using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers.HR
{
    [OverridableAuthorize]
    public class LoanMotorCycleController : Controller
    {
        private GTRDBContext db;
        public LoanMotorCycleController(GTRDBContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var loanData = db.HR_Loan_MotorCycle
                .Include(x => x.HR_Emp_Info)
                .Include(x => x.HR_Emp_Info.Cat_Department)
                .Include(x => x.HR_Emp_Info.Cat_Section)
                .Include(x => x.HR_Emp_Info.Cat_Designation)
                .Where(x => x.ComId == HttpContext.Session.GetString("comid")).ToList();
            return View(loanData);
        }
        [HttpGet]
        public IActionResult Create()
        {
            string comid = HttpContext.Session.GetString("comid");
            ViewBag.Title = "Create";

            var empInfo = (from emp in db.HR_Emp_Info
                           join d in db.Cat_Department on emp.DeptId equals d.DeptId
                           join s in db.Cat_Section on emp.SectId equals s.SectId
                           join des in db.Cat_Designation on emp.DesigId equals des.DesigId
                           where emp.ComId == comid
                           select new
                           {
                               Value = emp.EmpId,
                               Text = emp.EmpCode + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                           }).ToList();

            ViewData["EmpId"] = new SelectList(empInfo, "Value", "Text");

            ViewBag.Compound = new SelectList(db.Cat_Variable
                .Where(v => v.ComId == comid && v.VarType == "LoanCompound")
                .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName");

            ViewBag.PayBack = new SelectList(db.Cat_Variable
               .Where(v => v.ComId == comid && v.VarType == "LoanPayBack")
               .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(HR_Loan_MotorCycle hR_Loan_MotorCycle, bool newCalculation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string comid = HttpContext.Session.GetString("comid");
                    string userid = HttpContext.Session.GetString("userid");
                    if (hR_Loan_MotorCycle.LoanMotorId > 0)
                    {
                        hR_Loan_MotorCycle.UpdateByUserId = comid;
                        hR_Loan_MotorCycle.DateUpdated = DateTime.Now.Date;
                        db.Entry(hR_Loan_MotorCycle).State = EntityState.Modified;
                        if (!newCalculation)
                        {
                            foreach (var item in hR_Loan_MotorCycle.HR_Loan_Data_MotorCycles)
                            {
                                //item.LoanMotorId = hR_Loan_MotorCycle.LoanMotorId;
                                db.Entry(item).State = EntityState.Modified;
                            }
                        }
                        else
                        {
                            var newData = new List<HR_Loan_Data_MotorCycle>();
                            foreach (var item in hR_Loan_MotorCycle.HR_Loan_Data_MotorCycles)
                            {
                                item.LoanMotorId = hR_Loan_MotorCycle.LoanMotorId;
                                newData.Add(item);
                            }
                            var exist = db.HR_Loan_Data_MotorCycle.Where(l => l.LoanMotorId == hR_Loan_MotorCycle.LoanMotorId).ToList();

                            if (exist.Count > 0)
                                db.RemoveRange(exist);

                            if (newData.Count > 0)
                                db.AddRange(newData);
                        }
                    }
                    else
                    {
                        var unPaidLoan = db.HR_Loan_Data_MotorCycle
                            .Where(l => l.EmpId == hR_Loan_MotorCycle.EmpId && l.IsPaid == false && l.ComId == comid)
                            .FirstOrDefault();

                        if (unPaidLoan != null)
                        {
                            TempData["Message"] = "This Employee has unpaide Loan";
                            return Json(new { Success = 2, ex = TempData["Message"].ToString() });
                        }
                        hR_Loan_MotorCycle.DtTran = DateTime.Now.Date;
                        db.Add(hR_Loan_MotorCycle);
                    }
                    db.SaveChanges();

                    TempData["Message"] = "Loan Save/Update Successfully";
                    return Json(new { Success = 1, ex = TempData["Message"].ToString() });
                }
                TempData["Message"] = "Some thing wrong, Check data";
                return Json(new { Success = 3, ex = TempData["Message"].ToString() });
            }
            catch (Exception e)
            {
                TempData["Message"] = "Please contact software authority";
                return Json(new { Success = 3, ex = TempData["Message"].ToString() });
            }

        }

        public IActionResult CalcualteLoanPartial(decimal lAmount, decimal interest, int period, DateTime startDate,
            decimal ttlLoanAmt, decimal ttlInterest, decimal monthlyLoanAmt, string loanType)
        {
            SqlParameter[] sqlParameter = new SqlParameter[8];
            sqlParameter[0] = new SqlParameter("@LoanAmount", lAmount);
            sqlParameter[1] = new SqlParameter("@InterestRate", interest);
            sqlParameter[2] = new SqlParameter("@LoanPeriod", period);
            sqlParameter[3] = new SqlParameter("@StartPaymentDate", startDate);
            sqlParameter[4] = new SqlParameter("@TotalLoanAmount", ttlLoanAmt);
            sqlParameter[5] = new SqlParameter("@TotalInterest", ttlInterest);
            sqlParameter[6] = new SqlParameter("@MonthlyLoan", monthlyLoanAmt);
            sqlParameter[7] = new SqlParameter("@LoanType", loanType);
            List<CalculateData> loanCal = Helper.ExecProcMapTList<CalculateData>("HR_LoanProcessMotorCycle", sqlParameter);
            var loanData = loanCal.Select(l => new
            {
                Period = l.PERIOD,
                DtLoanMonth = String.Format("{0:dd-MMM-yyyy}", l.PAYDATE),
                MonthlyLoanAmount = l.PAYMENT,
                InterestAmount = l.INTEREST,
                PrincipalAmount = l.PRINCIPAL,
                BeginningLoanBalance = l.BeginningBalance,
                EndingBalance = l.EndingBalance
            }).ToList();
            //ViewBag.LoanCalculation = loanData;
            //return PartialView("~/Views/LoanMotorCycle/_LoanMotorCycleGrid.cshtml", new HR_Loan_Data_MotorCycle());
            return Json(loanData);
        }

        [HttpGet]
        public IActionResult GetEmp(int id)
        {
            if (id == 0)
                return NotFound();

            var loandMaster = db.HR_Loan_MotorCycle
                .Include(l => l.HR_Emp_Info)
                .Include(l => l.HR_Emp_Info.Cat_Department)
                .Include(l => l.HR_Emp_Info.Cat_Designation)
                .Include(l => l.HR_Emp_Info.HR_Emp_Image)
                .Where(l => l.EmpId == id).FirstOrDefault();
            string comid = HttpContext.Session.GetString("comid");
            if (loandMaster != null)
            {
                ViewBag.Title = "Edit";

                ViewBag.EmpId = new SelectList(db.HR_Emp_Info
                    .Where(s => s.ComId == comid)
                    .Select(s => new { Text = s.EmpName + " - [ " + s.EmpCode + " ]", Value = s.EmpId })
                    .ToList(), "Value", "Text", loandMaster.EmpId);

                ViewBag.Compound = new SelectList(db.Cat_Variable
                    .Where(v => v.ComId == comid && v.VarType == "LoanCompound")
                    .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName", loandMaster.Compound);

                ViewBag.PayBack = new SelectList(db.Cat_Variable
                   .Where(v => v.ComId == comid && v.VarType == "LoanPayBack")
                   .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName", loandMaster.PayBack);

                ViewBag.LoanCalculation = db.HR_Loan_Data_MotorCycle
                    .Where(l => l.LoanMotorId == loandMaster.LoanMotorId).OrderBy(l => l.DtLoanMonth).ToList();

                return View("Create", loandMaster);
            }

            ViewBag.Title = "Create";
            HR_Loan_MotorCycle loan = new HR_Loan_MotorCycle();

            loan.HR_Emp_Info = db.HR_Emp_Info
                .Include(l => l.Cat_Department)
                .Include(l => l.Cat_Designation)
                .Include(l => l.HR_Emp_Image)
                .Where(l => l.EmpId == id).FirstOrDefault();

            ViewBag.EmpId = new SelectList(db.HR_Emp_Info
                    .Where(s => s.ComId == comid)
                    .Select(s => new { Text = s.EmpName + " - [ " + s.EmpCode + " ]", Value = s.EmpId })
                    .ToList(), "Value", "Text", id);

            ViewBag.Compound = new SelectList(db.Cat_Variable
                .Where(v => v.ComId == comid && v.VarType == "LoanCompound")
                .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName");

            ViewBag.PayBack = new SelectList(db.Cat_Variable
               .Where(v => v.ComId == comid && v.VarType == "LoanPayBack")
               .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName");

            return View("Create", loan);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
                return NotFound();

            var loandMaster = db.HR_Loan_MotorCycle
                .Include(l => l.HR_Emp_Info)
                .Include(l => l.HR_Emp_Info.Cat_Department)
                .Include(l => l.HR_Emp_Info.Cat_Designation)
                .Include(l => l.HR_Emp_Info.HR_Emp_Image)
                .Where(l => l.LoanMotorId == id).FirstOrDefault();
            string comid = HttpContext.Session.GetString("comid");
            if (loandMaster != null)
            {
                ViewBag.Title = "Edit";

                ViewBag.EmpId = new SelectList(db.HR_Emp_Info
                    .Where(s => s.ComId == comid)
                    .Select(s => new { Text = s.EmpName + " - [ " + s.EmpCode + " ]", Value = s.EmpId })
                    .ToList(), "Value", "Text", loandMaster.EmpId);

                ViewBag.Compound = new SelectList(db.Cat_Variable
                    .Where(v => v.ComId == comid && v.VarType == "LoanCompound")
                    .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName", loandMaster.Compound);

                ViewBag.PayBack = new SelectList(db.Cat_Variable
                   .Where(v => v.ComId == comid && v.VarType == "LoanPayBack")
                   .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName", loandMaster.PayBack);

                ViewBag.LoanCalculation = db.HR_Loan_Data_MotorCycle
                    .Where(l => l.LoanMotorId == id).OrderBy(l => l.DtLoanMonth).ToList();

                return View("Create", loandMaster);
            }

            ViewBag.Title = "Create";
            ViewBag.EmpId = new SelectList(db.HR_Emp_Info
                    .Where(s => s.ComId == comid)
                    .Select(s => new { Text = s.EmpName + " - [ " + s.EmpCode + " ]", Value = s.EmpId })
                    .ToList(), "Value", "Text");

            ViewBag.Compound = new SelectList(db.Cat_Variable
                .Where(v => v.ComId == comid && v.VarType == "LoanCompound")
                .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName");

            ViewBag.PayBack = new SelectList(db.Cat_Variable
               .Where(v => v.ComId == comid && v.VarType == "LoanPayBack")
               .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName");

            return View("Create", loandMaster);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            var loandMaster = db.HR_Loan_MotorCycle
                .Include(l => l.HR_Emp_Info)
                .Include(l => l.HR_Emp_Info.Cat_Department)
                .Include(l => l.HR_Emp_Info.Cat_Designation)
                .Include(l => l.HR_Emp_Info.HR_Emp_Image)
                .Where(l => l.LoanMotorId == id).FirstOrDefault();
            string comid = HttpContext.Session.GetString("comid");
            if (loandMaster != null)
            {
                ViewBag.Title = "Delete";

                ViewBag.EmpId = new SelectList(db.HR_Emp_Info
                    .Where(s => s.ComId == comid)
                    .Select(s => new { Text = s.EmpName + " - [ " + s.EmpCode + " ]", Value = s.EmpId })
                    .ToList(), "Value", "Text", loandMaster.EmpId);

                ViewBag.Compound = new SelectList(db.Cat_Variable
                    .Where(v => v.ComId == comid && v.VarType == "LoanCompound")
                    .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName", loandMaster.Compound);

                ViewBag.PayBack = new SelectList(db.Cat_Variable
                   .Where(v => v.ComId == comid && v.VarType == "LoanPayBack")
                   .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName", loandMaster.PayBack);

                ViewBag.LoanCalculation = db.HR_Loan_Data_MotorCycle
                    .Where(l => l.LoanMotorId == id).OrderBy(l => l.DtLoanMonth).ToList();

                return View("Create", loandMaster);
            }

            ViewBag.Title = "Create";
            ViewBag.EmpId = new SelectList(db.HR_Emp_Info
                    .Where(s => s.ComId == comid)
                    .Select(s => new { Text = s.EmpName + " - [ " + s.EmpCode + " ]", Value = s.EmpId })
                    .ToList(), "Value", "Text");

            ViewBag.Compound = new SelectList(db.Cat_Variable
                .Where(v => v.ComId == comid && v.VarType == "LoanCompound")
                .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName");

            ViewBag.PayBack = new SelectList(db.Cat_Variable
               .Where(v => v.ComId == comid && v.VarType == "LoanPayBack")
               .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName");

            return View("Create", loandMaster);
        }


        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            try
            {
                var detailsLoan = await db.HR_Loan_Data_MotorCycle.Where(l => l.LoanMotorId == id).ToListAsync();
                db.HR_Loan_Data_MotorCycle.RemoveRange(detailsLoan);
                var master = db.HR_Loan_MotorCycle.Where(l => l.LoanMotorId == id).FirstOrDefault();
                db.HR_Loan_MotorCycle.Remove(master);
                await db.SaveChangesAsync();
                TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, LoanMotorId = master.LoanMotorId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }


        public class CalculateData
        {
            public int PERIOD { get; set; }
            public DateTime PAYDATE { get; set; }
            public decimal PAYMENT { get; set; }
            public decimal CURRENT_BALANCE { get; set; }
            public decimal INTEREST { get; set; }
            public decimal PRINCIPAL { get; set; }
            public decimal BeginningBalance { get; set; }
            public decimal EndingBalance { get; set; }
        }
    }
}