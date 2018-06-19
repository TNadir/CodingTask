using CodingSolution.Data.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodingSolution.Data.Interfaces
{
     public  interface ISector
    {
        IQueryable<Sectors> FindBy(Expression<Func<Sectors, bool>> predicate);
    }
}
