using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProductsStore.Models.Entity
{
    public class UserInfor : BaseEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int? Gender { get; set; }
        public string Birthday { get; set; }
        public string IdentityUserId { get; set; }
        public ApplicationUser IdentityUser { get; set; }
    }
}
