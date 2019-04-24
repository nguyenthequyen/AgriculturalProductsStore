using System.ComponentModel.DataAnnotations;

namespace AgriculturalProductsStore.Web.ViewModels.Account
{
    public class LoginInputModel
    {
        [Required(ErrorMessage ="Tên tài khoản không được để trống")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
    }
}