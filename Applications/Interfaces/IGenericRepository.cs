using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ChessApp.Applications.Interfaces
{
    public interface IGenericRepository<in TKey, TEntity>
    {
        // Sync method
         TEntity Create(TEntity entity);
         TEntity Update(TEntity entity);

         Task Delete(TKey key);
         Task Detele(TEntity entity);

         // Async method
         Task<TEntity> CreateAsync(TEntity entity);
         Task<TEntity> UpdateAsync(TEntity entity);
         Task DeleteAsync(TKey key);
         Task DeleteAsync(TEntity entity);
    }
}