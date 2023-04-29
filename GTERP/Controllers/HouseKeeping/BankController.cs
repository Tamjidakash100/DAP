using GTERP.BLL;
using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers.HouseKeeping
{
    [OverridableAuthorize]

    public class BankController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public BankController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: bank
        public async Task<IActionResult> Index()
        {

            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            return View(await db.Cat_Bank.ToListAsync());
        }

        // GET: bank/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bank = await db.Cat_Bank
                .FirstOrDefaultAsync(m => m.BankId == id);
            if (bank == null)
            {
                return NotFound();
            }

            return View(bank);
        }

        // GET: bank/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            //ViewBag.BankId = new SelectList(db.Cat_Bank, "BankId", "bankName");
            return View();
        }

        // POST: bank/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("BankId,bankName,bankShortName")]*/ Cat_Bank bank)
        {

            if (ModelState.IsValid)
            {
                bank.UserId = HttpContext.Session.GetString("userid");
                bank.ComId = HttpContext.Session.GetString("comid");
                if (bank.BankId > 0)
                {
                    db.Entry(bank).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), bank.BankId.ToString(), "Update", bank.BankName.ToString());
                }
                else
                {
                    db.Add(bank);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), bank.BankId.ToString(), "Create", bank.BankName.ToString());
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bank);

        }

        // GET: bank/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var bank = await db.Cat_Bank.FindAsync(id);
            //ViewBag.BankId = new SelectList(db.Cat_Bank, "BankId", "bankName", bank.ParentId);
            if (bank == null)
            {
                return NotFound();
            }
            return View("Create", bank);

        }

        // GET: bank/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bank = await db.Cat_Bank
                .FirstOrDefaultAsync(m => m.BankId == id);

            if (bank == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";
            //ViewBag.BankId = new SelectList(db.Cat_Bank, "BankId", "bankName", bank.ParentId);
            return View("Create", bank);

        }

        // POST: bank/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var bank = await db.Cat_Bank.FindAsync(id);
                db.Cat_Bank.Remove(bank);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), bank.BankId.ToString(), "Delete", bank.BankName);

                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, BankId = bank.BankId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        private bool BankExists(int id)
        {
            return db.Cat_Bank.Any(e => e.BankId == id);
        }
    }
}
