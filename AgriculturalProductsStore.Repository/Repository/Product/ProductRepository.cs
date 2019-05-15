using AgriculturalProductsStore.Models.Entity;
using AgriculturalProductsStore.Repository.BaseRepository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProductsStore.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ApplicationIdentityDbContext _dbContext;
        public ProductRepository(ApplicationIdentityDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteProduct(Product product)
        {
            Delete(product);
        }

        public void InsertProduct(Product product)
        {
            Insert(product);
        }

        public void UpdateProduct(Product product)
        {
            Update(product);
        }
    }
}
