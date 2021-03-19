using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGenericRepositoryAsync<TEntity, TKey> where TEntity : AggregateRoot<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TKey id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        //Task DeleteAsync(TKey id);
        Task DeleteAsync(TEntity entity);
        bool SaveChanges();
    }
}
