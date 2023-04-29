using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers.HouseKeeping
{
    [OverridableAuthorize]
    public class BudgetReleaseController : Controller
    {
        private readonly GTRDBContext db;
        private TransactionLogRepository tranlog;
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
        public clsProcedure clsProc { get; }
        //public CommercialRepository Repository { get; set; }

        public BudgetReleaseController(GTRDBContext gtrdb, TransactionLogRepository tran)
        {
            db = gtrdb;
            tranlog = tran;
            //Repository = rep;
        }

        // GET: BudgetReleaseSetup
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";

            string comid = HttpContext.Session.GetString("comid");
            string userid = HttpContext.Session.GetString("userid");

            //var fiscalYear = db.Acc_FiscalYears.Where(f => f.isRunning == true && f.isWorking == true).FirstOrDefault();
            //if (fiscalYear != null)
            //{
            //    var fiscalMonth = db.Acc_FiscalMonths.Where(f => f.OpeningdtFrom.Date <= DateTime.Now.Date && f.ClosingdtTo >= DateTime.Now.Date).FirstOrDefault();

            //    ViewBag.FiscalYearId = new SelectList(db.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", fiscalYear.FiscalYearId);
            //    ViewBag.FiscalMonthId = new SelectList(db.Acc_FiscalMonths.Where(x => x.FYId == fiscalYear.FYId).OrderByDescending(y => y.MonthName), "FiscalMonthId", "MonthName", fiscalMonth.FiscalMonthId);

            //}
            //else
            //{
            //    ViewBag.FiscalYearId = new SelectList(db.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName");
            //    ViewBag.FiscalMonthId = new SelectList(db.Acc_FiscalMonths.Where(x => x.FYId == fiscalYear.FiscalYearId).OrderByDescending(y => y.MonthName), "FiscalMonthId", "MonthName");
            //}


            ViewBag.FiscalYearId = new SelectList(db.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName");


            var filterAccount = db.Acc_ChartOfAccounts.Where(
                acc => db.Acc_BudgetRelease.Any(a => a.AccId == acc.AccId)
                && acc.comid == comid).Distinct();
            ViewBag.AccId = new SelectList(filterAccount.Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text");

            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            return View(await db.Acc_BudgetRelease.Include(b => b.Acc_FiscalYear).Include(b => b.Acc_FiscalMonth).Include(p => p.Acc_ChartOfAccount).Include(p => p.HR_Emp_Info).ToListAsync());
        }



        // GET: BudgetReleaseSetup/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";

            ViewData["PrdUnitId"] = new SelectList(db.PrdUnits, "PrdUnitId", "PrdUnitName");
            ViewData["ProductId"] = new SelectList(db.Products.Take(10), "ProductId", "ProductName");

            string comid = HttpContext.Session.GetString("comid");
            string userid = HttpContext.Session.GetString("userid");

            var fiscalYear = db.Acc_FiscalYears.Where(f => f.isRunning == true && f.isWorking == true).FirstOrDefault();
            if (fiscalYear != null)
            {
                var fiscalMonth = db.Acc_FiscalMonths.Where(f => f.OpeningdtFrom.Date <= DateTime.Now.Date && f.ClosingdtTo >= DateTime.Now.Date).FirstOrDefault();

                ViewBag.FiscalYearId = new SelectList(db.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", fiscalYear.FiscalYearId);
                ViewBag.FiscalMonthId = new SelectList(db.Acc_FiscalMonths.Where(x => x.FYId == fiscalYear.FYId).OrderByDescending(y => y.MonthName), "FiscalMonthId", "MonthName", fiscalMonth.FiscalMonthId);

            }
            else
            {
                ViewBag.FiscalYearId = new SelectList(db.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName");
                ViewBag.FiscalMonthId = new SelectList(db.Acc_FiscalMonths.Where(x => x.FYId == fiscalYear.FiscalYearId).OrderByDescending(y => y.MonthName), "FiscalMonthId", "MonthName");
            }



            var filterAccount = db.Acc_ChartOfAccounts.Where(
                acc => db.BudgetDetails
                    .Any(a => a.AccId == acc.AccId && (a.BudgetDebit + a.BudgetCredit) > 0 && a.BudgetMain.FiscalYearId == fiscalYear.FYId)
                && acc.comid == comid).Distinct();
            ViewBag.AccId = new SelectList(filterAccount.Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text");

            ViewBag.EmpId = new SelectList(db.HR_Emp_Info.Where(x => x.ComId == comid).Select(s => new { Text = s.EmpName + " - [ " + s.EmpCode + " ]", Value = s.EmpId }).ToList(), "Value", "Text");

            return View();
        }

        // POST: BudgetReleaseSetup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Acc_BudgetRelease budgetRelease)
        {
            if (ModelState.IsValid)
            {
                //var exist = await db.Acc_BudgetRelease
                //    .Where(p => p.BudgetReleaseId != budgetRelease.BudgetReleaseId
                //    && p.FiscalYearId == budgetRelease.FiscalYearId && p.FiscalMonthId==budgetRelease.FiscalMonthId && p.PrdUnitId == budgetRelease.PrdUnitId).FirstOrDefaultAsync();
                //if (exist != null)
                //{
                //    TempData["Message"] = "Data Already Exist";
                //    TempData["Status"] = "2";
                //    ViewBag.Title = "Edit";
                //    ViewData["PrdUnitId"] = new SelectList(db.PrdUnits, "PrdUnitId", "PrdUnitName", budgetRelease.PrdUnitId);
                //    ViewData["ProductId"] = new SelectList(db.Products.Take(10), "ProductId", "ProductName", budgetRelease.ProductId);

                //    ViewBag.FiscalYearId = new SelectList(db.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", budgetRelease.FiscalYearId);
                //    ViewBag.FiscalMonthId = new SelectList(db.Acc_FiscalMonths.OrderByDescending(y => y.MonthName), "FiscalMonthId", "MonthName", budgetRelease.FiscalMonthId);

                //    return View("Create", exist);
                //}
                //budgetRelease.UserId = HttpContext.Session.GetString("userid");
                //budgetRelease.ComId = HttpContext.Session.GetString("comid");

                //budgetRelease.PrdProwerMonth = (float)Math.Round((budgetRelease.PrdProwerYear / 12), 2);
                string userid = HttpContext.Session.GetString("userid");
                string comid = HttpContext.Session.GetString("comid");
                if (budgetRelease.BudgetReleaseId > 0)
                {
                    budgetRelease.DateUpdated = DateTime.Now;
                    budgetRelease.UserIdUpdated = userid;
                    db.Entry(budgetRelease).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), budgetRelease.BudgetReleaseId.ToString(), "Update", budgetRelease.BudgetReleaseId.ToString());

                }
                else
                {
                    budgetRelease.DateAdded = DateTime.Now;
                    budgetRelease.UserId = userid;
                    budgetRelease.ComId = comid;
                    db.Add(budgetRelease);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), budgetRelease.BudgetReleaseId.ToString(), "Create", budgetRelease.BudgetReleaseId.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(budgetRelease);
        }


        [HttpGet]
        public IActionResult GetFiscalMonth(int FiscalYearId)
        {
            string comid = HttpContext.Session.GetString("comid");
            var data = db.Acc_FiscalMonths.OrderByDescending(y => y.MonthName).Where(m => m.FYId == FiscalYearId).ToList();

            var filterAccount = db.Acc_ChartOfAccounts.Where(
                acc => db.BudgetDetails
                    .Any(a => a.AccId == acc.AccId && (a.BudgetDebit + a.BudgetCredit) > 0 && a.BudgetMain.FiscalYearId == FiscalYearId)
                && acc.comid == comid).Distinct();
            var accHead = filterAccount.Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList();


            return Json(new { Month = data, AccHead = accHead });
        }

        // GET: BudgetReleaseSetup/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            string comid = HttpContext.Session.GetString("comid");
            var budgetRelease = await db.Acc_BudgetRelease.FindAsync(id);

            ViewBag.FiscalYearId = new SelectList(db.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", budgetRelease.FiscalYearId);
            ViewBag.FiscalMonthId = new SelectList(db.Acc_FiscalMonths.OrderByDescending(y => y.MonthName), "FiscalMonthId", "MonthName", budgetRelease.FiscalMonthId);

            var filterAccount = db.Acc_ChartOfAccounts.Where(
                acc => db.BudgetDetails
                    .Any(a => a.AccId == acc.AccId && (a.BudgetDebit + a.BudgetCredit) > 0 && a.BudgetMain.FiscalYearId == budgetRelease.FiscalYearId)
                && acc.comid == comid).Distinct();
            ViewBag.AccId = new SelectList(filterAccount.Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text", budgetRelease.AccId);

            ViewBag.EmpId = new SelectList(db.HR_Emp_Info.Where(x => x.ComId == comid).Select(s => new { Text = s.EmpName + " - [ " + s.EmpCode + " ]", Value = s.EmpId }).ToList(), "Value", "Text", budgetRelease.EmpId);


            if (budgetRelease == null)
            {
                return NotFound();
            }
            return View("Create", budgetRelease);
        }

        // GET: BudgetReleaseSetup/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetRelease = await db.Acc_BudgetRelease

                .FirstOrDefaultAsync(m => m.BudgetReleaseId == id);

            if (budgetRelease == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";
            string comid = HttpContext.Session.GetString("comid");

            ViewBag.FiscalYearId = new SelectList(db.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", budgetRelease.FiscalYearId);
            ViewBag.FiscalMonthId = new SelectList(db.Acc_FiscalMonths.OrderByDescending(y => y.MonthName), "FiscalMonthId", "MonthName", budgetRelease.FiscalMonthId);

            var filterAccount = db.Acc_ChartOfAccounts.Where(
                acc => db.BudgetDetails
                    .Any(a => a.AccId == acc.AccId && (a.BudgetDebit + a.BudgetCredit) > 0 && a.BudgetMain.FiscalYearId == budgetRelease.FiscalYearId)
                && acc.comid == comid).Distinct();
            ViewBag.AccId = new SelectList(filterAccount.Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text", budgetRelease.AccId);

            ViewBag.EmpId = new SelectList(db.HR_Emp_Info.Where(x => x.ComId == comid).Select(s => new { Text = s.EmpName + " - [ " + s.EmpCode + " ]", Value = s.EmpId }).ToList(), "Value", "Text", budgetRelease.EmpId);

            return View("Create", budgetRelease);
        }

        // POST: BudgetReleaseSetup/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var budgetRelease = await db.Acc_BudgetRelease.FindAsync(id);
                db.Acc_BudgetRelease.Remove(budgetRelease);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), budgetRelease.BudgetReleaseId.ToString(), "Delete", budgetRelease.BudgetReleaseId.ToString());

                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, BudgetReleaseId = budgetRelease.BudgetReleaseId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }


        public IActionResult GetBalance(int AccId, int FiscalYearId, int BudgetReleaseId)
        {
            string comid = HttpContext.Session.GetString("comid");
            decimal balance = 0;
            var main = db.BudgetMains.Where(b => b.FiscalYearId == FiscalYearId && b.ComId == comid).FirstOrDefault();
            if (main != null)
            {
                var sub = db.BudgetDetails.Where(b => b.BudgetMainId == main.BudgetMainId && b.AccId == AccId).FirstOrDefault();
                balance = sub != null ? sub.BudgetDebit : 0;
            }

            double release = db.Acc_BudgetRelease.Where(r => r.BudgetReleaseId != BudgetReleaseId && r.AccId == AccId && r.FiscalYearId == FiscalYearId).Sum(r => r.DebitAmount);

            //balance = release != null ? balance - (decimal)release : balance;
            return Json(balance - (decimal)release);
        }


        public JsonResult SetSessionAccountReport(string rptFormat, string FiscalYearId, string AccId)
        {
            try
            {
                string comid = HttpContext.Session.GetString("comid");
                string userid = HttpContext.Session.GetString("userid");

                var reportname = "";
                var filename = "";
                string redirectUrl = "";
                string query = "";
                //return Json(new { Success = 1, TermsId = param, ex = "" });
                if (true)
                {
                    //redirectUrl = new UrlHelper(Request.RequestContext).Action(action, "COM_BBLC_Master", new { FromDate = FromDate, ToDate = ToDate, Supplierid = SupplierId, CommercialCompanyId = CommercialCompanyId }); //, new { companyId = "7e96b930-a786-44dd-8576-052ce608e38f" }
                    reportname = "rptBudgetRelease";
                    filename = "Notes_" + DateTime.Now.Date;
                    query = "Exec Acc_rptBudgetRelease '" + comid + "', '" + FiscalYearId + "' ,'" + AccId + "'";


                    HttpContext.Session.SetString("reportquery", query);
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Accounts/" + reportname + ".rdlc");
                }



                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


                string DataSourceName = "DataSet1";

                //HttpContext.Session.SetObject("Acc_rptList", postData);

                //Common.Classes.clsMain.intHasSubReport = 0;
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");// Session["ReportPath"].ToString();
                clsReport.strQueryMain = HttpContext.Session.GetString("reportquery");
                clsReport.strDSNMain = DataSourceName;

                var ConstrName = "ApplicationServices";
                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat }); //Repository.GenerateReport(clsReport.strReportPathMain, clsReport.strQueryMain, ConstrName, rptFormat);
                redirectUrl = callBackUrl;



                return Json(new { Url = redirectUrl });

            }

            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }

            return Json(new { Success = 0, ex = new Exception("Unable to Open").Message.ToString() });
            //return RedirectToAction("Index");

        }



        private bool BudgetReleaseSetupExists(int id)
        {
            return db.Acc_BudgetRelease.Any(e => e.BudgetReleaseId == id);
        }
    }
}