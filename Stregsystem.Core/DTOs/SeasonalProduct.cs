using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stregsystem.Core.DTOs
{
    public record SeasonalProduct(int ID, string Name, decimal Price, bool Active, bool CanBuyOnCredit, DateTime SeasonStartDate, DateTime SeasonEndDate) : Product(ID, Name, Price, Active, CanBuyOnCredit);
}
