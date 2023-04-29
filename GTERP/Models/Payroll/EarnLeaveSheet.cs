﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTERP.Models.Payroll
{
    public class EarnLeaveSheet
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string EmpStatus { get; set; }
        public string Paymode { get; set; }
        public string EmpType { get; set; }
        public string ProssType { get; set; }
        public string DeptId { get; set; }
        public string DeptName { get; set; }
        public string EmpCode { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string ReportType { get; set; }
        public string LId { get; set; }

        [Display(Name = @"View As: ")]
        public string ViewReportAs { get; set; }
        public EarnLeaveSheetGrid EarnLeaveSheetPropGrid { get; set; }
    }
    public class EarnLeaveSheetGrid
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string EmpStatus { get; set; }
        public string Paymode { get; set; }
        public string EmpType { get; set; }
        public string ProssType { get; set; }
        public string DeptId { get; set; }
        public string DeptName { get; set; }
        public string EmpCode { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string ReportType { get; set; }
        public string LId { get; set; }
    }
}
