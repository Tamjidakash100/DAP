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

    public class SummerWinterAllowanceController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext _context;

        public SummerWinterAllowanceController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            _context = context;
        }

        // GET: SummerWinterAllowance
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cat_SummerWinterAllowanceSetting.ToListAsync());
        }

        // GET: SummerWinterAllowance/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Cat_SummerWinterAllowanceSetting = await _context.Cat_SummerWinterAllowanceSetting
                .FirstOrDefaultAsync(m => m.SWAllowanceId == id);
            if (Cat_SummerWinterAllowanceSetting == null)
            {
                return NotFound();
            }

            return View(Cat_SummerWinterAllowanceSetting);
        }

        // GET: SummerWinterAllowance/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            return View();
        }

        // POST: SummerWinterAllowance/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(Cat_SummerWinterAllowanceSetting swSetting)
        {
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");
            var today = DateTime.Now;



            if (swSetting.SWAllowanceId > 0)
            {
                var check = _context.Cat_SummerWinterAllowanceSetting.Where(s => s.ProssType == swSetting.ProssType && s.SWAllowanceId != swSetting.SWAllowanceId).FirstOrDefault();

                if (check != null)
                {
                    TempData["Message"] = "Sorry, have a setting of this Poss type ";
                    TempData["Status"] = "2";
                    ViewBag.Title = "Edit";
                    return View(swSetting);
                }
                swSetting.UpdateByUserId = userid;
                swSetting.DateUpdated = today;
                _context.Entry(swSetting).State = EntityState.Modified;
                _context.SaveChanges();
                TempData["Message"] = "Data Update Successfully";
                TempData["Status"] = "2";
            }
            else
            {
                var check = _context.Cat_SummerWinterAllowanceSetting.Where(s => s.ProssType == swSetting.ProssType).FirstOrDefault();

                if (check != null)
                {
                    TempData["Message"] = "Sorry, have a setting of this Poss type ";
                    TempData["Status"] = "2";
                    ViewBag.Title = "Create";
                    return View(swSetting);
                }

                swSetting.DateAdded = today;
                swSetting.ComId = comid;
                swSetting.UserId = userid;
                _context.Add(swSetting);
                _context.SaveChanges();
                TempData["Message"] = "Data Save Successfully";
                TempData["Status"] = "1";
            }


            return RedirectToAction(nameof(Index));
            //return View(Cat_SummerWinterAllowanceSetting);
        }

        // GET: SummerWinterAllowance/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Title = "Edit";
            if (id == null)
            {
                return NotFound();
            }

            var Cat_SummerWinterAllowanceSetting = await _context.Cat_SummerWinterAllowanceSetting.FindAsync(id);
            if (Cat_SummerWinterAllowanceSetting == null)
            {
                return NotFound();
            }
            return View("Create", Cat_SummerWinterAllowanceSetting);
        }

        // POST: SummerWinterAllowance/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cat_SummerWinterAllowanceSetting Cat_SummerWinterAllowanceSetting)
        {
            if (id != Cat_SummerWinterAllowanceSetting.SWAllowanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Cat_SummerWinterAllowanceSetting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Cat_SummerWinterAllowanceSettingExists(Cat_SummerWinterAllowanceSetting.SWAllowanceId))
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
            return View(Cat_SummerWinterAllowanceSetting);
        }

        // GET: SummerWinterAllowance/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.Title = "Delete";
            if (id == null)
            {
                return NotFound();
            }

            var Cat_SummerWinterAllowanceSetting = await _context.Cat_SummerWinterAllowanceSetting
                .FirstOrDefaultAsync(m => m.SWAllowanceId == id);
            if (Cat_SummerWinterAllowanceSetting == null)
            {
                return NotFound();
            }

            return View("Create", Cat_SummerWinterAllowanceSetting);
        }

        // POST: SummerWinterAllowance/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var swAllow = await _context.Cat_SummerWinterAllowanceSetting.FindAsync(id);
                _context.Cat_SummerWinterAllowanceSetting.Remove(swAllow);
                _context.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), swAllow.SWAllowanceId.ToString(), "Delete", swAllow.SWAllowanceId.ToString());

                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, DeptId = swAllow.SWAllowanceId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        private bool Cat_SummerWinterAllowanceSettingExists(int id)
        {
            return _context.Cat_SummerWinterAllowanceSetting.Any(e => e.SWAllowanceId == id);
        }
    }
}
