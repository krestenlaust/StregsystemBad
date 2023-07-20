using Stregsystem.Core.DTOs;

namespace Stregsystem.Core.Transactions;

public class InsertCashTransaction : Transaction
{
    public InsertCashTransaction(int ID, User user, int amountOfOere) : base(ID, user, amountOfOere)
    {
    }
}
