using GTERP.Helpers;
using GTERP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DAP.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public ForgotPasswordModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public void OnGetAsync()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                string url = _configuration.GetValue<string>("API:ResendOTP");
                var response = await APIHelper.GetRequest<bool>(url + $"/{Input.Email}", false);
                if (response)
                {
                    return RedirectToPage("./ConfirmPasswordChange", new { email = Input.Email, resendOTP = true });
                }
            }

            return Page();
        }
    }
}
