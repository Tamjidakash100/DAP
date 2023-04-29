using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.Common;
using GTERP.Models.FactoryDapInfo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using GTERP.Models.BufferSalesReportInput;
using Microsoft.AspNetCore.Components.Forms;

namespace GTERP.Controllers.FactoryInfo
{
    public class FactoryInfoController : Controller
    {
        private readonly GTRDBContext _context;
        private TransactionLogRepository tranlog;
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
        //public CommercialRepository Repository { get; set; }



        public FactoryInfoController(GTRDBContext context, TransactionLogRepository tran)
        {
            _context = context;
            tranlog = tran;
            //Repository = rep;
        }

        public async Task<IActionResult> Index()
        {
            var ComId = HttpContext.Session.GetString("comid");
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            //tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");
            var data = await _context.FactoryInfos.Where(x => x.ComId == ComId).OrderByDescending(o=>o.FactoryInfoId).ToListAsync();
            return View(data);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            DateTime localDate = DateTime.Now;
            ViewBag.date = localDate;
            var prevDate = localDate - TimeSpan.FromDays(1);
            DateTime utcDate = DateTime.UtcNow;

            ViewBag.Openbln = _context.FactoryInfos.FirstOrDefaultAsync(x => x.DtInput == prevDate);
            var comId = HttpContext.Session.GetString("comid");


            ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName");
            ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths, "FiscalMonthId", "MonthName");

            return View();
        }
        [HttpPost]
        public IActionResult Create(List<BufferSaleReportInput> model)
        {
            ViewBag.Title = "Create";
            var comId = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");




            DateTime today = DateTime.Now;



            int updateCount = 0;
            int AddCount = 0;

            foreach (var item in model)
            {
                //DateTime inpdate = DateTime.ParseExact(item.inputdate, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                var previousDate = item.DtInput - TimeSpan.FromDays(1);
                var Prevprice = _context.BufferSaleReportInputs.Where(p => p.DtInput == previousDate).Select(s => s.UnitPrice).FirstOrDefault();
                var monthId = _context.Acc_FiscalMonths
                .Where(m => item.DtInput >= m.OpeningdtFrom && item.DtInput <= m.ClosingdtTo)
                .Select(m => m.MonthId)
                .FirstOrDefault();
                var FyId = _context.Acc_FiscalMonths
               .Where(m => item.DtInput >= m.OpeningdtFrom && item.DtInput <= m.ClosingdtTo)
               .Select(m => m.FYId)
               .FirstOrDefault();

                if (item.BufferSalesReportInputId > 0 )
                {
                    //BufferSaleReportInput bjj = new BufferSaleReportInput();
                    //bjj.BufferID = item.BufferID;
                    //bjj.ReciveByBuffer = item.ReciveByBuffer;
                    //bjj.SalesByBuffer = item.SalesByBuffer;
                    //bjj.DtInput = item.inputdate;
                    item.ComId = comId;
                    item.UserId = userid;
                    item.UpdateByUserId = userid;
                    item.DateAdded = today;
                    item.FiscalYearId = FyId;
                    item.FiscalMonthId = monthId;



                    _context.Update(item);
                    updateCount++;
                }
                else
                {
                    //BufferSaleReportInput bjj = new BufferSaleReportInput();
                    //bjj.BufferID = item.BufferID;
                    //bjj.ReciveByBuffer = item.ReciveByBuffer;
                    //bjj.SalesByBuffer = item.SalesByBuffer;
                    //bjj.DtInput = item.inputdate;
                    if (item.UnitPrice == 0)
                    { item.UnitPrice = Prevprice==0?14000: Prevprice; }
                    
                    item.ComId = comId;
                    item.UserId = userid;
                    item.UpdateByUserId = userid;
                    item.DateAdded = today;
                    item.FiscalYearId = FyId;
                    item.FiscalMonthId = monthId;

                    _context.Add(item);
                    AddCount++;

                }
                _context.SaveChanges();
            }







            return Json(new { Success = "1", ex ="["+ updateCount + "]Updated And [" + AddCount +"]Added" });
        }
        [HttpGet]
        public IActionResult CreateMoa()
        {
            ViewBag.Title = "Create";
            DateTime localDate = DateTime.Now;
            ViewBag.date = localDate;
            DateTime utcDate = DateTime.UtcNow;


            var comId = HttpContext.Session.GetString("comid");


            ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName");
            ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths, "FiscalMonthId", "MonthName");

