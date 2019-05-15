using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgriculturalProductsStore.Models.Entity
{
    public class AspController
    {
        [Key, Column(Order = 0)]
        public string Controller { get; set; }
        [Key, Column(Order = 1)]
        public string Action { get; set; }
        public string Area { get; set; }
        public string Desctiption { get; set; }
        public bool IsDelete { get; set; }
    }
}
