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

namespace GTERP.Controllers
{
    ////[Authorize]
    [OverridableAuthorize]
    public class ReportPermissionsController : Controller
    {
        private GTRDBContext db;
        public static string ResponseText = "";

        public ReportPermissionsController(GTRDBContext _db)
        {
            db = _db;
        }

        // GET: Countries
        public ActionResult Index()
        {

            return View(db.ReportPermissions.ToList());
        }

        public JsonResult getUserReport(string userid)
        {

            //string comid = HttpContext.Session.GetString("comid");

            //SqlParameter[] parameter = new SqlParameter[1];
            //parameter[0] = new SqlParameter("@ComId", comid);
            //List<EmpList> EmployeeListData = Helper.ExecProcMapTList<EmpList>("HR_prcGetEmployee", parameter);


            string comid = HttpContext.Session.GetString("comid");
            //string userid = HttpContext.Session.GetString("userid");

            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@comid", comid);
            parameters[1] = new SqlParameter("@userid", userid);
            List<ReportPermissionsVM> ListOfReportPermission = Helper.ExecProcMapTList<ReportPermissionsVM>("HR_ReportPermission", parameters);


            //var appKey = HttpContext.Session.GetString("appkey");
            //var model = new GetUserModel();
            //model.AppKey = Guid.Parse(appKey);

            //Uri url = new Uri(string.Format("https://www.gtrbd.net/Support/api/AccountAPI/GetUsersCompanies"));

            //WebHelper webHelper = new WebHelper();
            //string req = JsonConvert.SerializeObject(model);

            //string response = webHelper.GetUserCompany(url, req);
            //GetResponse res = new GetResponse(response);



            //var d = db.HR_ReportType.ToList();
            //var data = new ReportPermissionsVM();


            return Json(ListOfReportPermission);

        }



        // GET: Countries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        public class AspnetUserList
        {
            public string UserId { get; set; }

            public string UserName { get; set; }
            public string Email { get; set; }
        }

        public class CompanyList
        {
            public int isChecked { get; set; }

            public Guid ComId { get; set; }
            public string UserId { get; set; }

            public int ReportPermissionsId { get; set; }

            public string ReportName { get; set; }
            public int isDefault { get; set; }

        }
        public class GetUserModel
        {
            public Guid AppKey { get; set; }

        }

        // GET: Countries/Create
        public ActionResult Create()
        {
            //need to have all users and company list fom chitra api

            var appKey = HttpContext.Session.GetString("appkey");
            var model = new GetUserModel();
            model.AppKey = Guid.Parse(appKey);
            WebHelper webHelper = new WebHelper();

            string req = JsonConvert.SerializeObject(model);

            Uri url = new Uri(string.Format("https://www.gtrbd.net/Support/api/AccountAPI/GetUsersCompanies"));

            string response = webHelper.GetUserCompany(url, req);

            GetResponse res = new GetResponse(response);


            if (res.Companies != null || res.MyUsers != null)
            {
                List<AspnetUserList> aspNetUser = new List<AspnetUserList>();
                foreach (var user in res.MyUsers)
                {
                    var u = new AspnetUserList();
                    u.UserId = user.UserID;
                    u.UserName = user.UserName;
                    aspNetUser.Add(u);
                }
                ViewBag.UserId = new SelectList(aspNetUser, "UserId", "UserName");

                //var comid = HttpContext.Session.GetString("comid");
                //var userid = HttpContext.Session.GetString("userid");
                //var cp = db.ReportPermissions.Where(x => x.ComId.ToString() == comid).Select(x => new { x.ComId, x.UserId, x.ReportPermissionsId, x.isChecked, x.ReportId }).ToList();

                //SqlParameter[] parameter = new SqlParameter[2];
                //parameter[0] = new SqlParameter("@comid", comid);
                //parameter[1] = new SqlParameter("@userid", userid);

                //List<ReportPermissionsVM> ReportPermission = Helper.ExecProcMapTList<ReportPermissionsVM>("HR_ReportPermission", parameter);
                //return View(ReportPermission);
                return View(new List<ReportPermissionsVM>());
            }
            return View(new List<ReportPermissionsVM>());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        ////[Authorize]
        //public string Create(List<CompanyPermission> companypermission)
        public JsonResult Create(List<ReportPermissions> ReportPermissions, string UserId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var userid = HttpContext.Session.GetString("userid");
                    var comid = HttpContext.Session.GetString("comid");

                    var exist = db.ReportPermissions.Where(r => r.UserId == UserId).ToList();
                    if (exist.Count > 0)
                    {
                        db.RemoveRange(exist);
                        db.SaveChanges();
                    }

                    if (ReportPermissions != null)
                    {

                        ReportPermissions.ForEach((p) => p.ComId = comid);

                        db.ReportPermissions.AddRange(ReportPermissions);
                        db.SaveChanges();

                        return Json(new { Success = 1, ex = "" });

                    }



                    return Json(new { Success = 1, ex = "" });

                }
            }
            catch (Exception ex)
            {

                return Json(new { Success = 0, ex = ex.Message.ToString() });
            }


            return Json(new { Success = 0, ex = new Exception("Unable to save").Message.ToString() });
        }

        // GET: Countries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(/*Include =*/ "CountryCode,CountryName,CurrencyName,CountryShortName,CultureInfo,CurrencySymbol,CurrencyShortName,flagclass,DialCode")] Country country)
        {
            if (ModelState.IsValid)
            {
                db.Entry(country).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(country);
        }

        // GET: Countries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Country country = db.Countries.Find(id);
            db.Countries.Remove(country);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
