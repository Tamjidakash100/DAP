using DataTablesParser;
using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static GTERP.Controllers.SalesController;

namespace GTERP.Controllers.Account
{
    [OverridableAuthorize]
    public class Acc_PostVoucherController : Controller
    {
        private TransactionLogRepository tranlog;
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
        private GTRDBContext db;
        //public CommercialRepository Repository { get; set; } ///for report service
        public Acc_PostVoucherController(GTRDBContext _db, TransactionLogRepository tran)
        {
            db = _db;
            // Repository = repository; ///for report service
            tranlog = tran;
        }


        // GET: Acc_VoucherMain
        public ViewResult Index(string FromDate, string ToDate, string criteria)
        {
            var transactioncomid = HttpContext.Session.GetString("comid");

            DateTime dtFrom = Convert.ToDateTime(DateTime.Now.Date.ToString("dd-MMM-yy"));
            DateTime dtTo = Convert.ToDateTime(DateTime.Now.Date.ToString("dd-MMM-yy"));
            if (criteria == null)
            {
                criteria = "UnPost";


            }




            if (FromDate == null || FromDate == "")
            {
            }
            else
            {
                dtFrom = Convert.ToDateTime(FromDate);

            }
            if (ToDate == null || ToDate == "")
            {
            }
            else
            {
                dtTo = Convert.ToDateTime(ToDate);

            }
            //ViewBag.Acc_VoucherNoPrefix = db.Acc_VoucherNoPrefixes.Include(x => x.vVoucherTypes).Where(x => x.isVisible == true && x.vVoucherTypes.isSystem == false).ToList();

            //transactioncomid = "1";
            //var a = ;
            // return View(db.Acc_VoucherMains.Where(p => p.ComId == transactioncomid).ToList());

            List<Acc_VoucherMain> modellist = new List<Acc_VoucherMain>();
            ViewBag.Title = criteria;

            if (criteria == "All")
            {
                modellist = db.Acc_VoucherMains.Include(x => x.Acc_VoucherType).Where(p => p.comid == transactioncomid && (p.VoucherDate >= dtFrom && p.VoucherDate <= dtTo)).ToList();
            }
            else if (criteria == "Post")
            {
                modellist = db.Acc_VoucherMains.Include(x => x.Acc_VoucherType).Where(p => p.comid == transactioncomid && (p.VoucherDate >= dtFrom && p.VoucherDate <= dtTo) && p.isPosted == true).ToList();

            }
            else if (criteria == "UnPost")
            {
                modellist = db.Acc_VoucherMains.Include(x => x.Acc_VoucherType).Where(p => p.comid == transactioncomid && (p.VoucherDate >= dtFrom && p.VoucherDate <= dtTo) && p.isPosted == false).ToList();

            }


            return View(modellist);
        }

        public class VoucherView
        {
            public int VoucherId { get; set; }
            public string VoucherNo { get; set; }
            public string VoucherTypeName { get; set; }
            public DateTime VoucherDate { get; set; }
            public string VoucherDesc { get; set; }
            public string Status { get; set; }
            public bool isPosted { get; set; }
            public string Comid { get; set; }

            public double VAmount { get; set; }

            public string VoucherTypeNameShort { get; set; }
        }


