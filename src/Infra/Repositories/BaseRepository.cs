using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DDDContext _context;
        private readonly DbSet<TEntity> _dataSet;

        public BaseRepository(DDDContext context) {
            _context = context;
            _dataSet = context.Set<TEntity>();
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _dataSet.AnyAsync(a => a.Id.Equals(id));
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await _dataSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> ListAsync()
        {
            return await _dataSet.ToArrayAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            if (entity.Id == Guid.Empty) entity.Id = Guid.NewGuid();
            entity.CreateAt = DateTime.UtcNow;
            entity.UpdateAt = DateTime.UtcNow;
            await _dataSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var entityDb = await _dataSet.FindAsync(entity.Id);
            entity.UpdateAt = DateTime.Now;
            entity.CreateAt = entityDb.CreateAt;
            _context.Entry(entityDb).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entityDb = await _dataSet.FindAsync(id);
            _dataSet.Remove(entityDb);
            await _context.SaveChangesAsync();
        }
    }
}
