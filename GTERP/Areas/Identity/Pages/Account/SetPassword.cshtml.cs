using GTERP.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DAP.Areas.Identity.Pages.Account
{
    public class SetPasswordModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public SetPasswordModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            public string Email { get; set; }   
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "New password")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm new password")]
            [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGetAsync(string email)
        {
            ViewData["Email"] = email;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                string url = _configuration.GetValue<string>("API:ResetPassword");
                var response = await APIHelper.PostRequest<InputModel, bool>(url, Input, false);
                if (response)
                {
                    return RedirectToPage("./PasswordChanged");
                }
            }

            return RedirectToPage();
        }
    }
}
