using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stregsystem.Core.DTO
{
    public record Product(int ID, string Name, decimal Price, bool Active, bool CanBuyOnCredit);
}
