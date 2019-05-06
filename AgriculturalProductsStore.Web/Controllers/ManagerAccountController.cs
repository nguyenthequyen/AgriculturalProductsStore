using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AgriculturalProductsStore.Models.Constants;
using AgriculturalProductsStore.Models.Entity;
using AgriculturalProductsStore.Repository;
using AgriculturalProductsStore.Services;
using AgriculturalProductsStore.Web.ViewModels.ManagerAccount;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static AgriculturalProductsStore.Models.Enum.Enum;

namespace AgriculturalProductsStore.Web.Controllers
{
    public class ManagerAccountController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationIdentityDbContext _dbContext;
        private readonly IUserInforService _userInforService;
        private readonly IUserAddressService _userAddressService;
        private readonly ILogger<ManagerAccountController> _logger;
        private readonly IMapper _mapper;

        public ManagerAccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ApplicationIdentityDbContext dbContext,
            IUserInforService userInforService,
            IUserAddressService userAddressService,
            ILogger<ManagerAccountController> logger,
            IMapper mapper
            ) : base(logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _dbContext = dbContext;
            _userInforService = userInforService;
            _userAddressService = userAddressService;
            _logger = logger;
            _mapper = mapper;
        }
        /// <summary>
        /// Màn hình thông tin tài khoản
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        /// Created by: NTQuyen 06/05/2019
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
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
                    PhoneNumber = uservm.PhoneNumber,
                    BirthDay = userInfor.Birthday?.ToString(),
                    LastName = userInfor.LastName,
                    FirstName = userInfor.FirstName,
                    Gender = userInfor.Gender
                };

                ViewData["UserViewModel"] = userViewModel;
                return View(userViewModel);
            }
        }
        /// <summary>
        /// Xứ lý sửa thông tin tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        /// Created by: NTQuyen 06/05/2019
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Index(UserViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var userContext = await _userManager.GetUserAsync(HttpContext.User);
                if (userContext == null)
                {
                    Alert("Không tìm thấy thông tin tài khoản", NotificationType.error);
                    return View(model);
                }
                else
                {
                    ApplicationUser user = null;
                    Regex regexEmail = new Regex(RegexConstants.RegexEmail);
                    Regex regexPhone = new Regex(RegexConstants.RegexPhoneNumber);
                    Match matchEmail = regexEmail.Match(model.Email);
                    Match matchPhone = regexPhone.Match(model.PhoneNumber);
                    if (matchEmail.Success && matchPhone.Success)
                    {
                        user = await _userManager.FindByNameAsync(userContext.UserName);
                        var userInfor = await _userInforService.FindUserInforByUserId(user.Id);
                        if (user != null)
                        {
                            if (userInfor != null)
                            {
                                user.Email = model.Email;
                                user.PhoneNumber = model.PhoneNumber;
                                userInfor.LastName = model.LastName;
                                userInfor.FirstName = model.FirstName;
                                userInfor.Birthday = model.BirthDay;
                                userInfor.Gender = model.Gender;
                                await _userManager.UpdateAsync(user);
                                _userInforService.UpdateUserInfor(userInfor);
                                Alert("Thay đổi thông tin tài khoản thành công", NotificationType.success);
                                return View(model);
                            }
                            else
                            {
                                Alert("Không tìm thấy thông tin tài khoản", NotificationType.error);
                                return View(model);
                            }
                        }
                        else
                        {
                            Alert("Không tìm thấy thông tin tài khoản", NotificationType.error);
                            return View(model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Email hoặc số điện thoại không đúng định dạng");
                        return View(model);
                    }
                }
            }
            return View(model);
        }
        /// <summary>
        /// Màn hình thay đổi mật khẩu
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        /// Created by: NTQuyen 06/05/2019
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> UpdatePassword(string returnUrl)
        {
            return View();
        }
        /// <summary>
        /// Xủ lý thay đổi mật khẩu
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        /// Created by: NTQuyen 06/05/2019
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
        /// <summary>
        /// Màn hình sổ địa chỉ
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        /// Created by: NTQuyen 06/05/2019
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ManageAddress(string returnUrl = null)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                try
                {
                    var userAddress = _userAddressService.FindUserAddressByUserId(user.Id);
                    if (userAddress.Count == 0)
                    {
                        Alert("Không có thông tin sổ địa chỉ", NotificationType.warning);
                        return View();
                    }
                    else
                    {
                        var destinations = Mapper.Map<List<UserAddress>, List<UserAddressViewModel>>(userAddress);
                        return View(destinations);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Lỗi lấy thông tin sổ địa chỉ: " + ex);
                    Alert("Không có thông tin sổ địa chỉ", NotificationType.error);
                    return View();
                }
            }
            else
            {
                Alert("Không tìm thấy thông tin tài khoản", NotificationType.warning);
                return View();
            }
        }
        /// <summary>
        /// Màn hình cập nhật địa chỉ giao hàng
        /// </summary>
        /// <param name="id"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        /// Created by: NTQuyen 06/05/2019
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UpdateAddress(string id, string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var userAddress = await _userAddressService.GetFirstOrDefault(id);
                if (userAddress != null)
                {
                    var destinations = Mapper.Map<UserAddress, UserAddressViewModel>(userAddress);
                    return View(destinations);
                }
                else
                {
                    Alert("Không tìm thấy thông tin địa chỉ", NotificationType.error);
                    return RedirectToAction(nameof(ManageAddress), new { returnUrl = returnUrl });
                }
            }
            else
            {
                Alert("Không tìm thấy thông tin địa chỉ", NotificationType.error);
                return RedirectToAction(nameof(ManageAddress), new { returnUrl = returnUrl });
            }
        }
        /// <summary>
        /// Xử lý cập nhật địa chỉ giao hàng
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        /// Created by: NTQuyen 06/05/2019
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateAddress(UserAddressViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                if (user != null)
                {
                    var destinations = Mapper.Map<UserAddressViewModel, UserAddress>(model);
                    destinations.IdentityUserId = user.Id;
                    try
                    {
                        _userAddressService.UpdateUserAddress(destinations);
                        Alert("Cập nhật địa chỉ thành công", NotificationType.success);
                        return RedirectToAction(nameof(ManageAddress), new { returnUrl = returnUrl });
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("Lỗi cập nhật địa chỉ: " + ex);
                        Alert("Lỗi cập nhật địa chỉ", NotificationType.error);
                        return View();
                    }
                }
                else
                {
                    Alert("Không tìm thấy thông tin cá nhân", NotificationType.error);
                    return View();
                }
            }
            return View(model);
        }
        /// <summary>
        /// Xử lý Xóa địa chỉ giao hàng
        /// </summary>
        /// <param name="user"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        /// Created by: NTQuyen 06/05/2019
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteAddress(UserAddressId user, string returnUrl = null)
        {
            string id = user.Id;
            if (!string.IsNullOrEmpty(id))
            {
                var userAddress = await _userAddressService.GetFirstOrDefault(id);
                if (userAddress != null)
                {
                    _userAddressService.DeleteUserAddress(userAddress);
                    Alert("Xóa địa chỉ thành công", NotificationType.success);
                    return RedirectToAction(nameof(ManageAddress), new { returnUrl = returnUrl });
                }
                else
                {
                    Alert("Không tìm thấy thông tin địa chỉ", NotificationType.error);
                    return RedirectToAction(nameof(ManageAddress), new { returnUrl = returnUrl });
                }
            }
            else
            {
                Alert("Không tìm thấy thông tin địa chỉ", NotificationType.error);
                return RedirectToAction(nameof(ManageAddress), new { returnUrl = returnUrl });
            };
        }
        /// <summary>
        /// Màn hình thêm địa chỉ giao hàng
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        /// Created by: NTQuyen 06/05/2019
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddAddress(string returnUrl = null)
        {

            return View();
        }
        /// <summary>
        /// Xử lý thêm địa chỉ giao hàng
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        /// Created by: NTQuyen 06/05/2019
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddAddress(UserAddressViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                if (user != null)
                {
                    Regex regexPhone = new Regex(RegexConstants.RegexPhoneNumber);
                    Match matchPhone = regexPhone.Match(model.PhoneNumber);
                    if (matchPhone.Success)
                    {
                        try
                        {
                            if (model.IsDefault == true)
                            {
                                _userAddressService.UpdateNotDefaultAddress(false, user.Id);
                            }
                            var userAddress = new UserAddress();
                            userAddress = new UserAddress
                            {
                                FullName = model.FullName,
                                District = model.District,
                                Company = model.Company,
                                IsDefault = model.IsDefault,
                                PhoneNumber = model.PhoneNumber,
                                ProvinceCity = model.ProvinceCity,
                                Address = model.Address,
                                AddressType = model.AddressType,
                                Ward = model.Ward,
                                IdentityUserId = user.Id
                            };
                            _userAddressService.AddUserAddress(userAddress);
                            return RedirectToAction(nameof(ManageAddress), new { returnUrl = returnUrl });
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError("Lỗi update sổ địa chỉ: " + ex);
                            Alert("Thêm sổ địa chỉ thất bại", NotificationType.error);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("PhoneNumber", "Số điện thoại không đúng định dạng");

                    }
                }
                else
                {
                    Alert("Lỗi không tìm thấy thông tin tài khoản", NotificationType.error);
                    return View(model);
                }
            }
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