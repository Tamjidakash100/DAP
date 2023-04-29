using GTERP.BLL;
using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers.HouseKeeping
{
    [OverridableAuthorize]
    public class ITaxBankController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public ITaxBankController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: Section
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            //var sectio
            return View(await db.Cat_ITaxBank.Include(s => s.Cat_Bank).Include(s => s.Cat_BankBranch).ToListAsync());
        }



        // GET: Section/Create
        public IActionResult Create()
        {

            ViewBag.Title = "Create";
            ViewBag.BankId = new SelectList(db.Cat_Bank, "BankId", "BankName");
            ViewBag.BranchId = new SelectList(db.Cat_BankBranch, "BranchId", "BranchName");
            return View();
        }

        // POST: Section/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cat_ITaxBank cat_iTaxBank)
        {
            if (ModelState.IsValid)
            {
                cat_iTaxBank.UserId = HttpContext.Session.GetString("userid");
                cat_iTaxBank.ComId = HttpContext.Session.GetString("comid");

                cat_iTaxBank.DateUpdated = DateTime.Today;
                cat_iTaxBank.DateAdded = DateTime.Today;

                if (cat_iTaxBank.Id > 0)
                {
                    cat_iTaxBank.UpdateByUserId = HttpContext.Session.GetString("userid");
                    db.Entry(cat_iTaxBank).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_iTaxBank.Id.ToString(), "Update", cat_iTaxBank.Id.ToString());

                }
                else
                {
                    db.Add(cat_iTaxBank);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_iTaxBank.Id.ToString(), "Create", cat_iTaxBank.Id.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(cat_iTaxBank);
        }

        // GET: Section/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var cat_iTaxBank = await db.Cat_ITaxBank.FindAsync(id);
            ViewBag.BankId = new SelectList(db.Cat_Bank, "BankId", "BankName", cat_iTaxBank.BankId);
            ViewBag.BranchId = new SelectList(db.Cat_BankBranch, "BranchId", "BranchName", cat_iTaxBank.BranchId);
            if (cat_iTaxBank == null)
            {
                return NotFound();
            }
            return View("Create", cat_iTaxBank);
        }


        // GET: Section/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat_iTaxBank = await db.Cat_ITaxBank
                  .Include(c => c.Cat_Bank)
                  .Include(c => c.Cat_BankBranch)
               .FirstOrDefaultAsync(m => m.Id == id);
            if (cat_iTaxBank == null)
            {
                return NotFound();
            }


            ViewBag.Title = "Delete";
            ViewBag.BankId = new SelectList(db.Cat_Bank, "BankId", "BankName", cat_iTaxBank.BankId);
            ViewBag.BranchId = new SelectList(db.Cat_BankBranch, "BranchId", "BranchName", cat_iTaxBank.BranchId);
            return View("Create", cat_iTaxBank);
        }

        // POST: Section/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var cat_iTaxBank = await db.Cat_ITaxBank.FindAsync(id);
                db.Cat_ITaxBank.Remove(cat_iTaxBank);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_iTaxBank.Id.ToString(), "Delete", cat_iTaxBank.Id.ToString());
                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, SectId = cat_iTaxBank.Id, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        private bool cat_iTaxBankExists(int id)
        {
            return db.Cat_ITaxBank.Any(e => e.Id == id);
        }
    }
}
