using GTERP.Models.Buffers;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTERP.Models.BufferSalesReportInput
{
    public class BufferSaleReportInput
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BufferSalesReportInputId { get; set; }
        [Display(Name = "Fiscal Year")]
        public int FiscalYearId { get; set; }
        [ForeignKey("FiscalYearId")]
        public virtual Acc_FiscalYear YearName { get; set; }
        [Display(Name = "Fiscal Month")]
        public int FiscalMonthId { get; set; }
        [ForeignKey("FiscalMonthId")]
        public virtual Acc_FiscalMonth MonthName { get; set; }
        [Display(Name = "Buffer")]
        public int BufferID { get; set; }
        [ForeignKey("BufferID")]
        public virtual BufferList BufferList { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtInput { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public float UnitPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public float ReciveByBuffer { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public float SalesByBuffer { get; set; }
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
}
