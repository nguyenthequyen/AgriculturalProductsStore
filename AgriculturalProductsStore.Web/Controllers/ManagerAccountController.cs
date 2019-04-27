using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgriculturalProductsStore.Models.Entity;
using AgriculturalProductsStore.Repository;
using AgriculturalProductsStore.Web.ViewModels.ManagerAccount;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using static AgriculturalProductsStore.Models.Enum.Enum;

namespace AgriculturalProductsStore.Web.Controllers
{
    public class ManagerAccountController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationIdentityDbContext _dbContext;

        public ManagerAccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ApplicationIdentityDbContext dbContext
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _dbContext = dbContext;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var uservm = await _userManager.FindByNameAsync(user.UserName);
                var userInfor = _dbContext.UserInfors.FirstOrDefault(x => x.IdentityUserId == user.Id);
                var userViewModel = new UserViewModel();
                userViewModel = new UserViewModel
                {
                    Email = uservm.Email,
                    PhoneNumber = uservm.PhoneNumber
                };
                var userInforViewModel = new UserInforViewModel();
                userInforViewModel = new UserInforViewModel
                {
                    BirthDay = userInfor.Birthday?.ToString(),
                    LastName = userInfor.LastName,
                    FirstName = userInfor.FirstName,
                    Gender = userInfor.Gender
                };

                ViewData["UserViewModel"] = userViewModel;
                ViewData["userInforViewModel"] = userInforViewModel;
                return View();
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserViewModel model, string returnUrl = null)
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> UpdatePassword(string returnUrl)
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                if (user == null)
                {
                    Alert("Không tìm thấy thông tin tài khoản", NotificationType.error);
                    return View(returnUrl);
                }
                else
                {
                    var chagePassword = await _userManager.ChangePasswordAsync(user, model.PasswordOld, model.Password);
                    if (chagePassword.Succeeded)
                    {
                        await _signInManager.RefreshSignInAsync(user);
                        Alert("Đổi mật khẩu thành công", NotificationType.success);
                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        Alert("Đổi mật khẩu thất bại", NotificationType.error);
                        return View(returnUrl);
                    }
                }
            }
            Alert("Đổi mật khẩu thất bại", NotificationType.error);
            return View(model);
        }
        #region private
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction(nameof(ManagerAccountController.Index), "Home");
        }
        #endregion
    }
}