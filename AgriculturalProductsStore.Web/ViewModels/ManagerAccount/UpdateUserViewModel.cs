using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturalProductsStore.Web.ViewModels.ManagerAccount
{
    public class UpdateUserViewModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }
        public string Birthday { get; set; }
    }
}
