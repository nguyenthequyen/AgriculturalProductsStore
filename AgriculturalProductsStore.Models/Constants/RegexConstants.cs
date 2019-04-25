using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProductsStore.Models.Constants
{
    public static class RegexConstants
    {
        public const string RegexEmail = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public const string RegexPhoneNumber = @"^((\(\d{3}\) ?)|(\d{3}))?\d{3}\d{4}$";
    }
}
