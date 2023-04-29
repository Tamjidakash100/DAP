using GTERP.Helpers;
using GTERP.Models.DTOs;
using GTERP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace GTRChitra.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ConfirmPasswordChangeModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public ConfirmPasswordChangeModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty]
        public OTPModel OtpModel { get; set; }

        public class OTPModel
        {
            public string OTPToken { get; set; }
            public string Email { get; set; }
        }

        public async Task OnGetAsync(string email, bool resendOTP)
        {
            ViewData["Email"] = email;
            if (resendOTP)
            {
                string url = _configuration.GetValue<string>("API:ResendOTP");
                var response = await APIHelper.GetRequest<bool>(url + $"/{email}", false);
            }
        }

        public async Task<IActionResult> OnPostCheckOTPAsync()
        {
            if (OtpModel.Email is not null && OtpModel.OTPToken is not null)
            {
                string url = _configuration.GetValue<string>("API:VerifyOTP");
                var response = await APIHelper.PostRequest<OTPModel, bool>(url, OtpModel, false);
                if (response)
                {
                    return RedirectToPage("./SetPassword", new { email = OtpModel.Email });
                }
                else
                {
                    ModelState.AddModelError("Error", "OTP Does'nt Match");
                }
            }
            return RedirectToPage("./ConfirmPasswordChange", new { email = OtpModel.Email, resendOTP = false });
        }
    }
}
