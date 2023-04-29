using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GTERP.Controllers.Payroll
{
    [OverridableAuthorize]
    public class PF_LedgerController : Controller
    {
        private TransactionLogRepository tranlog;

        //Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
        private GTRDBContext db;
        public clsProcedure clsProc { get; }
        //public CommercialRepository Repository { get; set; } ///for report service

        public PF_LedgerController(GTRDBContext context, clsProcedure _clsProc, TransactionLogRepository tran)//for report service
        {

            db = context;
            // Repository = repository; ///for report service
            clsProc = _clsProc;
            tranlog = tran;
        }

        //[Authorize]
        // GET: Categories
        public ViewResult Index(string FromDate, string ToDate, string criteria)
        {

            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");

            DateTime dtFrom = Convert.ToDateTime(DateTime.Now.Date.ToString("dd-MMM-yy"));
            DateTime dtTo = Convert.ToDateTime(DateTime.Now.Date.ToString("dd-MMM-yy"));


            var BankAccountNo = db.BankAccountNos.Include(x => x.OpeningBanks).Where(c => c.comid == comid && c.BankAccountId > 0); //&& c.ComId == (transactioncomid)
            this.ViewBag.BankAccountId = new SelectList(BankAccountNo.Select(s => new { Text = s.BankAccountNumber + " - [ " + s.OpeningBanks.OpeningBankName + " ]", Value = s.BankAccountId }).ToList(), "Value", "Text");



            List<PF_Ledger> abcd = new List<PF_Ledger>();

            if (FromDate == null || FromDate == "")
            {

                abcd = db.PF_Ledgers.Include(x => x.vBankAccountNo).Where(x => x.comid == comid).ToList();

            }
            else
            {
                dtFrom = Convert.ToDateTime(FromDate);

                abcd = db.PF_Ledgers.Include(x => x.vBankAccountNo).Where(x => x.comid == comid).ToList();



            }

            return View(abcd);

        }

        //[Authorize]
        // GET: Categories/Create
        public ActionResult Create()
        {
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");

            PF_Ledger abc = new PF_Ledger();


            var x = db.PF_Ledgers.Where(x => x.comid == comid).OrderByDescending(x => x.PFLedgerId).FirstOrDefault();
            if (x != null)
            {
                ViewData["Criteria"] = new SelectList(CriteriaList, "Value", "Text");
                var BankAccountNo = db.BankAccountNos.Include(x => x.OpeningBanks).Where(c => c.comid == comid && c.BankAccountId > 0); //&& c.ComId == (transactioncomid)
                this.ViewBag.BankAccountId = new SelectList(BankAccountNo.Select(s => new { Text = s.BankAccountNumber + " - [ " + s.OpeningBanks.OpeningBankName + " ]", Value = s.BankAccountId }).ToList(), "Value", "Text", x.BankAccountId);

                abc.TranDate = x.TranDate.AddYears(1);
                abc.ReceivedTK = x.ReceivedTK;
                abc.PaymentTK = x.PaymentTK;
                abc.Balance = x.Balance;
                abc.Description = x.Description;
                abc.Remarks = x.Remarks;
                abc.ChequeNo = x.ChequeNo;
                abc.VoucherNo = x.VoucherNo;
                abc.BankAccountId = x.BankAccountId;




            }
            else
            {
                ViewData["Criteria"] = new SelectList(CriteriaList, "Value", "Text");
                var BankAccountNo = db.BankAccountNos.Include(x => x.OpeningBanks).Where(c => c.comid == comid && c.BankAccountId > 0); //&& c.ComId == (transactioncomid)
                this.ViewBag.BankAccountId = new SelectList(BankAccountNo.Select(s => new { Text = s.BankAccountNumber + " - [ " + s.OpeningBanks.OpeningBankName + " ]", Value = s.BankAccountId }).ToList(), "Value", "Text");

                abc.TranDate = DateTime.Now.Date;
            }





            ViewBag.Title = "Create";


            return View(abc);
        }


        public static List<SelectListItem> CriteriaList = new List<SelectListItem>()
        {
            new SelectListItem() { Text="Add", Value="Add"},
            new SelectListItem() { Text="Less", Value="Less"},
        };
        public static List<SelectListItem> AmountTypeList = new List<SelectListItem>()
        {
            new SelectListItem() { Text="Received", Value="Received"},
            new SelectListItem() { Text="Payment", Value="Payment"},
        };

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PF_Ledger PF_Ledger)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });

            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");

            //if (ModelState.IsValid)
            {
                if (PF_Ledger.PFLedgerId > 0)
                {

                    if (PF_Ledger.comid == null || PF_Ledger.comid == "")
                    {
                        PF_Ledger.comid = comid;

                    }

                    PF_Ledger.DateUpdated = DateTime.Now;
                    PF_Ledger.useridUpdate = userid;
                    //PF_Ledger.isPost = true;


                    db.Entry(PF_Ledger).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {

                    PF_Ledger.DateAdded = DateTime.Now;
                    PF_Ledger.userid = userid;
                    PF_Ledger.comid = comid;
                    //PF_Ledger.isPost = true;


                    db.PF_Ledgers.Add(PF_Ledger);
                    db.SaveChanges();


                    //db.Entry(PF_Ledger).GetDatabaseValues();
                    //int id = PF_Ledger.GovtScheduleId; // Yes it's here



                    //db.Categories.Add(PF_Ledger);

                }
            }
            return RedirectToAction("Create");

            //return View(PF_Ledger);
        }


        //[Authorize]
        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");
            if (id == null)
            {
                return BadRequest();
            }
            PF_Ledger PF_Ledger = db.PF_Ledgers.Where(c => c.PFLedgerId == id).FirstOrDefault();


            if (PF_Ledger == null)
            {
                return NotFound();
            }


            ViewData["Criteria"] = new SelectList(CriteriaList, "Value", "Text", PF_Ledger.Criteria);
            var BankAccountNo = db.BankAccountNos.Include(x => x.OpeningBanks).Where(c => c.comid == comid && c.BankAccountId > 0); //&& c.ComId == (transactioncomid)
            this.ViewBag.BankAccountId = new SelectList(BankAccountNo.Select(s => new { Text = s.BankAccountNumber + " - [ " + s.OpeningBanks.OpeningBankName + " ]", Value = s.BankAccountId }).ToList(), "Value", "Text");

            ViewBag.Title = "Edit";

            return View("Create", PF_Ledger);

        }




        public JsonResult SetSessionAccountReport(string rptFormat, string FromDate, string ToDate, int? BankAccId)
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

                    reportname = "rptPFBankAccountLedger";
                    filename = "rptPFBankAccountLedger_" + DateTime.Now.Date;
                    query = "Exec Payroll_rptBankAccountLedger '" + comid + "', '" + FromDate + "' ,'" + ToDate + "' ,'" + BankAccId + "' , 'PF Ledger'  ";


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



        //[Authorize]
        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");
            if (id == null)
            {
                return BadRequest();
            }
            PF_Ledger PF_Ledger = db.PF_Ledgers.Where(c => c.PFLedgerId == id).FirstOrDefault();


            if (PF_Ledger == null)
            {
                return NotFound();
            }

            ViewData["Criteria"] = new SelectList(CriteriaList, "Value", "Text", PF_Ledger.Criteria);
            var BankAccountNo = db.BankAccountNos.Include(x => x.OpeningBanks).Where(c => c.comid == comid && c.BankAccountId > 0); //&& c.ComId == (transactioncomid)
            this.ViewBag.BankAccountId = new SelectList(BankAccountNo.Select(s => new { Text = s.BankAccountNumber + " - [ " + s.OpeningBanks.OpeningBankName + " ]", Value = s.BankAccountId }).ToList(), "Value", "Text");


            ViewBag.Title = "Delete";

            return View("Create", PF_Ledger);
        }
        //        //[Authorize]
        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        //      [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int? id)
        {
            try
            {

                PF_Ledger PF_Ledger = db.PF_Ledgers.Where(c => c.PFLedgerId == id).FirstOrDefault();

                db.PF_Ledgers.Remove(PF_Ledger);
                db.SaveChanges();

                return Json(new { Success = 1, GovtScheduleId = PF_Ledger.PFLedgerId, ex = "" });

            }
            catch (Exception ex)
            {

                return Json(new { Success = 0, ex = ex.Message.ToString() });

            }



            //return RedirectToAction("Index");
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
