using GTERP.BLL;
using GTERP.Models;
using GTERP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static GTERP.Controllers.CompanyPermissionsController;

namespace GTERP.Controllers.HouseKeeping
{
    [OverridableAuthorize]
    public class UserPermissionController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public UserPermissionController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: UserPermission
        public async Task<IActionResult> Index()
        {
            var comid = HttpContext.Session.GetString("comid");
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            return View(await db.UserPermission.Where(x => x.ComId == comid).Include(x => x.HR_Emp_Info).ToListAsync());
        }



        // GET: UserPermission/Create
        public IActionResult Create()
        {
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");

            ViewBag.Title = "Create";

            var empInfo = (from emp in db.HR_Emp_Info
                           join d in db.Cat_Department on emp.DeptId equals d.DeptId
                           join s in db.Cat_Section on emp.SectId equals s.SectId
                           join des in db.Cat_Designation on emp.DesigId equals des.DesigId
                           where emp.ComId == comid && !db.UserPermission.Any(up => up.EmpId == emp.EmpId)
                           select new
                           {
                               Value = emp.EmpId,
                               Text = emp.EmpCode + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                           }).ToList();

            ViewData["EmpId"] = new SelectList(empInfo, "Value", "Text");

            var appKey = HttpContext.Session.GetString("appkey");
            var model = new GetUserModel();
            model.AppKey = Guid.Parse(appKey);
            WebHelper webHelper = new WebHelper();
            string req = JsonConvert.SerializeObject(model);
            //Uri url = new Uri(string.Format("https://localhost:44336/api/user/GetUsersCompanies"));
            //Uri url = new Uri(string.Format("https://pqstec.com:92/api/User/GetUsersCompanies")); ///enable ssl certificate for secure connection
            Uri url = new Uri(string.Format("https://www.gtrbd.net/Support/api/AccountAPI/GetUsersCompanies"));
            string response = webHelper.GetUserCompany(url, req);
            GetResponse res = new GetResponse(response);

            var list = res.MyUsers.ToList();
            var l = new List<CompanyPermissionsController.AspnetUserList>();
            foreach (var c in list)
            {
                var le = new CompanyPermissionsController.AspnetUserList();
                le.Email = c.UserName;
                le.UserId = c.UserID;
                le.UserName = c.UserName;
                l.Add(le);
            }

            ViewBag.Userlist = new SelectList(l.Where(u => !db.UserPermission.Any(p => p.AppUserId == u.UserId)), "UserId", "UserName");

            return View();
        }

