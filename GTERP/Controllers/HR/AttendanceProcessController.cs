using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Data;
using System.Linq;

namespace GTERP.Controllers.HR
{
    [OverridableAuthorize]
    public class AttendanceProcessController : Controller
    {
        DataSet dsList;
        DataSet dsDetails;
        private TransactionLogRepository tranlog;
        private GTRDBContext db;
        public AttendanceProcessController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        public IActionResult Index(string msg)
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            string comid = HttpContext.Session.GetString("comid");
            HR_AttendanceProcess model = new HR_AttendanceProcess();
            //dsList = new DataSet();

            //SqlParameter[] sqlParameter = new SqlParameter[1];

            //sqlParameter[0] = new SqlParameter("@p0", HttpContext.Session.GetString("comid"));
            //dsList = Helper.ExecProcMapDS("HR_prcGetDailyAttProcess", sqlParameter);

            //if (msg == "Create")
            //{
            //    if (dsList.Tables[0].Rows.Count > 0)
            //    {
            //        model.dtLast = DateTime.Parse(dsList.Tables[0].Rows[0]["prossDt"].ToString());
            //    }
            //    if (dsList.Tables[4].Rows.Count > 0)
            //    {
            //        model.dtProcess = DateTime.Parse(dsList.Tables[5].Rows[0]["CurrDate"].ToString());
            //        model.dtTo = DateTime.Parse(dsList.Tables[5].Rows[0]["LastDate"].ToString());
            //    }
            //}

            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            model.dtLast = db.HR_ProssType.OrderByDescending(p => p.ProssDt).FirstOrDefault().ProssDt;
            model.dtProcess = now;
            model.dtTo = endDate;

            if (msg == null)
            {

            }
            else
            {
                ModelState.AddModelError("CustomError", "Process complete");
                ViewBag.loadMsg = msg;
            }


            //combo
            //List<clsCommon.clsCombo2> Sec = clsGenerateList.prcColumnTwo(dsList.Tables[1]);
            ViewBag.Section = new SelectList(db.Cat_Section.Where(s => s.ComId == comid), "SectId", "SectName");
            //List<clsCommon.clsCombo2> Emp = clsGenerateList.prcColumnTwo(dsList.Tables[2]);
            //var empInfo = db.HR_Emp_Info.Select(e => new
            //{
            //    EmpId = e.EmpId,
            //    EmpCode = e.EmpCode,
            //    EmpName = e.EmpName,
            //    ComId = e.ComId
            //}).Where(a => a.ComId == comid).ToList();

