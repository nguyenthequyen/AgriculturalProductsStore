using AgriculturalProductsStore.Models.Entity;
using AgriculturalProductsStore.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProductsStore.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
