using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static GTERP.Controllers.SalesController;

namespace GTERP.Controllers.Account
{
    [OverridableAuthorize]
    public class Acc_ShowVoucherController : Controller
    {
        private TransactionLogRepository tranlog;

        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
        //public CommercialRepository Repository { get; set; }
        private GTRDBContext db;
        POSRepository POS;
        public Acc_ShowVoucherController(GTRDBContext context, POSRepository _POS, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
            POS = _POS;
            //Repository = rep;
        }

        // GET: Section
        public ActionResult Report()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            string comid = HttpContext.Session.GetString("comid");
            int defaultcountry = (db.Companys.Where(a => a.CompanyCode == comid).Select(a => a.CountryId).FirstOrDefault());

            //if (Session["Empname"] == null)
            //{
            //    return RedirectToRoute("GTR");
            //}
            var date = DateTime.Now.ToString("dd-MMM-yyyy");
            var date1 = DateTime.Now.ToString("dd-MMM-yyyy");

            ViewBag.date = date;
            ViewBag.date1 = date1;

            ViewBag.CountryId = new SelectList(POS.GetCountry(), "CountryId", "CurrencyShortName", defaultcountry);
            ViewBag.VoucherTypeId = new SelectList(db.Acc_VoucherTypes, "VoucherTypeId", "VoucherTypeName").ToList();
            //ViewBag.AccId = new SelectList(POS.GetChartOfAccountLedger(comid), "AccId", "AccName").ToList();


            #region accid viewbag selectlist
            List<Acc_ChartOfAccount> acclistdb = POS.GetChartOfAccountLedger(comid).ToList();

            List<SelectListItem> accid = new List<SelectListItem>();
            accid.Add(new SelectListItem { Text = "=ALL=", Value = "0" });

            //licities.Add(new SelectListItem { Text = "--Select State--", Value = "0" });
            if (acclistdb != null)
            {
                foreach (Acc_ChartOfAccount x in acclistdb)
                {
                    accid.Add(new SelectListItem { Text = x.AccName, Value = x.AccId.ToString() });
                }
            }
            ViewBag.AccId = (accid);
            #endregion



            ViewBag.PrdUnitId = new SelectList(db.PrdUnits.Where(c => c.comid == comid), "PrdUnitId", "PrdUnitName"); //&& c.ComId == (transactioncomid)


            ShowVoucherViewModel model = new ShowVoucherViewModel();
            List<Acc_FiscalYear> fiscalyear = db.Acc_FiscalYears.Where(x => x.comid == comid).ToList();
            int fiscalyid = fiscalyear.Max(p => p.FYId);


            List<Acc_FiscalMonth> fiscalmonth = db.Acc_FiscalMonths.Where(x => x.FYId == fiscalyid).ToList();

            model.FiscalYs = fiscalyear;
            model.ProcessMonths = fiscalmonth;
            model.CountryId = defaultcountry;

            //DataSet dsList = new DataSet();
            //DataSet dsDetails = new DataSet();
            //Models.Accounts.ShowVoucher model = new Models.Accounts.ShowVoucher();
            //dsList = Models.Accounts.ShowVoucher.prcGetData();
            //dsDetails = Models.Accounts.ShowVoucher.prcGetAccList();

            //List<clsCommon.clsCombo2> Curr = clsGenerateList.prcColumnTwo(dsList.Tables[1]);
            //ViewBag.Currency = new SelectList(db.Countries.Where(x=>x.isActive == true), "CountryId", "CurrencyShortName"); ;

            //List<clsCommon.clsCombo3> AccType = clsGenerateList.prcColumnThree(dsDetails.Tables[0]);
            //ViewBag.AccountsType = AccType;



            //List<clsCommon.clsCombo2> Acc = clsGenerateList.prcColumnTwo(dsDetails.Tables[1]);

            //Models.Accounts.ShowVoucher.PrcSetData(model, "Create", dsList);
            return View(model);
        }


