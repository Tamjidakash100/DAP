#region Assembly Refference
using DocumentFormat.OpenXml.EMMA;
using GTERP.BLL;
using GTERP.Helpers;
using GTERP.Models;
using GTERP.Models.Common;
using GTERP.Models.DTOs;
using GTERP.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Company = GTERP.Models.Company;
//using FreeGeoIPCore.AppCode;
#endregion

namespace GTERP.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {

        #region Feilds and constructor
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly GTRDBContext db;
        private readonly IConfiguration _configuration;

        public LoginModel(SignInManager<IdentityUser> signInManager,
            ILogger<LoginModel> logger,
            UserManager<IdentityUser> userManager,
            GTRDBContext context, TransactionLogRepository logRepository, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            db = context;
            LogRepository = logRepository;
            _configuration = configuration;

        }
        #endregion

        #region Property

        [BindProperty]
        public InputModel Input { get; set; }
        [BindProperty]
        public RegisterModel RegisterMod { get; set; }


        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }
        public bool ShowResend { get; set; }
        public string UserId { get; set; }


        [TempData]
        public string ErrorMessage { get; set; }
        public TransactionLogRepository LogRepository { get; }
        public IConfiguration Config { get; }
        public IConfiguration Configuration { get; }
        public AuthorizationFilterContext Accessor { get; }
        #endregion

        //To Do : Input model should be extend to capture request property

        #region InputModel
        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            public Guid AppKey { get; set; } = Guid.Parse("00696C16-1B7D-91B9-783A-B789C9D15B2C");


        }


        #endregion

        public class RegisterModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            [Required]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }
            public Guid AppKey { get; set; } = Guid.Parse("00696C16-1B7D-91B9-783A-B789C9D15B2C");
        }


        #region OnGetAsync
        public async Task OnGetAsync(string returnUrl = null)
        {



            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        #endregion


        #region OnPostLogin

        public async Task<IActionResult> OnPostLogin(string returnUrl = null)
        {

            returnUrl = returnUrl ?? Url.Content("~/");

            var inactiveuser = db.UserPermission?.Where(a => a.UserName == Input.Email).Select(a => a.IsInActive).FirstOrDefault();
            if (inactiveuser == null || inactiveuser == true)
            {
                ModelState.AddModelError("", "You are not an active user");
                return Page();
            }

            string url = _configuration.GetValue<string>("API:Login");

            var res = await APIHelper.PostRequest<InputModel, LoginResponse>(url, Input, false);

            #region Do further processing with response
            if (res.Success)
            {
                AppData.AppData.dbdaperpconstring = _configuration.GetConnectionString("DefaultConnection");

                inactiveuser = db.UserPermission?.FirstOrDefault(x => x.UserName == Input.Email)?.IsInActive;
                if (inactiveuser == null || inactiveuser == true)
                {
                    ModelState.AddModelError("", "You are not an active user");
                    return Page();
                }

                Token.JWToken = res.JWToken;
                HttpContext.Session.SetString("userid", res.UserId);
                HttpContext.Session.SetString("username", res.UserName);
                HttpContext.Session.SetString("appkey", Input.AppKey.ToString());

                if (res.Companies != null)
                {
                    var companies = new List<CompanyUser>();
                    foreach (var item in res.Companies)
                    {
                        var company = new CompanyUser();
                        company.ComId = item.ComId;
                        company.CompanyName = item.CompanyName;
                        companies.Add(company);
                    }

                    if (companies != null)
                    {

                        if (companies.Count > 0)
                        {
                            HttpContext.Session.SetObject("UserCompanys", companies);

                        }

                        var comId = companies.FirstOrDefault().ComId.ToString();
                        HttpContext.Session.SetString("comid", comId.ToString());


                        var userId = res.UserId;
                        SqlParameter[] sqlParameter = new SqlParameter[2];
                        sqlParameter[0] = new SqlParameter("@comid", comId);
                        sqlParameter[1] = new SqlParameter("@userid", userId);
                        List<UserMenuPermission> userMenus = Helper.ExecProcMapTList<UserMenuPermission>("prcgetMenuPermission", sqlParameter);


                        // set session Usermenu

                        if (userMenus?.Count > 0)
                        {
                            HttpContext.Session.SetObject("UserMenu", userMenus.OrderBy(a => a.SLNo));

                            var moduleses = userMenus.Select(a => a.ModuleId).Distinct();
                            var ModuleMenuCaption = userMenus.Where(x => x.Visible == true).Distinct().Select(x => x.ModuleMenuCaption).FirstOrDefault();
                            var activemoduleid = userMenus.Where(x => x.Visible == true).Distinct().Select(x => x.ModuleMenuCaption).FirstOrDefault();



                            HttpContext.Session.SetObject("activemodulename", ModuleMenuCaption);
                            HttpContext.Session.SetObject("activemoduleid", activemoduleid);
                            HttpContext.Session.SetObject("Modules", db.Modules.Where(a => moduleses.Contains(a.ModuleId)).ToList());
                        }

                        var userPermission = db.UserPermission.Where(u => u.AppUserId == res.UserId).FirstOrDefault();

                        if (userPermission != null)
                            HttpContext.Session.SetObject("userpermission", userPermission);
                        else
                            HttpContext.Session.SetObject("userpermission", new UserPermission());


                        MenuPermission_Master master = db.MenuPermissionMasters.Where(m => m.useridPermission == userId).FirstOrDefault();

                        if (master == null)
                        {
                            return LocalRedirect(returnUrl);
                        }
                        var userMenuPermission = db.MenuPermissionDetails.Where(m => m.MenuPermissionId == master.MenuPermissionId)
                            .Select(m => new
                            {
                                MenuPermissionDetailsId = m.MenuPermissionDetailsId,
                                ModuleMenuName = m.ModuleMenus.ModuleMenuName,
                                ModuleMenuCaption = m.ModuleMenus.ModuleMenuCaption,
                                ModuleMenuLink = m.ModuleMenus.ModuleMenuLink,
                                IsCreate = m.IsCreate,
                                IsView = m.IsView,
                                IsEdit = m.IsEdit,
                                IsDelete = m.IsDelete,
                                IsReport = m.IsReport,
                                SLNo = m.SLNo

                            }).OrderBy(x => x.SLNo).ToList();
                        var menus = db.ModuleMenus.Select(m => new
                        {
                            ModuleMenuId = m.ModuleMenuId,
                            ModuleMenuName = m.ModuleMenuName,
                            ModuleMenuCaption = m.ModuleMenuCaption,
                            ModuleMenuLink = m.ModuleMenuLink,
                            isInactive = m.isInactive,
                            isParent = m.isParent,
                            Active = m.Active,
                            ParentId = m.ParentId,
                            SLNo = m.SLNo
                        }).OrderBy(x => x.SLNo).ToList();

                        if (userMenuPermission.Count > 0)
                        {
                            HttpContext.Session.SetObject("menupermission", userMenuPermission);
                            HttpContext.Session.SetObject("modules", db.Modules.ToList());
                            HttpContext.Session.SetObject("menu", menus);


                            HttpContext.Session.SetInt32("activemenuid", 1);
                        }


                        _logger.LogInformation("User logged in.");

                        Company abcd = db.Companys.Include(x => x.vCountryCompany).Where(x => x.AppKey == Input.AppKey.ToString()).FirstOrDefault();

                        HttpContext.Session.SetString("isMultiDebitCredit", abcd.isMultiDebitCredit.ToString());
                        HttpContext.Session.SetString("isMultiCurrency", abcd.isMultiCurrency.ToString());
                        HttpContext.Session.SetString("isVoucherDistributionEntry", abcd.isVoucherDistributionEntry.ToString());
                        HttpContext.Session.SetString("isChequeDetails", abcd.isChequeDetails.ToString());

                        HttpContext.Session.SetInt32("defaultcurrencyid", abcd.CountryId);
                        HttpContext.Session.SetString("defaultcurrencyname", abcd.vCountryCompany.CurrencyShortName.ToString());


                        LogRepository.SuccessLogin(HttpContext.Session.GetString("Latitude"), HttpContext.Session.GetString("Longitude"), "Success");


                        List<SalesSub> addtocart = new List<SalesSub>();

                        HttpContext.Session.SetObject("cartlist", addtocart);
                    }
                }

                var gotoUrl = HttpContext.Session.GetString("gotourl");
                {
                    return LocalRedirect(returnUrl);
                }
            }

            else
            {
                HttpContext.Session.SetString("userid", Input.Email + " " + Input.Password);
                LogRepository.SuccessLogin(HttpContext.Session.GetString("Latitude"), HttpContext.Session.GetString("Longitude"), "Failure");

                if (res.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (res.IsLockedOut)
                {

                    ModelState.AddModelError("", "The account is locked out");
                    return RedirectToPage("./Lockout");
                }
                if (res.IsNotAllowed)
                {
                    ModelState.Remove("Input.ConfirmPassword");
                    _logger.LogWarning("User email is not confirmed.");
                    ModelState.AddModelError("", "Email is not confirmed.");


                    // var user = await _userManager.FindByEmailAsync(Input.Email);
                    UserId = res.UserId;
                    ShowResend = true;
                    return Page();
                }
                else
                {
                    ModelState.Remove("Input.ConfirmPassword");
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    ModelState.AddModelError(string.Empty, "User Not Register or Email Not Confirmed");

                    return Page();
                }



            }
            #endregion
        }
        #endregion

        #region OnPostRegister
        public async Task<IActionResult> OnPostRegisterAsync(string returnUrl = null)
        {
            try
            {
                returnUrl = returnUrl ?? Url.Content("~/");

                if (RegisterMod.Password == RegisterMod.ConfirmPassword && RegisterMod.PhoneNumber is not null)
                {
                    string url = _configuration.GetValue<string>("API:Register");
                    var res = await APIHelper.PostRequest<RegisterModel, RegResponse>(url, RegisterMod, false);

                    if (res.Succeeded)
                    {
                        return RedirectToPage("./CheckEmail", new { email = RegisterMod.Email });
                    }
                    else
                    {
                        return LocalRedirect(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "The password and confirmation password do not match.");

                    ViewData["Type"] = "Register";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }


        }
        #endregion

        public IActionResult OnGetForgotPassword()
        {
            //chittra panel 
            // return Redirect("https://localhost:44396/Identity/Account/ForgotPassword2");
            //return Redirect("https://pqstec.com:91/Identity/Account/ForgotPassword2");
            //api
            // return Redirect("https://localhost:5000/Identity/Account/ForgotPassword");
            //return Redirect("https://gtrbd.net/chitrapanelTest/Identity/Account/ForgotPassword2");
            //return Redirect("https://gtrbd.net/chitrapanelTest/Identity/Account/ForgotPassword");

            return RedirectToPage("./ForgotPassword");


        }
    }
}
