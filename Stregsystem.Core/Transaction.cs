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
    public int AmountOfOere { get; }

    public Transaction(int ID, User user, int amountOfOere)
    {
        this.ID = ID;
        User = user;
        AmountOfOere = amountOfOere;
    }

    public void Execute()
    {
        Timestamp = DateTime.Now;
    }
}
