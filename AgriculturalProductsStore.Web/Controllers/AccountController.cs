using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AgriculturalProductsStore.Models.Constants;
using AgriculturalProductsStore.Models.Entity;
using AgriculturalProductsStore.Web.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturalProductsStore.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager
            )
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                ApplicationUser user = null;
                Regex regexEmail = new Regex(RegexConstants.RegexEmail);
                Regex regexPhone = new Regex(RegexConstants.RegexPhoneNumber);
                Match matchEmail = regexEmail.Match(model.Username);
                Match matchPhone = regexPhone.Match(model.Username);
                if (matchEmail.Success)
                {
                    user = await _userManager.FindByEmailAsync(model.Username);
                    if (user == null)
                    {
                        ModelState.AddModelError("Username", "Tên đăng nhập hoặc mật khẩu không đúng. Xin vui lòng kiểm tra lại");
                        return View(model);
                    }
                    else
                    {
                        var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberLogin, lockoutOnFailure: true);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        if (result.IsLockedOut)
                        {
                            return RedirectToAction("Lockout", "Account");
                        }
                        else
                        {
                            ModelState.AddModelError("Password", "Mật khẩu đăng nhập không đúng. Xin vui lòng kiểm tra lại");
                            return View(model);
                        }
                    }
                }
                else if (matchPhone.Success)
                {
                    user = _userManager.Users.FirstOrDefault(x => x.PhoneNumber == model.Username);
                    if (user == null)
                    {
                        ModelState.AddModelError("Username", "Tên đăng nhập hoặc mật khẩu không đúng. Xin vui lòng kiểm tra lại");
                        return View(model);
                    }
                    else
                    {
                        var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberLogin, lockoutOnFailure: true);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        if (result.IsLockedOut)
                        {
                            return RedirectToAction("Lockout", "Account");
                        }
                        else
                        {
                            ModelState.AddModelError("Password", "Mật khẩu đăng nhập không đúng. Xin vui lòng kiểm tra lại");
                            return View(model);
                        }

                    }
                }
                else
                {
                    ModelState.AddModelError("Username", "Định dạng email hoặc số điện thoại không hợp lệ");
                    return View(model);
                }
            }
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = null;
                Regex regexEmail = new Regex(RegexConstants.RegexEmail);
                Regex regexPhone = new Regex(RegexConstants.RegexPhoneNumber);
                Match matchEmail = regexEmail.Match(model.Username);
                Match matchPhone = regexPhone.Match(model.Username);
                if (matchEmail.Success)
                {
                    user = await _userManager.FindByEmailAsync(model.Username);
                    if (user != null)
                    {
                        ModelState.AddModelError("Username", "Email này đã được đăng ký tài khoản.");
                        return View(model);
                    }
                    else
                    {

                    }
                }
                else if (matchPhone.Success)
                {

                }
                else
                {
                    ModelState.AddModelError("Username", "Định dạng email hoặc số điện thoại không hợp lệ");
                    return View(model);
                }
            }
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(string returnUrl)
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Lockout(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}