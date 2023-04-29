using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GTReportService.Models
{
    public class SubReport
    {
        public int Id { get; set; }
        public string strRptPathSub { get; set; } // Sub Report Path name
        public string strRFNSub { get; set; }   // Relational Field Name 
        public string strDSNSub { get; set; }   // DSN Name Sub Report
        public string strQuerySub { get; set; } // Query string Sub Report
    }
}