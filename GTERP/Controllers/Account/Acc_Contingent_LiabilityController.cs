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

namespace GTERP.Controllers.Account
{
    [OverridableAuthorize]
    public class Acc_Contingent_LiabilityController : Controller
    {
        private TransactionLogRepository tranlog;

        //Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
        private GTRDBContext db;
        public clsProcedure clsProc { get; }
        //public CommercialRepository Repository { get; set; } ///for report service

        public Acc_Contingent_LiabilityController(GTRDBContext context, clsProcedure _clsProc, TransactionLogRepository tran)//for report service
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


            //var Acc_ChartOfAccount = db.Acc_ChartOfAccounts.Where(c => c.comid == comid && c.AccId > 0 && c.AccType == "L" && c.AccCode.Contains("2-3-13")); //&& c.ComId == (transactioncomid)
            //this.ViewBag.AccId = new SelectList(Acc_ChartOfAccount.Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text");



            List<Acc_Contingent_Liability> abcd = new List<Acc_Contingent_Liability>();

            if (FromDate == null || FromDate == "")
            {

                abcd = db.Acc_Contingent_Liabilities.Where(x => x.comid == comid).ToList();

            }
            else
            {
                dtFrom = Convert.ToDateTime(FromDate);

                abcd = db.Acc_Contingent_Liabilities.Where(x => x.comid == comid).ToList();



            }
            //if (ToDate == null || ToDate == "")
            //{
            //}
            //else
            //{
            //    dtTo = Convert.ToDateTime(ToDate);

            //}



            //return View(db.Acc_Contingent_Liabilities.Where(c => c.ContingentLiabilityId > 0).ToList());
            return View(abcd);

        }

        //[Authorize]
        // GET: Categories/Create
        public ActionResult Create()
        {
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");




            Acc_Contingent_Liability abc = new Acc_Contingent_Liability();


            var x = db.Acc_Contingent_Liabilities.Where(x => x.comid == comid).OrderByDescending(x => x.ContingentLiabilityId).FirstOrDefault();
            if (x != null)
            {
                ViewData["Criteria"] = new SelectList(CriteriaList, "Value", "Text");
                //var Acc_ChartOfAccount = db.Acc_ChartOfAccounts.Where(c => c.comid == comid && c.AccId > 0 && c.AccType == "L" && c.AccCode.Contains("2-3-13")); //&& c.ComId == (transactioncomid)
                ////this.ViewBag.AccId = new SelectList(Acc_ChartOfAccount.Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text", x.AccId);


                abc.FromDate = x.FromDate.AddYears(1);
                abc.ToDate = x.ToDate.AddYears(1);
                abc.Description = x.Description;



            }
            else
            {
                ViewData["Criteria"] = new SelectList(CriteriaList, "Value", "Text");
                //var Acc_ChartOfAccount = db.Acc_ChartOfAccounts.Where(c => c.comid == comid && c.AccId > 0 && c.AccType == "L" && c.AccCode.Contains("2-3-13")); //&& c.ComId == (transactioncomid)
                ////this.ViewBag.AccId = new SelectList(Acc_ChartOfAccount.Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text");

                abc.FromDate = DateTime.Now.Date;
                abc.ToDate = DateTime.Now.Date;

            }





            ViewBag.Title = "Create";

            return View(abc);
        }


        public static List<SelectListItem> CriteriaList = new List<SelectListItem>()
        {
            new SelectListItem() { Text="Add", Value="Add"},
            new SelectListItem() { Text="Less", Value="Less"},
        };

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Acc_Contingent_Liability Acc_ContingentLiabilityvar)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });

            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");

            //if (ModelState.IsValid)
            {
                if (Acc_ContingentLiabilityvar.ContingentLiabilityId > 0)
                {

                    if (Acc_ContingentLiabilityvar.comid == null || Acc_ContingentLiabilityvar.comid == "")
                    {
                        Acc_ContingentLiabilityvar.comid = comid;

                    }

                    Acc_ContingentLiabilityvar.DateUpdated = DateTime.Now;
                    Acc_ContingentLiabilityvar.useridUpdate = userid;
                    //Acc_ContingentLiabilityvar.isPost = true;


                    db.Entry(Acc_ContingentLiabilityvar).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {

                    Acc_ContingentLiabilityvar.DateAdded = DateTime.Now;
                    Acc_ContingentLiabilityvar.userid = userid;
                    Acc_ContingentLiabilityvar.comid = comid;
                    //Acc_ContingentLiabilityvar.isPost = true;



                    db.Acc_Contingent_Liabilities.Add(Acc_ContingentLiabilityvar);
                    db.SaveChanges();


                    //db.Entry(Acc_ContingentLiabilityvar).GetDatabaseValues();
                    //int id = Acc_Contingent_Liabilities.ContingentLiabilityId; // Yes it's here



                    //db.Categories.Add(Acc_Contingent_Liability);

                }
            }
            return RedirectToAction("Create");

            //return View(Acc_Contingent_Liability);
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
            Acc_Contingent_Liability Acc_Contingent_Liability = db.Acc_Contingent_Liabilities.Where(c => c.ContingentLiabilityId == id).FirstOrDefault();


            if (Acc_Contingent_Liability == null)
            {
                return NotFound();
            }

            //var Acc_ChartOfAccount = db.Acc_ChartOfAccounts.Where(c => c.comid == comid && c.AccId > 0 && c.AccType == "L" && c.AccCode.Contains("2-3-13")); //&& c.ComId == (transactioncomid)
            //this.ViewBag.AccId = new SelectList(Acc_ChartOfAccount.Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text");

            ViewBag.Title = "Edit";

            return View("Create", Acc_Contingent_Liability);

        }




        public JsonResult SetSessionAccountReport(string rptFormat, string FromDate, string ToDate, int? AccId)
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
                    reportname = "rptGovtEquitySchedule";
                    filename = "GovtEquitySchedule_" + DateTime.Now.Date;
                    query = "Exec Acc_rptGovtEquity_Schedule '" + comid + "', '" + FromDate + "' ,'" + ToDate + "' ,'" + AccId + "'  ";


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
                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat }); //this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat }); //Repository.GenerateReport(clsReport.strReportPathMain, clsReport.strQueryMain, ConstrName, rptFormat);
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
            Acc_Contingent_Liability Acc_Contingent_Liability = db.Acc_Contingent_Liabilities.Where(c => c.ContingentLiabilityId == id).FirstOrDefault();


            if (Acc_Contingent_Liability == null)
            {
                return NotFound();
            }
            //var Acc_ChartOfAccount = db.Acc_ChartOfAccounts.Where(c => c.comid == comid && c.AccId > 0 && c.AccType == "L" && c.AccCode.Contains("2-3-13")); //&& c.ComId == (transactioncomid)
            //this.ViewBag.AccId = new SelectList(Acc_ChartOfAccount.Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text");


            ViewBag.Title = "Delete";

            return View("Create", Acc_Contingent_Liability);
        }
        //        //[Authorize]
        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        //      [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int? id)
        {
            try
            {

                Acc_Contingent_Liability Acc_Contingent_Liability = db.Acc_Contingent_Liabilities.Where(c => c.ContingentLiabilityId == id).FirstOrDefault();

                db.Acc_Contingent_Liabilities.Remove(Acc_Contingent_Liability);
                db.SaveChanges();

                return Json(new { Success = 1, ContingentLiabilityId = Acc_Contingent_Liability.ContingentLiabilityId, ex = "" });

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
