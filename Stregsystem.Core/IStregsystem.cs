using Stregsystem.Core.Providers;

namespace Stregsystem.Core;

public interface IStregsystem
{
    IUserProvider UserProvider { get; }
    IProductProvider ProductProvider { get; }
    ITransactionProvider TransactionProvider { get; }
}
