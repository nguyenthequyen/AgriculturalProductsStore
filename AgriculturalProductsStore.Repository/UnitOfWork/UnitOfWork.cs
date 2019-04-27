using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgriculturalProductsStore.Repository.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ApplicationIdentityDbContext _dbContext;
        public UnitOfWork(ApplicationIdentityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }

        public void RollBack()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }
    }
}
