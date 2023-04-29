using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers.HR
{
    [OverridableAuthorize]

    public class LeaveBalanceController : Controller
    {
        private readonly GTRDBContext db;
        public clsConnectionNew clsCon { get; set; }
        public clsProcedure clsProc { get; }

        public LeaveBalanceController(GTRDBContext context, clsConnectionNew _clsCon, clsProcedure _clsProc)
        {
            db = context;
            clsCon = _clsCon;
            clsProc = _clsProc;
        }

        // GET: LeaveBalance
        public async Task<IActionResult> Index()
        {
            ViewBag.OpeningYear = new SelectList(db.HR_Leave_Balance.OrderByDescending(x => x.DtOpeningBalance).Select(x => x.DtOpeningBalance).Distinct()).ToList();
            ViewBag.EmpId = new SelectList(db.HR_Emp_Info.Select(e => new { Text = e.EmpName + "- [" + e.EmpCode + "]", Value = e.EmpId }).OrderBy(e => e.Value).ToList(), "Value", "Text");
            ViewBag.SectId = new SelectList(db.Cat_Section, "SectId", "SectName");
            ViewBag.LeaveBalanceList = new List<HR_Leave_Balance>();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult GetLeaveBalance(string Criteria, int EmpId, int SectId, string DtOpBal)
        {

            var comid = HttpContext.Session.GetString("comid");
            SqlParameter[] parameter = new SqlParameter[6];

            parameter[0] = new SqlParameter("@Id", 1);
            parameter[1] = new SqlParameter("@ComId", comid);
            parameter[2] = new SqlParameter("@Criteria", Criteria);
            parameter[3] = new SqlParameter("@EmpId", EmpId);
            parameter[4] = new SqlParameter("@dtOPBal", DtOpBal);
            parameter[5] = new SqlParameter("@sectID", SectId);
            List<LeaveBalance> ProductSerialresult = Helper.ExecProcMapTList<LeaveBalance>("Hr_prcgetleavebalance", parameter);
            return Json(ProductSerialresult);
        }

        public class LeaveBalance
        {
            public int EmpId { get; set; }
            public string EmpCode { get; set; }
            public string EmpName { get; set; }
            public string SectName { get; set; }
            public string dtOpeningDate { get; set; }
            public float CL { get; set; }
            public float SL { get; set; }
            public float EL { get; set; }
            public float ML { get; set; }
            public int LvBalId { get; set; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveLeaveBalance(List<HR_Leave_Balance> LeaveBalance)
        {
            try
            {
                foreach (HR_Leave_Balance item in LeaveBalance)
                {
                    var userid = HttpContext.Session.GetString("userid");
                    item.ComId = HttpContext.Session.GetString("comid");
                    if (item.LvBalId > 0)
                    {
                        HR_Leave_Balance mdata = db.HR_Leave_Balance.Where(m => m.LvBalId == item.LvBalId).FirstOrDefault();
                        mdata.UpdateByUserId = userid;
                        mdata.UserId = userid;
                        mdata.DateUpdated = DateTime.Now;
                        mdata.EL = item.EL;
                        mdata.CL = item.CL;
                        mdata.SL = item.SL;
                        mdata.ML = item.ML;
                        db.Entry(mdata).Property(x => x.UpdateByUserId).IsModified = true;
                        db.Entry(mdata).Property(x => x.UserId).IsModified = true;
                        db.Entry(mdata).Property(x => x.DateUpdated).IsModified = true;
                        db.Entry(mdata).Property(x => x.SL).IsModified = true;
                        db.Entry(mdata).Property(x => x.EL).IsModified = true;
                        db.Entry(mdata).Property(x => x.CL).IsModified = true;
                        db.Entry(mdata).Property(x => x.ML).IsModified = true;
                        await db.SaveChangesAsync();
                    }
                    else
                    {
                        item.UserId = userid;
                        item.UpdateByUserId = userid;
                        item.DateAdded = DateTime.Now;
                        db.HR_Leave_Balance.Add(item);
                        await db.SaveChangesAsync();
                    }
                }
                return Json(LeaveBalance);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private bool HR_Leave_BalanceExists(int id)
        {
            return db.HR_Leave_Balance.Any(e => e.LvBalId == id);
        }
    }
}
