using GTERP.BLL;
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
//using AlanJuden.MvcReportViewer;
using System.Threading.Tasks;

namespace GTERP.Controllers.Account
{
    [OverridableAuthorize]

    public class Acc_AccountProcessController : Controller
    {
        private TransactionLogRepository tranlog;

        private readonly GTRDBContext db;
        private readonly POSRepository POS;



        public Acc_AccountProcessController(GTRDBContext context, POSRepository _POS, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
            POS = _POS;
        }

        public JsonResult GetMonthList(int? id)
        {


            string comid = HttpContext.Session.GetString("comid");

            //db.Configuration.ProxyCreationEnabled = false;
            //db.Configuration.LazyLoadingEnabled = false;
            if (id == null)
            {
                List<Acc_FiscalYear> fiscalyear = db.Acc_FiscalYears.Where(x => x.comid == comid && x.isLocked == false).ToList();
                id = fiscalyear.Max(p => p.FYId);
            }

            List<Acc_FiscalMonth> Acc_FiscalMonth = db.Acc_FiscalMonths
                .Where(x => x.FYId == id && x.isLocked == false
                && !db.HR_ProcessLock.Any(p => p.FiscalMonthId == x.FiscalMonthId && p.IsLock == true && p.LockType.Contains("Account Lock"))).ToList();
            //&& db.HR_ProcessLock.Contains(x.FiscalMonthId) && db.HR_ProcessLock.Where(p=> p.IsLock==true && p.LockType.Contains("Account Lock"))).ToList();
            List<fymonthclass> data = new List<fymonthclass>();

            int i = 0;
            foreach (Acc_FiscalMonth item in Acc_FiscalMonth)
            {
                fymonthclass asdf = new fymonthclass
                {
                    //asdf.MasterLCID = item.ExportInvoiceMasters.COM_MasterLC.MasterLCID;
                    isCheck = i++,
                    MonthId = item.MonthId,
                    MonthName = item.MonthName, //DateTime.Parse(item.InvoiceDate.ToString()).ToString("dd-MMM-yy");
                    dtFrom = item.dtFrom,
                    dtTo = item.dtTo
                };


                data.Add(asdf);
            }

            return Json(data);
            //return Json(new { Success = 1, data = asdf }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SetProcess(string[] monthid, string criteria, int? Currency, string FYId, string MinAccCode, string MaxAccCode)
        {

            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");

            if (criteria.ToUpper().ToString() == "TrialB".ToUpper())
            {
                if (monthid.Count() > 0)
                {
                    for (var i = 0; i < monthid.Count(); i++)
                    {
                        var monthidsingle = monthid[i];

                        var query = $"Exec prcProcessTrailBalance '{userid}','{comid}',{monthidsingle},{Currency},'TrialBProcess' ";

                        SqlParameter[] sqlParameter = new SqlParameter[5];

                        sqlParameter[0] = new SqlParameter("@UserId", userid);
                        sqlParameter[1] = new SqlParameter("@ComId", comid);
                        sqlParameter[2] = new SqlParameter("@MonthId", monthidsingle);
                        sqlParameter[3] = new SqlParameter("@Currency", Currency);
                        sqlParameter[4] = new SqlParameter("@PCName", "TrialBProcess");


                        Helper.ExecProc("prcProcessTrailBalance", sqlParameter);



                        // need change
                        //db.Database.ExecuteSqlCommand("Exec prcProcessTrailBalance @UserId , @ComId , @MonthId , @Currency , @PCName", new SqlParameter("@userid", Session["userid"]), new SqlParameter("@ComId", Session["comid"]), new SqlParameter("@MonthId", x), new SqlParameter("@Currency", Currency), new SqlParameter("@PCName", "Fahad"));

                        //sqlQuery = "Exec prcProcessTrailBalance " + Session["UserId"] + ", " + Session["ComId"] + ", " +
                        //        model.ProcessMonths[i].MonthId + ", " + model.CountryId + ", '' ";
                        //    //arQuery.Add(sqlQuery);

                    }
                }
            }
            else if (criteria.ToUpper().ToString() == "AllLedger".ToUpper())
            {
                if (monthid.Count() > 0)
                {
                    if (MinAccCode == null)
                    {
                        MinAccCode = "1-0-00-000-00000";
                    }
                    if (MaxAccCode == null)
                    {
                        MaxAccCode = "5-0-00-000-00000";
                    }
                    //for (var i = 0; i < monthid.Count(); i++)
                    //{
                    //var monthidsingle = monthid[i];
                    var query = $"Exec Acc_Process_LedgerMultiALL '{comid}','{userid}',{monthid.FirstOrDefault()},{Currency},'{MinAccCode}','{MaxAccCode}' ";

                    SqlParameter[] sqlParameter = new SqlParameter[6];

                    sqlParameter[0] = new SqlParameter("@ComId", comid);
                    sqlParameter[1] = new SqlParameter("@UserId", userid);
                    //sqlParameter[2] = new SqlParameter("@FYId", FYId);
                    sqlParameter[2] = new SqlParameter("@MonthId", monthid.FirstOrDefault());
                    sqlParameter[3] = new SqlParameter("@Currency", Currency);
                    sqlParameter[4] = new SqlParameter("@MinAccCode", MinAccCode);
                    sqlParameter[5] = new SqlParameter("@MaxAccCode", MaxAccCode);

                    //sqlParameter[6] = new SqlParameter("@PCName", "AllLedger");

                    Helper.ExecProc("Acc_Process_LedgerMultiALL", sqlParameter);
                    //}


                }
            }
            else if (criteria.ToUpper().ToString() == "cogs".ToUpper())
            {
                if (monthid.Count() > 0)
                {

                    for (var i = 0; i < monthid.Count(); i++)
                    {
                        var monthidsingle = monthid[i];



                        var query = $"Exec prcProcessCostOfService '{userid}','{comid}',{monthidsingle},{Currency},'COGSProcess' ";

                        SqlParameter[] sqlParameter = new SqlParameter[5];

                        sqlParameter[0] = new SqlParameter("@UserId", userid);
                        sqlParameter[1] = new SqlParameter("@ComId", comid);
                        sqlParameter[2] = new SqlParameter("@MonthId", monthidsingle);
                        sqlParameter[3] = new SqlParameter("@Currency", Currency);
                        sqlParameter[4] = new SqlParameter("@PCName", "COGSProcess");


                        Helper.ExecProc("prcProcessCostOfService", sqlParameter);


                        // need change
                        ///// db.Database.ExecuteSqlCommand("Exec prcProcessCostOfService @UserId , @ComId , @MonthId , @Currency , @PCName", new SqlParameter("@userid", Session["userid"]), new SqlParameter("@ComId", Session["comid"]), new SqlParameter("@MonthId", x), new SqlParameter("@Currency", Currency), new SqlParameter("@PCName", "Fahad"));

                        //sqlQuery = "Exec GTRAccounts.dbo.prcProcessCostOfService " + Session["UserId"] + ", " +
                        //        Session["ComId"] + ", " + model.ProcessMonths[i].MonthId + ", " + model.CountryId + ", '' ";
                        //    //arQuery.Add(sqlQuery);
                    }


                }
            }
            else if (criteria.ToUpper().ToString() == "income".ToUpper())
            {
                if (monthid.Count() > 0)
                {

                    for (var i = 0; i < monthid.Count(); i++)
                    {
                        var monthidsingle = monthid[i];

                        //Exec prcProcessIncome '4864add7-0ab2-4c4f-9eb8-6b63a425e665','31312c54-659b-4e63-b4ba-2bc3d7b05792',13,18,'Fahad'
                        var query = $"Exec prcProcessIncome '{userid}','{comid}',{monthidsingle},{Currency},'IncomeProcess' ";

                        SqlParameter[] sqlParameter = new SqlParameter[5];

                        sqlParameter[0] = new SqlParameter("@UserId", userid);
                        sqlParameter[1] = new SqlParameter("@ComId", comid);
                        sqlParameter[2] = new SqlParameter("@MonthId", monthidsingle);
                        sqlParameter[3] = new SqlParameter("@Currency", Currency);
                        sqlParameter[4] = new SqlParameter("@PCName", "IncomeProcess");


                        Helper.ExecProc("prcProcessIncome", sqlParameter);

                    }


                }
            }
            else if (criteria.ToUpper().ToString() == "bs".ToUpper())
            {
                if (monthid.Count() > 0)
                {

                    for (var i = 0; i < monthid.Count(); i++)
                    {
                        var monthidsingle = monthid[i];

                        //Exec prcProcessIncome '4864add7-0ab2-4c4f-9eb8-6b63a425e665','31312c54-659b-4e63-b4ba-2bc3d7b05792',13,18,'Fahad'
                        var query = $"Exec [prcProcessBalanceSheet] '{userid}','{comid}',{monthidsingle},{Currency},'BalanceSheetProcess' ";

                        SqlParameter[] sqlParameter = new SqlParameter[5];

                        sqlParameter[0] = new SqlParameter("@UserId", userid);
                        sqlParameter[1] = new SqlParameter("@ComId", comid);
                        sqlParameter[2] = new SqlParameter("@MonthId", monthidsingle);
                        sqlParameter[3] = new SqlParameter("@Currency", Currency);
                        sqlParameter[4] = new SqlParameter("@PCName", "BalanceSheetProcess");


                        Helper.ExecProc("prcProcessBalanceSheet", sqlParameter);

                    }


                }
            }
            else if (criteria.ToUpper().ToString() == "cb".ToUpper())
            {
                if (monthid.Count() > 0)
                {

                    for (var i = 0; i < monthid.Count(); i++)
                    {
                        var monthidsingle = monthid[i];

                        //Exec prcProcessIncome '4864add7-0ab2-4c4f-9eb8-6b63a425e665','31312c54-659b-4e63-b4ba-2bc3d7b05792',13,18,'Fahad'
                        var query = $"Exec [prcProcessCostBreakup] '{userid}','{comid}',{monthidsingle},{Currency},'CBProcess' ";

                        SqlParameter[] sqlParameter = new SqlParameter[5];

                        sqlParameter[0] = new SqlParameter("@UserId", userid);
                        sqlParameter[1] = new SqlParameter("@ComId", comid);
                        sqlParameter[2] = new SqlParameter("@MonthId", monthidsingle);
                        sqlParameter[3] = new SqlParameter("@Currency", Currency);
                        sqlParameter[4] = new SqlParameter("@PCName", "CBProcess");


                        Helper.ExecProc("prcProcessCostBreakup", sqlParameter);

                    }


                }
            }
            else if (criteria.ToUpper().ToString() == "all".ToUpper())
            {
                if (monthid.Count() > 0)
                {

                    for (var i = 0; i < monthid.Count(); i++)
                    {
                        var monthidsingle = monthid[i];

                        //Exec prcProcessIncome '4864add7-0ab2-4c4f-9eb8-6b63a425e665','31312c54-659b-4e63-b4ba-2bc3d7b05792',13,18,'Fahad'
                        var query = $"Exec prcProcessTrailBalance '{userid}','{comid}',{monthidsingle},{Currency},'TrialBProcess' ";
                        query = $"Exec prcProcessCostOfService '{userid}','{comid}',{monthidsingle},{Currency},'COGSProcess' ";
                        query = $"Exec prcProcessIncome '{userid}','{comid}',{monthidsingle},{Currency},'IncomeProcess' ";
                        query = $"Exec [prcProcessBalanceSheet] '{userid}','{comid}',{monthidsingle},{Currency},'BalanceSheetProcess' ";
                        query = $"Exec [prcProcessCostBreakup] '{userid}','{comid}',{monthidsingle},{Currency},'CBProcess' ";


                        SqlParameter[] sqlParameter = new SqlParameter[5];
                        sqlParameter[0] = new SqlParameter("@UserId", userid);
                        sqlParameter[1] = new SqlParameter("@ComId", comid);
                        sqlParameter[2] = new SqlParameter("@MonthId", monthidsingle);
                        sqlParameter[3] = new SqlParameter("@Currency", Currency);
                        sqlParameter[4] = new SqlParameter("@PCName", "ALLProcess");



                        Helper.ExecProc("prcProcessTrailBalance", sqlParameter);
                        Helper.ExecProc("prcProcessCostOfService", sqlParameter);
                        Helper.ExecProc("prcProcessIncome", sqlParameter);
                        Helper.ExecProc("prcProcessBalanceSheet", sqlParameter);
                        Helper.ExecProc("prcProcessCostBreakup", sqlParameter);

                    }


                }
            }
            else if (criteria.ToUpper().ToString() == "notes".ToUpper())
            {
                //if (monthid.Count() > 0)
                //{

                //    for (var i = 0; i < monthid.Count(); i++)
                //    {
                var monthidsingle = 0;// monthid[i];

                //Exec prcProcessIncome '4864add7-0ab2-4c4f-9eb8-6b63a425e665','31312c54-659b-4e63-b4ba-2bc3d7b05792',13,18,'Fahad'
                var query = $"Exec [prcProcessNotesBCIC] '{userid}','{comid}',{monthidsingle},{Currency},'NoteProcess' ,{FYId}  ";

                SqlParameter[] sqlParameter = new SqlParameter[6];

                sqlParameter[0] = new SqlParameter("@UserId", userid);
                sqlParameter[1] = new SqlParameter("@ComId", comid);
                sqlParameter[2] = new SqlParameter("@MonthId", monthidsingle);
                sqlParameter[3] = new SqlParameter("@Currency", Currency);
                sqlParameter[4] = new SqlParameter("@PCName", "NoteProcess");
                sqlParameter[5] = new SqlParameter("@FiscalYearId", FYId);



                Helper.ExecProc("prcProcessNotesBCIC", sqlParameter);

                //    }


                //}
            }



            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), "Set Process", criteria, "Update", criteria);


