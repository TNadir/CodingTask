using CodingSolution.Data.Domen;
using CodingSolution.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingSolution.Data.Interfaces
{
    public  interface ICandidate
    {
        Candidates Insert(Candidates candidates);

        Candidates Get(int candId);
        List<CandidatesSectors> GetSectorsById(int candId);
        bool Update(Candidates candidates);
    }
}
