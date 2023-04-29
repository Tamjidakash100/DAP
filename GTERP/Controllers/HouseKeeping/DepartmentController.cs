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
    //[OverridableAuthorize(typeof(OverridableAuthorize))]
    //[TypeFilter(typeof(OverridableAuthorize))] --- working for onoverrride 
    [OverridableAuthorize]
    public class DepartmentController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public DepartmentController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: Department
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            return View(await db.Cat_Department.ToListAsync());
        }

        // GET: Department/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await db.Cat_Department
                .FirstOrDefaultAsync(m => m.DeptId == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Department/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            //ViewBag.DeptId = new SelectList(db.Cat_Department, "DeptId", "DeptName");
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("DeptId,ComId,DeptCode,DeptName,Pcname,LuserId,DeptBangla,Slno,ParentId,Buid,Buname,DptSrtName,IsStrDpt")]*/ Cat_Department department)
        {
            if (ModelState.IsValid)
            {
                department.UserId = HttpContext.Session.GetString("userid");
                department.ComId = HttpContext.Session.GetString("comid");
                if (department.DeptId > 0)
                {
                    db.Entry(department).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), department.DeptId.ToString(), "Update", department.DeptName.ToString());

                }
                else
                {
                    db.Add(department);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), department.DeptId.ToString(), "Create", department.DeptName.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Department/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var department = await db.Cat_Department.FindAsync(id);
            //ViewBag.DeptId = new SelectList(db.Cat_Department, "DeptId", "DeptName", department.ParentId);
            if (department == null)
            {
                return NotFound();
            }
            return View("Create", department);
        }

        // GET: Department/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await db.Cat_Department
                .FirstOrDefaultAsync(m => m.DeptId == id);

            if (department == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";
            //ViewBag.DeptId = new SelectList(db.Cat_Department, "DeptId", "DeptName", department.ParentId);
            return View("Create", department);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var department = await db.Cat_Department.FindAsync(id);
                db.Cat_Department.Remove(department);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), department.DeptId.ToString(), "Delete", department.DeptName);

                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, DeptId = department.DeptId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }


        //public IActionResult IsExist(string DeptName,int DeptId)
        //{
        //    if (ViewBag.Title == "Create")
        //        return Json(!db.Cat_Department.Any(d => d.DeptName == DeptName));
        //    else
        //        return Json(!db.Cat_Department.Any(d => d.DeptName == DeptName));
        //}


        private bool DepartmentExists(int id)
        {
            return db.Cat_Department.Any(e => e.DeptId == id);
        }
    }
}