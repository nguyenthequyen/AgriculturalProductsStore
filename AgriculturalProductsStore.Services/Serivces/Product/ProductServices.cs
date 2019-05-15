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
    public class ProductServices : BaseService<Product>, IProductServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _reponsitory;
        public ProductServices(IUnitOfWork unitOfWork, IProductRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _unitOfWork = unitOfWork;
            _reponsitory = reponsitory;
        }

        public void DeleteProduct(List<Product> product)
        {
            foreach (var item in product)
            {
                Insert(item);
            }
            _unitOfWork.Commit();
        }

        public void InsertProduct(List<Product> product)
        {
            foreach (var item in product)
            {
                Insert(item);
            }
            _unitOfWork.Commit();
        }

        public void UpdateProduct(List<Product> product)
        {
            foreach (var item in product)
            {
                Insert(item);
            }
            _unitOfWork.Commit();
        }
    }
}
