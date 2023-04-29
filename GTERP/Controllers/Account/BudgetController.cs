using DataTablesParser;
using GTERP.BLL;
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

namespace GTERP.Controllers.Account
{
    [OverridableAuthorize]
    public class BudgetController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext _context;
        //public CommercialRepository Repository { get; set; }
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();

        public BudgetController(GTRDBContext context, TransactionLogRepository tran)
        {
            _context = context;
            tranlog = tran;
            //Repository = rep;

        }


        // GET: BudgetMains
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            string comid = HttpContext.Session.GetString("comid");

            return View(await _context.BudgetMains.Take(1).Where(x => x.ComId == comid).Include(y => y.YearName).Include(m => m.MonthName).ToListAsync());
        }

        // GET: BudgetMains/Details/5
        public IActionResult BudgetDataLoadByParameter(int? Yearid, int? Monthid, int? ParentId)
        {
            try
            {
                var result = "";
                var comid = HttpContext.Session.GetString("comid");
                //var userid = HttpContext.Session.GetString("userid");
                if (comid == null)
                {
                    result = "Please Login first";
                }
                var quary = $"EXEC Acc_BudgetData '{comid}',{Yearid},'{Monthid}','{ParentId}' ";

                //EXEC[Acc_BudgetData] '31312c54-659b-4e63-b4ba-2bc3d7b05792',2,'14',10141


                SqlParameter[] parameters = new SqlParameter[4];

                parameters[0] = new SqlParameter("@ComId", comid);
                parameters[1] = new SqlParameter("@YearId", Yearid);
                parameters[2] = new SqlParameter("@MonthId", Monthid);
                parameters[3] = new SqlParameter("@ParentId", ParentId);

                List<Acc_BudgetData> Acc_BudgetData = Helper.ExecProcMapTList<Acc_BudgetData>("Acc_BudgetData", parameters);

                return Json(new { Acc_BudgetData, ex = result });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public ActionResult Print(int? id, string type)
        {
            string SqlCmd = "";
            string ReportPath = "";
            var ConstrName = "ApplicationServices";
            var ReportType = "PDF";
            var comid = HttpContext.Session.GetString("comid");


            //var abcvouchermain = db.PurchaseRequisitionMain.Where(x => x.PurReqId == id && x.ComId == comid).FirstOrDefault();

            var reportname = "rptCOA_Budget";

            ///@ComId nvarchar(200),@Type varchar(10),@ID int,@dtFrom smalldatetime,@dtTo smalldatetime
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Accounts/" + reportname + ".rdlc");
            //var str = db.Acc_VoucherMains.Include(x => x.Acc_VoucherType).FirstOrDefault().Acc_VoucherType.VoucherTypeNameShort;// "VPC";
            HttpContext.Session.SetString("reportquery", "Exec [Acc_rptCOA_Budget] '" + comid + "'," + id + " ");


            //Session["reportquery"] = "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.[rptCommercialInvoice_Export] '" + id + "','" + AppData.AppData.intComId + "'";
            string filename = _context.BudgetMains.Include(x => x.YearName).Where(x => x.BudgetMainId == id).Select(x => x.YearName.FYName).Single();
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

            //var a = Session["PrintFileName"].ToString();


            string DataSourceName = "DataSet1";
            HttpContext.Session.SetObject("rptList", postData);


            //Common.Classes.clsMain.intHasSubReport = 0;
            clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
            clsReport.strQueryMain = HttpContext.Session.GetString("reportquery");
            clsReport.strDSNMain = DataSourceName;




            SqlCmd = clsReport.strQueryMain;
            ReportPath = clsReport.strReportPathMain;
            ReportType = "PDF";

            /////////////////////// sub report test to our report server




            //var jsonData = JsonConvert.SerializeObject(subReportObject);

            //string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType });  //Repository.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType, jsonData);
            string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); // this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //Repository.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

            return Redirect(callBackUrl);

            ///return RedirectToAction("Index", "ReportViewer");


        }


        public class Acc_BudgetData
        {
            public int? BudgetMainId { get; set; }
            public int? BudgetDetailsId { get; set; }
            public int? FiscalYearId { get; set; }
            public int? FiscalMonthId { get; set; }

            public string Year { get; set; }
            public string Month { get; set; }
            public string ParentCode { get; set; }
            public string ParentName { get; set; }
            public string AccId { get; set; }
            public string AccCode { get; set; }
            public string AccName { get; set; }
            public string BudgetDebit { get; set; }
            public string BudgetCredit { get; set; }


        }
        [HttpPost]
        public IActionResult GetMonthByYear(int? FYId)
        {
            var Month = _context.Acc_FiscalMonths.Where(m => m.FYId == FYId).ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            if (Month != null)
            {
                foreach (var item in Month)
                {
                    items.Add(new SelectListItem { Value = item.FiscalMonthId.ToString(), Text = item.MonthName });
                }
            }
            return Json(new SelectList(items, "Value", "Text"));
        }



        // GET: BudgetMains/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            var comid = HttpContext.Session.GetString("comid");


            var lastBudgetMainsdata = _context.BudgetMains.Take(1).Where(x => x.ComId == comid).OrderByDescending(x => x.BudgetMainId).FirstOrDefault();
            if (lastBudgetMainsdata != null)
            {
                var sampleBudgetMainsdata = new BudgetMain();

                ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", lastBudgetMainsdata.FiscalYearId);
                ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths.Where(x => x.FYId == lastBudgetMainsdata.FiscalYearId), "FiscalMonthId", "MonthName", lastBudgetMainsdata.FiscalMonthId);
                ViewBag.ParentId = new SelectList(_context.Acc_ChartOfAccounts.Where(x => x.comid == comid && x.AccType == "G"), "AccId", "AccName");

                return View();
            }

            ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName");
            ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths, "FiscalMonthId", "MonthName");
            ViewBag.ParentId = new SelectList(_context.Acc_ChartOfAccounts.Where(x => x.comid == comid && x.AccType == "G"), "AccId", "AccName");

            return View();
        }


        // POST: BudgetMains/Create
        [HttpPost]
        public IActionResult Create(BudgetMain BudgetMains)
        {
            try
            {
                var message = "";
                var result = "";
                var comid = HttpContext.Session.GetString("comid");
                var userid = HttpContext.Session.GetString("userid");


                var BudgetMainId = _context.BudgetMains.Where(x => x.ComId == comid && x.FiscalYearId == BudgetMains.FiscalYearId).Select(x => x.BudgetMainId).FirstOrDefault();
                BudgetMains.BudgetMainId = BudgetMainId;

                if (BudgetMains.BudgetMainId > 0)
                {

                    foreach (var item in BudgetMains.BudgetDetails)
                    {


                        if (item.BudgetDetailsId > 0)
                        {

                            item.DateUpdated = DateTime.Now;
                            item.UpdateByUserId = HttpContext.Session.GetString("userid");

                            //_context.BudgetDetails.Attach(item);
                            //_context.Entry(item).Property(x => x.AccId).IsModified = true;
                            //_context.Entry(item).Property(x => x.BudgetDebit).IsModified = true;
                            //_context.Entry(item).Property(x => x.BudgetCredit).IsModified = true;
                            //_context.Entry(item).Property(x => x.DateUpdated).IsModified = true;
                            //_context.Entry(item).Property(x => x.UpdateByUserId).IsModified = true;
                            _context.Update(item);



                            _context.Entry(item).State = EntityState.Modified;


                            TempData["Message"] = "Data Update Successfully";
                            TempData["Status"] = "2";
                            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), item.BudgetMainId.ToString(), "Update", item.AccId + " " + item.BudgetMainId);

                            //_context.SaveChanges();
                        }
                        else
                        {



                            //_context.SaveChanges();

                            //_context.Update(BudgetMains);


                            _context.Add(item);
                            TempData["Message"] = "Data Save Successfully.";
                            TempData["Status"] = "1";
                            //tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), item.BudgetMainId.ToString(), "Save", item.DistId + " " + item.PStationId + " " + item.FiscalYearId + " " + item.FiscalMonthId);
                            //_context.SaveChanges();


                        }
                        _context.SaveChanges();
                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), item.BudgetMainId.ToString(), "Update", BudgetMains.FiscalYearId + " " + BudgetMains.FiscalMonthId);

                    }


                    var TotalDebitAmount = _context.BudgetDetails.Where(x => x.BudgetMainId == BudgetMainId).Sum(x => x.BudgetDebit);
                    var TotalCreditAmount = _context.BudgetDetails.Where(x => x.BudgetMainId == BudgetMainId).Sum(x => x.BudgetCredit);



                    BudgetMain abc = _context.BudgetMains.Where(x => x.BudgetMainId == BudgetMainId).FirstOrDefault();

                    abc.TotalBudgetDebit = TotalDebitAmount;
                    abc.TotalBudgetCredit = TotalCreditAmount;
                    abc.UpdateByUserId = userid;
                    abc.DateUpdated = DateTime.Now;


                    _context.BudgetMains.Attach(abc);
                    _context.Entry(abc).Property(x => x.TotalBudgetDebit).IsModified = true;
                    _context.Entry(abc).Property(x => x.TotalBudgetCredit).IsModified = true;
                    _context.Entry(abc).Property(x => x.DateUpdated).IsModified = true;
                    _context.Entry(abc).Property(x => x.UpdateByUserId).IsModified = true;

                    _context.SaveChanges();

                }
                else
                {
                    BudgetMains.UserId = userid;
                    BudgetMains.ComId = comid;
                    BudgetMains.DateAdded = DateTime.Now;


                    _context.BudgetMains.Add(BudgetMains);
                    _context.SaveChanges();

                }

                return Json(new { Success = 1, ex = TempData["Message"] });

            }
            catch (Exception ex)
            {

                //throw ex;
                return Json(new { Success = false, ex = ex });

            }

        }

        // GET: BudgetMains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var comid = HttpContext.Session.GetString("comid");

            var BudgetMains = await _context.BudgetMains
                .Include(y => y.YearName)
                .Include(m => m.MonthName)
                .Where(b => b.BudgetMainId == id).FirstOrDefaultAsync();
            if (BudgetMains == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.Where(y => y.FiscalYearId == BudgetMains.FiscalYearId), "FiscalYearId", "FYName", BudgetMains.FiscalYearId);
            ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths.Where(m => m.FiscalMonthId == BudgetMains.FiscalMonthId), "FiscalMonthId", "MonthName", BudgetMains.FiscalMonthId);
            ViewBag.ParentId = new SelectList(_context.Acc_ChartOfAccounts.Where(x => x.comid == comid && x.AccType == "G"), "AccId", "AccName");


            return View("Create", BudgetMains);
        }

        // POST: BudgetMains/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, BudgetDetails BudgetDetails)
        {
            if (id != BudgetDetails.BudgetDetailsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {


                    BudgetDetails.DateUpdated = DateTime.Now;
                    BudgetDetails.UpdateByUserId = HttpContext.Session.GetString("userid");

                    _context.BudgetDetails.Attach(BudgetDetails);
                    _context.Entry(BudgetDetails).Property(x => x.BudgetDebit).IsModified = true;
                    _context.Entry(BudgetDetails).Property(x => x.BudgetCredit).IsModified = true;
                    _context.Entry(BudgetDetails).Property(x => x.DateUpdated).IsModified = true;
                    _context.Entry(BudgetDetails).Property(x => x.UpdateByUserId).IsModified = true;

                    //_context.SaveChanges();




                    //_context.Update(BudgetMains);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BudgetMainsExists(BudgetDetails.BudgetDetailsId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(BudgetDetails);
        }

        // GET: BudgetMains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var BudgetMains = await _context.BudgetMains
                .Include(y => y.YearName)
                .Include(m => m.MonthName)
                .Where(b => b.BudgetMainId == id).FirstOrDefaultAsync();
            if (BudgetMains == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Delete";
            ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.Where(y => y.FiscalYearId == BudgetMains.FiscalYearId), "FiscalYearId", "FYName", BudgetMains.FiscalYearId);
            ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths.Where(m => m.FiscalMonthId == BudgetMains.FiscalMonthId), "FiscalMonthId", "MonthName", BudgetMains.FiscalMonthId);

            return View("Delete", BudgetMains);
        }

        // POST: BudgetMains/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var BudgetMains = await _context.BudgetMains.FindAsync(id);
            _context.BudgetMains.Remove(BudgetMains);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BudgetMainsExists(int id)
        {
            return _context.BudgetMains.Any(e => e.BudgetMainId == id);
        }




        public class BudgetMainsList
        {
            public int BudgetMainId { get; set; }
            public string Year { get; set; }
            public string Month { get; set; }
            public string TotalBudgetDebit { get; set; }
            public string TotalBudgetCredit { get; set; }
        }

        public IActionResult Get()
        {
            try
            {
                var comid = (HttpContext.Session.GetString("comid"));
                //var abc = db.Products.Include(y => y.vPrimaryCategory); Include(x=>x.DistrictWiseBudgetMains).Include(x=>x.YearName).Include(x=>x.MonthName).Include(x=>x.Cat_PoliceStation).Include(x=>x.Cat_District).
                var query = from e in _context.BudgetMains.Where(x => x.BudgetMainId > 0 && x.ComId == comid).OrderByDescending(x => x.BudgetMainId)
                            select new BudgetMainsList
                            {
                                BudgetMainId = e.BudgetMainId,
                                Year = e.YearName.FYName,
                                Month = e.MonthName.MonthName,
                                TotalBudgetDebit = e.TotalBudgetDebit.ToString(),
                                TotalBudgetCredit = e.TotalBudgetCredit.ToString(),
                            };



                var parser = new Parser<BudgetMainsList>(Request.Form, query);

                return Json(parser.Parse());

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