            //int comid = int.Parse(Session["comid"].ToString());

            //db.Configuration.ProxyCreationEnabled = false;
            //db.Configuration.LazyLoadingEnabled = false;
            //if (id == null)
            //{
            //    List<Acc_FiscalYear> fiscalyear = db.Acc_FiscalYears.Where(x => x.comid == comid).ToList();
            //    id = fiscalyear.Max(p => p.FYId);
            //}

            //List<Acc_FiscalMonth> Acc_FiscalMonth = db.Acc_FiscalMonths.Where(x => x.FYId == id).ToList();
            //List<fymonthclass> data = new List<fymonthclass>();

            //int i = 0;
            //foreach (Acc_FiscalMonth item in Acc_FiscalMonth)
            //{
            //    fymonthclass asdf = new fymonthclass
            //    {
            //        //asdf.MasterLCID = item.ExportInvoiceMasters.COM_MasterLC.MasterLCID;
            //        isCheck = i++,
            //        MonthId = item.MonthId,
            //        MonthName = item.MonthName, //DateTime.Parse(item.InvoiceDate.ToString()).ToString("dd-MMM-yy");
            //        dtFrom = item.dtFrom,
            //        dtTo = item.dtTo
            //    };


            //    data.Add(asdf);
            //}


            if (AppData.AppData.globalException.Length > 0)
            {
                return Json(AppData.AppData.globalException);
            }

