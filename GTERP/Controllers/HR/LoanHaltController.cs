using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GTERP.Controllers
{
    [OverridableAuthorize]

    public class LoanHaltController : Controller
    {
        private GTRDBContext db;
        public LoanHaltController(GTRDBContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            string comid = HttpContext.Session.GetString("comid");

            var items = new SelectList(db.Cat_Variable
                .Where(v => v.ComId == comid && v.VarType == "LoanHalt")
                .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName");

            ViewBag.LoanTypes = items;

            ViewBag.OtherLoanType = new SelectList(db.Cat_Variable
                .Where(v => v.ComId == comid && v.VarType == "LoanType")
                .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName");

            var employees = db.HR_Emp_Info
                .Include(h => h.Cat_Department)
                .Include(h => h.Cat_Designation)
                .Include(h => h.Cat_Section)
                .Select(e => new EmpViewModel
                {
                    EmpId = e.EmpId,
                    ComId = e.ComId,
                    EmpName = e.EmpName,
                    EmpCode = e.EmpCode,
                    DesigName = e.Cat_Designation.DesigName,
                    SectName = e.Cat_Section.SectName,
                    DeptName = e.Cat_Department.DeptName
                }).ToList();

            ViewBag.Employees = employees;

            return View();
        }

        public class EmpViewModel
        {
            public int EmpId { get; set; }
            public string ComId { get; set; }
            public string EmpName { get; set; }
            public string EmpCode { get; set; }
            public string DesigName { get; set; }
            public string DeptName { get; set; }
            public string SectName { get; set; }
        }

        public class LoanHalt
        {
            [Display(Name = "Loan Type")]
            public string LoanType { get; set; }

            [Display(Name = "Other Loan Type")]
            public string OtherLoanType { get; set; }

            public string Criteria { get; set; }

            [Display(Name = "Increase Month")]
            public int IncreaseMonth { get; set; }
            [Display(Name = "Effective Month")]
            public DateTime EffectiveMonth { get; set; }

            [DataType(DataType.MultilineText)]
            public string Remarks { get; set; }
            public List<int> Employess { get; set; }
        }

        public IActionResult Create(LoanHalt loanHalt)
        {
            try
            {
                string comid = HttpContext.Session.GetString("comid");
                string userid = HttpContext.Session.GetString("userid");

                if (loanHalt.OtherLoanType == null)
                    loanHalt.OtherLoanType = "";


                if (loanHalt.Criteria == "All")
                {
                    var lInc = new HR_Loan_IncreaseInfo();
                    lInc.LoanType = loanHalt.LoanType;
                    lInc.InputType = loanHalt.Criteria;
                    lInc.OtherLoanType = loanHalt.OtherLoanType;
                    lInc.TtlIncreaseMonth = loanHalt.IncreaseMonth;
                    lInc.DtEffectiveMonth = loanHalt.EffectiveMonth;
                    lInc.Remarks = loanHalt.Remarks;
                    //lInc.EmpId = loanHalt.Employess[i];
                    lInc.UserId = userid;
                    lInc.ComId = comid;
                    lInc.DateAdded = DateTime.Now;
                    lInc.EmpId = 0;
                    db.HR_Loan_IncreaseInfo.Add(lInc);
                    db.SaveChanges();

                    SqlParameter[] sqlParameters = new SqlParameter[8];
                    sqlParameters[0] = new SqlParameter("@comid", comid);
                    sqlParameters[1] = new SqlParameter("@id", 0);
                    sqlParameters[2] = new SqlParameter("@LoanType", loanHalt.LoanType);
                    sqlParameters[3] = new SqlParameter("@TtlLoanIncreaseMonth", loanHalt.IncreaseMonth);
                    sqlParameters[4] = new SqlParameter("@EffectiveMonth", loanHalt.EffectiveMonth);
                    sqlParameters[5] = new SqlParameter("@Remarks", loanHalt.Remarks);

                    //sqlParameters[1] = new SqlParameter("@id", 0);
                    sqlParameters[6] = new SqlParameter("@EmpId", 0);
                    sqlParameters[7] = new SqlParameter("@LoanOtherType", loanHalt.OtherLoanType);
                    Helper.ExecProc("prcProcessLoanTermIncrease", sqlParameters);

                }
                else if (loanHalt.Criteria == "Employee")
                {
                    for (int i = 0; i < loanHalt.Employess.Count; i++)
                    {
                        var lInc = new HR_Loan_IncreaseInfo();
                        lInc.LoanType = loanHalt.LoanType;
                        lInc.InputType = loanHalt.Criteria;
                        lInc.OtherLoanType = loanHalt.OtherLoanType;
                        lInc.TtlIncreaseMonth = loanHalt.IncreaseMonth;
                        lInc.DtEffectiveMonth = loanHalt.EffectiveMonth;
                        lInc.Remarks = loanHalt.Remarks;
                        //lInc.EmpId = loanHalt.Employess[i];
                        lInc.UserId = userid;
                        lInc.ComId = comid;
                        lInc.DateAdded = DateTime.Now;
                        lInc.EmpId = loanHalt.Employess[i];

                        db.HR_Loan_IncreaseInfo.Add(lInc);
                        db.SaveChanges();

                        SqlParameter[] sqlParameters = new SqlParameter[8];
                        sqlParameters[0] = new SqlParameter("@comid", comid);
                        sqlParameters[1] = new SqlParameter("@id", 1);
                        sqlParameters[2] = new SqlParameter("@LoanType", loanHalt.LoanType);
                        sqlParameters[3] = new SqlParameter("@TtlLoanIncreaseMonth", loanHalt.IncreaseMonth);
                        sqlParameters[4] = new SqlParameter("@EffectiveMonth", loanHalt.EffectiveMonth);
                        sqlParameters[5] = new SqlParameter("@Remarks", loanHalt.Remarks);
                        sqlParameters[6] = new SqlParameter("@EmpId", loanHalt.Employess[i]);
                        sqlParameters[7] = new SqlParameter("@LoanOtherType", loanHalt.OtherLoanType);

                        Helper.ExecProc("prcProcessLoanTermIncrease", sqlParameters);
                    }
                }

                TempData["Message"] = "Data Save Successfully";

                return Json(new { Success = 1, ex = TempData["Message"].ToString() });


            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                return Json(new { Success = 3, ex = TempData["Message"].ToString() });
            }

        }
    }
}
