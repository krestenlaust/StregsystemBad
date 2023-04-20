using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stregsystem.Core.Validator
{
    public interface INameValidator
    {
        public bool IsFirstnameValid(string firstname);
        public bool IsSurnameValid(string surname);
    }
}