            var data = "abcd";
            return Json(data = "1");
            ////return Json(new { Success = 1, data = asdf }, JsonRequestBehavior.AllowGet);
        }


        public class fymonthclass
        {
            //public int FiscalMonthId { get; set; }
            public int MonthId { get; set; }
            public int isCheck { get; set; }

            public string MonthName { get; set; }
            public string dtFrom { get; set; }
            public string dtTo { get; set; }
            //public int FYId { get; set; }

        }


        public async Task<IActionResult> Index()
        {
            //var gTRDBContext = db.HR_Emp_Info.Include(h => h.Cat_BloodGroup).Include(h => h.Cat_Department).Include(h => h.Cat_Designation).Include(h => h.Cat_Floor).Include(h => h.Cat_Grade).Include(h => h.Cat_Line).Include(h => h.Cat_Religion).Include(h => h.Cat_Section).Include(h => h.Cat_Shift).Include(h => h.Cat_SubSection).Include(h => h.Cat_Unit);
            string comid = HttpContext.Session.GetString("comid");
            int defaultcountry = (db.Companys.Where(a => a.CompanyCode == comid.ToString()).Select(a => a.CountryId).FirstOrDefault());

            ViewBag.CountryId = new SelectList(await POS.GetCountryAsync(), "CountryId", "CurrencyShortName", defaultcountry);

            Acc_AccProcessViewModel model = new Acc_AccProcessViewModel();
            List<Acc_FiscalYear> fiscalyear = db.Acc_FiscalYears.Where(x => x.comid == comid && x.isLocked == false).ToList();
            int fiscalyid = fiscalyear.Max(p => p.FYId);

            List<Acc_FiscalMonth> fiscalmonth = db.Acc_FiscalMonths.Where(x => x.FYId == fiscalyid).ToList();

            model.ProcessFYs = fiscalyear;
            model.ProcessMonths = fiscalmonth;
            model.CountryId = defaultcountry;

            TempData["Status"] = "2";
            TempData["Message"] = "Account Process";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", ""); /// transaction log when enable it throw error
            //need to talk with himu

            //AccProcessViewModel.PrcSetData(model, "Create", dsDetails);
            return View(model);


            //return View(await _repos.GetEmpAsync());
        }

