using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GTERP.Models.Common;
using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;

using GTReportService.Models;

namespace GTReportService.Controllers
{
    ////[OverridableAuthorize]
    public class ReportViewerController : Controller
    {
        LocalReport lr = new LocalReport();
        private string strMainRP = "";
        private string strMainDSN = "";
        private string strMainQuery = "";
        private DataSet dsReport;
        string strFormat = "";

        //Variabl For Sub Report
        private string subrp = "";
        private string strDSN = "";
        private string strQuery = "";
        private string strRFN = "";
        // GET: ReportViewer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GenerateReport()

        {
            
            string reportFileName = Request.QueryString["ReportPath"];
            string databaseName = Request.QueryString["DbName"];
            string sqlCommand = Request.QueryString["SqlCmd"];
            string reportFileType = Request.QueryString["ReportType"];
            string SubReport = Request.QueryString["SubReport"];
            var listOfSubRpt=JsonConvert.DeserializeObject<List<subReport>>(SubReport);
            var clsRpt = new clsReport();
            if (listOfSubRpt.Count>0)
            {
                
                foreach (var subRpt in listOfSubRpt)
                {
                    clsRpt.rptList.Add(new subReport(subRpt.strRptPathSub, subRpt.strRFNSub, subRpt.strDSNSub, subRpt.strQuerySub));
                }
            }
           

            clsConnectionNew clsCon = new clsConnectionNew(databaseName, true);


            // Session["ReportPath"] = "~/Reports/rptMasterLCSalesContact.rdlc";

            //sqlCommand = "Exec GTERP.dbo.[rptMasterLCSalesContact] '" + 1 + "','" + 4 + "'";



            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            string reportformat = "PDF";


            if (reportFileType.ToString().ToUpper() == "EXCEL")
            {
                reportformat = "xls";


            }
            else if (reportFileType.ToString().ToUpper() == "WORD")
            {
                reportformat = "doc";
            }
            else
            {
                reportformat = "pdf";
            }


            string path = Path.Combine(Server.MapPath(reportFileName));

            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                Console.WriteLine($"No report file Named {reportFileName} is found !!");

            }

            lr.EnableExternalImages = true;

            clsCon.GTRFillDatasetWithSQLCommand(ref ds, sqlCommand);

            dt = ds.Tables[0];

            ReportDataSource rd = new ReportDataSource("DataSet1", dt);
            lr.DataSources.Add(rd);
            lr.SubreportProcessing += new SubreportProcessingEventHandler(prcProcessSubReport);


            //reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension = "test";

            ReportPageSettings aPageSettings = lr.GetDefaultPageSettings();
            int width = aPageSettings.PaperSize.Width;
            int height = aPageSettings.PaperSize.Height;
            int margintop = aPageSettings.Margins.Top;
            int marginbottom = aPageSettings.Margins.Bottom;
            int marginleft = aPageSettings.Margins.Left;
            int marginright = aPageSettings.Margins.Right;

            //new LocalReport().EnableExternalImages = true;


            string deviceInfo =
            "<DeviceInfo>" +
            "   <OutputFormat>PDF</OutputFormat>" +
            "   <PageWidth>" + width + "</PageWidth>" +
            "   <PageHeight>" + height + "</PageHeight>" +
            "   <MarginTop>" + margintop + "</MarginTop>" +
            "   <MarginLeft>" + marginleft + "</MarginLeft>" +
            "   <MarginRight>" + marginright + "</MarginRight>" +
            "   <MarginBottom>" + marginbottom + "</MarginBottom>" +
            "</DeviceInfo>";
           
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            lr.DisplayName = "GTR_Report";

            renderedBytes = lr.Render(
                reportFileType, 
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings
                );

            var sFileName = Session["PrintFileName"] + "_" + DateTime.Now.ToString("yyyyMMdd").ToString();

            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", ("inline; filename=" + sFileName + "." + reportformat)); //


            return File(renderedBytes, mimeType);
        }

        private void prcProcessSubReport(object sender, SubreportProcessingEventArgs e)
        {
            //Declare a data table
            DataTable dtSub = new DataTable();
            string sqlQuery = "", param = "";

            prcGetSubReportDetails(e.ReportPath);
            param = strRFN.Length == 0 ? "" : e.Parameters[strRFN].Values[0].ToString();
            sqlQuery = strQuery + " " + param;

            //Ready a datatable for report based on parameter data
            dtSub = prcGetDataSub(sqlQuery);

            //Processing sub report data
            e.DataSources.Add(new ReportDataSource(strDSN, dtSub));

            //            this.Page.Title = "final checking title";
        }

