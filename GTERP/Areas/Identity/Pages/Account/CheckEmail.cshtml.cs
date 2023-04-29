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
    public class CheckEmailModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public CheckEmailModel(IConfiguration configuration)
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
                    return RedirectToPage("./Confirmed");
                }
                else
                {
                    ModelState.AddModelError("Error", "OTP Verification Failed");
                }
            }
            return RedirectToPage("./CheckEmail", new { email = OtpModel.Email, resendOTP = false });
        }
    }
}
