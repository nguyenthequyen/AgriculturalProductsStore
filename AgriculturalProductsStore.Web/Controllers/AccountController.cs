using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AgriculturalProductsStore.Models.Constants;
using AgriculturalProductsStore.Models.Entity;
using AgriculturalProductsStore.Repository;
using AgriculturalProductsStore.Services;
using AgriculturalProductsStore.Web.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgriculturalProductsStore.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationIdentityDbContext _dbContext;
        private readonly IEmailSender _emailSender;
        private readonly IUserInforService _userInforService;
        private readonly ILogger<AccountController> _logger;
        public AccountController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            ApplicationIdentityDbContext dbContext,
            IEmailSender emailSender,
            IUserInforService userInforService,
            ILogger<AccountController> logger
            ) : base(logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _dbContext = dbContext;
            _emailSender = emailSender;
            _userInforService = userInforService;
            _logger = logger;
        }
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
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
        public IActionResult Register(string returnUrl = null)
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
                        user = new ApplicationUser
                        {
                            UserName = model.Username,
                            Email = model.Username
                        };
                        var resultCreatedUser = await _userManager.CreateAsync(user, model.Password);

                        if (resultCreatedUser.Succeeded)
                        {
                            var userInfor = new UserInfor
                            {
                                FirstName = model.FirstName,
                                LastName = model.LastName,
                                IdentityUserId = user.Id
                            };
                            _userInforService.AddUserInfor(userInfor);
                            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                            var callbackUrl = Url.Action(
                                "ConfirmEmail",
                                "Account",
                                new { userId = user.Id, code = code },
                                HttpContext.Request.Scheme
                                );
                            var url = string.Format("Vui lòng xác nhận tài khoản của bạn bằng cách nhấn &lt;a href='{0}'&gt;vào đây&lt;/a&gt;.", HtmlEncoder.Default.Encode(callbackUrl));
                            await _emailSender.SendEmailAsync(model.Username, "Xác nhận tài khoản của  bạn", url);
                            //await _signInManager.SignInAsync(user, isPersistent: false);
                            return RedirectToLocal(returnUrl);
                        }
                    }
                }
                else if (matchPhone.Success)
                {
                    user = await _userManager.FindByEmailAsync(model.Username);
                    if (user != null)
                    {
                        ModelState.AddModelError("Username", "Email này đã được đăng ký tài khoản.");
                        return View(model);
                    }
                    else
                    {
                        user = new ApplicationUser
                        {
                            UserName = model.Username,
                            PhoneNumber = model.Username,
                            PhoneNumberConfirmed = true
                        };
                        var result = await _userManager.CreateAsync(user, model.Password);

                        if (result.Succeeded)
                        {
                            var userInfor = new UserInfor
                            {
                                FirstName = model.FirstName,
                                LastName = model.LastName,
                                IdentityUserId = user.Id,
                            };
                            _userInforService.AddUserInfor(userInfor);
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
        public IActionResult ResetPassword(string returnUrl)
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code, string returnUrl = null)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("Error");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: true);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        #region private
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        #endregion
    }
}