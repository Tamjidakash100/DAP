using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.OpeningBalance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers.Sales.SalesOpeningBalance
{
    public class SaleOpeningBalanceController : Controller
    {
        private readonly GTRDBContext _context;
        private TransactionLogRepository tranlog;
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
        //public CommercialRepository Repository { get; set; }



        public SaleOpeningBalanceController(GTRDBContext context, TransactionLogRepository tran)
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
            var data = await _context.SalesOpeningBalances.Include(d => d.BufferList).Include(m => m.MonthName).Include(y => y.YearName).Where(x => x.ComId == ComId).ToListAsync();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            DateTime localDate = DateTime.Now;
            ViewBag.date = localDate;
            DateTime utcDate = DateTime.UtcNow;


            var comid = HttpContext.Session.GetString("comid");


            ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName");
            ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths, "FiscalMonthId", "MonthName");
            ViewBag.BufferId = new SelectList(_context.Buffers.Where(x => x.BufferListId > 0 && x.ComId == comid), "BufferListId", "BufferName");

            return View();
        }
        [HttpPost]
        public IActionResult Create(SalesOpening model)
        {
            ViewBag.Title = "Create";
            var comId = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");

            SalesOpening data = new SalesOpening();


            data.FiscalYearId = model.FiscalYearId;
            data.FiscalMonthId = model.FiscalMonthId;
            data.BufferID = model.BufferID;
            data.DtInput = DateTime.Today;
            data.ReciveByOpening = model.ReciveByOpening;
            data.SalesByOpening = model.SalesByOpening;
            data.BacklogOpening = model.BacklogOpening;
            data.ComId = comId;
            data.UserId = userid;
            data.DateAdded = DateTime.Today;
            data.UpdateByUserId = userid;
            data.DateUpdated = DateTime.Today;

            _context.SalesOpeningBalances.Add(data);
            _context.SaveChanges();



            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var comid = (HttpContext.Session.GetString("comid"));

            ViewBag.Title = "Edit";
            if (id == null)
            {
                return NotFound();
            }

            var SalesOpeningBalances = await _context.SalesOpeningBalances
                    .Include(y => y.YearName)
                    .Include(m => m.MonthName)
                    .Include(b => b.BufferList)
                    .Where(b => b.OpeningBalanceId == id).FirstOrDefaultAsync();

            if (SalesOpeningBalances == null)
            {
                return NotFound();
            }

            ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.Where(x => x.comid == comid).OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", SalesOpeningBalances.FiscalYearId);
            ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths, "FiscalMonthId", "MonthName", SalesOpeningBalances.FiscalMonthId);
            ViewBag.BufferId = new SelectList(_context.Buffers.Where(d => d.BufferListId == SalesOpeningBalances.BufferID), "BufferListId", "BufferName", SalesOpeningBalances.BufferID);


            return View(SalesOpeningBalances);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SalesOpening model)
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
                    throw;
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

            var SalesOpeningBalances = await _context.SalesOpeningBalances
                    .Include(y => y.YearName)
                    .Include(m => m.MonthName)
                    .Include(b => b.BufferList)
                    .Where(b => b.OpeningBalanceId == id).FirstOrDefaultAsync();

            if (SalesOpeningBalances == null)
            {
                return NotFound();
            }
            ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.Where(x => x.comid == comid).OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", SalesOpeningBalances.FiscalYearId);
            ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths, "FiscalMonthId", "MonthName", SalesOpeningBalances.FiscalMonthId);
            ViewBag.BufferId = new SelectList(_context.Buffers.Where(d => d.BufferListId == SalesOpeningBalances.BufferID), "BufferListId", "BufferName", SalesOpeningBalances.BufferID);


            return View(SalesOpeningBalances);
        }

        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(int id)
        {
            try
            {

                SalesOpening SalesOpeningBalances = _context.SalesOpeningBalances.Find(id);
                _context.SalesOpeningBalances.Remove(SalesOpeningBalances);
                _context.SaveChanges();
                return Json(new { Success = 1, OpeningBalanceId = SalesOpeningBalances.OpeningBalanceId, ex = "" });

            }

            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.Message.ToString() });
            }
        }

    }

}
