using AgriculturalProductsStore.Models.Entity;
using AgriculturalProductsStore.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProductsStore.Services
{
    public interface ICategoryService : IBaseService<Category>
    {
        void InsertCategory(List<Category> category);
        void UpdateCategory(List<Category> category);
        void DeleteCategory(List<Category> category);
    }
}
