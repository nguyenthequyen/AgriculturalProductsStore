using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProductsStore.Models.Entity
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual ApplicationRole ApplicationRole { get; set; }
    }
}
