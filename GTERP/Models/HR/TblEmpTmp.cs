﻿using System;
using System.Collections.Generic;

namespace GTERP_DAP_Model.CustomModels
{
    public partial class TblEmpTmp
    {
        public byte ComId { get; set; }
        public long AEmpId { get; set; }
        public long EmpId { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string EmpNameB { get; set; }
        public string EmpFather { get; set; }
        public string EmpFatherB { get; set; }
        public string EmpMother { get; set; }
        public string EmpMotherB { get; set; }
        public string EmpSpouse { get; set; }
        public string EmpSpouseB { get; set; }
        public string EmpCurrAdd { get; set; }
        public string EmpCurrCity { get; set; }
        public string EmpCurrPo { get; set; }
        public string EmpCurrPs { get; set; }
        public short EmpCurrDistId { get; set; }
        public string EmpPerAdd { get; set; }
        public string EmpPerVill { get; set; }
        public string EmpPerPo { get; set; }
        public string EmpPerPs { get; set; }
        public string EmpPerCity { get; set; }
        public short EmpPerDistId { get; set; }
        public string EmpPerZip { get; set; }
        public string EmpPhone { get; set; }
        public string EmpMobile { get; set; }
        public string EmpEmail { get; set; }
        public string EmpPicLocation { get; set; }
        public string EmpRemarks { get; set; }
        public string EmpPrintAs { get; set; }
        public string Sex { get; set; }
        public string Religion { get; set; }
        public string Caste { get; set; }
        public string BloodGroup { get; set; }
        public string MaritalSts { get; set; }
        public DateTime? DtBirth { get; set; }
        public DateTime? DtJoin { get; set; }
        public DateTime? DtReleased { get; set; }
        public DateTime? DtProvisionEnd { get; set; }
        public byte IsConfirm { get; set; }
        public DateTime? DtConfirm { get; set; }
        public long ConfDay { get; set; }
        public DateTime? DtQuit { get; set; }
        public short SectId { get; set; }
        public short SectIdSal { get; set; }
        public int DesigId { get; set; }
        public string Grade { get; set; }
        public string Floor { get; set; }
        public string Line { get; set; }
        public string WorkPlace { get; set; }
        public decimal Ts { get; set; }
        public decimal Gs { get; set; }
        public decimal Bs { get; set; }
        public decimal Ma { get; set; }
        public decimal Hr { get; set; }
        public decimal Trn { get; set; }
        public decimal PrdBn { get; set; }
        public string ShiftType { get; set; }
        public string ShiftCat { get; set; }
        public short? ShiftId { get; set; }
        public string Nationality { get; set; }
        public string PassportNo { get; set; }
        public string VoterNo { get; set; }
        public string BirthCertNo { get; set; }
        public byte IsAllowOtherAll { get; set; }
        public byte IsAllowNight { get; set; }
        public byte IsAllowAttBns { get; set; }
        public decimal AttBnsAmt { get; set; }
        public byte IsAllowHolidayBns { get; set; }
        public byte IsAllowPf { get; set; }
        public DateTime? DtPf { get; set; }
        public byte IsAllowOt { get; set; }
        public byte IsAllowPp { get; set; }
        public string PolicyNo { get; set; }
        public byte IsAllowGp { get; set; }
        public decimal Gpamt { get; set; }
        public byte IsTrnDeduction { get; set; }
        public byte IsInactive { get; set; }
        public string PaySource { get; set; }
        public string PayMode { get; set; }
        public string EmpType { get; set; }
        public string EmpSts { get; set; }
        public string CardNo { get; set; }
        public string CardNoCancel { get; set; }
        public short BankId { get; set; }
        public string BankAcNo { get; set; }
        public long RefId { get; set; }
        public string Fpid { get; set; }
        public string Fpvalue { get; set; }
        public int? AId { get; set; }
        public Guid WId { get; set; }
        public string Pcname { get; set; }
        public short? LuserId { get; set; }
        public int? WeekDayId { get; set; }
        public decimal? MobileAllow { get; set; }
        public string MobileNo { get; set; }
        public decimal? OldGs { get; set; }
        public decimal? TaxGs { get; set; }
        public string GradeIns { get; set; }
        public string Band { get; set; }
        public string BandIncen { get; set; }
        public string SubBandIncen { get; set; }
        public string Category { get; set; }
        public string BusStop { get; set; }
        public byte IsTiffin { get; set; }
        public byte IsIncenBonus { get; set; }
        public byte IsSalary { get; set; }
        public short? DeptId { get; set; }
        public short? SubSectId { get; set; }
        public decimal OtherAllow { get; set; }
        public DateTime? DtIncrement { get; set; }
        public short? ShiftIdR { get; set; }
        public decimal? PrevGross { get; set; }
        public byte? HrappFirst { get; set; }
        public byte? HrAppFinal { get; set; }
        public string Mpass { get; set; }
        public byte? IsAllowGradeBns { get; set; }
        public byte? IsAllowShortfall { get; set; }
    }
}
