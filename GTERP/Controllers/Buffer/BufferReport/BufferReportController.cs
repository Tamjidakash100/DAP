using DataTablesParser;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2013.Word;
using DocumentFormat.OpenXml.Wordprocessing;
using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

//namespace GTERP.Controllers.HR
namespace GTERP.Controllers.Buffer.BufferReport
{

    public class BufferReportController : Controller
    {
        private readonly GTRDBContext db;
        private TransactionLogRepository tranlog;
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
        //public CommercialRepository Repository { get; set; }


        public BufferReportController(GTRDBContext context, TransactionLogRepository tran)
        {
            db = context;
            tranlog = tran;
            //Repository = rep;
        }
        public IActionResult Index()
        {
            var comid = (HttpContext.Session.GetString("comid"));
            ViewBag.GatePassId = new SelectList(db.GatePass, "GatePassId", "GatePassNo");
            //ViewData["DistId"] = new SelectList(db.Cat_District, "DistId", "DistName");
            ViewData["BufferListId"] = new SelectList(db.Buffers, "BufferListId", "BufferName");
            ViewBag.Year = new SelectList(db.Acc_FiscalYears.OrderByDescending(y => y.FiscalYearId), "FiscalYearId", "FYName");
            ViewBag.Month = new SelectList(db.Acc_FiscalMonths, "FiscalMonthId", "MonthName");
            ViewBag.DONo = new SelectList(db.DeliveryOrder, "DOId", "DONo");
            ViewBag.ChallanId = new SelectList(db.DeliveryChallan, "DOId", "DONo");

            //ViewBag.DONo = new SelectList(DOList, "DOId", "DONo");
            ViewBag.DOId = new SelectList(db.DeliveryChallan, "DeliveryChallanId", "DOId");
            ViewBag.BankName = new SelectList(db.Acc_ChartOfAccounts.Where(b => b.IsBankItem == true), "AccId", "AccName");
            //db.Buffers.Select(s=>s.BufferListId)

            return View();
        }

        public JsonResult GetMonth(int yearId)
        {
            var Month = db.Acc_FiscalMonths.Where(m => m.FYId == yearId).Select(m => new { m.MonthId, m.MonthName }).ToList();
            return Json(Month);
        }

        public JsonResult GetThana(int DistId)
        {
            var id = db.RepresentativeBuffers.Where(s => s.BufferListId == DistId).Select(x => x.BufferRepresentativeId).FirstOrDefault();
            var bufrep = db.BuferRepresentative.Where(x => x.BufferRepresentativeId == id).Select(x => x.RepresentativeName).ToList();
            var bufrepid = db.BuferRepresentative.Where(x => x.BufferRepresentativeId == id).Select(x => x.BufferRepresentativeId).ToList();
            var Thana = db.RepresentativeBuffers.Where(d => d.BufferListId == DistId).Select(t => new { bufrepid, bufrep }).ToList();
            return Json(Thana);
        }

        public IActionResult Report()
        {
            
            
            string comid = HttpContext.Session.GetString("comid");
            string userid = HttpContext.Session.GetString("userid");

            ViewBag.YearName = db.Acc_FiscalYears.Where(x => x.comid == comid).ToList();
            ViewBag.MonthName = db.Acc_FiscalMonths.Where(x => x.ComId == comid).Take(0).ToList();
            // ViewBag.DistName = db.Buffers.ToList();
            ViewBag.BufferName = db.Buffers.ToList();
            ViewBag.rep = db.BuferRepresentative.ToList();
            //ViewBag.BankName = db.Acc_ChartOfAccounts.Where(a => a.IsBankItem == true).ToList();
            ViewBag.rep = db.BuferRepresentative.ToList();
            var z = from s in db.Acc_ChartOfAccounts.Where(x => x.comid == comid && x.IsBankItem == true)
                    where db.DeliveryOrder.Any(es => (es.AccId == s.AccId))
                    select s;// new { s.AccId , s.AccName };

            List<Acc_ChartOfAccount> abc = z.ToList();
            ViewBag.OrderId = new SelectList(db.RepresentativeBooking, "RepresentativeBookingId", "OrderNo");

            ViewBag.BankName = abc;
            ViewBag.RepresentativeList = new SelectList(db.Representative.Where(r => r.comid == comid), "RepresentativeId", "RepresentativeName");

            var permission = db.ReportPermissions.Where(r => r.UserId == userid && r.ComId == comid).ToList();
            var reports = new List<HR_ReportType>();
            if (permission.Count > 0)
            {
                foreach (var item in permission)
                {
                    var report = db.HR_ReportType.Where(r => r.ReportType == "Buffer Report" && r.ReportId == item.ReportId).FirstOrDefault();
                    if (report != null)
                    {
                        reports.Add(report);
                    }

                }
                ViewBag.ReportName = reports; // db.HR_ReportType.Where(r=>r.ReportType == "Sales Report" && r.IsActive == true).OrderBy(x=>x.SLNo).ToList();
            }
            else
            {
                ViewBag.ReportName = db.HR_ReportType.Where(r => r.ReportType == "Buffer Report" && r.IsActive == true).OrderBy(x => x.SLNo).ToList();
            }

            ViewBag.DONo = new SelectList(db.DeliveryOrder, "DOId", "DONo");

            return View();
        }
       

