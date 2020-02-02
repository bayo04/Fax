using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRepository<TEntity, TKey, TCreate> 
        where TEntity : class
    {
        Task<bool> Add(TCreate entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(TKey id);
        Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task Delete(TEntity entity);
        Task Update(TEntity entity);
    }
}
