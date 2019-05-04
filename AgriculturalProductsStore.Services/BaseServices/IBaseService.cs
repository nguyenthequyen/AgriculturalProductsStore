using AgriculturalProductsStore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProductsStore.Services.BaseServices
{
    public interface IBaseService<TEntity> : IService
     where TEntity : BaseEntity, new()
    {
        IEnumerable<TEntity> GetAllRecords();
        Task<TEntity> GetFirstOrDefault(string recordId);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Save();
    }
}
