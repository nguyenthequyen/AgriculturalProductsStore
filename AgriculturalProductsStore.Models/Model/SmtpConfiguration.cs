using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProductsStore.Models
{
    public class SmtpConfiguration
    {
        public string Host { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Port { get; set; } = 587; // default smtp port
        public bool UseSSL { get; set; } = true;
    }
}
