using GTERP.BLL;
using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GTERP.Models.ReceivedFromBufferBankAmountModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace GTERP.Controllers.ReceivedFromBufferBankAmount
{
    public class BanksController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext _context;

        public BanksController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var ComId = HttpContext.Session.GetString("comid");
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            var data = _context.BanksModel.Select(b => b).Include(b=>b.BufferList).Where(x => x.comid == ComId).ToListAsync();
            return View(await data);
        }

        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            var comId = HttpContext.Session.GetString("comid");

            ViewBag.BufferListId = new SelectList(_context.Buffers, "BufferListId", "BufferName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(BanksModel banksmodel)
        {
            ViewBag.Title = "Create";
            var comId = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");

            BanksModel banks = new BanksModel();

            
            banks.BankName = banksmodel.BankName;
            banks.BankAccountNumber = banksmodel.BankAccountNumber;
            banks.BranchName = banksmodel.BranchName;
            banks.comid= comId;
            banks.userid=userid;
            banks.BufferId = banksmodel.BufferId;
            banks.DateAdded = DateTime.Today;
            banks.IsDeleted= false;

            _context.BanksModel.Add(banks);
            _context.SaveChanges();



            return RedirectToAction("index");
        }

        public async Task<IActionResult>  Edit(int? Id)
        {
            ViewBag.Title = "Edit";
            var comId = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var ReceivedFromBank = await _context.BanksModel
                    .Include(y => y.BufferList)
                    .Where(b => b.BankId == Id).FirstOrDefaultAsync();

            //var BankFromDB = _context.BanksModel.FirstOrDefault(c => c.BankId == Id);

            ViewBag.BufferId = new SelectList(_context.Buffers.Where(d => d.BufferListId == ReceivedFromBank.BufferId), "BufferListId", "BufferName", ReceivedFromBank.BufferId);
            //ViewBag.BankId = new SelectList(_context.BanksModel, "BankId", "BankName", ReceivedFromBank.BankId);

            if (ReceivedFromBank == null)
            {
                return NotFound();
            }

            return View(ReceivedFromBank);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BanksModel banksModel)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    var comid = (HttpContext.Session.GetString("comid"));
                    var userid = (HttpContext.Session.GetString("userid"));


                    banksModel.userid = userid;
                    banksModel.comid = comid;
                    banksModel.DateAdded = banksModel.DateAdded;
                    banksModel.DateUpdated = DateTime.Now;

                    _context.Update(banksModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankModelExists(banksModel.BankId))
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

            return View(banksModel);
        }

        private bool BankModelExists(int id)
        {
            return _context.BanksModel.Any(e => e.BankId == id);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var comid = (HttpContext.Session.GetString("comid"));
            ViewBag.Title = "Delete";
            if (id == null)
            {
                return NotFound();
            }

            var DeleteFromBank = await _context.BanksModel
                    .Include(y => y.BufferList)
                    .Where(b => b.BankId == id).FirstOrDefaultAsync();


            ViewBag.BufferId = new SelectList(_context.Buffers.Where(d => d.BufferListId == DeleteFromBank.BufferId), "BufferListId", "BufferName", DeleteFromBank.BufferId);

            if (DeleteFromBank == null)
            {
                return NotFound();
            }

            return View(DeleteFromBank);
        }

        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(int id)
        {
            try
            {

                BanksModel banksModel = _context.BanksModel.Find(id);
                _context.BanksModel.Remove(banksModel);
                _context.SaveChanges();
                return Json(new { Success = 1, BankId = banksModel.BankId, ex = "" });

            }

            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.Message.ToString() });
            }
        }
    }
}
