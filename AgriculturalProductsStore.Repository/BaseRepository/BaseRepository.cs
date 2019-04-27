using AgriculturalProductsStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProductsStore.Repository.BaseRepository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private ApplicationIdentityDbContext _dbContext;
        public BaseRepository(ApplicationIdentityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }
        public virtual void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> GetAllRecords()
        {
            return _dbContext.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetFirstOrDefault(Guid recordId)
        {
            return await _dbContext.Set<TEntity>().FindAsync(recordId);
        }

        public virtual void Save()
        {
            _dbContext.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }
    }
}
