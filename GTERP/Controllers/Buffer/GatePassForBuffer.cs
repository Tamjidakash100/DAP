using DataTablesParser;
using DocumentFormat.OpenXml.Office2010.Excel;
using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.Buffers;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers.Buffer
{
    public class GatePassForBuffer : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext _context;
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
        public clsProcedure clsProc { get; }
        public GatePassForBuffer(GTRDBContext context, TransactionLogRepository tran)
        {
            _context = context;
            tranlog = tran;

        }
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            string comid = HttpContext.Session.GetString("comid");
            var data = await _context.BufferGatePass.Where(x => x.ComId == comid).Include(y => y.BufferGatePassSub).ToListAsync();

            foreach (var x in data) {
                var ChalanNo =await _context.BufferGatePassSub.Where(w => w.BufferGatePassId == x.BufferGatePassId).Include(y => y.BufferDelChallan).Select(s=>s.BufferDelChallan.ChallanNo).ToListAsync();
                var array = new List<string>();
                x.BufferDelChallanNo = string.Join(",", ChalanNo);
            }

            return View(data);

        }

        public ActionResult Print(int? id)
        {
            string SqlCmd = "";
            string ReportPath = "";
            var ConstrName = "ApplicationServices";
            var ReportType = "PDF";
            var comid = HttpContext.Session.GetString("comid");

            var reportname = "rptBufferTruckGatePassReportID";
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/BufferReport/" + reportname + ".rdlc");
            HttpContext.Session.SetString("reportquery", "Exec [Buffer_rptTruckGatePassReportID] '" + comid + "','" + id + "','','','idwise'");

            string filename = _context.BufferGatePass.Where(x => x.BufferGatePassId == id).Single().GatePassNo.ToString();
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

            string DataSourceName = "DataSet1";
            HttpContext.Session.SetObject("rptList", postData);

            clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
            clsReport.strQueryMain = HttpContext.Session.GetString("reportquery");
            clsReport.strDSNMain = DataSourceName;


            SqlCmd = clsReport.strQueryMain;
            ReportPath = clsReport.strReportPathMain;
            ReportType = "PDF";

            //string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); // this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //Repository.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);
            string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType });
            return Redirect(callBackUrl);

        }


        public class ReportTalli {
            public string ReportFormat { get; set; }
            public string Report { get; set; }
            public string FromDate { get; set; }
            public string ToDate { get; set; }
           



        }



        [HttpPost, ActionName("BufferTali")]
        public JsonResult BufferTali(ReportTalli reportTalli)
        {
            try
            {
                string comid = HttpContext.Session.GetString("comid");

                var reportname = "";
                var filename = "";
                string redirectUrl = "";

                reportname = "rptCommercialDivisionMarketingBranch";
                filename = "rptTruckJugeSharSorboraherTaliSheet_List_" + DateTime.Now.Date.ToString();
                var query = "Exec [Buffer_rptTaliSheetDapAllReport] '" + comid + "','','" + reportTalli.FromDate + "','" + reportTalli.ToDate + "','talli'";
               

                HttpContext.Session.SetString("reportquery", "Exec [Buffer_rptTruckGatePassReportID] '" + comid + "','','" + reportTalli.FromDate + "','" + reportTalli.ToDate + "','talli'");
                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/BufferReport/" + reportname + ".rdlc");
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";

                
                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = reportTalli.ReportFormat });
                redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });

            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
            return Json(new { Success = 0, ex = new Exception("Unable to Open").Message.ToString() });
            //return RedirectToAction("Index");
        }




        public ActionResult PrintTali(ReportTalli reportTalli)
        {
            string SqlCmd = "";
            string ReportPath = "";
            var ConstrName = "ApplicationServices";
            var ReportType = "PDF";
            var comid = HttpContext.Session.GetString("comid");

            var reportname = "rptCommercialDivisionMarketingBranch";
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/BufferReport/" + reportname + ".rdlc");
            HttpContext.Session.SetString("reportquery", "Exec [Buffer_rptTaliSheetDapAllReport] '" + comid + "','','','"+reportTalli.FromDate+"','"+reportTalli.ToDate+ "','','','','',''");

       
            HttpContext.Session.SetString("PrintFileName", reportname+" "+ reportTalli.FromDate);

            string DataSourceName = "DataSet1";
            HttpContext.Session.SetObject("rptList", postData);

            clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
            clsReport.strQueryMain = HttpContext.Session.GetString("reportquery");
            clsReport.strDSNMain = DataSourceName;


            SqlCmd = clsReport.strQueryMain;
            ReportPath = clsReport.strReportPathMain;
            ReportType = "PDF";

            //string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); // this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //Repository.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);
            string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType });
            return Redirect(callBackUrl);

        }
        public static List<SelectListItem> CarrierType = new List<SelectListItem>()
        {
        new SelectListItem() {Text="BRTC", Value="brtc"},
        new SelectListItem() { Text="Others", Value="others"}
        };

        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            var comid = HttpContext.Session.GetString("comid");

            var lastbookingdata = _context.BufferGatePass.Take(1).Where(x => x.ComId == comid).OrderByDescending(x => x.BufferGatePassId).FirstOrDefault();
            if (lastbookingdata != null)
            {

                ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", lastbookingdata.FiscalYearId);
                ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths.OrderByDescending(y => y.MonthName), "FiscalMonthId", "MonthName", lastbookingdata.FiscalMonthId);

            }
            else {   ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName");
            ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths.OrderByDescending(y => y.MonthName), "FiscalMonthId", "MonthName");}

            ViewBag.lastGatePassNo = _context.BufferGatePass.Where(w => w.ComId == comid).OrderByDescending(o => o.GatePassNo).Select(s => s.GatePassNo).FirstOrDefault() + 1;

          

            ViewBag.BufferListId = new SelectList(_context.Buffers.Where(x => x.ComId == comid), "BufferListId", "BufferName");
            ViewBag.BufferRepresentativeId = new SelectList(CarrierType.OrderByDescending(x => x.Text), "Value", "Text"); /*new SelectList(_context.BuferRepresentative, "BufferRepresentativeId", "RepresentativeName");*/

            return View(lastbookingdata);


        }
        public class ChalanObj {
        
            public int chalan { get; set; }
            public float Qty { get; set; }
        
        }

        [HttpPost]
        public IActionResult Create(BufferGatePass booking)
        {
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");
            if (booking.BufferGatePassId > 0)
            {
                var exist = _context.BufferGatePass.Include(i => i.BufferGatePassSub).Where(w => w.BufferGatePassId == booking.BufferGatePassId && w.ComId == comid).FirstOrDefault();
                if (exist != null)
                {
                    foreach (var i in exist.BufferGatePassSub)
                    {
                        _context.BufferGatePassSub.Remove(i);
                        var del_cha = _context.BufferDelChallan.Where(w => w.BufferDelChallanId == i.BufferDelChallanId && w.ComId == comid).FirstOrDefault();

                        del_cha.IsDelivered = false;
                        _context.BufferDelChallan.Update(del_cha);
                        
                    }
                    _context.SaveChanges();

                    var del_cha_id = JsonConvert.DeserializeObject<List<ChalanObj>>(booking.BufferDelChallanId);

                   
                    foreach (var item in del_cha_id)
                    {
                        var delChaId= (item.chalan);
                        var GatePassQty= (item.Qty);
                       

                        if (delChaId > 0)
                        {
                            var totalChalanQty= _context.BufferDelChallan.Where(w => w.BufferDelChallanId == delChaId && w.ComId == comid).Select(s => s.DeliveryQty).FirstOrDefault();
                            var totalGatePassQty= _context.BufferGatePassSub.Where(w => w.BufferDelChallanId == delChaId).Sum(s => s.TruckLoadQty);

                            BufferGatePassSub gts = new BufferGatePassSub();
                            gts.BufferDelChallanId= delChaId;
                            gts.BufferGatePassId = exist.BufferGatePassId;
                            gts.TruckLoadQty = GatePassQty;
                            gts.BalanceQty = totalChalanQty - (totalGatePassQty+ GatePassQty);
                            _context.BufferGatePassSub.Add(gts);

                            if (gts.BalanceQty == 0)
                            {
                                var existChalan = _context.BufferDelChallan.Where(w => w.BufferDelChallanId == delChaId && w.ComId == comid).FirstOrDefault();
                                existChalan.IsDelivered = true;
                                _context.BufferDelChallan.Update(existChalan);

                            }
                        }
                        //var del_cha = _context.BufferDelChallan.Where(w => w.BufferDelChallanId == delChaId && w.ComId == comid).FirstOrDefault();

                        //del_cha.IsDelivered = true;
                        //_context.BufferDelChallan.Update(del_cha);
                    }
                    
                    exist.TotalQty = booking.TotalQty;
                    exist.GatePassDate = booking.GatePassDate;
                    exist.DateUpdated = DateTime.Now;
                    exist.UpdateByUserId = userid;
                    _context.BufferGatePass.Update(exist);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "Something wrong";
                    return View("Create", TempData["Message"]);
                }

            }
            else
            {
                try
                {
                    booking.ComId = comid;
                    booking.UserId = userid;
                    booking.DateAdded= DateTime.Now;
                 


                    _context.Add(booking);
                    _context.SaveChanges();


                    //var del_cha_id = booking.BufferDelChallanId;
                    //var del_cha_idArray = del_cha_id.Split(',');

                    var del_cha_id = JsonConvert.DeserializeObject<List<ChalanObj>>(booking.BufferDelChallanId);

                    var exist = _context.BufferGatePass.Where(w => w.DateAdded == booking.DateAdded && w.ComId == comid).FirstOrDefault();
                    foreach (var item in del_cha_id)
                    {
                        var delChaId= (item.chalan);
                        var GatePassQty= (item.Qty);
                       

                        if (delChaId > 0)
                        {
                            var totalChalanQty= _context.BufferDelChallan.Where(w => w.BufferDelChallanId == delChaId && w.ComId == comid).Select(s => s.DeliveryQty).FirstOrDefault();
                            var totalGatePassQty= _context.BufferGatePassSub.Where(w => w.BufferDelChallanId == delChaId).Sum(s => s.TruckLoadQty);

                            BufferGatePassSub gts = new BufferGatePassSub();
                            gts.BufferDelChallanId= delChaId;
                            gts.BufferGatePassId = exist.BufferGatePassId;
                            gts.TruckLoadQty = GatePassQty;
                            gts.BalanceQty = totalChalanQty - (totalGatePassQty+ GatePassQty);
                            _context.BufferGatePassSub.Add(gts);

                            if (gts.BalanceQty == 0)
                            {
                                var existChalan = _context.BufferDelChallan.Where(w => w.BufferDelChallanId == delChaId && w.ComId == comid).FirstOrDefault();
                                existChalan.IsDelivered = true;
                                _context.BufferDelChallan.Update(existChalan);

                            }
                        }
                        //var del_cha = _context.BufferDelChallan.Where(w => w.BufferDelChallanId == delChaId && w.ComId == comid).FirstOrDefault();

                        //del_cha.IsDelivered = true;
                        //_context.BufferDelChallan.Update(del_cha);
                    }
                    _context.SaveChanges();


                    return RedirectToAction("Index");
                }
                catch
                {
                    return View("Create");
                }
            }
        }

        

        public IActionResult Edit(int Id)
        {
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");

            if (Id > 0)
            {

                var exist = _context.BufferGatePass.Include(i=>i.BufferGatePassSub).ThenInclude(i=>i.BufferDelChallan).Where(w => w.BufferGatePassId == Id && w.ComId==comid).FirstOrDefault();
                if (exist != null)
                {
                    var ChalanArray = new List<int>();
                    foreach (var x in exist.BufferGatePassSub)
                    {
                        ChalanArray.Add(x.BufferDelChallan.ChallanNo);
                                               
                    }

                    exist.BufferDelChallanNo= string.Join(",", ChalanArray);
                    ViewBag.Title = "Edit";

                    ViewBag.FiscalYearId = new SelectList(_context.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", exist.FiscalYearId);
                    ViewBag.FiscalMonthId = new SelectList(_context.Acc_FiscalMonths.Where(x => x.FYId == exist.FiscalYearId), "FiscalMonthId", "MonthName", exist.FiscalMonthId);
                    //ViewBag.BufferListId = new SelectList(_context.Buffers.Where(x => x.ComId == comid), "BufferListId", "BufferName", exist.BufferListId);
              ViewBag.BufferRepresentativeId = new SelectList(CarrierType.OrderByDescending(x => x.Text), "Value", "Text"); //new SelectList(_context.BuferRepresentative, "BufferRepresentativeId", "RepresentativeName");

                    return View("Create", exist);
                }
                else
                {
                    return Json("Unable to edit");
                }



            }
            else { return Json("no id found"); }

        }


        public IActionResult Delete(int Id)
        {
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");
            if (Id > 0)
            {
                var exist = _context.BufferGatePass.Include(i => i.BufferGatePassSub).Where(w => w.BufferGatePassId == Id && w.ComId == comid).FirstOrDefault();
                if (exist != null)
                {
                    foreach (var i in exist.BufferGatePassSub)
                    {
                        _context.BufferGatePassSub.Remove(i);
                        var del_cha = _context.BufferDelChallan.Where(w => w.BufferDelChallanId == i.BufferDelChallanId && w.ComId == comid).FirstOrDefault();

                        del_cha.IsDelivered = false;
                        _context.BufferDelChallan.Update(del_cha);
                    }

                    _context.BufferGatePass.Remove(exist);
                    _context.SaveChanges();


                    return Json(new { flag = '1', Msg = "Successfully Deleted" });
                }
                else
                {
                    return Json(new { flag = '2', Msg = "Unable to delete" });

                }



            }
            else 
            {
                return Json(new { flag = '2', Msg = "No id Found" });
            }

        }


        [HttpPost]
        public JsonResult AllotmentInfo(string type,string page, int yearid, int monthid)
        {
            var comid = HttpContext.Session.GetString("comid");
            try
            {

                if (page == "Edit")
                {
                    if (type == "brtc")
                    {
                        var query = (from e in _context.BufferDelChallan.Include(i => i.RepresentativeBooking).Include(i => i.RepresentativeBooking.BufferRepresentative).Include(i => i.RepresentativeBooking.BufferList).Include(i => i.BufferGatePassChallans)
                                    .Where(x => x.RepresentativeBooking.BufferRepresentativeId == 19 && x.ComId == comid && x.IsDelivered == false)
                                     select new BufferDcVm
                                     {
                                         BufferDelChallanId = e.BufferDelChallanId,
                                         ChallanNo = e.ChallanNo,
                                         OrderNo = e.RepresentativeBooking.OrderNo,
                                         Carrier = e.RepresentativeBooking.BufferRepresentative.RepresentativeName,
                                         Buffer = e.RepresentativeBooking.BufferList.BufferName,
                                         qty = e.DeliveryQty,
                                         BalanceQty = e.BufferGatePassChallans.OrderByDescending(o => o.BufferGatePassSubId).FirstOrDefault() == null ? e.DeliveryQty : e.BufferGatePassChallans.OrderByDescending(o => o.BufferGatePassSubId).FirstOrDefault().BalanceQty,
                                         TruckLoadQty = e.BufferGatePassChallans.Sum(s=>s.TruckLoadQty),
                                         DeliveryDate = @String.Format("{0:MMM d, yyyy}", e.DeliveryDate)


                                     }).ToList();
                        if (query == null)
                        {
                            TempData["Message"] = "No Chalan availabe";
                            return Json(new { success = false, msg = "No Chalan created" });
                        }

                        return Json(query);

                    }
                    else
                    {
                        var query = (from e in _context.BufferDelChallan.Include(i => i.RepresentativeBooking).Include(i => i.RepresentativeBooking.BufferRepresentative).Include(i => i.RepresentativeBooking.BufferList)
                                       .Where(x => x.RepresentativeBooking.BufferRepresentativeId != 19 && x.ComId == comid && x.IsDelivered == false)
                                     select new BufferDcVm
                                     {
                                         BufferDelChallanId = e.BufferDelChallanId,
                                         ChallanNo = e.ChallanNo,
                                         OrderNo = e.RepresentativeBooking.OrderNo,
                                         Carrier = e.RepresentativeBooking.BufferRepresentative.RepresentativeName,
                                         Buffer = e.RepresentativeBooking.BufferList.BufferName,
                                         qty = e.DeliveryQty,
                                         TruckLoadQty = e.BufferGatePassChallans.Sum(s => s.TruckLoadQty),
                                         BalanceQty = e.BufferGatePassChallans.OrderByDescending(o => o.BufferGatePassSubId).FirstOrDefault() == null ? e.DeliveryQty : e.BufferGatePassChallans.OrderByDescending(o => o.BufferGatePassSubId).FirstOrDefault().BalanceQty,
                                         DeliveryDate = @String.Format("{0:MMM d, yyyy}", e.DeliveryDate)


                                     }).ToList();
                        if (query == null)
                        {
                            TempData["Message"] = "No Chalan availabe";
                            return Json(new { success = false, msg = "No Chalan created" });
                        }

                        return Json(query);
                    }
                }
                else
                {
                    if (type == "brtc")
                    {
                        var query = (from e in _context.BufferDelChallan.Include(i => i.RepresentativeBooking).Include(i => i.RepresentativeBooking.BufferRepresentative).Include(i => i.RepresentativeBooking.BufferList).Include(i => i.BufferGatePassChallans)
                                    .Where(x => x.RepresentativeBooking.BufferRepresentativeId == 19 && x.ComId == comid && x.IsDelivered == false)
                                     select new BufferDcVm
                                     {
                                         BufferDelChallanId = e.BufferDelChallanId,
                                         ChallanNo = e.ChallanNo,
                                         OrderNo = e.RepresentativeBooking.OrderNo,
                                         Carrier = e.RepresentativeBooking.BufferRepresentative.RepresentativeName,
                                         Buffer = e.RepresentativeBooking.BufferList.BufferName,
                                         qty = e.DeliveryQty,
                                         BalanceQty = e.BufferGatePassChallans.OrderByDescending(o => o.BufferGatePassSubId).FirstOrDefault() == null ? e.DeliveryQty : e.BufferGatePassChallans.OrderByDescending(o => o.BufferGatePassSubId).FirstOrDefault().BalanceQty,
                                         DeliveryDate = @String.Format("{0:MMM d, yyyy}", e.DeliveryDate)


                                     }).ToList();
                        if (query == null)
                        {
                            TempData["Message"] = "No Chalan availabe";
                            return Json(new { success = false, msg = "No Chalan created" });
                        }

                        return Json(query);

                    }
                    else
                    {
                        var query = (from e in _context.BufferDelChallan.Include(i => i.RepresentativeBooking).Include(i => i.RepresentativeBooking.BufferRepresentative).Include(i => i.RepresentativeBooking.BufferList)
                                       .Where(x => x.RepresentativeBooking.BufferRepresentativeId != 19 && x.ComId == comid && x.IsDelivered == false)
                                     select new BufferDcVm
                                     {
                                         BufferDelChallanId = e.BufferDelChallanId,
                                         ChallanNo = e.ChallanNo,
                                         OrderNo = e.RepresentativeBooking.OrderNo,
                                         Carrier = e.RepresentativeBooking.BufferRepresentative.RepresentativeName,
                                         Buffer = e.RepresentativeBooking.BufferList.BufferName,
                                         qty = e.DeliveryQty,
                                         BalanceQty = e.BufferGatePassChallans.OrderByDescending(o => o.BufferGatePassSubId).FirstOrDefault() == null ? e.DeliveryQty : e.BufferGatePassChallans.OrderByDescending(o => o.BufferGatePassSubId).FirstOrDefault().BalanceQty,
                                         DeliveryDate = @String.Format("{0:MMM d, yyyy}", e.DeliveryDate)


                                     }).ToList();
                        if (query == null)
                        {
                            TempData["Message"] = "No Chalan availabe";
                            return Json(new { success = false, msg = "No Chalan created" });
                        }

                        return Json(query);
                    }

                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, values = ex.Message.ToString() });
            }
        }
    }
}
