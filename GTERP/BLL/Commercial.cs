using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.BLL
{
    public class CommercialRepository
    {
        public string GenerateReport(string reportPath, string sqlCmd, string conStringName, string reportFileType, string subReportObject = null)
        {
            var result = "";
            if (subReportObject == null)
            {
                //result = $"https://localhost:44383/ReportViewer/GenerateReport?ReportPath= { reportPath }&SqlCmd={ sqlCmd }&DbName={conStringName}&ReportType={ reportFileType}";
                //result = $"https://www.pqstec.com/DAPERPREPORT/ReportViewer/GenerateReport?ReportPath= { reportPath }&SqlCmd={ sqlCmd }&DbName={conStringName}&ReportType={ reportFileType}";
                result = $"http://www.gtrbd.net/DAPERPREPORT/ReportViewer/GenerateReport?ReportPath= { reportPath }&SqlCmd={ sqlCmd }&DbName={conStringName}&ReportType={ reportFileType}";
                //result = $"http://www.gtrbd.net/DAPREPORTTesting/ReportViewer/GenerateReport?ReportPath= { reportPath }&SqlCmd={ sqlCmd }&DbName={conStringName}&ReportType={ reportFileType}";
            }
            else
            {
                //result = $"https://localhost:44383/ReportViewer/GenerateReport?ReportPath= { reportPath }&SqlCmd={ sqlCmd }&DbName={conStringName}&ReportType={ reportFileType}&SubReport={subReportObject}";
                //result = $"https://www.pqstec.com/DAPERPREPORT/ReportViewer/GenerateReport?ReportPath= { reportPath }&SqlCmd={ sqlCmd }&DbName={conStringName}&ReportType={ reportFileType}&SubReport={subReportObject}";
                result = $"http://www.gtrbd.net/DAPERPREPORT/ReportViewer/GenerateReport?ReportPath= { reportPath }&SqlCmd={ sqlCmd }&DbName={conStringName}&ReportType={ reportFileType}&SubReport={subReportObject}";
                //result = $"http://www.gtrbd.net/DAPREPORTTesting/ReportViewer/GenerateReport?ReportPath= { reportPath }&SqlCmd={ sqlCmd }&DbName={conStringName}&ReportType={ reportFileType}&SubReport={subReportObject}";
            }
            return result;

        }
    }
    public class SubReport
    {
        public int Id { get; set; }
        public string strRptPathSub { get; set; } // Sub Report Path name
        public string strRFNSub { get; set; }   // Relational Field Name 
        public string strDSNSub { get; set; }   // DSN Name Sub Report
        public string strQuerySub { get; set; } // Query string Sub Report
    }


    /////////////////////sub report sample
    ///
    //string ConstrName = "ApplicationServices";
    //string ReportType = "PDF";
    //ReportPath = "~/ReportViewer/POS/rptInvoice.rdlc";
    //        var subReport = new SubReport();
    //var subReportObject = new List<SubReport>();

    //subReport.strDSNSub = "DataSet1";
    //        subReport.strRFNSub = "";
    //        subReport.strQuerySub = "Exec rptInvoice_Terms '" + id + "','" + Session["comid"].ToString() + "',''";
    //        subReport.strRptPathSub = "rptInvoice_Terms";

    //        subReportObject.Add(subReport);
    //        var jsonData = JsonConvert.SerializeObject(subReportObject);

    //        var callBackUrl = GenerateReport(ReportPath, SQLQuery, ConstrName, ReportType, jsonData);

    //        return Redirect(callBackUrl);


}

