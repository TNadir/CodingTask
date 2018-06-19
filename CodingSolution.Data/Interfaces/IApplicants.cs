using CodingSolution.Data.Domen;
using CodingSolution.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingSolution.Data.Interfaces
{
   public interface IApplicants
    {
        void Add(List<Applicants> applicants);
        void  Apply(int candidateId, RegisterForm registerForm);
        bool Delete(Applicants applicants);
    }
}
