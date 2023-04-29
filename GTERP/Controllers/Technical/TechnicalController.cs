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

namespace GTERP.Controllers.HouseKeeping
{
    [OverridableAuthorize]
    public class TechnicalController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;
        //public CommercialRepository Repository { get; set; }
        public TechnicalController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
            //Repository = rep;
        }

        // GET: Technical
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            //var sectio
            return View(await db.Technical.Include(m => m.Cat_Meeting).ToListAsync());
        }

        // GET: Technical/Create
        public IActionResult Create()
        {

            ViewBag.Title = "Create";
            ViewBag.MeetingId = new SelectList(db.Cat_Meeting, "MeetingId", "Meeting");
            ViewBag.MeetingType = new SelectList(db.Cat_Variable.Where(c => c.VarType.Equals("Technical")), "VarName", "VarName");
            return View(new Technical());
        }

        // POST: Technical/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Technical Technical)
        {
            if (ModelState.IsValid)
            {
                Technical.UserId = HttpContext.Session.GetString("userid");
                Technical.ComId = HttpContext.Session.GetString("comid");




                if (Technical.TechnicalId > 0)
                {
                    Technical.DateUpdated = DateTime.Today;
                    Technical.UpdateByUserId = HttpContext.Session.GetString("userid");
                    db.Entry(Technical).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Technical.TechnicalId.ToString(), "Update", Technical.MeetingId.ToString());

                }
                else
                {
                    Technical.DateAdded = DateTime.Today;
                    db.Add(Technical);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Technical.TechnicalId.ToString(), "Create", Technical.MeetingId.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(Technical);
        }

        // GET: Technical/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var Technical = await db.Technical.FindAsync(id);
            ViewBag.MeetingId = new SelectList(db.Cat_Meeting, "MeetingId", "Meeting", Technical.MeetingId);
            ViewBag.MeetingType = new SelectList(db.Cat_Variable.Where(c => c.VarType.Equals("Technical")), "VarName", "VarName", Technical.MeetingType);
            if (Technical == null)
            {
                return NotFound();
            }
            return View("Create", Technical);
        }


        // GET: Technical/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Technical = await db.Technical
                 .Include(m => m.Cat_Meeting)
               .FirstOrDefaultAsync(m => m.TechnicalId == id);
            if (Technical == null)
            {
                return NotFound();
            }


            ViewBag.Title = "Delete";
            ViewBag.MeetingId = new SelectList(db.Cat_Meeting, "MeetingId", "Meeting", Technical.MeetingId);
            ViewBag.MeetingType = new SelectList(db.Cat_Variable.Where(c => c.VarType.Equals("Technical")), "VarName", "VarName", Technical.MeetingType);
            return View("Create", Technical);

        }

        // POST: Technical/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var Technical = await db.Technical.FindAsync(id);
                db.Technical.Remove(Technical);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Technical.TechnicalId.ToString(), "Delete", Technical.MeetingId.ToString());
                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, TechnicalId = Technical.TechnicalId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }


        [HttpGet]
        public IActionResult GetMeeting(string meeting)
        {
            var data = db.Cat_Meeting.Where(m => m.MeetingType == meeting)
                .Select(m => new
                {
                    MeetingId = m.MeetingId,
                    Meeting = m.Meeting
                }).ToList();
            return Json(data);
        }


        private bool TechnicalExists(int id)
        {
            return db.Technical.Any(e => e.TechnicalId == id);
        }

        public static List<SelectListItem> ReportTypes = new List<SelectListItem>()
        {
        new SelectListItem() {Text="Meeting", Value="Meeting"},
        new SelectListItem() { Text="Quality Test of Phosphoric Acid", Value="Import"},
        new SelectListItem() { Text="Waste Management", Value="Waste"},
        new SelectListItem() { Text="License Receive/ Renewal", Value="License"},
        new SelectListItem() { Text="Fire & Safety", Value="Fire"},
        new SelectListItem() { Text="Extinguisher", Value="Extinguisher"},
        new SelectListItem() { Text="Training", Value="Training"},
        new SelectListItem() { Text="Visit", Value="Visit"}
        };

        public IActionResult Report()
        {
            var comid = HttpContext.Session.GetString("comid");
            ViewData["ReportType"] = new SelectList(ReportTypes, "Value", "Text");
            return View();
        }

        [HttpGet]
        public IActionResult GetReport(string reportType, DateTime fromDate, DateTime toDate, string rptFormat)
        {
            try
            {
                string comid = HttpContext.Session.GetString("comid");
                var reportname = "";
                var filename = "";
                string redirectUrl = "";

                if (reportType == "Meeting")
                {
                    reportname = "Meeting";
                    filename = "rptMeeting_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec Tech_rptTechnical '" + comid + "','" + fromDate + "','" + toDate + "','" + reportname + "'";
                    HttpContext.Session.SetString("reportquery", "Exec Tech_rptTechnical '" + comid + "','" + fromDate + "','" + toDate + "','" + reportname + "'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Technical/" + "rpt" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (reportType == "Import")
                {
                    reportname = "Import";
                    filename = "rptImport_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec Tech_rptTechnical '" + comid + "','" + fromDate + "','" + toDate + "','" + reportname + "'";
                    HttpContext.Session.SetString("reportquery", "Exec Tech_rptTechnical '" + comid + "','" + fromDate + "','" + toDate + "','" + reportname + "'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Technical/" + "rpt" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (reportType == "Waste")
                {
                    reportname = "Waste";
                    filename = "rptWaste_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec Tech_rptTechnical '" + comid + "','" + fromDate + "','" + toDate + "','" + reportname + "'";
                    HttpContext.Session.SetString("reportquery", "Exec Tech_rptTechnical '" + comid + "','" + fromDate + "','" + toDate + "','" + reportname + "'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Technical/" + "rpt" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (reportType == "License")
                {
                    reportname = "License";
                    filename = "rptLicense_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec Tech_rptTechnical '" + comid + "','" + fromDate + "','" + toDate + "','" + reportname + "'";
                    HttpContext.Session.SetString("reportquery", "Exec Tech_rptTechnical '" + comid + "','" + fromDate + "','" + toDate + "','" + reportname + "'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Technical/" + "rpt" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (reportType == "Fire")
                {
                    reportname = "Fire";
                    filename = "rptFire_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec Tech_rptTechnical '" + comid + "','" + fromDate + "','" + toDate + "','" + reportname + "'";
                    HttpContext.Session.SetString("reportquery", "Exec Tech_rptTechnical '" + comid + "','" + fromDate + "','" + toDate + "','" + reportname + "'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Technical/" + "rpt" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (reportType == "Extinguisher")
                {
                    reportname = "Extinguisher";
                    filename = "rptExtinguisher_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec Tech_rptTechnical '" + comid + "','" + fromDate + "','" + toDate + "','" + reportname + "'";
                    HttpContext.Session.SetString("reportquery", "Exec Tech_rptTechnical '" + comid + "','" + fromDate + "','" + toDate + "','" + reportname + "'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Technical/" + "rpt" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (reportType == "Training")
                {
                    reportname = "Training";
                    filename = "rptTraining_List_" + DateTime.Now.Date.ToString();
                    var query = "Exec Tech_rptTechnical '" + comid + "','" + fromDate + "','" + toDate + "','" + reportname + "'";
                    HttpContext.Session.SetString("reportquery", "Exec Tech_rptTechnical '" + comid + "','" + fromDate + "','" + toDate + "','" + reportname + "'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Technical/" + "rpt" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }
                else if (reportType == "Visit")
                {
                    reportname = "Visit";
                    filename = "rptVisit_List_" + DateTime.Now.Date.ToString(); var query = "Exec Tech_rptTechnical '" + comid + "','" + fromDate + "','" + toDate + "','" + reportname + "'";
                    HttpContext.Session.SetString("reportquery", "Exec Tech_rptTechnical '" + comid + "','" + fromDate + "','" + toDate + "','" + reportname + "'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Technical/" + "rpt" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }

                string DataSourceName = "DataSet1";
                GTERP.Models.Common.clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                GTERP.Models.Common.clsReport.strQueryMain = HttpContext.Session.GetString("reportquery");
                GTERP.Models.Common.clsReport.strDSNMain = DataSourceName;

                var ConstrName = "ApplicationServices";
                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat }); //this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat }); //Repository.GenerateReport(clsReport.strReportPathMain, clsReport.strQueryMain, ConstrName, rptFormat);
                redirectUrl = callBackUrl;
                return Json(new { Url = redirectUrl });
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
