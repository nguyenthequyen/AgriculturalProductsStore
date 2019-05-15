using AgriculturalProductsStore.Models;
using AgriculturalProductsStore.Repository.BaseRepository;
using AgriculturalProductsStore.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProductsStore.Services.BaseServices
{
    public class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : BaseEntity, new()
    {
        private readonly IBaseRepository<TEntity> _reponsitory;
        private readonly IUnitOfWork _unitOfWork;
        public BaseService(IUnitOfWork unitOfWork, IBaseRepository<TEntity> reponsitory)
        {
            _reponsitory = reponsitory;
            _unitOfWork = unitOfWork;
        }
        public void Insert(TEntity entity)
        {
            _reponsitory.Insert(entity);
        }

        public void Delete(TEntity entity)
        {
            _reponsitory.Delete(entity);
        }

        public IEnumerable<TEntity> GetAllRecords()
        {
            return _reponsitory.GetAllRecords();
        }

        public async Task<TEntity> GetFirstOrDefault(string id)
        {
            return await _reponsitory.GetFirstOrDefault(id);
        }

        public void Save()
        {
            _reponsitory.Save();
        }

        public void Update(TEntity entity)
        {
            _reponsitory.Update(entity);
        }
    }
}
