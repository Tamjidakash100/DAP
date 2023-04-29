using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.FactoryDapInfo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers.FactoryInfo
{
    public class BufferFactoryController : Controller
    {
        private readonly GTRDBContext _context;
        private TransactionLogRepository tranlog;
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
        public BufferFactoryController(GTRDBContext context, TransactionLogRepository tran)
        {
            _context = context;
            tranlog = tran;
            //Repository = rep;
        }
        public async Task<IActionResult> Index()
        {
            var ComId = HttpContext.Session.GetString("comid");
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            //tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");
            var data = await _context.BufferFactoryInfomations.Include(b=>b.BufferList).Include(m => m.MonthName).Include(y => y.YearName).Where(x => x.ComId == ComId).ToListAsync();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            DateTime localDate = DateTime.Now;
            ViewBag.date = localDate;
            DateTime utcDate = DateTime.UtcNow;


            var comId = HttpContext.Session.GetString("comid");

            ViewData["BufferId"] = new SelectList(_context.Buffers.Where(x => x.BufferListId > 0 && x.ComId == comId), "BufferListId", "BufferName");

            ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName");
            ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths, "FiscalMonthId", "MonthName");

            return View();
        }
        [HttpPost]
        public IActionResult Create(BufferFactoryInfomation model)
        {
            ViewBag.Title = "Create";
            var comId = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");

            BufferFactoryInfomation data = new BufferFactoryInfomation();


            data.FiscalYearId = model.FiscalYearId;
            data.FiscalMonthId = model.FiscalMonthId;
            data.BufferId = model.BufferId;
            data.DtInput = model.DtInput;
            data.Production = model.Production;
            data.SalesDAPFCL = model.SalesDAPFCL;
            data.OpeningBalance = model.OpeningBalance;
            data.DOBalance = model.DOBalance;
            data.YearlyAllotmentMOA = model.YearlyAllotmentMOA;
            data.ComId = comId;
            data.UserId = userid;
            data.DateAdded = DateTime.Today;
            data.UpdateByUserId = userid;
            data.DateUpdated = DateTime.Today;

            _context.BufferFactoryInfomations.Add(data);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var comid = (HttpContext.Session.GetString("comid"));

            ViewBag.Title = "Edit";
            if (id == null)
            {
                return NotFound();
            }

            var FactoryInfoInput = await _context.BufferFactoryInfomations
                    .Include(b => b.BufferList )
                    .Include(y => y.YearName)
                    .Include(m => m.MonthName)
                    .Where(b => b.bufferFactoryInfoId == id).FirstOrDefaultAsync();

            if (FactoryInfoInput == null)
            {
                return NotFound();
            }
            ViewData["BufferId"] = new SelectList(_context.Buffers.Where(x => x.BufferListId > 0 && x.ComId == comid), "BufferListId", "BufferName");
            ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.Where(x => x.comid == comid).OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", FactoryInfoInput.FiscalYearId);
            ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths, "FiscalMonthId", "MonthName", FactoryInfoInput.FiscalMonthId);

            return View(FactoryInfoInput);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BufferFactoryInfomation model)
        {
            var comid = (HttpContext.Session.GetString("comid"));

            if (ModelState.IsValid)
            {
                try
                {

                    var userid = (HttpContext.Session.GetString("userid"));

                    model.UpdateByUserId = userid;
                    model.DateUpdated = DateTime.Now;

                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BufferWiseBookingExists(model.bufferFactoryInfoId))
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
            return View(model);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var comid = (HttpContext.Session.GetString("comid"));
            ViewBag.Title = "Delete";
            if (id == null)
            {
                return NotFound();
            }
            var FactoryInfoInput = await _context.BufferFactoryInfomations
                    .Include(b => b.BufferList)
                    .Include(y => y.YearName)
                    .Include(m => m.MonthName)
                    .Where(b => b.bufferFactoryInfoId == id).FirstOrDefaultAsync();

            if (FactoryInfoInput == null)
            {
                return NotFound();
            }
            ViewData["BufferId"] = new SelectList(_context.Buffers.Where(x => x.BufferListId > 0 && x.ComId == comid), "BufferListId", "BufferName");
            ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.Where(x => x.comid == comid).OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", FactoryInfoInput.FiscalYearId);
            ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths, "FiscalMonthId", "MonthName", FactoryInfoInput.FiscalMonthId);

            return View(FactoryInfoInput);

        }

        // POST: Action/Delete/5
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var BufferFactoryInfos = await _context.BufferFactoryInfomations.FindAsync(id);
            _context.BufferFactoryInfomations.Remove(BufferFactoryInfos);
            await _context.SaveChangesAsync();

            return Json(new { Success = 1, FactoryInfoId = BufferFactoryInfos.bufferFactoryInfoId, ex = "" });

        }
        private bool BufferWiseBookingExists(int id)
        {
            return _context.BuffertWiseBookings.Any(e => e.BufferBookingId == id);
        }

    }
}
