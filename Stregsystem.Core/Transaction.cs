using Stregsystem.Core.DTOs;

namespace Stregsystem.Core;

public abstract class Transaction
{
    public int ID { get; }
    public User User { get; }
    public DateTime Timestamp { get; private set; }

    /// <summary>
    /// Always non-negative value.
    /// </summary>
    public decimal Amount { get; }

    public Transaction(int ID, User user, decimal amount)
    {
        this.ID = ID;
        User = user;
        Amount = amount;
    }

    public void Execute()
    {
        Timestamp = DateTime.Now;
    }
}
