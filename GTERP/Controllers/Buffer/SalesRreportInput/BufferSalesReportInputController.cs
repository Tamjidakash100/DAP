using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.Buffers;
using GTERP.Models.BufferSalesReportInput;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers.Buffer
{
    public class BufferSalesReportInputController : Controller
    {
        private readonly GTRDBContext _context;
        private TransactionLogRepository tranlog;
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
        //public CommercialRepository Repository { get; set; }



        public BufferSalesReportInputController(GTRDBContext context, TransactionLogRepository tran)
        {
            _context = context;
            tranlog = tran;
            //Repository = rep;
        }
        // GET: Designation
        public async Task<IActionResult> Index()
        {
            var ComId = HttpContext.Session.GetString("comid");
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            //tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");
            var data = await _context.BufferSaleReportInputs.Include(d => d.BufferList).Include(y => y.YearName).Include(m => m.MonthName).Where(x => x.ComId == ComId).OrderByDescending(x => x.BufferSalesReportInputId).ToListAsync();
            return View(data);
        }



        // GET: BufferList/Create
        [HttpGet]
        public IActionResult Create(int? Id)
        {
            var comid = (HttpContext.Session.GetString("comid"));

            // ViewData["RepresentativeId"] = new SelectList(db.BufferRepresentative, "RepresentativeId", "RepresentativeName");
            BufferVm model = new BufferVm();

            ViewBag.Title = "Create";
            model = new BufferVm();

            ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.Where(x => x.comid == comid).OrderByDescending(y => y.FYName), "FiscalYearId", "FYName");
            ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths.Where(x => x.ComId == comid), "FiscalMonthId", "MonthName");
            ViewData["BufferId"] = new SelectList(_context.Buffers.Where(x => x.BufferListId > 0 && x.ComId == comid), "BufferListId", "BufferName");

            model.drpDistricts = _context.Cat_District.Select(x => new SelectListItem { Text = x.DistName, Value = x.DistId.ToString() }).ToList();
            model.drpBufferRep = _context.BuferRepresentative.Select(x => new SelectListItem { Text = x.RepresentativeName, Value = x.BufferRepresentativeId.ToString() }).ToList();
            return View(model);



        }
        [HttpPost]
        public IActionResult Create(BufferSaleReportInput model)
        {
            ViewBag.Title = "Create";
            var comId = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");

            BufferSaleReportInput data = new BufferSaleReportInput();


            data.FiscalYearId = model.FiscalYearId;
            data.FiscalMonthId = model.FiscalMonthId;
            data.BufferID = model.BufferID;
            data.DtInput = model.DtInput;
            data.UnitPrice = model.UnitPrice;
            data.ReciveByBuffer = model.ReciveByBuffer;
            data.SalesByBuffer = model.SalesByBuffer;
            data.ComId = comId;
            data.UserId = userid;
            data.DateAdded = DateTime.Today;
            data.UpdateByUserId = userid;
            data.DateUpdated = DateTime.Today;

            _context.BufferSaleReportInputs.Add(data);
            _context.SaveChanges();



            return RedirectToAction("index");
        }




        // GET: DistrictWiseBookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var comid = (HttpContext.Session.GetString("comid"));
            ViewBag.Title = "Edit";
            if (id == null)
            {
                return NotFound();
            }

            //var BufferSaleReportInput = await _context.BufferSaleReportInputs.FindAsync(id);
            var BufferSaleReportInput = await _context.BufferSaleReportInputs
                    .Include(y => y.YearName)
                    .Include(m => m.MonthName)
                    .Include(d => d.BufferList)
                    .Where(b => b.BufferSalesReportInputId == id).FirstOrDefaultAsync();
            if (BufferSaleReportInput == null)
            {
                return NotFound();
            }

            ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.Where(x => x.comid == comid).OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", BufferSaleReportInput.FiscalYearId);
            ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths, "FiscalMonthId", "MonthName", BufferSaleReportInput.FiscalMonthId);
            ViewBag.BufferId = new SelectList(_context.Buffers.Where(d => d.BufferListId == BufferSaleReportInput.BufferID), "BufferListId", "BufferName", BufferSaleReportInput.BufferID);

            ViewData["BufferId"] = new SelectList(_context.Buffers.Where(x => x.BufferListId > 0 && x.ComId == comid), "BufferListId", "BufferName", BufferSaleReportInput.BufferID);


            return View(BufferSaleReportInput);
        }

        // POST: DistrictWiseBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BufferSaleReportInput bufferSaleReportInput)
        {
            var comid = (HttpContext.Session.GetString("comid"));

            if (ModelState.IsValid)
            {
                try
                {

                    var userid = (HttpContext.Session.GetString("userid"));


                    bufferSaleReportInput.UpdateByUserId = userid;
                    bufferSaleReportInput.DateUpdated = DateTime.Now;

                    _context.Update(bufferSaleReportInput);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BufferWiseBookingExists(bufferSaleReportInput.BufferSalesReportInputId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            };

            ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName");
            ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths, "FiscalMonthId", "MonthName");
            ViewData["BufferId"] = new SelectList(_context.Buffers.Where(x => x.BufferListId > 0 && x.ComId == comid), "BufferListId", "BufferName");
            return View(bufferSaleReportInput);
        }

        // GET: BufferWiseBooking/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var comid = (HttpContext.Session.GetString("comid"));
            ViewBag.Title = "Delete";
            if (id == null)
            {
                return NotFound();
            }

            var BufferSaleReportInput = await _context.BufferSaleReportInputs
                .Include(d => d.BufferList)
                .FirstOrDefaultAsync(m => m.BufferSalesReportInputId == id);
            if (BufferSaleReportInput == null)
            {
                return NotFound();
            }
            ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.Where(x => x.comid == comid).OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", BufferSaleReportInput.FiscalYearId);
            ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths, "FiscalMonthId", "MonthName", BufferSaleReportInput.FiscalMonthId);
            ViewBag.BufferId = new SelectList(_context.Buffers.Where(d => d.BufferListId == BufferSaleReportInput.BufferID), "BufferListId", "BufferName", BufferSaleReportInput.BufferID);
            ViewData["BufferId"] = new SelectList(_context.Buffers.Where(x => x.BufferListId > 0 && x.ComId == comid), "BufferListId", "BufferName", BufferSaleReportInput.BufferID);

            return View(BufferSaleReportInput);
        }

        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(int id)
        {
            try
            {

                BufferSaleReportInput bufferSaleReportInput = _context.BufferSaleReportInputs.Find(id);
                _context.BufferSaleReportInputs.Remove(bufferSaleReportInput);
                _context.SaveChanges();
                return Json(new { Success = 1, BufferSaleReportID = bufferSaleReportInput.BufferSalesReportInputId, ex = "" });

            }

            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.Message.ToString() });
            }
        }

        private bool BufferWiseBookingExists(int id)
        {
            return _context.BuffertWiseBookings.Any(e => e.BufferBookingId == id);
        }

    }
}
