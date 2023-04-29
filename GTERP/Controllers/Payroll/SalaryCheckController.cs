using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GTERP.Controllers.Payroll
{
    [OverridableAuthorize]
    public class SalaryCheckController : Controller
    {
        public SalaryCheckController(GTRDBContext _db)
        {
            db = _db;
        }

        private GTRDBContext db { get; set; }

        public IActionResult Index(string prossType)
        {
            string comid = HttpContext.Session.GetString("comid");

            SqlParameter[] parameter1 = new SqlParameter[1];
            parameter1[0] = new SqlParameter("@ComId", comid);
            var pType = Helper.ExecProcMapTList<Pross>("GetProssType", parameter1);
            ViewBag.ProssType = new SelectList(pType, "ProssType", "ProssType");

            //ViewBag.SalaryCheck = null;
            List<SalaryCheck> salCheck = null;
            if (prossType != null)
            {
                SqlParameter[] parameter = new SqlParameter[2];
                parameter[0] = new SqlParameter("@ComId", comid);
                parameter[1] = new SqlParameter("@ProssType", prossType);
                salCheck = Helper.ExecProcMapTList<SalaryCheck>("Payroll_prcGetSalaryCheck", parameter);
                ViewBag.Pross = prossType;
            }
            return View(salCheck);


        }
        public class Pross
        {
            public string ProssType { get; set; }
            public DateTime dtInput { get; set; }
        }


        public class SalaryCheck
        {
            public int EmpId { get; set; }
            [Display(Name = "Emp Code")]
            public string EmpCode { get; set; }
            [Display(Name = "Emp Name")]
            public string EmpName { get; set; }
            [Display(Name = "Department")]
            public string DeptName { get; set; }
            [Display(Name = "Section")]
            public string SectName { get; set; }
            [Display(Name = "Designation")]
            public string DesigName { get; set; }
            [Display(Name = "Emp Type")]
            public string EmpType { get; set; }
            [Display(Name = "Account Number")]
            public string AccountNumber { get; set; }
            [Display(Name = "Pross Type")]
            public string ProssType { get; set; }
            [Display(Name = "Basic Salary")]
            public int BS { get; set; }
            [Display(Name = "House Rent")]
            public int HR { get; set; }
            [Display(Name = "Medical ALlowance")]
            public int MA { get; set; }
            [Display(Name = "Dearness Allowance")]
            public float DearnessAllow { get; set; }
            [Display(Name = "Gas Allowance")]
            public float GasAllow { get; set; }
            [Display(Name = "Personal Pay")]
            public float PersonalPay { get; set; }
            [Display(Name = "Arrear Basic")]
            public float ArrearBasic { get; set; }
            [Display(Name = "Arrear Bonus")]
            public float ArrearBonus { get; set; }
            [Display(Name = "Washing Allowance")]
            public float WashingAllow { get; set; }
            [Display(Name = "ComPFCount")]

            public float ComPFCount { get; set; }
            [Display(Name = "Charge Allowance")]
            public float SiftAllow { get; set; }
            [Display(Name = "Charge Allowance")]
            public float ChargeAllow { get; set; }
            [Display(Name = "Contain Sub")]
            public float ContainSub { get; set; }
            [Display(Name = "Education Allowance")]
            public float EduAllow { get; set; }
            [Display(Name = "Tiffin Allowance")]
            public float TiffinAllow { get; set; }
            [Display(Name = "Canteen Allowance")]
            public float CanteenAllow { get; set; }
            [Display(Name = "Festival Bonus")]
            public float FestivalBonus { get; set; }
            [Display(Name = "Risk Allowance")]
            public float RiskAllow { get; set; }
            [Display(Name = "Night lowance")]
            public float NightAllow { get; set; }
            [Display(Name = "Convince Allowance")]
            public int ConvAllow { get; set; }
            [Display(Name = "Modbile Allowance")]
            public int MobileAllow { get; set; }
            [Display(Name = "Honorarim")]
            public int MiscHonorAllow { get; set; }

            [Display(Name = "Others Addition")]
            public int OthersAddition { get; set; }

            [Display(Name = "Gross Pay")]
            public float TotalPayable { get; set; }

            //deduction part
            [Display(Name = "PF")]
            public float PF { get; set; }
            [Display(Name = "Addition PF")]
            public float PfAdd { get; set; }
            [Display(Name = "HR Expense")]
            public float HrExp { get; set; }

            [Display(Name = "Electric Charge")]
            public float ElectricCharge { get; set; }
            [Display(Name = "Gas charge")]
            public float Gascharge { get; set; }

            [Display(Name = "Water charge")]
            public float Watercharge { get; set; }
            [Display(Name = "IncomeTax")]
            public float IncomeTax { get; set; }


            [Display(Name = "M.C. Loan (Local)")]
            public float McloanDed { get; set; }
            [Display(Name = "M.C. Loan (O.P)")]
            public float McloanDedOther { get; set; }
            [Display(Name = "H.B. Loan (Local)")]
            public float HbloanDed { get; set; }
            [Display(Name = "H.B. Loan (O.P)")]
            public float HbloanDedOther { get; set; }
            [Display(Name = "P.F. Loan (Local)")]
            public float PfloannDed { get; set; }
            [Display(Name = "PF Loan (O.P)")]
            public float PfloannDedOther { get; set; }
            [Display(Name = "W.F. Loan (Local)")]
            public float WfloanLocal { get; set; }
            [Display(Name = "W.F. Loan (O.P)")]
            public float WfloanOther { get; set; }
            [Display(Name = "W.P.P.F. Ded.")]
            public float WpfloanDed { get; set; }
            [Display(Name = "Adv Against Exp.")]
            public float AdvAgainstExp { get; set; }
            [Display(Name = "Facility Adv.")]
            public float AdvFacility { get; set; }

            [Display(Name = "Festival Bonus Ded.")]
            public float FesBonusDed { get; set; }
            [Display(Name = "Transport Charge")]
            public float Transportcharge { get; set; }
            [Display(Name = "Salary Adv")]
            public float SalaryAdv { get; set; }

            [Display(Name = "Wagesa Adv")]
            public float WagesaAdv { get; set; }

            [Display(Name = "Purchase Adv")]
            public float PurchaseAdv { get; set; }

            [Display(Name = "Incentive Bns Ded.")]
            public float DedIncBns { get; set; }

            [Display(Name = "Incentive Bns Ded.(O.P)")]
            public float DedIncBonusOf { get; set; }

            [Display(Name = "Adv. IT Ded.")]
            public float AdvInTaxDed { get; set; }

            [Display(Name = "Donation")]
            public float Donation { get; set; }

            [Display(Name = "Haz Scheme")]
            public float HazScheme { get; set; }
            [Display(Name = "Dish Antina")]
            public float Dishantenna { get; set; }
            [Display(Name = "Revenue Stamp")]
            public float RevenueStamp { get; set; }
            [Display(Name = "O.W.A Sub.")]
            public float OwaSub { get; set; }

            [Display(Name = "Ladies Club")]
            public float Moktab { get; set; }
            [Display(Name = "Chemical Forum")]
            public float ChemicalForum { get; set; }
            [Display(Name = "Diploma asso. Ded.")]
            public float DiplomaassoDed { get; set; }
            [Display(Name = "Enggasso Ded.")]
            public float EnggassoDed { get; set; }

            [Display(Name = "Chemical Asso")]
            public float ChemicalAsso { get; set; }

            [Display(Name = "Wf Sub")]
            public float Wfsub { get; set; }

            [Display(Name = "Union Sub Ded")]
            public float UnionSubDed { get; set; }

            [Display(Name = "Emp Club Ded")]
            public float EmpClubDed { get; set; }

            [Display(Name = "Adv Wages Ded")]
            public float AdvWagesDed { get; set; }



            [Display(Name = "Others Deduction")]
            public float OthersDeduction { get; set; }

            [Display(Name = "Total Deduct")]
            public float TotalDeduct { get; set; }
            [Display(Name = "Net Salary Payable")]
            public float NetSalaryPayable { get; set; }


        }
    }
}