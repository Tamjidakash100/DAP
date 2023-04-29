using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;

namespace GTERP.Controllers.Account
{
    [OverridableAuthorize]
    public class Acc_FiscalYearController : Controller
    {
        private TransactionLogRepository tranlog;

        //private GTRDBContext db = new GTRDBContext();
        private GTRDBContext db;
        public Acc_FiscalYearController(GTRDBContext _db, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = _db;
        }

        //[Authorize]
        // GET: Acc_FiscalYear

        public ActionResult Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            string comid = HttpContext.Session.GetString("comid");

            //if (Session["Empname"] == null)
            //{
            //    return RedirectToRoute("GTR");
            //}
            //var list = db.Acc_FiscalYears.Where(x => x.comid == comid);
            //return View(list.ToList());

            return View(db.Acc_FiscalYears.Where(c => c.comid == comid).OrderByDescending(x => x.FiscalYearId).ToList());
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Acc_FiscalYear fiscalYear)
        {
            string comid = HttpContext.Session.GetString("comid");

            //var errors = ModelState.Where(x => x.Value.Errors.Any())
            //.Select(x => new { x.Key, x.Value.Errors });

            SqlParameter[] sqlParameter = new SqlParameter[1];
            sqlParameter[0] = new SqlParameter("@comid", comid);
            Helper.ExecProc("Acc_prcCloseFiscalYear", sqlParameter);

            //db.Database.ExecuteSqlCommand("Exec prcCloseFiscalYear @comid", new SqlParameter("@comid", comid));
            TempData["Message"] = "Year Close Successfully.";

            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), fiscalYear.FYName, "Acc_prcCloseFiscalYear", fiscalYear.FYName);


            return View(db.Acc_FiscalYears.Where(c => c.comid == comid).OrderByDescending(x => x.FiscalYearId).ToList());



        }


        // GET: Acc_FiscalYear/Edit/5

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
