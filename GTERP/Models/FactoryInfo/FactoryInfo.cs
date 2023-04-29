using GTERP.Models.Buffers;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTERP.Models.FactoryDapInfo
{
    public class FactoryInfomation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FactoryInfoId { get; set; }
        [Display(Name = "Fiscal Year")]
        public int FiscalYearId { get; set; }
        [ForeignKey("FiscalYearId")]
        public virtual Acc_FiscalYear YearName { get; set; }
        [Display(Name = "Fiscal Month")]
        public int FiscalMonthId { get; set; }
        [ForeignKey("FiscalMonthId")]
        public virtual Acc_FiscalMonth MonthName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtInput { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public float Production { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public float SalesDAPFCL { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public float OpeningBalance { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public float DOBalance { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public float? Deposit { get; set; }
        [NotMapped]
        public float TotalAllocated { get; set; }

        [StringLength(80)]
        public string ComId { get; set; }
        public string PcName { get; set; }
        [DataType("NVARCHAR(128)")]
        public string UserId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
    }
    public class BufferFactoryInfomation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int bufferFactoryInfoId { get; set; }
        [Display(Name = "Fiscal Year")]
        public int FiscalYearId { get; set; }
        [ForeignKey("FiscalYearId")]
        public virtual Acc_FiscalYear YearName { get; set; }
        [Display(Name = "Fiscal Month")]
        public int FiscalMonthId { get; set; }
        [ForeignKey("FiscalMonthId")]
        public virtual Acc_FiscalMonth MonthName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [ForeignKey(nameof(BufferList))]
        [Display(Name = "Buffer Name")]
        public int BufferId { get; set; }
        public BufferList BufferList { get; set; }
        public DateTime DtInput { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public float Production { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public float SalesDAPFCL { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public float OpeningBalance { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public float DOBalance { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public float? YearlyAllotmentMOA { get; set; }
        [NotMapped]
        public float TotalAllocated { get; set; }

        [StringLength(80)]
        public string ComId { get; set; }
        public string PcName { get; set; }
        [DataType("NVARCHAR(128)")]
        public string UserId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
    }


    public class BufferAllotment_MOA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MOA_ID { get; set; }
        [Display(Name = "Fiscal Year")]
        public int FiscalYearId { get; set; }
        [ForeignKey("FiscalYearId")]
        public virtual Acc_FiscalYear YearName { get; set; }
        [Display(Name = "Fiscal Month")]
        public int FiscalMonthId { get; set; }
        [ForeignKey("FiscalMonthId")]
        public virtual Acc_FiscalMonth MonthName { get; set; }


        [ForeignKey(nameof(BufferList))]
        [Display(Name = "Buffer Name")]
        public int BufferId { get; set; }
        public BufferList BufferList { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtInput { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public float? AllotmentMOA { get; set; }


        [StringLength(80)]
        public string ComId { get; set; }
        public string PcName { get; set; }
        [DataType("NVARCHAR(128)")]
        public string UserId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdateByUserId { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
    }


}
