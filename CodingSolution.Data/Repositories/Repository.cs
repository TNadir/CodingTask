
using CodingSolution.Data.Domen;
using CodingSolution.Data.Interfaces;
using CodingSolution.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

namespace CodingSolution.Data.Repositories
{
    public class Repository<T> :
        IRepository<T> where T : AuditEntity
    {
        private readonly ApplicationDbContext context;
        private IDbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(ApplicationDbContext _context)
        {
            this.context = _context;
        }

        public T GetById(int id)
        {
            return this.Entities.Find(id);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return this.Entities.Where(predicate);
        }

        public T Insert(T entity)
        {

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.Entities.Add(entity);
            return entity;

        }

        public void Update(T entity)
        {

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.context.Entry(entity).State = EntityState.Modified;

        }

        public void Delete(T entity)
        {
           
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            this.context.Entry(entity).State = EntityState.Deleted;
            
        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        private IDbSet<T> Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = context.Set<T>();
                }
                return entities;
            }
        }
    }
}
