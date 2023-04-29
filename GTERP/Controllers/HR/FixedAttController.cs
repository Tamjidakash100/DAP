using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;

namespace GTERP.Controllers.HR
{
    [OverridableAuthorize]

    public class FixedAttController : Controller
    {
        private readonly GTRDBContext db;


        public FixedAttController(GTRDBContext context)
        {
            db = context;

        }

        public class AttFixGrid
        {
            public bool IsChecked { get; set; }
            public int EmpId { get; set; }
            public string EmpCode { get; set; }
            public string EmpName { get; set; }
            public string SectName { get; set; }
            public string DeptName { get; set; }
            public string DesigName { get; set; }
            public int ShiftId { get; set; }
            public string ShiftName { get; set; }

            [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
            public DateTime dtPunchDate { get; set; } = DateTime.Now.Date;

            [DisplayFormat(DataFormatString = "{0:HH-MM}", ApplyFormatInEditMode = true)]
            public string TimeIn { get; set; } = DateTime.Now.ToShortTimeString();
            [DisplayFormat(DataFormatString = "{0:HH-MM}", ApplyFormatInEditMode = true)]
            public string TimeOut { get; set; } = DateTime.Now.ToShortTimeString();

            [DisplayFormat(DataFormatString = "{0:HH-MM}", ApplyFormatInEditMode = true)]
            public string OTHourInTime { get; set; } = DateTime.Now.ToShortTimeString();

            public string Status { get; set; }
            public int StatusId { get; set; }

            public string Remarks { get; set; }
            //[DisplayFormat(DataFormatString = "{0:HH-MM}", ApplyFormatInEditMode = true)]
            public string OtHour { get; set; }
            public float OT { get; set; }
            public string Line { get; set; }
            public string EmpType { get; set; }

            public bool IsInactive { get; set; }
            public int SectId { get; set; }
            public string Criteria { get; set; }

            [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]

            public DateTime DtFrom { get; set; }
            [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]

            public DateTime DtTo { get; set; }



        }

