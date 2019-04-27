using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturalProductsStore.Web.ViewModels.ManagerAccount
{
    public class UpdatePasswordViewModel
    {
        public string PasswordOld { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
