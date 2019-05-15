using AgriculturalProductsStore.Models.Entity;
using AgriculturalProductsStore.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProductsStore.Services
{
    public interface IProductServices : IBaseService<Product>
    {
        void InsertProduct(List<Product> product);
        void UpdateProduct(List<Product> product);
        void DeleteProduct(List<Product> product);
    }
}
