using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stregsystem.Core.DTOs
{
    public record User(int ID, string Firstname, string Lastname, string Username, string Emailaddress, decimal balance);
}
