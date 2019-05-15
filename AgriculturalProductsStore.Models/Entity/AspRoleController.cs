using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgriculturalProductsStore.Models.Entity
{
    public class AspRoleController
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Controller")]
        public string Controller { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("Action")]
        public string Action { get; set; }
        public string Desctiption { get; set; }
        [Key, Column(Order = 2)]
        public string IdentityRoleId { get; set; }
        public ApplicationRole IdentityRole { get; set; }

    }
}