        public IActionResult Get(string FromDate, string ToDate, string criteria, int isAll)
        {
            try
            {
                var comid = (HttpContext.Session.GetString("comid"));

                DateTime dtFrom = Convert.ToDateTime(DateTime.Now.Date);
                DateTime dtTo = Convert.ToDateTime(DateTime.Now.Date);

                if (FromDate == null || FromDate == "")
                {
                }
                else
                {
                    dtFrom = Convert.ToDateTime(FromDate);

                }
                if (ToDate == null || ToDate == "")
                {
                }
                else
                {
                    dtTo = Convert.ToDateTime(ToDate);

                }

                Microsoft.Extensions.Primitives.StringValues y = "";

                var x = Request.Form.TryGetValue("search[value]", out y);

                //UserPermission permission = HttpContext.Session.GetObject<UserPermission>("userpermission");
                //var X = db.Acc_VoucherMains.Include(x => x.Acc_VoucherType).Where(p => p.comid == transactioncomid && (p.VoucherDate >= dtFrom && p.VoucherDate <= dtTo)).ToList();
                //return View(X);


                var query = from e in db.Acc_VoucherMains.Include(x => x.Acc_VoucherType)
                            select new VoucherView
                            {
                                VoucherId = e.VoucherId,
                                VoucherNo = e.VoucherNo,
                                VoucherDate = e.VoucherDate,
                                //VoucherDate = e.VoucherDate,
                                VoucherDesc = e.VoucherDesc,
                                VAmount = e.VAmount,
                                Comid = e.comid,
                                isPosted = e.isPosted,
                                VoucherTypeName = e.Acc_VoucherType.VoucherTypeName,
                                VoucherTypeNameShort = e.Acc_VoucherType.VoucherTypeNameShort,
                                //Status = e.isPosted.ToString() != "0" ? "Posted" : "Not Posted",
                                Status = e.isPosted != false ? "Posted" : "Not Posted"
                            };

                if (y.ToString().Length > 0)
                {
                    if (criteria == "Post")
                        query = query.Where(v => v.Comid == comid && v.isPosted == true);
                    else if (criteria == "UnPost")
                        query = query.Where(v => v.Comid == comid && v.isPosted == false);
                    else
                        query = query.Where(v => v.Comid == comid);

                    var parser = new Parser<VoucherView>(Request.Form, query);

                    return Json(parser.Parse());
                }
                else
                {
                    if (criteria == "Post")
                        query = query.Where(v => v.Comid == comid && v.VoucherDate >= dtFrom && v.VoucherDate <= dtTo && v.isPosted == true);
                    else if (criteria == "UnPost")
                        query = query.Where(v => v.Comid == comid && v.VoucherDate >= dtFrom && v.VoucherDate <= dtTo && v.isPosted == false);
                    else
                        query = query.Where(v => v.Comid == comid && v.VoucherDate >= dtFrom && v.VoucherDate <= dtTo);

                    var parser = new Parser<VoucherView>(Request.Form, query);

                    return Json(parser.Parse());
                }
            }
            catch (Exception ex)
            {
                return Json(new { Success = "0", error = ex.Message });
                //throw ex;
            }

        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(Acc_VoucherMain model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var values = prcSaveData(model);
        //            ViewBag["Message"] = values;
        //            if (values == "Data Posted Successfuly")
        //            {
        //                TempData["successmessage"] = values;
        //                return RedirectToAction("Index");
        //            }
        //            ViewBag.IsError = true;
        //            ModelState.AddModelError("CustomError", values);
        //            return View(model);
        //        }
        //        return View(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.IsError = true;
        //        ModelState.AddModelError("CustomError", ex.Message);
        //        return View(model);
        //    }
        //}
        public ActionResult Print(int? id, string type)
        {
            string SqlCmd = "";
            string ReportPath = "";
            var ConstrName = "ApplicationServices";
            var ReportType = "PDF";
            var comid = HttpContext.Session.GetString("comid");


            var abcvouchermain = db.Acc_VoucherMains.Include(x => x.Acc_VoucherType).Where(x => x.VoucherId == id && x.comid == comid).FirstOrDefault();

            var reportname = "rptShowVoucher";// db.Acc_VoucherMains.Where(x => x.VoucherId== id).Select(x => x.VoucherNo).FirstOrDefault();

            if (abcvouchermain.Acc_VoucherType != null)
            {
                if (abcvouchermain.Acc_VoucherType.VoucherTypeName.ToUpper() == "Bank Payment".ToUpper())
                {
                    reportname = "rptShowVoucher_VBP";
                }
                else if (abcvouchermain.Acc_VoucherType.VoucherTypeName.ToUpper() == "Journal".ToUpper())
                {
                    reportname = "rptShowVoucher_Journal";

                }
                else if (abcvouchermain.Acc_VoucherType.VoucherTypeName.ToUpper() == "Bank Receipt".ToUpper())
                {
                    reportname = "rptShowVoucher_MoneyReceipt";

                }
            }
            //if (reportname == null)
            //{
            //    reportname = "rptShowVoucher";
            //}

            //HttpContext.Session.SetString("PrintFileName",
            //int WarehouseCount = db.Acc_VoucherMains.Where(x => x.VoucherId == id).Count(); 
            //if (WarehouseCount > 0) { reportname = "rptShowVoucher_SubRpt"; }

            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Accounts/" + reportname + ".rdlc");
            var str = db.Acc_VoucherMains.Include(x => x.Acc_VoucherType).FirstOrDefault().Acc_VoucherType.VoucherTypeNameShort;// "VPC";
            var Currency = "1";
            HttpContext.Session.SetString("reportquery", "Exec Acc_rptVoucher 0, 'VID','All', '" + comid + "' , '01-Jan-1900', '01-Jan-1900', '" + str + "','" + str + "', " + id + ", " + Currency + ", 0");


            //Session["reportquery"] = "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.[rptCommercialInvoice_Export] '" + id + "','" + AppData.AppData.intComId + "'";
            string filename = db.Acc_VoucherMains.Where(x => x.VoucherId == id).Select(x => x.VoucherNo + "_" + x.Acc_VoucherType.VoucherTypeName).Single();
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

            //var a = Session["PrintFileName"].ToString();


            string DataSourceName = "DataSet1";
            //string FormCaption = "Report :: Sales Acknowledgement ...";


            //postData.Add(1, new subReport("rptInvoice_Terms", "", "DataSet1", "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.rptInvoice_Terms '" + id + "','" +HttpContext.Session.GetString("comid"); + "',''"));

            HttpContext.Session.SetObject("rptList", postData);


            //Common.Classes.clsMain.intHasSubReport = 0;
            clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
            clsReport.strQueryMain = HttpContext.Session.GetString("reportquery");
            clsReport.strDSNMain = DataSourceName;




            SqlCmd = clsReport.strQueryMain;
            ReportPath = clsReport.strReportPathMain;
            ReportType = "PDF";

            /////////////////////// sub report test to our report server


            var subReport = new SubReport();
            var subReportObject = new List<SubReport>();

            subReport.strDSNSub = "DataSet1";
            subReport.strRFNSub = "";
            subReport.strQuerySub = "Exec [rptShowVoucher_Referance] '" + id + "','" + comid + "','ChequeNo'";
            subReport.strRptPathSub = "rptShowVoucher_ChequeNo";
            subReportObject.Add(subReport);


            subReport = new SubReport();
            subReport.strDSNSub = "DataSet1";
            subReport.strRFNSub = "";
            subReport.strQuerySub = "Exec [rptShowVoucher_Referance] '" + id + "','" + comid + "','ReceiptPerson'";
            subReport.strRptPathSub = "rptShowVoucher_ReceiptPerson";
            subReportObject.Add(subReport);


            var jsonData = JsonConvert.SerializeObject(subReportObject);

            string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType });  //Repository.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType, jsonData);

            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), abcvouchermain.VoucherId.ToString(), "Report", reportname);

