﻿using Stregsystem.Core.DataProviders;
using Stregsystem.Core.DTOs;
using Stregsystem.Core.Exceptions;
using Stregsystem.Core.Logging;
using Stregsystem.Core.Logging.Loggers;
using Stregsystem.Core.Providers;
using Stregsystem.Core.Transactions;
using Stregsystem.Core.Validator;

#nullable enable
namespace Stregsystem.Core
{
    /// <summary>
    /// God object as specified by assignment. It does everything at once.
    /// </summary>
    public class Stregsystem : IUserProvider, IProductProvider, ITransactionProvider
    {
        /// <summary>
        /// transactions are simply stored in memory as the assignment did not specify that they couldn't be ephemeral.
        /// </summary>
        readonly ICollection<Transaction> transactions = new List<Transaction>();
        readonly ICollection<User> users;
        readonly ISet<Product> products;
        readonly string logfilePath = "transaction-log.txt";

        readonly IEmailValidator emailValidator;
        readonly INameValidator nameValidator;
        readonly IUsernameValidator usernameValidator;
        readonly ILogger logger;

        /// <summary>
        /// TODO: UserBalanceNotification, validator regex, tostring/comparator på nogle metoder
        /// </summary>
        /// <param name="userDataProvider"></param>
        /// <param name="productDataProvider"></param>
        /// <param name="emailValidator"></param>
        /// <param name="nameValidator"></param>
        /// <param name="usernameValidator"></param>
        internal Stregsystem(IUserDataProvider userDataProvider, IProductDataProvider productDataProvider, IEmailValidator emailValidator, INameValidator nameValidator, IUsernameValidator usernameValidator)
        {
            this.emailValidator = emailValidator;
            this.nameValidator = nameValidator;
            this.usernameValidator = usernameValidator;

            // Note: Consider not doing IO in a constructor.
            logger = new FileLogger(logfilePath);
            logger.Log("Started Stregsystem");

            // Loads user-and product-storage into memory.
            users = new List<User>(userDataProvider.GetUsers());
            logger.Log($"Finished loading {nameof(users)}");

            products = new HashSet<Product>(productDataProvider.GetProducts());
            logger.Log($"Finished loading {nameof(products)}");
        }

        /// <summary>
        /// Returns product when the following condition is met:
        /// Product active AND (product not seasonal OR product is in season)
        /// </summary>
        IEnumerable<Product> IProductProvider.ActiveProducts => products.Where(p => p.Active && (p is not SeasonalProduct || p is SeasonalProduct ps && (ps.SeasonStartDate < DateTime.Now || ps.SeasonEndDate > DateTime.Now)));

        public void BuyProduct(User user, Product product)
        {
            if (user.Balance < product.Price && !product.CanBuyOnCredit)
            {
                throw new InsufficientCreditsException(user, product);
            }

            ExecuteTransaction(new BuyTransaction(transactions.Count, user, product.Price));
        }

        public void AddCreditsToAccount(User user, decimal amount)
        {
            ExecuteTransaction(new InsertCashTransaction(transactions.Count, user, amount));
        }

        void ExecuteTransaction(Transaction transaction)
        {
            decimal balanceChange = 0;
            if (transaction is BuyTransaction)
            {
                balanceChange -= transaction.Amount;
            }
            else if (transaction is InsertCashTransaction)
            {
                balanceChange += transaction.Amount;
            }

            // Update User Balance:
            transaction.User.Balance += balanceChange;

            transaction.Execute();
            transactions.Add(transaction);
            logger.Log(transaction.ToString()!);
        }

        Product IProductProvider.GetProductByID(int ID)
        {
            return products.First(p => p.ID == ID);
        }

        User IUserProvider.GetUserByUsername(string username)
        {
            return users.First(u => u.Username == username);
        }

        IEnumerable<User> IUserProvider.GetUsers(Func<User, bool> predicate)
        {
            return users.Where(predicate);
        }

        IEnumerable<Transaction> ITransactionProvider.GetTransactionsByUser(User user, int rows)
        {
            return transactions.Where(t => t.User == user).TakeLast(rows);
        }
    }
}
