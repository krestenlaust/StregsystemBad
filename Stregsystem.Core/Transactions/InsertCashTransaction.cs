using Stregsystem.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stregsystem.Core.Transactions
{
    internal class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(int ID, User user, DateTime timestamp, decimal amount) : base(ID, user, timestamp, amount)
        {
        }


    }
}
