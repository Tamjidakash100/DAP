using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTERP.Models.Common
{
    class clsReport
    {
        public int Id { get; set; }
        
        public  string strReportPathMain { get; set; }
        public  string strDSNMain { get; set; }
        public  string strQueryMain { get; set; }

        public  List<subReport> rptList { get; set; }
    }

    //Sub Report Class
    public class subReport
    {
        public int Id { get; set; }
        public string strRptPathSub { get; set; } // Sub Report Path name
        public string strRFNSub { get; set; }   // Relational Field Name 
        public string strDSNSub { get; set; }   // DSN Name Sub Report
        public string strQuerySub { get; set; } // Query string Sub Report


        public subReport(string strRptPath, string strRFN, string strDSN, string strQuery)
        {
            strRptPathSub = strRptPath;
            strRFNSub = strRFN;
            strDSNSub = strDSN;
            strQuerySub = strQuery;
        }
    }
}
