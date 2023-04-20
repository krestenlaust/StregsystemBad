using Stregsystem.Core.DTO;

namespace Stregsystem.Core
{
    public class Stregsystem
    {
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
            throw new NotImplementedException();
        }

        public Product GetProductByID(int ID)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetUsers(Func<User, bool> predicate)
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

        public IList<Product> ActiveProducts()
        {
            throw new NotImplementedException();
        }
    }
}
