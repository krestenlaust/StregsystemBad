using Stregsystem.Core.DataProviders;
using Stregsystem.Core.DTO;

namespace Stregsystem.Core
{
    /// <summary>
    /// God object as specified by assignment. It does everything and nothing at once.
    /// </summary>
    public class Stregsystem : IUserProvider, IProductProvider, ITransactionProvider
    {
        /// <summary>
        /// transactions are simply stored in memory as the assignment did not specify that they couldn't be ephemeral.
        /// </summary>
        readonly HashSet<Transaction> transactions = new HashSet<Transaction>();

        public IEnumerable<Product> ActiveProducts => throw new NotImplementedException();

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
        }

        public Product GetProductByID(int ID)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUsername(string username)
        {
            throw new NotImplementedException();

        }

        public IList<Transaction> GetTransactions(User user, int count)
        {
            throw new NotImplementedException();
        }

        public User GetUsers(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetTransactionsByUser(User user, int rows)
        {
            throw new NotImplementedException();
        }
    }
}
