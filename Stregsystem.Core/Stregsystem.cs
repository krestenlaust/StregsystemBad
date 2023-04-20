using Stregsystem.Core.Providers;
using Stregsystem.Core.DTOs;
using Stregsystem.Core.DataProviders;
using Stregsystem.Core.Validator;
using Stregsystem.Core.Logging;
using Stregsystem.Core.Logging.Loggers;

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
        readonly HashSet<Transaction> transactions = new HashSet<Transaction>();
        readonly string logfilePath = "log.txt";

        readonly IUserDataProvider userDataProvider;
        readonly IProductDataProvider productDataProvider;
        readonly IEmailValidator emailValidator;
        readonly INameValidator nameValidator;
        readonly IUsernameValidator usernameValidator;
        readonly ILogger logger;

        internal Stregsystem(IUserDataProvider userDataProvider, IProductDataProvider productDataProvider, IEmailValidator emailValidator, INameValidator nameValidator, IUsernameValidator usernameValidator)
        {
            this.userDataProvider = userDataProvider;
            this.productDataProvider = productDataProvider;
            this.emailValidator = emailValidator;
            this.nameValidator = nameValidator;
            this.usernameValidator = usernameValidator;

            // Note: Consider not doing IO in a constructor.
            logger = new FileLogger(logfilePath);
            logger.Log("Started Stregsystem");
        }

        IEnumerable<Product> IProductProvider.ActiveProducts => throw new NotImplementedException();

        public void BuyProduct(User user, Product product)
        {
            throw new NotImplementedException();
        }

        public void AddCreditsToAccount(User user, decimal amount)
        {
            throw new NotImplementedException();
        }

        void ExecuteTransaction(Transaction transaction)
        {
            transaction.Execute();
            transactions.Add(transaction);
            logger.Log(transaction.ToString()!);
        }

        Product IProductProvider.GetProductByID(int ID)
        {
            return productDataProvider.GetProducts().First(p => p.ID == ID);
        }

        User IUserProvider.GetUserByUsername(string username)
        {
            return userDataProvider.GetUsers().First(u => u.Username == username);
        }

        IEnumerable<User> IUserProvider.GetUsers(Func<User, bool> predicate)
        {
            return userDataProvider.GetUsers().Where(predicate);
        }

        IEnumerable<Transaction> ITransactionProvider.GetTransactionsByUser(User user, int rows)
        {
            throw new NotImplementedException();
        }
    }
}
