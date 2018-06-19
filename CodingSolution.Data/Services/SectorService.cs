using CodingSolution.Data.Domen;
using CodingSolution.Data.Interfaces;
using CodingSolution.Data.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodingSolution.Data.Services
{
    public class SectorService : ISector
    {
        private readonly IUnitOfWork unit;
        public SectorService(IUnitOfWork unit) => this.unit = unit;
        public IQueryable<Sectors> FindBy(Expression<Func<Sectors, bool>> predicate)
        {
            return this.unit.Repository<Sectors>().FindBy(predicate);
        }
    }
}
