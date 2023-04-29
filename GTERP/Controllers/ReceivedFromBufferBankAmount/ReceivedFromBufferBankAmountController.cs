using GTERP.BLL;
using GTERP.Models;
using Microsoft.AspNetCore.Mvc;
using GTERP.Migrations.GTRDB;
using GTERP.Models.BufferSalesReportInput;
using GTERP.Models.ReceivedFromBufferBankAmountModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers.ReceivedFromBufferBankAmount
{
    public class ReceivedFromBufferBankAmountController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext _context;

        public ReceivedFromBufferBankAmountController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var ComId = HttpContext.Session.GetString("comid");
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            var data = _context.ReceivedFromBufferBankAmountsModels.Include(x=>x.BufferList).Include(y=>y.Acc_FiscalYear).Include(z=>z.Acc_FiscalMonth).Include(v=>v.Banks)
                .Where(x => x.comid == ComId).ToListAsync();
            return View(await data);
        }

        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            var comId = HttpContext.Session.GetString("comid");

            ViewBag.BufferListId = new SelectList(_context.Buffers, "BufferListId", "BufferName");
            ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName");
            ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths, "FiscalMonthId", "MonthName");
            ViewBag.BankId = new SelectList(_context.BanksModel, "BankId", "BankName");

            return View();
        }

        public JsonResult getBankName (int id)
        {
            if (id <= 0)
            {
                return Json(new { flag = "0", msg = "Invalid Buffer  Id." });
            }

            var BankName = _context.BanksModel.Where(x => x.BufferId == id).ToList();

            if (BankName.Count > 0 && BankName != null)
            {
                return Json(new { flag = "1", msg = "Bank Name found.", data = BankName });
            }
            else
            {
                return Json(new { flag = "0", msg = "Bank Name not found." });
            }
        }

        public JsonResult getFiscalMonthName(int id)
        {
            if (id <= 0)
            {
                return Json(new { flag = "0", msg = "Invalid Fiscal Year Id." });
            }

            var fiscalMonth = _context.Acc_FiscalMonths.Where(x => x.FYId == id).ToList();

            if (fiscalMonth.Count > 0 && fiscalMonth != null)
            {
                return Json(new { flag = "1", msg = "Fiscal Month found.", data = fiscalMonth });
            }
            else
            {
                return Json(new { flag = "0", msg = "Fiscal Month Not found." });
            }
        }

        [HttpPost]
        public IActionResult Create(ReceivedFromBufferBankAmountsModels receivedFromBufferBankAmountmodel)
        {
            ViewBag.Title = "Create";
            var comId = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");

            ReceivedFromBufferBankAmountsModels receivedFrom = new ReceivedFromBufferBankAmountsModels();

            receivedFrom.BufferId = receivedFromBufferBankAmountmodel.BufferId;
            receivedFrom.FiscalMonthId = receivedFromBufferBankAmountmodel.FiscalMonthId;
            receivedFrom.FiscalYearId = receivedFromBufferBankAmountmodel.FiscalYearId;
            receivedFrom.BankID = receivedFromBufferBankAmountmodel.BankID;
            receivedFrom.Amount = receivedFromBufferBankAmountmodel.Amount;
            receivedFrom.Note= receivedFromBufferBankAmountmodel.Note;
            receivedFrom.DtInput = receivedFromBufferBankAmountmodel.DtInput;
            receivedFrom.comid= comId;
            receivedFrom.userid = userid;
            receivedFrom.DateAdded = DateTime.Today;
            receivedFrom.IsDeleted = false;

            _context.ReceivedFromBufferBankAmountsModels.Add(receivedFrom);
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

            var ReceivedFromBuffer = await _context.ReceivedFromBufferBankAmountsModels
                    .Include(y => y.BufferList)
                    .Include(m => m.Acc_FiscalYear)
                    .Include(d => d.Acc_FiscalMonth)
                    .Include(x => x.Banks)
                    .Where(b => b.BankAmountId == id).FirstOrDefaultAsync();
            if (ReceivedFromBuffer == null)
            {
                return NotFound();
            }

            ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.Where(x => x.comid == comid).OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", ReceivedFromBuffer.FiscalYearId);
            ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths.Where(x => x.ComId == comid).OrderByDescending(y => y.MonthName), "FiscalMonthId", "MonthName", ReceivedFromBuffer.FiscalMonthId);
            ViewBag.BufferId = new SelectList(_context.Buffers.Where(d => d.BufferListId == ReceivedFromBuffer.BufferId), "BufferListId", "BufferName", ReceivedFromBuffer.BufferId);
            ViewBag.BankId = new SelectList(_context.BanksModel, "BankId", "BankName", ReceivedFromBuffer.BankID);


            ViewData["BufferId"] = new SelectList(_context.Buffers.Where(x => x.BufferListId > 0 && x.ComId == comid), "BufferListId", "BufferName", ReceivedFromBuffer.BufferId);


            return View(ReceivedFromBuffer);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReceivedFromBufferBankAmountsModels ReceivedFromBufferBankAmountsModel)
        {
            

            if (ModelState.IsValid)
            {
                try
                {
                    var comid = (HttpContext.Session.GetString("comid"));
                    var userid = (HttpContext.Session.GetString("userid"));


                    ReceivedFromBufferBankAmountsModel.userid = userid;
                    ReceivedFromBufferBankAmountsModel.comid= comid;
                    ReceivedFromBufferBankAmountsModel.DateUpdated = DateTime.Now;

                    _context.Update(ReceivedFromBufferBankAmountsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceivedFromBufferBankAmountExists(ReceivedFromBufferBankAmountsModel.BankAmountId))
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

            return View(ReceivedFromBufferBankAmountsModel);
        }

        private bool ReceivedFromBufferBankAmountExists(int id)
        {
            return _context.ReceivedFromBufferBankAmountsModels.Any(e => e.BankAmountId == id);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var comid = (HttpContext.Session.GetString("comid"));
            ViewBag.Title = "Delete";
            if (id == null)
            {
                return NotFound();
            }

            var ReceivedFromBuffer = await _context.ReceivedFromBufferBankAmountsModels
                    .Include(y => y.BufferList)
                    .Include(m => m.Acc_FiscalYear)
                    .Include(d => d.Acc_FiscalMonth)
                    .Include(x => x.Banks)
                    .Where(b => b.BankAmountId == id).FirstOrDefaultAsync();
            if (ReceivedFromBuffer == null)
            {
                return NotFound();
            }

            ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.Where(x => x.comid == comid).OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", ReceivedFromBuffer.FiscalYearId);
            ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths.Where(x => x.ComId == comid).OrderByDescending(y => y.MonthName), "FiscalMonthId", "MonthName", ReceivedFromBuffer.FiscalMonthId);
            ViewBag.BufferId = new SelectList(_context.Buffers.Where(d => d.BufferListId == ReceivedFromBuffer.BufferId), "BufferListId", "BufferName", ReceivedFromBuffer.BufferId);
            ViewBag.BankId = new SelectList(_context.BanksModel, "BankId", "BankName", ReceivedFromBuffer.BankID);


            ViewData["BufferId"] = new SelectList(_context.Buffers.Where(x => x.BufferListId > 0 && x.ComId == comid), "BufferListId", "BufferName", ReceivedFromBuffer.BufferId);


            return View(ReceivedFromBuffer);
        }


        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(int id)
        {
            try
            {

                ReceivedFromBufferBankAmountsModels receivedFromBufferBankAmountsModels = _context.ReceivedFromBufferBankAmountsModels.Find(id);
                _context.ReceivedFromBufferBankAmountsModels.Remove(receivedFromBufferBankAmountsModels);
                _context.SaveChanges();
                return Json(new { Success = 1, BankAmountID = receivedFromBufferBankAmountsModels.BankAmountId, ex = "" });

            }

            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.Message.ToString() });
            }
        }
    }
}
