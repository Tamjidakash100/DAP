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
    public class InsurGradeController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public InsurGradeController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: Cat_InsurGrade
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");


            var data = await db.Cat_InsurGrade.ToListAsync();
            return View(data);
        }

        // GET: Cat_InsurGrade/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Cat_InsurGrade = await db.Cat_InsurGrade
                .FirstOrDefaultAsync(m => m.InGId == id);
            if (Cat_InsurGrade == null)
            {
                return NotFound();
            }

            return View(Cat_InsurGrade);
        }

        // GET: Cat_InsurGrade/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            //ViewBag.CountryId = new SelectList(db.Cat_Country, "CountryId", "CountryName");
            ViewBag.InGId = new SelectList(db.Cat_InsurGrade, "InGId", "IncenBandName");
            return View();
        }

        // POST: Cat_InsurGrade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind(" DistId ,DistName,DistNameShort,aId ,wId , LUserId ,PCName")]*/ Cat_InsurGrade Cat_InsurGrade)
        {
            if (ModelState.IsValid)
            {
                Cat_InsurGrade.UserId = HttpContext.Session.GetString("userid");
                Cat_InsurGrade.ComId = HttpContext.Session.GetString("comid");
                if (Cat_InsurGrade.InGId > 0)
                {
                    Cat_InsurGrade.DateUpdated = DateTime.Now;
                    Cat_InsurGrade.UpdateByUserId = HttpContext.Session.GetString("userid");
                    db.Entry(Cat_InsurGrade).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_InsurGrade.InGId.ToString(), "Update", Cat_InsurGrade.InSurGrade.ToString());

                }
                else
                {
                    db.Add(Cat_InsurGrade);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_InsurGrade.InGId.ToString(), "Create", Cat_InsurGrade.InSurGrade.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(Cat_InsurGrade);
        }

        // GET: Cat_InsurGrade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            //Cat_Country  cat_Country  = db.Cat_Country.Where(m => m.BuyerId.ToString() == id.ToString()).FirstOrDefault(); //Find(id);// 
            var Cat_InsurGrade = await db.Cat_InsurGrade.FindAsync(id);
            ViewBag.InGId = new SelectList(db.Cat_InsurGrade, "InGId", "IncenBandName", Cat_InsurGrade.InGId);
            if (Cat_InsurGrade == null)
            {
                return NotFound();
            }

            return View("Create", Cat_InsurGrade);
        }

        // POST: Cat_InsurGrade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InGId,ComId,InsurGrade,Amount,Remarks,SLNO,IsInactive,UserId, Pcname")] Cat_InsurGrade Cat_InsurGrade)
        {
            if (id != Cat_InsurGrade.InGId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(Cat_InsurGrade);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncenBandtExists(Cat_InsurGrade.InGId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Cat_InsurGrade);
        }

        // GET: Cat_InsurGrade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Cat_InsurGrade = await db.Cat_InsurGrade
                .FirstOrDefaultAsync(m => m.InGId == id);

            if (Cat_InsurGrade == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";
            ViewBag.InGId = new SelectList(db.Cat_InsurGrade, "InGId", "InSurGrade", Cat_InsurGrade.InGId);
            return View("Create", Cat_InsurGrade);
        }

        // POST: Cat_InsurGrade/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {


            try
            {
                var Cat_InsurGrade = await db.Cat_InsurGrade.FindAsync(id);
                db.Cat_InsurGrade.Remove(Cat_InsurGrade);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_InsurGrade.InGId.ToString(), "Delete", Cat_InsurGrade.InSurGrade);

                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, InGId = Cat_InsurGrade.InGId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }

        }

        private bool IncenBandtExists(int id)
        {
            return db.Cat_InsurGrade.Any(e => e.InGId == id);
        }
    }
}