        private DataTable prcGetDataSub(string strQuery)
        {
            //System.Data.DataSet 
            System.Data.DataSet ds = new System.Data.DataSet();
            clsConnectionNew clsCon = new clsConnectionNew(true);
            try
            {
                //SQL Query (Here i use Store procedure)
                clsCon.GTRFillDatasetWithSQLCommand(ref ds, strQuery);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                clsCon = null;
            }
            return ds.Tables[0];
        }

        private void prcGetSubReportDetails(string rptPath)
        {
            //Session["MyArrayList"] = new ArrayList();
            Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
            //ArrayList rptList = new ArrayList();

            postData = Session["rptList"] as Dictionary<int, dynamic>;


            foreach (var lst in postData)
            {
                if (lst.Value.strRptPathSub.ToUpper() == rptPath.ToUpper())
                {
                    strDSN = lst.Value.strDSNSub;
                    strQuery = lst.Value.strQuerySub;
                    strRFN = lst.Value.strRFNSub;
                }
            }

            //foreach (var lst in postData)
            //{
            //}

            //subrp = "rptInvoice_PM";
            //strDSN = "DataSet1";
            //strQuery = "Exec custbill_corporate.dbo.rptInvoice_PM 65,1";
            //strRFN = "";



            //foreach (var lst in Common.Classes.clsReport.rptList)
            //{
            //    if (lst.strRptPathSub.ToUpper() == rptPath.ToUpper())
            //    {
            //        strDSN = lst.strDSNSub;
            //        strQuery = lst.strQuerySub;
            //        strRFN = lst.strRFNSub;
            //    }
            //}

        }
        //public ActionResult Print(int? id, string type)
        //{
        //    AppData.AppData.dbGTCommercial = db.Database.Connection.Database;
        //    //Session["rptList"] = null;
        //    clsReport.rptList = null;

        //    //ReportItem item = new ReportItem();
        //    //string query = "";
        //    //string path = "";

        //    //query = "Exec rptInvoice "+ id +" ,'" + System.Web.HttpContext.Current.Session["ComId"] + "'";
        //    //path = "~/Report/rptInvoice.rdlc";
        //    //item.Databinds(path, query);
        //    //clsReport.rptList.Add(new subReport("rptSaleID_PM", "", "DataSet1", "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.rptInvoice_PM '" + id + "','" + System.Web.HttpContext.Current.Session["ComId"] + "'"));

        //    //return RedirectToAction("Index", "ReportViewer");


        //    //[] @ComId tinyint, @Flag varchar(15), @Currency smallInt
        //    Session["ReportPath"] = "~/Report/POS/rptInvoice.rdlc";
        //    Session["reportquery"] = "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.[rptInvoice] '" + id + "','" + AppData.AppData.intComId + "','" + AppData.AppData.AppPath.ToString() + "'";
        //    string ReportPath = "~/Report/POS/rptInvoice.rdlc";
        //    string SQLQuery = "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.[rptInvoice] '" + id + "','" + AppData.AppData.intComId + "','" + AppData.AppData.AppPath.ToString() + "'";
        //    string DataSourceName = "DataSet1";
        //    //string FormCaption = "Report :: Sales Acknowledgement ...";


        //    string filename = db.SalesMains.Where(x => x.SalesId == id).Select(x => x.CustomerName + "_" + x.SalesNo).Single();
        //    Session["PrintFileName"] = filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", "");

        //    postData.Add(1, new subReport("rptInvoice_Terms", "", "DataSet1", "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.rptInvoice_Terms '" + id + "','" + Session["comid"].ToString() + "',''"));

        //    clsReport.rptList.Add(new subReport("rptInvoice_BankDetails", "", "DataSet1", "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.rptInvoice_BankDetails '" + (gridList.ActiveRow.Cells["termsidBank"].Value.ToString()) + "'," + AppData.AppData.intComId + ",'" + AppData.AppData.AppPath.ToString() + "'"));
        //    clsReport.rptList.Add(new subReport("rptInvoice_Terms", "", "DataSet1", "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.rptInvoice_Terms '" + id + "'," + AppData.AppData.intComId + ",'" + AppData.AppData.AppPath.ToString() + "'"));
        //    clsReport.rptList.Add(new subReport("rptSaleID_PM", "", "DataSet1", "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.rptInvoice_PM '" + id + "'," + AppData.AppData.intComId + ""));


        //    Session["rptList"] = postData;

        //    //Common.Classes.clsMain.intHasSubReport = 0;
        //    clsReport.strReportPathMain = ReportPath;
        //    clsReport.strQueryMain = SQLQuery;
        //    clsReport.strDSNMain = DataSourceName;

        //    return RedirectToAction("Index", "ReportViewer");


        //}
    }

}