            return Redirect(callBackUrl);

            ///return RedirectToAction("Index", "ReportViewer");


        }


        public JsonResult SetProcess(string[] voucherid, string criteria)
        {
            if (criteria.ToUpper().ToString() == "Post".ToUpper())
            {
                if (voucherid.Count() > 0)
                {
                    for (var i = 0; i < voucherid.Count(); i++)
                    {
                        string voucheridsingle = voucherid[i];


                        var singlevoucher = db.Acc_VoucherMains.Where(x => x.VoucherId == Convert.ToInt32(voucheridsingle)).FirstOrDefault();

                        singlevoucher.isPosted = true;
                        db.Entry(singlevoucher).State = EntityState.Modified;
                        db.SaveChanges();

                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), "Data Post Successfully", singlevoucher.VoucherId.ToString(), criteria, singlevoucher.VoucherId.ToString());

                    }
                }
            }
            else
            {
                if (criteria.ToUpper().ToString() == "UnPost".ToUpper())
                {
                    if (voucherid.Count() > 0)
                    {
                        for (var i = 0; i < voucherid.Count(); i++)
                        {
                            string voucheridsingle = voucherid[i];


                            var singlevoucher = db.Acc_VoucherMains.Where(x => x.VoucherId == Convert.ToInt32(voucheridsingle)).FirstOrDefault();

                            singlevoucher.isPosted = false;
                            db.Entry(singlevoucher).State = EntityState.Modified;
                            db.SaveChanges();
                            //tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), singlevoucher.VoucherId.ToString(), criteria, singlevoucher.VoucherId.ToString());



                            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), "Data UnPost Successfully", singlevoucher.VoucherId.ToString(), criteria, singlevoucher.VoucherId.ToString());

                        }
                    }
                }
            }



            var data = "";
            return Json(data = "1");
        }
        public ActionResult create()
        {
            return View();
        }
        public string prcSaveData(Acc_VoucherMain model)
        {
            ArrayList arQuery = new ArrayList();

            try
            {
                var sqlQuery = "";
                // Count total Debit & Credit
                //foreach (var item in model.Collection)
                //{
                //    if (item.IsCheck == true)
                //    {
                //        sqlQuery = " Update tblAcc_Voucher_Main Set IsPosted = 1 ,LuserIdCheck = " + Session["Luserid"].ToString() + "   Where ComId = " + HttpContext.Session.GetString("comid").ToString() + " And VoucherId = " + (item.voucherid) + "";
                //        arQuery.Add(sqlQuery);
                //    }
                //}
                //clsCon.GTRSaveDataWithSQLCommand(arQuery);
                return "Data Posted Successfuly";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            finally
            {
                //clsCon = null;
            }
        }

    }
}