using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProductsStore.Repository
{
    public class AgriculturalProductsStoreDbContext : DbContext
    {
        public AgriculturalProductsStoreDbContext(DbContextOptions<AgriculturalProductsStoreDbContext> options)
            : base(options)
        { }
    }
}