        [HttpPost]
        public IActionResult Report(BufferReportGrid ReportData)
        {
            var ReportPath = db.HR_ReportType.FirstOrDefault(r => r.ReportType == "Buffer Report" && r.ReportName == ReportData.Report);
            string comid = HttpContext.Session.GetString("comid");
            var query = "";
            var reportname = "";
            var rptFormat = "";
            var filename = "";
            string redirectUrl = "";
            string DataSourceName = "DataSet1";
            ReportData.RepresentativeId = db.BuferRepresentative.Where(s => s.RepresentativeName==ReportData.Representative).Select(s => s.BufferRepresentativeId).FirstOrDefault();
            var ConstrName = "ApplicationServices";


            var monthId = db.Acc_FiscalMonths
          .Where(m => ReportData.FromDate >= m.OpeningdtFrom && ReportData.FromDate <= m.ClosingdtTo)
          .Select(m => m.MonthId)
          .FirstOrDefault();
            var FyId = db.Acc_FiscalMonths
           .Where(m => ReportData.FromDate >= m.OpeningdtFrom && ReportData.FromDate <= m.ClosingdtTo)
           .Select(m => m.FYId)
           .FirstOrDefault();





            int Jan = 0;
            int Feb = 0;
            int Mar = 0;
            int Apr = 0;
            int May = 0;
            int Jun = 0;
            int July = 0;
            int Aug = 0;
            int Sep = 0;
            int Oct = 0;
            int Nov = 0;
            int Dec = 0;



            if (ReportData.Year!=null && ReportData.Year != "0") {
                var fy = Int32.Parse(ReportData.Year);
                var names = db.Acc_FiscalMonths.Where(x => x.FYId == FyId).Select(x => x.MonthId).ToArray();
                var yearc = DateTime.Now.Year.ToString();

                Jan = names[0];
                Feb = names[1];
                Mar = names[2];
                Apr = names[3];
                May = names[4];
                Jun = names[5];
                July = names[6];
                Aug = names[7];
                Sep = names[8];
                Oct = names[9];
                Nov = names[10];
                Dec = names[11];
            }




           





            //var names = db.Acc_FiscalMonths.Where(x=>x.FYId== fy).Select(x => x.MonthId).ToArray();



            if (ReportData.Report == ReportPath.ReportName)
            {
                if (ReportData.Report== "Buffer List") {
                    query = $"Exec Buffer_rptAllReport '{comid}','{FyId}','{monthId}','{ReportData.FromDate}','{ReportData.ToDate}','{ReportData.Buffer}','{ReportData.RepresentativeId}','{ReportData.Report}','{ReportData.FromDONo}','{ReportData.ToDONo}' ";
                    HttpContext.Session.SetString("reportquery", query);

                }
               else if (ReportData.Report == "Challan Report")
                {
                    query = $"Exec Buffer_rptdafReport '{comid}','{FyId}','{monthId}','{ReportData.FromDate}','{ReportData.ToDate}','{ReportData.Buffer}','{ReportData.RepresentativeId}','{ReportData.Report}','{ReportData.FromDONo}','{ReportData.ToDONo}' ";
                    HttpContext.Session.SetString("reportquery", query);

                }
                

                    else if (ReportData.Report == "Integrated Report of Buffers")
                {


                    query = $"Exec Buffer_Report16production_Report'{comid}','{FyId}','{monthId}','{ReportData.Buffer}','{ReportData.FromDate}','{Jan}','{Feb}','{Mar}','{Apr}','{May}','{Jun}','{July}','{Aug}','{Sep}','{Oct}','{Nov}','{Dec}' ";
                    HttpContext.Session.SetString("reportquery", query);

                }
                else if (ReportData.Report == "Inventory Register")
                {
                    query = $"Exec Buffer_inventory_register '{comid}','{FyId}','{monthId}','{ReportData.Buffer}','{ReportData.Report}'";
                    HttpContext.Session.SetString("reportquery", query);

                }

                else if (ReportData.Report == "Total Monthly Supply Report")
                {
                    query = $"Exec Buffer_Monthly_wise_daily'{comid}','{FyId}','{monthId}','{ReportData.Buffer}','{ReportData.Report}','{Jan}','{Feb}','{Mar}','{Apr}','{May}','{Jun}','{July}','{Aug}','{Sep}','{Oct}','{Nov}','{Dec}' ";
                    HttpContext.Session.SetString("reportquery", query);

                }
                else if (ReportData.Report == "Daily Basis Monthly DAP Fertilizer Buffer Supply Report")
                {
                    query = $"Exec Buffer_rptDailyBasisMonthlyDAPFertilizerBufferSupplyReport'{comid}','{FyId}','{monthId}','{ReportData.FromDate}','{ReportData.ToDate}','{ReportData.Buffer}','{ReportData.RepresentativeId}','{ReportData.Report}','{ReportData.FromDONo}','{ReportData.ToDONo}' ";
                    HttpContext.Session.SetString("reportquery", query);

                }
                else if (ReportData.Report == "TaliSheet Commercial Division Marketing Section")
                {
                    query = $"Exec Buffer_rptTaliSheetDapAllReport'{comid}','{FyId}','{monthId}','{ReportData.FromDate}','{ReportData.ToDate}','{ReportData.Buffer}','{ReportData.RepresentativeId}','{ReportData.Report}','{ReportData.FromDONo}','{ReportData.ToDONo}' ";
                    HttpContext.Session.SetString("reportquery", query);

                }
                else if (ReportData.Report == "Name of Buffers")
                {
                    query = $"Exec Name_of_Buffers'{comid}','{FyId}','{monthId}','{ReportData.FromDate}','{ReportData.ToDate}','{ReportData.Buffer}','{ReportData.RepresentativeId}','{ReportData.Report}','{ReportData.FromDONo}','{ReportData.ToDONo}' ";
                    HttpContext.Session.SetString("reportquery", query);

                }
                else if (ReportData.Report == "Supply To Buffer(Month)")
                {
                    
                    query = $"Exec Buffer_Sells_statement_Final'{comid}','{FyId}','{monthId}','{ReportData.Buffer}','{ReportData.Report}','{Jan}','{Feb}','{Mar}','{Apr}','{May}','{Jun}','{July}','{Aug}','{Sep}','{Oct}','{Nov}','{Dec}' ";
                    HttpContext.Session.SetString("reportquery", query);

                }
                else if (ReportData.Report == "Daily Production & Stocked Report")
                {

                    query = $"Exec Buffer_Report16production_Report'{comid}','{FyId}','{monthId}','{ReportData.Buffer}','{ReportData.Report}','{Jan}','{Feb}','{Mar}','{Apr}','{May}','{Jun}','{July}','{Aug}','{Sep}','{Oct}','{Nov}','{Dec}' ";
                    HttpContext.Session.SetString("reportquery", query);

                }
                //Buffer_Report16production_Report
                else if (ReportData.Report == "Buffer Sales Statement(Amount) ")
                {
                    query = $"Exec Buffer_Sales_Statement_in_Amount'{comid}','{FyId}','{monthId}','{ReportData.FromDate}','{ReportData.ToDate}','{ReportData.Buffer}','{ReportData.RepresentativeId}','{ReportData.Report}','{ReportData.FromDONo}','{ReportData.ToDONo}' ";
                    HttpContext.Session.SetString("reportquery", query);

                }
                else if (ReportData.Report == "Buffer Sales Statement(MIS)")
                {
                  

                    query = $"Exec Buffer_Sells_statement_Final'{comid}','{FyId}','{monthId}','{ReportData.Buffer}','{ReportData.Report}','{Jan}','{Feb}','{Mar}','{Apr}','{May}','{Jun}','{July}','{Aug}','{Sep}','{Oct}','{Nov}','{Dec}' ";
                    HttpContext.Session.SetString("reportquery", query);

                }

                else if (ReportData.Report == "All Buffer Allotment")
                {

                    //List<> ts= new List<> ();
                    query = $"Exec Buffer_Sells_statement_Final'{comid}','{FyId}','{monthId}','{ReportData.Buffer}','{ReportData.Report}','{Jan}','{Feb}','{Mar}','{Apr}','{May}','{Jun}','{July}','{Aug}','{Sep}','{Oct}','{Nov}','{Dec}' ";
                    HttpContext.Session.SetString("reportquery", query);
                    

                }
                else if (ReportData.Report == "Receive from Buffer(Bank Amount)")
                {

                    //List<> ts= new List<> ();

                    query = $"Exec Buffer_Receivefrom_buffer_Bank_Ammount'{comid}','{FyId}','{monthId}','{ReportData.Buffer}','{ReportData.Report}','{Jan}','{Feb}','{Mar}','{Apr}','{May}','{Jun}','{July}','{Aug}','{Sep}','{Oct}','{Nov}','{Dec}' ";
                    HttpContext.Session.SetString("reportquery", query);

                }




                else if (ReportData.Report == "DAP Fertilizer Fill Truck GatePass")
                {
                    query = $"Exec Buffer_DAPFertilizerFillTruckGatePass'{comid}','{FyId}','{monthId}','{ReportData.FromDate}','{ReportData.ToDate}','{ReportData.Buffer}','{ReportData.RepresentativeId}','{ReportData.Report}','{ReportData.FromDONo}','{ReportData.ToDONo}' ";
                    HttpContext.Session.SetString("reportquery", query);

                }
                //Daily DAP Fertilizer Buffer
                else if (ReportData.Report == "Buffer Sales Statement(Quantity) ")
                {
                    //--Exec Buffer_Sales_Statement_in_Quantity'31312C54-659B-4E63-B4BA-2BC3D7B05792','4','37','48','15-Jan-2023','0','0','Buffer Sales Statement(Quantity) ','',''

                    query = $"Exec Buffer_Sales_Statement_in_Quantity'{comid}','{FyId}','{monthId}','{Dec}','{ReportData.ToDate}','{ReportData.Buffer}','{ReportData.RepresentativeId}','{ReportData.Report}','{ReportData.FromDONo}','{ReportData.ToDONo}' ";
                    HttpContext.Session.SetString("reportquery", query);

                }
                else if (ReportData.Report == "Daily Allotment wise report(Details)")
                {
                    query = $"Exec Buffer_DailyDAPFertilizerBuffer'{comid}','{FyId}','{monthId}','{ReportData.FromDate}','{ReportData.ToDate}','{ReportData.Buffer}','{ReportData.RepresentativeId}','{ReportData.Report}','{ReportData.FromDONo}','{ReportData.OdNum}' ";
                    HttpContext.Session.SetString("reportquery", query);

                }
                else if (ReportData.Report == "Daily Allotment wise report")
                {
                    query = $"Exec Buffer_DailyDAPFertilizerBuffer'{comid}','{FyId}','{monthId}','{ReportData.FromDate}','{ReportData.ToDate}','{ReportData.Buffer}','{ReportData.RepresentativeId}','{ReportData.Report}','{ReportData.FromDONo}','{ReportData.OdNum}' ";
                    HttpContext.Session.SetString("reportquery", query);

                }
                else if (ReportData.Report == "Integrated Allocationwise Daily Basis DAP Fertilizer Buffer Supply Report")
                {
                    

                    query = $"Exec Buffer_IntegratedSeasonWiseMonthlyFertilizerSupplyReport'{comid}','{FyId}','{monthId}','{ReportData.Buffer}','{ReportData.Report}','{Jan}','{Feb}','{Mar}','{Apr}' ";
                    HttpContext.Session.SetString("reportquery", query);

                }
                else if (ReportData.Report == "Daily Production & Stocked Report")
                {


                    query = $"Exec Buffer_IntegratedSeasonWiseMonthlyFertilizerSupplyReport'{comid}','{FyId}','{monthId}','{ReportData.Buffer}','{ReportData.Report}','{Jan}','{Feb}','{Mar}','{Apr}'";
                    HttpContext.Session.SetString("reportquery", query);

                }

            }
            else
            {

            }
            reportname = ReportPath.ReportPath;
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/" + reportname);
            filename = "'" + ReportData.Report + "' List_" + DateTime.Now.Date.ToString();
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
            clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
            clsReport.strQueryMain = HttpContext.Session.GetString("reportquery");
            clsReport.strDSNMain = DataSourceName;

            //string callBackUrl = Repository.GenerateReport(clsReport.strReportPathMain, clsReport.strQueryMain, ConstrName, ReportData.ReportFormat);
            string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat });
            redirectUrl = callBackUrl;
            return Redirect(redirectUrl);
        }

        public class BufferReportGrid
        {
            public int Id { get; set; }
            public DateTime FromDate { get; set; }
            public string ToDate { get; set; }
            public string Year { get; set; }
            public string Month { get; set; }
            public string Buffer { get; set; }
            public string Representative { get; set; }
            public string Thana { get; set; }
            public string Bank { get; set; }
            
            //public string Buffer { get; set; }
            //public string Representative { get; set; }
            
            public int RepresentativeId { get; set; }
            public string FromDONo { get; set; }
            public string ToDONo { get; set; }
            public string OdNum { get; set; }
            public string Report { get; set; }
            public string ReportFormat { get; set; }
        }

        public IActionResult DistrictWiseDailySalesReport(string FiscalYearId, string MonthNameId)
        {

            var comid = (HttpContext.Session.GetString("comid"));

            List<BufferWiseDailySalesVM> DistrictWiseDailySales = new List<BufferWiseDailySalesVM>();

            var query = from e in db.DeliveryOrder.Where(d => d.ComId == comid)
                        select new BufferWiseDailySalesVM
                        {
                            DOId = e.DOId,
                            DeliveryNumber = e.DONo,
                            DODate = e.DODate,
                            DistrictName = e.Booking.Cat_District.DistName,
                            Quantity = e.Qty,
                            TotalPrice = (float)e.TotalPrice
                        };
            var totalqty = query.Sum(q => q.Quantity);
            query.ToList();
            //foreach (var item in query)
            //{
            //    DistrictWiseDailySales.Add(item);
            //}

            ViewBag.FiscalYearId = new SelectList(db.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", FiscalYearId);
            ViewBag.MonthNameId = new SelectList(db.MonthNames, "MonthNameId", "ShortName", MonthNameId);
            ViewData["DistId"] = new SelectList(db.Cat_District, "DistId", "DistName");

            return View(DistrictWiseDailySales);
        }

        public class
            BufferWiseDailySalesVM
        {
            public int DOId { get; set; }
            public int DeliveryNumber { get; set; }
            public DateTime DODate { get; set; }
            public string DistrictName { get; set; }
            public float Quantity { get; set; }
            public float TotalPrice { get; set; }
        }

        [HttpPost, ActionName("BufferReport")]
        public JsonResult BufferReport(string rptFormat, string action, string DistrictId, string FromDate, string ToDate, string MonthId, string YearId, int? FromDOId, int? ToDOId, string Bank, int? GatePassId, int? DONo, int? BookingMonthId, string ReceiverPerson, string Type, string FromNo, string ToNo, int? RepresentativeId)
        {
            try
            {
                string comid = HttpContext.Session.GetString("comid");

                var reportname = "";
                var filename = "";
                string redirectUrl = "";
                if (action == "PrintDistrictWiseDailySalse")
                {
                    reportname = "rptDistrictWiseDailySales";
                    filename = "rptDistrictWiseDailySales_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec Sales_rptGetDistrictWiseDailySaleReport '" + comid + "','" + DistrictId + "','" + FromDate + "','" + ToDate + "' ";
                    HttpContext.Session.SetString("reportquery", "Exec Sales_rptGetDistrictWiseDailySaleReport '" + comid + "','" + DistrictId + "','" + FromDate + "','" + ToDate + "' ");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (action == "PrintDeliveryOrderDateWiseReport")
                {
                    reportname = "rptDeliveryOrderDateWise";
                    filename = "rptDeliveryOrderDateWiseSales_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec Sales_rptDeliveryOrderDateWiseReport '" + comid + "','" + FromDate + "','" + ToDate + "' ";
                    HttpContext.Session.SetString("reportquery", "Exec Sales_rptDeliveryOrderDateWiseReport '" + comid + "','" + FromDate + "','" + ToDate + "' ");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (action == "PrintDeliveryOrderNumberWiseReport")
                {
                    reportname = "rptDeliveryOrderNumberWiseReport";
                    filename = "rptDeliveryOrderNumberWiseReport_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec Sales_rptDeliveryOrderNumberWiseReport '" + comid + "','" + FromDOId + "','" + ToDOId + "' ";
                    HttpContext.Session.SetString("reportquery", "Exec Sales_rptDeliveryOrderNumberWiseReport '" + comid + "','" + FromDOId + "','" + ToDOId + "' ");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (action == "PrintBankDipositrDateWiseReport")
                {
                    reportname = "rptBankDipositDateWiseReport";
                    filename = "rptBankDipositDateWiseReport_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec Sales_rptBankDipositDateWiseReport '" + comid + "','" + FromDate + "','" + ToDate + "','" + Bank + "' ";
                    HttpContext.Session.SetString("reportquery", "Exec Sales_rptBankDipositDateWiseReport '" + comid + "','" + FromDate + "','" + ToDate + "','" + Bank + "' ");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (action == "PrintDeliveryOrderNumberWiseReport")
                {
                    reportname = "rptDeliveryOrderNumberWiseReport";
                    filename = "rptDeliveryOrderNumberWiseReport_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec Sales_rptDeliveryOrderNumberWiseReport '" + comid + "','" + YearId + "' ";
                    HttpContext.Session.SetString("reportquery", "Exec Sales_rptDeliveryOrderNumberWiseReport '" + comid + "','" + YearId + "' ");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (action == "PrintDailyDateWiseSalesSummaryReport")
                {
                    reportname = "rptDailyDateWiseSalesSummaryReport";
                    filename = "rptDailyDateWiseSalesSummaryReport_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec Sales_rptDailyDateWiseSalesSummaryReport '" + comid + "','" + FromDate + "','" + ToDate + "' ";
                    HttpContext.Session.SetString("reportquery", "Exec Sales_rptDailyDateWiseSalesSummaryReport '" + comid + "','" + FromDate + "','" + ToDate + "' ");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (action == "PrintAnnualSalesReport")
                {
                    reportname = "rptAnnualSalesReport";
                    filename = "rptAnnualSalesReport_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec Sales_rptAnnualSalesReport '" + comid + "','" + YearId + "' ";
                    HttpContext.Session.SetString("reportquery", "Exec Sales_rptAnnualSalesReport '" + comid + "','" + YearId + "' ");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (action == "PrintDeliveryOrderWiseChallanReport")
                {
                    reportname = "rptDeliveryOrderWiseChallanReport";
                    filename = "rptDeliveryOrderWiseChallanReport_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec Sales_rptDeliveryOrderWiseChallanReport '" + comid + "','" + FromDOId + "','" + ToDOId + "' ";
                    HttpContext.Session.SetString("reportquery", "Exec Sales_rptDeliveryOrderWiseChallanReport '" + comid + "','" + FromDOId + "','" + ToDOId + "' ");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (action == "PrintrptDeliveryDateWiseBankSummaryReport")
                {
                    reportname = "rptDeliveryDateWiseBankSummary";
                    filename = "rptDeliveryDateWiseBankSummaryReport_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec Sales_rptDeliveryDateWiseBankSummaryReport '" + comid + "','" + FromDate + "','" + ToDate + "' ";
                    HttpContext.Session.SetString("reportquery", "Exec Sales_rptDeliveryDateWiseBankSummaryReport '" + comid + "','" + FromDate + "','" + ToDate + "' ");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }

                else if (action == "PrintrptDeliveryChallanDateWiseBankSummaryReport")
                {
                    reportname = "rptIDeliveryChallanSummary";
                    filename = "rptIDeliveryChallanSummary_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec [Sales_rptDeliveryChallanSummary] '" + comid + "','" + FromDate + "','" + ToDate + "' ";
                    HttpContext.Session.SetString("reportquery", "Exec [Sales_rptDeliveryChallanSummary] '" + comid + "','" + FromDate + "','" + ToDate + "' ");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }


                else if (action == "PrintrptBankDipositMonthWiseSummaryReport")
                {
                    reportname = "rptBankDipositMonthWiseSummaryReport";
                    filename = "rptBankDipositMonthWiseSummaryReport_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec [Sales_rptBankDipositMonthWiseSummaryReport] '" + comid + "','" + FromDate + "','" + ToDate + "','" + MonthId + "' ";
                    HttpContext.Session.SetString("reportquery", "Exec [Sales_rptBankDipositMonthWiseSummaryReport] '" + comid + "','" + FromDate + "','" + ToDate + "','" + MonthId + "' ");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (action == "PrintrptAllotmentWiseSummaryReport")
                {
                    reportname = "rptAllotmentWiseSummaryReport";
                    filename = "rptAllotmentWiseSummaryReport_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec [Sales_rptAllotmentWiseSummaryReport] '" + comid + "','" + YearId + "'";
                    HttpContext.Session.SetString("reportquery", "Exec [Sales_rptAllotmentWiseSummaryReport] '" + comid + "','" + YearId + "'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (action == "PrintrptAllotmentMonthWiseDistrictReport")
                {
                    reportname = "rptAllotmentMonthWiseDistrictReport";
                    filename = "rptAllotmentMonthWiseDistrictReport_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec [Sales_rptAllotmentMonthWiseDistrictReport] '" + comid + "','" + YearId + "'";
                    HttpContext.Session.SetString("reportquery", "Exec [Sales_rptAllotmentMonthWiseDistrictReport] '" + comid + "','" + YearId + "'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (action == "PrintrptChallanReport")
                {
                    reportname = "rptChallanReport";
                    filename = "rptChallanReport_List_" + DateTime.Now.Date.ToString();
                    // var query = "Exec [Sales_rptChallanReport] '" + comid + "','" + FromDOId + "','" + ToDOId + "'";
                    var query = "Exec [Sales_rptChallanReport] '" + comid + "','" + FromDate + "','" + ToDate + "'";
                    // HttpContext.Session.SetString("reportquery", "Exec [Sales_rptChallanReport] '" + comid + "','" + FromDOId + "','" + ToDOId + "'");
                    HttpContext.Session.SetString("reportquery", "Exec [Sales_rptChallanReport] '" + comid + "','" + FromDate + "','" + ToDate + "'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (action == "PrintrptBankWiseSummaryReport")
                {
                    reportname = "rptBankWiseYearlySummaryReport";
                    filename = "rptBankWiseYearlySummaryReport_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec [Sales_rptBankWiseSummaryReport] '" + comid + "','" + YearId + "'";
                    HttpContext.Session.SetString("reportquery", "Exec [Sales_rptBankWiseSummaryReport] '" + comid + "','" + YearId + "'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (action == "PrintrptMonthWiseSalesReport")
                {
                    reportname = "rptMonthWiseSalesReport";
                    filename = "rptMonthWiseSalesReport_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec [Sales_rptAllotmentWiseSummaryReport] '" + comid + "','" + YearId + "'";
                    HttpContext.Session.SetString("reportquery", "Exec [Sales_rptAllotmentWiseSummaryReport] '" + comid + "','" + YearId + "'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (action == "PrintrptDellerWiseBalanceReport")
                {
                    reportname = "rptDellerWiseBalanceReport";
                    filename = "rptDellerWiseBalanceReport_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec [Sales_rptDellerWiseBalanceReport] '" + comid + "','" + YearId + "','" + MonthId + "'";
                    HttpContext.Session.SetString("reportquery", "Exec [Sales_rptDellerWiseBalanceReport] '" + comid + "','" + YearId + "','" + MonthId + "'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (action == "PrintrptDeliveryChallanReport")
                {
                    reportname = "rptDeliveryChallanReport";
                    filename = "rptrptDeliveryChallan_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec [Sales_rptDeliveryChallanReport] '" + comid + "','" + FromDate + "'";
                    HttpContext.Session.SetString("reportquery", "Exec [Sales_rptDeliveryChallanReport] '" + comid + "','" + FromDate + "'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (action == "PrintrptTruckGatePassReport")
                {
                    reportname = "rptTruckGatePassReport";
                    filename = "rptTruckGatePassReport_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec [Sales_rptTruckGatePassReport] '" + comid + "','" + GatePassId + "'";
                    HttpContext.Session.SetString("reportquery", "Exec [Sales_rptTruckGatePassReport] '" + comid + "','" + GatePassId + "'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (action == "PrintrptDOChallanOrderReport")
                {
                    reportname = "rptDOChallanOrderReport";
                    filename = "rptDOChallanOrderReport_" + DateTime.Now.Date.ToString();
                    var query = "Exec [rptDeliveryOrder] '" + comid + "','" + DONo + "'";
                    HttpContext.Session.SetString("reportquery", "Exec [rptDeliveryOrder] '" + comid + "','" + DONo + "'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (action == "PrintrptBoraddhoVittikMulloJomaanduttolonReport")
                {
                    reportname = "rptBoraddhoVittikMulloJomaanduttolonReport";
                    filename = "rptBoraddhoVittikMulloJomaanduttolonReport_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec [Sales_rptDebitOrCreditPriceBasedOnQtyReport] '" + comid + "','" + BookingMonthId + "'";
                    HttpContext.Session.SetString("reportquery", "Exec [Sales_rptDebitOrCreditPriceBasedOnQtyReport] '" + comid + "','" + MonthId + "'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (action == "PrintrptDealerVittikMulloJomaanduttolonReport")
                {
                    reportname = "rptDealerVittikMulloJomaanduttolonReport";
                    filename = "rptDealerVittikMulloJomaanduttolonReport_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec [Sales_rptDealerWiseDebitOrCreditPriceBasedOnQtyReport] '" + comid + "','" + MonthId + "'";
                    HttpContext.Session.SetString("reportquery", "Exec [Sales_rptDealerWiseDebitOrCreditPriceBasedOnQtyReport] '" + comid + "','" + MonthId + "'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (action == "PrintrptYearlyDistributionReport")
                {
                    reportname = "rptYearlyDistributionReport";
                    filename = "rptYearlyDistributionReport_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec [Sales_rptYearlyDistributionReport] '" + comid + "','" + YearId + "'";
                    HttpContext.Session.SetString("reportquery", "Exec [Sales_rptYearlyDistributionReport] '" + comid + "','" + YearId + "'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (action == "PrintrptTaliSheet")
                {
                    reportname = "rptTruckJugeSharSorboraherTaliSheet";
                    filename = "rptTruckJugeSharSorboraherTaliSheet_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec [Sales_rptTaliSheet] '" + comid + "','" + FromDate + "','" + ToDate + "'";
                    HttpContext.Session.SetString("reportquery", "Exec [Sales_rptTaliSheet] '" + comid + "','" + FromDate + "','" + ToDate + "'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (action == "PrintrptDeliveryChallanReceiverPersonWise")
                {
                    reportname = "rptDeliveryChallanByReceiver";
                    filename = "rptDeliveryChallanByReceiver_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec [Sales_rptDeliveryChallanByReceiverReport] '" + comid + "','" + FromDate + "','" + ToDate + "','" + ReceiverPerson + "'";
                    HttpContext.Session.SetString("reportquery", "Exec [Sales_rptDeliveryChallanByReceiverReport] '" + comid + "','" + FromDate + "','" + ToDate + "','" + ReceiverPerson + "'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (action == "PrintrptDeliveryChallanRepresentativeWise")
                {
                    reportname = "rptDeliveryChallanByRepresentative";
                    filename = "rptDeliveryChallanByRepresentative_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec [Sales_rptDeliveryChallanByRepresentativeReport] '" + comid + "','" + FromDate + "','" + ToDate + "','" + RepresentativeId + "'";
                    HttpContext.Session.SetString("reportquery", "Exec [Sales_rptDeliveryChallanByRepresentativeReport] '" + comid + "','" + FromDate + "','" + ToDate + "','" + RepresentativeId + "'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/SalesReport/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (action == "PrintMissingSequence")
                {
                    //redirectUrl = new UrlHelper(Request.RequestContext).Action(action, "COM_BBLC_Master", new { FromDate = FromDate, ToDate = ToDate, Supplierid = SupplierId, CommercialCompanyId = CommercialCompanyId }); //, new { companyId = "7e96b930-a786-44dd-8576-052ce608e38f" }
                    reportname = "rpt_MissingSequence";
                    filename = "rpt_MissingSequence" + DateTime.Now.Date.ToString();
                    var query = "Exec [rpt_MissingSequence] '" + comid + "' , ";
                    HttpContext.Session.SetString("reportquery", "Exec [rpt_MissingSequence] '" + comid + "',  '" + Type + "' , '" + FromNo + "','" + ToNo + "'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Inventory/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }

                string DataSourceName = "DataSet1";

                //HttpContext.Session.SetObject("Acc_rptList", postData);

                //Common.Classes.clsMain.intHasSubReport = 0;
                //clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");// Session["ReportPath"].ToString();
                //clsReport.strQueryMain = HttpContext.Session.GetString("reportquery");
                //clsReport.strDSNMain = DataSourceName;

                //var ConstrName = "ApplicationServices";
                //string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat }); //this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat }); //Repository.GenerateReport(clsReport.strReportPathMain, clsReport.strQueryMain, ConstrName, rptFormat);
                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat });
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


        [HttpPost, ActionName("PrintMissingSequence")]
        public JsonResult PrintMissingSequence(string rptFormat, string action, string Type, string FromNo, string ToNo)
        {
            try
            {
                string comid = HttpContext.Session.GetString("comid");

                var reportname = "";
                var filename = "";
                string redirectUrl = "";
                //return Json(new { Success = 1, TermsId = param, ex = "" });
                if (action == "PrintMissingSequence")
                {
                    //redirectUrl = new UrlHelper(Request.RequestContext).Action(action, "COM_BBLC_Master", new { FromDate = FromDate, ToDate = ToDate, Supplierid = SupplierId, CommercialCompanyId = CommercialCompanyId }); //, new { companyId = "7e96b930-a786-44dd-8576-052ce608e38f" }
                    reportname = "rpt_MissingSequence";
                    filename = "rpt_MissingSequence" + DateTime.Now.Date.ToString();
                    var query = "Exec [rpt_MissingSequence] '" + comid + "' , ";
                    HttpContext.Session.SetString("reportquery", "Exec [rpt_MissingSequence] '" + comid + "',  '" + Type + "' , '" + FromNo + "','" + ToNo + "'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Inventory/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }


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




        [HttpPost]
        public IActionResult BufferWiseSales(int? distid)
        {
            var comid = HttpContext.Session.GetString("comid");
            var data = db.DeliveryOrder.Where(d => d.Booking.Cat_District.DistId == distid).ToList();

            var query = $"EXEC PrcGetDistrictWiseSaleData '{comid}',{distid}";

            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@ComId", comid);
            parameters[1] = new SqlParameter("@DistId", distid);
            List<BufferWiseSalesVM> SalesData = Helper.ExecProcMapTList<BufferWiseSalesVM>("PrcGetDistrictWiseSaleData", parameters);

            return Json(SalesData);
        }

        public class BufferWiseSalesVM
        {
            public int DOId { get; set; }
            public int DeliveryNumber { get; set; }
            public string DODate { get; set; }
            public string DealerName { get; set; }
            public string DistrictName { get; set; }
            public string BankName { get; set; }
            public string AllotmentMonth { get; set; }
            public Int64 PayInSlipNo { get; set; }
            public string PayInSlipDate { get; set; }
            public float UnitPrice { get; set; }
            public float Quantity { get; set; }
            public float TotalPrice { get; set; }
            public string Remarks { get; set; }
        }


        public IActionResult Get()
        {
            try
            {
                var comid = (HttpContext.Session.GetString("comid"));
                var query = from e in db.DeliveryOrder.Where(x => x.DOId > 0 && x.ComId == comid).OrderByDescending(x => x.DOId)
                            select new BufferWiseSalesVM
                            {
                                DOId = e.DOId,
                                DeliveryNumber = e.DONo,
                                DODate = e.DODate.ToString("dd-MMM-yyyy"),
                                DealerName = e.Booking.Customer.CustomerName,
                                DistrictName = e.Booking.Cat_District.DistName,
                                BankName = e.Acc_ChartOfAccount.AccName,
                                //AllotmentMonth = e.Booking.MonthName.Name,
                                // BankName = e.Acc_ChartOfAccount.AccType,
                                AllotmentMonth = e.Booking.MonthName.MonthName,
                                PayInSlipNo = e.PayInSlipNo,
                                PayInSlipDate = e.PayInSlipDate.ToString("dd-MMM-yyyy"),
                                UnitPrice = (float)e.UnitPrice,
                                Quantity = (float)e.Qty,
                                TotalPrice = (float)e.TotalPrice,
                                Remarks = e.Remarks
                            };
                var parser = new Parser<BufferWiseSalesVM>(Request.Form, query);
                return Json(parser.Parse());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
