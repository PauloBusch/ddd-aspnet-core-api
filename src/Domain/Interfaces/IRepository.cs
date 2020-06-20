using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity 
    {
        Task<TEntity> GetAsync(Guid id);
        Task<IEnumerable<TEntity>> ListAsync();
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
    }
}
