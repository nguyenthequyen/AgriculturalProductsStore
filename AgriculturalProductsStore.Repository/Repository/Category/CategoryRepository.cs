using AgriculturalProductsStore.Models.Entity;
using AgriculturalProductsStore.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProductsStore.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationIdentityDbContext _dbContext;
        public CategoryRepository(ApplicationIdentityDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteCategory(Category category)
        {
            Delete(category);
        }

        public void InsertCategory(Category category)
        {
            Insert(category);
        }

        public void UpdateCategory(Category category)
        {
            Update(category);
        }
    }
}
