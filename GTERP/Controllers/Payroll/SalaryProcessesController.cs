#region Assembly refferance
using GTERP.Models;
using GTERP.Models.Common;
using GTERP.Models.Payroll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace GTERP.Controllers.Payroll
{
    #region Controller
    [OverridableAuthorize]
    public class SalaryProcessesController : Controller
    {
        #region Feild and Poperties
        private readonly GTRDBContext db;

        public clsConnectionNew clsCon { get; set; }
        public clsProcedure clsProc { get; }

        public SalaryProcessesController(GTRDBContext context, clsConnectionNew _clsCon, clsProcedure _clsProc)
        {
            db = context;
            clsCon = _clsCon;
            clsProc = _clsProc;
        }
        #endregion

        // GET: SalaryProcesses
        #region Index
        public async Task<IActionResult> Create()
        {
            return View("Create");

        }

        #endregion


        #region Create get
        //[HttpGet]
        //[Route("Create")]
        public async Task<IActionResult> Index()
        {
            //if (HttpContext.Session.GetString("DisplayName") == null)
            //{
            //    return RedirectToRoute("GTR");
            //}
            SalaryProcess model = new SalaryProcess();
            //ViewBag.SalaryPross=  db.SalaryProcess.ToList();
            string comid = HttpContext.Session.GetString("comid");

            ViewBag.FestType = new SelectList(db.Cat_Variable
                .Where(x => x.VarType == "FestivalType").OrderBy(x => x.SLNo).ToList(), "VarName", "VarName");
            ViewBag.SalType = new SelectList(db.Cat_Variable
                .Where(x => x.VarType == "SalaryType").OrderBy(x => x.SLNo).ToList(), "VarName", "VarName");

            ViewBag.EmpType = new SelectList(db.Cat_Emp_Type.Where(x => x.ComId == comid), "EmpTypeId", "EmpTypeName");
            ViewBag.Religion = new SelectList(db.Cat_Religion.Where(x => x.ComId == comid), "RelgionId", "ReligionName");


            return View(model);
        }

        #endregion

        #region Create Post

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Index(SalaryProcess salary)
        {

            //var JObject = new JObject();
            //var d = JObject.Parse(salProssModel);
            //string objct = d["salProssModel"].ToString();

            //var model = JsonConvert.DeserializeObject<SalaryProcess>(objct);
            var model = salary;
            var command = model.Command;
            try
            {
                if (ModelState.IsValid)
                {
                    if (command.ToUpper().ToString() == "ProssSalAct".ToUpper())
                    {
                        var values = prcProcessSalaryAct(model);
                        if (values.ToString().ToUpper().Contains("Complete".ToUpper()))
                        {
                            TempData["Message"] = values;
                            return Json(new { Success = 1, ex = TempData["Message"].ToString() });
                        }
                        else
                        {
                            TempData["Message"] = values;
                            return Json(new { Success = 2, ex = TempData["Message"].ToString() });
                        }
                    }
                    else if (command.ToUpper().ToString() == "ProssSalRel".ToUpper())
                    {
                        var values = prcProcessSalaryRel(model);
                        if (values.ToString().ToUpper().Contains("Complete".ToUpper()))
                        {
                            TempData["Message"] = values;
                            return Json(new { Success = 1, ex = TempData["Message"].ToString() });
                        }
                        else
                        {
                            TempData["Message"] = values;
                            return Json(new { Success = 2, ex = TempData["Message"].ToString() });
                        }
                    }
                    else if (command.ToUpper().ToString() == "prossFest".ToUpper())
                    {
                        var values = prcProcessFestBonus(model);
                        if (values.ToString().ToUpper().Contains("Complete".ToUpper()))
                        {
                            TempData["Message"] = values;
                            return Json(new { Success = 1, ex = TempData["Message"].ToString() });
                        }
                        else
                        {
                            TempData["Message"] = values;
                            return Json(new { Success = 2, ex = TempData["Message"].ToString() });
                        }
                    }
                    else if (command.ToUpper().ToString() == "prossSalAdv".ToUpper())
                    {
                        var values = prcProcessFestAdv(model);
                        if (values.ToString().ToUpper().Contains("Complete".ToUpper()))
                        {
                            TempData["Message"] = values;
                            return Json(new { Success = 1, ex = TempData["Message"].ToString() });
                        }
                        else
                        {
                            TempData["Message"] = values;
                            return Json(new { Success = 2, ex = TempData["Message"].ToString() });
                        }
                    }
                    else if (command.ToUpper().ToString() == "dltprossFest".ToUpper())
                    {
                        var values = prcProcessFestBonusDelete(model);
                        if (values.ToString().ToUpper().Contains("Delete".ToUpper()))
                        {
                            TempData["Message"] = values;
                            return Json(new { Success = 1, ex = TempData["Message"].ToString() });
                        }
                        else
                        {
                            TempData["Message"] = values;
                            return Json(new { Success = 2, ex = TempData["Message"].ToString() });
                        }
                    }
                    else if (command.ToUpper().ToString() == "dltprossSalAdv".ToUpper())
                    {
                        var values = prcDeleteFestAdv(model);
                        if (values.ToString().ToUpper().Contains("Delete".ToUpper()))
                        {
                            TempData["Message"] = values;
                            return Json(new { Success = 1, ex = TempData["Message"].ToString() });
                        }
                        else
                        {
                            TempData["Message"] = values;
                            return Json(new { Success = 2, ex = TempData["Message"].ToString() });
                        }
                    }
                    else if (command.ToUpper().ToString() == "dltprossSalAdv".ToUpper())
                    {
                        var values = prcDeleteFestAdv(model);
                        if (values.ToString().ToUpper().Contains("Delete".ToUpper()))
                        {
                            TempData["Message"] = values;
                            return Json(new { Success = 1, ex = TempData["Message"].ToString() });
                        }
                        else
                        {
                            TempData["Message"] = values;
                            return Json(new { Success = 2, ex = TempData["Message"].ToString() });
                        }
                    }
                    else if (command.ToUpper().ToString() == "prossEarnLeave".ToUpper())
                    {
                        var values = prcProcessEarnLeave(model);
                        if (values.ToString().ToUpper().Contains("Complete".ToUpper()))
                        {
                            TempData["Message"] = values;
                            return Json(new { Success = 1, ex = TempData["Message"].ToString() });
                        }
                        else
                        {
                            TempData["Message"] = values;
                            return Json(new { Success = 2, ex = TempData["Message"].ToString() });
                        }
                    }
                    else if (command.ToUpper().ToString() == "PFIndividual".ToUpper())
                    {
                        var values = prcProcessPFIndividual(model);
                        if (values.ToString().ToUpper().Contains("Complete".ToUpper()))
                        {
                            TempData["Message"] = values;
                            return Json(new { Success = 1, ex = TempData["Message"].ToString() });
                        }
                        else
                        {
                            TempData["Message"] = values;
                            return Json(new { Success = 2, ex = TempData["Message"].ToString() });
                        }
                    }
                    else
                    {
                        TempData["Message"] = "Criteria Not Mach";
                        return Json(new { Success = 2, ex = TempData["Message"].ToString() });
                    }
                }
                else
                {
                    TempData["Message"] = "Model State Not Valid";
                    return Json(new { Success = 3, ex = TempData["Message"].ToString() });
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return Json(new { Success = 3, ex = TempData["Message"].ToString() });
            }

        }
        #endregion

        #region Commented code

        //[HttpPost]
        //public ActionResult EarnLeavePrc(SalaryProcess earnLeavePrc)
        //{
        //    SalaryProcess salaryProcess=new SalaryProcess();
        //    int rowEffect=salaryProcess.PrcEarnLeave(earnLeavePrc);
        //    if (rowEffect>0)
        //    {
        //        ViewBag.loadMsg = "save";
        //    }
        //    else
        //    {
        //        ViewBag.msgErr = "error";
        //    }
        //    return Json(rowEffect, JsonRequestBehavior.AllowGet);
        //}

        #endregion

        #region PrcLoadCombo

        public void prcLoadCombo()
        {
            var comid = HttpContext.Session.GetString("comid");
            DataSet dsList = new DataSet();
            try
            {
                string sqlQuery = "Exec prcGetSalPross '" + comid + "' ";
                clsCon.GTRFillDatasetWithSQLCommand(ref dsList, sqlQuery);

                // Load Combo
                List<clsCommon.clsCombo1> Sal = clsGenerateList.prcColumnOne(dsList.Tables[0]);
                ViewBag.SalType = Sal;
                List<clsCommon.clsCombo1> Fest = clsGenerateList.prcColumnOne(dsList.Tables[1]);
                ViewBag.FestType = Fest;
                ViewBag.firstDate = dsList.Tables[3].Rows[0]["firstDate"].ToString();
                ViewBag.lastDate = dsList.Tables[4].Rows[0]["lastDate"].ToString();
                ViewBag.SalDesc = dsList.Tables[5].Rows[0]["SalDesc"].ToString();
                List<clsCommon.clsCombo1> Rel = clsGenerateList.prcColumnOne(dsList.Tables[6]);
                List<clsCommon.clsCombo1> Type = clsGenerateList.prcColumnOne(dsList.Tables[7]);
                ViewBag.EmpType = Type;
                ViewBag.Religions = Rel;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                clsCon = null;
            }
        }
        #endregion

        #region PrcProcessSalaryAct
        public String prcProcessSalaryAct(SalaryProcess model)
        {
            var comid = HttpContext.Session.GetString("comid");
            ArrayList arQuery = new ArrayList();


            try
            {
                var path = HttpContext.Request.GetEncodedUrl().ToString();
                if (path == null || path.Length == 0)
                {
                    path = "SalaryProcess";
                }

                string sqlQuery1 = "", SelDescription = "";
                Int64 ChkLock = 0;

                List<HR_ProcessLock> hrprocesslock = db.HR_ProcessLock.Where(x => x.ComId == comid && x.LockType == "Active Salary Lock"
                && (x.DtDate >= Convert.ToDateTime(model.dtFirst) && x.DtDate <= Convert.ToDateTime(model.dtLast) && x.IsLock == true)).ToList();
                //sqlQuery1 = "Select dbo.fncProcessLock (" + HttpContext.Session.GetString("comid") + ", 'Active Salary Lock','" + clsProc.GTRDate(model.dtFirst) + "')";
                ChkLock = hrprocesslock.Count();// clsCon.GTRCountingDataLarge(sqlQuery1);

                if (ChkLock >= 1)
                {
                    return "Process Lock. Please communicate to Administrator";
                }
                else
                {

                    SqlParameter[] parameter = new SqlParameter[5];
                    parameter[0] = new SqlParameter("@ComId", comid);
                    parameter[1] = new SqlParameter("@FirstDate", Helper.GTRDate(model.dtFirst.ToString()));
                    parameter[2] = new SqlParameter("@LastDate", Helper.GTRDate(model.dtLast.ToString()));
                    parameter[3] = new SqlParameter("@PaymentDate", Helper.GTRDate(model.dtPayment.ToString()));
                    parameter[4] = new SqlParameter("@ProssType", model.salDesc);
                    Helper.ExecProc("HR_prcProcessSalary", parameter);

                    return "Process Complete";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }



        }
        #endregion

        #region PrcProcessSalaryRel
        public String prcProcessSalaryRel(SalaryProcess model)
        {
            ArrayList arQuery = new ArrayList();
            try
            {
                string comid = HttpContext.Session.GetString("comid");
                var path = HttpContext.Request.GetEncodedUrl().ToString();
                if (path == null || path.Length == 0)
                {
                    path = "SalaryProcess";
                }
                string sqlQuery1 = "", SelDescription = "";
                Int64 ChkLock = 0;

                //sqlQuery1 = "Select dbo.fncProcessLock (" + HttpContext.Session.GetString("ComId") + ", 'Released Salary Lock','" + clsProc.GTRDate(model.dtFirst) + "')";
                //ChkLock = Helper.GTRCountingDataLarge(sqlQuery1);


                List<HR_ProcessLock> hrprocesslock = db.HR_ProcessLock.Where(x => x.ComId == comid && x.LockType == "Released Salary Lock"
                && (x.DtDate >= Convert.ToDateTime(model.dtFirst) && x.DtDate <= Convert.ToDateTime(model.dtLast) && x.IsLock == true)).ToList();
                //sqlQuery1 = "Select dbo.fncProcessLock (" + HttpContext.Session.GetString("comid") + ", 'Active Salary Lock','" + clsProc.GTRDate(model.dtFirst) + "')";
                ChkLock = hrprocesslock.Count();// clsCon.GTRCountingDataLarge(sqlQuery1);

                if (ChkLock >= 1)
                {
                    return "Process Lock. Please communicate to Administrator";
                }
                else
                {
                    SqlParameter[] parameter = new SqlParameter[5];
                    parameter[0] = new SqlParameter("@ComId", comid);
                    parameter[1] = new SqlParameter("@FirstDate", Helper.GTRDate(model.dtFirst.ToString()));
                    parameter[2] = new SqlParameter("@LastDate", Helper.GTRDate(model.dtLast.ToString()));
                    parameter[3] = new SqlParameter("@PaymentDate", Helper.GTRDate(model.dtPayment.ToString()));
                    parameter[4] = new SqlParameter("@ProssType", model.salDesc);
                    Helper.ExecProc("HR_PrcProcessSalaryReleased", parameter);

                    return "Process Complete";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }
        #endregion

        #region prcProcessFestBonus

        public String prcProcessFestBonus(SalaryProcess model)
        {
            var comid = HttpContext.Session.GetString("comid");
            ArrayList arQuery = new ArrayList();


            try
            {
                var path = HttpContext.Request.GetEncodedUrl().ToString();
                if (path == null || path.Length == 0)
                {
                    path = "SalaryProcess";
                }

                string sqlQuery1 = "", SelDescription = "";
                Int64 ChkLock = 0;

                List<HR_ProcessLock> hrprocesslock = db.HR_ProcessLock
                    .Where(x => x.ComId == comid && x.LockType == model.FestType
                    && (x.DtDate >= Convert.ToDateTime(model.dtFest)
                    && x.DtDate <= Convert.ToDateTime(model.dtFest)
                    && x.IsLock == true)).ToList();
                //sqlQuery1 = "Select dbo.fncProcessLock (" + HttpContext.Session.GetString("comid") + ", 'Active Salary Lock','" + clsProc.GTRDate(model.dtFirst) + "')";
                ChkLock = hrprocesslock.Count();// clsCon.GTRCountingDataLarge(sqlQuery1);

                if (ChkLock >= 1)
                {
                    return "Process Lock. Please communicate to Administrator";
                }
                else
                {
                    SqlParameter[] parameter = new SqlParameter[8];
                    parameter[0] = new SqlParameter("@ComId", comid);
                    parameter[1] = new SqlParameter("@JoinDate", Helper.GTRDate(model.dtFestEffect));
                    parameter[2] = new SqlParameter("@LastDate", Helper.GTRDate(model.dtFest));
                    parameter[3] = new SqlParameter("@PaymentDate", Helper.GTRDate(model.dtPayment));
                    parameter[4] = new SqlParameter("@ProssType", (model.salDesc));
                    parameter[5] = new SqlParameter("@SalaryType", (model.SalType));
                    parameter[6] = new SqlParameter("@Festivaltype", (model.FestType));
                    parameter[7] = new SqlParameter("@Percen", (model.bonusPer));
                    Helper.ExecProc("HR_prcProcessFestivalBonus", parameter);
                    return "Process Complete";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }

        #endregion
        #region prcProcessFestBonusDelete

        public String prcProcessFestBonusDelete(SalaryProcess model)
        {
            var comid = HttpContext.Session.GetString("comid");
            ArrayList arQuery = new ArrayList();


            try
            {
                var path = HttpContext.Request.GetEncodedUrl().ToString();
                if (path == null || path.Length == 0)
                {
                    path = "SalaryProcess";
                }

                string sqlQuery1 = "", SelDescription = "";
                Int64 ChkLock = 0;

                List<HR_ProcessLock> hrprocesslock = db.HR_ProcessLock.Where(x => x.ComId == comid && x.LockType == model.FestType && (x.DtDate >= Convert.ToDateTime(model.dtFest) && x.DtDate <= Convert.ToDateTime(model.dtFest) && x.IsLock == true)).ToList();
                //sqlQuery1 = "Select dbo.fncProcessLock (" + HttpContext.Session.GetString("comid") + ", 'Active Salary Lock','" + clsProc.GTRDate(model.dtFirst) + "')";
                ChkLock = hrprocesslock.Count();// clsCon.GTRCountingDataLarge(sqlQuery1);

                if (ChkLock >= 1)
                {
                    return "Process Lock. Please communicate to Administrator";
                }
                else
                {
                    SqlParameter[] parameter = new SqlParameter[8];
                    parameter[0] = new SqlParameter("@ComId", comid);
                    parameter[1] = new SqlParameter("@JoinDate", Helper.GTRDate(model.dtFestEffect.ToString()));
                    parameter[2] = new SqlParameter("@LastDate", Helper.GTRDate(model.dtFest.ToString()));
                    parameter[3] = new SqlParameter("@PaymentDate", Helper.GTRDate(model.dtPayment.ToString()));
                    parameter[4] = new SqlParameter("@ProssType", (model.salDesc.ToString()));
                    parameter[5] = new SqlParameter("@SalaryType", (model.SalType.ToString()));
                    parameter[6] = new SqlParameter("@Festivaltype", (model.FestType.ToString()));
                    parameter[7] = new SqlParameter("@Percen", (model.bonusPer.ToString()));
                    Helper.ExecProc("HR_prcProcessFestivalBonusDelete", parameter);
                    return "Process Delete Complete";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }

        #endregion

        #region prcProcessEarnLeave
        public string prcProcessEarnLeave(SalaryProcess model)
        {
            var comid = HttpContext.Session.GetString("comid");
            ArrayList arQuery = new ArrayList();


            try
            {
                var path = HttpContext.Request.GetEncodedUrl().ToString();
                if (path == null || path.Length == 0)
                {
                    path = "SalaryProcess";
                }

                string sqlQuery1 = "", SelDescription = "";
                Int64 ChkLock = 0;

                List<HR_ProcessLock> hrprocesslock = db.HR_ProcessLock.Where(x => x.ComId == comid && x.LockType == "Earn Leave Lock" && (x.DtDate >= Convert.ToDateTime(model.dtELPrcFirst) && x.DtDate <= Convert.ToDateTime(model.dtELPrcLast) && x.IsLock == true)).ToList();
                //sqlQuery1 = "Select dbo.fncProcessLock (" + HttpContext.Session.GetString("comid") + ", 'Active Salary Lock','" + clsProc.GTRDate(model.dtFirst) + "')";
                ChkLock = hrprocesslock.Count();// clsCon.GTRCountingDataLarge(sqlQuery1);

                if (ChkLock >= 1)
                {
                    return "Process Lock. Please communicate to Administrator";
                }
                else
                {
                    SqlParameter[] parameter = new SqlParameter[5];
                    parameter[0] = new SqlParameter("@ComId", comid);
                    parameter[1] = new SqlParameter("@FirstDate", Helper.GTRDate(model.dtELPrcFirst.ToString()));
                    parameter[2] = new SqlParameter("@LastDate", Helper.GTRDate(model.dtELPrcLast.ToString()));
                    parameter[3] = new SqlParameter("@PaymentDate", Helper.GTRDate(model.dtPayment.ToString()));
                    parameter[4] = new SqlParameter("@ProssType", model.salDesc);
                    Helper.ExecProc("HR_prcProcessEarnLeave", parameter);
                    return "Process Complete";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }
        #endregion


        #region prcPFIndividual

        public string prcProcessPFIndividual(SalaryProcess model)
        {
            var comid = HttpContext.Session.GetString("comid");
            ArrayList arQuery = new ArrayList();


            try
            {
                var path = HttpContext.Request.GetEncodedUrl().ToString();
                if (path == null || path.Length == 0)
                {
                    path = "SalaryProcess";
                }

                string sqlQuery1 = "", SelDescription = "";
                Int64 ChkLock = 0;

                List<HR_ProcessLock> hrprocesslock = db.HR_ProcessLock.Where(x => x.ComId == comid && x.LockType == "PF Individual Lock" && (x.DtDate >= Convert.ToDateTime(model.PFIndDtFrom) && x.DtDate <= Convert.ToDateTime(model.PFIndDtTo) && x.IsLock == true)).ToList();
                //sqlQuery1 = "Select dbo.fncProcessLock (" + HttpContext.Session.GetString("comid") + ", 'Active Salary Lock','" + clsProc.GTRDate(model.dtFirst) + "')";
                ChkLock = hrprocesslock.Count();// clsCon.GTRCountingDataLarge(sqlQuery1);

                if (ChkLock >= 1)
                {
                    return "Process Lock. Please communicate to Administrator";
                }
                else
                {
                    SqlParameter[] parameter = new SqlParameter[4];
                    parameter[0] = new SqlParameter("@ComId", comid);
                    parameter[1] = new SqlParameter("@dtFrom", Helper.GTRDate(model.PFIndDtFrom));
                    parameter[2] = new SqlParameter("@dtTo", Helper.GTRDate(model.PFIndDtTo.ToString()));

                    parameter[3] = new SqlParameter("@Percentage", (model.PFIndPercentage));
                    Helper.ExecProc("HR_ProcessPFIndividual", parameter);
                    return "Process Complete";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }
        #endregion

        #region prcProcessFestAdv
        public String prcProcessFestAdv(SalaryProcess model)
        {
            ArrayList arQuery = new ArrayList();
            try
            {
                var path = HttpContext.Request.GetEncodedUrl().ToString();
                if (path == null || path.Length == 0)
                {
                    path = "SalaryProcess";
                }
                string sqlQuery1 = "", SelDescription = "";
                Int64 ChkLock = 0;

                sqlQuery1 = "Select dbo.fncProcessLock (" + HttpContext.Session.GetString("ComId") + ", 'Released Salary Lock','" + clsProc.GTRDate(model.dtFirst) + "')";
                ChkLock = clsCon.GTRCountingDataLarge(sqlQuery1);
                if (ChkLock == 1)
                {
                    return "Process Lock. Please communicate to Administrator";
                }
                else
                {
                    string sqlQuery = "Exec prcProcessFestivalAdv "
                                        + HttpContext.Session.GetString("ComId") + ",'"
                                        + clsProc.GTRDate(model.dtSalAdv) + "', "
                                        + " '"
                                        + clsProc.GTRDate(model.dtPayment) + "','"
                                        + clsProc.GTRSingleQuoteAvoid(model.salDesc) + "','"
                                        + clsProc.GTRSingleQuoteAvoid(model.AdvType) + "',"
                                        + " '"
                                        + clsProc.GTRSingleQuoteAvoid(model.AdvFestType) + "','"
                                        + clsProc.GTRValidateDouble(clsProc.GTRSingleQuoteAvoid(model.bonusAdvPer)) + "' ";
                    arQuery.Add(sqlQuery);

                    // Insert Information To Log File
                    sqlQuery = "Insert Into UserTransactionLogs (LUserId, formName, tranStatement, tranType,PCName)"
                                + " Values (" + HttpContext.Session.GetString("UserId") + ", '"
                                + path + "','" + sqlQuery.Replace("'", "|") + "','FestAdvPross',"
                                + " '" + HttpContext.Session.GetString("PCName") + "')";
                    arQuery.Add(sqlQuery);

                    //Transaction with database
                    clsCon.GTRSaveDataWithSQLCommand(arQuery);
                    return "Process Complete";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }
        #endregion

        #region prcDeleteFestAdv
        public String prcDeleteFestAdv(SalaryProcess model)
        {
            ArrayList arQuery = new ArrayList();
            try
            {
                var path = HttpContext.Request.GetEncodedUrl().ToString();
                if (path == null || path.Length == 0)
                {
                    path = "SalaryProcess";
                }
                string sqlQuery1 = "", SelDescription = "";
                Int64 ChkLock = 0;

                sqlQuery1 = "Select dbo.fncProcessLock (" + HttpContext.Session.GetString("ComId") + ", 'Released Salary Lock','" + clsProc.GTRDate(model.dtFirst) + "')";
                ChkLock = clsCon.GTRCountingDataLarge(sqlQuery1);
                if (ChkLock == 1)
                {
                    return "Process Lock. Please communicate to Administrator";
                }
                else
                {
                    string sqlQuery = " Delete from tblFestAdvSalary where ProssType='" + clsProc.GTRSingleQuoteAvoid(model.salDesc) + "'";

                    arQuery.Add(sqlQuery);
                    // Insert Information To Log File
                    sqlQuery = "Insert Into UserTransactionLogs (LUserId, formName, tranStatement, tranType,PCName)"
                                + " Values (" + HttpContext.Session.GetString("UserId") + ", '"
                                + path + "','" + sqlQuery.Replace("'", "|") + "','FestAdvPross',"
                                + " '"
                                + HttpContext.Session.GetString("PCName") + "')";
                    arQuery.Add(sqlQuery);

                    //Transaction with database
                    clsCon.GTRSaveDataWithSQLCommand(arQuery);
                    return "Process Delete Successfully";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }
        #endregion

        #region prcDeleteFestBonus
        public String prcDeleteFestBonus(SalaryProcess model)
        {
            ArrayList arQuery = new ArrayList();
            try
            {
                var path = HttpContext.Request.GetEncodedUrl().ToString();
                if (path == null || path.Length == 0)
                {
                    path = "SalaryProcess";
                }
                string sqlQuery1 = "", SelDescription = "";
                Int64 ChkLock = 0;

                sqlQuery1 = "Select dbo.fncProcessLock (" + HttpContext.Session.GetString("ComId") + ", 'Released Salary Lock','" + clsProc.GTRDate(model.dtFirst) + "')";
                ChkLock = clsCon.GTRCountingDataLarge(sqlQuery1);
                if (ChkLock == 1)
                {
                    return "Process Lock. Please communicate to Administrator";
                }
                else
                {
                    string sqlQuery = " Delete from tblFestBonusAll where ProssType='" + clsProc.GTRSingleQuoteAvoid(model.salDesc) + "'";


                    arQuery.Add(sqlQuery);

                    // Insert Information To Log File
                    sqlQuery = "Insert Into UserTransactionLogs (LUserId, formName, tranStatement, tranType,PCName)"
                                + " Values (" + HttpContext.Session.GetString("UserId") + ", '"
                                + path + "','" + sqlQuery.Replace("'", "|") + "','FestBonusPross',"
                                + " '"
                                + HttpContext.Session.GetString("PCName") + "')";
                    arQuery.Add(sqlQuery);

                    //Transaction with database
                    clsCon.GTRSaveDataWithSQLCommand(arQuery);
                    return "Process Delete Successfully";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }


            #endregion
        }

    }
    #endregion
}