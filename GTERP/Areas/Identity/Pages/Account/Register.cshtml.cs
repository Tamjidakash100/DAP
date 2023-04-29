#region Assembly Refference
using GTERP.Helpers;
using GTERP.Models;
using GTERP.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace DAP.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        #region Feilds and Constructor
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;
        GTRDBContext db;
        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            GTRDBContext _db, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _configuration = configuration;
            db = _db;
        }
        #endregion

        #region Properties
        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        #endregion

        #region Input Model
        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]

            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            [Required]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }
            public Guid AppKey { get; set; } = Guid.Parse("00696C16-1B7D-91B9-783A-B789C9D15B2C");
        }
        #endregion

        #region OnGetAsync
        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }
        #endregion

        #region OnPostAsyncRegister
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            //string url = _configuration.GetValue<string>("API:Register");
            //var res = await APIHelper.PostRequest<RegisterModel, RegResponse>(url, RegisterMod, false);
            //if (res.Succeeded == true)
            //{
            //    //Handle your reponse here
            //    //return LocalRedirect("./CheckEmail");
            //    return RedirectToPage("./CheckEmail");
            //}
            //else
            //{
            //    if (res.Errors != null)
            //    {
            //        foreach (var item in res.Errors)
            //        {
            //            if (!string.IsNullOrEmpty(item.Key) && !string.IsNullOrEmpty(item.Error))
            //            {
            //                HttpContext.Session.SetString("error", $"{item.Error}");
            //            }
            //        }

            //        ViewData["error"] = res.Errors;

            //    }

            return RedirectToPage("Register");

            //    //No Response from the server

            //}


        }
        #endregion
    }
}
