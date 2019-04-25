using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturalProductsStore.Web.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Họ đệm không được để trống")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Tên tài khoản không được để trống")]
        [EmailAddress]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(100, ErrorMessage = "{0} Mật khẩu phải chứa ít nhất {2} và tối đa {1} ký tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu và xác nhận mật khẩu phải trùng nhau")]
        public string ConfirmPassword { get; set; }
    }
}
