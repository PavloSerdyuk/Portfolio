using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Training.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Training.DAL.Repositories.Abstractions
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByKeys(params object[] keys);
        Task<TEntity> CreateAsync(TEntity Element);
        Task<bool> DeleteAsync(TEntity entity);
        void UpdateAsync(TEntity Element);
        Task<int> SaveChangesAsync();
    }
}
