using CodingSolution.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingSolution.Data.Interfaces
{
    public interface IValidator
    {
        Tuple<bool, string> ValidateForm(RegisterForm form);
    }
}