        //[ValidateAntiForgeryToken]
        public ActionResult PrintReport(int? id, string type)
        {
            try
            {

                return RedirectToAction("Index", "ReportViewer");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }


        [HttpPost, ActionName("SetSession")]
        ////[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        //[OverridableAuthorize]
        //[ValidateAntiForgeryToken]
        public ActionResult SetSession(string criteria, string rptFormat, string rpttype, string dtFrom, string dtTo,
            string VoucherFrom, string VoucherTo, int? Currency, int? isPosted, int? isOther, int? FYId, int? VoucherTypeId, int? AccId, int? PrdUnitId)
        {
            //data: { criteria: criteria, rptFormat: rptFormat, rpttype: rpttype,
            //dtFrom: dtFrom, dtTo: dtTo, VoucherFrom: VoucherFrom, VoucherTo: VoucherTo, Currency: Currency, isPosted: isPosted, isOther: isOther  },

            try
            {
                var ConstrName = "ApplicationServices";
                string comid = HttpContext.Session.GetString("comid");

                var VoucherTypeShortName = "";

                if (criteria == "fy")
                {
                    if (FYId != null || FYId.Value > 0)
                    {
                        Acc_FiscalYear fiscalyear = db.Acc_FiscalYears.Where(x => x.FYId == FYId).FirstOrDefault();
                        dtFrom = fiscalyear.OpDate;
                        dtTo = fiscalyear.ClDate;
                    }
                }


                if (VoucherTypeId != null || VoucherTypeId.Value >= 0)
                {
                    Acc_VoucherType Acc_VoucherType = db.Acc_VoucherTypes.Where(x => x.VoucherTypeId == VoucherTypeId).FirstOrDefault();
                    VoucherTypeShortName = Acc_VoucherType.VoucherTypeNameShort;

                }




                var abcvouchermain = db.Acc_VoucherTypes.Where(x => x.VoucherTypeId == VoucherTypeId).FirstOrDefault();

                var reportname = "rptShowVoucher";// db.Acc_VoucherMains.Where(x => x.VoucherId== id).Select(x => x.VoucherNo).FirstOrDefault();

                if (abcvouchermain != null)
                {
                    if (abcvouchermain.VoucherTypeName.ToUpper() == "Bank Payment".ToUpper())
                    {
                        reportname = "rptShowVoucher_VBP";
                    }
                    else if (abcvouchermain.VoucherTypeName.ToUpper() == "Journal".ToUpper())
                    {
                        reportname = "rptShowVoucher_Journal";

                    }
                    else if (abcvouchermain.VoucherTypeName.ToUpper() == "Bank Receipt".ToUpper())
                    {
                        reportname = "rptShowVoucher_MoneyReceipt";

                    }
                    else if (abcvouchermain.VoucherTypeName.ToUpper() == "Bank Payment".ToUpper())
                    {
                        reportname = "rptChk_janata";
                    }
                }


                //var reportname = "";
                //if (rpttype.ToUpper().ToString() == "iv".ToUpper())
                //{
                //    reportname = "rptShowVoucher";
                //}
                //else if (rpttype.ToUpper().ToString() == "lov".ToUpper())
                //{
                //    reportname = "rptListOfVoucher";
                //}





                string filename = "";
                string strQueryMain = "";
                if (criteria.ToUpper().ToString() == "No".ToUpper())
                {

                    filename = "VoucherNo_From_" + VoucherFrom + "_To_" + VoucherTo;// db.Acc_VoucherMains.Where(x => x.VoucherNo == VoucherFrom).Select(x => x.VoucherNo + "_" + x.Acc_VoucherType.VoucherTypeName).Single();



                    strQueryMain = "Exec Acc_rptVoucher '" + isPosted.ToString() + "','VNo','" + VoucherTypeShortName + "', '" + comid + "' , '" +
                        dtFrom + "','" + dtTo + "','" + VoucherFrom + "','" + VoucherTo + "',0, " + Currency + ", '" + AccId + "'";
                }
                else if (criteria.ToUpper().ToString() == "Date".ToUpper())
                {
                    filename = "Voucher_Date_" + dtFrom + "_To_" + dtTo;// db.Acc_VoucherMains.Where(x => x.VoucherNo == VoucherFrom).Select(x => x.VoucherNo + "_" + x.Acc_VoucherType.VoucherTypeName).Single();


                    strQueryMain = "Exec Acc_rptVoucher '" + isPosted.ToString() + "','VDATE','" + VoucherTypeShortName + "'  , '" + comid + "' ,'" +
                        dtFrom + "','" + dtTo + "','','',0, " + Currency + ", '" + AccId + "'";


                }
                else if (criteria.ToUpper().ToString() == "fy".ToUpper())
                {
                    filename = "Voucher_Date_" + dtFrom + "_To_" + dtTo;// db.Acc_VoucherMains.Where(x => x.VoucherNo == VoucherFrom).Select(x => x.VoucherNo + "_" + x.Acc_VoucherType.VoucherTypeName).Single();

                    strQueryMain = "Exec Acc_rptVoucher '" + isPosted.ToString() + "','VDATE','" + VoucherTypeShortName + "' , '" +
                        comid + "','" + dtFrom + "','" + dtTo + "','','',0, " + Currency + ", '" + AccId + "'";


                }




                var subReport = new SubReport();
                //var subReportObject = new List<SubReport>();

                subReport.strDSNSub = "DataSet1";
                subReport.strRFNSub = "VoucherId";
                subReport.strQuerySub = "Exec [rptShowVoucher_Referance] 'xxxx','" + comid + "','ChequeNo'";
                subReport.strRptPathSub = "rptShowVoucher_ChequeNo";
                //subReportObject.Add(subReport);
                postData.Add(2, subReport);



                subReport = new SubReport();
                subReport.strDSNSub = "DataSet1";
                subReport.strRFNSub = "VoucherId";
                subReport.strQuerySub = "Exec [rptShowVoucher_Referance] 'xxxx','" + comid + "','ReceiptPerson'";
                subReport.strRptPathSub = "rptShowVoucher_ReceiptPerson";
                //subReportObject.Add(subReport);
                postData.Add(3, subReport);

                //postData.Add(3, new subReport("rptInvoice_PM", "", "DataSet1", "Exec rptInvoice_PM '" + id + "','" + HttpContext.Session.GetString("comid") + ""));


                HttpContext.Session.SetObject("rptList", postData);










                string DataSourceName = "DataSet1";
                var ReportPath = "~/ReportViewer/Accounts/" + reportname + ".rdlc";
                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Accounts/" + reportname + ".rdlc");
                HttpContext.Session.SetString("reportquery", strQueryMain);
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("reportquery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat }); //Repository.GenerateReport(ReportPath, strQueryMain, ConstrName, rptFormat);

                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), "", reportname, "Report", reportname);

                return Json(callBackUrl);

                //return Redirect(callBackUrl);


                //string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat }); //Repository.GenerateReport(ReportPath, strQueryMain, ConstrName, rptFormat);



                //return Redirect(callBackUrl);

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return null;

        }
    }
}

//var vals = reportid.Split(',')[0];
// need change
///// redirectUrl = new UrlHelper(Request.RequestContext).Action("PrintReport", "ShowVoucher", new { id = 0 }); //, new { companyId = "7e96b930-a786-44dd-8576-052ce608e38f" }
//// var str = db.Acc_VoucherMains.FirstOrDefault().Acc_VoucherType.VoucherTypeNameShort;// "VPC";
//var Currency = "1";

// HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


// string DataSourceName = "DataSet1";
// HttpContext.Session.SetObject("rptList", postData);
//Session["rptList"] = postData;

//Common.Classes.clsMain.intHasSubReport = 0;
//clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
//clsReport.strQueryMain = HttpContext.Session.GetString("reportquery");
//clsReport.strDSNMain = DataSourceName;


//string redirectUrl = "";