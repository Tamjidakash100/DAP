using GTERP.Models;
using GTERP.Models.Common;
using GTERP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static GTERP.Controllers.CompanyPermissionsController;

namespace GTERP.Controllers
{
    [OverridableAuthorize]
    public class ReportTypesController : Controller
    {
        private readonly GTRDBContext _context;

        public ReportTypesController(GTRDBContext context)
        {
            _context = context;
        }

        // GET: ReportTypes
        public IActionResult Index()
        {
            return View("Create");
        }
        public IActionResult GetReportTypes()
        {
            return Json(new { data = _context.ReportTypes.ToList() });
        }

        // GET: ReportTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportType = await _context.ReportTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportType == null)
            {
                return NotFound();
            }

            return View(reportType);
        }

        // GET: ReportTypes/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRole(ApprovalRole model)
        {
            string errorMessage = "Model State is not valid";
            if (ModelState.IsValid)
            {
                try
                {
                    _context.ApprovalRoles.Add(model);
                    _context.SaveChanges();
                    return Json(new { success = 1 });
                }
                catch (Exception ex)
                {

                    errorMessage = ex.Message;
                }

            }
            return Json(new { error = errorMessage });
        }
        // POST: ReportTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReportType reportType)
        {
            string errorMessage = "Model State is not valid";
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(reportType);
                    await _context.SaveChangesAsync();
                    return Json(new { success = 1 });
                }
                catch (Exception ex)
                {

                    errorMessage = ex.Message;
                }

            }
            return Json(new { error = errorMessage });
        }

        // GET: ReportTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportType = await _context.ReportTypes.FindAsync(id);
            if (reportType == null)
            {
                return NotFound();
            }
            return Json(new { data = reportType });
        }
        public async Task<IActionResult> EditRole(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportType = await _context.ApprovalRoles.FindAsync(id);
            if (reportType == null)
            {
                return NotFound();
            }
            return Json(new { result = reportType });
        }

        // POST: ReportTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeTitle,Description")] ReportType reportType)
        {
            if (id != reportType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportTypeExists(reportType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Json(new { success = 1 });
            }
            return Json(new { error = 0 });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(int id, [Bind("Id,RoleTitle,RoleDescription")] ApprovalRole approvalRole)
        {
            if (id != approvalRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(approvalRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportTypeExists(approvalRole.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Json(new { success = 1 });
            }
            return Json(new { error = 0 });
        }

        // GET: ReportTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportType = await _context.ReportTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportType == null)
            {
                return NotFound();
            }

            return View(reportType);
        }

        // POST: ReportTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var reportType = await _context.ReportTypes.FindAsync(id);
                _context.ReportTypes.Remove(reportType);
                _context.SaveChanges();
                return Json(new { success = 1 });
            }
            catch (Exception ex)
            {

                return Json(new { error = ex.Message });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRole(int id)
        {
            try
            {
                var role = await _context.ApprovalRoles.FindAsync(id);
                _context.ApprovalRoles.Remove(role);
                _context.SaveChanges();
                return Json(new { success = 1 });
            }
            catch (Exception ex)
            {

                return Json(new { error = ex.Message });
            }


        }
        public ActionResult GetRoleAndUsers()
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
            if (res.MyUsers != null)
            {
                var list = res.MyUsers.ToList();
                var UserListM = new List<AspnetUserList>();
                foreach (var c in list)
                {
                    var le = new AspnetUserList();
                    le.Email = c.UserName;
                    le.UserId = c.UserID;
                    le.UserName = c.UserName;
                    UserListM.Add(le);
                }
                var UserList = new List<users>();
                var RoleList = _context.ApprovalRoles.ToList();

                foreach (var item in UserListM)
                {
                    var users = new users();
                    users.UserId = item.UserId;
                    users.Email = item.Email;
                    UserList.Add(users);

                }
                return Json(new { roleList = RoleList, userList = UserList });
            }



            return Json(new { error = "0" });


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveApproval(string assignApprovals)
        {
            if (ModelState.IsValid)
            {
                var JObject = new JObject();
                var da = JObject.Parse(assignApprovals);
                string d = da["userRoleList"].ToString();
                var objList = JsonConvert.DeserializeObject<List<AssignApproval>>(d);
                using (var tr = _context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var item in objList)
                        {

                            //foreach (var r in item.RoleUserList)
                            //{
                            var panel = new ApprovalPanel();
                            panel.ApprovalRoleId = item.RoleId;
                            panel.ReportTypeId = item.RptTypeId;
                            panel.CreatedUserId = item.CreatedUserId;
                            panel.ApprovedUserId = item.ApprovalUserId;
                            panel.ComId = HttpContext.Session.GetString("comid");
                            _context.ApprovalPanels.Add(panel);
                            _context.SaveChanges();
                            //}

                        }
                        tr.Commit();
                        return Json(new { success = 1 });
                    }
                    catch (Exception ex)
                    {
                        tr.Rollback();
                        Console.WriteLine(ex.Message);
                    }

                }
            }
            return Json(new { error = 0 });
        }


        public JsonResult GetCreateUsersApprovals(string userId)
        {
            var approvalList = _context.ApprovalPanels.Where(x => x.CreatedUserId == userId).Select(x => new { x.ReportType.Id, x.ReportType.TypeTitle }).Distinct().ToList();

            return Json(new { approvalList });
        }
        public JsonResult GetCreateUsersApprovalsRoles(string userId, int reportTypeId)
        {
            var approvalList = _context.ApprovalPanels.Where(x => x.CreatedUserId == userId).Select(x => new { x.ApprovalRole.Id, x.ApprovalRole.RoleTitle, x.ApprovedUserId }).Distinct().ToList();

            return Json(new { approvalList });
        }

        public JsonResult GetApprovalList(string userId, int reportTypeId)
        {
            var approvalUserList = _context.ApprovalPanels.Where(x => x.CreatedUserId == userId && x.ReportTypeId == reportTypeId).Select(x => new { x.ApprovedUserId }).ToList();

            return Json(new { approvalUserList });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApprovalTransfer(string fromUserId, string toUserId)

        {
            try
            {


                SqlParameter[] sqlParameter = new SqlParameter[3];
                sqlParameter[0] = new SqlParameter("@newUserId", toUserId);
                sqlParameter[1] = new SqlParameter("@comId", HttpContext.Session.GetString("comid"));
                sqlParameter[2] = new SqlParameter("@fromUserId", fromUserId);

                Helper.ExecProc("prcApprovalTransfer", sqlParameter);
                return Json(new { success = 1 });
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return Json(new { error = ex.Message });
            }


        }

        private bool ReportTypeExists(int id)
        {
            return _context.ReportTypes.Any(e => e.Id == id);
        }
    }

    public class RoleAndUsers
    {
        public int Id { get; set; }
        public string ComId { get; set; }
        public string RoleId { get; set; }
        public string UserId { get; set; }
    }
    public class users
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
    }
    public class AssignApproval
    {
        //{ Id: 0, RptTypeId: 0, RoleId: 0, CreatedUserId: "", ApprovalUserId: "" };
        public int Id { get; set; }
        public int RptTypeId { get; set; }
        public int RoleId { get; set; }
        public string CreatedUserId { get; set; }
        public string ApprovalUserId { get; set; }
    }
    //public class AssignApprovalRoleUser
    //{
    //    public int Id { get; set; }
    //    public int RoleId { get; set; }
    //    public string CreatedUserId { get; set; }
    //    public string ApprovalUserId { get; set; }
    //}

}
