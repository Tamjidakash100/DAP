using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;


namespace GTERP.Controllers.HR
{
    [OverridableAuthorize]

    public class SummerWinterAllowController : Controller
    {
        public GTRDBContext db;
        public SummerWinterAllowController(GTRDBContext context)
        {
            db = context;
        }
        public class Pross
        {
            public string ProssType { get; set; }
            public DateTime dtInput { get; set; }
        }

        public IActionResult Index(int? SWAId)
        {
            string comid = HttpContext.Session.GetString("comid");

            //SqlParameter[] parameter1 = new SqlParameter[1];
            //parameter1[0] = new SqlParameter("@ComId", comid);
            //var prossType = Helper.ExecProcMapTList<Pross>("GetProssType", parameter1);
            //ViewBag.ProssType = new SelectList(prossType, "ProssType", "ProssType");

            ViewBag.ProssType = new SelectList(db.Cat_SummerWinterAllowanceSetting, "SWAllowanceId", "ProssType");

            if (SWAId != null)
            {
                //string comid = HttpContext.Session.GetString("comid");
                SqlParameter[] parameter = new SqlParameter[2];
                parameter[0] = new SqlParameter("@ComId", comid);
                parameter[1] = new SqlParameter("@SWAId", SWAId);
                var allowances = Helper.ExecProcMapTList<SummerWinterAllowViewModel>("HR_prcGetSummerWinterAllow", parameter);
                ViewBag.Recreation = allowances;
                ViewBag.SWAId = SWAId;
                return View();
            }
            ViewBag.Recreation = null;
            return View();
        }

        //public IActionResult GetData(DateTime date)
        //{

        //    return Json(allowances);
        //}

        public class SummerWinterAllowViewModel
        {
            public int EmpId { get; set; }
            public string EmpCode { get; set; }
            public string EmpName { get; set; }
            public string EmpType { get; set; }
            public string DeptName { get; set; }
            public string SectName { get; set; }
            public string DesigName { get; set; }
            public int BS { get; set; }
            public DateTime DtInput { get; set; }
            public bool IsSummer { get; set; }
            public bool IsWinter { get; set; }
            public bool IsRainCoat { get; set; }
        }

        public IActionResult Create(List<HR_SummerWinterAllowance> summerWinterAllows)
        {
            try
            {
                var swId = summerWinterAllows.FirstOrDefault().SWAllowanceId;
                var setting = db.Cat_SummerWinterAllowanceSetting.Where(s => s.SWAllowanceId == swId).FirstOrDefault();
                if (setting != null)
                {
                    foreach (var item in summerWinterAllows)
                    {
                        item.Stamp = 10; // default 10 tk
                        var exist = db.HR_SummerWinterAllowance
                            .Where(s => s.SWAllowanceId == item.SWAllowanceId && s.EmpId == item.EmpId).FirstOrDefault();
                        if (exist != null)
                        {
                            db.HR_SummerWinterAllowance.Remove(exist);
                        }

                        if (item.IsRaincoat || item.IsSummer || item.IsWinter)
                        {
                            db.Add(AllowCalculation(item, setting));
                        }
                    }
                    db.SaveChanges();
                    TempData["Message"] = "Summer Winter allowance Save/Update Successfully";
                    return Json(new { Success = 1, ex = TempData["Message"].ToString() });
                }
                else
                {
                    TempData["Message"] = "Settinge not found the Month";
                    return Json(new { Success = 2, ex = TempData["Message"].ToString() });
                }

            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return Json(new { Success = 3, ex = TempData["Message"].ToString() });
            }

        }

        HR_SummerWinterAllowance AllowCalculation(HR_SummerWinterAllowance item, Cat_SummerWinterAllowanceSetting setting)
        {
            if (item.IsSummer)
            {
                item.SummerAllow = setting.SummerAllow;
            }
            if (item.IsWinter)
            {
                item.WinterAllow = setting.WinterAllow;
            }
            if (item.IsRaincoat)
            {
                item.RainCoatAndGumbootAllow = setting.RainCoatAndGumbootAllow;
            }

            item.Amount = item.SummerAllow + item.WinterAllow + item.RainCoatAndGumbootAllow;
            item.VatDed = (setting.VatDiduction / 100) * item.Amount;
            item.TaxDed = (setting.TaxDiduction / 100) * item.Amount;

            var ttlPercent = setting.VatDiduction + setting.TaxDiduction;

            item.NetAmount = item.Amount - (item.VatDed + item.TaxDed + item.Stamp);

            return item;
        }


    }
}