            return View();
        }

        public class Salesinput {
            public int BufferSalesReportInputId { get; set; }

            public int BufferID { get; set; }
            public string BufferName { get; set; }
            public float ReciveByBuffer { get; set; }
           
            public float SalesByBuffer { get; set; }
            public DateTime inputdate { get; set; }


        }

        [HttpPost]
        public async Task<IActionResult> Createfactory(FactoryInfomation item)
        {
            ViewBag.Title = "Create";
            var comId = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");

            DateTime today = DateTime.Now;

            //DateTime inpdate = DateTime.ParseExact(item.inputdate, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            //for(int i; i>8; i++)
            //var previousDate = item.DtInput - TimeSpan.FromDays(1);
            var previousDoBal= await (_context.FactoryInfos.OrderByDescending(o => o.FactoryInfoId).Select(s => s.DOBalance).FirstOrDefaultAsync());

            var monthId = _context.Acc_FiscalMonths
            .Where(m => item.DtInput >= m.OpeningdtFrom && item.DtInput <= m.ClosingdtTo)
            .Select(m => m.MonthId)
            .FirstOrDefault();
            var FyId = _context.Acc_FiscalMonths
           .Where(m => item.DtInput >= m.OpeningdtFrom && item.DtInput <= m.ClosingdtTo)
           .Select(m => m.FYId)
           .FirstOrDefault();
            var Exitance = await (_context.FactoryInfos.Where(p => p.DtInput == item.DtInput).FirstOrDefaultAsync());

            if (Exitance != null && item.DtInput.Date == today.Date)
            {
                var PrevDoBalUp = await (_context.FactoryInfos.OrderByDescending(o => o.FactoryInfoId).Select(s => s.DOBalance).Skip(1).FirstOrDefaultAsync());

                Exitance.Production = item.Production;
                Exitance.Deposit = item.Deposit;
                Exitance.SalesDAPFCL = item.SalesDAPFCL;
                Exitance.DOBalance = (float)(PrevDoBalUp + item.Deposit) - item.SalesDAPFCL;
                Exitance.UpdateByUserId = userid;



                _context.Update(Exitance);
                _context.SaveChanges();
                return Json(new { Success = "1", ex = "Succsfully Updated" });

            }
            else if (Exitance == null && item.DtInput.Date == today.Date)
            {
                var PrevDoBal = await (_context.FactoryInfos.OrderByDescending(o => o.FactoryInfoId).Select(s => s.DOBalance).FirstOrDefaultAsync());

                item.ComId = comId;
                item.UserId = userid;

                item.DateAdded = today;
                item.FiscalYearId = FyId;
                item.FiscalMonthId = monthId;
                item.DOBalance = (float)(PrevDoBal + item.Deposit) - item.SalesDAPFCL;
                if (item.OpeningBalance == 0)
                {
                    item.OpeningBalance = await (_context.FactoryInfos.Where(p => p.OpeningBalance != 0).OrderByDescending(o => o.FactoryInfoId).Select(a => a.OpeningBalance).FirstOrDefaultAsync());

                }

                _context.Add(item);
                _context.SaveChanges();
                return Json(new { Success = "2", ex = "Succesfully Added" });

            }
            else
            {
                return Json(new { Success = "3", ex = "You can't update or add data of previous date. U only can update or add today's data" });
            }
        }
            
        
 

        [HttpPost]
        public IActionResult CreateMoa(List<BufferAllotment_MOA> model)
        {
            ViewBag.Title = "Create";
            var comId = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");




            DateTime today = DateTime.Now;





            foreach (var item in model)
            {
                //DateTime inpdate = DateTime.ParseExact(item.inputdate, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                
                var monthId = _context.Acc_FiscalMonths
                .Where(m => today >= m.OpeningdtFrom && today <= m.ClosingdtTo)
                .Select(m => m.MonthId)
                .FirstOrDefault();
                var FyId = _context.Acc_FiscalMonths
               .Where(m => today >= m.OpeningdtFrom && today <= m.ClosingdtTo)
               .Select(m => m.FYId)
               .FirstOrDefault();

                if (item.MOA_ID > 0)
                {
                    //BufferSaleReportInput bjj = new BufferSaleReportInput();
                    //bjj.BufferID = item.BufferID;
                    //bjj.ReciveByBuffer = item.ReciveByBuffer;
                    //bjj.SalesByBuffer = item.SalesByBuffer;
                    //bjj.DtInput = item.inputdate;
                    item.ComId = comId;
                    item.UserId = userid;
                    item.UpdateByUserId = userid;
                    item.DateAdded = today;
                    
                    //item.FiscalYearId = FyId;
                    //item.FiscalMonthId = monthId;



                    _context.Update(item);

                }
                else
                {
                    //BufferSaleReportInput bjj = new BufferSaleReportInput();
                    //bjj.BufferID = item.BufferID;
                    //bjj.ReciveByBuffer = item.ReciveByBuffer;
                    //bjj.SalesByBuffer = item.SalesByBuffer;
                    //bjj.DtInput = item.inputdate;

                    item.ComId = comId;
                    item.UserId = userid;
                    item.UpdateByUserId = userid;
                    item.DateAdded = today;
                    //item.FiscalYearId = FyId;
                    //item.FiscalMonthId = monthId;
                    item.DtInput = today;
                    _context.Add(item);

                }
                _context.SaveChanges();
            }
           


           



            return Json(new { Success = "1", ex = "" });
        }



        public JsonResult getFiscalMonthName(int id)
        {
            if (id <= 0)
            {
                return Json(new { flag = "0", msg = "Invalid Fiscal Year Id." });
            }

            var fiscalMonth = _context.Acc_FiscalMonths.Where(x => x.FYId == id).ToList();

            if (fiscalMonth.Count > 0 && fiscalMonth != null)
            {
                return Json(new { flag = "1", msg = "Fiscal Month found.", data = fiscalMonth });
            }
            else
            {
                return Json(new { flag = "0", msg = "Fiscal Month Not found." });
            }
        }


        public class FactoryInfo {

            public int BufferSalesReportInputId { get; set; }
            public int BufferListId { get; set; }
            public int MOA_ID { get; set; }
            public float ReciveByBuffer { get; set; }
         
            public float SalesByBuffer { get; set; }
            public float AllotmentMOA { get; set; }
            public string BufferName { get; set; }

        }



        [HttpPost]
        public async Task<ActionResult> GetAllBuffer(string inpdate)
        {

            DateTime date = DateTime.Parse(inpdate);
            var factoryData =await (_context.FactoryInfos.FirstOrDefaultAsync(x => x.DtInput == date));

            var comid = HttpContext.Session.GetString("comid");

            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@inpdate", inpdate);



            List<FactoryInfo> Data =  Helper.ExecProcMapTList<FactoryInfo>("Getprosalesreport", parameters);

            return Json(new {data=Data, Factory=factoryData });
        }

        [HttpPost]
        public ActionResult GetAllMoa(int monthid)
        {


            var comid = HttpContext.Session.GetString("comid");



            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@monthid", monthid);

            List<FactoryInfo> Data = Helper.ExecProcMapTList<FactoryInfo>("GetAllotmentMoa", parameters);

            return Json(Data);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            var comid = (HttpContext.Session.GetString("comid"));

            ViewBag.Title = "Edit";
            if (id == null)
            {
                return NotFound();
            }

            var FactoryInfoInput = await _context.FactoryInfos
                    .Include(y => y.YearName)
                    .Include(m => m.MonthName)
                    .Where(b => b.FactoryInfoId == id).FirstOrDefaultAsync();

            if (FactoryInfoInput == null)
            {
                return NotFound();
            }

            ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.Where(x => x.comid == comid).OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", FactoryInfoInput.FiscalYearId);
            ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths, "FiscalMonthId", "MonthName", FactoryInfoInput.FiscalMonthId);

            return View(FactoryInfoInput);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FactoryInfomation model)
        {
            var comid = (HttpContext.Session.GetString("comid"));

            if (ModelState.IsValid)
            {
                try
                {

                    var userid = (HttpContext.Session.GetString("userid"));

                    model.UpdateByUserId = userid;
                    model.DateUpdated = DateTime.Now;

                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BufferWiseBookingExists(model.FactoryInfoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            };
            return View(model);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var comid = (HttpContext.Session.GetString("comid"));
            ViewBag.Title = "Delete";
            if (id == null)
            {
                return NotFound();
            }
            var FactoryInfoInput = await _context.FactoryInfos
                    .Include(y => y.YearName)
                    .Include(m => m.MonthName)
                    .Where(b => b.FactoryInfoId == id).FirstOrDefaultAsync();

            if (FactoryInfoInput == null)
            {
                return NotFound();
            }

            ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.Where(x => x.comid == comid).OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", FactoryInfoInput.FiscalYearId);
            ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths, "FiscalMonthId", "MonthName", FactoryInfoInput.FiscalMonthId);

            return View(FactoryInfoInput);

        }

        // POST: Action/Delete/5
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var BufferFactoryInfos= await _context.FactoryInfos.FindAsync(id);
            _context.FactoryInfos.Remove(BufferFactoryInfos);
            await _context.SaveChangesAsync();

            return Json(new { Success = 1, FactoryInfoId = BufferFactoryInfos.FactoryInfoId, ex = "" });
            
        }



        private bool BufferWiseBookingExists(int id)
        {
            return _context.BuffertWiseBookings.Any(e => e.BufferBookingId == id);
        }
    }
}