            //var empInfo =db.HR_Emp_Info;
            ViewBag.Employee = new SelectList(db.HR_Emp_Info, "EmpId", "EmpCode");
            ViewBag.EmpData = db.HR_Emp_Info.ToList();
            return View(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Index(HR_AttendanceProcess model/*, string optSts, string optCriteria*/)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                string optSts = model.dayType;
                string optCriteria = model.optCriteria;

                var comid = HttpContext.Session.GetString("comid");
                var userid = HttpContext.Session.GetString("userid");
                //var values = prcProcessData(model, optSts, optCriteria,comid,userid);
                string values = "";

                string pcName = "Himu Test Pc";
                // ArrayList arQuery = new ArrayList();

                string sqlQuery = "";
                dsDetails = new DataSet();
                Int64 ChkLock = 0;

                sqlQuery = "Select dbo.HR_fncProcessLock ('" + comid + "', 'Attendance Lock','" + Helper.GTRDate(model.dtProcess.ToString()) + "')";
                ChkLock = Helper.GTRCountingDataLarge(sqlQuery);


                if (ChkLock == 1)
                {
                    TempData["Message"] = "Process Locked. Please communicate with Administrator";
                    return Json(new { Success = 2, ex = TempData["Message"].ToString() });
                }
                try
                {
                    // transaction path for transaction log 
                    //var path = Request.Url.AbsolutePath.ToString();
                    var path = "";
                    if (path == null || path.Length == 0)
                    {
                        path = "AttendanceProcess";
                    }

                    DateTime dt1 = model.dtProcess;
                    DateTime dt2 = model.dtLast;

                    TimeSpan ts = dt1 - dt2;
                    int days = ts.Days;
                    if (days > 1)
                    {
                        TempData["Message"] = "Please Run The Process For " + Helper.GTRDate(model.dtLast.AddDays(1).ToString());
                        return Json(new { Success = 1, ex = TempData["Message"].ToString() });
                    }

                    if (model.Monthly == true)
                    {
                        int X = 0, Y = 0;
                        var m = model.dtLast;
                        X = DateTime.Parse(model.dtProcess.ToString()).Day;
                        Y = DateTime.Parse(model.dtTo.ToString()).Day;

                        while (X <= Y)
                        {
                            dsDetails = new DataSet();
                            {
                                if (optSts == "H" || optSts == "R" || optSts == "W" || optSts == "S")
                                {
                                    //sqlQuery = "delete tblProssType where ComId = " + comid + " and ProssDt =  '" + Helper.GTRDate(model.dtProcess.ToString()) + "' ";
                                    //arQuery.Add(sqlQuery);
                                    var prossType = db.HR_ProssType.Where(p => p.ComId == comid && p.ProssDt == Convert.ToDateTime(Helper.GTRDate(model.dtProcess.ToString()))).FirstOrDefault();
                                    if (prossType != null)
                                    {
                                        db.Remove(prossType);
                                    }


                                    // Insert Information To Log File
                                    // need change 
                                    //sqlQuery =
                                    //    "Insert Into tblUser_Trans_Log (LUserId, formName, tranStatement, tranType,PCName)" +
                                    //    "Values (" + userid + ", '" + path + "', '" +
                                    //    sqlQuery.Replace("'", "|") + "', 'delete','" + pcName + "')";

                                    //arQuery.Add(sqlQuery);

                                    //sqlQuery = "insert into tblProssType(ComId, ProssDt, DaySts, DayStsB, IsLock) values(" + comid + ", '" + Helper.GTRDate(model.dtProcess.ToString()) + "', '" + optSts + "', '" + optSts + "', 0)";
                                    //arQuery.Add(sqlQuery);

                                    HR_ProssType nPross = new HR_ProssType();
                                    nPross.ComId = comid;
                                    nPross.ProssDt = Convert.ToDateTime(Helper.GTRDate(model.dtProcess.ToString()));
                                    nPross.DaySts = optSts;
                                    nPross.DayStsB = optSts;
                                    nPross.IsLock = "0";
                                    db.Add(nPross);
                                    db.SaveChanges();
                                    // Insert Information To Log File
                                    // need change
                                    //sqlQuery =
                                    //    "Insert Into tblUser_Trans_Log (LUserId, formName, tranStatement, tranType,PCName)" +
                                    //    "Values (" + userid + ", '" + path + "', '" +
                                    //    sqlQuery.Replace("'", "|") + "', 'Create','" + pcName + "')";
                                    //arQuery.Add(sqlQuery);
                                }
                                prcInsertEmp(model, model.optCriteria);

                                //sqlQuery = "Exec HR_PrcProcessAttend " + comid + ",'" + Helper.GTRDate(model.dtProcess.ToString()) + "'";
                                //arQuery.Add(sqlQuery);

                                SqlParameter[] parameter = new SqlParameter[2];
                                parameter[0] = new SqlParameter("@ComID", comid);
                                parameter[1] = new SqlParameter("@Date", Helper.GTRDate(model.dtProcess.ToString()));

                                Helper.ExecProc("HR_PrcProcessAttend", parameter);
                                // Insert Information To Log File
                                //sqlQuery =
                                //    "Insert Into tblUser_Trans_Log (LUserId, formName, tranStatement, tranType,PCName)" +
                                //    "Values (" + userid + ", '" + path + "', '" + sqlQuery.Replace("'", "|") +
                                //    "', 'Create','" + pcName + "')";
                                //arQuery.Add(sqlQuery);
                            }
                            model.dtProcess = DateTime.Parse(model.dtProcess.ToString()).AddDays(1);
                            X++;
                            //return "Processing " + clsProc.GTRDate(model.dtProcess.ToString())+ " .....";
                        }
                    }
                    else
                    {
                        if (optSts == "H" || optSts == "R" || optSts == "W" || optSts == "S")
                        {
                            //sqlQuery = "delete tblProssType where ComId = " + comid + " and ProssDt =  '" + Helper.GTRDate(model.dtProcess.ToString()) + "' ";
                            //arQuery.Add(sqlQuery);

                            var prossType = db.HR_ProssType.Where(p => p.ComId == comid && p.ProssDt == Convert.ToDateTime(Helper.GTRDate(model.dtProcess.ToString()))).FirstOrDefault();
                            if (prossType != null)
                            {
                                db.Remove(prossType);
                            }


                            // Insert Information To Log File
                            //sqlQuery = "Insert Into tblUser_Trans_Log (LUserId, formName, tranStatement, tranType,PCName)" +
                            //           "Values (" + userid + ", '" + path + "', '" + sqlQuery.Replace("'", "|") +
                            //           "', 'Delete','" + pcName + "')";
                            //arQuery.Add(sqlQuery);

                            //sqlQuery = "insert into tblProssType(ComId, ProssDt, DaySts, DayStsB, IsLock) values(" + comid + ", '" + Helper.GTRDate(model.dtProcess.ToString()) + "', '" + optSts + "', '" + optSts + "', 0)";
                            //arQuery.Add(sqlQuery);

                            HR_ProssType nPross = new HR_ProssType();
                            nPross.ComId = comid;
                            nPross.ProssDt = Convert.ToDateTime(Helper.GTRDate(model.dtProcess.ToString()));
                            nPross.DaySts = optSts;
                            nPross.DayStsB = optSts;
                            nPross.IsLock = "0";
                            db.Add(nPross);
                            db.SaveChanges();
                            // Insert Information To Log File
                            //sqlQuery = "Insert Into tblUser_Trans_Log (LUserId, formName, tranStatement, tranType,PCName)" +
                            //           "Values (" + userid + ", '" + path + "', '" + sqlQuery.Replace("'", "|") +
                            //           "', 'Create','" +pcName + "')";
                            //arQuery.Add(sqlQuery);
                        }
                        //sqlQuery = "Exec HR_PrcProcessAttend " + comid + ",'" + Helper.GTRDate(model.dtProcess.ToString()) + "'";
                        //arQuery.Add(sqlQuery);
                        //string date = Helper.GTRDate(model.dtProcess.ToString());
                        SqlParameter[] parameter = new SqlParameter[2];
                        parameter[0] = new SqlParameter("@ComID", comid);
                        parameter[1] = new SqlParameter("@Date", Helper.GTRDate(model.dtProcess.ToString()));

                        Helper.ExecProc("HR_PrcProcessAttend", parameter);

                        // Insert Information To Log File
                        //sqlQuery = "Insert Into tblUser_Trans_Log (LUserId, formName, tranStatement, tranType,PCName)" +
                        //           "Values (" + userid + ", '" + path + "', '" + sqlQuery.Replace("'", "|") +
                        //           "', 'Create','" + pcName+ "')";
                        //arQuery.Add(sqlQuery);
                    }
                    //Transaction with database
                    //Helper.GTRSaveDataWithSQLCommand(arQuery);
                    values = "Process complete";
                }
                catch (Exception ex)
                {
                    return Json(ex.Message.ToString());
                }



                if (values == "Process complete")
                {
                    ModelState.AddModelError("CustomError", values);
                    //prcLoadCombo();
                    ViewBag.loadMsg = "save";
                    //return RedirectToAction("Index", "AttendanceProcess", new { msg = "save" });
                    TempData["Message"] = values;
                    return Json(new { Success = 1, ex = TempData["Message"].ToString() });

                    //return View(model);
                }
                else
                {
                    ModelState.AddModelError("CustomError", values);
                    //prcLoadCombo();
                    //ViewBag.msgErr = "error";
                    //return View(model);
                    TempData["Message"] = "Process not complete";
                    return Json(new { Success = 1, ex = TempData["Message"].ToString() });


                }
                //}
                //else
                //{
                //    //prcLoadCombo();
                //    ModelState.AddModelError("CustomError", "There is something wrong, please check");
                //    //ViewBag.msgErr = "error";
                //    //return View(model);
                //    return Json("error");
                //}
            }
            catch (Exception ex)
            {
                //prcLoadCombo();
                ModelState.AddModelError("CustomError", ex.Message);
                ViewBag.msgErr = "error";
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });

            }

        }


        public String prcProcessData(HR_AttendanceProcess model, string optSts, string optCriteria, string comId, string userId)
        {
            string comid = comId;
            string userid = userId;

            string pcName = "Himu Test Pc";
            ArrayList arQuery = new ArrayList();
            //clsProcedure clsProc = new clsProcedure();
            //clsConnectionNew clsCon = new clsConnectionNew("GTRHRIS_WEBDEMO", true);
            string sqlQuery = "";
            dsDetails = new DataSet();
            Int64 ChkLock = 0;

            sqlQuery = "Select dbo.HR_fncProcessLock ('" + comid + "', 'Attendance Lock','" + Helper.GTRDate(model.dtProcess.ToString()) + "')";
            ChkLock = Helper.GTRCountingDataLarge(sqlQuery);


            if (ChkLock == 1)
            {
                return "Process Locked. Please communicate with Administrator";
            }
            try
            {
                // transaction path for transaction log 
                //var path = Request.Url.AbsolutePath.ToString();
                var path = "";
                if (path == null || path.Length == 0)
                {
                    path = "AttendanceProcess";
                }

                DateTime dt1 = model.dtProcess;
                DateTime dt2 = model.dtLast;

                TimeSpan ts = dt1 - dt2;
                int days = ts.Days;
                if (days > 1)
                {
                    return "Please Run The Process For " + Helper.GTRDate(model.dtLast.AddDays(1).ToString());
                }

                if (model.Monthly == true)
                {
                    int X = 0, Y = 0;
                    var m = model.dtLast;
                    X = DateTime.Parse(model.dtProcess.ToString()).Day;
                    Y = DateTime.Parse(model.dtTo.ToString()).Day;

                    while (X <= Y)
                    {
                        //dsDetails = new DataSet();
                        {
                            if (optSts == "H" || optSts == "R" || optSts == "W" || optSts == "S")
                            {
                                sqlQuery = "delete tblProssType where ComId = " + comid + " and ProssDt =  '" + Helper.GTRDate(model.dtProcess.ToString()) + "' ";
                                arQuery.Add(sqlQuery);

                                // Insert Information To Log File
                                // need change 
                                //sqlQuery =
                                //    "Insert Into tblUser_Trans_Log (LUserId, formName, tranStatement, tranType,PCName)" +
                                //    "Values (" + userid + ", '" + path + "', '" +
                                //    sqlQuery.Replace("'", "|") + "', 'delete','" + pcName + "')";

                                //arQuery.Add(sqlQuery);

                                sqlQuery = "insert into tblProssType(ComId, ProssDt, DaySts, DayStsB, IsLock) values(" + comid + ", '" + Helper.GTRDate(model.dtProcess.ToString()) + "', '" + optSts + "', '" + optSts + "', 0)";
                                arQuery.Add(sqlQuery);

                                // Insert Information To Log File
                                // need change
                                //sqlQuery =
                                //    "Insert Into tblUser_Trans_Log (LUserId, formName, tranStatement, tranType,PCName)" +
                                //    "Values (" + userid + ", '" + path + "', '" +
                                //    sqlQuery.Replace("'", "|") + "', 'Create','" + pcName + "')";
                                //arQuery.Add(sqlQuery);
                            }
                            prcInsertEmp(model, optCriteria);

                            sqlQuery = "Exec HR_PrcProcessAttend " + comid + ",'" + Helper.GTRDate(model.dtProcess.ToString()) + "'";
                            arQuery.Add(sqlQuery);

                            // Insert Information To Log File
                            //sqlQuery =
                            //    "Insert Into tblUser_Trans_Log (LUserId, formName, tranStatement, tranType,PCName)" +
                            //    "Values (" + userid + ", '" + path + "', '" + sqlQuery.Replace("'", "|") +
                            //    "', 'Create','" + pcName + "')";
                            //arQuery.Add(sqlQuery);
                        }
                        model.dtProcess = DateTime.Parse(model.dtProcess.ToString()).AddDays(1);
                        X++;
                        //return "Processing " + clsProc.GTRDate(model.dtProcess.ToString())+ " .....";
                    }
                }
                else
                {
                    if (optSts == "H" || optSts == "R" || optSts == "W" || optSts == "S")
                    {
                        sqlQuery = "delete tblProssType where ComId = " + comid + " and ProssDt =  '" + Helper.GTRDate(model.dtProcess.ToString()) + "' ";
                        arQuery.Add(sqlQuery);



                        // Insert Information To Log File
                        //sqlQuery = "Insert Into tblUser_Trans_Log (LUserId, formName, tranStatement, tranType,PCName)" +
                        //           "Values (" + userid + ", '" + path + "', '" + sqlQuery.Replace("'", "|") +
                        //           "', 'Delete','" + pcName + "')";
                        //arQuery.Add(sqlQuery);

                        sqlQuery = "insert into tblProssType(ComId, ProssDt, DaySts, DayStsB, IsLock) values(" + comid + ", '" + Helper.GTRDate(model.dtProcess.ToString()) + "', '" + optSts + "', '" + optSts + "', 0)";
                        arQuery.Add(sqlQuery);

                        // Insert Information To Log File
                        //sqlQuery = "Insert Into tblUser_Trans_Log (LUserId, formName, tranStatement, tranType,PCName)" +
                        //           "Values (" + userid + ", '" + path + "', '" + sqlQuery.Replace("'", "|") +
                        //           "', 'Create','" +pcName + "')";
                        //arQuery.Add(sqlQuery);
                    }
                    sqlQuery = "Exec HR_PrcProcessAttend " + comid + ",'" + Helper.GTRDate(model.dtProcess.ToString()) + "'";
                    arQuery.Add(sqlQuery);

                    // Insert Information To Log File
                    //sqlQuery = "Insert Into tblUser_Trans_Log (LUserId, formName, tranStatement, tranType,PCName)" +
                    //           "Values (" + userid + ", '" + path + "', '" + sqlQuery.Replace("'", "|") +
                    //           "', 'Create','" + pcName+ "')";
                    //arQuery.Add(sqlQuery);
                }
                //Transaction with database
                Helper.GTRSaveDataWithSQLCommand(arQuery);
                return "Process complete";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }

        private void prcInsertEmp(HR_AttendanceProcess model, string optCriteria)
        {
            ArrayList arQuery = new ArrayList();
            //clsProcedure clsProc = new clsProcedure();
            //clsConnectionNew clsCon = new clsConnectionNew("GTRHRIS_WEBDEMO", true);
            string SQLQuery = "", SectId = "", DesigId = "", EmpId = "", ShiftId = "", SubSectId = "", Band = "";
            string comid = HttpContext.Session.GetString("comid");
            string userid = HttpContext.Session.GetString("userid");

            var processDate = Helper.GTRDate(model.dtProcess.ToString());
            SqlParameter[] parameter = new SqlParameter[4];
            //Collecting Parameter Value
            if (optCriteria.ToString().ToUpper() == "All".ToUpper())
            {

                //SQLQuery = "Delete tblTempCount;Insert Into tblTempCount (EmpID, DateTime1) Select EmpId,'" + Helper.GTRDate(model.dtProcess.ToString())
                //           + "' from tblEmp_Info Where ComId = " + comid + " ";
                //arQuery.Add(SQLQuery);
                parameter[0] = new SqlParameter("@ComId", comid);
                parameter[1] = new SqlParameter("@dtPross", processDate);
                parameter[2] = new SqlParameter("@optCriteria", "All");
                parameter[3] = new SqlParameter("@id", "0");// no needed for all
            }
            else if (optCriteria.ToUpper() == "Sec".ToUpper())
            {
                SectId = model.SectId.ToString();
                //SQLQuery = "Delete tblTempCount;Insert Into tblTempCount (EmpID, DateTime1) Select EmpID,'" + Helper.GTRDate(model.dtProcess.ToString())
                //           + "' from tblEmp_Info Where ComId = " + comid + " and SectId = '" + SectId + "' ";
                //arQuery.Add(SQLQuery);
                parameter[0] = new SqlParameter("@ComId", comid);
                parameter[1] = new SqlParameter("@dtPross", processDate);
                parameter[2] = new SqlParameter("@optCriteria", "Sec");
                parameter[3] = new SqlParameter("@id", SectId);
            }

            else if (optCriteria.ToUpper() == "Desig".ToUpper())
            {
                DesigId = model.DesigId.ToString();
                //SQLQuery = "Delete tblTempCount;Insert Into tblTempCount (EmpID, DateTime1) Select EmpId,'" + Helper.GTRDate(model.dtProcess.ToString())
                //           + "' from tblEmp_Info Where ComID = " + comid + " and DesigId = '" + DesigId + "'";
                //arQuery.Add(SQLQuery);               
                parameter[0] = new SqlParameter("@ComId", comid);
                parameter[1] = new SqlParameter("@dtPross", processDate);
                parameter[2] = new SqlParameter("@optCriteria", "EmpId");
                parameter[3] = new SqlParameter("@id", DesigId);
            }

            else if (optCriteria.ToUpper() == "EmpId".ToUpper())
            {
                EmpId = model.EmpId.ToString();
                //SQLQuery = "Delete tblTempCount;Insert Into tblTempCount (EmpID, DateTime1) Select EmpId,'" + Helper.GTRDate(model.dtProcess.ToString())
                //           + "' from tblEmp_Info Where ComID = " + comid + " and EmpId = '" + EmpId + "'";
                //arQuery.Add(SQLQuery);
                parameter[0] = new SqlParameter("@ComId", comid);
                parameter[1] = new SqlParameter("@dtPross", processDate);
                parameter[2] = new SqlParameter("@optCriteria", "EmpId");
                parameter[3] = new SqlParameter("@id", EmpId);
            }

            Helper.ExecProc("HR_prcSetAttData", parameter);
        }
    }
}