        // POST: UserPermission/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("PermissionId,UserPermissionName,UserPermissionhortName")]*/ UserPermission UserPermission)
        {

            if (ModelState.IsValid)
            {
                UserPermission.UserId = HttpContext.Session.GetString("userid");
                UserPermission.ComId = HttpContext.Session.GetString("comid");
                if (UserPermission.PermissionId > 0)
                {
                    db.Entry(UserPermission).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), UserPermission.PermissionId.ToString(), "Update", UserPermission.EmpId.ToString());

                }
                else
                {
                    db.Add(UserPermission);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), UserPermission.PermissionId.ToString(), "Create", UserPermission.EmpId.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(UserPermission);

        }

        // GET: UserPermission/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var comid = HttpContext.Session.GetString("comid");

            ViewBag.Title = "Edit";
            var UserPermission = await db.UserPermission.FindAsync(id);

            if (UserPermission == null)
            {
                return NotFound();
            }

            var empInfo = (from emp in db.HR_Emp_Info
                           join d in db.Cat_Department on emp.DeptId equals d.DeptId
                           join s in db.Cat_Section on emp.SectId equals s.SectId
                           join des in db.Cat_Designation on emp.DesigId equals des.DesigId
                           where emp.ComId == comid && emp.EmpId == UserPermission.EmpId
                           select new
                           {
                               Value = emp.EmpId,
                               Text = emp.EmpCode + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                           }).ToList();

            ViewData["EmpId"] = new SelectList(empInfo, "Value", "Text", UserPermission.EmpId);

            var appKey = HttpContext.Session.GetString("appkey");
            var model = new GetUserModel();
            model.AppKey = Guid.Parse(appKey);
            WebHelper webHelper = new WebHelper();
            string req = JsonConvert.SerializeObject(model);
            //Uri url = new Uri(string.Format("https://localhost:44336/api/user/GetUsersCompanies"));
            //Uri url = new Uri(string.Format("https://pqstec.com:92/api/User/GetUsersCompanies")); ///enable ssl certificate for secure connection
            Uri url = new Uri(string.Format("https://www.gtrbd.net/Support/api/AccountAPI/GetUsersCompanies"));
            string response = webHelper.GetUserCompany(url, req);
            GetResponse res = new GetResponse(response);

            var list = res.MyUsers.ToList();
            var l = new List<CompanyPermissionsController.AspnetUserList>();
            foreach (var c in list.Where(u => u.UserID == UserPermission.AppUserId))
            {
                var le = new CompanyPermissionsController.AspnetUserList();
                le.Email = c.UserName;
                le.UserId = c.UserID;
                le.UserName = c.UserName;
                l.Add(le);
            }

            ViewBag.Userlist = new SelectList(l, "UserId", "UserName", UserPermission.AppUserId);

            return View("Create", UserPermission);

        }

        // GET: UserPermission/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var comid = HttpContext.Session.GetString("comid");


            var UserPermission = await db.UserPermission

                .FirstOrDefaultAsync(m => m.PermissionId == id);

            if (UserPermission == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";

            var empInfo = (from emp in db.HR_Emp_Info
                           join d in db.Cat_Department on emp.DeptId equals d.DeptId
                           join s in db.Cat_Section on emp.SectId equals s.SectId
                           join des in db.Cat_Designation on emp.DesigId equals des.DesigId
                           where emp.ComId == comid && emp.EmpId == UserPermission.EmpId
                           select new
                           {
                               Value = emp.EmpId,
                               Text = emp.EmpCode + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                           }).ToList();

            ViewData["EmpId"] = new SelectList(empInfo, "Value", "Text", UserPermission.EmpId);

            var appKey = HttpContext.Session.GetString("appkey");
            var model = new GetUserModel();
            model.AppKey = Guid.Parse(appKey);
            WebHelper webHelper = new WebHelper();
            string req = JsonConvert.SerializeObject(model);
            //Uri url = new Uri(string.Format("https://localhost:44336/api/user/GetUsersCompanies"));
            //Uri url = new Uri(string.Format("https://pqstec.com:92/api/User/GetUsersCompanies")); ///enable ssl certificate for secure connection
            Uri url = new Uri(string.Format("https://www.gtrbd.net/Support/api/AccountAPI/GetUsersCompanies"));
            string response = webHelper.GetUserCompany(url, req);
            GetResponse res = new GetResponse(response);

            var list = res.MyUsers.ToList();
            var l = new List<CompanyPermissionsController.AspnetUserList>();
            foreach (var c in list.Where(u => u.UserID == UserPermission.AppUserId))
            {
                var le = new CompanyPermissionsController.AspnetUserList();
                le.Email = c.UserName;
                le.UserId = c.UserID;
                le.UserName = c.UserName;
                l.Add(le);
            }

            ViewBag.Userlist = new SelectList(l, "UserId", "UserName", UserPermission.AppUserId);

            return View("Create", UserPermission);

        }

        // POST: UserPermission/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var UserPermission = await db.UserPermission.FindAsync(id);
                db.UserPermission.Remove(UserPermission);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), UserPermission.PermissionId.ToString(), "Delete", UserPermission.EmpId.ToString());
                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, PermissionId = UserPermission.PermissionId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        private bool UserPermissionExists(int id)
        {
            return db.UserPermission.Any(e => e.PermissionId == id);
        }
    }
}