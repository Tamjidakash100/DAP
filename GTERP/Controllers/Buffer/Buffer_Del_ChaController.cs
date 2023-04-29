using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.Buffers;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static GTERP.Controllers.Buffer.BufferRepresentativeWiseBooking;

namespace GTERP.Controllers.Buffer
{
    public class Buffer_Del_ChaController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext _context;
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
        public clsProcedure clsProc { get; }

        public Buffer_Del_ChaController(TransactionLogRepository tranlog, GTRDBContext context)
        {
            this.tranlog = tranlog;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            string comid = HttpContext.Session.GetString("comid");
            var data = await _context.BufferDelChallan.Where(x => x.ComId == comid).Include(y => y.RepresentativeBooking).ThenInclude(i => i.BufferRepresentative).Include(i => i.RepresentativeBooking.BufferList).Include(m => m.BufferRepresentativeMember).ToListAsync();
            return View(data);

        }
        public class ReportchallanTalli
        {
            public string ReportFormat { get; set; }
            public string Report { get; set; }
            public string FromDate { get; set; }
            public string ToDate { get; set; }




        }
        [HttpPost, ActionName("BufferChallanTali")]
        public JsonResult BufferChallanTali(ReportchallanTalli reportchallanTalli)
        {
            try
            {
                string comid = HttpContext.Session.GetString("comid");

                var reportname = "";
                var filename = "";
                string redirectUrl = "";

                reportname = "rptDAPFertilizerSupplyChallan(Buffer)";
                filename = "DAPFertilizerSupplyChallan(Buffer)" + DateTime.Now.Date.ToString();
                var query = "Exec Buffer_rptdafReport '31312C54-659B-4E63-B4BA-2BC3D7B05792','0','0','25-Feb-2023','25-Feb-2023','0','0','DAP Fertilizer Supply Challan(Buffer)','','' ";
                HttpContext.Session.SetString("reportquery", "Buffer_rptdafReport '" + comid + "','','','','','','','','"+ reportchallanTalli.FromDate + "','"+ reportchallanTalli.ToDate + "' ");
                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/BufferReport/" + reportname + ".rdlc");
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";


                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = reportchallanTalli.ReportFormat });
                redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });

            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
            return Json(new { Success = 0, ex = new Exception("Unable to Open").Message.ToString() });
            //return RedirectToAction("Index");
        }

        public ActionResult Print(int? id)
        {
            string SqlCmd = "";
            string ReportPath = "";
            var ConstrName = "ApplicationServices";
            var ReportType = "PDF";
            var comid = HttpContext.Session.GetString("comid");

            var reportname = "rptDAPFertilizerSupplyChallan(Buffer)ID";
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/BufferReport/" + reportname + ".rdlc");
            HttpContext.Session.SetString("reportquery", "Exec [Buffer_rptDAPFertilizerSupplyChallan(Buffer)ID] '" + comid + "','" + id + "'");

            string filename = _context.BufferDelChallan.Where(x => x.BufferDelChallanId == id).Single().BufferDelChallanId.ToString();
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

            string DataSourceName = "DataSet1";
            HttpContext.Session.SetObject("rptList", postData);

            clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
            clsReport.strQueryMain = HttpContext.Session.GetString("reportquery");
            clsReport.strDSNMain = DataSourceName;


            SqlCmd = clsReport.strQueryMain;
            ReportPath = clsReport.strReportPathMain;
            ReportType = "PDF";

            //string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); // this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //Repository.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);
            string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType });
            return Redirect(callBackUrl);

        }

        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            var comid = HttpContext.Session.GetString("comid");
            ViewBag.BufferRepresentativeId = new SelectList(_context.BuferRepresentative, "BufferRepresentativeId", "RepresentativeName");
            var lastbookingdata = _context.BufferDelChallan.Take(1).Where(x => x.ComId == comid).OrderByDescending(x => x.BufferDelChallanId).FirstOrDefault();

            ViewBag.lastChalanNo = _context.BufferDelChallan.Where(w => w.ComId == comid).OrderByDescending(o=>o.ChallanNo).Select(s => s.ChallanNo).FirstOrDefault() +1;

            //var lastbookingdata = _context.RepresentativeBooking.Take(1).Where(x => x.ComId == comid).OrderByDescending(x => x.RepresentativeBookingId).FirstOrDefault();
            //// var lastRepbookingdata = _context.BuffertWiseBookings.Take(1).Where(x => x.BufferBookingId == lastbookingdata.BufferBookingId).OrderByDescending(x => x.BufferBookingId).FirstOrDefault();


            //ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", lastbookingdata.FiscalYearId);
            //ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths.Where(x => x.FYId == lastbookingdata.FiscalYearId), "FiscalMonthId", "MonthName", lastbookingdata.FiscalMonthId);


            ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName");
            ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths, "FiscalMonthId", "MonthName");

            ViewBag.RepresentativeMemberId = new SelectList(_context.BufferRepresentativeMember, "Id", "Name");

            return View();


        }
        [HttpPost]
        public IActionResult Create(BufferDelChallan booking)
        {
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");
            if (booking.BufferDelChallanId > 0)
            {
                var exist = _context.BufferDelChallan.Where(w => w.BufferDelChallanId == booking.BufferDelChallanId).FirstOrDefault();
                if (exist != null)
                {
                    exist.DeliveryQty = booking.DeliveryQty;
                    exist.DateUpdated = DateTime.Today;
                    exist.UpdateByUserId = userid;
                    _context.BufferDelChallan.Update(exist);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "Something wrong";
                    return Json("Create", TempData["Message"]);
                }

            }
            else
            {
                try
                {
                    booking.ComId = comid;
                    booking.UserId = userid;
                    booking.DateAdded = DateTime.Today;


                    _context.BufferDelChallan.Add(booking);
                    _context.SaveChanges();


                    return RedirectToAction("Index");
                }
                catch
                {
                    TempData["Message"] = "Something wrong";
                    return Json("Create", TempData["Message"]);
                }
            }
        }
        public IActionResult Edit(int ChalanId)
        {
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");

            if (ChalanId > 0)
            {

                var exist = _context.BufferDelChallan.Include(i => i.RepresentativeBooking.BufferRepresentative).Where(w => w.BufferDelChallanId == ChalanId).FirstOrDefault();
                if (exist != null)
                {

                    BufferDelChallan RB = new();
                    RB.BufferDelChallanId = exist.BufferDelChallanId;
                    RB.ChallanNo = exist.ChallanNo;
                    RB.DeliveryQty = exist.DeliveryQty;
                    RB.DeliveryDate = exist.DeliveryDate;
                    RB.TotalAllocated = _context.RepresentativeBooking.Where(w => w.RepresentativeBookingId == exist.RepresentativeBookingId && w.ComId == comid).Select(s => s.AllotmentQty).FirstOrDefault();
                    RB.alreadyAlocated = _context.BufferDelChallan.Where(w => w.RepresentativeBookingId == exist.RepresentativeBookingId && w.ComId == comid).Sum(s => s.DeliveryQty);
                    RB.Available = (RB.TotalAllocated - RB.alreadyAlocated);


                    ViewBag.Title = "Edit";
                    ViewBag.BufferRepresentativeId = new SelectList(_context.BuferRepresentative, "BufferRepresentativeId", "RepresentativeName", exist.RepresentativeBooking.BufferRepresentative.BufferRepresentativeId);
                    ViewBag.RepresentativeMemberId = new SelectList(_context.BufferRepresentativeMember, "Id", "Name", exist.RepresentativeMemberId);


                    return View("Create", RB);
                }
                else
                {
                    return Json("Unable to edit");
                }



            }
            else { return Json("no id found"); }

        }


        public IActionResult Delete(int bookingId)
        {
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");

            if (bookingId > 0)
            {

                var exist = _context.BufferDelChallan.Where(w => w.BufferDelChallanId == bookingId && w.ComId==comid).FirstOrDefault();
                if (exist != null)
                {
                    _context.BufferDelChallan.Remove(exist);
                    _context.SaveChanges();




                    return Json(new { flag = '1', Msg = "Successfully Deleted" });
                }
                else
                {
                    return Json(new { flag = '2', Msg = "Unable to delete" });

                }



            }
            else
            {
                return Json(new { flag = '2', Msg = "No id Found" });

            }
        }
        [HttpGet]
        public JsonResult getRepesentativeMember(int id)
        {
            if (id <= 0)
            {
                return Json(new { flag = "0", msg = "Invalid Buffer Repesentative Id." });
            }

            var RepesentativeMember = _context.BufferRepresentativeMember.Where(x => x.BufferRepresentativeId == id).ToList();

            if (RepesentativeMember.Count > 0 && RepesentativeMember != null)
            {
                return Json(new { flag = "1", msg = "RepesentativeMember Name found.", data = RepesentativeMember });
            }
            else
            {
                return Json(new { flag = "0", msg = "RepesentativeMember Name not found." });
            }
        }




        [HttpPost]
        public JsonResult AllotmentInfo(int id)
        {
            var comid = HttpContext.Session.GetString("comid");
            try
            {
                var query = (from e in _context.RepresentativeBooking.Where(x => x.BufferRepresentativeId == id && x.RepresentativeBookingId > 0 && x.ComId == comid).OrderByDescending(x => x.RepresentativeBookingId)
                             select new RepresentativeBookingList
                             {
                                 RepresentativeBookingId = e.RepresentativeBookingId,
                                 OrderNo = e.OrderNo,
                                 Year = e.YearName.FYName,
                                 Month = e.MonthName.MonthName,

                                 Buffer = e.BufferList.BufferName,
                                 RepresentativeCode = e.BufferRepresentative.RepresentativeCode,
                                 RepresentativeName = e.BufferRepresentative.RepresentativeName,


                                 AllotmentQty = e.AllotmentQty,
                                 RemainingQty = Math.Round(e.AllotmentQty - ((_context.BufferDelChallan.Where(w => w.RepresentativeBookingId == e.RepresentativeBookingId).Select(x => x.DeliveryQty) != null ? (_context.BufferDelChallan.Where(w => w.RepresentativeBookingId == e.RepresentativeBookingId).Sum(x => x.DeliveryQty)) : 0)), 2).ToString("0.00")
                                 //e.vDeliveryOrder.Sum(x=>x.Qty)).ToString()
                                 //e.AllotmentQty - float.Parse
                             }).ToList();
                if (query == null)
                {
                    return Json(new { success = false });
                }

                return Json(query);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, values = ex.Message.ToString() });
            }
        }



    }
}
