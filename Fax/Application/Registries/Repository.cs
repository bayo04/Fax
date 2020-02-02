using Core;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Registries
{
    public class Repository<TEntity, TKey, TCreate>
        : IRepository<TEntity, TKey, TCreate>
        where TEntity : class
    {
        protected FaxDbContext _faxDbContext { get; set; }
        //public Repository(FaxDbContext faxDbContext)
        //{
        //    _faxDbContext = faxDbContext;
        //}
        public virtual async Task<bool> Add(TCreate entity)
        {
            await _faxDbContext.AddAsync(entity);
            return true;
        }

        public virtual async Task Delete(TEntity entity)
        {
            _faxDbContext.Remove(entity);
        }

        public virtual async Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await _faxDbContext.Set<TEntity>().FindAsync(predicate);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _faxDbContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetById(TKey id)
        {
            return await _faxDbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task Update(TEntity entity)
        {
            _faxDbContext.Set<TEntity>().Update(entity);
        }
    }
}
