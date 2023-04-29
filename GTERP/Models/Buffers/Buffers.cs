using GTERP.Models.BufferSalesReportInput;

//using AspNetCore;
using GTERP.Models.ReceivedFromBufferBankAmountModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GTERP.Models.OpeningBalance;
using GTERP.Models.FactoryDapInfo;
using GTERP.Controllers.Buffer;

namespace GTERP.Models.Buffers
{

    public partial class BufferRepresentative
    {

        public BufferRepresentative()
        {
            //BufferList = new HashSet<BufferList>();
        }

        public int BufferRepresentativeId { get; set; }
        [Required]
        [StringLength(60, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Carrier Code")]
        public string RepresentativeCode { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Carrier Name")]
        public string RepresentativeName { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Carrier Name Bangla")]
        public string RepresentativeNameBangla { get; set; }


        [Display(Name = "Carrier Address")]

        public string RepresentativeAddress { get; set; }

        [Display(Name = "Mobile No")]

        public string RepresentativeMobile { get; set; }

        [StringLength(128)]
        public string comid { get; set; }

        [StringLength(128)]
        public string userid { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }



        public virtual ICollection<RepresentativeBuffer> RepresentativeBuffer { get; set; }
        public virtual ICollection<BuffertWiseBooking> BuffertWiseBooking { get; set; }
        public virtual ICollection<BufferRepresentativeMember> BufferRepresentativeMember { get; set; }

    }
    public class BufferRepresentativeMember
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Name (Bangla)")]
        public string BanglaName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }


        public int BufferRepresentativeId { get; set; }

        public virtual BufferRepresentative Representative { get; set; }
        public virtual ICollection<BufferDelChallan> BufferDelChallan { get; set; }

    }

    public partial class BufferList
    {

        public BufferList()
        {
            //BufferRepresentativeList = new HashSet<BufferRepresentative>();
            //DistrictList = new HashSet<Cat_District>();
        }


        public int BufferListId { get; set; }
        [StringLength(80)]
        public string ComId { get; set; }

        [Required]
        [Display(Name = "Buffer Code")]
        public string BufferCode { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Buffer Name")]
        public string BufferName { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Buffer Name Bangla")]
        public string BufferNameBangla { get; set; }



        //public ICollection<Cat_District> DistrictList { get; set; }
        public virtual ICollection<ReceivedFromBufferBankAmountsModels> ReceivedFromBufferBankAmounts { get; set; }
        public virtual ICollection<BanksModel> BanksModels { get; set; }
        public virtual ICollection<BufferSaleReportInput> BufferSaleReportInputs { get; set; }
        public virtual ICollection<SalesOpening> SalesOpeningBalances { get; set; }
        public ICollection<RepresentativeBuffer> BufferRepresentativeList { get; set; }
        public ICollection<BufferFactoryInfomation> BufferFactoryInfomations { get; set; }
        public ICollection<DistictBuffer> DistictBuffer { get; set; }
       




    }


    public class RepresentativeBuffer
    {
        public int Id { get; set; }
        public int BufferListId { get; set; }
        public BufferList BufferList { get; set; }
        public int BufferRepresentativeId { get; set; }
        public BufferRepresentative Representative { get; set; }
    }


    public class DistictBuffer
    {
        public int Id { get; set; }
        public int BufferListId { get; set; }
        public BufferList BufferList { get; set; }
        public int DistId { get; set; }
        public Cat_District Cat_District { get; set; }
    }



    public partial class BuffertWiseBooking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BufferBookingId { get; set; }
        
        [Display(Name = "Fiscal Year")]
        public int FiscalYearId { get; set; }
        [ForeignKey("FiscalYearId")]
        public virtual Acc_FiscalYear YearName { get; set; }
        

        public int FiscalMonthId { get; set; }


        
        [Display(Name = "Buffer")]

        public int BufferID { get; set; }
        
        [ForeignKey("BufferID")]
        public virtual BufferList BufferList { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]

        public int BufferRepresentativeId { get; set; }
        [ForeignKey("BufferRepresentativeId")]
        public virtual BufferRepresentative BufferRepresentative { get; set; }
        public DateTime DtInput { get; set; }
        public float Qty { get; set; }
        [NotMapped]
        [Column(TypeName = "decimal(18,2)")]

        public float AvailavleQty { get; set; }

        public string AllotmentType { get; set; }
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


    public partial class RepresentativeBooking
    {
        public int RepresentativeBookingId { get; set; }
        public string OrderNo { get; set; }
        /// public int BookingNo { get; set; }
        public int FiscalYearId { get; set; }
        [ForeignKey("FiscalYearId")]
        public virtual Acc_FiscalYear YearName { get; set; }
        public int FiscalMonthId { get; set; }
        [ForeignKey("FiscalMonthId")]
        public virtual Acc_FiscalMonth MonthName { get; set; }
        public int BufferRepresentativeId { get; set; }
        [ForeignKey("BufferRepresentativeId")]
        public virtual BufferRepresentative BufferRepresentative { get; set; }
        public int BufferListId { get; set; }
        [ForeignKey("BufferListId")]
        public virtual BufferList BufferList { get; set; }
        public float AllotmentQty { get; set; }
        [NotMapped]
        public float RemainQty { get; set; }
        [NotMapped]
        public float TotalAllowed { get; set; }
        [NotMapped]
        public float Allocated { get; set; }



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


        public int? BufferBookingId { get; set; }
        [ForeignKey("BufferBookingId")]
        public virtual BuffertWiseBooking BuffertWiseBooking { get; set; }
        public virtual ICollection<BufferDelOrder> BufferDeliveryOrder { get; set; }





    }

    public partial class RepresentativeBookingVM
    {

        public int RepresentativeBookingId { get; set; }
        public string BufferName { get; set; }
        public string CurierName { get; set; }
        public float TotalAllotmetnt { get; set; }
        public float Allocated { get; set; }
        public float Avilavle { get; set; }
        public float Qty { get; set; }
        public DateTime DateTime { get; set; }

    }
    public partial class BufferVM
    {

        public int RepresentativeBookingId { get; set; }
        public string BufferName { get; set; }
        public string CurierName { get; set; }
        public float TotalAllotmetnt { get; set; }
        public float Allocated { get; set; }
        public float Avilavle { get; set; }
        public float Qty { get; set; }
        public DateTime DateTime { get; set; }

    }


    public partial class BufferDelOrder
    {

        [Key]
        public int BufferDelOrderId { get; set; }
        public int DONo { get; set; } = 1;

        [NotMapped]
        public int OldDONo { get; set; }


        [DisplayFormat(DataFormatString = "{0:yy/MM/dd}")]
        [DataType(DataType.Date)]
        public DateTime DODate { get; set; }


        public int RepresentativeBookingId { get; set; }
        [ForeignKey("RepresentativeBookingId")]
        public virtual RepresentativeBooking RepresentativeBooking { get; set; }

        public int? BufferRepresentativeId { get; set; }
        [ForeignKey("BufferRepresentativeId")]
        public virtual BufferRepresentative BufferRepresentative { get; set; }


        public int PayInSlipNo { get; set; }
        [DisplayFormat(DataFormatString = "{0:yy/MM/dd}")]
        [DataType(DataType.Date)]
        public DateTime PayInSlipDate { get; set; }
        public float Qty { get; set; }
        public float RemainingQty { get; set; }
        [NotMapped]
        public float CurrentRemainingQty { get; set; }

        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public string Remarks { get; set; }

        public string QtyInWordsEng { get; set; }
        public string QtyInWordsBng { get; set; }

        public string TotalPriceInWordsEng { get; set; }
        public string TotalPriceInWordsBng { get; set; }


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


        //public ICollection<BufferDelChallan> BufferDelChallan { get; set; }
    }



    public class BufferDelChallan
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BufferDelChallanId { get; set; }
        public int ChallanNo { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yy/MM/dd}")]
        [DataType(DataType.Date)]
        public DateTime DeliveryDate { get; set; } // Date 

        //public string MyProperty { get; set; }
        public float DeliveryQty { get; set; }       //Chalan qty

        public int RepresentativeBookingId { get; set; }
        [ForeignKey("RepresentativeBookingId")]
        public virtual RepresentativeBooking RepresentativeBooking { get; set; }


        [ForeignKey("BufferRepresentativeMember")]
        public int? RepresentativeMemberId { get; set; }
        
        public virtual BufferRepresentativeMember BufferRepresentativeMember { get; set; }


        [StringLength(128)]
        public string ComId { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        [StringLength(128)]
        public string UpdateByUserId { get; set; }
        public bool IsDelivered { get; set; }

        public virtual ICollection<BufferGatePassSub> BufferGatePassChallans { get; set; }


        [NotMapped]
        public int Representativeid { get; set; }
        [NotMapped]
        public int DONo { get; set; }
        [NotMapped]
        public float TotalAllocated { get; set; }
        [NotMapped]
        public float previousQty { get; set; }
        [NotMapped]
        public float alreadyAlocated { get; set; }
        [NotMapped]
        public float Available { get; set; }
        //[ForeignKey("BufferDelOrder")]
        //public int BufferDelOrderId { get; set; }

        //public virtual BufferDelOrder BufferDelOrder { get; set; }
       




    }

    public class BufferGatePass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BufferGatePassId { get; set; }
      
        public int GatePassNo { get; set; }
        public string GatePassFrom { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime GatePassDate { get; set; }

        [Required]
        public string TruckNumber { get; set; }
        public string DriverName { get; set; }
        public string DriverMobile { get; set; }

        public string ReceiverName { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverMobile { get; set; }


        public int FiscalYearId { get; set; }
        public int FiscalMonthId { get; set; }
        public int? BufferId { get; set; }

        public float TotalQty { get; set; }

        [StringLength(128)]
        public string ComId { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        [StringLength(128)]
        public string UpdateByUserId { get; set; }

        public int Status { get; set; } = 0;
        [NotMapped]
        public string BufferDelChallanId { get; set; }
        [NotMapped]
        public string BufferDelChallanNo { get; set; }



        public virtual ICollection<BufferGatePassSub> BufferGatePassSub { get; set; }
    }

    public class BufferGatePassSub
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BufferGatePassSubId { get; set; }


        public int BufferGatePassId { get; set; }
        [ForeignKey("BufferGatePassId")]
        public virtual BufferGatePass BufferGatePass { get; set; }

        public int BufferDelChallanId { get; set; }
        [ForeignKey("BufferDelChallanId")]

        public virtual BufferDelChallan BufferDelChallan { get; set; }


        public float TruckLoadQty { get; set; }
        public float BalanceQty { get; set; }




        [NotMapped]
        public string DistName { get; set; }
        [NotMapped]
        public string FyName { get; set; }
        [NotMapped]
        public string RepresentativeName { get; set; }


    }
    public class BufferVm
    {
        public int BufferListId { get; set; }
        public int RepresentativeBookingId { get; set; }

        public string ComId { get; set; }


        public string BufferCode { get; set; }


        public string BufferName { get; set; }

        public string BufferNameBangla { get; set; }
        public List<SelectListItem> drpDistricts { get; set; }
        public List<SelectListItem> drpBufferRep { get; set; }
        public int[] districtId { get; set; }

        public int[] bufferRepId { get; set; }
        public float AllotmentQty { get; set; }
        public float AvailabeQty { get; set; }
        public DateTime DateAdded { get; set; }



        public int BufferRepresentativeId { get; set; }

        public string RepresentativeName { get; set; }
    }


    // Buffer Delivery Challan view Model
    public class BufferDcVm
    {
        public BufferDelChallan BufferDelChallan { get; set; }
        public int BufferId { get; set; }
        public List<BufferList> Bufferlist { get; set; }

        public int BufferRepresentativeId { get; set; }
        public List<SelectList> BufferRepresentativeName { get; set; }

        public int BufferRepresentativeMemberId { get; set; }
        public List<SelectList> BufferRepresentativeMemberName { get; set; }
        
        public int BufferDelChallanId { get; set; }
        public int ChallanNo { get; set; }
        public string OrderNo { get; set; }
        public string Buffer { get; set; }
        public string Carrier { get; set; }
        public float  qty { get; set; }
        public float TruckLoadQty { get; set; }
        public float  BalanceQty { get; set; }

        public string DeliveryDate { get; set; }

    }








}
