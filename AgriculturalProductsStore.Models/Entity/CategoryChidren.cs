using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProductsStore.Models.Entity
{
    public class CategoryChidren : BaseEntity
    {
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
