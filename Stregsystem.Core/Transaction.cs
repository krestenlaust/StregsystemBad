using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stregsystem.Core.DTO;

namespace Stregsystem.Core
{
    public abstract class Transaction
    {
        public int ID { get; }
        public User User { get; }
        public DateTime Timestamp { get; private set; }
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
}
