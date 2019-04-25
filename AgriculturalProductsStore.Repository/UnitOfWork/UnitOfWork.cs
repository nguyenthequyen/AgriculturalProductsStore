using System;
using System.Collections.Generic;
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
            _dbContext.Dispose();
        }
    }
}
