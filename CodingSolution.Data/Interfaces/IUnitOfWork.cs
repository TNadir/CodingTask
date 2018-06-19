using CodingSolution.Data.Domen;
using CodingSolution.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingSolution.Data.Interfaces
{
    public interface IUnitOfWork
    {
        Repository<T> Repository<T>() where T : AuditEntity;
        void Save();
    }
}
