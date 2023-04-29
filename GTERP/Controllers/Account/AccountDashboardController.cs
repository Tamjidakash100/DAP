using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GTERP.Controllers
{
    [OverridableAuthorize]
    public class AccountDashboardController : Controller
    {
        private Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
        private GTRDBContext db = new GTRDBContext();
        // GET: Deshboard

        [HttpGet]
        public ActionResult BuyerWiseShipmentStatus(int? ComId, int? BuyerId, int? Year)
        {
            var comid = HttpContext.Session.GetString("comid");
            ViewBag.SisterConcernCompanyId = new SelectList(db.SisterConcernCompany.Where(x => x.comid.ToString() == comid.ToString()), "SisterConcernCompanyId", "CompanyName");
            //ViewBag.BuyerId = new SelectList(db.BuyerInformation, "BuyerId", "BuyerName");
            ViewBag.BuyerGroupId = new SelectList(db.BuyerGroups.Take(0).Where(x => x.comid.ToString() == comid.ToString()), "BuyerGroupId", "BuyerGroupName");


            return View(); //p.ComId == AppData.AppData.intComId && 

        }


        public class HMShipmentStatusModel
        {
            public string YearNo { get; set; }

            public string MonthName { get; set; }

            public decimal PCS { get; set; }

            public decimal DOZEN { get; set; }

            public decimal USD { get; set; }

            public decimal MILLIONS { get; set; }

        }


        [HttpGet]

        public ActionResult GetOverDueShipment()
        {
            var comid = HttpContext.Session.GetString("comid");

            ViewBag.SisterConcernCompanyId = new SelectList(db.SisterConcernCompany.Where(x => x.comid.ToString() == comid), "SisterConcernCompanyId", "CompanyName");
            ViewBag.BuyerGroupId = new SelectList(db.BuyerGroups.Where(x => x.comid.ToString() == comid).Take(0), "BuyerGroupId", "BuyerGroupName");
            return View();
        }

        public class Dashboard1
        {
            public string Caption { get; set; }
            public string Count { get; set; }
            public string ReportLinkCaption { get; set; }
        }


        public class Dashboard2
        {
            public int MonthId { get; set; }
            public string MonthName { get; set; }
            public decimal? TotalDocument { get; set; }
        }

        public class Dashboard3
        {
            public string username { get; set; }
            public int MonthId { get; set; }
            public string MonthName { get; set; }
            public int TotalDocument { get; set; }
        }

        public class Dashboard4
        {
            public int DayId { get; set; }
            public string Caption { get; set; }
            public string DateNameString { get; set; }
            public int TotalDocument { get; set; }
        }



        [HttpGet]
        //
        public ActionResult MainDashboard(DateTime? FromDate, DateTime? ToDate)
        {
            if (FromDate == null || ToDate == null)
            {
                FromDate = DateTime.Now.Date;
                ToDate = DateTime.Now.Date;

            }
            else
            {

                ViewBag.FromDate = FromDate;
                ViewBag.ToDate = ToDate;
            }
            var comid = HttpContext.Session.GetString("comid");



            //////1st 
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "Cash Payment");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<Dashboard1> CashPayment = Helper.ExecProcMapTList<Dashboard1>("prcGetDashboard_Accounts", parameters);
            ViewBag.CashPayment = CashPayment;

            /////2nd
            List<Dashboard1> CashReceipt = Helper.ExecProcMapTList<Dashboard1>("prcGetDashboard_Accounts",
                new SqlParameter[] {
                    new SqlParameter("@Criteria", "Cash Receipt"),
                    new SqlParameter("@FromDate", FromDate),
                    new SqlParameter("@ToDate", ToDate),
                    new SqlParameter("@ComId", comid)
                    }
                );
            ViewBag.CashReceipt = CashReceipt;

            //////  3  
            //SqlParameter[] parameters3 = new SqlParameter[4];
            List<Dashboard1> BankPayment = Helper.ExecProcMapTList<Dashboard1>("prcGetDashboard_Accounts",
            new SqlParameter[]
                {
                new SqlParameter("@Criteria", "Bank Payment"),
                new SqlParameter("@FromDate", FromDate),
                new SqlParameter("@ToDate", ToDate),
                new SqlParameter("@ComId", comid),
                }
            );
            ViewBag.BankPayment = BankPayment;


            //////  4 
            //SqlParameter[] parameters4 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "Bank Receipt");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<Dashboard1> BankReceipt = Helper.ExecProcMapTList<Dashboard1>("prcGetDashboard_Accounts", parameters);
            ViewBag.BankReceipt = BankReceipt;


            //////  5 
            //SqlParameter[] parameters5 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "Contra");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);


            List<Dashboard1> Contra = Helper.ExecProcMapTList<Dashboard1>("prcGetDashboard_Accounts", parameters);
            ViewBag.Contra = Contra;


            //////  6
            //SqlParameter[] parameters6 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "Journal");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<Dashboard1> Journal = Helper.ExecProcMapTList<Dashboard1>("prcGetDashboard_Accounts", parameters);
            ViewBag.Journal = Journal;





            //////  88 s
            //SqlParameter[] parameters8 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "TotalCashReceipt");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<Dashboard2> MonthWiseCashReceipt = Helper.ExecProcMapTList<Dashboard2>("prcGetDashboard_Accounts", parameters);


            //////  9 s
            //SqlParameter[] parameters9 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "TotalCashPayment");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<Dashboard2> MonthWiseCashPayment = Helper.ExecProcMapTList<Dashboard2>("prcGetDashboard_Accounts", parameters);


            //////  10 s
            //SqlParameter[] parameters10 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "TotalBankReceipt");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<Dashboard2> MonthWiseBankReceipt = Helper.ExecProcMapTList<Dashboard2>("prcGetDashboard_Accounts", parameters);



            //////  11 s
            //SqlParameter[] parameters11 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "TotalBankPayment");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<Dashboard2> MonthWiseBankPayment = Helper.ExecProcMapTList<Dashboard2>("prcGetDashboard_Accounts", parameters);


            //////  12 s
            //SqlParameter[] parameters12 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "TotalContra");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<Dashboard2> MonthWiseContra = Helper.ExecProcMapTList<Dashboard2>("prcGetDashboard_Accounts", parameters);



            //////  12 s
            //SqlParameter[] parameters12 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "TotalJournal");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<Dashboard2> MonthWiseJournal = Helper.ExecProcMapTList<Dashboard2>("prcGetDashboard_Accounts", parameters);



            //SqlParameter[] parameters14 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "MonthUserWiseAllVoucher");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<Dashboard3> MonthUserWiseAllVoucher = Helper.ExecProcMapTList<Dashboard3>("prcGetDashboard_Accounts", parameters);

            //////  14 s
            //SqlParameter[] parameters14 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "MonthUserWiseCashPayment");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<Dashboard3> MonthUserWiseCashPayment = Helper.ExecProcMapTList<Dashboard3>("prcGetDashboard_Accounts", parameters);

            //////  15 s
            //SqlParameter[] parameters15 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "MonthUserWiseCashReceipt");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<Dashboard3> MonthUserWiseCashReceipt = Helper.ExecProcMapTList<Dashboard3>("prcGetDashboard_Accounts", parameters);



            //////  16 s
            //SqlParameter[] parameters16 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "MonthUserWiseBankPayment");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<Dashboard3> MonthUserWiseBankPayment = Helper.ExecProcMapTList<Dashboard3>("prcGetDashboard_Accounts", parameters);

            //////  17 s
            //SqlParameter[] parameters17 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "MonthUserWiseBankReceipt");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<Dashboard3> MonthUserWiseBankReceipt = Helper.ExecProcMapTList<Dashboard3>("prcGetDashboard_Accounts", parameters);



            //////  18 s
            //SqlParameter[] parameters18 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "MonthUserWiseContra");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<Dashboard3> MonthUserWiseContra = Helper.ExecProcMapTList<Dashboard3>("prcGetDashboard_Accounts", parameters);


            //SqlParameter[] parameters199 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "MonthUserWiseJournal");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<Dashboard3> MonthUserWiseJournal = Helper.ExecProcMapTList<Dashboard3>("prcGetDashboard_Accounts", parameters);









            //////  19 s
            //SqlParameter[] parameters19 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "TopTransactionCashPayment");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<TopTransaction> TopTransactionCP = Helper.ExecProcMapTList<TopTransaction>("prcGetDashboard_Accounts", parameters);
            ViewBag.TopTransactionCashPayment = TopTransactionCP.ToList();


            //////  20 s
            //SqlParameter[] parameters20= new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "TopTransactionCashReceipt");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<TopTransaction> TopTransactionCR = Helper.ExecProcMapTList<TopTransaction>("prcGetDashboard_Accounts", parameters);
            ViewBag.TopTransactionCashReceipt = TopTransactionCR;


            //////  21 s
            //SqlParameter[] parameters21 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "TopTransactionBankPayment");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<TopTransaction> TopTransactionBP = Helper.ExecProcMapTList<TopTransaction>("prcGetDashboard_Accounts", parameters);
            ViewBag.TopTransactionBankPayment = TopTransactionBP;

            //////  22 s
            //SqlParameter[] parameters22 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "TopTransactionBankReceipt");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<TopTransaction> TopTransactionBR = Helper.ExecProcMapTList<TopTransaction>("prcGetDashboard_Accounts", parameters);
            ViewBag.TopTransactionBankReceipt = TopTransactionBR;


            //////  23 s
            //SqlParameter[] parameters23 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "TopTransactionContra");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<TopTransaction> TopTransactionContra = Helper.ExecProcMapTList<TopTransaction>("prcGetDashboard_Accounts", parameters);
            ViewBag.TopTransactionContra = TopTransactionContra;


            //////  23 s
            //SqlParameter[] parameters233 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "TopTransactionJournal");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<TopTransaction> TopTransactionJournal = Helper.ExecProcMapTList<TopTransaction>("prcGetDashboard_Accounts", parameters);
            ViewBag.TopTransactionJournal = TopTransactionJournal;





            //////  24 s
            //SqlParameter[] parameters24 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "TopLogin");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<UserLogingInfoes> TopLogin = Helper.ExecProcMapTList<UserLogingInfoes>("prcGetDashboard_Accounts", parameters);
            ViewBag.TopLogin = TopLogin;





            //////  25 s
            //SqlParameter[] parameters25 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "VoucherUserCount");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<UserCountDocumentLastTransaction> VoucherUserCount = Helper.ExecProcMapTList<UserCountDocumentLastTransaction>("prcGetDashboard_Accounts", parameters);
            ViewBag.VoucherUserCount = VoucherUserCount;



            //////  26 s
            //SqlParameter[] parameters26 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "TopUserTransaction");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<TopTransaction> AllUserTransaction = Helper.ExecProcMapTList<TopTransaction>("prcGetDashboard_Accounts", parameters);
            ViewBag.AllUserTransaction = AllUserTransaction;


            //////  7 s
            //SqlParameter[] parameters7 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "UserLogingInfoes");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<UserLogingInfoes> UserLogingInfoes = Helper.ExecProcMapTList<UserLogingInfoes>("prcGetDashboard_Accounts", parameters);
            ViewBag.UserLogingInfoe = UserLogingInfoes.ToList();


            //////  8
            //SqlParameter[] parameters66 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "LastTransactions");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);


            List<LastTransactions> LastTransactions = Helper.ExecProcMapTList<LastTransactions>("prcGetDashboard_Accounts", parameters);
            ViewBag.LastTransactions = LastTransactions.ToList();


            //////  27 s
            SqlParameter[] parameters27 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "DayWiseVoucher");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<Dashboard4> DayWiseVoucher = Helper.ExecProcMapTList<Dashboard4>("prcGetDashboard_Accounts", parameters);




            /////Post Voucher
            List<Dashboard1> PostVoucher = Helper.ExecProcMapTList<Dashboard1>("prcGetDashboard_Accounts",
                new SqlParameter[] {
                    new SqlParameter("@Criteria", "Post Voucher"),
                    new SqlParameter("@FromDate", FromDate),
                    new SqlParameter("@ToDate", ToDate),
                    new SqlParameter("@ComId", comid)
                    }
                );
            ViewBag.PostVoucher = PostVoucher;


            /////UnPost Voucher
            List<Dashboard1> UnPostVoucher = Helper.ExecProcMapTList<Dashboard1>("prcGetDashboard_Accounts",
                new SqlParameter[] {
                    new SqlParameter("@Criteria", "UnPost Voucher"),
                    new SqlParameter("@FromDate", FromDate),
                    new SqlParameter("@ToDate", ToDate),
                    new SqlParameter("@ComId", comid)
                    }
                );
            ViewBag.UnPostVoucher = UnPostVoucher;


            /////Total Debit
            List<Dashboard1> TotalDebit = Helper.ExecProcMapTList<Dashboard1>("prcGetDashboard_Accounts",
                new SqlParameter[] {
                    new SqlParameter("@Criteria", "Total Debit"),
                    new SqlParameter("@FromDate", FromDate),
                    new SqlParameter("@ToDate", ToDate),
                    new SqlParameter("@ComId", comid)
                    }
                );
            ViewBag.TotalDebit = TotalDebit;


            /////Total Credit
            List<Dashboard1> TotalCredit = Helper.ExecProcMapTList<Dashboard1>("prcGetDashboard_Accounts",
                new SqlParameter[] {
                    new SqlParameter("@Criteria", "Total Credit"),
                    new SqlParameter("@FromDate", FromDate),
                    new SqlParameter("@ToDate", ToDate),
                    new SqlParameter("@ComId", comid)
                    }
                );
            ViewBag.TotalCredit = TotalCredit;



            /////Total Cash Balance
            List<Dashboard1> TotalCashBalance = Helper.ExecProcMapTList<Dashboard1>("prcGetDashboard_Accounts",
                new SqlParameter[] {
                    new SqlParameter("@Criteria", "Total Cash Balance"),
                    new SqlParameter("@FromDate", FromDate),
                    new SqlParameter("@ToDate", ToDate),
                    new SqlParameter("@ComId", comid)
                    }
                );
            ViewBag.TotalCashBalance = TotalCashBalance;


            /////Total Bank Balance
            List<Dashboard1> TotalBankBalance = Helper.ExecProcMapTList<Dashboard1>("prcGetDashboard_Accounts",
                new SqlParameter[] {
                    new SqlParameter("@Criteria", "Total Bank Balance"),
                    new SqlParameter("@FromDate", FromDate),
                    new SqlParameter("@ToDate", ToDate),
                    new SqlParameter("@ComId", comid)
                    }
                );
            ViewBag.TotalBankBalance = TotalBankBalance;







            //////  19 s
            //SqlParameter[] parameters19 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "CashBalance");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<LedgerBalance> CashBalanceList = Helper.ExecProcMapTList<LedgerBalance>("prcGetDashboard_Accounts", parameters);
            ViewBag.CashBalanceList = CashBalanceList.ToList();


            //////  20 s
            //SqlParameter[] parameters20= new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "BankBalance");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<LedgerBalance> BankBalanceList = Helper.ExecProcMapTList<LedgerBalance>("prcGetDashboard_Accounts", parameters);
            ViewBag.BankBalanceList = BankBalanceList;


            //////  21 s
            //SqlParameter[] parameters21 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "AccountsPayableBalance");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<LedgerBalance> AccountsPayableBalanceList = Helper.ExecProcMapTList<LedgerBalance>("prcGetDashboard_Accounts", parameters);
            ViewBag.AccountsPayableBalanceList = AccountsPayableBalanceList;

            //////  22 s
            //SqlParameter[] parameters22 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "AccountsReceivableBalance");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<LedgerBalance> AccountsReceivableBalanceList = Helper.ExecProcMapTList<LedgerBalance>("prcGetDashboard_Accounts", parameters);
            ViewBag.AccountsReceivableBalanceList = AccountsReceivableBalanceList;


            //////  23 s
            //SqlParameter[] parameters23 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "FixedDepostiBalance");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<LedgerBalance> FixedDepostiBalanceList = Helper.ExecProcMapTList<LedgerBalance>("prcGetDashboard_Accounts", parameters);
            ViewBag.FixedDepostiBalanceList = FixedDepostiBalanceList;


            //////  23 s
            //SqlParameter[] parameters233 = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Criteria", "FixedAssetBalance");
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@ComId", comid);

            List<LedgerBalance> FixedAssetBalanceList = Helper.ExecProcMapTList<LedgerBalance>("prcGetDashboard_Accounts", parameters);
            ViewBag.FixedAssetBalanceList = FixedAssetBalanceList;


            ViewBag.DashboardData = new
            {
                TotalCashReceipt = MonthWiseCashReceipt,
                TotalCashPayment = MonthWiseCashPayment,
                TotalBankReceipt = MonthWiseBankReceipt,
                TotalBankPayment = MonthWiseBankPayment,
                TotalContra = MonthWiseContra,
                TotalJournal = MonthWiseJournal,

                MonthUserWiseAllVoucher = MonthUserWiseAllVoucher,
                MonthUserWiseCashPayment = MonthUserWiseCashPayment,
                MonthUserWiseCashReceipt = MonthUserWiseCashReceipt,
                MonthUserWiseBankPayment = MonthUserWiseBankPayment,
                MonthUserWiseBankReceipt = MonthUserWiseBankReceipt,
                MonthUserWiseContra = MonthUserWiseContra,
                MonthUserWiseJournal = MonthUserWiseJournal,

                DayWiseVoucher = DayWiseVoucher,

            };

            //   //ViewBag.SisterConcernCompanyId = new SelectList(db.SisterConcernCompany, "SisterConcernCompanyId", "CompanyName");
            //   //ViewBag.BuyerId = new SelectList(db.BuyerInformation, "BuyerId", "BuyerName");
            return View();
        }

        public class UserCountDocumentLastTransaction
        {
            public string UserName { get; set; }
            public string YearInput { get; set; }
            public string TotalCount { get; set; }
            public string LastTransactionDate { get; set; }
        }

        public class UserLogingInfoes
        {
            public string UserName { get; set; }
            public string DeviceType { get; set; }
            public DateTime? LoginTime { get; set; }
            public string IPAddress { get; set; }
        }

        public class TopTransaction
        {
            public string UserName { get; set; }
            public string Caption { get; set; }
            public DateTime? WorkDate { get; set; }
        }

        public class LedgerBalance
        {
            public string AccName { get; set; }
            public string AccCode { get; set; }
            public decimal? Balance { get; set; }
            public string Caption { get; set; }
        }



        public class LastTransactions
        {
            public string Caption { get; set; }
            public int Total { get; set; }
            public decimal? Value { get; set; }

            public string EntryDate { get; set; }

        }


        //public JsonResult LastTransaction(DateTime? FromDate, DateTime? ToDate)
        //{
        //    if (FromDate == null || ToDate == null)
        //    {
        //        FromDate = DateTime.Now.Date;
        //        ToDate = DateTime.Now.Date;

        //    }
        //    List<LastTransactions> LastTransactions = (db.Database.SqlQuery<LastTransactions>("[prcLastTransaction]  @Criteria, @FromDate, @ToDate",
        //        new SqlParameter("Criteria", "LastTransactions"),
        //        new SqlParameter("FromDate", FromDate),
        //        new SqlParameter("ToDate", ToDate)

        //        )).ToList();

        //    // ViewBag.LastTransactions = LastTransactions;
        //    return Json(LastTransactions, JsonRequestBehavior.AllowGet);
        //}






        [HttpGet]

        public ActionResult GatePassDetailsChart()
        {
            ViewBag.SisterConcernCompanyId = new SelectList(db.SisterConcernCompany, "SisterConcernCompanyId", "CompanyName");
            return View();
        }



        public class GatePassChartSummary
        {

            public string SupplierName { get; set; }
            public decimal TotalValue { get; set; }

        }


        public class GatePassDetails
        {
            public string GatePassNo { get; set; }
            public string CompanyName { get; set; }
            public string SupplierName { get; set; }
            public string LcOpeningDate { get; set; }
            public string ExpiryDate { get; set; }
            public string UDNo { get; set; }
            public string UDDate { get; set; }
            public string PortOfLoadingName { get; set; }
            public string PINo { get; set; }
            public string FileNo { get; set; }
            public string ImportPONo { get; set; }
            public string HSCode { get; set; }
            public string ItemDescription { get; set; }
            public string ItemGroupName { get; set; }
            public decimal ImportRate { get; set; }
            public decimal TotalValue { get; set; }

        }




        [HttpGet]

        public ActionResult GroupLCChart()
        {
            ViewBag.SisterConcernCompanyId = new SelectList(db.SisterConcernCompany, "SisterConcernCompanyId", "CompanyName");
            return View();
        }

        //[HttpGet]

        //public ActionResult GetGroupLC(int? ComId)
        //{
        //    try
        //    {
        //        if (ComId == null)
        //        {
        //            ComId = 0;
        //        }

        //        var query = "select CompanyName ,BuyerName ,GroupLCRefName , convert(varchar,TotalGroupLCValue) as TotalGroupLCValue," +
        //            "LCRefNo,ExportPONo,HSCode,ItemName,Fabrication,convert(varchar,TotalValue) as TotalValue," +
        //            "convert(varchar,QtyInPcs) as QtyInPcs,convert(varchar,OrderQty) as OrderQty " +
        //            "from VWGroupLC where CompanyID = " + ComId + " ";
        //        List<GroupLC> groupLC = db.Database.SqlQuery<GroupLC>(query).ToList();


        //        query = "select BuyerName,sum(TotalValue) as TotalMLCValue from VWGroupLC where CompanyID = " + ComId + "  group by BuyerName";
        //        List<GroupLCchart> groupLCChart = db.Database.SqlQuery<GroupLCchart>(query).ToList();

        //        var data = new { datag = groupLC, datac = groupLCChart };

        //        return Json(data, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public class GroupLC
        {
            public string CompanyName { get; set; }
            public string BuyerName { get; set; }
            public string GroupLCRefName { get; set; }
            public string TotalGroupLCValue { get; set; }
            public string LCRefNo { get; set; }
            public string ExportPONo { get; set; }
            public string HSCode { get; set; }
            public string ItemName { get; set; }
            public string Fabrication { get; set; }
            public string TotalValue { get; set; }
            public string QtyInPcs { get; set; }
            public string OrderQty { get; set; }
        }
        public class GroupLCchart
        {
            public string BuyerName { get; set; }
            public decimal TotalMLCValue { get; set; }
        }





        #region rptDashboardMarginAlert Using Procedure

        [HttpGet]

        public ActionResult rptDashboardMarginAlert()
        {
            ViewBag.SisterConcernCompanyId = new SelectList(db.SisterConcernCompany, "SisterConcernCompanyId", "CompanyName");
            return View();
        }

        //[HttpPost]

        //public ActionResult rptDashboardMarginAlert(int? ComId)
        //{

        //    if (ComId == null)
        //    {
        //        ComId = 0;
        //    }

        //    List<MarginAlert> marginAlert = (db.Database.SqlQuery<MarginAlert>("[rptDashboardMarginAlert]  @ComId",
        //        new SqlParameter("ComId", ComId))).ToList();
        //    var data = marginAlert;
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

        public class MarginAlert
        {
            public string GatePassNo { get; set; }
            public string CompanyName { get; set; }
            public string SupplierName { get; set; }
            public string BuyerName { get; set; }
            public string LcOpeningDate { get; set; }
            public string ExpiryDate { get; set; }
            public int? TotalPI { get; set; }

            public string PortOfLoadingName { get; set; }
            public decimal TotalValue { get; set; }
            public decimal GatePassValue { get; set; }
            public decimal TotalMLCValue { get; set; }
            public decimal SalesBookingAmount { get; set; }
            public decimal MarginUsed { get; set; }
        }
        #endregion rptDashboardMarginAlert Using Procedure

        #region rptDashboardSupplierBillMaturityOverdue Using Procedure
        [HttpGet]

        public ActionResult rptDashboardSupplierBillMaturityOverdue()
        {
            ViewBag.SisterConcernCompanyId = new SelectList(db.SisterConcernCompany, "SisterConcernCompanyId", "CompanyName");

            return View();
        }



        public class SupplierBillMaturityOverdue
        {
            public string CompanyName { get; set; }
            public string SalesBooking { get; set; }
            public string B2BNo { get; set; }
            public string Supplier { get; set; }
            public string BillRef { get; set; }
            public string DeliveryOrderNo { get; set; }// as Total PI
            public string CommercialDeliveryOrderDate { get; set; }
            public string BillDate { get; set; }
            public string MaturityDate { get; set; }

        }
        #endregion rptDashboardSupplierBillMaturityOverdue Using Procedure




        #region rptDashboardBillCreatePending using Procedure

        [HttpGet]

        public ActionResult rptDashboardBillCreatePending()
        {
            ViewBag.SisterConcernCompanyId = new SelectList(db.SisterConcernCompany, "SisterConcernCompanyId", "CompanyName");

            return View();
        }



        public class BillCreatePending
        {
            public string CompanyName { get; set; }
            public string SupplierName { get; set; }
            public string GatePassNo { get; set; }
            public string CommercialDeliveryOrderNo { get; set; }
            public string CommercialDeliveryOrderDate { get; set; }
            public string ItemGroupName { get; set; }
            public string ItemDescription { get; set; }
            public string BLNo { get; set; }
            public string BLDate { get; set; }
            public string DocumentReceiptDate { get; set; }
            public string DocumentAssesmentDate { get; set; }
            public decimal TotalValue { get; set; }

        }
        #endregion



        [HttpGet]

        public ActionResult rptForthComingShipment()
        {
            ViewBag.SisterConcernCompanyId = new SelectList(db.SisterConcernCompany, "SisterConcernCompanyId", "CompanyName");

            return View();
        }


        //public ActionResult PrintFCSR(int? id, string type)
        //{
        //    try
        //    {


        //        GTERP.AppData.AppData.dbGTERP = db.Database.Connection.Database;
        //        clsReport.rptList = null;
        //        var ComId = AppData.AppData.intComId;

        //        var quary = $"EXEC rptForthComingShipment '{ComId}','{id}'";


        //        Session["ReportPath"] = "~/Report/ExportReport/rptForthComingShipment.rdlc";
        //        Session["reportquery"] = "Exec " + GTERP.AppData.AppData.dbGTERP.ToString() + ".dbo.[rptForthComingShipment] " + AppData.AppData.intComId + " , '" + id + "'";
        //        Session["DataSourceName"] = "DataSet1";

        //        Session["rptList"] = postData;

        //        clsReport.strReportPathMain = Session["ReportPath"].ToString();
        //        clsReport.strQueryMain = Session["reportquery"].ToString();
        //        clsReport.strDSNMain = Session["DataSourceName"].ToString();

        //        return RedirectToAction("Index", "ReportViewer");
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //}



        //[HttpPost, ActionName("SetSession")]

        ////[ValidateAntiForgeryToken]
        //public JsonResult SetSession(string reporttype, string action, int reportid)
        //{
        //    try
        //    {
        //        Session["ReportType"] = reporttype;
        //        //AppData.AppDate.PrintDate = printdate.ToString();


        //        //return Json(new { Success = 1, TermsId = param, ex = "" });
        //        var redirectUrl = new UrlHelper(Request.RequestuContext).Action(action, "Dashboard", new { id = reportid }); //, new { companyId = "7e96b930-a786-44dd-8576-052ce608e38f" }
        //        return Json(new { Url = redirectUrl });

        //    }

        //    catch (Exception ex)
        //    {
        //        // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }

        //    return Json(new { Success = 0, ex = new Exception("Unable to Delete").Message.ToString() });
        //    //return RedirectToAction("Index");

        //}






        //public ActionResult ExportDeliveryOrderStatus(int? BuyerGroupId, string FromDate, string ToDate)
        //{
        //    DateTime dtFrom = Convert.ToDateTime(DateTime.Now.Date);
        //    DateTime dtTo = Convert.ToDateTime(DateTime.Now.Date);

        //    if (FromDate == null || FromDate == "")
        //    {
        //    }
        //    else
        //    {
        //        dtFrom = Convert.ToDateTime(FromDate);

        //    }
        //    if (ToDate == null || ToDate == "")
        //    {
        //    }
        //    else
        //    {
        //        dtTo = Convert.ToDateTime(ToDate);

        //    }
        //    ViewBag.BuyerGroupId = new SelectList(db.BuyerGroups, "BuyerGroupId", "BuyerGroupName");
        //    if (BuyerGroupId == null)
        //    {
        //        BuyerGroupId = 0;
        //    }


        //    List<ExportDeliveryOrderStatusModel> ProductSerialresult = (db.Database.SqlQuery<ExportDeliveryOrderStatusModel>("[rptExportDeliveryOrderStatus]  @comid, @userid,@dtFrom,@dtTo,@BuyerGroupId", new SqlParameter("comid", Session["comid"]), new SqlParameter("userid", Session["userid"]), new SqlParameter("dtFrom", dtFrom), new SqlParameter("dtTo", dtTo), new SqlParameter("BuyerGroupId", BuyerGroupId))).ToList();
        //    //ViewBag.ProductSerial = new SelectList(ProductSerialresult, "ProductSerialId", "ProductSerialNo");
        //    ViewBag.ExportDeliveryOrderStatus = ProductSerialresult;


        //    return View(); //p.ComId == AppData.AppData.intComId && 



        //}

        public class ExportDeliveryOrderStatusModel
        {
            public string RowNo { get; set; }

            public string BuyerLCRef { get; set; }
            public string DeliveryOrderNo { get; set; }
            public decimal TotalDeliveryOrderQty { get; set; }
            public decimal DeliveryOrderValue { get; set; }
            public string CargoHandOverDate { get; set; }




            public string BLNO { get; set; }

            public string BankRef { get; set; }



            public decimal RealizationAmount { get; set; } ///TotalValue	ReceivingDate	PIStatus





            public decimal ShortPayment { get; set; }
            public string DestinationName { get; set; }


            public string ExpNo { get; set; }

            public string BuyerGroupName { get; set; }
            public string BuyerName { get; set; }


            public string FirstNotifyParty { get; set; }

            public decimal FBPAmount { get; set; }


            public string DeliveryOrderDate { get; set; }
            public string VesselSailingDate { get; set; }

            public string PaymentMaturityDate { get; set; }


            public string PaymentReceiveDate { get; set; }

            public string DeliveryOrderPaymentStatus { get; set; }



            public string StatusColor { get; set; }




        }



    }
}