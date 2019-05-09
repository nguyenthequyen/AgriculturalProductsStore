using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturalProductsStore.Web.Configuration
{
    public static class ActivePage
    {
        public static string Index => "Index";

        public static string ChangePassword => "ChangePassword";

        public static string ExternalLogins => "ExternalLogins";

        public static string PersonalData => "PersonalData";

        public static string TwoFactorAuthentication => "TwoFactorAuthentication";
        public static string ManagerAddress => "ManagerAddress";
        public static string ManagerOrder => "ManagerOrder";
        public static string ManagerPay => "ManagerPay";
        public static string ProductsPurchasedLater => "ProductsPurchasedLater";

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);

        public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword);

        public static string ExternalLoginsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ExternalLogins);

        public static string PersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, PersonalData);

        public static string TwoFactorAuthenticationNavClass(ViewContext viewContext) => PageNavClass(viewContext, TwoFactorAuthentication);
        public static string ManagerAddressClass(ViewContext viewContext) => PageNavClass(viewContext, ManagerAddress);
        public static string ManagerOrderClass(ViewContext viewContext) => PageNavClass(viewContext, ManagerOrder);
        public static string ManagerPayClass(ViewContext viewContext) => PageNavClass(viewContext, ManagerPay);
        public static string ProductsPurchasedLaterClass(ViewContext viewContext) => PageNavClass(viewContext, ProductsPurchasedLater);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
