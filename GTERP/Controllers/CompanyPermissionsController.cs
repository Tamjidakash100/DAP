using GTERP.Models;
using GTERP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GTERP.Controllers
{
    ////[Authorize]
    [OverridableAuthorize]
    public class CompanyPermissionsController : Controller
    {
        private GTRDBContext db;
        public static string ResponseText = "";

        public CompanyPermissionsController(GTRDBContext _db)
        {
            db = _db;
        }

        // GET: Countries
        public ActionResult Index()
        {

            return View(db.UserCompanyPermissions.ToList());
        }

        public JsonResult getUserCompany(string UserId)
        {
            var SavedList = db.CompanyPermissions.Where(x => x.UserId == UserId).ToList();

            var dataList = new List<CompanyPermissionVM>();
            //foreach (var asdf in newList)
            //{
            //    var data = new CompanyPermissionVM();

            //    data.UserId = asdf.UserId;
            //    data.CompanyName = "DAP";
            //    data.ComId = asdf.ComId;
            //    data.isChecked = asdf.isChecked;
            //    data.isDefault = asdf.isDefault;
            //    data.CompanyPermissionId = asdf.CompanyPermissionId;
            //    dataList.Add(data);
            //}


            var appKey = HttpContext.Session.GetString("appkey");
            var model = new GetUserModel();
            model.AppKey = Guid.Parse(appKey);

            //Uri url = new Uri(string.Format("https://localhost:44336/api/User/GetUsersCompanies"));
            //Uri url = new Uri(string.Format("http://101.2.165.187:82/api/user/GetUsersCompanies"));
            //Uri url = new Uri(string.Format("https://pqstec.com:92/api/User/GetUsersCompanies")); ///enable ssl certificate for secure connection
            Uri url = new Uri(string.Format("https://www.gtrbd.net/Support/api/AccountAPI/GetUsersCompanies"));

            WebHelper webHelper = new WebHelper();
            string req = JsonConvert.SerializeObject(model);

            string response = webHelper.GetUserCompany(url, req);
            GetResponse res = new GetResponse(response);



            var d = db.Companys.Where(x => x.AppKey == appKey).FirstOrDefault();
            var cp = db.CompanyPermissions.Where(x => x.UserId == UserId && x.ComId.ToString() == d.CompanyCode).FirstOrDefault();
            var data = new CompanyPermissionVM();

            data.UserId = UserId;
            data.CompanyName = d.CompanyName;
            data.ComId = Guid.Parse(d.CompanyCode);
            if (cp != null)
            {
                data.isChecked = cp.isChecked;
                data.isDefault = cp.isDefault;
                data.CompanyPermissionId = cp.CompanyPermissionId;
            }


            //dataList.Add(data);
            //var list = db.CompanyPermissions.Where(x => x.UserId == UserId).Select(x=>x.ComId).Distinct().ToList();
            //var l = new List<CompanyList>();
            //for (int i = 0; i < list.Count; i++)
            //{
            //    var seq = list.ElementAt(i);
            //    var d = db.Companys.Where(x => x.CompanyCode == seq.ToString()).FirstOrDefault();
            //    var data = new CompanyPermissionVM();

            //    data.UserId = UserId;
            //    data.CompanyName = d.CompanyName;
            //    data.ComId = Guid.Parse(d.CompanyCode);
            //    data.isChecked = 0;
            //    data.isDefault = 0;
            //    data.CompanyPermissionId = 0;
            //    dataList.Add(data);
            //}

            foreach (var cc in SavedList)
            {

                foreach (var item in dataList)
                {
                    if (item.ComId == cc.ComId)
                    {
                        item.isChecked = cc.isChecked;
                        item.isDefault = cc.isDefault;
                        item.CompanyPermissionId = cc.CompanyPermissionId;

                    }


                }






            }

            //List<CompanyList> CompanyList = new List<CompanyList>();
            //foreach (var company in res.Companies)
            //{
            //    var com = new CompanyList();
            //    com.ComId = company.ComId;
            //    //com.CompanyShortName = company.CompanyName;

            //    CompanyList.Add(com);
            //}

            //ViewBag.comid = new SelectList(l, "ComId", "CompanyShortName");


            return Json(data);

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

            public int CompanyPermissionId { get; set; }

            public string CompanyName { get; set; }
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

            //Login
            //Uri url = new Uri(string.Format("https://localhost:44336/api/User/GetUsersCompanies"));
            //Uri url = new Uri(string.Format("http://101.2.165.187:82/api/user/GetUsersCompanies"));
            //Uri url = new Uri(string.Format("https://pqstec.com:92/api/User/GetUsersCompanies")); ///enable ssl certificate for secure connection
            Uri url = new Uri(string.Format("https://www.gtrbd.net/Support/api/AccountAPI/GetUsersCompanies"));

            string response = webHelper.GetUserCompany(url, req);

            GetResponse res = new GetResponse(response);

            // var cplist = new List<CompanyPermissionVM>();
            var data = new CompanyPermissionVM();

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

                var comid = HttpContext.Session.GetString("comid");
                var comName = db.Companys.Where(x => x.CompanyCode == comid).Select(x => x.CompanyName).FirstOrDefault();
                var cp = db.CompanyPermissions.Where(x => x.ComId.ToString() == comid).Select(x => new { x.ComId, x.UserId, x.CompanyPermissionId, x.isChecked, x.isDefault }).FirstOrDefault();

                data = new CompanyPermissionVM();
                data.UserId = cp.UserId;
                data.CompanyName = comName;
                data.ComId = cp.ComId;
                data.isChecked = cp.isChecked;
                data.isDefault = cp.isDefault;
                data.CompanyPermissionId = cp.CompanyPermissionId;

                //var UserCompanyList = new List<CompanyList>();



                //foreach (var com in res.Companies)
                //{
                //    var c = new CompanyList();
                //    c.ComId = com.ComId;
                //    c.CompanyName = com.CompanyName;
                //    UserCompanyList.Add(c);
                //}

                //for (int i = 0; i < UserCompanyList.Count; i++)
                //{
                //    var d = UserCompanyList.ElementAt(i).ComId;
                //    var newList=db.CompanyPermissions.Where(x => x.ComId == d).ToList();

                //    var dataList = new List<CompanyPermissionVM>();

                //    foreach (var list in newList)
                //    {
                //        var data = new CompanyPermissionVM();
                //        data.UserId = list.UserId;
                //        data.CompanyName = "DAP";
                //        data.ComId = list.ComId;
                //        data.isChecked = list.isChecked;
                //        data.isDefault = list.isDefault;
                //        data.CompanyPermissionId = list.CompanyPermissionId;
                //        dataList.Add(data);
                //    }


                //    cplist.AddRange(dataList);
                //}

                //ViewBag.ComId = new SelectList(data, "ComId", "CompanyName");
            }
            else
            {


                //No Response from the server

            }
            var comPermision = new CompanyPermission();

            return View(data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        ////[Authorize]
        //public string Create(List<CompanyPermission> companypermission)
        public JsonResult Create(string companyPermissions)
        {
            JObject str = JObject.Parse(companyPermissions);
            var result = str["strfy"].ToString();

            var cp = JsonConvert.DeserializeObject<CompanyPermission>(result);
            try
            {
                //var errors = ModelState.Where(x => x.Value.Errors.Any())
                //.Select(x => new { x.Key, x.Value.Errors });
                //var cp=JsonConvert.DeserializeObject<CompanyPermission>(strfy);

                if (ModelState.IsValid)
                {

                    // If sales main has SalesID then we can understand we have existing sales Information
                    // So we need to Perform Update Operation

                    var userid = HttpContext.Session.GetString("userid");

                    // Perform Update

                    if (cp.CompanyPermissionId > 0)
                    {
                        if (cp.isChecked == 1)
                        {
                            db.Entry(cp).State = EntityState.Modified;
                        }
                        else
                        {
                            var x = db.CompanyPermissions.Where(p => p.CompanyPermissionId == cp.CompanyPermissionId).FirstOrDefault();
                            //db.CompanyPermissions.Remove(CP);
                            db.CompanyPermissions.Remove(x);
                        }
                        db.SaveChanges();
                    }
                    else
                    {
                        if (cp.isChecked == 1)
                        {
                            db.CompanyPermissions.Add(cp);
                            db.SaveChanges();
                        }
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
