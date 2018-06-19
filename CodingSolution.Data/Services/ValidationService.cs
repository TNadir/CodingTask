using CodingSolution.Data.Interfaces;
using CodingSolution.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingSolution.Data.Services
{
    public class ValidationService : IValidator
    {
        public Tuple<bool, string> ValidateForm(RegisterForm form)
        {
            bool isSuccess = false;
            string message = string.Empty;

            if (form == null)
            {

                message = "Fill all fields";
            }
            else if (string.IsNullOrEmpty(form.Name))
            {

                message = "Name is mandatary field!";
            }
            else if (form.Sector==null||form.Sector.Length == 0)
            {

                message = "Selector is mandatary field!";
            }
            else if (!form.Agree)
            {

                message = "You must agree with policy!";
            }
            else {

                isSuccess = true;
                message = "success";
            }

            return new Tuple<bool, string>(isSuccess, message);
        }
    }
}
