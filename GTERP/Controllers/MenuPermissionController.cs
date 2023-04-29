using GTERP.Models;
using GTERP.Models.Common;
using GTERP.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using static GTERP.Controllers.CompanyPermissionsController;
using AspnetUserList = GTERP.Controllers.CompanyPermissionsController.AspnetUserList;

namespace GTERP.Controllers
{
    [OverridableAuthorize]
    public class MenuPermissionController : Controller
    {
        private GTRDBContext db;

        public MenuPermissionController(GTRDBContext context)
        {
            db = context;
        }
        // GET: MenuPermission
        public ActionResult Index()
        {
            //if (!UserAccess(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString()))
            //{
            //    return NotFound();
            //}

            var appKey = HttpContext.Session.GetString("appkey");
            var model = new GetUserModel();
            model.AppKey = Guid.Parse(appKey);
            WebHelper webHelper = new WebHelper();

            string req = JsonConvert.SerializeObject(model);

            //Login
            //Uri url = new Uri(string.Format("https://localhost:44336/api/User/GetUsersCompanies"));
            //Uri url = new Uri(string.Format("http://101.2.165.187:82/api/user/GetUsersCompanies"));
            //Uri url = new Uri(string.Format("https://pqstec.com:92/api/User/GetUsersCompanies")); ///enable ssl certificate for secure connection
            Uri url = new Uri(string.Format("https://www.gtrbd.net/Support/api/AccountAPI/GetUsersCompanies"));



            string response = webHelper.GetUserCompany(url, req);

            GetResponse res = new GetResponse(response);


            if (res.MyUsers != null || res.Companies != null)
            {
                SqlParameter[] sqlParameter1 = new SqlParameter[1];
                sqlParameter1[0] = new SqlParameter("@Criteria", "MenuPermission");

                List<MenuPermission> menuPermission = Helper.ExecProcMapTList<MenuPermission>("prcgetAspnetUserList", sqlParameter1).ToList();

                var resultUsers = new List<MenuPermission>();
                for (int i = 0; i < res.MyUsers.Count; i++)
                {
                    var seqUserId = res.MyUsers.ElementAt(i).UserID;
                    var UserName = res.MyUsers.ElementAt(i).UserName;
                    // var seqUserId = res.MyUsers.ElementAt(i).UserID;
                    var hs = menuPermission.Where(x => x.useridPermission == seqUserId).ToList();


                    foreach (var menu in hs)
                    {
                        //var menu = menuPermission.Where(x => x.useridPermission == d.useridPermission).FirstOrDefault();
                        var resultUser = new MenuPermission();

                        resultUser.UserId = menu.UserId;
                        resultUser.useridPermission = menu.useridPermission;
                        resultUser.UserName = UserName;
                        resultUser.CompanyName = menu.CompanyName;
                        resultUser.comid = menu.comid;
                        resultUser.Email = UserName;
                        resultUser.MenuPermissionId = menu.MenuPermissionId;
                        resultUsers.Add(resultUser);
                    }
                }


                ViewBag.MenuPermission = resultUsers;

            }


            return View();
        }

        public class MenuPermission
        {
            public int MenuPermissionId { get; set; }
            public string UserId { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string comid { get; set; }
            public string CompanyName { get; set; }
            public string useridPermission { get; set; }

        }

