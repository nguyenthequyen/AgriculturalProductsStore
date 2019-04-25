using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProductsStore.Models.Entity
{
    public class UserInfor: BaseEntity
    {
        public string Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string IdentityUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
