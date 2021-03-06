﻿using AgriculturalProductsStore.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturalProductsStore.Web.ViewModels.ManagerAccount
{
    public class UpdateUserViewModel
    {
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email thoại không được để trống")]
        public string Email { get; set; }
        public int Gender { get; set; }
        public string Birthday { get; set; }
        [Required(ErrorMessage = "Họ đệm không được để trống")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        public string FirstName { get; set; }
    }
}
