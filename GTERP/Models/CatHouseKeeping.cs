using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTERP.Models
{

    public partial class Cat_Department
    {
        public Cat_Department()
        {
            //HrTempAttend = new HashSet<HrTempAttend>();
            //HrTempAttendMonth = new HashSet<HrTempAttendMonth>();
            Cat_Section = new HashSet<Cat_Section>();
            Cat_SubSection = new HashSet<Cat_SubSection>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeptId { get; set; }

        public string ComId { get; set; }

        [Display(Name = "Department Code")]
        //[StringLength()]
        public string DeptCode { get; set; }

        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "Please Provide Department Name")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        //[Remote(action: "IsExist", controller: "Department")]
        public string DeptName { get; set; }

        [Display(Name = "Department Name Bangla")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string DeptBangla { get; set; }

        [Display(Name = "SL No")]
        public short? Slno { get; set; }

        public string PcName { get; set; }
        [StringLength(128)]
        public string UserId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtInput { get; set; }


        //public virtual Cat_Company Com { get; set; }
        //public virtual ICollection<HrTempAttend> HrTempAttend { get; set; }
        //public virtual ICollection<HrTempAttendMonth> HrTempAttendMonth { get; set; }

        public virtual ICollection<Cat_Section> Cat_Section { get; set; }
        public virtual ICollection<Cat_SubSection> Cat_SubSection { get; set; }
    }

    public partial class Cat_Section
    {
        public Cat_Section()
        {
            //HrTempAttend = new HashSet<HrTempAttend>();
            //HrTempAttendMonth = new HashSet<HrTempAttendMonth>();
            Cat_SubSection = new HashSet<Cat_SubSection>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SectId { get; set; }

        public string ComId { get; set; }
        [Display(Name = "Section Name")]
        [Required(ErrorMessage = "Please Provide Section Name")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string SectName { get; set; }

        [Display(Name = "Section Bangla")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string SectNameB { get; set; }

        [Display(Name = "Department")]
        public int? DeptId { get; set; }
        public virtual Cat_Department Dept { get; set; }

        [Display(Name = "SL NO")]
        public int Slno { get; set; }

        //public short? CostSect { get; set; }
        //public short? CostSubSect { get; set; }
        //public decimal? CostSectTotal { get; set; }
        //[DataType(DataType.MultilineText)]
        //public string Remarks { get; set; }

        public string PcName { get; set; }
        [StringLength(128)]
        public string UserId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtInput { get; set; }


        //public virtual ICollection<HrTempAttend> HrTempAttend { get; set; }
        // public virtual ICollection<HrTempAttendMonth> HrTempAttendMonth { get; set; }
        public virtual ICollection<Cat_SubSection> Cat_SubSection { get; set; }
    }

    public partial class Cat_SubSection
    {
        public Cat_SubSection()
        {
            //HrTempAttend = new HashSet<HrTempAttend>();
            //HrTempAttendMonth = new HashSet<HrTempAttendMonth>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubSectId { get; set; }

        public string ComId { get; set; }
        [Display(Name = "Sub Section Name")]
        [Required(ErrorMessage = "Please Provide Sub Section Name")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string SubSectName { get; set; }
        [Display(Name = "Sub Section Bangla")]
        public string SubSectNameB { get; set; }

        [Display(Name = "Section Name")]
        public int SectId { get; set; }
        [Display(Name = "Department Name")]
        public int DeptId { get; set; }

        [Display(Name = "SL NO")]
        public short Slno { get; set; }


        public string PcName { get; set; }
        [DataType("NVARCHAR(128)")]
        public string UserId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtInput { get; set; }

        //public virtual Cat_Company Com { get; set; }
        [ForeignKey("DeptId")]
        public virtual Cat_Department Dept { get; set; }
        [ForeignKey("SectId")]

        public virtual Cat_Section Sect { get; set; }
        //public virtual ICollection<HrTempAttend> HrTempAttend { get; set; }
        //public virtual ICollection<HrTempAttendMonth> HrTempAttendMonth { get; set; }
    }

    public partial class Cat_Designation
    {
        public Cat_Designation()
        {
            //HrTempAttendMonth = new HashSet<HrTempAttendMonth>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DesigId { get; set; }
        public string ComId { get; set; }

        [Display(Name = "Designation Name")]
        [Required(ErrorMessage = "Please Provide Desingation Name")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string DesigName { get; set; }

        [Display(Name = "Designation Bangla")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string DesigNameB { get; set; }

        [Display(Name = "Salary Range")]
        [StringLength(40)]
        public string SalaryRange { get; set; }

        [Display(Name = "Sl No")]
        public int? SlNo { get; set; }
        [Display(Name = "Minimum GS")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Gsmin { get; set; }

        [Display(Name = "Grade")]
        public int? GradeId { get; set; }
        public virtual Cat_Grade Grade { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal AttBonus { get; set; }

        [Display(Name = "Total Manpower")]
        public int? TtlManpower { get; set; }

        [Display(Name = "Total Manpower")]
        public int? ProposedManPower { get; set; }


        public string PcName { get; set; }

        [DataType("NVARCHAR(128)")]
        public string UserId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtInput { get; set; }


        //public virtual Cat_Company Com { get; set; }
        //public virtual ICollection<HrTempAttendMonth> HrTempAttendMonth { get; set; }
    }

    public partial class Cat_Grade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GradeId { get; set; }



        [Display(Name = "Grade Name")]
        [Required(ErrorMessage = "Please Input Grade Name.")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string GradeName { get; set; }

        [Display(Name = "Grade Bangla")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string GradeNameB { get; set; }

        [Display(Name = "Minimum GS")]
        public double? MinGS { get; set; }

        [Display(Name = "Total Manpower")]
        public int? TtlManpower { get; set; }

        [Display(Name = "Salary Range")]
        [StringLength(30)]
        public string SalaryRange { get; set; }

        [Display(Name = "Total Man Power Worker")]
        public int? TtlManPowerWorker { get; set; }

        [Display(Name = "SL No")]
        public int? SlNo { get; set; }


        public string ComId { get; set; }

        public string PcName { get; set; }
        [DataType("NVARCHAR(128)")]
        public string UserId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtInput { get; set; }
    }

    public partial class Cat_Religion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RelgionId { get; set; }

        [Display(Name = "Religion Name")]
        [Required(ErrorMessage = "Please Provide Religion Name")]
        [StringLength(20)]
        [DataType("NVARCHAR(20)")]
        public string ReligionName { get; set; }

        [Display(Name = "Religion Bangla")]
        [Required(ErrorMessage = "Please Provide Religion Name Bangla")]
        [StringLength(20)]
        [DataType("NVARCHAR(20)")]
        public string ReligionNameB { get; set; }

        public string ComId { get; set; }

        public string PcName { get; set; }
        [StringLength(128)]
        public string UserId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtInput { get; set; }
    }



    public partial class Cat_BloodGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BloodId { get; set; }

        [Display(Name = "Blood Group")]
        [Required(ErrorMessage = "Plz input Blood Group Name")]
        [StringLength(30)]
        [DataType("nvarchar(40)")]
        public string BloodName { get; set; }

        [Display(Name = "Blood Group Bangla")]
        [StringLength(30)]
        [DataType("nvarchar(40)")]
        public string BloodNameB { get; set; }

        public string ComId { get; set; }

        public string PcName { get; set; }
        [StringLength(128)]
        public string UserId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtInput { get; set; }

    }

    public partial class Cat_Line
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LineId { get; set; }

        [Display(Name = "Line Name")]
        [Required(ErrorMessage = "Plz input Line Name")]
        [StringLength(30)]
        [DataType("nvarchar(40)")]
        public string LineName { get; set; }

        [Display(Name = "Line Bangla")]
        [StringLength(30)]
        [DataType("nvarchar(25)")]
        public string LineNameB { get; set; }

        public string ComId { get; set; }

        public string PcName { get; set; }
        [StringLength(128)]
        public string UserId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtInput { get; set; }
    }

    public partial class Cat_Shift
    {
        public Cat_Shift()
        {
            //HrTempAttend = new HashSet<HrTempAttend>();
        }

        public string ComId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShiftId { get; set; }

        [Display(Name = "Shift Name")]
        [Required(ErrorMessage = "Please Provide Shift Name")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string ShiftName { get; set; }

        [Display(Name = "Shift Code")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string ShiftCode { get; set; }

        [Display(Name = "Shift Description")]
        [StringLength(200)]
        public string ShiftDesc { get; set; }

        [Display(Name = "Shift In")]

        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime ShiftIn { get; set; }
        [Display(Name = "Shift Out")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime ShiftOut { get; set; }

        [Display(Name = "Shift Late")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime ShiftLate { get; set; }

        [Display(Name = "Lunch Time")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime LunchTime { get; set; }

        [Display(Name = "Lunch In")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime LunchIn { get; set; }

        [Display(Name = "Lunch Out")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime LunchOut { get; set; }

        [Display(Name = "Tiffin Time")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime TiffinTime { get; set; }

        [Display(Name = "Tiffin In")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime TiffinIn { get; set; }


        [Display(Name = "Tiffin Out")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime TiffinOut { get; set; }


        [Display(Name = "Regular Hour")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime RegHour { get; set; }

        [Display(Name = "Shift Type")]
        public string ShiftType { get; set; }

        [Display(Name = "Shift Cat")]
        public string ShiftCat { get; set; }

        [Display(Name = "Is Inactive")]
        public bool IsInactive { get; set; }

        [Display(Name = "Tiffin Time 1")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? TiffinTime1 { get; set; }

        [Display(Name = "Tiffin Time In 1")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? TiffinTimeIn1 { get; set; }

        [Display(Name = "Tiffin Time 2")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? TiffinTime2 { get; set; }

        [Display(Name = "Tiffin Time In 2")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? TiffinTimeIn2 { get; set; }

        public string PcName { get; set; }
        [StringLength(128)]
        public string UserId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtInput { get; set; }

        //public virtual Cat_Company Com { get; set; }
        //public virtual ICollection<HrTempAttend> HrTempAttend { get; set; }
    }

    public partial class Cat_Floor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FloorId { get; set; }

        [Display(Name = "Floor Name")]
        [Required(ErrorMessage = "Plz input Floor Name")]
        [StringLength(30)]
        [DataType("nvarchar(40)")]
        public string FloorName { get; set; }

        [Display(Name = "Floor Bangla")]
        [StringLength(30)]
        [DataType("nvarchar(25)")]
        public string FloorNameB { get; set; }

        public string ComId { get; set; }

        public string PcName { get; set; }
        [StringLength(128)]
        public string UserId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtInput { get; set; }
    }

    public partial class Cat_Unit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UnitId { get; set; }

        [Display(Name = "Unit Name")]
        [Required(ErrorMessage = "Plz input Unit Name")]
        [StringLength(30)]
        [DataType("nvarchar(30)")]
        public string UnitName { get; set; }

        [Display(Name = "Short Name")]
        [StringLength(30)]
        [DataType("nvarchar(30)")]
        public string UnitShortName { get; set; }

        [Display(Name = "Unit Bangla")]
        [StringLength(30)]
        [DataType("nvarchar(25)")]
        public string UnitNameB { get; set; }

        public string ComId { get; set; }

        public string PcName { get; set; }
        [StringLength(128)]
        public string UserId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtInput { get; set; }
    }
    public partial class Cat_District
    {
        public Cat_District()
        {
            //Cat_Employee = new HashSet<Cat_Employee>();
            //Cat_PoliceStations = new HashSet<Cat_PoliceStation>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DistId { get; set; }

        [Display(Name = "District Name")]
        [Required(ErrorMessage = "Please Provide District Name")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string DistName { get; set; }

        [Display(Name = "District Bangla")]
        [Required(ErrorMessage = "Please Provide District Name Bangla")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string DistNameB { get; set; }

        [Display(Name = "Short Name")]
        [StringLength(15)]
        [DataType("NVARCHAR(15)")]
        public string DistNameShort { get; set; }

        [Display(Name = "SL No")]
        public int? SL { get; set; }


        //public int? CountryId { get; set; }
        //public virtual Cat_Country Country { get; set; }
        [StringLength(20)]
        public string PcName { get; set; }
        [StringLength(80)]
        public string ComId { get; set; }
        [StringLength(80)]
        public string UserId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtInput { get; set; }

        //public virtual ICollection<Cat_PoliceStation> Cat_PoliceStations { get; set; }
        //public virtual ICollection<Cat_Employee> Cat_Employee { get; set; }
    }

    public partial class Cat_PoliceStation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PStationId { get; set; }

        [Display(Name = "Police Station Name")]
        [Required(ErrorMessage = "Plz input Police Station Name")]
        [StringLength(30)]
        [DataType("nvarchar(30)")]
        public string PStationName { get; set; }

        [Display(Name = "Police Station Bangla")]
        [StringLength(30)]
        [DataType("nvarchar(25)")]
        public string PStationNameB { get; set; }

        [Display(Name = "District")]
        public int DistId { get; set; }
        [ForeignKey("DistId")]
        public virtual Cat_District Cat_District { get; set; }

        public string ComId { get; set; }

        public string PcName { get; set; }
        [StringLength(128)]
        public string UserId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtInput { get; set; }
    }




    public partial class Cat_Integration_Setting_Main
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IntegrationSettingMainId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Plz input Name")]
        [StringLength(50)]
        public string IntegrationSettingName { get; set; }

        [Display(Name = "Integration Table Name")]
        [StringLength(100)]
        public string IntegrationTableName { get; set; }


        [Display(Name = "Integration Remarks")]
        [DataType(DataType.MultilineText)]
        public string IntegrationRemarks { get; set; }


        public virtual ICollection<Cat_Integration_Setting_Details> Cat_Integration_Setting_Details { get; set; }


        [Display(Name = "Primary Serial No")]
        [StringLength(10)]
        public string MainSLNo { get; set; }



        [StringLength(128)]
        public string ComId { get; set; }
        [StringLength(200)]
        public string PcName { get; set; }
        [StringLength(128)]
        public string UserId { get; set; }
        public Nullable<DateTime> DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public Nullable<DateTime> DateUpdated { get; set; }


        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        [Display(Name = "Voucher Type")]
        public int? VoucherTypeId { get; set; }

        [ForeignKey("VoucherTypeId")]
        public virtual Acc_VoucherType Acc_VoucherType { get; set; }


    }


    public partial class Cat_Integration_Setting_Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IntegrationSettingDetailsId { get; set; }


        public int IntegrationSettingMainId { get; set; }
        [ForeignKey("IntegrationSettingMainId")]
        public virtual Cat_Integration_Setting_Main Cat_Integration_Setting_Mains { get; set; }




        [Display(Name = "Account/Salary Head Name")]
        public int AccId { get; set; }
        [ForeignKey("AccId")]
        public virtual Acc_ChartOfAccount Acc_ChartOfAccounts { get; set; }

        [NotMapped]
        public string[] Columns { get; set; }

        [Display(Name = "Payroll Table Column Name")]
        [StringLength(1000)]

        public string SelectColumnNameOne { get; set; }

        public int ConditionCount { get; set; }

        [Display(Name = "Where 1st Condition")]
        [StringLength(200)]
        public string ColNameOne { get; set; }

        [Display(Name = "1st Cond. Value")]
        [StringLength(200)]
        public string colNameOneValue { get; set; }//OtherLinkOne

        [Display(Name = "And 2nd Condition")]
        [StringLength(200)]
        public string ColNameTwo { get; set; }

        [Display(Name = "2nd Cond. Value")]
        [StringLength(200)]
        public string colNameTwoValue { get; set; }//OtherLineTwo


        [Display(Name = "And 3rd Condition")]
        [StringLength(200)]
        public string ColNameThree { get; set; }

        [Display(Name = "3rd Cond. Value")]
        [StringLength(200)]
        public string colNameThreeValue { get; set; }//OtherLineTwo

        [Display(Name = "And 4th Condition")]
        [StringLength(200)]
        public string ColNameFour { get; set; }

        [Display(Name = "4th Cond. Value")]
        [StringLength(200)]
        public string colNameFourValue { get; set; }//OtherLineTwo


        [Display(Name = "Serial No")]

        public int SLNo { get; set; }


        public string SelectStatement { get; set; }

        public string WhereCondition { get; set; }


        public string ColNameOneGroupBy { get; set; }
        public string ColNameTwoGroupBy { get; set; }
        public string ColNameThreeGroupBy { get; set; }
        public string ColNameFourGroupBy { get; set; }
        public string GroupByCondition { get; set; }




        [Display(Name = "Remarks")]
        [StringLength(300)]
        public string Remarks { get; set; }




        public bool IsSubtract { get; set; }

        [Display(Name = "Is Debit")]

        public bool IsDebit { get; set; }


        [Display(Name = "Is Credit")]

        public bool IsCredit { get; set; }

        [NotMapped]
        public bool IsDelete { get; set; }

        [StringLength(128)]
        public string ComId { get; set; }

        [StringLength(128)]
        public string PcName { get; set; }
        [StringLength(128)]
        public string UserId { get; set; }
        public Nullable<DateTime> DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public Nullable<DateTime> DateUpdated { get; set; }

    }


    public partial class Cat_PayrollIntegrationSummary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cat_PayrollIntegrationSummaryId { get; set; }

        [Display(Name = "Data Type")]
        [DataType("nvarchar(200)")]
        public string DataType { get; set; }

        [Display(Name = "Employee Type")]
        [DataType("nvarchar(200)")]
        public string EmployeeType { get; set; }


        [Display(Name = "Account/Salary Head Name")]
        public int AccId { get; set; }
        [ForeignKey("AccId")]
        public virtual Acc_ChartOfAccount Acc_ChartOfAccounts { get; set; }


        [Display(Name = "Fiscal Year")]
        public int? FiscalYearId { get; set; }
        [ForeignKey("FiscalYearId")]
        public virtual Acc_FiscalYear Acc_FiscalYears { get; set; }


        [Display(Name = "Fiscal Month")]
        public int? FiscalMonthId { get; set; }
        [ForeignKey("FiscalMonthId")]
        public virtual Acc_FiscalMonth Acc_FiscalMonths { get; set; }

        public double TKDebitLocal { get; set; }
        public double TKCreditLocal { get; set; }


        [Display(Name = "Serial No")]

        public string SLNo { get; set; }





        public string ComId { get; set; }

        public string PcName { get; set; }
        [StringLength(128)]
        public string UserId { get; set; }
        public Nullable<DateTime> DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public Nullable<DateTime> DateUpdated { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }


        public string Note1 { get; set; }
        public string Note2 { get; set; }
        public string Note3 { get; set; }
        public string Remarks { get; set; }

    }




    public partial class Cat_BusStop
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BusStopId { get; set; }

        [Display(Name = "Bus Stop Name")]
        [Required(ErrorMessage = "Please Provide Bus Stop Name")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string BusStopName { get; set; }

        public float Rate { get; set; }

        [StringLength(150)]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        public bool IsInactive { get; set; }

        [StringLength(128)]
        public string ComId { get; set; }


        public string PcName { get; set; }
        [DataType("NVARCHAR(128)")]
        public string UserId { get; set; }
        public DateTime? DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public DateTime? DateUpdated { get; set; }

    }

    public partial class Cat_ExchangeRate
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExChangeId { get; set; }

        [Display(Name = "Exchange Rate")]
        [Required(ErrorMessage = "Please provide Exchange Rate")]
        //[StringLength(25)]
        //[DataType("NVARCHAR(25)")]
        public float ExchangeRate { get; set; }



        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime? DtInput { get; set; }

        [StringLength(128)]
        public string ComId { get; set; }


        public string PcName { get; set; }
        [DataType("NVARCHAR(128)")]
        public string UserId { get; set; }
        public DateTime? DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public DateTime? DateUpdated { get; set; }


    }

    public partial class Cat_IncenBand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InBId { get; set; }

        [Display(Name = "IncenBand Name")]
        [Required(ErrorMessage = "Please Input Grade Name.")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string IncenBandName { get; set; }

        [Display(Name = "Remarks")]
        [StringLength(25)]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        [Display(Name = "SLNO")]
        public int SlNo { get; set; }

        [Display(Name = "IsInactive")]
        public bool IsInactive { get; set; }

        public string ComId { get; set; }

        [StringLength(25)]
        public string PcName { get; set; }

        [DataType("NVARCHAR(128)")]
        public string UserId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public DateTime? DateUpdated { get; set; }
    }

    public partial class Cat_Catagory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CatId { get; set; }

        [Display(Name = "Catagory Name")]
        [Required(ErrorMessage = "Please Input Grade Name.")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string CatName { get; set; }

        [Display(Name = "Remarks")]
        [StringLength(25)]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        [Display(Name = "SLNO")]
        public int SlNo { get; set; }

        [Display(Name = "IsInactive")]
        public bool IsInactive { get; set; }

        public string ComId { get; set; }

        [StringLength(25)]
        public string PcName { get; set; }
        [DataType("NVARCHAR(128)")]
        public string UserId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }

    }

    public partial class Cat_InsurGrade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InGId { get; set; }

        [Display(Name = "InSurance Grade Name")]
        [Required(ErrorMessage = "Please Input Grade Name.")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string InSurGrade { get; set; }

        [Display(Name = "Amount")]
        public int Amount { get; set; }

        [Display(Name = "Remarks")]
        [StringLength(25)]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        [Display(Name = "SLNO")]
        public int SlNo { get; set; }

        [Display(Name = "IsInactive")]
        public bool IsInactive { get; set; }

        [DataType("NVARCHAR(128)")]
        public string ComId { get; set; }

        [StringLength(25)]
        public string PcName { get; set; }
        [DataType("NVARCHAR(128)")]
        public string UserId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
    }

    public partial class Cat_Area
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short AreaId { get; set; }
        public string AreaName { get; set; }
        public string AreaNameShort { get; set; }
        public string AreaCode { get; set; }

        //public short? CountryId { get; set; }

        public string Pcname { get; set; }
        public string UserId { get; set; }
        public string ComId { get; set; }

        //public virtual Cat_Country Country { get; set; }
    }

    public partial class Cat_Article
    {
        public Cat_Article()
        {
            //TblStrBomArticle = new HashSet<TblStrBomArticle>();
            //TblStrChemicalBatchMain = new HashSet<TblStrChemicalBatchMain>();
            //TblStrPuArticle = new HashSet<TblStrPuArticle>();
        }

        public string ComId { get; set; }
        [Key]
        public int ArticleId { get; set; }
        public string ArticleNo { get; set; }
        public string ArticleName { get; set; }
        public short BuyerId { get; set; }
        public short ColorId { get; set; }
        public string Iman { get; set; }
        public string StandSize { get; set; }
        public string SizeRange { get; set; }
        public float MatOrdExess { get; set; }
        public string UserId { get; set; }
        public string Pcname { get; set; }



        public string MouldName { get; set; }
        public string PackingAssort { get; set; }
        public string MouldCode { get; set; }
        public string ArtImageName { get; set; }
        public string Remarks { get; set; }

        public virtual Cat_Buyer Buyer { get; set; }
        public virtual Cat_Color Color { get; set; }
        public virtual Cat_Company Com { get; set; }
        //public virtual ICollection<TblStrBomArticle> TblStrBomArticle { get; set; }
        //public virtual ICollection<TblStrChemicalBatchMain> TblStrChemicalBatchMain { get; set; }
        //public virtual ICollection<TblStrPuArticle> TblStrPuArticle { get; set; }
    }

    public partial class Cat_Bank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BankId { get; set; }

        [Display(Name = "Bank Name")]
        [Required(ErrorMessage = "Please input Bank Name")]
        [StringLength(60)]
        [DataType("nvarchar(60)")]
        public string BankName { get; set; }

        [Display(Name = "Short Name")]
        [StringLength(40)]
        [DataType("nvarchar(40)")]
        public string BankShortName { get; set; }

        [Display(Name = "Bank Address")]
        [StringLength(250)]
        [DataType("nvarchar(250)")]
        public string BankAddress { get; set; }

        public string ComId { get; set; }

        public string PcName { get; set; }
        [StringLength(80)]
        public string UserId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtInput { get; set; }
    }

    public partial class Cat_BankBranch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BranchId { get; set; }

        [Display(Name = "Branch Name")]
        [Required(ErrorMessage = "Please input Branch Name")]
        [StringLength(70)]
        [DataType("nvarchar(70)")]
        public string BranchName { get; set; }

        [Display(Name = "Branch Address")]
        [StringLength(250)]
        [DataType("nvarchar(250)")]
        public string BranchAddress { get; set; }

        public string ComId { get; set; }

        public string PcName { get; set; }
        [StringLength(80)]
        public string UserId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtInput { get; set; }
    }

    public partial class Cat_PayMode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PayModeId { get; set; }

        [Display(Name = "Pay Mode")]
        [StringLength(25)]
        public string PayModeName { get; set; }
    }
    public partial class Cat_AccountType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccTypeId { get; set; }

        [Display(Name = "Account Type")]
        [StringLength(25)]
        public string AccTypeName { get; set; }
    }

    public partial class Cat_Bomtype
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short BomtypeId { get; set; }
        public string BomtypeName { get; set; }
        public string Pcname { get; set; }
        public string UserId { get; set; }

        public short Slno { get; set; }

        public string ComId { get; set; }

        public virtual Cat_Company Com { get; set; }
    }

    public partial class Cat_Business
    {
        public string ComId { get; set; }

        public short Buid { get; set; }
        public string Buname { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AId { get; set; }
        public short Cpid { get; set; }
        public string Cpname { get; set; }
        public string Pcname { get; set; }
        public string UserId { get; set; }

        public virtual Cat_Company Com { get; set; }
    }


    public partial class Cat_Buyer
    {
        public Cat_Buyer()
        {
            Cat_Article = new HashSet<Cat_Article>();
            //TblOrderMain = new HashSet<TblOrderMain>();
            //TblStrReplaceSub1 = new HashSet<TblStrReplaceSub1>();
        }

        public short BuyerId { get; set; }
        public string BuyerCode { get; set; }
        public string BuyerName { get; set; }
        public string BuyerNameShort { get; set; }
        public string AddBiz { get; set; }
        public string AddShip { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public short CountryId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        public string Pcname { get; set; }
        public string UserId { get; set; }
        public string ComId { get; set; }
        public byte IsInactive { get; set; }
        public string BuyerGroup { get; set; }

        public virtual Cat_Company Com { get; set; }
        public virtual ICollection<Cat_Article> Cat_Article { get; set; }
        //public virtual ICollection<TblOrderMain> TblOrderMain { get; set; }
        //public virtual ICollection<TblStrReplaceSub1> TblStrReplaceSub1 { get; set; }
    }

    public partial class Cat_BuyerCont
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? AId { get; set; }
        public int? BuyerId { get; set; }
        public string Contperson { get; set; }
        public string Cat_Designation { get; set; }
        public string ContNo { get; set; }
        public string EMail { get; set; }
        public byte? Contid { get; set; }
        public Guid? Wid { get; set; }
        public string ComId { get; set; }
        public byte? RowNo { get; set; }

        public virtual Cat_Company Com { get; set; }
    }

    public partial class Cat_Cadre
    {
        public string ComId { get; set; }
        public int Cdid { get; set; }
        public string Position { get; set; }
        public string IdealSet { get; set; }
        public short? Mcdid { get; set; }
        public string Mposition { get; set; }
        public string Remarks { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AId { get; set; }
        public string Pcname { get; set; }
        public string UserId { get; set; }

        public virtual Cat_Company Com { get; set; }
    }

    public partial class Cat_CadreHeader
    {
        public string ComId { get; set; }
        public int Mcdid { get; set; }
        public string Mposition { get; set; }
        public string Remarks { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AId { get; set; }
        public string Pcname { get; set; }
        public string UserId { get; set; }

        public virtual Cat_Company Com { get; set; }
    }

    public partial class Cat_CadreUnit
    {
        public string ComId { get; set; }
        public int Cdid { get; set; }
        public string Position { get; set; }
        public string IdealSet { get; set; }
        public short? Mcdid { get; set; }
        public string Mposition { get; set; }
        public string Remarks { get; set; }
        public int Ideal { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AId { get; set; }
        public string Pcname { get; set; }
        public string UserId { get; set; }

        public virtual Cat_Company Com { get; set; }
    }

    public partial class Cat_Color
    {
        public Cat_Color()
        {
            Cat_Article = new HashSet<Cat_Article>();
            //TblStrProductDistribution = new HashSet<TblStrProductDistribution>();
            //TblStrReplaceSub2 = new HashSet<TblStrReplaceSub2>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short ColorId { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
        public string Phantom { get; set; }
        public string UserId { get; set; }
        public string Pcname { get; set; }




        public virtual ICollection<Cat_Article> Cat_Article { get; set; }
        //public virtual ICollection<TblStrProductDistribution> TblStrProductDistribution { get; set; }
        //public virtual ICollection<TblStrReplaceSub2> TblStrReplaceSub2 { get; set; }
    }

    public partial class Cat_Company
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ComId { get; set; }
        public string ComCode { get; set; }
        public string ComName { get; set; }
        public string ComNameB { get; set; }
        public string ComNameAvro { get; set; }
        public string ComAddress { get; set; }
        public string ComAddressB { get; set; }
        public string ComAddress2 { get; set; }
        public string ComAddress2B { get; set; }
        public string ComPhone { get; set; }
        public string ComPhone2 { get; set; }
        public string ComFax { get; set; }
        public string ComEmail { get; set; }
        public string ComWeb { get; set; }
        public string ComType { get; set; }
        public string ComAlias { get; set; }
        public string ComFinYear { get; set; }
        public string Description { get; set; }
        public string ContPerson { get; set; }
        public string ContDesig { get; set; }
        public byte IsGroup { get; set; }
        public byte IsShowCurrencySymbol { get; set; }
        public byte IsShowZeroBalance { get; set; }
        public byte IsInactive { get; set; }
        public string ImgName { get; set; }
        public string ImgName2 { get; set; }

        public string ComMain { get; set; }
        public byte? ComMainId { get; set; }
        public byte? IsVoucherChange { get; set; }
        public byte? IsCat_SubSection { get; set; }
        public byte? IsMultiCurrency { get; set; }
        public byte? IsChequeNo { get; set; }
        public string ComShortName { get; set; }
        public int? Processforproductid { get; set; }

        public virtual ICollection<HrAttFixed> HrAttFixed { get; set; }
        public virtual ICollection<HrEarnLeave> HrEarnLeave { get; set; }
        public virtual ICollection<HrEmpIncr> HrEmpIncr { get; set; }
        public virtual ICollection<HR_Emp_Info> HR_Emp_Info { get; set; }
        public virtual ICollection<HrEmpInfoBangla> HR_Emp_InfoBangla { get; set; }
        public virtual ICollection<HR_Emp_Released> HrEmpReleased { get; set; }
        public virtual ICollection<HR_Emp_Salary> HrEmpSalary { get; set; }
        public virtual ICollection<HrEmpShift> HrEmpShift { get; set; }
        public virtual ICollection<HrLeaveAvail> HrLeaveAvail { get; set; }

        public virtual ICollection<HrTemp> HrTemp { get; set; }
        public virtual ICollection<HrTempAttend> HrTempAttend { get; set; }
        public virtual ICollection<HrTempAttendMonth> HrTempAttendMonth { get; set; }
        public virtual ICollection<HrTempElBalance> HrTempElBalance { get; set; }
        public virtual ICollection<HrTempEmp> HrTempEmp { get; set; }
        public virtual ICollection<HrWeekday> HrWeekday { get; set; }
        public virtual ICollection<Cat_Article> Cat_Article { get; set; }
        public virtual ICollection<Cat_Bomtype> Cat_Bomtype { get; set; }
        public virtual ICollection<Cat_BusStop> Cat_BusStop { get; set; }
        public virtual ICollection<Cat_Business> Cat_Business { get; set; }
        public virtual ICollection<Cat_Buyer> Cat_Buyer { get; set; }
        public virtual ICollection<Cat_BuyerCont> Cat_BuyerCont { get; set; }
        public virtual ICollection<Cat_Cadre> Cat_Cadre { get; set; }
        public virtual ICollection<Cat_CadreHeader> Cat_CadreHeader { get; set; }
        public virtual ICollection<Cat_CadreUnit> Cat_CadreUnit { get; set; }


        public virtual ICollection<Cat_Currency> Cat_Currency { get; set; }
        public virtual ICollection<Cat_Department> Cat_Department { get; set; }
        public virtual ICollection<Cat_Designation> Desig { get; set; }
        public virtual ICollection<Cat_Employee> Cat_Employee { get; set; }
        public virtual ICollection<Cat_ExchangeRate> Cat_ExchangeRate { get; set; }
        public virtual ICollection<Cat_Shift> Cat_Shift { get; set; }
        public virtual ICollection<Cat_SubSection> Cat_SubSection { get; set; }
        //public virtual ICollection<TblExtraOtofficer> TblExtraOtofficer { get; set; }
        //public virtual ICollection<TblOtpermission> TblOtpermission { get; set; }
        //public virtual ICollection<TblProcessedDataSal> TblProcessedDataSal { get; set; }
        //public virtual ICollection<TblProcessedDataTemp> TblProcessedDataTemp { get; set; }
        //public virtual ICollection<TblSalArrear> TblSalArrear { get; set; }
        //public virtual ICollection<TblSalDue> TblSalDue { get; set; }
        //public virtual ICollection<TblSalIncomeTax> TblSalIncomeTax { get; set; }
        //public virtual ICollection<TblUserCompany> TblUserCompany { get; set; }
    }

    public partial class Cat_Country
    {
        public Cat_Country()
        {
            Cat_Area = new HashSet<Cat_Area>();
            Cat_District = new HashSet<Cat_District>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string CountrySname { get; set; }
        public string TimeDifference { get; set; }
        public string CurrName { get; set; }
        public string CurrSname { get; set; }
        public byte IsLocal { get; set; }

        public string Pcname { get; set; }
        public string UserId { get; set; }
        public virtual ICollection<Cat_Area> Cat_Area { get; set; }
        public virtual ICollection<Cat_District> Cat_District { get; set; }
    }

    public partial class Cat_Currency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public Guid? Wid { get; set; }
        public string ComId { get; set; }
        public string UserId { get; set; }

        public virtual Cat_Company Com { get; set; }
    }

    public partial class Cat_Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CustId { get; set; }
        public int AreaId { get; set; }
        public int ZoneId { get; set; }
        public string CustCode { get; set; }
        public string CustName { get; set; }
        public int CtypeId { get; set; }
        public string SrtName { get; set; }
        public string ContPerson { get; set; }
        public string Cat_Designation { get; set; }
        public string OrgName { get; set; }
        public string OrgType { get; set; }
        public string OrgAddress { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public double OpAmount { get; set; }
        public byte IsAllowCredit { get; set; }
        public int SalesRefId { get; set; }
        public double FreeBagBalance { get; set; }
        public int? AccId { get; set; }
        public string ComId { get; set; }
        public DateTime? DtOpen { get; set; }
        public long SalAccId { get; set; }
        public byte? IsAllowComission { get; set; }
        public int? AreaInchargeId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CreditLimit { get; set; }
        public int? Loctionid { get; set; }
        public int? Locationid { get; set; }
        public string Bdapprvdno { get; set; }
        public string UsFdaregNo { get; set; }

        public virtual Cat_CustomerType Ctype { get; set; }
    }

    public partial class Cat_CustomerInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Custid { get; set; }
        public string Custcode { get; set; }
        public string Custname { get; set; }
        public string Srtname { get; set; }
        public int AreaId { get; set; }
        public string BussAdd { get; set; }
        public string Billto { get; set; }
        public string Shipto { get; set; }
        public string Warehouse { get; set; }
        public string Home { get; set; }
        public string Legal { get; set; }
        public string Postal { get; set; }
        public string Other { get; set; }
        public int? Isinactive { get; set; }
        public DateTime? CustSince { get; set; }
        public string Currency { get; set; }
        public string Balance { get; set; }
        public DateTime? BalanceAsOf { get; set; }
        public string BusPhone { get; set; }
        public string Mobile { get; set; }
        public string AssistantPhone { get; set; }
        public string OtherPhone { get; set; }
        public string BusinessFax { get; set; }
        public string OtherFax { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string WebPageAddress { get; set; }
        public string SalesPerson { get; set; }
        public string SalesBalance { get; set; }
        public string FinCreditLimit { get; set; }
        public string FinPriceLevel { get; set; }
        public string FinCreditRating { get; set; }
        public string PreShipMet { get; set; }
        public string PrePayMet { get; set; }
        public string PaymentTerms { get; set; }
        public string CustGroup { get; set; }
        public string Logo { get; set; }
        public string TaxGroup { get; set; }
        public string CustStatus { get; set; }
        public string Zone { get; set; }


        public string BussType { get; set; }
        public DateTime DtStatusUpdate { get; set; }
        public byte IsHideInClist { get; set; }
        public byte UnderComId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? AdjAmount { get; set; }
        public DateTime? DtQrcodeGen { get; set; }
        public byte IsQrcodeGen { get; set; }
    }

    public partial class Cat_CustomerType
    {
        public Cat_CustomerType()
        {
            Cat_Customer = new HashSet<Cat_Customer>();
        }


        public string CtypeName { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CtypeId { get; set; }

        public DateTime? DtOrder { get; set; }
        public int? Priority { get; set; }

        public virtual ICollection<Cat_Customer> Cat_Customer { get; set; }
    }

    public partial class Cat_DeliverySite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DsiteId { get; set; }
        public string DsiteName { get; set; }

        public string Pcname { get; set; }
        public string UserId { get; set; }
        public byte? Comid { get; set; }
    }

    public partial class Cat_DepartmentOhid
    {
        public string ComId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeptId { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }

        public string Pcname { get; set; }
        public string UserId { get; set; }
        public string DeptBangla { get; set; }
        public short? Slno { get; set; }
        public int? ParentId { get; set; }
        public short? Buid { get; set; }
        public string Buname { get; set; }
        public string DptSrtName { get; set; }
        public byte? IsStrDpt { get; set; }
    }

    public partial class DesigCapacity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short DesigId { get; set; }
        public string ComId { get; set; }
        public short DeptId { get; set; }
        public short SectId { get; set; }

        public string DesigName { get; set; }
        public string Band { get; set; }
        public short? Capacity { get; set; }
        public byte? IsInactive { get; set; }

        public string Pcname { get; set; }
        public string UserId { get; set; }

    }

    public partial class Cat_Directory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AId { get; set; }
        public string DirApp { get; set; }
        public string DirGtr { get; set; }
        public string DirReport { get; set; }
        public string DirTemp { get; set; }
        public string DirPic { get; set; }
        public string Flag { get; set; }
    }

    public partial class Cat_Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DrId { get; set; }
        public string Name { get; set; }
        public string Degree { get; set; }
        public string RegNo { get; set; }
        public string MobileNo { get; set; }
        public string Pcname { get; set; }
        public string UserId { get; set; }
    }

    public partial class Cat_Employee
    {
        public string ComId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EmpId { get; set; }
        public string EmpCode { get; set; }
        public short EmpCodeFingure { get; set; }
        public string EmpName { get; set; }
        public string NickName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string PreAdd { get; set; }
        public string PerAdd { get; set; }
        public short PerDistId { get; set; }
        public short DeptId { get; set; }
        public short Cat_SectionId { get; set; }
        public int DesigId { get; set; }
        public string MobileNo { get; set; }
        public string MobileNo2 { get; set; }
        public string MobileEmarg { get; set; }
        public string Email { get; set; }
        public byte ReligionId { get; set; }
        public string Caste { get; set; }
        public byte BGroupId { get; set; }
        public string NationalId { get; set; }
        public string BirthCertificatNo { get; set; }
        public string PassportNo { get; set; }
        public byte IsInactive { get; set; }
        public DateTime? Dob { get; set; }
        public DateTime? Doj { get; set; }
        public string MaritailStatus { get; set; }
        public string Pcname { get; set; }
        public string UserId { get; set; }
        public virtual Cat_Company Com { get; set; }
        public virtual Cat_District PerDist { get; set; }
    }


    public partial class Cat_IncenSubBand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SubBand { get; set; }
        public string Band { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Amount { get; set; }
        public byte? ComId { get; set; }
        public byte? IsInactive { get; set; }


        public string Remarks { get; set; }
        public DateTime? DtDate { get; set; }
        public string ProssType { get; set; }
    }

    public partial class Cat_ItemEva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short EitemId { get; set; }
        public string EitemName { get; set; }
        public string EitemCode { get; set; }
        public short ArticleId { get; set; }
        public short BuyerId { get; set; }
        public short ColorId { get; set; }
        public short UnitId { get; set; }
        public string Hardness { get; set; }
        public string Thickness { get; set; }
        public string SheetSize { get; set; }
        public double QtyMetre { get; set; }
        public double ConvInch { get; set; }

        public double QtyForPair { get; set; }
        public byte IsPairWise { get; set; }
        public short TtlSheet { get; set; }
    }

    public partial class Cat_Leave_Type
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LTypeId { get; set; }
        [Display(Name = "Leave Type")]
        [Required(ErrorMessage = "Please Provide Leave Type.")]

        [StringLength(25)]
        public string LTypeName { get; set; }

        [Display(Name = "Short Name")]
        [StringLength(5)]
        public string LTypeNameShort { get; set; }

        [Display(Name = "Leave Days")]
        public float? LDays { get; set; }

        [StringLength(80)]
        public string ComId { get; set; }
    }

    public partial class Cat_Machine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MachineId { get; set; }
        public string MachineName { get; set; }
        public int DeptId { get; set; }
        public string Remarks { get; set; }
        public string ComId { get; set; }
        public string UserId { get; set; }
        public string Pcname { get; set; }


        public string MachineCode { get; set; }
        public string MachineSpec { get; set; }
        public int? SubSectId { get; set; }
        public double? PrdCapacity { get; set; }
        public int? PrdCapacityUnitId { get; set; }
    }

    public partial class Cat_MonthName
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short MonthId { get; set; }
        public string MonthName { get; set; }
        public string MonthNameB { get; set; }
        public int YearName { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public byte TotalDays { get; set; }
        public byte MonthSl { get; set; }
        public byte LockAttend { get; set; }
        public byte LockSalary { get; set; }
        public byte LockOt { get; set; }
        public byte LockBonus { get; set; }
        public byte LockIncrement { get; set; }

    }

    public partial class Cat_Operation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AId { get; set; }
        public string Operation { get; set; }
        public string Pcname { get; set; }
        public string UserId { get; set; }
    }

    public partial class Cat_PostOffice
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int POId { get; set; }

        [Display(Name = "Post Office Name")]
        [Required(ErrorMessage = "Plz input Post Office Name")]
        [StringLength(40)]
        [DataType("nvarchar(40)")]
        public string POName { get; set; }

        [Display(Name = "Post Office Code")]
        [StringLength(40)]
        [DataType("nvarchar(40)")]
        public string POCode { get; set; }

        [Display(Name = "Post Office Bangla")]
        [StringLength(40)]
        [DataType("nvarchar(40)")]
        public string PONameB { get; set; }

        [Display(Name = "District")]
        public int DistId { get; set; }
        [ForeignKey("DistId")]
        public virtual Cat_District Cat_District { get; set; }

        [Display(Name = "Police Station")]
        public int? PStationId { get; set; }
        [ForeignKey("PStationId")]
        public virtual Cat_PoliceStation Cat_PoliceStation { get; set; }

        public string ComId { get; set; }

        public string PcName { get; set; }
        [StringLength(128)]
        public string UserId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtInput { get; set; }

    }

    public partial class Cat_Skill
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillId { get; set; }

        [Display(Name = "Skill Name")]
        [StringLength(40)]
        [Required]
        public string SkillName { get; set; }

        [Display(Name = "Sikill Name Bangla")]
        [StringLength(40)]
        [DataType("nvarchar(40)")]
        public string SkillNameB { get; set; }


        [StringLength(128)]
        public string ComId { get; set; }

        [StringLength(25)]
        public string PcName { get; set; }
        [StringLength(128)]
        public string UserId { get; set; }
        public DateTime? DateAdded { get; set; }
        [StringLength(128)]
        public string UpdateByUserId { get; set; }
        public DateTime? DateUpdated { get; set; }
    }

    public partial class Cat_ProdCategory
    {
        public Cat_ProdCategory()
        {
            Cat_ProdSubCategory = new HashSet<Cat_ProdSubCategory>();
            //TblStrProduct = new HashSet<TblStrProduct>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short ProdCatId { get; set; }
        public string ProdCatName { get; set; }
        public string Pcname { get; set; }
        public string UserId { get; set; }


        public string ComId { get; set; }

        public virtual ICollection<Cat_ProdSubCategory> Cat_ProdSubCategory { get; set; }
        //public virtual ICollection<TblStrProduct> TblStrProduct { get; set; }
    }

    public partial class Cat_ProdSubCategory
    {
        public Cat_ProdSubCategory()
        {
            //TblStrProduct = new HashSet<TblStrProduct>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdScatId { get; set; }
        public string ProdScatName { get; set; }
        public short ProdCatId { get; set; }
        public string UserId { get; set; }
        public string Pcname { get; set; }


        public string PurchaseType { get; set; }
        public string ComId { get; set; }
        public int? Scslno { get; set; }

        public virtual Cat_ProdCategory ProdCat { get; set; }
        //public virtual ICollection<TblStrProduct> TblStrProduct { get; set; }
    }

    public partial class Cat_RowColour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short RowColourId { get; set; }
        public string RowColourName { get; set; }
        public string Pcname { get; set; }
        public string UserId { get; set; }

        public short Slno { get; set; }

        public string ComId { get; set; }
    }

    public partial class Cat_SalaryPerType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public byte SalId { get; set; }
        public string SalPerType { get; set; }
        public string Pcname { get; set; }
        public string UserId { get; set; }
    }

    public partial class Cat_ScratchCard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ScratchCardId { get; set; }
        public string ScratchCardname { get; set; }

        public string ComId { get; set; }
        public Guid? WId { get; set; }
        public string Pcname { get; set; }
        public string UserId { get; set; }
        public string ScratchCardCode { get; set; }
    }

    public partial class Cat_ShiftNight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short ShiftId { get; set; }
        public string ShiftCode { get; set; }
        public string ShiftName { get; set; }
        public string ShiftDesc { get; set; }
        public DateTime ShiftIn { get; set; }
        public DateTime ShiftOut { get; set; }
        public DateTime ShiftLate { get; set; }
        public DateTime LunchTime { get; set; }
        public DateTime LunchIn { get; set; }
        public DateTime LunchOut { get; set; }
        public DateTime TiffinTime { get; set; }
        public DateTime TiffinIn { get; set; }
        public DateTime TiffinOut { get; set; }
        public DateTime RegHour { get; set; }
        public string ShiftType { get; set; }
        public string ShiftCat { get; set; }
        public byte IsInactive { get; set; }


        public string Pcname { get; set; }
        public string UserId { get; set; }
        public byte? ComId { get; set; }
    }

    public partial class Cat_ShiftRamadan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short ShiftId { get; set; }
        public string ShiftCode { get; set; }
        public string ShiftName { get; set; }
        public string ShiftDesc { get; set; }
        public DateTime ShiftIn { get; set; }
        public DateTime ShiftOut { get; set; }
        public DateTime ShiftLate { get; set; }
        public DateTime LunchTime { get; set; }
        public DateTime LunchIn { get; set; }
        public DateTime LunchOut { get; set; }
        public DateTime TiffinTime { get; set; }
        public DateTime TiffinIn { get; set; }
        public DateTime TiffinOut { get; set; }
        public DateTime RegHour { get; set; }
        public string ShiftType { get; set; }
        public string ShiftCat { get; set; }
        public byte IsInactive { get; set; }


        public string Pcname { get; set; }
        public string UserId { get; set; }
        public byte? ComId { get; set; }
        public DateTime? TiffinTime1 { get; set; }
        public DateTime? TiffinTimeIn1 { get; set; }
        public DateTime? TiffinTime2 { get; set; }
        public DateTime? TiffinTimeIn2 { get; set; }
    }

    public partial class Cat_Size
    {
        public Cat_Size()
        {
            //TblStrArticleSizeSub = new HashSet<TblStrArticleSizeSub>();
            //TblStrExtraOrderSub = new HashSet<TblStrExtraOrderSub>();
            //TblStrOrderSub = new HashSet<TblStrOrderSub>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public short SizeId { get; set; }
        public string SizeName { get; set; }
        public string UserId { get; set; }
        public string Pcname { get; set; }


        public string ComId { get; set; }

        //public virtual ICollection<TblStrArticleSizeSub> TblStrArticleSizeSub { get; set; }
        //public virtual ICollection<TblStrExtraOrderSub> TblStrExtraOrderSub { get; set; }
        //public virtual ICollection<TblStrOrderSub> TblStrOrderSub { get; set; }
    }

    public partial class Cat_SpecType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short SpecTypeId { get; set; }
        public string SpecTypeName { get; set; }
        public string Pcname { get; set; }
        public string UserId { get; set; }

        public string ComId { get; set; }
    }

    public partial class Cat_Style
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StyleId { get; set; }
        public string StyleNo { get; set; }
        public short BuyerId { get; set; }
        public string UserId { get; set; }
        public string Pcname { get; set; }

    }

    public partial class Cat_Supplier
    {
        public Cat_Supplier()
        {
            //TblStrProductDistribution = new HashSet<TblStrProductDistribution>();
            //TblStrProductSupplier = new HashSet<TblStrProductSupplier>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierId { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string SupplierNameShort { get; set; }
        public string AddBiz { get; set; }
        public string AddShip { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public short CountryId { get; set; }


        public string Pcname { get; set; }
        public string UserId { get; set; }
        public byte? Comid { get; set; }
        public byte? IsInactive { get; set; }
        public int? AccId { get; set; }

        //public virtual ICollection<TblStrProductDistribution> TblStrProductDistribution { get; set; }
        //public virtual ICollection<TblStrProductSupplier> TblStrProductSupplier { get; set; }
    }

    public partial class Cat_SupplierCont
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int? SupplierId { get; set; }
        public string Contperson { get; set; }
        public string Cat_Designation { get; set; }
        public string ContNo { get; set; }
        public string EMail { get; set; }
        public byte? Contid { get; set; }
        public Guid? Wid { get; set; }
        public byte? Comid { get; set; }
        public byte? RowNo { get; set; }
    }

    public partial class Cat_Terms
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TermsId { get; set; }
        public string TermsType { get; set; }
        public string TermsData { get; set; }
        public string UserId { get; set; }
        public string Pcname { get; set; }


    }

    public partial class Cat_TermsMain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TermsId { get; set; }
        public string TermsType { get; set; }
        public string UserId { get; set; }
        public string Pcname { get; set; }

        public byte? ComId { get; set; }
    }

    public partial class Cat_TermsSub
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TermsId { get; set; }
        public string TermsData { get; set; }
        public int? RowNo { get; set; }


    }

    public partial class Cat_Tiffin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CatTiffinId { get; set; }
        public string DesigName { get; set; }
        public byte PaidBothShift { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ShiftAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal GenAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ShiftAllow { get; set; }
        public string Pcname { get; set; }
        public string UserId { get; set; }
    }

    public partial class Cat_Truck
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Truckid { get; set; }
        public string TruckNo { get; set; }
        public int? TruckTypeId { get; set; }
        public Guid? Wid { get; set; }
        public byte? Comid { get; set; }
        public int? Userid { get; set; }
        public string TruckTypeNoNeed { get; set; }
    }

    public partial class Cat_TruckChallanBillVoucher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TruckChallanBillId { get; set; }
        public long Doid { get; set; }
        public string Dono { get; set; }
        public long CustId { get; set; }
        public DateTime DtDate { get; set; }
        public double Qty { get; set; }
        public double Aramount { get; set; }
        public double SalesVatamt { get; set; }
        public double CompRate { get; set; }
        public double SalesRate { get; set; }
        public double Vat { get; set; }
        public double Carrying { get; set; }
        public double Unloading { get; set; }
        public double Commission { get; set; }
        public int? Vataccid { get; set; }
        public int? Custaccid { get; set; }
        public int? Salaccid { get; set; }
        public int? Truckaccid { get; set; }
        public string Description { get; set; }
        public long? TruckChallanid { get; set; }
        public long? VatChallanId { get; set; }
        public byte? Comid { get; set; }
        public string UserId { get; set; }
    }

    public partial class Cat_TruckType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TruckTypeid { get; set; }
        public string TruckType { get; set; }
        public long? TruckAccId { get; set; }
        public byte? Comid { get; set; }
        public int? Userid { get; set; }
    }

    public partial class Cat_Type
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short TypeId { get; set; }
        public string TypeName { get; set; }
        public string Pcname { get; set; }
        public string UserId { get; set; }


        public string ComId { get; set; }
        public int? TypeSlno { get; set; }
    }

    public partial class Cat_UnitConversion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short FromUnitId { get; set; }
        public short ToUnitId { get; set; }
        public double FromUnitRate { get; set; }
        public double ToUnitRate { get; set; }

        public string Pcname { get; set; }
        public string UserId { get; set; }
    }

    public partial class Cat_Gender
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenderId { get; set; }

        [StringLength(30)]
        public string GenderName { get; set; }
        [StringLength(30)]
        public string GenderNameB { get; set; }

        [StringLength(80)]
        public string ComId { get; set; }

    }
    public partial class Cat_Emp_Type
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpTypeId { get; set; }

        [StringLength(30)]
        public string EmpTypeName { get; set; }
        [StringLength(30)]
        public string EmpTypeNameB { get; set; }

        [Display(Name = "Total Manpower")]
        public int? TtlManpower { get; set; }


        [StringLength(80)]
        public string ComId { get; set; }

        [StringLength(60)]
        public string PcName { get; set; }
        [StringLength(80)]
        public string UserId { get; set; }
        public DateTime? DateAdded { get; set; }
        [StringLength(80)]
        public string UpdateByUserId { get; set; }
        public DateTime? DateUpdated { get; set; }

    }

    public partial class Cat_VatParticulars
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VatId { get; set; }
        public string VatParticulars { get; set; }
        public string VatQtyType { get; set; }
        public double VatPrincipalValue { get; set; }
        public double BeforeTaka { get; set; }
        public double DiffTaka { get; set; }
        public int CountryId { get; set; }
        public int? Userid { get; set; }
        public string ComId { get; set; }
        public Guid? Wid { get; set; }
        public long? VatAcciD { get; set; }
        public int? Prdid { get; set; }
        public byte? IsExport { get; set; }
        public byte? IsVat { get; set; }
        public byte? IsOther { get; set; }
        public double? ExportValue { get; set; }
    }

    public partial class Cat_VisitorCompany
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VcomId { get; set; }
        public string VcomName { get; set; }
        public string VcomAddress { get; set; }
    }

    public partial class Cat_VoucherType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VoucherTypeId { get; set; }
        public string VtypeName { get; set; }
        public string VtypeNameShort { get; set; }
        public byte ModuleId { get; set; }
        public byte IsAll { get; set; }
        public byte SortNo { get; set; }

    }

    public partial class Cat_Warehouse
    {
        public Cat_Warehouse()
        {
            Cat_WarehouseBin = new HashSet<Cat_WarehouseBin>();
            //TblStrProductDistributionBin = new HashSet<TblStrProductDistributionBin>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WarehouseId { get; set; }
        public string ComId { get; set; }
        public short Whid { get; set; }
        public string Whcode { get; set; }
        public string Whname { get; set; }
        public string WhnameShort { get; set; }
        public int ParentId { get; set; }
        public string ParentCode { get; set; }
        public string Whtype { get; set; }


        public virtual ICollection<Cat_WarehouseBin> Cat_WarehouseBin { get; set; }
        //public virtual ICollection<TblStrProductDistributionBin> TblStrProductDistributionBin { get; set; }
    }

    public partial class Cat_WarehouseBin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte WarehouseBinId { get; set; }
        public string ComId { get; set; }
        public short BinId { get; set; }
        public string BinNo { get; set; }
        public string FloorNo { get; set; }
        public string RoomNo { get; set; }
        public string RackNo { get; set; }
        public string CellNo { get; set; }
        public string BinDetails { get; set; }
        public short Whid { get; set; }

        public string Pcname { get; set; }
        public string UserId { get; set; }

        public virtual Cat_Warehouse Wh { get; set; }
    }

    public partial class Cat_Zone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ZoneId { get; set; }
        public string Zonename { get; set; }
        public int? AreaId { get; set; }
        public string ComId { get; set; }
        public Guid? WId { get; set; }
        public string Pcname { get; set; }
        public string UserId { get; set; }
        public string ZoneCode { get; set; }
    }

    public partial class Cat_BuildingType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BId { get; set; }

        [Display(Name = "Building Name")]
        [Required(ErrorMessage = "Plz input Building Name")]
        [StringLength(30)]
        [DataType("nvarchar(30)")]
        public string BuildingName { get; set; }

        [Display(Name = "Building Short Name")]
        [StringLength(30)]
        [DataType("nvarchar(30)")]
        public string BuildingShortName { get; set; }

        [Display(Name = "Building Bangla")]
        [StringLength(30)]
        [DataType("nvarchar(25)")]
        public string BuildingNameB { get; set; }

        [StringLength(80)]
        public string ComId { get; set; }

        [StringLength(60)]
        public string PcName { get; set; }
        [StringLength(80)]
        public string UserId { get; set; }
        public DateTime? DateAdded { get; set; }
        [StringLength(80)]
        public string UpdateByUserId { get; set; }
        public DateTime? DateUpdated { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtInput { get; set; }
    }

    public partial class Cat_Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LId { get; set; }

        [Display(Name = "House Location Name")]
        [Required(ErrorMessage = "Plz input House Location Name")]
        [StringLength(30)]
        public string LocationName { get; set; }

        [Display(Name = "House Location Bangla")]
        [StringLength(30)]
        public string LocationNameB { get; set; }

        [Display(Name = "Location Name Short")]
        [StringLength(30)]
        public string LocationNameShort { get; set; }

        [Display(Name = "Location Name Short Bangla")]
        [StringLength(30)]
        public string LocationNameShortB { get; set; }

        [StringLength(80)]
        public string ComId { get; set; }

        [StringLength(60)]
        public string PcName { get; set; }

        [StringLength(80)]
        public string UserId { get; set; }
        public DateTime? DateAdded { get; set; }
        [StringLength(80)]
        public string UpdateByUserId { get; set; }
        public DateTime? DateUpdated { get; set; }
    }

    public partial class Cat_AttStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatusId { get; set; }

        [Display(Name = "Attend. Status")]
        [Required(ErrorMessage = "Please Provide Attendance Type.")]
        [StringLength(5)]
        public string AttStatus { get; set; }

        [Display(Name = "Attend. Status Details")]
        [StringLength(25)]
        public string AttStatusDetails { get; set; }

        [StringLength(80)]
        public string ComId { get; set; }
    }

    public partial class Cat_Variable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VarId { get; set; }

        [StringLength(80)]
        public string ComId { get; set; }

        [StringLength(30)]
        [Display(Name = "Name")]
        public string VarName { get; set; }

        [StringLength(20)]
        [Display(Name = "Type")]
        public string VarType { get; set; }

        [Display(Name = "Serial No")]
        public int SLNo { get; set; }

        [StringLength(80)]
        public string PcName { get; set; }

        [StringLength(80)]
        public string UserId { get; set; }

        public DateTime DtTran { get; set; } = DateTime.Now;

        public DateTime? DateAdded { get; set; }
        [StringLength(80)]
        public string UpdateByUserId { get; set; }
        public DateTime? DateUpdated { get; set; }
    }

    public partial class Cat_MedicalDiagnosis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiagId { get; set; }

        [Display(Name = "Diagnosis Name")]
        [StringLength(50)]
        public string DiagName { get; set; }

        [StringLength(80)]
        public string ComId { get; set; }

        [StringLength(80)]
        public string UserId { get; set; }

        public DateTime? DateAdded { get; set; }
        [StringLength(80)]
        public string UpdateByUserId { get; set; }

        public DateTime? DateUpdated { get; set; }
    }

    public partial class Cat_HRSetting
    {
        //Id, EmpType, HouseLocation, HouseCatagory, BS, HR, HRExp, MA, GasAllowance, GasCharge, ElectricCharge

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Employee Type")]
        public int EmpTypeId { get; set; }
        [ForeignKey("EmpTypeId")]
        public virtual Cat_Emp_Type Cat_Emp_Type { get; set; }

        [Display(Name = "House Location")]
        public int LId { get; set; }
        [ForeignKey("LId")]
        public virtual Cat_Location Cat_Location { get; set; }

        [Display(Name = "House Category")]
        public int? BId { get; set; }
        [ForeignKey("BId")]
        public virtual Cat_BuildingType Cat_BuildingType { get; set; }

        [Display(Name = "Basic")]
        public float BS { get; set; }

        [Display(Name = "House Rent")]
        [Required]
        public float HR { get; set; }


        [Display(Name = "Minimum HR")]
        public float? MinHR { get; set; }

        [Display(Name = "Medical Allownce")]
        public float MA { get; set; }

        [Display(Name = "Is Persentage")]
        public bool IsPersentage { get; set; }

        [StringLength(80)]
        public string ComId { get; set; }

        [StringLength(80)]
        public string UserId { get; set; }

        public DateTime? DateAdded { get; set; }
        [StringLength(80)]
        public string UpdateByUserId { get; set; }

        public DateTime? DateUpdated { get; set; }
    }
    public partial class Cat_HRExpSetting
    {
        //Id, EmpType, HouseLocation, HouseCatagory, BS, HR, HRExp, MA, GasAllowance, GasCharge, ElectricCharge

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Employee Type")]
        public int EmpTypeId { get; set; }
        [ForeignKey("EmpTypeId")]
        public virtual Cat_Emp_Type Cat_Emp_Type { get; set; }

        [Display(Name = "House Location")]
        public int LId { get; set; }
        [ForeignKey("LId")]
        public virtual Cat_Location Cat_Location { get; set; }

        [Display(Name = "House Category")]
        public int BId { get; set; }
        [ForeignKey("BId")]
        public virtual Cat_BuildingType Cat_BuildingType { get; set; }

        [Display(Name = "Basic")]
        public float BS { get; set; }

        [Display(Name = "H.R. Exp")]
        [Required]
        public float HRExp { get; set; }

        [Display(Name = "Is Persentage")]
        public bool IsPersentage { get; set; }


        [StringLength(80)]
        public string ComId { get; set; }

        [StringLength(80)]
        public string UserId { get; set; }

        public DateTime? DateAdded { get; set; }
        [StringLength(80)]
        public string UpdateByUserId { get; set; }

        public DateTime? DateUpdated { get; set; }
    }

    public partial class Cat_GasChargeSetting
    {
        //Id, EmpType, HouseLocation, HouseCatagory, BS, HR, HRExp, MA, GasAllowance, GasCharge, ElectricCharge

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Display(Name = "Employee Type")]
        //public int EmpTypeId { get; set; }
        //[ForeignKey("EmpTypeId")]
        //public virtual Cat_Emp_Type Cat_Emp_Type { get; set; }

        [Display(Name = "House Location")]
        public int LId { get; set; }
        [ForeignKey("LId")]
        public virtual Cat_Location Cat_Location { get; set; }

        [Display(Name = "House Category")]
        public int BId { get; set; }
        [ForeignKey("BId")]
        public virtual Cat_BuildingType Cat_BuildingType { get; set; }

        //[Display(Name = "Basic")]
        //[NotMapped]
        //public float BS { get; set; }

        [Display(Name = "Gas Charge")]
        [Required]
        public float GasCharge { get; set; }

        [Display(Name = "Is Persentage")]
        public bool IsPersentage { get; set; }

        [StringLength(80)]
        public string ComId { get; set; }

        [StringLength(80)]
        public string UserId { get; set; }

        public DateTime? DateAdded { get; set; }
        [StringLength(80)]
        public string UpdateByUserId { get; set; }

        public DateTime? DateUpdated { get; set; }
    }

    public partial class Cat_ElectricChargeSetting
    {
        //Id, EmpType, HouseLocation, HouseCatagory, BS, HR, HRExp, MA, GasAllowance, GasCharge, ElectricCharge

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Display(Name = "Employee Type")]
        //public int EmpTypeId { get; set; }
        //[ForeignKey("EmpTypeId")]
        //public virtual Cat_Emp_Type Cat_Emp_Type { get; set; }

        [Display(Name = "House Location")]
        public int LId { get; set; }
        [ForeignKey("LId")]
        public virtual Cat_Location Cat_Location { get; set; }

        [Display(Name = "House Category")]
        public int BId { get; set; }
        [ForeignKey("BId")]
        public virtual Cat_BuildingType Cat_BuildingType { get; set; }


        //[Display(Name = "Basic")]
        //[NotMapped]
        //public float BS { get; set; }

        [Display(Name = "Electric Charge")]
        [Required]
        public float ElectricCharge { get; set; }

        [Display(Name = "Is Persentage")]
        public bool IsPersentage { get; set; }

        [StringLength(80)]
        public string ComId { get; set; }

        [StringLength(80)]
        public string UserId { get; set; }

        public DateTime? DateAdded { get; set; }
        [StringLength(80)]
        public string UpdateByUserId { get; set; }

        public DateTime? DateUpdated { get; set; }
    }

    public class Cat_SummerWinterAllowanceSetting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SWAllowanceId { get; set; }
        public string ProssType { get; set; }
        public float SummerAllow { get; set; }
        public float WinterAllow { get; set; }
        public float RainCoatAndGumbootAllow { get; set; }
        public float VatDiduction { get; set; }
        public float TaxDiduction { get; set; }

        [StringLength(40)]
        [Display(Name = "Reference No")]
        public string ReferenceNo { get; set; }

        [StringLength(80)]
        public string ComId { get; set; }

        [StringLength(80)]
        public string UserId { get; set; }

        public DateTime? DateAdded { get; set; }
        [StringLength(80)]
        public string UpdateByUserId { get; set; }

        public DateTime? DateUpdated { get; set; }
    }

    public class Cat_IncomeTaxChk
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Pross Type")]
        [StringLength(12)]
        public string ProssType { get; set; }
        [Display(Name = "Is Stop Tax")]
        public bool IsStopTax { get; set; }
        [StringLength(80)]
        public string ComId { get; set; }
        [StringLength(80)]
        public string UserId { get; set; }
        public DateTime? DateAdded { get; set; }
        [StringLength(80)]
        public string UpdateByUserId { get; set; }
        public DateTime? DateUpdated { get; set; }
    }

    public class Cat_ITComputationSetting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Tax Computation")]
        public float TaxComputation { get; set; }
        public float Amount { get; set; }
        public float Rate { get; set; }
        // [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dtFrom { get; set; }
        // [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? dtTo { get; set; }
        [Display(Name = "Fiscal Year")]
        [StringLength(20)]
        public string FiscalYear { get; set; }
        [StringLength(80)]
        public string ComId { get; set; }
        [StringLength(80)]
        public string UserId { get; set; }
        public DateTime? DateAdded { get; set; }
        [StringLength(80)]
        public string UpdateByUserId { get; set; }
        public DateTime? DateUpdated { get; set; }
    }

    public class Cat_ITaxBank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Bank")]
        public int BankId { get; set; }
        [ForeignKey("BankId")]
        public Cat_Bank Cat_Bank { get; set; }


        [Display(Name = "Branch")]
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Cat_BankBranch Cat_BankBranch { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Moth Date")]
        public DateTime MonthDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Chq Date")]
        public DateTime ChqDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Chq No")]
        public string ChqNo { get; set; }

        [StringLength(80)]
        public string ComId { get; set; }
        [StringLength(80)]
        public string UserId { get; set; }
        public DateTime? DateAdded { get; set; }
        [StringLength(80)]
        public string UpdateByUserId { get; set; }
        public DateTime? DateUpdated { get; set; }
    }

    public partial class Cat_ReportSignatory
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SignatoryId { get; set; }

        [Display(Name = "Module")]
        [StringLength(30)]
        public string Module { get; set; }

        [Display(Name = "Report")]
        [StringLength(30)]
        public string ReportName { get; set; }


        [Display(Name = "Signatory1")]
        [Required]
        [StringLength(30)]
        public string Signatory1 { get; set; }

        [StringLength(30)]
        [Display(Name = "Signatory1 Bangla")]
        public string Signatory1B { get; set; }

        [Display(Name = "Signatory2")]
        [StringLength(30)]
        public string Signatory2 { get; set; }

        [StringLength(30)]
        [Display(Name = "Signatory2 Bangla")]
        public string Signatory2B { get; set; }

        [Display(Name = "Signatory3")]
        [StringLength(30)]
        public string Signatory3 { get; set; }

        [StringLength(30)]
        [Display(Name = "Signatory3 Bangla")]
        public string Signatory3B { get; set; }


        [Display(Name = "Signatory4")]
        [StringLength(30)]
        public string Signatory4 { get; set; }

        [StringLength(30)]
        [Display(Name = "Signatory4 Bangla")]
        public string Signatory4B { get; set; }


        [Display(Name = "Signatory5")]
        [StringLength(30)]
        public string Signatory5 { get; set; }

        [StringLength(30)]
        [Display(Name = "Signatory5 Bangla")]
        public string Signatory5B { get; set; }

        [Display(Name = "Signatory6")]
        [StringLength(30)]
        public string Signatory6 { get; set; }

        [StringLength(30)]
        [Display(Name = "Signatory6 Bangla")]
        public string Signatory6B { get; set; }

        public string PcName { get; set; }
        [StringLength(128)]
        public string ComId { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }
        public DateTime? DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public DateTime? DateUpdated { get; set; }

        [Display(Name = "From Date")]
        public DateTime FromDate { get; set; }

        [Display(Name = "To Date")]
        public DateTime ToDate { get; set; }


    }

}




