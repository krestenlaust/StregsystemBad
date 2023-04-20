using Stregsystem.Core.DTO;

namespace Stregsystem.Core.Transactions
{
    internal class BuyTransaction : Transaction
    {
        public Product Product { get; }

        public BuyTransaction(int ID, User user, DateTime timestamp, decimal amount) : base(ID, user, timestamp, amount)
        {
        }
    }
}
