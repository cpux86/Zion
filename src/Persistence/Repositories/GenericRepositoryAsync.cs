using Domain.Common;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GenericRepositoryAsync<TEntity, TKey> : IGenericRepositoryAsync<TEntity, TKey>
        where TEntity : AggregateRoot<TKey>
    {
        private readonly CatalogContext _catalogContext;
        private readonly DbSet<TEntity> table;
        public GenericRepositoryAsync(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
            table = _catalogContext.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await table.FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await table.AddAsync(entity);
            await _catalogContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            // здесь обновится сущьность полностью
            _catalogContext.Entry(entity).State = EntityState.Modified;
            // а здесь только измененные заначения
            _catalogContext.Attach(entity);
            
            await _catalogContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            table.Remove(entity);
            await _catalogContext.SaveChangesAsync();
        }

        public bool SaveChanges()
        {
            return (_catalogContext.SaveChanges() >= 0);
        }

        
    }
}