        public ActionResult Index()
        {
            var comid = HttpContext.Session.GetString("comid");

            ViewBag.EmpId = new SelectList(db.HR_Emp_Info.Where(x => x.ComId == comid).ToList(), "EmpId", "EmpName");
            ViewBag.Designation = new SelectList(db.Cat_Designation.Where(x => x.ComId == comid).ToList(), "DesigId", "DesigName");
            ViewBag.Departments = new SelectList(db.Cat_Department.Where(x => x.ComId == comid).ToList(), "DeptId", "DeptName");
            ViewBag.Sections = new SelectList(db.Cat_Section.Where(x => x.ComId == comid).ToList(), "SectId", "SectName");
            ViewBag.Lines = new SelectList(db.Cat_Line.Where(x => x.ComId == comid).ToList(), "LineId", "LineName");
            ViewBag.StatusId = new SelectList(db.Cat_AttStatus.ToList(), "StatusId", "AttStatus").ToList();
            ViewBag.EmpTypeId = new SelectList(db.Cat_Emp_Type.ToList(), "EmpTypeId", "EmpTypeName").ToList();


            return View("MyView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public IActionResult Index(AttFixGrid fixAttendance)
        public IActionResult Index(string DtFrom, string DtTo, string criteria, string value)
        {
            // DtFrom: dtfrom, DtTo: dtto, criteria: criteria , value: value
            try
            {
                var comid = HttpContext.Session.GetString("comid");

                var quary = $"EXEC HR_PrcGetFixAtt '1','{comid}','{criteria}','{value}','{DtFrom}','{DtTo}'";

                SqlParameter[] sqlParameter = new SqlParameter[6];
                sqlParameter[0] = new SqlParameter("@Id", "1");
                sqlParameter[1] = new SqlParameter("@ComId", comid);
                sqlParameter[2] = new SqlParameter("@OptCriteria", criteria);
                sqlParameter[3] = new SqlParameter("@Value", value);
                sqlParameter[4] = new SqlParameter("@dtfrom", DtFrom);
                sqlParameter[5] = new SqlParameter("@dtTo", DtTo);

                var listOfAttFixed = Helper.ExecProcMapTList<AttFixGrid>("HR_PrcGetFixAtt", sqlParameter);


                TempData["Message"] = "Data Load Successfully";
                //return Json(gridData);
                return Json(new { Success = 1, Result = listOfAttFixed, message = TempData["Message"].ToString() });
                //return gridData;
            }
            catch (Exception ex)
            {

                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
                //return null;
            }
            //return Json(gridData);
            //return PartialView("_FixAttendancGrid", gridData);
        }


        //public List<AttFixGrid> PopulateGrid(AttFixGrid fixAttendance)
        //{
        //    string optCritaria = fixAttendance.Criteria;
        //    string valueLine = "0";
        //    string valueSec = "0";
        //    string valueStatus = "=ALL=";
        //    string valueShift = "0";
        //    string value = "";
        //    switch (optCritaria)
        //    {
        //        case "EmpID":
        //            value = fixAttendance.EmpId.ToString();
        //            break;
        //        case "Sec":
        //            value = fixAttendance.SectId.ToString();
        //            break;
        //        case "ShiftTime":
        //            value = fixAttendance.ShiftId.ToString();
        //            break;
        //        case "Status":
        //            value = fixAttendance.Status;
        //            break;
        //        case "Line":
        //            value = fixAttendance.Line;
        //            break;
        //    }
        //    if (fixAttendance.Line != null)
        //    {
        //        valueLine = fixAttendance.Line;
        //    }
        //    if (fixAttendance.Status != null)
        //    {
        //        valueStatus = fixAttendance.Status;
        //    }
        //    if (fixAttendance.SectId != 0)
        //    {
        //        valueSec = fixAttendance.SectId.ToString();
        //    }
        //    if (fixAttendance.ShiftId != 0)
        //    {
        //        valueShift = fixAttendance.ShiftId.ToString();
        //    }

        //    DateTime dtFrom = fixAttendance.DtFrom;
        //    DateTime dtTo = fixAttendance.DtTo;

        //    List<AttFixGrid> list = new List<AttFixGrid>();

        //    try
        //    {
        //        var comid = HttpContext.Session.GetString("comid");

        //        SqlParameter[] sqlParameter = new SqlParameter[10];
        //        sqlParameter[0] = new SqlParameter("@Id", "1");
        //        sqlParameter[1] = new SqlParameter("@ComId", comid);
        //        sqlParameter[2] = new SqlParameter("@OptCriteria", optCritaria);
        //        sqlParameter[3] = new SqlParameter("@Value", value);
        //        sqlParameter[4] = new SqlParameter("@dtfrom", dtFrom);
        //        sqlParameter[5] = new SqlParameter("@dtTo", dtTo);
        //        sqlParameter[6] = new SqlParameter("@Line", valueLine);
        //        sqlParameter[7] = new SqlParameter("@SectId", valueSec);
        //        sqlParameter[8] = new SqlParameter("@Status", valueStatus);
        //        sqlParameter[9] = new SqlParameter("@ShiftId", valueShift);
        //        List<AttFixGrid> listOfAttFixed = Helper.ExecProcMapTList<AttFixGrid>("HR_PrcGetFixAtt", sqlParameter);

        //        return listOfAttFixed;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        //clsCon = null;
        //    }
        //}

        //private List<AttFixGrid> GetAllData()
        //{


        //    try
        //    {

        //        var comid = HttpContext.Session.GetString("comid");

        //        SqlParameter[] sqlParameter = new SqlParameter[9];
        //        sqlParameter[0] = new SqlParameter("@Id", "1");
        //        sqlParameter[1] = new SqlParameter("@ComId", comid);
        //        sqlParameter[2] = new SqlParameter("@OptCriteria", "All");
        //        sqlParameter[3] = new SqlParameter("@dtfrom", "01-jan-20");
        //        sqlParameter[4] = new SqlParameter("@dtTo", "01-june-20");
        //        sqlParameter[6] = new SqlParameter("@SectId", "");
        //        sqlParameter[7] = new SqlParameter("@Status", "");
        //        sqlParameter[8] = new SqlParameter("@ShiftId", "");
        //        List<AttFixGrid> listOfAttFixed = Helper.ExecProcMapTList<AttFixGrid>("HR_PrcGetFixAtt", sqlParameter);


        //        return listOfAttFixed;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return null;
        //    }
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateSelectedData(string GridDataList)
        {
            var comid = HttpContext.Session.GetString("comid");
            var pcName = HttpContext.Session.GetString("pcname");
            var userid = HttpContext.Session.GetString("userid");
            if (GridDataList != null)
            {


                var JObject = new JObject();
                var d = JObject.Parse(GridDataList);
                string objct = d["GridDataList"].ToString();
                var model = JsonConvert.DeserializeObject<List<AttFixGrid>>(objct);

                using (var tr = db.Database.BeginTransaction())
                {
                    foreach (var aGridData in model)
                    {

                        try
                        {
                            #region update HR_AttFixed working

                            var f = db.HR_AttFixed.Where(x => x.EmpId == aGridData.EmpId).Where(y => y.DtPunchDate == Convert.ToDateTime(aGridData.dtPunchDate)).ToList();
                            //var stId = db.Cat_AttStatus.Where(x => x.AttStatus == aGridData.Status).Select(x => x.StatusId).FirstOrDefault();
                            //var shiftId = db.Cat_Shift.Where(x => x.ShiftName == aGridData.ShiftName).Select(x => x.ShiftId).FirstOrDefault();
                            if (f.Count() > 0)
                            {
                                db.HR_AttFixed.RemoveRange(f);
                                db.SaveChanges();
                            }



                            var fixAtt = new HR_AttFixed();
                            var processData = new HR_ProcessedData();

                            fixAtt.ComId = comid;
                            fixAtt.EmpId = aGridData.EmpId;
                            fixAtt.DtPunchDate = Convert.ToDateTime(aGridData.dtPunchDate);
                            fixAtt.TimeIn = TimeSpan.Parse(aGridData.TimeIn);
                            fixAtt.TimeOut = TimeSpan.Parse(aGridData.TimeOut);
                            fixAtt.StatusId = Convert.ToInt16(aGridData.StatusId);// stId;
                            fixAtt.Status = aGridData.Status;// stId;

                            fixAtt.ShiftId = aGridData.ShiftId;
                            fixAtt.Remarks = aGridData.Remarks;
                            fixAtt.PcName = pcName;
                            fixAtt.TimeInPrev = TimeSpan.Parse(aGridData.TimeIn);
                            fixAtt.TimeOutPrev = TimeSpan.Parse(aGridData.TimeOut);
                            fixAtt.DtTran = DateTime.Now;
                            fixAtt.IsInactive = true;
                            fixAtt.OTHour = float.Parse(aGridData.OtHour);
                            fixAtt.OTHourInTime = TimeSpan.Parse(aGridData.OTHourInTime);

                            fixAtt.OTHourPrev = 0;
                            fixAtt.StatusPrev = aGridData.Status;

                            db.HR_AttFixed.Add(fixAtt);
                            db.SaveChanges();
                            #endregion



                            #region Method 1 to update ProcessData
                            var prosData = db.HR_ProcessedData.Where(x => x.EmpId == aGridData.EmpId && x.DtPunchDate.Date == aGridData.dtPunchDate.Date && x.ComId == comid && x.ShiftId == aGridData.ShiftId).FirstOrDefault();
                            if (prosData != null)
                            {
                                prosData.TimeIn = TimeSpan.Parse(aGridData.TimeIn);
                                prosData.TimeOut = TimeSpan.Parse(aGridData.TimeOut);
                                prosData.OTHour = float.Parse(aGridData.OtHour);
                                //prosData.Oth = TimeSpan.Parse(aGridData.OtHour);
                                prosData.Status = aGridData.Status;
                                prosData.Remarks = aGridData.Remarks;

                                db.Entry(prosData).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            #endregion




                        }
                        catch (SqlException ex)
                        {

                            Console.WriteLine(ex.Message);
                            tr.Rollback();

                        }
                    }
                    tr.Commit();
                }

                return Json(new { Success = 1, message = "Data Updated Successfully" });
            }

            return null;
        }



        public JsonResult StatusListFromMVC()
        {
            var JObject = new JObject();
            var GridDataList = new SelectList(db.Cat_AttStatus.ToList(), "StatusId", "AttStatus").ToList();

            var output = JsonConvert.SerializeObject(GridDataList);
            //var d = JObject.Parse(GridDataList.ToList());

            //TODO: Check the user if it is admin or normal user, (true-Admin, false- Normal user)  
            //string output = isAdmin ? "Welcome to the Admin User" : "Welcome to the User";

            return Json(output);
        }

    }
}
