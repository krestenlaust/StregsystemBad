namespace Stregsystem.Core;

public interface IBroker
{
    void ExecuteTransaction(Transaction transaction);
}
