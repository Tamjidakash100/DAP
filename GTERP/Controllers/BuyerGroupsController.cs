using GTERP;
using GTERP.BLL;
using GTERP.Models;
using GTERP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static GTERP.Controllers.SalesController;

namespace GTCommercial.Controllers
{



    [OverridableAuthorize]
    //[AllowAnonymousWithPolicy("MyPolicy")]
    //[PermissionHandler("Admin")]
    public class BuyerGroupsController : Controller
    {
        //public CommercialRepository repos;
        private TransactionLogRepository TransactionLog;
        public GTRDBContext db;

        public WebHelper WebHelper { get; }

        //public object ob;


        public BuyerGroupsController(GTRDBContext context, TransactionLogRepository transactionLog, WebHelper webHelper)
        {
            db = context;
            //ob = context;
            //repos = repository;
            TransactionLog = transactionLog;
            WebHelper = webHelper;
        }
        //UserLog //UserLog;



        ////[Authorize]

        // GET: BuyerGroupsdb
        //  [OverridableAuthorize(typeof(object))]

        public ActionResult Index()
        {

            //HttpContext.Session.SetString("userid", "288c0006-7ff3-4997-ba27-c4be5d03d100");
            // HttpContext.Session.SetString("c", "288c0006-7ff3-4997-ba27-c4be5d03d100");
            #region Transaction Log

            TempData["Message"] = "Data Update Successfully";
            TempData["Status"] = "2";
            TransactionLog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "index", "");
            #endregion


            var data = db.BuyerGroups.ToList();
            return View(data);

        }

        public ActionResult testcallback()
        {
            Microsoft.Extensions.Primitives.StringValues originValues;
            Request.Headers.TryGetValue("Origin", out originValues);


            var callbackUrl = originValues;

            var redirectUrl = new Uri($"https://localhost:44330/Home/testResponse");
            var d = new req();
            d.OrderId = "OrderId_12345";
            d.Password = "Password_saasdf";
            string request = JsonConvert.SerializeObject(d);
            string response = WebHelper.Post(redirectUrl, request);
            return Ok();
        }
        class req
        {
            public int Id { get; set; }
            public string OrderId { get; set; }
            public string Password { get; set; }
        }
        public IActionResult GenerateReport()
        {

            //AppData.dbGTCommercial = db.Database.GetDbConnection().Database;
            ////Session["rptList"] = null;
            ///

            int id = 1;
            int comid = 4;
            var ReportPath = "CommercialReport/rptMasterLCSalesContact.rdlc";
            var SqlCmd = "Exec [rptMasterLCSalesContact] '" + id + "','" + comid + "'";
            var ConstrName = "ApplicationServices";
            var ReportType = "PDF";

            var subReport = new SubReport();
            var subReportObject = new List<SubReport>();

            subReport.strDSNSub = "DataSet1";
            subReport.strRFNSub = "";
            subReport.strQuerySub = "Exec [rptMasterLCSalesContact] '" + id + "','" + comid + "'";
            subReport.strRptPathSub = "CommercialReport/rptMasterLCSalesContact.rdlc";

            subReportObject.Add(subReport);


            var jsonData = JsonConvert.SerializeObject(subReportObject);

            var callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType,jsonData);

            return Redirect(callBackUrl);
        }


        //public JsonResult SetSession(string reporttype, string action , int? id)
        //{
        //    try
        //    {
        //        HttpContext.Session.SetString("userid", reporttype);

        //        string redirectUrl = "";

        //        if (action == "PrintBBLCOpen")
        //        {
        //            redirectUrl = new UrlHelper(Request.RequestContext).Action(action, "COM_BBLC_Master", new { id = id });
        //        }
        //        else
        //        {
        //            //var vals = reportid.Split(',')[0];
        //            redirectUrl = new UrlHelper(Request.RequestContext).Action(action, "COM_BBLC_Master", new { id = id });

        //        }
        //        return Json(new { Url = redirectUrl });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //    return Json(new { Success = 0, ex = new Exception("Unable to Delete").Message.ToString() });
        //}

        // GET: BuyerGroups/Create
        //  [OverridableAuthorize(typeof(object))]
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            return View();
        }

        [HttpPost]
        //[OverridableAuthorize]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(BuyerGroup BuyerGroup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var comid = HttpContext.Session.GetString("comid");

                    if (BuyerGroup.BuyerGroupId > 0)
                    {
                        ViewBag.Title = "Edit";
                        BuyerGroup.comid = comid;

                        db.Entry(BuyerGroup).State = EntityState.Modified;





                        db.SaveChanges();

                        #region Transaction Log

                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        TransactionLog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), BuyerGroup.BuyerGroupId.ToString(), "Update", BuyerGroup.BuyerGroupName.ToString());
                        #endregion


                    }
                    else
                    {
                        ViewBag.Title = "Create";

                        BuyerGroup.comid = comid;

                        db.BuyerGroups.Add(BuyerGroup);

                        db.SaveChanges();


                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        TransactionLog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), BuyerGroup.BuyerGroupId.ToString(), "Create", BuyerGroup.BuyerGroupName.ToString());




                    }
                }

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["Message"] = "Unable to Save / Update";
                BuyerGroup.BuyerGroupId = 0;
                TempData["Status"] = "0";

                return View(BuyerGroup);
                throw ex;
            }

        }



        // GET: BuyerGroups/Edit/5
        //[OverridableAuthorize]
        public ActionResult Edit(int? id)
        {
            ViewBag.Title = "Edit";
            if (id == null)
            {
                return BadRequest();
            }
            BuyerGroup BuyerGroup = db.BuyerGroups.Find(id);
            if (BuyerGroup == null)
            {
                return NotFound();
            }
            return View("Create", BuyerGroup);

        }



        // GET: BuyerGroups/Delete/5

        //[OverridableAuthorize]
        public ActionResult Delete(int? id)
        {
            ViewBag.Title = "Delete";
            if (id == null)
            {
                return BadRequest();
            }
            BuyerGroup BuyerGroup = db.BuyerGroups.Find(id);
            if (BuyerGroup == null)
            {
                return NotFound();
            }

            return View("Create", BuyerGroup);
        }

        // POST: BuyerGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        //[OverridableAuthorize]

        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                BuyerGroup BuyerGroup = db.BuyerGroups.Find(id);
                db.BuyerGroups.Remove(BuyerGroup);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "1";
                TransactionLog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), BuyerGroup.BuyerGroupId.ToString(), "Delete", BuyerGroup.BuyerGroupName);



                return Json(new { Success = 1, id = BuyerGroup.BuyerGroupId, ex = "Data Delete Successfully" });
            }
            catch (Exception ex)
            {

                TempData["Message"] = "Unable to Delete the Data.";
                TempData["Status"] = "3";

                return Json(new
                {
                    Success = 0,
                    ex = ex.Message.ToString()
                });

            }
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
