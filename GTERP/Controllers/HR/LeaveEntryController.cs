using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers.HR
{
    [OverridableAuthorize]
    public class LeaveEntryController : Controller
    {

        private readonly GTRDBContext db;

        public LeaveEntryController(GTRDBContext context)
        {
            db = context;
        }

        // GET: LeaveEntry
        public ActionResult Index()
        {
            HR_Leave_Avail LeaveData = db.HR_Leave_Avail.Where(a => a.EmpId == 0).FirstOrDefault();
            ViewBag.LeaveBalance = db.HR_Leave_Balance.Where(l => l.LvBalId == 0).FirstOrDefault();
            ViewBag.EmpId = new SelectList(db.HR_Emp_Info, "EmpId", "EmpName");
            ViewBag.LTypeId = new SelectList(db.Cat_Leave_Type, "LTypeId", "LTypeNameShort");
            return View();
        }

        public JsonResult LoadEmployeeLeaveData(int? empId, DateTime? date)
        {

            DateTime asdf = DateTime.Now.Date;
            if (date is null)
            {
                var adate = DateTime.Now.Year;
            }
            else
            {
                //asdf = date;
            }

            var comid = HttpContext.Session.GetString("comid");


            string year = date.Value.Year.ToString();



            var LeaveBalance = db.HR_Leave_Balance
                .Include(lb => lb.HR_Emp_Info)
                .Where(l => l.ComId == comid && l.EmpId == empId && l.DtOpeningBalance.ToString() == year.ToString())

                .Select(d => new
                {
                    LeaveId = d.LvBalId,
                    Code = d.HR_Emp_Info.EmpCode,
                    EmployeeName = d.HR_Emp_Info.EmpName,
                    Year = year,
                    CLTotal = d.CL,
                    CLEnjoyed = d.ACL,
                    SLTotal = d.SL,
                    SLEnjoyed = d.ASL,
                    ELTotal = d.EL,
                    ELEnjoyed = d.AEL,
                    MLTotal = d.ML,
                    MLEnjoyed = d.AML
                });

            // ViewBag.Leaveavoail = LeaveBalance;
            return Json(LeaveBalance);
        }

        public JsonResult LoadLeaveEntryPartial(int empId)
        {
            try
            {

                List<LeaveEntryView> data = new List<LeaveEntryView>();



                var leaveEntries = db.HR_Leave_Avail
                    .Include(l => l.Cat_Leave_Type)
                    .Include(la => la.HR_Emp_Info)
                    .Where(l => l.EmpId == empId)
                    .Select(l => new
                    {
                        l.LvId,
                        l.HR_Emp_Info.EmpCode,
                        l.HR_Emp_Info.EmpName,
                        l.Cat_Leave_Type.LTypeNameShort,
                        l.DtFrom,
                        l.DtTo,
                        l.TotalDay,
                        l.LvApp,
                        l.Remark,
                        l.Status
                    }).ToList().OrderByDescending(l => l.LvId);

                foreach (var item in leaveEntries)
                {
                    LeaveEntryView asdf = new LeaveEntryView();
                    //asdf.MasterLCID = item.ExportInvoiceMasters.COM_MasterLC.MasterLCID;
                    asdf.LvId = item.LvId;
                    asdf.EmpCode = item.EmpCode;
                    asdf.EmpName = item.EmpName;
                    asdf.LTypeNameShort = item.LTypeNameShort;

                    asdf.DtFrom = DateTime.Parse(item.DtFrom.ToString()).ToString("dd-MMM-yy");
                    asdf.DtTo = DateTime.Parse(item.DtTo.ToString()).ToString("dd-MMM-yy");

                    asdf.TotalDay = item.TotalDay;
                    asdf.LvApp = item.LvApp;
                    asdf.Remark = item.Remark;

                    if (item.Status == 0)
                        asdf.Status = "Pending";
                    else if (item.Status == 1)
                        asdf.Status = "Approved";
                    else if (item.Status == 2)
                        asdf.Status = "Dis Approved";


                    data.Add(asdf);
                }                //ViewBag.LeaveEntries = leaveEntries;
                return Json(data);

                //var leaveEntries = db.HR_Leave_Avail
                //    .Include(l => l.Cat_Leave_Type)
                //    .Include(la => la.HR_Emp_Info)
                //    .Where(l => l.EmpId == empId)
                //    .Select(l => new
                //    {
                //        l.LvId,
                //        l.HR_Emp_Info.EmpCode,
                //        l.HR_Emp_Info.EmpName,
                //        l.Cat_Leave_Type.LTypeNameShort,
                //        l.DtFrom,
                //        l.DtTo,
                //        l.TotalDay,
                //        l.LvApp,
                //        l.Remark
                //    });
                ////ViewBag.LeaveEntries = leaveEntries;
                //return Json(leaveEntries);

            }
            catch (Exception)
            {
                return Json(new { Success = 0, InvoiceId = 0, ex = "Unable to Load the Data" });

            }
        }

        public JsonResult GetToDate(DateTime? DtFrom, double TotalDay)
        {
            DateTime DtTo = DtFrom.Value.AddDays(TotalDay).AddDays(-1);
            string dtto = DtTo.ToString("dd-MMM-yy");
            return Json(dtto);
        }


        public JsonResult LeaveBalanceCheck(int empid)
        {
            var comid = HttpContext.Session.GetString("comid");
            var balance = db.HR_Leave_Balance.Where(b => b.EmpId == empid && b.ComId == comid).FirstOrDefault();
            var leaveType = db.Cat_Leave_Type.Where(t => t.ComId == comid).FirstOrDefault();
            return Json(new { balance, leaveType });
        }


        // GET: LeaveEntry/Create
        public IActionResult Create(int empid)
        {
            HR_Leave_Avail LeaveData = db.HR_Leave_Avail.Where(a => a.EmpId == empid).FirstOrDefault();
            ViewBag.LeaveBalance = db.HR_Leave_Balance.Where(l => l.LvBalId == empid).FirstOrDefault();
            string comid = HttpContext.Session.GetString("comid");

            var empInfo = (from emp in db.HR_Emp_Info
                           join d in db.Cat_Department on emp.DeptId equals d.DeptId
                           join s in db.Cat_Section on emp.SectId equals s.SectId
                           join des in db.Cat_Designation on emp.DesigId equals des.DesigId
                           where emp.ComId == comid
                           select new
                           {
                               Value = emp.EmpId,
                               Text = emp.EmpCode + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                           }).ToList();

            ViewData["EmpId"] = new SelectList(empInfo, "Value", "Text");


            ViewBag.LTypeId = new SelectList(db.Cat_Leave_Type, "LTypeId", "LTypeNameShort");


            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(HR_Leave_Avail hR_Leave_Avail)
        {
            hR_Leave_Avail.PcName = "Sayed";
            hR_Leave_Avail.UserId = HttpContext.Session.GetString("userid");
            hR_Leave_Avail.ComId = HttpContext.Session.GetString("comid");
            hR_Leave_Avail.DtInput = DateTime.Today;

            HR_Leave_Balance LeaveBalance = db.HR_Leave_Balance.Where(e => e.EmpId == hR_Leave_Avail.EmpId && e.ComId == hR_Leave_Avail.ComId && e.DtOpeningBalance == DateTime.Now.Year).FirstOrDefault();
            Cat_Leave_Type LeaveType = db.Cat_Leave_Type.Where(t => t.LTypeId == hR_Leave_Avail.LTypeId).FirstOrDefault();
            float AvailCL = 0;
            float AvailSL = 0;
            float AvailEL = 0;
            float AvailML = 0;
            var Success = "";
            AvailCL = (float)(LeaveBalance.CL - LeaveBalance.ACL);
            AvailSL = (float)(LeaveBalance.SL - LeaveBalance.ASL);
            AvailEL = (float)(LeaveBalance.EL - LeaveBalance.AEL);
            AvailML = (float)(LeaveBalance.ML - LeaveBalance.AML);
            var message = "Leave Balance Over.Please Correction Leave Day";
            Success = "Data Save Successfully";
            try
            {
                try
                {
                    if (LeaveType.LTypeNameShort == "CL")
                    {
                        if (AvailCL >= hR_Leave_Avail.TotalDay)
                        {
                            LeaveBalance.PreviousLeave = LeaveBalance.ACL;
                            LeaveBalance.ACL = (LeaveBalance.PreviousLeave + hR_Leave_Avail.TotalDay);
                        }
                        else
                        {
                            return Json(new { Success = 0, ex = message });

                        }
                    }
                    else if (LeaveType.LTypeNameShort == "EL")
                    {
                        if (AvailEL >= hR_Leave_Avail.TotalDay)
                        {
                            LeaveBalance.PreviousLeave = LeaveBalance.AEL;
                            LeaveBalance.AEL = (LeaveBalance.PreviousLeave + hR_Leave_Avail.TotalDay);
                        }
                        else
                        {
                            return Json(new { Success = 0, ex = message });

                        }
                    }
                    else if (LeaveType.LTypeNameShort == "SL")
                    {
                        if (AvailSL >= hR_Leave_Avail.TotalDay)
                        {
                            LeaveBalance.PreviousLeave = LeaveBalance.ASL;
                            LeaveBalance.ASL = (LeaveBalance.PreviousLeave + hR_Leave_Avail.TotalDay);
                        }
                        else
                        {
                            return Json(new { Success = 0, ex = message });

                        }
                    }
                    else if (LeaveType.LTypeNameShort == "ML")
                    {
                        if (AvailML >= hR_Leave_Avail.TotalDay)
                        {
                            LeaveBalance.PreviousLeave = LeaveBalance.AML;
                            LeaveBalance.AML = (LeaveBalance.PreviousLeave + hR_Leave_Avail.TotalDay);
                        }
                        else
                        {
                            return Json(new { Success = 0, ex = message });

                        }
                    }
                    LeaveBalance.DateAdded = DateTime.Now;
                    LeaveBalance.UpdateByUserId = hR_Leave_Avail.UserId;
                    db.Update(LeaveBalance);
                    await db.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    //throw ex;
                    return Json(new { Success = 0, ex = ex });

                }
                hR_Leave_Avail.LvType = LeaveType.LTypeName;
                hR_Leave_Avail.DateAdded = DateTime.Now;
                db.Add(hR_Leave_Avail);
                await db.SaveChangesAsync().ConfigureAwait(true);

                // hR_Leave_Avail = null;
            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex });

                //throw ex;
            }

            return Json(new { Success = 1, ex = Success });
        }

        public JsonResult LoadGridData(int lvid)
        {
            HR_Leave_Avail LeaveData = db.HR_Leave_Avail.Where(l => l.LvId == lvid).FirstOrDefault();

            LeaveEntryView data = new LeaveEntryView();
            //asdf.MasterLCID = item.ExportInvoiceMasters.COM_MasterLC.MasterLCID;
            data.LvId = LeaveData.LvId;
            data.EmpId = LeaveData.EmpId;
            //asdf.EmpName = LeaveData.EmpName;
            data.LTypeId = LeaveData.LTypeId;

            data.DtFrom = DateTime.Parse(LeaveData.DtFrom.ToString()).ToString("dd-MMM-yy");
            data.DtTo = DateTime.Parse(LeaveData.DtTo.ToString()).ToString("dd-MMM-yy");
            data.DtLvInput = DateTime.Parse(LeaveData.DtLvInput.ToString()).ToString("dd-MMM-yy");
            data.DtInput = DateTime.Parse(LeaveData.DtInput.ToString()).ToString("dd-MMM-yy");


            data.TotalDay = LeaveData.TotalDay;
            data.LvApp = LeaveData.LvApp;
            data.Remark = LeaveData.Remark;
            data.Status = LeaveData.Status.ToString();

            return Json(data);


            //HR_Leave_Avail LeaveData = db.HR_Leave_Avail.Where(l => l.LvId == lvid).FirstOrDefault();
            //return Json(LeaveData);


        }

        public JsonResult Update(HR_Leave_Avail LeaveAvail)
        {
            LeaveAvail.UserId = HttpContext.Session.GetString("userid");
            LeaveAvail.ComId = HttpContext.Session.GetString("comid");
            LeaveAvail.DtInput = DateTime.Today;

            var message = "Leave Balance Over.Please Correction Leave Day";
            HR_Leave_Balance lb = db.HR_Leave_Balance.Where(e => e.EmpId == LeaveAvail.EmpId && e.ComId == LeaveAvail.ComId && e.DtOpeningBalance == DateTime.Now.Year).FirstOrDefault();
            HR_Leave_Balance previouslb = db.HR_Leave_Balance.Where(e => e.EmpId == LeaveAvail.EmpId && e.ComId == LeaveAvail.ComId && e.DtOpeningBalance == DateTime.Now.Year).FirstOrDefault();

            Cat_Leave_Type LeaveType = db.Cat_Leave_Type.Where(t => t.LTypeId == LeaveAvail.LTypeId).FirstOrDefault();
            HR_Leave_Avail PreviousLeave = db.HR_Leave_Avail.Include(l => l.Cat_Leave_Type).AsNoTracking().Where(l => l.LvId == LeaveAvail.LvId).FirstOrDefault();
            float ACL = 0;
            float AEL = 0;
            float ASL = 0;
            float AML = 0;
            LeaveAvail.PreviousDay = PreviousLeave.TotalDay;
            var Success = "";
            if (PreviousLeave.Cat_Leave_Type.LTypeNameShort == "CL")
            {
                ACL = (float)(lb.ACL - LeaveAvail.PreviousDay);
                lb.ACL = ACL;
            }
            else if (PreviousLeave.Cat_Leave_Type.LTypeNameShort == "SL")
            {
                ASL = (float)(lb.ASL - LeaveAvail.PreviousDay);
                lb.ASL = ASL;
            }
            else if (PreviousLeave.Cat_Leave_Type.LTypeNameShort == "EL")
            {
                AEL = (float)(lb.AEL - LeaveAvail.PreviousDay);
                lb.AEL = AEL;
            }
            else if (PreviousLeave.Cat_Leave_Type.LTypeNameShort == "ML")
            {
                AML = (float)(lb.AML - LeaveAvail.PreviousDay);
                lb.AML = AML;
            }

            //db.Update(lb);
            //db.SaveChanges();

            if (LeaveType.LTypeNameShort == "CL")
            {
                ACL = (float)(lb.ACL + LeaveAvail.TotalDay);
                lb.ACL = ACL;
                if (ACL > lb.CL)
                {
                    //db.Update(previouslb);
                    //db.SaveChanges();

                    return Json(new { Success = 0, ex = message });

                    //return Json(message);
                }
            }
            else if (LeaveType.LTypeNameShort == "SL")
            {
                ASL = (float)(lb.ASL + LeaveAvail.TotalDay);
                lb.ASL = ASL;
                if (ASL > lb.SL)
                {
                    //db.Update(PreviousLeave);
                    //db.SaveChanges();

                    return Json(new { Success = 0, ex = message });

                }
            }
            else if (LeaveType.LTypeNameShort == "EL")
            {
                AEL = (float)(lb.AEL + LeaveAvail.TotalDay);
                lb.AEL = AEL;
                if (AEL > lb.EL)
                {
                    //db.Update(PreviousLeave);
                    //db.SaveChanges();

                    return Json(new { Success = 0, ex = message });

                }
            }
            else if (LeaveType.LTypeNameShort == "ML")
            {
                AML = (float)(lb.AML + LeaveAvail.TotalDay);
                lb.AML = AML;
                if (AML > lb.ML)
                {
                    //db.Update(PreviousLeave);
                    //db.SaveChanges();

                    return Json(new { Success = 0, ex = message });

                }
            }
            lb.DateUpdated = DateTime.Now;
            db.Update(lb);
            db.SaveChanges();

            LeaveAvail.DateUpdated = DateTime.Now;
            db.Update(LeaveAvail);
            db.SaveChanges();

            Success = "Data Update Successully";
            return Json(new { Success = 2, ex = Success });

        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(HR_Leave_Avail LeaveAvail)
        {
            try
            {
                LeaveAvail.ComId = HttpContext.Session.GetString("comid");
                HR_Leave_Balance lb = db.HR_Leave_Balance.Where(e => e.EmpId == LeaveAvail.EmpId && e.ComId == LeaveAvail.ComId && e.DtOpeningBalance == DateTime.Now.Year).FirstOrDefault();
                Cat_Leave_Type LeaveType = db.Cat_Leave_Type.Where(t => t.LTypeId == LeaveAvail.LTypeId).FirstOrDefault();
                HR_Leave_Avail PreviousLeave = db.HR_Leave_Avail.Include(l => l.Cat_Leave_Type).AsNoTracking().Where(l => l.LvId == LeaveAvail.LvId).FirstOrDefault();

                var previoustypeid = LeaveType.LTypeId;
                var presenttypeid = LeaveAvail.LTypeId;
                float ACL = 0;
                float AEL = 0;
                float ASL = 0;
                float AML = 0;
                LeaveAvail.PreviousDay = PreviousLeave.TotalDay;
                var Success = "";
                if (PreviousLeave.Cat_Leave_Type.LTypeNameShort == "CL")
                {
                    ACL = (float)(lb.ACL - LeaveAvail.PreviousDay);
                    lb.ACL = ACL;
                }
                else if (PreviousLeave.Cat_Leave_Type.LTypeNameShort == "SL")
                {
                    ASL = (float)(lb.ASL - LeaveAvail.PreviousDay);
                    lb.ASL = ASL;
                }
                else if (PreviousLeave.Cat_Leave_Type.LTypeNameShort == "EL")
                {
                    AEL = (float)(lb.AEL - LeaveAvail.PreviousDay);
                    lb.AEL = AEL;
                }
                else if (PreviousLeave.Cat_Leave_Type.LTypeNameShort == "ML")
                {
                    AML = (float)(lb.AML - LeaveAvail.PreviousDay);
                    lb.AML = AML;
                }

                db.Update(lb);
                db.SaveChanges();

                var id = LeaveAvail.LvId;
                var hR_Leave_Avail = await db.HR_Leave_Avail.FindAsync(id);
                db.HR_Leave_Avail.Remove(hR_Leave_Avail);
                await db.SaveChangesAsync();

                Success = "Data Delete Successully";
                return Json(new { Success = 1, ex = Success });

            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }

        }

        public class LeaveEntryView
        {
            public int LvId { get; set; }

            public int EmpId { get; set; }
            public int LTypeId { get; set; }


            /// </summary>
            public string EmpCode { get; set; }
            public string EmpName { get; set; }
            public string LTypeNameShort { get; set; }
            public string Remark { get; set; }


            public string DtFrom { get; set; }
            public string DtTo { get; set; }
            public string DtLvInput { get; set; }
            public string DtInput { get; set; }


            public float? TotalDay { get; set; }
            public float? LvApp { get; set; }
            public string Status { get; set; }

        }


        private bool HR_Leave_AvailExists(int id)
        {
            return db.HR_Leave_Avail.Any(e => e.LvId == id);
        }
    }
}
