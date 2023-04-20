using Stregsystem.Core.DTO;

namespace Stregsystem.Core.DataProviders
{
    public interface ITransactionProvider
    {
        IEnumerable<Transaction> GetTransactionsByUser(User user, int rows);
    }
}
