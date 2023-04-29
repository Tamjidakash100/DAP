using GTERP.BLL;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
//using FreeGeoIPCore.AppCode;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace GTERP.Controllers.HR
{
    [OverridableAuthorize]
    public class DashboardController : Controller
    {
        private TransactionLogRepository tranlog;
        //public clsConnectionNew clsCon { get; set; }
        public IHttpContextAccessor _httpContext { get; }
        public Dashboard _Dashboard { get; }
        public DailyAttendanceSum DailyAttendanceSum1 { get; }

        public DashboardController(clsConnectionNew _clsCon, IHttpContextAccessor httpContext, Dashboard _dashboard, DailyAttendanceSum dailyAttendanceSum, TransactionLogRepository tran)
        {
            tranlog = tran;
            //clsCon = _clsCon;
            _httpContext = httpContext;
            _Dashboard = _dashboard;
            DailyAttendanceSum1 = dailyAttendanceSum;
        }
        public ActionResult Index(string dtLoad)
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            var comid = HttpContext.Session.GetString("comid");

            //if (dtLoad == "")
            if (dtLoad == null)
            {
                var dashboard = InitializeDashBord();
                //HttpContext.Session.SetString("DashboardDate", DateTime.Now.Date.ToString());
                ViewBag.ListOfAtt = PrcGetDailyAttendanceSum(comid, DateTime.Now.ToString(), DateTime.Now.ToString());
                ViewBag.DtLoad = DateTime.Now.ToString("dd-MMM-yyyy");
                return View(dashboard);
            }
            else
            {
                //HttpContext.Session.SetString("DashboardDate", dtLoad);
                var dashboard = dtLoad;
                ViewBag.DtLoad = dtLoad;
                ViewBag.ListOfAtt = PrcGetDailyAttendanceSum(comid, DateTime.Now.ToString(), DateTime.Now.ToString());
                return View(dashboard);
            }
        }

        [HttpGet]
        public ActionResult LoadData(string dtLoad)
        {
            var comid = HttpContext.Session.GetString("comid");

            if (dtLoad == "")
            {
                var dashboard = InitializeDashBord();
                //HttpContext.Session.SetString("DashboardDate", DateTime.Now.Date.ToString());
                ViewBag.ListOfAtt = PrcGetDailyAttendanceSum(comid, DateTime.Now.ToString(), DateTime.Now.ToString());
                ViewBag.DtLoad = DateTime.Now.ToString("dd-MMM-yyyy");
                return View(dashboard);
            }
            else
            {
                //HttpContext.Session.SetString("DashboardDate", dtLoad);
                var dashboard = InitializeDashBord(dtLoad);
                ViewBag.DtLoad = dtLoad;
                ViewBag.ListOfAtt = PrcGetDailyAttendanceSum(comid, DateTime.Now.ToString(), DateTime.Now.ToString());
                return View("Index", dashboard);
            }
        }

        public ActionResult GetDailyAttSum()
        {
            var comid = HttpContext.Session.GetString("comid");
            List<DailyAttendanceSum> dailyAttendanceSum = PrcGetDailyAttendanceSum(comid, DateTime.Now.ToString(), DateTime.Now.ToString());
            return Json(dailyAttendanceSum);
        }




        public Dashboard InitializeDashBord(string date = null)
        {
            var comid = HttpContext.Session.GetString("comid");
            var dashBord = new Dashboard();

            if (date != null)
            {
                dashBord.DailyAttendance = PrcGetDailyAttendance(date);
            }
            else
            {
                dashBord.DailyAttendance = PrcGetDailyAttendance();
            }

            dashBord.DailyAttendanceSum = PrcGetDailyAttendanceSum(comid, DateTime.Now.ToString(), DateTime.Now.ToString());
            dashBord.MonthlyAttendance = PrcGetMonthlyAttendance(comid);
            dashBord.EmployeeDetails = PrcGetEmployeeDetails(comid);
            dashBord.SalaryDetails = PrcGetSalaryDetails(comid);

            return dashBord;
        }


        public MonthlyAttendance PrcGetMonthlyAttendance(string comid)
        {

            SqlParameter[] sqlParemeter = new SqlParameter[1];
            sqlParemeter[0] = new SqlParameter("@ComID", comid);

            MonthlyAttendance aMonthlyAttendance = Helper.ExecProcMapT<MonthlyAttendance>("HR_prcGetEmployeeDetails", sqlParemeter);




            return aMonthlyAttendance;
        }



        public EmployeeDetails PrcGetEmployeeDetails(string comid)
        {
            SqlParameter[] sqlParemeter = new SqlParameter[1];
            sqlParemeter[0] = new SqlParameter("@ComID", comid);

            EmployeeDetails aEmployeeDetails = Helper.ExecProcMapT<EmployeeDetails>("HR_prcGetEmployeeDetails", sqlParemeter);


            return aEmployeeDetails;
        }


        public SalaryDetails PrcGetSalaryDetails(string comid)
        {

            SqlParameter[] sqlParemeter = new SqlParameter[1];
            sqlParemeter[0] = new SqlParameter("@ComID", comid);

            SalaryDetails aSalaryDetails = Helper.ExecProcMapT<SalaryDetails>("PrcGetSalaryDetails", sqlParemeter);


            return aSalaryDetails;
        }

        public List<DailyAttendanceSum> PrcGetDailyAttendanceSum(string comid, string fromdate, string toDate)
        {
            try
            {


                var date = DateTime.Now;


                SqlParameter[] sqlParameter1 = new SqlParameter[7];
                sqlParameter1[0] = new SqlParameter("@ComId", comid);
                sqlParameter1[1] = new SqlParameter("@dtDate", fromdate);
                sqlParameter1[2] = new SqlParameter("@dtTO", toDate);
                sqlParameter1[3] = new SqlParameter("@ShiftId", 0);
                sqlParameter1[4] = new SqlParameter("@EmpType", "=ALL=");
                sqlParameter1[5] = new SqlParameter("@Flag", "Department");
                sqlParameter1[6] = new SqlParameter("@LineId", "0");
                List<DailyAttendanceSum> listofDailyAttendance = Helper.ExecProcMapTList<DailyAttendanceSum>("HR_RptAttendSum", sqlParameter1);


                return listofDailyAttendance;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public DailyAttendance PrcGetDailyAttendance(string date = null)
        {
            var comid = HttpContext.Session.GetString("comid");

            try
            {
                if (comid != null && date == null)
                {


                    //var coId = _httpContext.Session.GetString("comid");
                    SqlParameter[] sqlParemeter = new SqlParameter[1];
                    sqlParemeter[0] = new SqlParameter("@ComID", comid);

                    DailyAttendance aDailyAttendance = Helper.ExecProcMapT<DailyAttendance>("HR_prcGetDailyAttendance", sqlParemeter);





                    return aDailyAttendance;
                }
                if (comid != null && date != null)
                {

                    SqlParameter[] sqlParemeter = new SqlParameter[3];
                    sqlParemeter[0] = new SqlParameter("@ComID", comid);
                    sqlParemeter[1] = new SqlParameter("@Id", 1);
                    sqlParemeter[2] = new SqlParameter("@dtProcessDate", date);

                    DailyAttendance aDailyAttendance = Helper.ExecProcMapT<DailyAttendance>("HR_prcGetDailyAttendance", sqlParemeter);


                    return aDailyAttendance;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public class DailyAttendance
        {
            public string TotalEmployee { get; set; }
            public string Present { get; set; }
            public string Absent { get; set; }
            public string Late { get; set; }
            public string Leave { get; set; }
            public DateTime LastProcessDate { get; set; }
            public string PresentPercent { get; set; }
            public string AbsentPercent { get; set; }
            public string LeavePercent { get; set; }
            public string LatePercent { get; set; }


        }

        public class DailyAttendanceSum
        {
            [Display(Name = "Company Id")]
            //[Index("IX_ComAccnameUniqe", 1, IsUnique = true)]
            [StringLength(128)]
            public string ComId { get; set; }
            public string SectName { get; set; }
            public string Male { get; set; }
            public string Female { get; set; }
            public string TotalEmployee { get; set; }
            public string Present { get; set; }
            public string Absent { get; set; }
            public string Late { get; set; }
            public string Leave { get; set; }
            public string PresentPercent { get; set; }
            public string AbsentPercent { get; set; }
            public string LeavePercent { get; set; }
            public string LatePercent { get; set; }
            public string SalaryPerDay { get; set; }
            public string OTHour { get; set; }


        }

        public class SalaryDetails
        {
            public string AvgSalary { get; set; }
            public string PerDaySalary { get; set; }
            public string NetPayableSalary { get; set; }
            public string TotalOtCost { get; set; }
            public string TotalAdvance { get; set; }
            public string LastProssType { get; set; }
            public string ProssType { get; set; }
            public DateTime LastProcessDate { get; set; }


        }
        public class EmployeeDetails
        {
            public string ActiveEmployee { get; set; }
            public string ReleasedEmployee { get; set; }
            public string OtYesEmployee { get; set; }
            public string MaleEmployee { get; set; }
            public string FemaleEmployee { get; set; }
            public string TotalEmployee { get; set; }
            public DateTime LastProcessDate { get; set; }
            public DateTime FirstDayOfMonth { get; set; }


        }
        public class MonthlyAttendance
        {
            public string MonthlyTotalOtHour { get; set; }
            public string MonthlyExtraOtHour { get; set; }
            public string MonthlyReghour { get; set; }
            public string MonthlyPresent { get; set; }
            public string MonthlyAbsent { get; set; }
            public string MonthlyLate { get; set; }
            public string MonthlyCl { get; set; }
            public string MonthlySl { get; set; }
            public string Prosstype { get; set; }
            public DateTime LastProcessDate { get; set; }
            public DateTime FirstDayOfMonth { get; set; }




        }
        public class Dashboard
        {
            public DailyAttendance DailyAttendance { get; set; }
            public MonthlyAttendance MonthlyAttendance { get; set; }
            public EmployeeDetails EmployeeDetails { get; set; }
            public SalaryDetails SalaryDetails { get; set; }
            public List<DailyAttendanceSum> DailyAttendanceSum { get; set; }



        }

    }

}