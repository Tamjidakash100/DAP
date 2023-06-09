﻿using System;
using System.Collections.Generic;

namespace GTERP_DAP_Model.CustomModels
{
    public partial class TblProcessedDataSal
    {
        public int? AEmpId { get; set; }
        public int ComId { get; set; }
        public long EmpId { get; set; }
        public string Month { get; set; }
        public short Year { get; set; }
        public string EmpCode { get; set; }
        public string EmpType { get; set; }
        public DateTime? DtInput { get; set; }
        public short? DesigId { get; set; }
        public short SectId { get; set; }
        public short? SubSectId { get; set; }
        public short? DeptId { get; set; }
        public string Band { get; set; }
        public DateTime? DtJoin { get; set; }
        public string Grade { get; set; }
        public string GradeSal { get; set; }
        public string DtSalary { get; set; }
        public string PaySource { get; set; }
        public string PayMode { get; set; }
        public string EmpSts { get; set; }
        public float WorkingDays { get; set; }
        public float Pday { get; set; }
        public float Dday { get; set; }
        public float Wday { get; set; }
        public float Hday { get; set; }
        public float Present { get; set; }
        public float Absent { get; set; }
        public short TtlAbsent { get; set; }
        public float Late { get; set; }
        public float LateMin { get; set; }
        public float Cl { get; set; }
        public float El { get; set; }
        public float Sl { get; set; }
        public float Ml { get; set; }
        public float AccL { get; set; }
        public short Lwp { get; set; }
        public decimal Lwppay { get; set; }
        public decimal Mlpay { get; set; }
        public short Clh { get; set; }
        public short Slh { get; set; }
        public decimal Gs { get; set; }
        public decimal Bs { get; set; }
        public decimal Hr { get; set; }
        public decimal Ma { get; set; }
        public decimal Trn { get; set; }
        public decimal Ab { get; set; }
        public decimal Adv { get; set; }
        public decimal Gp { get; set; }
        public decimal Pf { get; set; }
        public decimal GradeAmt { get; set; }
        public decimal Arrear { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal AttBonus { get; set; }
        public decimal HdayBonus { get; set; }
        public decimal Fbonus { get; set; }
        public decimal Pbonus { get; set; }
        public decimal OthersAddition { get; set; }
        public decimal OthersDeduct { get; set; }
        public decimal OtherAllow { get; set; }
        public decimal TotalDeduct { get; set; }
        public decimal TotalAddition { get; set; }
        public decimal TotalPayable { get; set; }
        public decimal NetSalary { get; set; }
        public decimal NetSalaryPayable { get; set; }
        public decimal CashAmt { get; set; }
        public decimal BankAmt { get; set; }
        public byte Cf { get; set; }
        public decimal Stamp { get; set; }
        public string Otdes { get; set; }
        public decimal Otrate { get; set; }
        public decimal Ot { get; set; }
        public float OtminTtl { get; set; }
        public float OthrTtl { get; set; }
        public float ExOtmin { get; set; }
        public float ExOthr { get; set; }
        public decimal ExOtamount { get; set; }
        public string ProssType { get; set; }
        public byte IsAllowPf { get; set; }
        public byte IsReleased { get; set; }
        public short BankId { get; set; }
        public string BankAcNo { get; set; }
        public decimal ExchRate { get; set; }
        public decimal Pp { get; set; }
        public decimal Dd { get; set; }
        public decimal Bcl { get; set; }
        public decimal Bel { get; set; }
        public decimal Bsl { get; set; }
        public decimal Trnd { get; set; }
        public decimal MobileDeduction { get; set; }
        public decimal MobileAllow { get; set; }
        public short Lunch { get; set; }
        public short LunchAmt { get; set; }
        public short Night { get; set; }
        public short NightAmt { get; set; }
        public decimal IncenBns { get; set; }
        public byte IsAllowGradeBns { get; set; }
        public decimal Loan { get; set; }
        public decimal LoanBalance { get; set; }
        public int Amount { get; set; }
        public int Tk1000 { get; set; }
        public int Tk500 { get; set; }
        public int Tk100 { get; set; }
        public int Tk50 { get; set; }
        public int Tk20 { get; set; }
        public int Tk10 { get; set; }
        public int Tk5 { get; set; }
        public int Tk2 { get; set; }
        public int Tk1 { get; set; }
        public long AId { get; set; }
        public Guid WId { get; set; }
        public byte IsCash { get; set; }
        public byte IsBank { get; set; }
        public byte MngSalary { get; set; }

        public virtual TblCatCompany Com { get; set; }
    }
}
