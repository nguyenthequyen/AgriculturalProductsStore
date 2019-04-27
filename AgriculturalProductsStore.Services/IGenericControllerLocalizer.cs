using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProductsStore.Services
{
    public interface IGenericControllerLocalizer<T> : IStringLocalizer<T>
    {

    }
}
