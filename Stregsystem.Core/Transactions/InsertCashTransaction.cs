using Stregsystem.Core.DTOs;

namespace Stregsystem.Core.Transactions
{
    internal class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(int ID, User user, decimal amount) : base(ID, user, amount)
        {
        }
    }
}