        public ActionResult UserTransfer(string menuPermissionId, string userIdPermission, string comId)
        {
            var appKey = HttpContext.Session.GetString("appkey");
            var model = new GetUserModel();
            model.AppKey = Guid.Parse(appKey);
            WebHelper webHelper = new WebHelper();

            string req = JsonConvert.SerializeObject(model);

            //Login
            //Uri url = new Uri(string.Format("https://localhost:44336/api/User/GetUsersCompanies"));
            // Uri url = new Uri(string.Format("http://101.2.165.187:82/api/user/GetUsersCompanies"));
            //Uri url = new Uri(string.Format("https://pqstec.com:92/api/User/GetUsersCompanies")); ///enable ssl certificate for secure connection
            Uri url = new Uri(string.Format("https://www.gtrbd.net/Support/api/AccountAPI/GetUsersCompanies"));

            string response = webHelper.GetUserCompany(url, req);

            GetResponse res = new GetResponse(response);




            String userid = HttpContext.Session.GetString("userid");


            SqlParameter[] sqlParameter = new SqlParameter[4];
            sqlParameter[0] = new SqlParameter("@menuPermissionId", menuPermissionId);
            sqlParameter[1] = new SqlParameter("@userIdPermission", userIdPermission);
            sqlParameter[2] = new SqlParameter("@comId", comId);
            sqlParameter[3] = new SqlParameter("@AddedByUserId", userid);

            Helper.ExecProc("prcPermissionTransfer", sqlParameter);
            //db.Database.ExecuteSqlCommand("prcPermissionTransfer @p0,@p1,@p2,@p3 ", parameters: new[]
            //{ menuPermissionId, userIdPermission, comId, userid });

            //string ComID = Convert.ToInt32(comId);
            MenuPermission_Master menuPermission_Master = db.MenuPermissionMasters.Include(m => m.MenuPermission_Details).ThenInclude(abc => abc.ModuleMenus).Where(a => a.useridPermission == userIdPermission && a.comid == comId).FirstOrDefault();

            ViewBag.Title = "Edit";


            SqlParameter[] sqlParameter1 = new SqlParameter[2];
            sqlParameter1[0] = new SqlParameter("@Criteria", "CompanyPermission");
            sqlParameter1[1] = new SqlParameter("@userid", HttpContext.Session.GetString("userid"));

            List<CompanyList> CompanyList = Helper.ExecProcMapTList<CompanyList>("prcgetPermitCompanyList", sqlParameter1).ToList();


            //List<CompanyList> CompanyList = (db.Database.SqlQuery<CompanyList>("[prcgetPermitCompanyList]  @Criteria, @userid", new SqlParameter("Criteria", "CompanyPermission"), new SqlParameter("userid", userid))).ToList();
            ViewBag.comid = new SelectList(CompanyList, "ComId", "CompanyShortName", comId);



            SqlParameter[] sqlParameter2 = new SqlParameter[1];
            sqlParameter2[0] = new SqlParameter("@Criteria", "CompanyPermission");

            //List<AspnetUserList> AspNetUserList = Helper.ExecProcMapTList<AspnetUserList>("prcgetAspnetUserList", sqlParameter2).ToList();

            //List<AspnetUserList> AspNetUserList = (db.Database.SqlQuery<AspnetUserList>("[prcgetAspnetUserList]  @Criteria", new SqlParameter("Criteria", "CompanyPermission"))).ToList();
            //ViewBag.UserId = new SelectList(AspNetUserList, "UserId", "UserName",UserId);

            var list = res.MyUsers.ToList();
            var l = new List<AspnetUserList>();
            foreach (var c in list)
            {
                var le = new AspnetUserList();
                le.Email = c.UserName;
                le.UserId = c.UserID;
                le.UserName = c.UserName;
                l.Add(le);
            }

            ViewBag.useridPermission = new SelectList(l, "UserId", "UserName", userIdPermission);
            ViewBag.newUserPermission = new SelectList(l, "UserId", "UserName");


            //ViewBag.useridPermission = new SelectList(AspNetUserList, "UserId", "UserName", userIdPermission);
            //ViewBag.newUserPermission = new SelectList(AspNetUserList, "UserId", "UserName");
            //ViewBag.MenuList = db.ModuleMenus.ToList();

            SqlParameter[] sqlParameter3 = new SqlParameter[2];
            sqlParameter3[0] = new SqlParameter("@comid", comId);
            sqlParameter3[1] = new SqlParameter("@userid", userid);
            List<MenuPermissionModel> menuPermissionModels = Helper.ExecProcMapTList<MenuPermissionModel>("MenuPermissionInformation", sqlParameter3).ToList();
            ViewBag.MenuList = menuPermissionModels;




            // return View("Create", menuPermission_Master);

            return RedirectToAction("Index");

            //return View("Create");
        }

        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        public ActionResult Create(string comid, string UserId, int? MenuPermissionId, int? isDelete)
        {

            var appKey = HttpContext.Session.GetString("appkey");
            var model = new GetUserModel();
            model.AppKey = Guid.Parse(appKey);
            WebHelper webHelper = new WebHelper();

            string req = JsonConvert.SerializeObject(model);

            //Login
            //Uri url = new Uri(string.Format("https://localhost:44336/api/User/GetUsersCompanies"));
            //Uri url = new Uri(string.Format("http://101.2.165.187:82/api/user/GetUsersCompanies"));
            //Uri url = new Uri(string.Format("https://pqstec.com:92/api/User/GetUsersCompanies")); ///enable ssl certificate for secure connection
            Uri url = new Uri(string.Format("https://www.gtrbd.net/Support/api/AccountAPI/GetUsersCompanies"));


            string response = webHelper.GetUserCompany(url, req);

            GetResponse res = new GetResponse(response);

            if (MenuPermissionId > 0)
            {

                if (res.MyUsers != null || res.Companies != null)
                {

                    if (isDelete == 1)
                    {

                        ViewBag.Title = "Delete";

                    }
                    else
                    {
                        ViewBag.Title = "Edit";

                    }


                    if (MenuPermissionId == null)
                    {
                        return BadRequest();
                    }

                    MenuPermission_Master menuPermission_Master = db.MenuPermissionMasters.Include(m => m.MenuPermission_Details).ThenInclude(abc => abc.ModuleMenus).Where(m => m.MenuPermissionId.ToString() == MenuPermissionId.ToString()).FirstOrDefault();




                    if (menuPermission_Master == null)
                    {
                        return NotFound();
                    }



                    if (UserId == null)
                    {
                        UserId = HttpContext.Session.GetString("userid");


                    }
                    if (comid == null)
                    {
                        //comid = int.Parse((HttpContext.Session.GetString("comid")));
                        comid = HttpContext.Session.GetString("comid");


                    }




                    //Uri url = new Uri(string.Format("http://101.2.165.187:82/api/user/GetUsersCompanies"));
                    //string response = webHelper.GetUserCompany(url, req);
                    //GetResponse res = new GetResponse(response);

                    var list = res.MyUsers.ToList();
                    var l = new List<AspnetUserList>();
                    foreach (var c in list)
                    {
                        var le = new AspnetUserList();
                        le.Email = c.UserName;
                        le.UserId = c.UserID;
                        le.UserName = c.UserName;
                        l.Add(le);
                    }
                    var mas = db.MenuPermissionMasters.Where(x => x.comid == comid && x.useridPermission == UserId && x.DefaultModuleId != null).FirstOrDefault();

                    if (mas == null)
                    {

                        ViewBag.ModuleList = new SelectList(db.Modules, "ModuleId", "ModuleCaption");
                    }
                    else
                    {

                        var defaultmodule = db.Modules.Where(x => x.ModuleId == mas.DefaultModuleId).FirstOrDefault();
                        if (defaultmodule == null)
                        {
                            ViewBag.ModuleList = new SelectList(db.Modules, "ModuleId", "ModuleCaption");

                        }
                        else
                        {
                            ViewBag.ModuleList = new SelectList(db.Modules, "ModuleId", "ModuleCaption", defaultmodule.ModuleId);

                        }

                    }
                    ViewBag.useridPermission = new SelectList(l, "UserId", "UserName", UserId);
                    ViewBag.newUserPermission = new SelectList(l, "UserId", "UserName", UserId);


                    SqlParameter[] sqlParameter2 = new SqlParameter[2];
                    sqlParameter2[0] = new SqlParameter("@comid", comid);
                    sqlParameter2[1] = new SqlParameter("@userid", menuPermission_Master.useridPermission);
                    List<MenuPermissionModel> menuPermissionModels = Helper.ExecProcMapTList<MenuPermissionModel>("MenuPermissionInformation", sqlParameter2).ToList();


                    //List<MenuPermissionModel> menuPermissionModels = (db.Database.SqlQuery<MenuPermissionModel>("[MenuPermissionInformation]  @comid, @userid", new SqlParameter("comid", comid), new SqlParameter("userid", UserId))).ToList();
                    //ViewBag.ProductSerial = new SelectList(ProductSerialresult, "ProductSerialId", "ProductSerialNo");


                    ViewBag.MenuList = menuPermissionModels;



                    //var comName = db.Companys.Where(x => x.CompanyCode == comid).Select(x => x.CompanyName).FirstOrDefault();
                    ////var cp = db.CompanyPermissions.Where(x => x.ComId.ToString() == comid).Select(x => new { x.ComId, x.UserId, x.CompanyPermissionId, x.isChecked, x.isDefault }).FirstOrDefault();

                    var d = db.Companys.Where(x => x.AppKey == appKey).ToList();
                    //var cp = db.CompanyPermissions.Where(x => x.UserId == userid && x.ComId.ToString() == d.CompanyCode).FirstOrDefault();
                    //var data = new CompanyPermissionVM();


                    List<CompanyList> CompanyList = new List<CompanyList>();
                    foreach (var company in d)
                    {
                        var com = new CompanyList();
                        com.ComId = new Guid(company.CompanyCode);
                        com.CompanyShortName = company.CompanyName;

                        CompanyList.Add(com);
                    }

                    ViewBag.comid = new SelectList(CompanyList, "ComId", "CompanyShortName", comid);


                    return View("Create", menuPermission_Master);

                }

            }

            else
            {

                //if (UserId == null)
                //{
                //    UserId = HttpContext.Session.GetString("userid");


                //}
                if (comid == null)
                {
                    //comid = int.Parse((HttpContext.Session.GetString("comid")));
                    comid = HttpContext.Session.GetString("comid");


                }

                ViewBag.Title = "Create";
                var list = res.MyUsers.ToList();
                var l = new List<AspnetUserList>();
                foreach (var c in list)
                {
                    var le = new AspnetUserList();
                    le.Email = c.UserName;
                    le.UserId = c.UserID;
                    le.UserName = c.UserName;
                    l.Add(le);
                }

                ViewBag.useridPermission = new SelectList(l, "UserId", "UserName", UserId);
                ViewBag.newUserPermission = new SelectList(l, "UserId", "UserName");
                if (comid != null && UserId != null)
                {

                    MenuPermission_Master menuPermission_Master = db.MenuPermissionMasters.Include(m => m.MenuPermission_Details).ThenInclude(abc => abc.ModuleMenus).Where(m => m.comid == comid && m.useridPermission == UserId).FirstOrDefault();
                    if (menuPermission_Master != null)
                    {
                        ViewBag.ModuleList = new SelectList(db.Modules, "ModuleId", "ModuleCaption", menuPermission_Master.DefaultModuleId);
                        ViewBag.Title = "Edit";
                    }
                    else
                    {
                        ViewBag.ModuleList = new SelectList(db.Modules, "ModuleId", "ModuleCaption");
                    }




                    var d = db.Companys.Where(x => x.AppKey == appKey).ToList();
                    List<CompanyList> CompanyList1 = new List<CompanyList>();
                    foreach (var company in d)
                    {
                        var com = new CompanyList();
                        com.ComId = new Guid(company.CompanyCode);
                        com.CompanyShortName = company.CompanyName;

                        CompanyList1.Add(com);
                    }



                    //List<CompanyList> CompanyList1 = new List<CompanyList>();
                    //foreach (var company in res.Companies)
                    //{
                    //    var com = new CompanyList();
                    //    com.ComId = company.ComId;
                    //    com.CompanyShortName = company.CompanyName;

                    //    CompanyList1.Add(com);
                    //}

                    ViewBag.comid = new SelectList(CompanyList1, "ComId", "CompanyShortName");


                    SqlParameter[] sqlParameter2 = new SqlParameter[2];
                    sqlParameter2[0] = new SqlParameter("@comid", comid);
                    sqlParameter2[1] = new SqlParameter("@userid", UserId);

                    List<MenuPermissionModel> menuPermissionModels = Helper.ExecProcMapTList<MenuPermissionModel>("MenuPermissionInformation", sqlParameter2).ToList();

                    ViewBag.MenuList = menuPermissionModels;


                    return View(menuPermission_Master);
                }

                ViewBag.MenuList = null;
                //List<CompanyList> CompanyList = new List<CompanyList>();
                //foreach (var company in res.Companies)
                //{
                //    var com = new CompanyList();
                //    com.ComId = company.ComId;
                //    com.CompanyShortName = company.CompanyName;

                //    CompanyList.Add(com);
                //}


                var dd = db.Companys.Where(x => x.AppKey == appKey).ToList();
                //var cp = db.CompanyPermissions.Where(x => x.UserId == userid && x.ComId.ToString() == d.CompanyCode).FirstOrDefault();
                //var data = new CompanyPermissionVM();


                List<CompanyList> CompanyList = new List<CompanyList>();
                foreach (var company in dd)
                {
                    var com = new CompanyList();
                    com.ComId = new Guid(company.CompanyCode);
                    com.CompanyShortName = company.CompanyName;

                    CompanyList.Add(com);
                }

                ViewBag.comid = new SelectList(CompanyList, "ComId", "CompanyShortName");


            }


            return View();


        }

