using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProductsStore.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void RollBack();
    }
}