        // GET: Section


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Acc_AccProcessViewModel model, string criteria, string command)
        {
            //DataSet dsList = new DataSet();
            //DataSet dsDetails = new DataSet();
            try
            {
                if (command != "Save")
                {
                    if (command == "0")
                    {
                        string comid = HttpContext.Session.GetString("comid");
                        int defaultcountry = (db.Companys.Where(a => a.CompanySecretCode == comid.ToString()).Select(a => a.CountryId).FirstOrDefault());

                        ViewBag.CountryId = new SelectList(POS.GetCountry(), "CountryId", "CurrencyShortName", defaultcountry);

                        //AccProcessViewModel model = new AccProcessViewModel();
                        List<Acc_FiscalYear> fiscalyear = db.Acc_FiscalYears.Where(x => x.comid == comid && x.isLocked == false).ToList();
                        int fiscalyid = fiscalyear.Max(p => p.FYId);

                        List<Acc_FiscalMonth> fiscalmonth = db.Acc_FiscalMonths.Where(x => x.FYId == fiscalyid && x.isLocked == false).ToList();

                        model.ProcessFYs = fiscalyear;
                        model.ProcessMonths = fiscalmonth;
                        model.CountryId = defaultcountry;
                    }
                    else
                    {
                        int fiscalyid = int.Parse(command);

                        List<Acc_FiscalMonth> fiscalmonth = db.Acc_FiscalMonths.Where(x => x.FYId == fiscalyid).ToList();
                        ViewBag.CountryId = new SelectList(POS.GetCountry(), "CountryId", "CurrencyShortName");

                        //dsDetails = AccProcessViewModel.prcGetData(command);
                        //List<clsCommon.clsCombo2> Curr = clsGenerateList.prcColumnTwo(dsDetails.Tables[3]);
                        //ViewBag.Currency = Curr;
                        //AccProcessViewModel.PrcSetData(model, "Create", dsDetails);
                    }
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        var values = prcDataSave(model, criteria);
                        //if (values == "Process Completed Successfully")
                        //{
                        //    dsList = AccProcessViewModel.prcGetData("0");
                        //    var fiscalyid = "0";
                        //    fiscalyid = dsList.Tables[0].Rows[0]["FYId"].ToString();
                        //    dsDetails = AccProcessViewModel.prcGetData(fiscalyid);
                        //    List<clsCommon.clsCombo2> Curr1 = clsGenerateList.prcColumnTwo(dsList.Tables[3]);
                        //    ViewBag.Currency = Curr1;
                        //    ModelState.Clear();
                        //    AccProcessViewModel.PrcSetData(model, "Create", dsDetails);
                        //}

                        //dsList = rptSummaryReport.prcGetData("0");
                        //List<clsCommon.clsCombo2> Curr = clsGenerateList.prcColumnTwo(dsList.Tables[3]);
                        //ViewBag.Currency = Curr;
                        //ModelState.AddModelError("CustomError", values);
                        return View(model);
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {
                //dsList = rptSummaryReport.prcGetData("0");
                //List<clsCommon.clsCombo2> Curr = clsGenerateList.prcColumnTwo(dsList.Tables[3]);
                //ViewBag.Currency = Curr;
                //ModelState.AddModelError("CustomError", ex.Message);
                return View(model);
            }

        }

        public string prcDataSave(Acc_AccProcessViewModel model, string criteria)
        {

            var sqlQuery = "";
            try
            {
                if (criteria.ToUpper().ToString() == "TrialB".ToUpper())
                {
                    if (model.ProcessMonths.Count > 0)
                    {
                        for (var i = 0; i < model.ProcessMonths.Count; i++)
                        {
                            if (model.ProcessMonths[i].isCheck == true)
                            {
                                sqlQuery = "Exec prcProcessTrailBalance " + HttpContext.Session.GetString("userid") + ", " + HttpContext.Session.GetString("comid") + ", " +
                                    model.ProcessMonths[i].MonthId + ", " + model.CountryId + ", '' ";
                                //arQuery.Add(sqlQuery);
                            }
                        }
                    }
                }
                else if (criteria.ToUpper().ToString() == "cogs".ToUpper())
                {
                    if (model.ProcessMonths.Count > 0)
                    {
                        for (var i = 0; i < model.ProcessMonths.Count; i++)
                        {
                            if (model.ProcessMonths[i].isCheck == true)
                            {
                                sqlQuery = "Exec GTRAccounts.dbo.prcProcessCostOfService " + HttpContext.Session.GetString("userid") + ", " +
                                HttpContext.Session.GetString("comid") + ", " + model.ProcessMonths[i].MonthId + ", " + model.CountryId + ", '' ";
                                //arQuery.Add(sqlQuery);
                            }
                        }
                    }
                }
                else if (criteria.ToUpper().ToString() == "income".ToUpper())
                {
                    if (model.ProcessMonths.Count > 0)
                    {
                        for (var i = 0; i < model.ProcessMonths.Count; i++)
                        {
                            if (model.ProcessMonths[i].isCheck == true)
                            {
                                sqlQuery = "Exec GTRAccounts.dbo.prcProcessIncome " + HttpContext.Session.GetString("userid") + ", " + HttpContext.Session.GetString("comid") + ", " + model.ProcessMonths[i].MonthId + ", " + model.CountryId + ", '' ";
                                //arQuery.Add(sqlQuery);
                            }
                        }
                    }
                }
                //clsCon.GTRSaveDataWithSQLCommand(arQuery);
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), "Process data", criteria, "Save", criteria);

                return "Process Completed Successfully";
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                //clsCon = null;
            }
        }
    }
}