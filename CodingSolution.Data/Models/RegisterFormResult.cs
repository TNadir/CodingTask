using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingSolution.Data.Models
{
     public  class RegisterFormResult
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
        public List<CandidatesSectors> Sectors { get; set; }
    }
}
