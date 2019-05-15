using AgriculturalProductsStore.Models.Entity;
using AgriculturalProductsStore.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProductsStore.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        void InsertCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