        public class CompanyList
        {
            public Guid ComId { get; set; }
            public string CompanyShortName { get; set; }
        }
        public class MenuPermissionModel
        {
            public int ModuleMenuId { get; set; }

            public string ParentMenuName { get; set; }

            public string ModuleMenuName { get; set; }

            public string ModuleMenuCaption { get; set; }

            public string ModuleMenuController { get; set; }

            public int SLNO { get; set; }

            public bool IsDefault { get; set; }

        }

        [HttpPost]
        [RequestSizeLimit(73400320)]
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        //[ValidateAntiForgeryToken]
        //[RequestSizeLimit(1074790400)]
        public ActionResult Create(MenuPermission_Master menuPermission_Master)
        {
            try
            {
                //var a =   menuPermission_Master;
                if ((HttpContext.Session.GetString("comid")) == "0" || (HttpContext.Session.GetString("comid")) == null)
                {
                    return Json(new { Success = 0, ex = new Exception("Please Login Again for This Transaction").Message.ToString() });
                }
                ViewBag.Title = "Create";
                //Mastersmain.VoucherInputDate = DateTime.Now.Date;

                //if (!UserAccess(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString()))
                //{
                //    return NotFound();
                //}

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

                if (ModelState.IsValid)
                {

                    if (menuPermission_Master.MenuPermissionId > 0)
                    {
                        menuPermission_Master.DateUpdated = DateTime.Now;
                        //cOM_MachinaryLC_Master.DateAdded = DateTime.Now;

                        menuPermission_Master.comid = HttpContext.Session.GetString("comid");
                        menuPermission_Master.useridUpdate = HttpContext.Session.GetString("userid");


                        if (menuPermission_Master.userid == null || menuPermission_Master.userid == "0")
                        {
                            menuPermission_Master.userid = HttpContext.Session.GetString("userid");

                        }
                        if (menuPermission_Master.comid == "")
                        {
                            menuPermission_Master.comid = HttpContext.Session.GetString("comid");
                        }

                        IQueryable<MenuPermission_Details> menuPermission_Detailses = db.MenuPermissionDetails.Where(p => p.MenuPermissionId == menuPermission_Master.MenuPermissionId);

                        db.MenuPermissionDetails.RemoveRange(menuPermission_Detailses);
                        //foreach (MenuPermission_Details ss in menuPermission_Detailses)
                        //{
                        //    db.MenuPermissionDetails.Remove(ss);
                        //}

                        if (menuPermission_Master.MenuPermission_Details != null)
                        {
                            foreach (MenuPermission_Details ss in menuPermission_Master.MenuPermission_Details)
                            {
                                ss.DateAdded = DateTime.Now;
                                ss.DateUpdated = DateTime.Now;

                                db.MenuPermissionDetails.Add(ss);
                                //db.SaveChanges();
                            }
                            db.SaveChanges();

                        }
                        db.Entry(menuPermission_Master).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                    else
                    {
                        menuPermission_Master.DateAdded = DateTime.Now;
                        menuPermission_Master.DateUpdated = DateTime.Now;
                        menuPermission_Master.comid = HttpContext.Session.GetString("comid");
                        menuPermission_Master.userid = (HttpContext.Session.GetString("userid"));

                        //cOM_MachinaryLC_Master.userid = HttpContext.Session.GetString("userid");

                        //foreach (MenuPermission_Details ss in menuPermission_Master.MenuPermission_Details)
                        //{
                        //    ss.DateAdded = DateTime.Now;
                        //    ss.DateUpdated = DateTime.Now;

                        //    //db.VoucherSubs.Add(ss);
                        //    //db.cOM_MachinaryLC_MasterExports.Add(ss);
                        //}

                        db.MenuPermissionMasters.Add(menuPermission_Master);
                    }

                    db.SaveChanges();
                    //return RedirectToAction("Index");
                }
                //return Json(new { Success = 1, MenuPermissionId = menuPermission_Master.MenuPermissionId, ex = "" });
                return Json(new { Success = 1 });


            }
            catch (Exception ex)
            {

                return Json(new
                {
                    success = false,
                    errors = ex.Message
                    //ModelState.Keys.SelectMany(k => ModelState[k].Errors).Select(m => m.ErrorMessage).ToArray()
                });
            }
        }


        //public ActionResult Edit(int? id)
        //{
        //    var userid = HttpContext.Session.GetString("userid"); ;
        //    if (id == null)
        //    {
        //        return BadRequest();
        //    }
        //    MenuPermission_Master menuPermission_Master = db.MenuPermissionMasters.Find(id);
        //    if (menuPermission_Master == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.Title = "Edit";



        //    /////newly added code for edit the user
        //    var appKey = HttpContext.Session.GetString("appkey");
        //    var model = new GetUserModel();
        //    model.AppKey = appKey;
        //    WebHelper webHelper = new WebHelper();

        //    string req = JsonConvert.SerializeObject(model);

        //    Uri url = new Uri(string.Format("http://101.2.165.187:82/api/user/GetUsersCompanies"));

        //    string response = webHelper.GetUserCompany(url, req);

        //    GetResponse res = new GetResponse(response);





        //    SqlParameter[] sqlParameter = new SqlParameter[2];
        //    sqlParameter[0] = new SqlParameter("@Criteria", "CompanyPermission");
        //    sqlParameter[1] = new SqlParameter("@userid", HttpContext.Session.GetString("userid"));

        //    List<CompanyList> CompanyLists = Helper.ExecProcMapTList<CompanyList>("prcgetPermitCompanyList", sqlParameter).ToList();

        //    //List<CompanyList> CompanyLists = (db.Database.SqlQuery<CompanyList>("[prcgetPermitCompanyList]  @Criteria, @userid", new SqlParameter("Criteria", "CompanyPermission"), new SqlParameter("userid", userid))).ToList();
        //    ViewBag.comid = new SelectList(CompanyLists, "ComId", "CompanyShortName");

        //    SqlParameter[] sqlParameter1 = new SqlParameter[1];
        //    sqlParameter1[0] = new SqlParameter("@Criteria", "CompanyPermission");

        //    List<AspnetUserList> AspNetUserList = Helper.ExecProcMapTList<AspnetUserList>("prcgetAspnetUserList", sqlParameter1).ToList();

        //    //List<AspnetUserList> AspNetUserList = (db.Database.SqlQuery<AspnetUserList>("[prcgetAspnetUserList]  @Criteria", new SqlParameter("Criteria", "CompanyPermission"))).ToList();
        //    //ViewBag.UserId = new SelectList(AspNetUserList, "UserId", "UserName",UserId);
        //    ViewBag.useridPermission = new SelectList(AspNetUserList, "UserId", "UserName");
        //    ViewBag.newUserPermission = new SelectList(AspNetUserList, "UserId", "UserName");
        //    ViewBag.MenuList = db.ModuleMenus.ToList();

        //    return View("Create", menuPermission_Master);
        //}

        ////[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        //public ActionResult Delete(int? MenuPermissionId)
        //{
        //    var userid = HttpContext.Session.GetString("userid");
        //    if (MenuPermissionId == null)
        //    {
        //        return BadRequest();
        //    }
        //    MenuPermission_Master menuPermission_Master = db.MenuPermissionMasters.Include(m => m.MenuPermission_Details).ThenInclude(abc => abc.ModuleMenus).Where(m => m.MenuPermissionId.ToString() == MenuPermissionId.ToString()).FirstOrDefault();
        //    if (menuPermission_Master == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.Title = "Delete";
        //    SqlParameter[] sqlParameter = new SqlParameter[2];
        //    sqlParameter[0] = new SqlParameter("@Criteria", "CompanyPermission");
        //    sqlParameter[1] = new SqlParameter("@userid", HttpContext.Session.GetString("userid"));

        //    List<CompanyList> CompanyLists = Helper.ExecProcMapTList<CompanyList>("prcgetPermitCompanyList", sqlParameter).ToList();

        //    //List<CompanyList> CompanyLists = (db.Database.SqlQuery<CompanyList>("[prcgetPermitCompanyList]  @Criteria, @userid", new SqlParameter("Criteria", "CompanyPermission"), new SqlParameter("userid", userid))).ToList();
        //    ViewBag.comid = new SelectList(CompanyLists, "ComId", "CompanyShortName");

        //    SqlParameter[] sqlParameter1 = new SqlParameter[1];
        //    sqlParameter1[0] = new SqlParameter("@Criteria", "CompanyPermission");

        //    List<AspnetUserList> AspNetUserList = Helper.ExecProcMapTList<AspnetUserList>("prcgetAspnetUserList", sqlParameter1).ToList();

        //    //List<AspnetUserList> AspNetUserList = (db.Database.SqlQuery<AspnetUserList>("[prcgetAspnetUserList]  @Criteria", new SqlParameter("Criteria", "CompanyPermission"))).ToList();
        //    //ViewBag.UserId = new SelectList(AspNetUserList, "UserId", "UserName",UserId);
        //    ViewBag.useridPermission = new SelectList(AspNetUserList, "UserId", "UserName");
        //    ViewBag.newUserPermission = new SelectList(AspNetUserList, "UserId", "UserName");

        //    SqlParameter[] sqlParametermenu = new SqlParameter[2];
        //    sqlParametermenu[0] = new SqlParameter("@comid",menuPermission_Master.comid);
        //    sqlParametermenu[1] = new SqlParameter("@userid", menuPermission_Master.userid);

        //    List<MenuPermissionModel> menuPermissionModels = Helper.ExecProcMapTList < MenuPermissionModel >("[MenuPermissionInformation]", sqlParametermenu).ToList();
        //    //ViewBag.ProductSerial = new SelectList(ProductSerialresult, "ProductSerialId", "ProductSerialNo");
        //    ViewBag.MenuList = menuPermissionModels;

        //    return View("Create", menuPermission_Master);
        //}


        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]       
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {
            try
            {

                IQueryable<MenuPermission_Details> grouplcsub = db.MenuPermissionDetails.Where(p => p.MenuPermissionId == id);

                db.MenuPermissionDetails.RemoveRange(grouplcsub);

                //foreach (COM_MachinaryLC_Details ss in grouplcsub)
                //{
                //    db.COM_MachinaryLC_Details.Remove(ss);
                //}

                MenuPermission_Master menuPermission_Master = db.MenuPermissionMasters.Find(id);
                db.MenuPermissionMasters.Remove(menuPermission_Master);
                db.SaveChanges();
                return Json(new { Success = 1, TermsId = menuPermission_Master.MenuPermissionId, ex = "" });
            }

            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }

