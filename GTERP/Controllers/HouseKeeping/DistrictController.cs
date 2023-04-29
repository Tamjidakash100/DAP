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
    public class DistrictController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public DistrictController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: Cat_District
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            var data = await db.Cat_District.ToListAsync();
            return View(data);
        }

        // GET: Cat_District/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Cat_District = await db.Cat_District
                .FirstOrDefaultAsync(m => m.DistId == id);
            if (Cat_District == null)
            {
                return NotFound();
            }

            return View(Cat_District);
        }

        // GET: Cat_District/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            //ViewBag.CountryId = new SelectList(db.Cat_Country, "CountryId", "CountryName");
            ViewBag.DistId = new SelectList(db.Cat_District, "DistId", "DistName");
            return View();
        }

        // POST: Cat_District/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind(" DistId ,DistName,DistNameShort,aId ,wId , LUserId ,PCName")]*/ Cat_District Cat_District)
        {
            if (ModelState.IsValid)
            {
                Cat_District.UserId = HttpContext.Session.GetString("userid");
                //Cat_District.ComId = (int)HttpContext.Session.GetInt32("comid");
                if (Cat_District.DistId > 0)
                {
                    db.Entry(Cat_District).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_District.DistId.ToString(), "Update", Cat_District.DistName.ToString());

                }
                else
                {
                    db.Add(Cat_District);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_District.DistId.ToString(), "Create", Cat_District.DistName.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(Cat_District);
        }

        // GET: Cat_District/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            //Cat_Country  cat_Country  = db.Cat_Country.Where(m => m.BuyerId.ToString() == id.ToString()).FirstOrDefault(); //Find(id);// 
            var Cat_District = await db.Cat_District.FindAsync(id);
            ViewBag.DistId = new SelectList(db.Cat_District, "DistId", "DistName", Cat_District.DistId);
            if (Cat_District == null)
            {
                return NotFound();
            }
            //ViewBag.CountryId = new SelectList(db.Cat_Country, "CountryId", "CountryName", Cat_District.CountryId);
            return View("Create", Cat_District);
        }

        // POST: Cat_District/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DistId,ComId,DistName,DistNameB,DistNameShort,CountryName,CountryId,LuserId, Pcname")] Cat_District Cat_District)
        {
            if (id != Cat_District.DistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(Cat_District);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DistrictExists(Cat_District.DistId))
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
            return View(Cat_District);
        }

        // GET: Cat_District/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Cat_District = await db.Cat_District
                .FirstOrDefaultAsync(m => m.DistId == id);

            if (Cat_District == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";
            ViewBag.DistId = new SelectList(db.Cat_District, "DistId", "DistName", Cat_District.DistId);
            // ViewBag.CountryId = new SelectList(db.Cat_Country, "CountryId", "CountryName", Cat_District.CountryId);
            return View("Create", Cat_District);
        }

        // POST: Cat_District/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {


            try
            {
                var Cat_District = await db.Cat_District.FindAsync(id);
                db.Cat_District.Remove(Cat_District);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_District.DistId.ToString(), "Delete", Cat_District.DistName);

                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, DeptId = Cat_District.DistId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }

        }

        private bool DistrictExists(int id)
        {
            return db.Cat_District.Any(e => e.DistId == id);
        }
    }
}