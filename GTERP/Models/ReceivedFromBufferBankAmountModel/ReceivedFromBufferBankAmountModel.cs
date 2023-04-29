using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Wordprocessing;
using GTERP.Models.Buffers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTERP.Models.ReceivedFromBufferBankAmountModel
{
    public class ReceivedFromBufferBankAmountsModels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BankAmountId { get; set; }
        [Display(Name = "Date")]
        public DateTime DtInput { get; set; }
        [ForeignKey(nameof(BufferList))]
        [Display(Name = "Buffer Name")]
        public int BufferId { get; set; }
        public BufferList BufferList { get; set; }
        [ForeignKey(nameof(Acc_FiscalYear))]
        [Display(Name = "Fiscal Year")]
        public int FiscalYearId { get; set; }
        public Acc_FiscalYear Acc_FiscalYear { get; set; }
        [ForeignKey(nameof(Acc_FiscalMonth))]
        [Display(Name = "Fiscal Month")]
        public int FiscalMonthId { get; set; }
        public Acc_FiscalMonth Acc_FiscalMonth { get; set; }
        [ForeignKey(nameof(Banks))]
        [Display(Name = "Bank")]
        public int BankID { get; set; }
        
        public BanksModel Banks { get; set; }
        public Double Amount { get; set; }
        [StringLength(255)]
        public string Note { get; set; }
        [StringLength(128)]
        public string comid { get; set; }

        [StringLength(128)]
        public string userid { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }


    // all banks Model
    public class BanksModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BankId { get; set; }
        [ForeignKey(nameof(BufferList))]
        [Display(Name = "Buffer Name")]
        public int BufferId { get; set; }
        public BufferList BufferList { get; set; }
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
        public string BranchName { get; set; }

        [StringLength(128)]
        public string comid { get; set; }

        [StringLength(128)]
        public string userid { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<ReceivedFromBufferBankAmountsModels> ReceivedFromBufferBankAmounts { get; set; }
    }
}