            //return Json(new { Success = 0, ex = new Exception("Unable to Delete").Message.ToString() });
            // return RedirectToAction("Index");
        }

        //bool UserAccess(string cont,string act)
        //{
        //    string userId = HttpContext.Session.GetString("userid");
        //    if (act=="Index")
        //    {
        //        var details = db.MenuPermissionDetails.Where(m => m.MenuPermission_Masters.userid == userId && m.ModuleMenu.ModuleMenuController == cont && m.IsView==true).FirstOrDefault();
        //        if (details != null)
        //            return true;               
        //    }
        //    else if (act=="Create")
        //    {
        //        var details = db.MenuPermissionDetails.Where(m => m.MenuPermission_Masters.userid == userId && m.ModuleMenu.ModuleMenuController == cont && m.IsCreate == true).FirstOrDefault();
        //        if (details != null)
        //            return true;               
        //    }
        //    else if (act=="Edit")
        //    {
        //        var details = db.MenuPermissionDetails.Where(m => m.MenuPermission_Masters.userid == userId && m.ModuleMenu.ModuleMenuController == cont && m.IsEdit == true).FirstOrDefault();
        //        if (details != null)
        //            return true;               
        //    }
        //    else if (act=="Delete")
        //    {
        //        var details = db.MenuPermissionDetails.Where(m => m.MenuPermission_Masters.userid == userId && m.ModuleMenu.ModuleMenuController == cont && m.IsDelete == true).FirstOrDefault();
        //        if (details != null)
        //            return true;               
        //    }

        //    return true;
        //}

        public ActionResult Approval()
        {

            return View("Approval");
        }

    }
}