using GTERP.BLL;
using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers
{
    [OverridableAuthorize]
    public class Acc_BudgetController : Controller
    {
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
        private GTRDBContext db = new GTRDBContext();
        private TransactionLogRepository tranlog;

        public Acc_BudgetController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;

        }

        //private int comid = int.Parse(httpre Session["comid"].ToString());
        //
        // GET: /Budget/
        public ViewResult Index(string FromDate, string ToDate)
        {
            var transactioncomid = HttpContext.Session.GetString("comid");

            DateTime dtFrom = Convert.ToDateTime(DateTime.Now.Date.ToString("dd-MMM-yy"));
            DateTime dtTo = Convert.ToDateTime(DateTime.Now.Date.ToString("dd-MMM-yy"));



            if (FromDate == null || FromDate == "")
            {
            }
            else
            {
                dtFrom = Convert.ToDateTime(FromDate);

            }
            if (ToDate == null || ToDate == "")
            {
            }
            else
            {
                dtTo = Convert.ToDateTime(ToDate);

            }
            //var d = db.Acc_BudgetMains.Where(p => p.comid.ToString() == transactioncomid.ToString() && (p.BudgetDate >= dtFrom && p.BudgetDate <= dtTo)).ToList();

            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "Index", "");

            return View();
        }

        //





        public ActionResult Create(int? FiscalYearId, int? FiscalMonthId, int? BudgetId = 0)
        {
            try
            {
                ViewBag.Title = "Entry";
                var transactioncomid = HttpContext.Session.GetString("comid");

                //if (Type == null)
                //{
                var Type = "VPC";
                //}

                Acc_BudgetMain Budgetsamplemodel = new Acc_BudgetMain();
                var transactioncompany = db.Companys.Where(c => c.ComId.ToString() == transactioncomid).FirstOrDefault();
                HttpContext.Session.SetInt32("defaultcurrencyid", transactioncompany.CountryId);
                HttpContext.Session.SetString("defaultcurrencyname", transactioncompany.vCountryCompany.CurrencyShortName);


                ViewBag.PrdUnitId = new SelectList(db.PrdUnits.Where(c => c.comid.ToString() == transactioncomid), "PrdUnitId", "PrdUnitName"); //&& c.ComId.ToString() == (transactioncomid)



                ///////account head parent data for dropdown
                var ChartOfAccountParent = db.Acc_ChartOfAccounts.Where(p => p.comid.ToString() == transactioncomid).Where(c => c.AccId > 0 && c.AccType == "G" && c.comid.ToString() == transactioncomid).Select(s => new { Text = s.AccName, Value = s.AccId }).ToList(); //&& c.ComId.ToString() == (transactioncomid)
                this.ViewBag.AccountParent = new SelectList(ChartOfAccountParent, "Value", "Text");


                //List<ChartOfAccountsModel> ChartOfAccountsModelInformations = (db.Database.SqlQuery<ChartOfAccountsModel>("[ExportInvoiceDetailsInformation]  @comid, @userid,@MasterLCId", new SqlParameter("comid", Session["comid"]), new SqlParameter("userid", Session["userid"]), new SqlParameter("MasterLCId", MasterLCId))).ToList();
                ////ViewBag.ProductSerial = new SelectList(ProductSerialresult, "ProductSerialId", "ProductSerialNo");
                //ViewBag.RemainingCOA = ChartOfAccountsModelInformations;


                //this.ViewBag.AccountSearch = Acc_ChartOfAccounts;

                //List<VoucherChartOfAccount> COAParent = (db.Database.SqlQuery<VoucherChartOfAccount>("[prcGetVoucherAccounts]  @comid,@Type,@dtvoucher", new SqlParameter("comid", Session["comid"].ToString()), new SqlParameter("Type", Type), new SqlParameter("dtvoucher", DateTime.Now.Date.ToString("dd-MMM-yy")))).ToList();
                //this.ViewBag.AccountSearch = COAParent;
                //this.ViewBag.ProductSerial = new SelectList(db.ProductSerial.Where(c => c.ProductSerialId > 0), "ProductSerialId", "ProductSerialNo");

                var ChartOfAccountsearch = db.Acc_ChartOfAccounts.Where(c => c.AccId > 0 && c.AccType == "L" && c.comid.ToString() == transactioncomid); //&& c.ComId.ToString() == (transactioncomid)
                this.ViewBag.AccountSearch = ChartOfAccountsearch;



                if (Type == "VPC")
                {
                    ViewBag.Title = "Create";


                    var Acc_ChartOfAccounts = db.Acc_ChartOfAccounts.Where(c => c.comid.ToString() == transactioncomid && c.AccId > 0 && c.AccType == "L"); //&& c.ComId.ToString() == (transactioncomid)
                    if (transactioncompany.isMultiDebitCredit == true)
                    {
                        this.ViewBag.Account = new SelectList(Acc_ChartOfAccounts.Where(x => x.IsBankItem == false).Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text");
                    }
                    else
                    {
                        this.ViewBag.Account = new SelectList(Acc_ChartOfAccounts.Where(x => x.IsBankItem == false && x.IsCashItem == false).Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text");
                    }






                    this.ViewBag.SubSectionList = db.Cat_SubSection.Where(x => x.ComId.ToString() == transactioncomid);


                    if (BudgetId == 0)
                    {
                        ///////only cash item when multi debit credit of then it enable







                        if (FiscalYearId != null && FiscalMonthId != null && FiscalMonthId > 0)
                        {

                            Acc_BudgetMain budgetMain = db.Acc_BudgetMains.Where(m => m.FiscalYearId == FiscalYearId && m.FiscalMonthId == FiscalMonthId).FirstOrDefault();
                            if (budgetMain != null)
                            {
                                ViewBag.Title = "Edit";

                                this.ViewBag.Country = new SelectList(db.Countries.Where(x => x.isActive == true), "CountryId", "CurrencyShortName", budgetMain.CountryId);
                                int AccId = budgetMain.BudgetSubs.Where(x => x.SRowNo < 0).Select(x => x.AccId).FirstOrDefault();
                                this.ViewBag.AccountMain = new SelectList(db.Acc_ChartOfAccounts.Where(p => p.comid.ToString() == transactioncomid && p.AccType == "L" && p.IsCashItem == true).Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text", AccId);
                                this.ViewBag.FiscalYearId = new SelectList(db.Acc_FiscalYears.Where(p => p.comid.ToString() == transactioncomid && p.FiscalYearId > 0), "FiscalYearId", "FYName", budgetMain.FiscalYearId).ToList(); //&& c.ComId.ToString() == (transactioncomid)
                                this.ViewBag.FiscalMonthId = new SelectList(db.Acc_FiscalMonths.Where(p => p.ComId.ToString() == transactioncomid && p.FiscalMonthId == budgetMain.FiscalMonthId), "FiscalMonthId", "MonthName", budgetMain.FiscalMonthId).ToList(); //&& c.ComId.ToString() == (transactioncomid)

                                return View(budgetMain);

                            }


                        }




                        this.ViewBag.Country = new SelectList(db.Countries.Where(x => x.isActive == true), "CountryId", "CurrencyShortName", transactioncompany.CountryId);
                        this.ViewBag.AccountMain = new SelectList(db.Acc_ChartOfAccounts.Where(p => p.comid.ToString() == transactioncomid && p.AccType == "L" && p.IsCashItem == true).Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text");
                        this.ViewBag.FiscalYearId = new SelectList(db.Acc_FiscalYears.Where(p => p.comid.ToString() == transactioncomid && p.FiscalYearId > 0), "FiscalYearId", "FYName").ToList(); //&& c.ComId.ToString() == (transactioncomid)
                        this.ViewBag.FiscalMonthId = new SelectList(db.Acc_FiscalMonths.Where(p => p.ComId.ToString() == transactioncomid && p.FiscalMonthId > 0), "FiscalMonthId", "MonthName").Take(0).ToList(); //&& c.ComId.ToString() == (transactioncomid)

                        return View(Budgetsamplemodel);

                    }
                    else
                    {


                        Acc_BudgetMain budgetMain = db.Acc_BudgetMains.Find(BudgetId);

                        if (budgetMain.isPosted == true)
                        {
                            return NotFound();
                        }
                        //Acc_BudgetMain budgetMain = db.Acc_BudgetMains.Find(id);
                        if (budgetMain == null)
                        {
                            return NotFound();
                        }
                        ViewBag.Title = "Edit";
                        this.ViewBag.Country = new SelectList(db.Countries.Where(x => x.isActive == true), "CountryId", "CurrencyShortName", budgetMain.CountryId);
                        int AccId = budgetMain.BudgetSubs.Where(x => x.SRowNo < 0).Select(x => x.AccId).FirstOrDefault();
                        this.ViewBag.AccountMain = new SelectList(db.Acc_ChartOfAccounts.Where(p => p.comid.ToString() == transactioncomid && p.AccType == "L" && p.IsCashItem == true).Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text", AccId);
                        this.ViewBag.FiscalYearId = new SelectList(db.Acc_FiscalYears.Where(p => p.comid.ToString() == transactioncomid && p.FiscalYearId > 0), "FiscalYearId", "FYName", budgetMain.FiscalYearId).ToList(); //&& c.ComId.ToString() == (transactioncomid)
                        this.ViewBag.FiscalMonthId = new SelectList(db.Acc_FiscalMonths.Where(p => p.ComId.ToString() == transactioncomid && p.FiscalMonthId == budgetMain.FiscalMonthId), "FiscalMonthId", "MonthName", budgetMain.FiscalMonthId).ToList(); //&& c.ComId.ToString() == (transactioncomid)

                        return View(budgetMain);

                    }
                }


                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public class ChartOfAccountsModel
        {

            public int MasterLCDetailsID { get; set; }

            public int ExportInvoiceDetailsId { get; set; }

            public string StyleName { get; set; }

            public string ExportPONo { get; set; }

            public string ShipmentDate { get; set; }

            public string Destination { get; set; }
            public float OrderQty { get; set; }
            public string UnitMasterId { get; set; }
            public decimal UnitPrice { get; set; }

            public decimal TotalValue { get; set; }


            public string PODate { get; set; }
            public string ColorCode { get; set; }
            public string DestinationPO { get; set; }






        }


        public async Task<JsonResult> CallComboSubSectionList()
        {
            try
            {
                //var SubSectionList = new SelectList(db.SubSections.Where(c => c.SubSectId > 0), "SubSectId", "SubSectName").ToList();

                var SubSectionList = db.Cat_SubSection.Select(e => new
                {
                    value = e.SubSectId,
                    display = e.SubSectName
                }).ToList();



                return Json(SubSectionList);

            }
            catch (Exception ex)
            {

                return Json(new { Success = 0, ex = ex.Message.ToString() });

            }
        }




        [HttpPost]
        public JsonResult AccountInfo(int id)
        {
            try
            {


                Acc_ChartOfAccount chartofaccount = db.Acc_ChartOfAccounts.Where(y => y.AccId == id).SingleOrDefault();


                return Json(chartofaccount);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, values = ex.Message.ToString() });
            }
        }


        [HttpPost]
        public JsonResult FYMonthInfo(int id)
        {
            try
            {
                var comid = HttpContext.Session.GetString("comid");
                //db.Configuration.ProxyCreationEnabled = false;
                //db.Configuration.LazyLoadingEnabled = false;

                //List<Acc_FiscalMonths> fiscalmonth = db.Acc_FiscalMonths.Where(y => y.FYId == id).ToList();

                int fyid = (db.Acc_FiscalYears.Where(x => x.FiscalYearId == id).Select(x => x.FYId).FirstOrDefault());
                //return Json(fiscalmonth );

                List<Acc_FiscalMonth> fiscalmonthlist = db.Acc_FiscalMonths.Where(x => x.FYId == fyid && x.ComId.ToString() == comid).ToList();

                List<SelectListItem> fiscalmonthselectlist = new List<SelectListItem>();

                //licities.Add(new SelectListItem { Text = "--Select State--", Value = "0" });
                if (fiscalmonthlist != null)
                {
                    foreach (Acc_FiscalMonth x in fiscalmonthlist)
                    {
                        fiscalmonthselectlist.Add(new SelectListItem { Text = x.MonthName, Value = x.FiscalMonthId.ToString() });
                    }
                }
                return Json(new SelectList(fiscalmonthselectlist, "Value", "Text"));




            }
            catch (Exception ex)
            {
                return Json(new { success = false, values = ex.Message.ToString() });
            }
        }


        // POST: /Budget/Create

        [HttpPost]
        public JsonResult Create(Acc_BudgetMain budgetMain)
        {
            try
            {


                //var errors = ModelState.Where(x => x.Value.Errors.Any())
                //.Select(x => new { x.Key, x.Value.Errors });

                {

                    // If sales main has BudgetID then we can understand we have existing sales Information
                    // So we need to Perform Update Operation

                    // Perform Update
                    if (budgetMain.BudgetId > 0)
                    {
                        //var CurrentProductSerial = db.ProductSerial.Where(p => p.BudgetId == budgetMain.BudgetId);
                        var CurrentBudgetSub = db.Acc_BudgetSubs.Where(p => p.BudgetId == budgetMain.BudgetId);
                        var CurrentBudgetSubSection = db.Acc_BudgetSubSections.Where(p => p.BudgetId == budgetMain.BudgetId);



                        //BudgetSub
                        //foreach (ProductSerial ss in CurrentProductSerial)
                        //db.ProductSerial.Remove(ss);

                        foreach (Acc_BudgetSub ss in CurrentBudgetSub)
                            db.Acc_BudgetSubs.Remove(ss);


                        foreach (Acc_BudgetSub ss in budgetMain.BudgetSubs)
                        {
                            //db.BudgetSubs.Add(ss);
                            db.Acc_BudgetSubs.Add(ss);

                            foreach (Acc_BudgetSubSection sss in ss.BudgetSubSections)
                            {
                                db.Acc_BudgetSubSections.Add(sss);



                            }

                        }


                        db.Entry(budgetMain).State = EntityState.Modified;
                        db.SaveChanges();
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), budgetMain.BudgetId.ToString(), "Update", budgetMain.BudgetId.ToString());

                    }
                    //Perform Save
                    else
                    {
                        budgetMain.userid = HttpContext.Session.GetString("userid");
                        budgetMain.comid = HttpContext.Session.GetString("comid");
                        budgetMain.DateAdded = DateTime.Now;

                        var x = BudgetNoMaker(budgetMain.comid.ToString(), budgetMain.FiscalYearId, budgetMain.FiscalMonthId); // nned to work..
                        budgetMain.BudgetNo = (x[0]);
                        budgetMain.BudgetSerialId = int.Parse(x[1]);

                        db.Acc_BudgetMains.Add(budgetMain);
                        db.SaveChanges();
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), budgetMain.BudgetId.ToString(), "Create", budgetMain.BudgetId.ToString());

                    }


                    // If Sucess== 1 then Save/Update Successfull else there it has Exception
                    return Json(new { Success = 1, BudgetID = budgetMain.BudgetId, ex = "" });
                }
            }
            catch (Exception ex)
            {

                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
            return Json(new { Success = 0, ex = new Exception("Unable to save").Message.ToString() });
        }


        public string[] BudgetNoMaker(string comid, int? fiscalyearid = 0, int? fiscalmonthid = 0)
        {
            string[] FinalAccCode = new string[2];
            var input = 0;
            int length = 6;
            int maxBudgetid = 0;
            var maxnowithpadleftresult = "";

            string voucernocreatestyle = "";

            //length = db.BudgetNoPrefixs.Where(x => x.BudgetTypeId == Budgettypeid && x.comid.ToString() == comid).Select(x => x.Length).FirstOrDefault();


            if (fiscalmonthid > 0)
            {
                maxBudgetid = db.Acc_BudgetMains.Where(x => x.comid.ToString() == comid && x.FiscalYearId == fiscalyearid && x.FiscalMonthId == fiscalmonthid).Max(x => x.BudgetSerialId);
                input = maxBudgetid + 1;
                maxnowithpadleftresult = input.ToString().PadLeft(length, '0');
                FinalAccCode[0] = "B-" + maxnowithpadleftresult.ToString();
                FinalAccCode[1] = input.ToString();
            }
            else
            {
                maxBudgetid = db.Acc_BudgetMains.Where(x => x.comid.ToString() == comid && x.FiscalYearId == fiscalyearid).Max(x => x.BudgetSerialId);
                input = maxBudgetid + 1;
                maxnowithpadleftresult = input.ToString().PadLeft(length, '0');
                FinalAccCode[0] = "B-" + maxnowithpadleftresult.ToString();
                FinalAccCode[1] = input.ToString();
            }


            return FinalAccCode;
        }

        //
        // GET: /Budget/Edit/5
        public ActionResult Edit(string Type, int? BudgetId)
        {

            try
            {
                ViewBag.Title = "Entry";
                var transactioncomid = HttpContext.Session.GetString("comid");

                if (Type == null)
                {
                    Type = "VPC";
                }




                var Budgetsamplemodel = db.BudgetMains.Include(x => x.BudgetDetails).Where(x => x.BudgetMainId == BudgetId).ToList();


                var transactioncompany = db.Companys.Where(c => c.ComId.ToString() == transactioncomid).FirstOrDefault();
                HttpContext.Session.SetInt32("defaultcurrencyid", transactioncompany.CountryId);
                HttpContext.Session.SetString("defaultcurrencyname", transactioncompany.vCountryCompany.CurrencyShortName);

                ViewBag.PrdUnitId = new SelectList(db.PrdUnits.Where(c => c.comid.ToString() == transactioncomid), "PrdUnitId", "PrdUnitName"); //&& c.ComId.ToString() == (transactioncomid)
                                                                                                                                                ///////account head parent data for dropdown
                var ChartOfAccountParent = db.Acc_ChartOfAccounts.Where(p => p.comid.ToString() == transactioncomid).Where(c => c.AccId > 0 && c.AccType == "G" && c.comid.ToString() == transactioncomid).Select(s => new { Text = s.AccName, Value = s.AccId }).ToList(); //&& c.ComId.ToString() == (transactioncomid)
                this.ViewBag.AccountParent = new SelectList(ChartOfAccountParent, "Value", "Text");


                var Acc_ChartOfAccounts = db.Acc_ChartOfAccounts.Where(c => c.comid.ToString() == transactioncomid && c.AccId > 0 && c.AccType == "L"); //&& c.ComId.ToString() == (transactioncomid)
                if (transactioncompany.isMultiDebitCredit == true)
                {
                    this.ViewBag.Account = new SelectList(Acc_ChartOfAccounts.Where(x => x.IsBankItem == false).Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text");
                }
                else
                {
                    this.ViewBag.Account = new SelectList(Acc_ChartOfAccounts.Where(x => x.IsBankItem == false && x.IsCashItem == false).Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text");
                }


                ///////only cash item when multi debit credit of then it enable
                this.ViewBag.AccountMain = new SelectList(db.Acc_ChartOfAccounts.Where(p => p.comid.ToString() == transactioncomid && p.AccType == "L" && p.IsCashItem == true).Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text");
                this.ViewBag.SubSectionList = db.Cat_SubSection.Where(x => x.ComId.ToString() == transactioncomid);


                return View("Create", Budgetsamplemodel);
            }
            catch (Exception ex)
            {
                string abcd = ex.InnerException.InnerException.Message.ToString();
                throw ex;
            }
        }


        // GET: /Budget/Delete/5
        public ActionResult Delete(int? BudgetId)
        {
            try
            {
                var transactioncomid = HttpContext.Session.GetString("comid");
                if (BudgetId == null)
                {
                    return NotFound();
                }


                Acc_BudgetMain budgetMain = db.Acc_BudgetMains.Find(BudgetId);

                if (budgetMain.isPosted == true)
                {
                    return NotFound();
                }

                if (budgetMain == null)
                {
                    return NotFound();
                }
                ViewBag.Title = "Delete";


                var transactioncompany = db.Companys.Where(c => c.ComId.ToString() == transactioncomid).FirstOrDefault();
                HttpContext.Session.SetInt32("defaultcurrencyid", transactioncompany.CountryId);
                HttpContext.Session.SetString("defaultcurrencyname", transactioncompany.vCountryCompany.CurrencyShortName);



                ViewBag.PrdUnitId = new SelectList(db.PrdUnits.Where(c => c.comid.ToString() == transactioncomid), "PrdUnitId", "PrdUnitName", budgetMain.PrdUnitId); //&& c.ComId.ToString() == (transactioncomid)
                                                                                                                                                                      ///////account head parent data for dropdown
                var ChartOfAccountParent = db.Acc_ChartOfAccounts.Where(p => p.comid.ToString() == transactioncomid).Where(c => c.AccId > 0 && c.AccType == "G" && c.comid.ToString() == transactioncomid).Select(s => new { Text = s.AccName, Value = s.AccId }).ToList(); //&& c.ComId.ToString() == (transactioncomid)
                this.ViewBag.AccountParent = new SelectList(ChartOfAccountParent, "Value", "Text");


                var Acc_ChartOfAccounts = db.Acc_ChartOfAccounts.Where(c => c.comid.ToString() == transactioncomid && c.AccId > 0 && c.AccType == "L"); //&& c.ComId.ToString() == (transactioncomid)
                if (transactioncompany.isMultiDebitCredit == true)
                {
                    this.ViewBag.Account = new SelectList(Acc_ChartOfAccounts.Where(x => x.IsBankItem == false).Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text");
                }
                else
                {
                    this.ViewBag.Account = new SelectList(Acc_ChartOfAccounts.Where(x => x.IsBankItem == false && x.IsCashItem == false).Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text");
                }


                ///////only cash item when multi debit credit of then it enable
                this.ViewBag.SubSectionList = db.Cat_SubSection.Where(x => x.ComId.ToString() == transactioncomid);

                this.ViewBag.Country = new SelectList(db.Countries.Where(x => x.isActive == true), "CountryId", "CurrencyShortName", budgetMain.CountryId);
                this.ViewBag.FiscalYearId = new SelectList(db.Acc_FiscalYears.Where(p => p.comid.ToString() == transactioncomid && p.FiscalYearId > 0), "FiscalYearId", "FYName", budgetMain.FiscalYearId).ToList(); //&& c.ComId.ToString() == (transactioncomid)
                this.ViewBag.FiscalMonthId = new SelectList(db.Acc_FiscalMonths.Where(p => p.ComId.ToString() == transactioncomid && p.FiscalMonthId == budgetMain.FiscalMonthId), "FiscalMonthId", "MonthName", budgetMain.FiscalMonthId).ToList(); //&& c.ComId.ToString() == (transactioncomid)


                this.ViewBag.Country = new SelectList(db.Countries.Where(x => x.isActive == true), "CountryId", "CurrencyShortName", budgetMain.CountryId);


                var ChartOfAccountsearch = db.Acc_ChartOfAccounts.Where(c => c.AccId > 0 && c.AccType == "L" && c.comid.ToString() == transactioncomid); //&& c.ComId.ToString() == (transactioncomid)
                this.ViewBag.AccountSearch = ChartOfAccountsearch;

                //Call Create View
                return View("Create", budgetMain);
            }
            catch (Exception ex)
            {
                string abcd = ex.InnerException.InnerException.Message.ToString();
                throw ex;
            }


        }


        // POST: /Budget/Delete/5
        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(int id)
        {
            try
            {
                //BudgetSub BudgetSub = db.BudgetSubs.Find(id);
                //db.BudgetSubs.Remove(BudgetSub);

                Acc_BudgetMain budgetMain = db.Acc_BudgetMains.Find(id);
                db.Acc_BudgetMains.Remove(budgetMain);
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), budgetMain.BudgetNo.ToString(), "Delete", budgetMain.BudgetNo.ToString());

                db.SaveChanges();
                return Json(new { Success = 1, BudgetID = budgetMain.BudgetId, ex = "" });

            }

            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.Message.ToString() });
            }

            return Json(new { Success = 0, ex = new Exception("Unable to Delete").Message.ToString() });
            // return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [HttpPost]
        public JsonResult ProductInfo(int id)
        {
            try
            {

                var product = db.Products.Where(y => y.ProductId == id).SingleOrDefault();

                return Json(product);
                //return Json("tesst" );

            }
            catch (Exception ex)
            {
                return Json(new { success = false, values = ex.Message.ToString() });
            }
            //return Json(new SelectList(product, "Value", "Text" ));
        }



    }
}