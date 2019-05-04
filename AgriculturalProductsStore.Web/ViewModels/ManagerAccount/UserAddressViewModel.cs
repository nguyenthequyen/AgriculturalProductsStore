using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturalProductsStore.Web.ViewModels.ManagerAccount
{
    public class UserAddressViewModel
    {
        [Required(ErrorMessage = "Họ và tên không được để trống")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Tỉnh/Thành phố không được để trống")]
        public string ProvinceCity { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string PhoneNumber { get; set; }
        public string Company { get; set; }
        [Required(ErrorMessage = "Quận/Huyện không được để trống")]
        public string District { get; set; }
        [Required(ErrorMessage = "Phường/Xã không được để trống")]
        public string Ward { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string Address { get; set; }
        public int? AddressType { get; set; }
        public bool IsDefault { get; set; }
        public string Id { get; set; }
    }
}
