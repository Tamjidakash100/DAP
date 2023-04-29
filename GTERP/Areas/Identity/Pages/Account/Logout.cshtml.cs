using GTERP.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DAP.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");

            HttpContext.Session.SetObject("UserMenu", null);
            HttpContext.Session.SetObject("Companys", null);

            HttpContext.Session.SetString("userid", string.Empty);
            HttpContext.Session.SetString("username", string.Empty);
            HttpContext.Session.SetString("comid", string.Empty);
            HttpContext.Session.SetObject("UserCompanys", null);



            //Session["Menus"] = null;
            //Session["Companys"] = null;
            //System.Web.HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);


            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
