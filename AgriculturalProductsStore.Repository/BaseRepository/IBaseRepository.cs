using AgriculturalProductsStore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProductsStore.Repository.BaseRepository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        IEnumerable<TEntity> GetAllRecords();
        Task<TEntity> GetFirstOrDefault(string id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Save();
    }
}
