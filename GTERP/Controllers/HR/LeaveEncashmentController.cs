using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers.HouseKeeping
{
    [OverridableAuthorize]
    public class LeaveEncashmentController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public LeaveEncashmentController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: lvEncashment
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            return View(await db.HR_LvEncashment.Include(e => e.HR_Emp_Info).ToListAsync());
        }


        // GET: lvEncashment/Create
        public IActionResult Create()
        {
            string comid = HttpContext.Session.GetString("comid");
            ViewBag.Title = "Create";
            ViewData["EmpId"] = new SelectList(db.HR_Emp_Info
             .Where(s => s.ComId == comid)
             .Select(s => new { Text = s.EmpName + " - [ " + s.EmpCode + " ]", Value = s.EmpId })
             .ToList(), "Value", "Text");

            return View();
        }



        // POST: lvEncashment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HR_LvEncashment lvEncashment)
        {
            if (ModelState.IsValid)
            {
                //lvEncashment.UserId = HttpContext.Session.GetString("userid");
                lvEncashment.ComId = HttpContext.Session.GetString("comid");

                string comid = HttpContext.Session.GetString("comid");



                var elBalance = db.HR_Leave_Balance
               .Where(l => l.EmpId == lvEncashment.EmpId && l.DtOpeningBalance == lvEncashment.LvEncashmentIYear)
               .FirstOrDefault();
                if (elBalance != null)
                {
                    SqlParameter[] parameter = new SqlParameter[3];
                    parameter[0] = new SqlParameter("@ComId", comid);
                    parameter[1] = new SqlParameter("@EmpId", lvEncashment.EmpId);
                    parameter[2] = new SqlParameter("@dtInput", lvEncashment.DtInput);
                    var basic = Helper.ExecProcMapTList<Basic>("HR_prcGetBS", parameter);

                    if (basic.Count > 0 || basic != null)
                    {
                        var bs = basic.FirstOrDefault().BS;

                        //float round = (float)Math.Round((decimal)((bs * lvEncashment.TotalDays * 12) / 365), 0);
                        float a = (float)(bs * lvEncashment.TotalDays * 12) / 365;
                        lvEncashment.Amount = (float)Math.Round(a, 0);
                        lvEncashment.Stamp = 10;
                        lvEncashment.NetAmount = lvEncashment.Amount - 10;
                    }

                    if (lvEncashment.LvEncashmentId > 0)
                    {
                        if (lvEncashment.IsELEnjoy)
                            elBalance.EL = 0;
                        else
                            elBalance.EL = lvEncashment.ELBalance - lvEncashment.TotalDays;

                        db.Entry(elBalance).State = EntityState.Modified;

                        lvEncashment.DateUpdated = DateTime.Now;
                        lvEncashment.UpdateByUserId = HttpContext.Session.GetString("userid");
                        lvEncashment.ProssType = GetProssType(Convert.ToDateTime(lvEncashment.DtInput));
                        db.Entry(lvEncashment).State = EntityState.Modified;
                        await db.SaveChangesAsync();

                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), lvEncashment.LvEncashmentId.ToString(), "Update", lvEncashment.LvEncashmentId.ToString());

                    }
                    else
                    {

                        if (lvEncashment.IsELEnjoy)
                            elBalance.EL = 0;
                        else
                            elBalance.EL = elBalance.EL - lvEncashment.TotalDays;



                        db.Entry(elBalance).State = EntityState.Modified;

                        lvEncashment.UserId = HttpContext.Session.GetString("userid");
                        lvEncashment.DateAdded = DateTime.Now;
                        lvEncashment.ProssType = GetProssType(Convert.ToDateTime(lvEncashment.DtInput));
                        db.Add(lvEncashment);
                        await db.SaveChangesAsync();

                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), lvEncashment.LvEncashmentId.ToString(), "Create", lvEncashment.LvEncashmentId.ToString());

                    }
                    return RedirectToAction(nameof(Index));
                }
                TempData["Message"] = "The Employee has not EL Balance";
                TempData["Status"] = "2";

            }
            return View(lvEncashment);
        }

        string GetProssType(DateTime date)
        {
            if (date == null)
            {
                date = DateTime.Now;
            }
            return date.ToString("MMMM") + "-" + date.Year.ToString();
        }

        //[HttpGet]
        //public IActionResult GetBasic(int empId, DateTime dtInput)
        //{
        //    string comid = HttpContext.Session.GetString("comid");

        //    SqlParameter[] parameter = new SqlParameter[3];
        //    parameter[0] = new SqlParameter("@ComId", comid);
        //    parameter[1] = new SqlParameter("@EmpId", empId);
        //    parameter[2] = new SqlParameter("@dtInput", dtInput);
        //    var basic = Helper.ExecProcMapTList<Basic>("HR_prcGetBS", parameter);
        //    return Json(basic);
        //}

        public class Basic
        {
            public int BS { get; set; }
        }

        // GET: lvEncashment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            string comid = HttpContext.Session.GetString("comid");
            ViewBag.Title = "Edit";
            var lvEncashment = await db.HR_LvEncashment.FindAsync(id);

            ViewData["EmpId"] = new SelectList(db.HR_Emp_Info
             .Where(s => s.ComId == comid)
             .Select(s => new { Text = s.EmpName + " - [ " + s.EmpCode + " ]", Value = s.EmpId })
             .ToList(), "Value", "Text");

            if (lvEncashment == null)
            {
                return NotFound();
            }
            var elBalance = db.HR_Leave_Balance
              .Where(l => l.EmpId == lvEncashment.EmpId && l.DtOpeningBalance == lvEncashment.LvEncashmentIYear)
              .FirstOrDefault();

            if (elBalance != null)
            {
                if (lvEncashment.IsELEnjoy)// current and previous add
                {
                    lvEncashment.ELBalance = (lvEncashment.TotalDays * 2) + (int)elBalance.EL;
                }
                else
                {
                    lvEncashment.ELBalance = lvEncashment.TotalDays + (int)elBalance.EL;
                }

            }
            else
            {
                lvEncashment.ELBalance = 0;
            }

            return View("Create", lvEncashment);
        }

        // GET: lvEncashment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            string comid = HttpContext.Session.GetString("comid");
            var lvEncashment = await db.HR_LvEncashment
                .FirstOrDefaultAsync(m => m.LvEncashmentId == id);
            ViewData["EmpId"] = new SelectList(db.HR_Emp_Info
           .Where(s => s.ComId == comid)
           .Select(s => new { Text = s.EmpName + " - [ " + s.EmpCode + " ]", Value = s.EmpId })
           .ToList(), "Value", "Text");
            if (lvEncashment == null)
            {
                return NotFound();
            }
            var elBalance = db.HR_Leave_Balance
              .Where(l => l.EmpId == lvEncashment.EmpId && l.DtOpeningBalance == lvEncashment.LvEncashmentIYear)
              .FirstOrDefault();

            if (elBalance != null)
            {
                if (lvEncashment.IsELEnjoy)// current and previous add
                {
                    lvEncashment.ELBalance = (lvEncashment.TotalDays * 2) + (int)elBalance.EL;
                }
                else
                {
                    lvEncashment.ELBalance = lvEncashment.TotalDays + (int)elBalance.EL;
                }
            }
            else
            {
                lvEncashment.ELBalance = 0;
            }

            ViewBag.Title = "Delete";
            //ViewBag.DeptId = new SelectList(db.HR_LvEncashment, "DeptId", "DeptName", lvEncashment.ParentId);
            return View("Create", lvEncashment);
        }

        // POST: lvEncashment/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var lvEncashment = await db.HR_LvEncashment.FindAsync(id);
                var elBalance = db.HR_Leave_Balance
                    .Where(l => l.EmpId == lvEncashment.EmpId && l.DtOpeningBalance == lvEncashment.LvEncashmentIYear)
                    .FirstOrDefault();
                if (elBalance != null)
                {
                    if (lvEncashment.IsELEnjoy)// current and previous add
                    {
                        elBalance.EL = elBalance.EL + (lvEncashment.TotalDays * 2);
                    }
                    else
                    {
                        elBalance.EL = elBalance.EL + lvEncashment.TotalDays;
                    }
                }
                db.Entry(elBalance).State = EntityState.Modified;
                db.HR_LvEncashment.Remove(lvEncashment);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), lvEncashment.LvEncashmentId.ToString(), "Delete", lvEncashment.LvEncashmentId.ToString());

                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, LvEncashmentId = lvEncashment.LvEncashmentId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        [HttpGet]
        public IActionResult GetLeaveBalance(int empId, int year)
        {
            var data = db.HR_Leave_Balance
                .Where(l => l.EmpId == empId && l.DtOpeningBalance == year).FirstOrDefault();
            return Json(data);
        }




        private bool lvEncashmentExists(int id)
        {
            return db.HR_LvEncashment.Any(e => e.LvEncashmentId == id);
        }
    }
}