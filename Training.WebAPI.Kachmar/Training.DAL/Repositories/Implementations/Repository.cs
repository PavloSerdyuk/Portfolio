using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Training.DAL.Entities;
using Training.DAL.Repositories.Abstractions;

namespace Training.DAL.Repositories.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private TrainingContext Context { get; set; }
        private DbSet<TEntity> DbSet { get; set; }


        public Repository(TrainingContext context)
        {
            this.Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() =>
            await DbSet.ToListAsync<TEntity>();


        public async Task<TEntity> GetByKeys(params object[] keys) =>
            await DbSet.FindAsync(keys);


        public async Task<TEntity> CreateAsync(TEntity Element)
        {
            if (Element == null)
            {
                throw new ArgumentNullException(nameof(Element));
            }
            await DbSet.AddAsync(Element);
            return Element;
        }

        public async Task<bool> DeleteAsync(TEntity entity) =>
            (await Task.Run(() => DbSet.Remove(entity))).Entity != null;

        public void UpdateAsync(TEntity Element)
        {
            DbSet.Attach(Element);
            Context.Entry(Element).State = EntityState.Modified;
        }

        /// <summary> 
        /// Saves changes in the database asynchronously.
        /// </summary>
        /// <returns>Task</returns>
        public Task<int> SaveChangesAsync() => Context.SaveChangesAsync();
    }
}
