using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity 
    {
        Task<bool> ExistsAsync(Guid id);
        Task<TEntity> GetAsync(Guid id);
        Task<IEnumerable<TEntity>> ListAsync();
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
    }
}
