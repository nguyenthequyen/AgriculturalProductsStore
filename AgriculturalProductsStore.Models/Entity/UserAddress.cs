using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProductsStore.Models.Entity
{
    public class UserAddress : BaseEntity
    {
        public string FullName { get; set; }
        public string ProvinceCity { get; set; }
        public string PhoneNumber { get; set; }
        public string Company { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string Address { get; set; }
        public int? AddressType { get; set; }
        public bool IsDefault { get; set; }
        public string IdentityUserId { get; set; }
        public ApplicationUser IdentityUser { get; set; }
    }
}
