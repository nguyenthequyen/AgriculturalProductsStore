using AgriculturalProductsStore.Models.Entity;
using AgriculturalProductsStore.Repository;
using AgriculturalProductsStore.Repository.BaseRepository;
using AgriculturalProductsStore.Repository.UnitOfWork;
using AgriculturalProductsStore.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProductsStore.Services
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _reponsitory;
        public CategoryService(IUnitOfWork unitOfWork, ICategoryRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _unitOfWork = unitOfWork;
            _reponsitory = reponsitory;
        }

        public void DeleteCategory(List<Category> category)
        {
            foreach (var item in category)
            {
                Delete(item);
            }
            _unitOfWork.Commit();
        }

        public void InsertCategory(List<Category> category)
        {
            foreach (var item in category)
            {
                Insert(item);
            }
            _unitOfWork.Commit();
        }

        public void UpdateCategory(List<Category> category)
        {
            foreach (var item in category)
            {
                Update(item);
            }
            _unitOfWork.Commit();
        }
    }
}
