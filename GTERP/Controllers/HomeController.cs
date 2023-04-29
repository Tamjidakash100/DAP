using GTERP.Models;
using GTERP.Models.Common;
using GTERP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GTERP.Controllers
{

    public class HomeController : Controller

    {
        private GTRDBContext db;

        public IHttpContextAccessor Accessor { get; }

        public HomeController(GTRDBContext context, IHttpContextAccessor accessor)
        {
            db = context;
            Accessor = accessor;
        }


        [HttpGet]
        public ActionResult AccessDenied()
        {
            ViewBag.Message = "Access Denied";

            return View();
        }


        [HttpGet]
        public ActionResult Profile()
        {
            string userId = HttpContext.Session.GetString("userid");

            var user = db.UserPermission.Include(a => a.HR_Emp_Info).Where(a => a.AppUserId == userId).FirstOrDefault();

            return View(user);
        }

        public class InputModel
        {

            public string Email { get; set; }

            public Guid AppKey { get; set; } = Guid.Parse("00696C16-1B7D-91B9-783A-B789C9D15B2C");


        }

        [HttpGet]

        public ActionResult ResetPassword()
        {

            string username = HttpContext.Session.GetString("username");
            InputModel abc = new InputModel();
            abc.Email = username;

            WebHelper webHelper = new WebHelper();

            string request = JsonConvert.SerializeObject(abc);

            //Login
            //Uri url = new Uri(string.Format("https://localhost:5001/api/User/PasswordReset"));
            //Uri url = new Uri(string.Format("http://101.2.165.187:82/api/User/Register")); ///now disabled
            //Uri url = new Uri(string.Format("https://pqstec.com:92/api/User/Register")); ///enable ssl certificate for secure connection
            Uri url = new Uri(string.Format("https://gtrbd.net/ChitraAPITest/api/User/PasswordReset"));
            //Uri url = new Uri(string.Format("http://gtrbd.net:93/api/User/Register"));


            string response = webHelper.Post(url, request);


            //RegResponse res = new RegResponse(response);
            if (response == "true")
            {
                //Handle your reponse here
                //return LocalRedirect("./CheckEmail");
                //return RedirectToPage("../identity/account/CheckEmail");
                //return View("Identity", null);
                return RedirectToPage("/Account/CheckEmailReset", new { area = "Identity" });
            }


            return View();
        }




        [HttpGet]
        public IActionResult LoginPage()
        {
            return RedirectToPage("/Account/Login1", new { area = "Identity" });
        }

        [HttpGet]
        public ActionResult Index_Ecommerce()
        {
            //homeSlider
            List<HomeSlider> mainSlider = db.HomeSlider.ToList();
            ViewBag.homeSliders = mainSlider;

            //category
            var category = db.Categories.Where(c => c.CategoryId > 0).ToList();
            ViewBag.Category = category;

            //subcat
            var subcategory = db.SubCategory.Where(c => c.SubCategoryId > 0).ToList();
            ViewBag.SubCategories = subcategory;
            //product
            //var products = db.Products.Include(p => p.SubCategory); ///sahinur work
            //var products = db.Products.Include(p => p.CategoryId);
            return View(db.Products.Where(c => c.ProductId > 1).ToList());
            //return View();
        }


        public IActionResult ForgotPassOnClick()
        {


            ////chittra panel
            ////return Redirect("https://localhost:44396/Identity/Account/ForgotPassword2");
            ////return Redirect("https://pqstec.com:91/Identity/Account/ForgotPassword2");
            ////api
            //// return Redirect("https://localhost:44336/Identity/Account/ForgotPassword");
            //return Redirect("https://gtrbd.net/ChitraAPITest/Identity/Account/ForgotPassword");
            ////return Redirect("https://gtrbd.net:93/Identity/Account/ForgotPassword");




            string username = HttpContext.Session.GetString("username");
            InputModel abc = new InputModel();
            abc.Email = username;

            WebHelper webHelper = new WebHelper();

            string request = JsonConvert.SerializeObject(abc);

            //Login
            //Uri url = new Uri(string.Format("https://localhost:5001/api/User/PasswordReset"));
            //Uri url = new Uri(string.Format("http://101.2.165.187:82/api/User/Register")); ///now disabled
            //Uri url = new Uri(string.Format("https://pqstec.com:92/api/User/Register")); ///enable ssl certificate for secure connection
            Uri url = new Uri(string.Format("https://gtrbd.net/ChitraAPITest/api/User/PasswordReset"));
            //Uri url = new Uri(string.Format("http://gtrbd.net:93/api/User/Register"));


            string response = webHelper.Post(url, request);


            //RegResponse res = new RegResponse(response);
            if (response == "true")
            {
                //Handle your reponse here
                //return LocalRedirect("./CheckEmail");
                //return RedirectToPage("../identity/account/CheckEmail");
                //return View("Identity", null);
                return RedirectToPage("/Account/CheckEmailReset", new { area = "Identity" });
            }


            return View();







        }

        [HttpGet]

        public ActionResult Index()
        {
            HttpContext.Session.SetInt32("ActiveModuleMenuId", 0);
            HttpContext.Session.SetString("activemodulename", "Software");
            ViewBag.error = HttpContext.Session.GetString("error");
            HttpContext.Session.SetString("error", "");
            return View();
            //return View();
        }

        [HttpGet]
        public ActionResult UserSessionCheck() => Json(HttpContext.Session.GetString("userid"));


        public ActionResult CheckSession()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("AppKey")))
            {
                return RedirectToPage("./Login1");
            }
            return null;
        }

        [OverridableAuthorize]

        public ActionResult ModuleDefault()
        {
            return View();
            //return View();
        }

        [HttpPost, ActionName("SetSessionHideMenu")]
        //[ValidateAntiForgeryToken]
        public JsonResult SetSessionHideMenu(string isHide)
        {
            try
            {
                //var JObject = new JObject();
                //var d = JObject.Parse(isHide);
                //string objct = d["data"].ToString();

                //if (objct != null)
                //{


                var a = Convert.ToInt32(isHide);
                HttpContext.Session.SetInt32("ishidemenu", a);
                return Json(new { Success = 1 });
                //}



            }

            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
            return Json(new { Success = 0, ex = new Exception("Unable to Set").Message.ToString() });
        }


        [HttpPost, ActionName("SetSessionActiveModule")]
        //[ValidateAntiForgeryToken]
        public JsonResult SetSessionActiveModule(int isActive)
        {
            try
            {


                HttpContext.Session.SetInt32("isactivemodule", isActive);
                var abc = db.Modules.Where(x => x.ModuleId == isActive).Select(x => x.ModuleName).FirstOrDefault().ToString();
                HttpContext.Session.SetInt32("activemenuid", isActive);
                HttpContext.Session.SetString("activemodulename", abc);

                var AllMenus = HttpContext.Session.GetObject<List<UserMenuPermission>>("UserMenu");
                if (AllMenus != null)
                {
                    var defaultMenu = AllMenus.Where(m => m.ModuleId == isActive && m.isInactive == 0 && m.isParent == 0 && m.ParentId != 0).OrderByDescending(x => x.IsDefault).OrderBy(m => m.SLNo).FirstOrDefault();

                    return Json(new { Success = 1, Menu = defaultMenu });
                }
                else
                {
                    return Json(new { Success = 1, Menu = "" });
                }


            }

            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }

        }

        public void SaveUserState(string url)
        {
            var comid = Accessor.HttpContext.Session.GetString("comid");
            var userid = Accessor.HttpContext.Session.GetString("userid");
            var recentVisit = url;
            if (userid == null && comid == null)
            {
                return;
            }
            var user = db.UserStates.Where(x => x.UserId == userid).FirstOrDefault();
            if (user != null)
            {
                user.LastVisited = recentVisit;
                db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                var newuserstate = new UserState() { UserId = userid, LastVisited = recentVisit, ComId = comid };
                db.Add(newuserstate);
                db.SaveChanges();
            }
        }


        //[HttpPost, ActionName("SetSessionLocation")]
        ////[ValidateAntiForgeryToken]
        //public JsonResult SetSessionLocation(string Latitude , string Longitude)
        //{
        //    try
        //    {

        //        HttpContext.Session.SetString("Latitude", Latitude);
        //        HttpContext.Session.SetString("Longitude", Longitude);


        //        return Json(new { Success = 1 });

        //    }

        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }

        //}

        [HttpPost, ActionName("SetSessionLocation")]
        //public JsonResult DeleteConfirmed(int id)
        public IActionResult SetSessionActiveModule(string Latitude, string Longitude)
        {
            try
            {
                if (Latitude == null)
                {
                    Latitude = "";
                    Longitude = "";

                }
                //Acc_VoucherSub Acc_VoucherSub = db.Acc_VoucherSubs.Find(id);
                //db.Acc_VoucherSubs.Remove(Acc_VoucherSub);

                HttpContext.Session.SetString("Latitude", Latitude);
                HttpContext.Session.SetString("Longitude", Longitude);

                return Json(new { Success = 1, VoucherID = 0, ex = "" });

            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.Message.ToString() });
            }


            // return RedirectToAction("Index");
        }

        [HttpPost, ActionName("SetSessionModuleMenuId")]
        //public JsonResult DeleteConfirmed(int id)
        public IActionResult SetSessionModuleMenuId(int ModuleMenuId)
        {
            try
            {
                if (ModuleMenuId != null)
                {
                    HttpContext.Session.SetInt32("ActiveModuleMenuId", ModuleMenuId);
                }


                return Json(new { Success = 1, ModuleMenuId = ModuleMenuId, ex = "" });

            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.Message.ToString() });
            }


            // return RedirectToAction("Index");
        }

          [HttpPost, ActionName("SetSessionModuleTabId")]
        public IActionResult SetSessionModuleTabId(int ModuleTabId)
        {
            try
            {
                if (ModuleTabId > 0)
                {
                    HttpContext.Session.SetInt32("ActiveModuleTabId", ModuleTabId);
                }


                return Json(new { Success = 1, ModuleMenuId = ModuleTabId, ex = "" });

            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.Message.ToString() });
            }


            // return RedirectToAction("Index");
        }

        public IActionResult GenerateReport()
        {
            // return Redirect("https://localhost:44383/Home/About");

            var ReportPath = "";
            var SqlCmd = "Exec GTERP.dbo.[rptMasterLCSalesContact] '" + 1 + "','" + 4 + "'";
            var DbName = "GTERP";
            var ReportType = "PDF";
            return Redirect("https://localhost:44375/ReportViewer/GenerateReport?ReportPath=" + ReportPath + "&SqlCmd=" + SqlCmd + "&DbName=" + DbName + "&ReportType=" + ReportType);
        }

        //public ActionResult ECommerce()
        //{

        //}


        [HttpGet]
        //[Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult UnderConstruction()
        {
            ViewBag.Message = "Under Construction.";

            return View();
        }

        //[HttpGet]
        //public ActionResult AccessDenied()
        //{
        //    ViewBag.Message = "Access Denied";

        //    return View();
        //}

        public ActionResult ChangeSelectedCompany(string comid)
        {
            var com = db.Companys.Where(x => x.CompanyCode == comid).FirstOrDefault();
            if (com != null)
            {
                HttpContext.Session.SetString("comid", "");
                HttpContext.Session.SetString("comid", com.CompanyCode);
                HttpContext.Session.SetString("appkey", "");
                HttpContext.Session.SetString("appkey", com.AppKey);
                HttpContext.Session.SetObject("UserMenu", null);
                HttpContext.Session.SetObject("activemodulename", null);
                HttpContext.Session.SetObject("activemoduleid", null);
                HttpContext.Session.SetObject("Modules", null);
                HttpContext.Session.SetObject("menupermission", null);
                HttpContext.Session.SetObject("menu", null);
                HttpContext.Session.SetInt32("activemenuid", 0);
                var uid = HttpContext.Session.GetString("userid");


                SqlParameter[] sqlParameter = new SqlParameter[2];
                sqlParameter[0] = new SqlParameter("@comid", com.CompanyCode);
                sqlParameter[1] = new SqlParameter("@userid", uid);
                List<UserMenuPermission> userMenus = Helper.ExecProcMapTList<UserMenuPermission>("prcgetMenuPermission", sqlParameter);


                // set session Usermenu

                if (userMenus.Count > 0)
                {
                    HttpContext.Session.SetObject("UserMenu", userMenus);

                    var ModuleMenuCaption = userMenus.Where(x => x.Visible == true).Distinct().Select(x => x.ModuleMenuCaption).FirstOrDefault();
                    var activemoduleid = userMenus.Where(x => x.Visible == true).Distinct().Select(x => x.ModuleMenuCaption).FirstOrDefault();

                    HttpContext.Session.SetObject("activemodulename", ModuleMenuCaption);
                    HttpContext.Session.SetObject("activemoduleid", activemoduleid);
                    HttpContext.Session.SetObject("Modules", db.Modules.ToList());

                }




                MenuPermission_Master master = db.MenuPermissionMasters.Where(m => m.useridPermission == uid).FirstOrDefault();

                if (master != null)
                {

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
                            IsReport = m.IsReport

                        }).ToList();
                    var menus = db.ModuleMenus.Select(m => new
                    {
                        ModuleMenuId = m.ModuleMenuId,
                        ModuleMenuName = m.ModuleMenuName,
                        ModuleMenuCaption = m.ModuleMenuCaption,
                        ModuleMenuLink = m.ModuleMenuLink,
                        isInactive = m.isInactive,
                        isParent = m.isParent,
                        Active = m.Active,
                        ParentId = m.ParentId
                    }).ToList();

                    if (userMenuPermission.Count > 0)
                    {
                        HttpContext.Session.SetObject("menupermission", userMenuPermission);
                        HttpContext.Session.SetObject("menu", menus);
                        HttpContext.Session.SetInt32("activemenuid", 1);
                    }
                }

                return Json(new { success = 1 });
                //return View("Index");
            }


            return Json(new { error = 0 });
        }


    }
    public class ChangeComModel
    {
        public string ComId { get; set; }
    }
}
