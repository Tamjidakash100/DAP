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

    public class BankBranchController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;


        public BankBranchController(GTRDBContext context, TransactionLogRepository tran)
        {
            db = context;
            tranlog = tran;

        }

        // GET: BankBranch
        public async Task<IActionResult> Index()
        {

            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");


            return View(await db.Cat_BankBranch.ToListAsync());
        }

        // GET: BankBranch/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankbranch = await db.Cat_BankBranch
                .FirstOrDefaultAsync(m => m.BranchId == id);
            if (bankbranch == null)
            {
                return NotFound();
            }

            return View(bankbranch);
        }

        // GET: BankBranch/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            //ViewBag.BranchId = new SelectList(db.Cat_BankBranch, "BranchId", "BranchName");
            return View();
        }

        // POST: bankbranch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("BranchId,BranchName,bankbranchShortName")]*/ Cat_BankBranch bankbranch)
        {

            if (ModelState.IsValid)
            {
                bankbranch.UserId = HttpContext.Session.GetString("userid");
                bankbranch.ComId = HttpContext.Session.GetString("comid");
                if (bankbranch.BranchId > 0)
                {
                    db.Entry(bankbranch).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), bankbranch.BranchId.ToString(), "Update", bankbranch.BranchName.ToString());

                }
                else
                {
                    db.Add(bankbranch);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), bankbranch.BranchId.ToString(), "Create", bankbranch.BranchName.ToString());
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bankbranch);

        }

        // GET: BankBranch/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var bankbranch = await db.Cat_BankBranch.FindAsync(id);
            //ViewBag.BranchId = new SelectList(db.Cat_BankBranch, "BranchId", "BranchName", bankbranch.ParentId);
            if (bankbranch == null)
            {
                return NotFound();
            }
            return View("Create", bankbranch);

        }

        // GET: BankBranch/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankbranch = await db.Cat_BankBranch
                .FirstOrDefaultAsync(m => m.BranchId == id);

            if (bankbranch == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";
            //ViewBag.BranchId = new SelectList(db.Cat_BankBranch, "BranchId", "BranchName", bankbranch.ParentId);
            return View("Create", bankbranch);

        }

        // POST: bankbranch/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var bankbranch = await db.Cat_BankBranch.FindAsync(id);
                db.Cat_BankBranch.Remove(bankbranch);
                db.SaveChanges();
                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), bankbranch.BranchId.ToString(), "Delete", bankbranch.BranchName);
                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, BranchId = bankbranch.BranchId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        private bool BankBranchExists(int id)
        {
            return db.Cat_BankBranch.Any(e => e.BranchId == id);
        }
    }
}