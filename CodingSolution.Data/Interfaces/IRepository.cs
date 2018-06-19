using CodingSolution.Data.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodingSolution.Data.Interfaces
{
    public interface IRepository<T> where T:AuditEntity
    {
        T GetById(int id);

        T Insert(T entity);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Update(T entity);
      
        void Delete(T entity);

     
       
    }
}
