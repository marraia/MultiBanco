using GasStation.Domain.Entities;
using GasStation.Domain.Interfaces.Repositories.Base;
using GasStation.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GasStation.Repositories.Repository.Base
{
    public class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey>, IDisposable
                where TEntity : EntityBase<TKey>
                where TKey : struct
    {
        protected readonly DbSet<TEntity> _db;
        protected readonly GasStationContext _context;

        protected RepositoryBase(GasStationContext context)
        {
            _context = context;
            _db = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> AlterAsync(TEntity entity)
        {
            var currentEntity = await GetByIdAsync(entity.Id).ConfigureAwait(false);
            _context.Entry(currentEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async virtual Task DeleteAsync(TEntity entity)
        {
            _db.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            await _db.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync()
        {
            var query =
                await _db
                        .AsNoTracking()
                        .ToListAsync()
                        .ConfigureAwait(false);

            return query;
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            Expression<Func<TEntity, bool>> predicate = t => t.Id.ToString() == id.ToString();
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public virtual void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
