using DocumentFormat.OpenXml.Bibliography;
using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.Buffers;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using static GTERP.Controllers.Buffer.BufferWishBookingController;

namespace GTERP.Controllers.Buffer
{

    public class BufferRepresentativeWiseAllotement : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext _context;
        public BufferRepresentativeWiseAllotement(GTRDBContext context, TransactionLogRepository tran)
        {
            _context = context;
            tranlog = tran;

        }
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            string comid = HttpContext.Session.GetString("comid");
            var data = await _context.RepresentativeBooking.Where(x => x.ComId == comid).Include(y => y.YearName).Include(m => m.MonthName).Include(b => b.BufferList).Include(x => x.BufferRepresentative).OrderByDescending(o=>o.RepresentativeBookingId).ToListAsync();
            return View(data);

        }

        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            var comid = HttpContext.Session.GetString("comid");

            var lastbookingdata = _context.RepresentativeBooking.Take(1).Where(x => x.ComId == comid).OrderByDescending(x => x.RepresentativeBookingId).FirstOrDefault();
            // var lastRepbookingdata = _context.BuffertWiseBookings.Take(1).Where(x => x.BufferBookingId == lastbookingdata.BufferBookingId).OrderByDescending(x => x.BufferBookingId).FirstOrDefault();

            //if (lastbookingdata != null)
            //{
            //    var samplebookingdata = new RepresentativeBooking();
            //    samplebookingdata.FiscalYearId = lastbookingdata.FiscalYearId;
            //    samplebookingdata.FiscalMonthId = lastbookingdata.FiscalMonthId;
            //    ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", lastbookingdata.FiscalYearId);
            //    ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths.Where(x => x.FYId == lastbookingdata.FiscalYearId), "FiscalMonthId", "MonthName", lastbookingdata.FiscalMonthId);
            //    ViewBag.BufferListId = new SelectList(_context.Buffers.Where(x => x.ComId == comid), "BufferListId", "BufferName", lastbookingdata.BufferListId);
            //    ViewBag.BufferRepresentativeId = new SelectList(_context.BuferRepresentative, "BufferRepresentativeId", "RepresentativeName", lastbookingdata.BufferRepresentativeId);
            //    //ViewBag.DistId = new SelectList(_context.Cat_District.OrderBy(d => d.SL), "DistId", "DistName", lastbookingdata.DistId);
            //    //ViewBag.PStationId = new SelectList(_context.Cat_PoliceStation.Where(x => x.DistId == lastbookingdata.DistId), "PStationId", "PStationName", lastbookingdata.PStationId);
            //    //ViewData["AllotmentTypeList"] = new SelectList(AllotmentTypeList.OrderByDescending(x => x.Text), "Value", "Text", lastRepbookingdata.AllotmentType);
            //    return View();
            //}


            ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName");
            ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths.OrderByDescending(y => y.MonthName), "FiscalMonthId", "MonthName");

            ViewBag.BufferListId = new SelectList(_context.Buffers.Where(x => x.ComId == comid), "BufferListId", "BufferName");
            ViewBag.BufferRepresentativeId = new SelectList(_context.BuferRepresentative, "BufferRepresentativeId", "RepresentativeName");
            //ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName");
            //ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths, "FiscalMonthId", "MonthName");

            //ViewData["AllotmentTypeList"] = new SelectList(AllotmentTypeList.OrderByDescending(x => x.Text), "Value", "Text");
            return View();


        }
        [HttpPost]
        public IActionResult Create(RepresentativeBooking booking)
        {
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");
            if (booking.RepresentativeBookingId > 0)
            {
                var exist = _context.RepresentativeBooking.Where(w => w.RepresentativeBookingId == booking.RepresentativeBookingId).FirstOrDefault();
                if (exist != null)
                {
                    exist.AllotmentQty = booking.AllotmentQty;
                    exist.DateAdded = booking.DateAdded;
                    exist.DateUpdated = DateTime.Today;
                    exist.UpdateByUserId = userid;
                    _context.RepresentativeBooking.Update(exist);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "Something wrong";
                    return View("Create", TempData["Message"]);
                }

            }
            else
            {
                try
                {
                    booking.ComId = comid;
                    booking.UserId = userid;
                    DateTime date = (DateTime)booking.DateAdded;
                    
                    string dateString = date.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
                    DateTime date2 = DateTime.ParseExact(dateString, "yyyy-MM-dd HH:mm:ss.fffffff", CultureInfo.InvariantCulture);

                    string FiscalMonth = date.Year.ToString() + " (" + date.ToString("MMMM") + " )";

                    //    var fmonth = _context.Acc_FiscalYears.Where(w=>w.FiscalYearId==booking.FiscalYearId).Select(s => s.dtFrom).FirstOrDefault();
                    //var parseDate= DateTime.ParseExact(fmonth, "MMM d yyyy hh:mmtt", CultureInfo.InvariantCulture);
                    ////var result = _context.Acc_FiscalMonths.Where(x => x.FYId == booking.FiscalYearId);
                    ////string dtf = _context.Acc_FiscalMonths.Where(x => x.FYId == booking.FiscalYearId)
                    //                .Include(x => x.dtFrom >= result).FirstOrDefault();

                    var monthId = (from br in _context.Acc_FiscalMonths
                                   where (br.MonthName == FiscalMonth)
                                   select br.FiscalMonthId).FirstOrDefault();


                    //var month = _context.Acc_FiscalMonths.Select(x => x.OpeningdtFrom).ToList();
                    //var month1 = month.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
                    //List<Date> dateList = month.Select(d => d.Date).ToList();

                    //var monthId = (from br in _context.Acc_FiscalMonths
                    //               where (br.OpeningdtFrom >= date
                    //               && br.ClosingdtTo <= date
                    //               && br.FYId == booking.FiscalYearId)
                    //               select br.FiscalMonthId
                    //               ).FirstOrDefault();


                    booking.FiscalMonthId = monthId;

                    _context.Add(booking);
                    _context.SaveChanges();


                    return RedirectToAction("Index");
                }
                catch
                {
                    return RedirectToAction("Create");
                }
            }
        }
        public IActionResult Edit(int bookingId)
        {
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");

            if (bookingId > 0)
            {

                var exist = _context.RepresentativeBooking.Where(w => w.RepresentativeBookingId == bookingId).FirstOrDefault();
                if (exist != null)
                {

                    RepresentativeBooking RB = new();
                    RB.RepresentativeBookingId = exist.RepresentativeBookingId;
                    RB.OrderNo = exist.OrderNo;
                    RB.TotalAllowed = _context.BuffertWiseBookings.Where(y => y.BufferBookingId == exist.BufferBookingId && y.FiscalYearId == exist.FiscalYearId).Select(s => s.Qty).FirstOrDefault();
                    RB.Allocated = _context.RepresentativeBooking.Where(y => y.BufferBookingId == exist.BufferBookingId && y.FiscalYearId == exist.FiscalYearId).Sum(x => x.AllotmentQty);
                    RB.RemainQty = RB.TotalAllowed - RB.Allocated;
                    RB.AllotmentQty = exist.AllotmentQty;
                    RB.DateAdded = exist.DateAdded;

                    ViewBag.Title = "Edit";

                    ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", exist.FiscalYearId);
                    ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths.Where(x => x.FYId == exist.FiscalYearId), "FiscalMonthId", "MonthName", exist.FiscalMonthId);
                    ViewBag.BufferListId = new SelectList(_context.Buffers.Where(x => x.ComId == comid), "BufferListId", "BufferName", exist.BufferListId);
                    ViewBag.BufferRepresentativeId = new SelectList(_context.BuferRepresentative, "BufferRepresentativeId", "RepresentativeName", exist.BufferRepresentativeId);

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

                var exist = _context.RepresentativeBooking.Where(w => w.RepresentativeBookingId == bookingId).FirstOrDefault();
                if (exist != null)
                {
                    _context.RepresentativeBooking.Remove(exist);
                    _context.SaveChanges();




                    return Json(new { flag = '1', Msg = "Successfully Deleted" });
                }
                else
                {
                    return Json(new { flag = '2', Msg = "Unable to delete" });

                }



            }
            else { return Json("no id found"); }

        }

        public class RepresentativeBookingList
        {
            public string AllotmentType { get; set; }
            public int RepresentativeBookingId { get; set; }
            public string OrderNo { get; set; }

            public string Year { get; set; }
            public string Month { get; set; }

            public string BufferName { get; set; }

            public string RepresentativeCode { get; set; }
            public string RepresentativeName { get; set; }
            public int BufferId { get; set; }
            public int BufferListId { get; set; }
            public int BufferWBookingid { get; set; }
            public string PrevAllotmentQty { get; set; }
            public string TotalAllocated { get; set; }
            public string Balance { get; set; }
            public string BufferWiseAllotment { get; set; }
            
            public float AllotmentQty { get; set; }
            public string RemainingQty { get; set; }



        }

        [HttpPost]
        public JsonResult AllotmentInfo(int id, int yearid)
        {
            var comid = HttpContext.Session.GetString("comid");
            try
            {
                

                //var query = $"EXEC PrcGetBufferWiseBookingAllotment '{comid}', '{Year}' , '{Month}' , '{type}'";
                SqlParameter[] parameters = new SqlParameter[3];

                parameters[0] = new SqlParameter("@ComId", comid);
                parameters[1] = new SqlParameter("@Representativeid", id);
                parameters[2] = new SqlParameter("@Year", yearid);
               


                List<RepresentativeBookingList> DeliveryOrderData = Helper.ExecProcMapTList<RepresentativeBookingList>("PrcGetBufferRepresentativeBookingAllotment", parameters);

                return Json(DeliveryOrderData);



            }
            catch (Exception ex)
            {
                return Json(new { success = false, values = ex.Message.ToString() });
            }
        }
    }
}
