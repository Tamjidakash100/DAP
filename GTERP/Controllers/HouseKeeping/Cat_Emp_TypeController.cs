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
    public class Cat_Emp_TypeController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public Cat_Emp_TypeController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: Grade
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");


            return View(await db.Cat_Emp_Type.ToListAsync());

        }

        // GET: Cat_Emp_Type/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Cat_Emp_Type = await db.Cat_Emp_Type
                .FirstOrDefaultAsync(m => m.EmpTypeId == id);
            if (Cat_Emp_Type == null)
            {
                return NotFound();
            }

            return View(Cat_Emp_Type);
        }

        // GET: Grade/Create
        public IActionResult Create()
        {

            ViewBag.Title = "Create";
            //ViewBag.DeptId = new SelectList(db.Cat_Department, "DeptId", "DeptName");
            return View();
        }

        // POST: Grade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpTypeId,EmpTypeName,EmpTypeNameB,TtlManpower,ComId")] Cat_Emp_Type Cat_Emp_Type)
        {


            if (ModelState.IsValid)
            {
                Cat_Emp_Type.UserId = HttpContext.Session.GetString("userid");
                Cat_Emp_Type.ComId = HttpContext.Session.GetString("comid");

                Cat_Emp_Type.DateUpdated = DateTime.Today;
                // Cat_Emp_Type.DtInput = DateTime.Today;
                Cat_Emp_Type.DateAdded = DateTime.Today;
                if (Cat_Emp_Type.EmpTypeId > 0)
                {
                    Cat_Emp_Type.UpdateByUserId = HttpContext.Session.GetString("userid");
                    db.Entry(Cat_Emp_Type).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Emp_Type.EmpTypeId.ToString(), "Update", Cat_Emp_Type.EmpTypeName.ToString());

                }
                else
                {
                    db.Add(Cat_Emp_Type);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Emp_Type.EmpTypeId.ToString(), "Create", Cat_Emp_Type.EmpTypeId.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(Cat_Emp_Type);
        }

        // GET: Grade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var Cat_Emp_Type = await db.Cat_Emp_Type.FindAsync(id);
            if (Cat_Emp_Type == null)
            {
                return NotFound();
            }
            return View("Create", Cat_Emp_Type);
        }


        // GET: Grade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Cat_Emp_Type = await db.Cat_Emp_Type
                .FirstOrDefaultAsync(m => m.EmpTypeId == id);
            if (Cat_Emp_Type == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Delete";
            return View("Create", Cat_Emp_Type);
        }

        // POST: Grade/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var Cat_Emp_Type = await db.Cat_Emp_Type.FindAsync(id);
                db.Cat_Emp_Type.Remove(Cat_Emp_Type);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Emp_Type.EmpTypeId.ToString(), "Delete", Cat_Emp_Type.EmpTypeName);

                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, EmpTypeId = Cat_Emp_Type.EmpTypeId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        private bool Cat_GradeExists(int id)
        {
            return db.Cat_Emp_Type.Any(e => e.EmpTypeId == id);
        }
    }
}
