using Stregsystem.Core.DTOs;

namespace Stregsystem.Core.Providers;

public interface ITransactionProvider
{
    IEnumerable<Transaction> GetTransactionsByUser(User user, int rows);
}
