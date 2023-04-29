using DataTablesParser;
using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace GTERP.Controllers.POS
{
    [OverridableAuthorize]
    public class BillManagementController : Controller
    {
        private readonly GTRDBContext db;
        private TransactionLogRepository tranlog;
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
        public clsProcedure clsProc { get; }
        //public CommercialRepository Repository { get; set; }



        public BillManagementController(GTRDBContext gtrdb, TransactionLogRepository tran)
        {
            db = gtrdb;
            tranlog = tran;
            //Repository = rep;
        }

        // GET: PurchaseRequisition
        public async Task<IActionResult> Index()
        {
            string comid = HttpContext.Session.GetString("comid");

            //var fiscalYear = db.Acc_FiscalYears.Where(f => f.isRunning == true && f.isWorking == true).FirstOrDefault();
            //if (fiscalYear != null)
            //{
            //    var fiscalMonth = db.Acc_FiscalMonths.Where(f => f.OpeningdtFrom.Date <= DateTime.Now.Date && f.ClosingdtTo >= DateTime.Now.Date).FirstOrDefault();

            //    ViewBag.FiscalYearId = new SelectList(db.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", fiscalYear.FiscalYearId);
            //    ViewBag.FiscalMonthId = new SelectList(db.Acc_FiscalMonths.OrderByDescending(y => y.MonthName), "FiscalMonthId", "MonthName", fiscalMonth.FiscalMonthId);

            //}
            //else
            //{
            //    ViewBag.FiscalYearId = new SelectList(db.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName");
            //    ViewBag.FiscalMonthId = new SelectList(db.Acc_FiscalMonths.OrderByDescending(y => y.MonthName), "FiscalMonthId", "MonthName");

            //}

            //ViewBag.CostAlloMainId = new SelectList(db.bill_Main.Where(x => x.ComId == comid).Select(s => new { Text = s.Name, Value = s.CostAlloMainId }).ToList(), "Value", "Text");


            return View(await db.Bill_Main.Include(p => p.Supplier).Include(p => p.Acc_ChartOfAccount).ToListAsync());


            //return View();
        }

        public partial class PurchaseReQuisitionResult
        {
            public int PurReqId { get; set; }
            public string PRNo { get; set; }
            [Display(Name = "Product Unit")]
            public string PrdUnitName { get; set; }

            [Display(Name = "Requisition Ref")]
            public string ReqRef { get; set; }

            [Display(Name = "Requisition Date")]
            public string ReqDate { get; set; }

            [Display(Name = "Board Meeting Date")]
            public string BoardMeetingDate { get; set; }

            public string PurposeName { get; set; }


            public string DeptName { get; set; }


            public string ApprovedBy { get; set; }


            public string RecommenedBy { get; set; }

            [Display(Name = "Status")]
            public string Status { get; set; }

            public string Remarks { get; set; }

            [Display(Name = "Required Date")]
            public string RequiredDate { get; set; }




        }

        public IActionResult Get(string UserList, string FromDate, string ToDate, string CustomerList, int isAll)
        {
            try
            {
                var comid = (HttpContext.Session.GetString("comid"));

                DateTime dtFrom = Convert.ToDateTime(DateTime.Now.Date);
                DateTime dtTo = Convert.ToDateTime(DateTime.Now.Date);

                if (FromDate == null || FromDate == "")
                {
                }
                else
                {
                    dtFrom = Convert.ToDateTime(FromDate);

                }
                if (ToDate == null || ToDate == "")
                {
                }
                else
                {
                    dtTo = Convert.ToDateTime(ToDate);

                }

                Microsoft.Extensions.Primitives.StringValues y = "";

                var x = Request.Form.TryGetValue("search[value]", out y);

                if (y.ToString().Length > 0)
                {


                    var query = from e in db.PurchaseRequisitionMain.Where(x => x.ComId == comid)
                                .OrderByDescending(x => x.PurReqId)
                                    //let ImagePath = e.ImagePath + e.ProductId + e.FileExtension
                                select new PurchaseReQuisitionResult
                                {
                                    PurReqId = e.PurReqId,
                                    PRNo = e.PRNo,
                                    RecommenedBy = e.RecommenedBy != null ? e.RecommenedBy.EmpName : "",
                                    ApprovedBy = e.ApprovedBy != null ? e.ApprovedBy.EmpName : "",
                                    ReqDate = e.ReqDate.ToString("dd-MMM-yy"),
                                    RequiredDate = e.RequiredDate.ToString("dd-MMM-yy"),
                                    BoardMeetingDate = e.BoardMeetingDate.ToString("dd-MMM-yy"),
                                    PurposeName = e.Purpose != null ? e.Purpose.PurposeName : "",
                                    DeptName = e.Department != null ? e.Department.DeptName : "",
                                    Status = e.Status.ToString() != "0" ? "Posted" : "Not Posted",
                                    Remarks = e.Remarks,
                                    ReqRef = e.ReqRef,
                                };


                    var parser = new Parser<PurchaseReQuisitionResult>(Request.Form, query);

                    return Json(parser.Parse());

                }
                else
                {


                    if (CustomerList != null && UserList != null)
                    {
                        var querytest = from e in db.PurchaseRequisitionMain
                        .Where(x => x.ComId == comid)
                        .Where(p => (p.ReqDate >= dtFrom && p.ReqDate <= dtTo))
                        //.Where(p => p.userid == UserList)
                        .Where(p => p.UserId.ToLower().Contains(UserList.ToLower()))
                        //.Where(p => p.CustomerId == int.Parse(CustomerList))

                        .OrderByDescending(x => x.PurReqId)
                                            //let ImagePath = e.ImagePath + e.ProductId + e.FileExtension
                                        select new PurchaseReQuisitionResult
                                        {
                                            PurReqId = e.PurReqId,
                                            PRNo = e.PRNo,
                                            RecommenedBy = e.RecommenedBy != null ? e.RecommenedBy.EmpName : "",
                                            ApprovedBy = e.ApprovedBy != null ? e.ApprovedBy.EmpName : "",
                                            ReqDate = e.ReqDate.ToString("dd-MMM-yy"),
                                            RequiredDate = e.RequiredDate.ToString("dd-MMM-yy"),
                                            BoardMeetingDate = e.BoardMeetingDate.ToString("dd-MMM-yy"),
                                            PurposeName = e.Purpose != null ? e.Purpose.PurposeName : "",
                                            DeptName = e.Department != null ? e.Department.DeptName : "",
                                            Status = e.Status.ToString() != "0" ? "Posted" : "Not Posted",
                                            Remarks = e.Remarks,
                                            ReqRef = e.ReqRef,
                                        };


                        var parser = new Parser<PurchaseReQuisitionResult>(Request.Form, querytest);
                        return Json(parser.Parse());
                    }
                    else if (CustomerList != null && UserList == null)
                    {
                        var querytest = from e in db.PurchaseRequisitionMain
                        .Where(x => x.ComId == comid)
                        .Where(p => (p.ReqDate >= dtFrom && p.ReqDate <= dtTo))
                        //.Where(p => p.userid == UserList)
                        // .Where(p => p.CustomerId == int.Parse(CustomerList))

                        .OrderByDescending(x => x.PurReqId)
                                            //let ImagePath = e.ImagePath + e.ProductId + e.FileExtension
                                        select new PurchaseReQuisitionResult
                                        {
                                            PurReqId = e.PurReqId,
                                            PRNo = e.PRNo,
                                            RecommenedBy = e.RecommenedBy != null ? e.RecommenedBy.EmpName : "",
                                            ApprovedBy = e.ApprovedBy != null ? e.ApprovedBy.EmpName : "",
                                            ReqDate = e.ReqDate.ToString("dd-MMM-yy"),
                                            RequiredDate = e.RequiredDate.ToString("dd-MMM-yy"),
                                            BoardMeetingDate = e.BoardMeetingDate.ToString("dd-MMM-yy"),
                                            PurposeName = e.Purpose != null ? e.Purpose.PurposeName : "",
                                            DeptName = e.Department != null ? e.Department.DeptName : "",
                                            Status = e.Status.ToString() != "0" ? "Posted" : "Not Posted",
                                            Remarks = e.Remarks,
                                            ReqRef = e.ReqRef,
                                        };


                        var parser = new Parser<PurchaseReQuisitionResult>(Request.Form, querytest);
                        return Json(parser.Parse());
                    }
                    else if (CustomerList == null && UserList != null)
                    {

                        var querytest = from e in db.PurchaseRequisitionMain
                        .Where(x => x.ComId == comid)
                        .Where(p => (p.ReqDate >= dtFrom && p.ReqDate <= dtTo))
                        //.Where(p => p.userid == UserList)
                        .Where(p => p.UserId.ToLower().Contains(UserList.ToLower()))


                        .OrderByDescending(x => x.PurReqId)
                                            //let ImagePath = e.ImagePath + e.ProductId + e.FileExtension
                                        select new PurchaseReQuisitionResult
                                        {
                                            PurReqId = e.PurReqId,
                                            PRNo = e.PRNo,
                                            RecommenedBy = e.RecommenedBy != null ? e.RecommenedBy.EmpName : "",
                                            ApprovedBy = e.ApprovedBy != null ? e.ApprovedBy.EmpName : "",
                                            ReqDate = e.ReqDate.ToString("dd-MMM-yy"),
                                            RequiredDate = e.RequiredDate.ToString("dd-MMM-yy"),
                                            BoardMeetingDate = e.BoardMeetingDate.ToString("dd-MMM-yy"),
                                            PurposeName = e.Purpose != null ? e.Purpose.PurposeName : "",
                                            DeptName = e.Department != null ? e.Department.DeptName : "",
                                            Status = e.Status.ToString() != "0" ? "Posted" : "Not Posted",
                                            Remarks = e.Remarks,
                                            ReqRef = e.ReqRef,
                                        };


                        var parser = new Parser<PurchaseReQuisitionResult>(Request.Form, querytest);
                        return Json(parser.Parse());


                    }
                    else
                    {

                        var querytest = from e in db.PurchaseRequisitionMain
                        .Where(x => x.ComId == comid)
                        .Where(p => (p.ReqDate >= dtFrom && p.ReqDate <= dtTo))

                        .OrderByDescending(x => x.PurReqId)
                                            //let ImagePath = e.ImagePath + e.ProductId + e.FileExtension
                                        select new PurchaseReQuisitionResult
                                        {
                                            PurReqId = e.PurReqId,
                                            PRNo = e.PRNo,
                                            RecommenedBy = e.RecommenedBy != null ? e.RecommenedBy.EmpName : "",
                                            ApprovedBy = e.ApprovedBy != null ? e.ApprovedBy.EmpName : "",
                                            ReqDate = e.ReqDate.ToString("dd-MMM-yy"),
                                            RequiredDate = e.RequiredDate.ToString("dd-MMM-yy"),
                                            BoardMeetingDate = e.BoardMeetingDate.ToString("dd-MMM-yy"),
                                            PurposeName = e.Purpose != null ? e.Purpose.PurposeName : "",
                                            DeptName = e.Department != null ? e.Department.DeptName : "",
                                            Status = e.Status.ToString() != "0" ? "Posted" : "Not Posted",
                                            Remarks = e.Remarks,
                                            ReqRef = e.ReqRef,
                                        };


                        var parser = new Parser<PurchaseReQuisitionResult>(Request.Form, querytest);
                        return Json(parser.Parse());


                    }

                }

            }
            catch (Exception ex)
            {
                return Json(new { Success = "0", error = ex.Message });
                //throw ex;
            }

        }

        public ActionResult GetProductInfo(int id)
        {
            var comid = HttpContext.Session.GetString("comid");

            decimal? lastpurchaseprice;
            lastpurchaseprice = db.GoodsReceiveSub.Include(x => x.GoodsReceiveMain).Where(x => x.GoodsReceiveMain.ComId == comid && x.ProductId == id && x.GoodsReceiveMain.Status > 0).OrderByDescending(x => x.PurchaseOrderSub.PurchaseOrderMain.PODate).Take(1).Select(x => x.Rate).FirstOrDefault();
            if (lastpurchaseprice == null)
            {
                lastpurchaseprice = 0;
            }

            var ProductData = db.Products.Include(x => x.vProductUnit).Where(x => x.comid == comid).Select(p => new
            {
                p.ProductId,
                p.ProductName,
                p.ProductBrand,
                p.ProductModel,
                UnitName = p.vProductUnit.UnitName,
                p.UnitId,
                LastPurchasePrice = lastpurchaseprice
            }).Where(p => p.ProductId == id).FirstOrDefault();// ToList();

            ///ProductData.CostPrice = db.PurchaseOrderMain.Include(x => x.PurchaseOrderSub).Where(x => x.ComId == comid).Select(x=>x.p).OrderByDescending(x => x.PODate);
            //ProductData.CostPrice = db.GoodsReceiveSub.Include(x => x.GoodsReceiveMain).Where(x => x.GoodsReceiveMain.ComId == comid && x.ProductId == id).OrderByDescending(x => x.PurchaseOrderSub.PurchaseOrderMain.PODate).Take(1).Select(x => x.Rate);


            return Json(ProductData);
        }

        // GET: PurchaseRequisition/Create
        public IActionResult Create()
        {

            InitViewBag("Create");
            var data = db.Bill_Main.OrderByDescending(b => b.BillMainId).FirstOrDefault()?.BillMainId ?? 0;
            var bill = new Bill_Main();
            bill.BillNo = "B-" + ++data;
            bill.BillDate = DateTime.Now;
            return View(bill); /// for new bill no set last primary key value increment
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Bill_Main bill_Main)
        {
            try
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });

                if (ModelState.IsValid)
                {
                    if (bill_Main.BillMainId > 0)
                    {
                        bill_Main.DateUpdated = DateTime.Now;
                        bill_Main.ComId ??= HttpContext.Session.GetString("comid");
                        bill_Main.UserIdUpdated = HttpContext.Session.GetString("userid");
                        bill_Main.UserId ??= HttpContext.Session.GetString("userid");


                        if (bill_Main.Bill_Subs != null)
                        {
                            foreach (var item in bill_Main.Bill_Subs)
                            {
                                if (item.IsDelete)
                                {
                                    db.Entry(item).State = EntityState.Deleted;
                                }
                                else
                                {
                                    if (item.BillSubId > 0)
                                    {
                                        item.DateUpdated = DateTime.Now;
                                        db.Entry(item).State = EntityState.Modified;
                                    }
                                    else
                                    {
                                        item.DateAdded = DateTime.Now;
                                        db.Entry(item).State = EntityState.Added;
                                    }
                                }
                            }
                        }

                        db.Entry(bill_Main).State = EntityState.Modified;
                        db.SaveChanges();

                        TempData["Status"] = "2";
                        TempData["Message"] = "Data Update Successfully";

                        return Json(new { Success = 2, data = bill_Main.BillMainId, ex = TempData["Message"].ToString() });
                    }
                    else
                    {
                        bill_Main.UserId = HttpContext.Session.GetString("userid");
                        bill_Main.ComId = (HttpContext.Session.GetString("comid"));
                        bill_Main.DateAdded = DateTime.Now;

                        //if (bill_Main.Bill_Subs != null)
                        //{
                        //    foreach (var item in bill_Main.Bill_Subs)
                        //    {
                        //        item.DateAdded = DateTime.Now;
                        //    }
                        //}

                        bill_Main?.Bill_Subs?.ForEach(b => b.DateAdded = DateTime.Now);

                        db.Bill_Main.Add(bill_Main);
                        db.SaveChanges();
                        //TempData["Status"] = "1";
                        TempData["Message"] = "Data Save Successfully";

                        return Json(new { Success = 1, data = bill_Main.BillMainId, ex = TempData["Message"].ToString() }); ;
                    }
                }
                else
                {
                    return Json(new { Success = 3, ex = "Model State Not Valid" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = 3, ex = e.Message });

            }


        }

        public JsonResult ProductInfo(int id)
        {
            try
            {


                var productName = db.Products.Where(y => y.ProductId == id).Select(a => a.ProductName).SingleOrDefault();
                return Json(productName);
                //return Json("tesst" );

            }
            catch (Exception ex)
            {
                return Json(new { success = false, values = ex.Message.ToString() });
            }
            //return Json(new SelectList(product, "Value", "Text" ));
        }

        // POST: PurchaseRequisition/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(PurchaseRequisitionMain purchaseRequisitionMain)
        //{
        //    var ex = "";
        //    try
        //    {
        //        //if (ModelState.IsValid)
        //        //{

        //        #region Mandatory Parameter

        //        var comid = HttpContext.Session.GetString("comid");
        //        var userid = HttpContext.Session.GetString("userid");
        //        var AddDate = DateTime.Now;
        //        var UpdateDate = DateTime.Now;
        //        var PcName = HttpContext.Session.GetString("pcname");
        //        #endregion


        //        DateTime date = purchaseRequisitionMain.ReqDate;
        //        var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
        //        var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
        //        var activefiscalmonth = db.Acc_FiscalMonths.Where(x => x.ComId == comid && x.OpeningdtFrom >= firstDayOfMonth && x.ClosingdtTo <= lastDayOfMonth).FirstOrDefault();// && x.dtFrom.ToString() == monthid.ToString()
        //        if (activefiscalmonth == null)
        //        {
        //            return Json(new { Success = 0, ex = "No Active Fiscal Month Found" });
        //        }
        //        var activefiscalyear = db.Acc_FiscalYears.Where(x => x.FYId == activefiscalmonth.FYId).FirstOrDefault();
        //        if (activefiscalyear == null)
        //        {
        //            return Json(new { Success = 0, ex = "No Active Fiscal Year Found" });
        //        }


        //        //if (ModelState.IsValid)
        //        //{
        //        #region Edit request 
        //        if (purchaseRequisitionMain.PurReqId > 0)
        //        {

        //            purchaseRequisitionMain.FiscalMonthId = activefiscalmonth.FiscalMonthId;
        //            purchaseRequisitionMain.FiscalYearId = activefiscalyear.FiscalYearId;


        //            purchaseRequisitionMain.ComId = comid;
        //            purchaseRequisitionMain.UpdateByUserId = userid;
        //            purchaseRequisitionMain.DateUpdated = UpdateDate;
        //            IQueryable<PurchaseRequisitionSub> PurchaseRequisitionSub = db.PurchaseRequisitionSub.Where(p => p.PurReqId == purchaseRequisitionMain.PurReqId);

        //            //foreach (PurchaseRequisitionSub prsdelete in PurchaseRequisitionSub)
        //            //{
        //            //    db.PurchaseRequisitionSub.Remove(prsdelete);
        //            //}
        //            var sl = 0;
        //            foreach (PurchaseRequisitionSub item in purchaseRequisitionMain.PurchaseRequisitionSub)
        //            {
        //                sl++;
        //                if (item.PurReqSubId > 0)
        //                {
        //                    if (item.IsDelete!=true)
        //                    {
        //                        db.Entry(item).State = EntityState.Modified;
        //                        db.SaveChanges();
        //                    }
        //                    else
        //                    {
        //                        db.Entry(item).State = EntityState.Deleted;
        //                        db.SaveChanges();
        //                    }

        //                }
        //                else
        //                {
        //                    try
        //                    {
        //                        var sub = new PurchaseRequisitionSub();
        //                        sub.ComId = comid;
        //                        sub.DateAdded = item.DateAdded;
        //                        sub.DateUpdated = item.DateUpdated;
        //                        sub.Note = item.Note;
        //                        sub.PcName = PcName;
        //                        sub.ProductId = item.ProductId;
        //                        sub.PurReqId = item.PurReqId;
        //                        sub.PurReqQty = item.PurReqQty;
        //                        sub.PurReqSubId = item.PurReqSubId;
        //                        sub.RemainingReqQty = item.RemainingReqQty;
        //                        sub.SLNo = sl;
        //                        sub.UpdateByUserId = item.UpdateByUserId;

        //                        sub.UserId = userid;

        //                        db.PurchaseRequisitionSub.Add(sub);

        //                    }
        //                    catch (Exception e)
        //                    {

        //                        Console.WriteLine(e.Message);
        //                    }

        //                }

        //            }

        //            db.Entry(purchaseRequisitionMain).State = EntityState.Modified;
        //            db.SaveChanges();
        //        }
        //        #endregion

        //        #region Create Request

        //        else
        //        {
        //            using (var tr = db.Database.BeginTransaction())
        //            {

        //                purchaseRequisitionMain.FiscalMonthId = activefiscalmonth.FiscalMonthId;
        //                purchaseRequisitionMain.FiscalYearId = activefiscalyear.FiscalYearId;

        //                purchaseRequisitionMain.ComId = comid;
        //                purchaseRequisitionMain.UserId = userid;
        //                purchaseRequisitionMain.DateAdded = AddDate;
        //                var main = new PurchaseRequisitionMain();
        //                main = purchaseRequisitionMain;
        //                var sl = 0;
        //                foreach (var item in purchaseRequisitionMain.PurchaseRequisitionSub)
        //                {
        //                    sl++;
        //                    var sub = new PurchaseRequisitionSub();
        //                    sub.ComId = comid;
        //                    sub.DateAdded = AddDate;
        //                    sub.DateUpdated = item.DateUpdated;
        //                    sub.Note = item.Note;
        //                    sub.PcName = PcName;
        //                    sub.ProductId = item.ProductId;
        //                    sub.PurReqId = purchaseRequisitionMain.PurReqId;
        //                    sub.PurReqQty = item.PurReqQty;
        //                    sub.LastPurchasePrice = item.LastPurchasePrice;
        //                    sub.RemainingReqQty = item.RemainingReqQty;
        //                    sub.SLNo = sl;
        //                    sub.UpdateByUserId = item.UpdateByUserId;
        //                    sub.UserId = userid;
        //                }

        //                db.PurchaseRequisitionMain.Add(main);
        //                db.SaveChanges();

        //                tr.Commit();
        //            }

        //        } 
        //        #endregion


        //        return Json(new { Success = 1, PurReqId = purchaseRequisitionMain.PurReqId, ex = "" });
        //        //}
        //        //}



        //    }
        //    catch (Exception e)
        //    {
        //        ex = e.Message;
        //        //return Json(new { Success = 0, error = 1, ex = e.Message });
        //    }
        //    #region ViewBag Initialization

        //    //ViewData["Employees"] = new SelectList(db.HR_Emp_Info.Select(x => new { x.EmpId, x.EmpCode, x.EmpName }), "EmpId", "EmpName", purchaseRequisitionMain.ApprovedByEmpId);
        //    //ViewData["CategoryId"] = new SelectList(db.Categories.Select(x => new { x.CategoryId, x.Name }), "CategoryId", "Name");
        //    //ViewData["DepartmentId"] = new SelectList(db.Cat_Department.Select(x => new { x.DeptId, x.DeptName }), "DeptId", "DeptName", purchaseRequisitionMain.DepartmentId);
        //    //ViewData["PrdUnitId"] = new SelectList(db.PrdUnits.Select(x => new { x.PrdUnitId, x.PrdUnitShortName }), "PrdUnitId", "PrdUnitShortName", purchaseRequisitionMain.PrdUnitId);
        //    //ViewData["PurposeId"] = new SelectList(db.Purpose.Select(x => new { x.PurposeId, x.PurposeName }), "PurposeId", "PurposeName", purchaseRequisitionMain.PurposeId);

        //    //ViewData["ProductId"] = new SelectList(db.Products.Select(x => new { x.ProductId, x.ProductName }), "ProductId", "ProductName");

        //    //ViewData["UnitId"] = new SelectList(db.Unit.Select(x => new { x.UnitId, x.UnitName }), "UnitId", "UnitName"); 
        //    #endregion

        //    return Json(new { Success = 0, error = 1, ex = ex });

        //}
        //[ValidateAntiForgeryToken]



        [HttpPost]
        public ActionResult DeletePrSub(int prsubid)
        {
            try
            {
                var sub = db.PurchaseRequisitionSub.Find(prsubid);
                db.PurchaseRequisitionSub.Remove(sub);
                db.SaveChanges();
                return Json(new { error = 0, success = 1, message = "This record deleted successfully" });
            }
            catch (Exception ex)
            {
                var m = $" Message:{ex.Message}\nInner Exception:{ex.InnerException.Message}";
                return Json(new { error = 1, success = 0, message = m });
            }

        }

        // GET: PurchaseRequisition/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Edit";

            Bill_Main Bill = await db.Bill_Main
                 .Include(p => p.Bill_Subs).ThenInclude(p => p.Product)
                 .Include(p => p.Acc_ChartOfAccount)
                 .Where(p => p.BillMainId == id)
                 .FirstOrDefaultAsync();

            if (Bill == null)
            {
                return NotFound();
            }
            InitViewBag("Edit", Bill);
            //return Json(new {data= purchaseRequisitionMain });
            return View("Create", Bill);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";

            Bill_Main Bill = await db.Bill_Main
                .Include(p => p.Bill_Subs).ThenInclude(p => p.Product)
                 .Include(p => p.Acc_ChartOfAccount)
                .Where(p => p.BillMainId == id)
                .FirstOrDefaultAsync();
            // PurchaseRequisitionMain purchaseRequisitionMain = await db.PurchaseRequisitionMain.FindAsync(id);
            if (Bill == null)
            {
                return NotFound();
            }
            InitViewBag("Delete", Bill);
            //return Json(new {data= purchaseRequisitionMain });
            return View("Create", Bill);

        }

        // POST: PurchaseRequisition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var bill = await db.Bill_Main.FindAsync(id);
                db.Bill_Main.Remove(bill);
                await db.SaveChangesAsync();


                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), bill.BillMainId.ToString(), "Delete", bill.BillNo);

                return Json(new { Success = 1, BillMainId = bill.BillMainId, ex = "" });

            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new
                {
                    Success = 0,
                    ex = ex.Message.ToString()
                });
            }
        }
        private void InitViewBag(string title, Bill_Main Bill_Main = null)
        {
            var comid = HttpContext.Session.GetString("comid");

            ViewBag.Title = title;
            if (title == "Create")
            {


                ViewBag.SupplierId = new SelectList(db.Suppliers.Where(x => x.comid == comid).Select(s => new { Text = s.SupplierName, Value = s.SupplierId }).ToList(), "Value", "Text");
                ViewBag.ProductId = new SelectList(db.Products.Where(x => x.comid == comid).Select(s => new { Text = s.ProductName + " - [ " + s.ProductCode + " ]", Value = s.ProductId }).ToList(), "Value", "Text");
                ViewBag.AccId = new SelectList(db.Acc_ChartOfAccounts.Where(x => x.comid == comid && x.AccCode.Substring(0, 6) == "1-1-11").Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text");

                //ViewData["ProductId"] = new SelectList(db.Products.Where(c => c.comid == comid), "ProductId", "ProductName");

            }
            else if (title == "Edit" || title == "Delete")
            {
                ViewBag.AccId = new SelectList(db.Acc_ChartOfAccounts.Where(x => x.comid == comid && x.AccCode.Substring(0, 6) == "1-1-11").Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text", Bill_Main.AccId);

                ViewBag.SupplierId = new SelectList(db.Suppliers.Where(x => x.comid == comid).Select(s => new { Text = s.SupplierName, Value = s.SupplierId }).ToList(), "Value", "Text", Bill_Main.SupplierId);
                ViewBag.ProductId = new SelectList(db.Products.Where(x => x.comid == comid).Select(s => new { Text = s.ProductName + " - [ " + s.ProductCode + " ]", Value = s.ProductId }).ToList(), "Value", "Text");
            }

        }


        public ActionResult Print(int id)
        {
            string SqlCmd = "";
            string ReportPath = "";
            var ConstrName = "ApplicationServices";
            var ReportType = "PDF";
            var comid = HttpContext.Session.GetString("comid");


            //filename = "Bill_" + DateTime.Now.Date;
            //query = "Exec rptBillManagement '" + Id + "', '" + comid + "'";

            var reportname = "rptBillManagement";
            ///@ComId nvarchar(200),@Type varchar(10),@ID int,@dtFrom smalldatetime,@dtTo smalldatetime
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Accounts/" + reportname + ".rdlc");
            //var str = db.Acc_VoucherMains.Include(x => x.Acc_VoucherType).FirstOrDefault().Acc_VoucherType.VoucherTypeNameShort;// "VPC";
            HttpContext.Session.SetString("reportquery", "Exec [rptBillManagement] '" + id + "','" + comid + "'");


            //Session["reportquery"] = "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.[rptCommercialInvoice_Export] '" + id + "','" + AppData.AppData.intComId + "'";
            string filename = "Bill_" + DateTime.Now.Date;
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

            //var a = Session["PrintFileName"].ToString();


            string DataSourceName = "DataSet1";
            HttpContext.Session.SetObject("rptList", postData);


            //Common.Classes.clsMain.intHasSubReport = 0;
            clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
            clsReport.strQueryMain = HttpContext.Session.GetString("reportquery");
            clsReport.strDSNMain = DataSourceName;




            SqlCmd = clsReport.strQueryMain;
            ReportPath = clsReport.strReportPathMain;
            ReportType = "PDF";

            /////////////////////// sub report test to our report server


            //var subReport = new SubReport();
            //var subReportObject = new List<SubReport>();

            //subReport.strDSNSub = "DataSet1";
            //subReport.strRFNSub = "";
            //subReport.strQuerySub = "Exec [rptShowVoucher_Referance] '" + id + "','" + comid + "','ChequeNo'";
            //subReport.strRptPathSub = "rptShowVoucher_ChequeNo";
            //subReportObject.Add(subReport);


            //subReport = new SubReport();
            //subReport.strDSNSub = "DataSet1";
            //subReport.strRFNSub = "";
            //subReport.strQuerySub = "Exec [rptShowVoucher_Referance] '" + id + "','" + comid + "','ReceiptPerson'";
            //subReport.strRptPathSub = "rptShowVoucher_ReceiptPerson";
            //subReportObject.Add(subReport);


            //var jsonData = JsonConvert.SerializeObject(subReportObject);

            //string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType });  //Repository.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType, jsonData);
            string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //Repository.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

            return Redirect(callBackUrl);

            ///return RedirectToAction("Index", "ReportViewer");


        }

        public JsonResult SetSessionAccountReport(string rptFormat, string CostAlloMainId, string FiscalYearId, string FiscalMonthId)
        {
            try
            {
                string comid = HttpContext.Session.GetString("comid");
                string userid = HttpContext.Session.GetString("userid");

                var reportname = "";
                var filename = "";
                string redirectUrl = "";
                string query = "";
                //return Json(new { Success = 1, TermsId = param, ex = "" });
                if (true)
                {
                    //redirectUrl = new UrlHelper(Request.RequestContext).Action(action, "COM_BBLC_Master", new { FromDate = FromDate, ToDate = ToDate, Supplierid = SupplierId, CommercialCompanyId = CommercialCompanyId }); //, new { companyId = "7e96b930-a786-44dd-8576-052ce608e38f" }
                    reportname = "rptCostAllocation";
                    filename = "Notes_" + DateTime.Now.Date;
                    query = "Exec Acc_rptCostAllocation '" + CostAlloMainId + "', '" + FiscalYearId + "' ,'" + FiscalMonthId + "','" + comid + "','" + userid + "'";


                    HttpContext.Session.SetString("reportquery", query);
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Accounts/" + reportname + ".rdlc");
                }



                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


                string DataSourceName = "DataSet1";

                //HttpContext.Session.SetObject("Acc_rptList", postData);

                //Common.Classes.clsMain.intHasSubReport = 0;
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");// Session["ReportPath"].ToString();
                clsReport.strQueryMain = HttpContext.Session.GetString("reportquery");
                clsReport.strDSNMain = DataSourceName;

                var ConstrName = "ApplicationServices";
                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat }); //Repository.GenerateReport(clsReport.strReportPathMain, clsReport.strQueryMain, ConstrName, rptFormat);
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


        [HttpPost, ActionName("PrintVatTax")]
        public JsonResult GrrDetailsReport(string rptFormat, string action, string FromDate, string ToDate)
        {
            try
            {
                string comid = HttpContext.Session.GetString("comid");

                var reportname = "";
                var filename = "";
                string redirectUrl = "";
                if (action == "PrintVatTax")
                {
                    reportname = "rptVatTaxBill";
                    filename = "rptVatTaxBill" + DateTime.Now.Date.ToString();
                    HttpContext.Session.SetString("reportquery", "Exec [rptBillListReport] '" + comid + "','" + FromDate + "','" + ToDate + "','VatTax'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Accounts/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }


                string DataSourceName = "DataSet1";


                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");// Session["ReportPath"].ToString();
                clsReport.strQueryMain = HttpContext.Session.GetString("reportquery");
                clsReport.strDSNMain = DataSourceName;

                var ConstrName = "ApplicationServices";
                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat }); //Repository.GenerateReport(clsReport.strReportPathMain, clsReport.strQueryMain, ConstrName, rptFormat);
                redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }

            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }

            return Json(new { Success = 0, ex = new Exception("Unable to Open").Message.ToString() });


        }

        [HttpPost, ActionName("PrintSD")]
        public JsonResult PrintSDReport(string rptFormat, string action, string FromDate, string ToDate)
        {
            try
            {
                string comid = HttpContext.Session.GetString("comid");

                var reportname = "";
                var filename = "";
                string redirectUrl = "";
                if (action == "PrintSD")
                {
                    reportname = "rptSDBill";
                    filename = "rptSDBill" + DateTime.Now.Date.ToString();
                    HttpContext.Session.SetString("reportquery", "Exec [rptBillListReport] '" + comid + "','" + FromDate + "','" + ToDate + "','SD'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Accounts/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }


                string DataSourceName = "DataSet1";


                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");// Session["ReportPath"].ToString();
                clsReport.strQueryMain = HttpContext.Session.GetString("reportquery");
                clsReport.strDSNMain = DataSourceName;

                var ConstrName = "ApplicationServices";
                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat }); //Repository.GenerateReport(clsReport.strReportPathMain, clsReport.strQueryMain, ConstrName, rptFormat);
                redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }

            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }

            return Json(new { Success = 0, ex = new Exception("Unable to Open").Message.ToString() });


        }

        [HttpPost, ActionName("PrintWelfare")]
        public JsonResult PrintWelfareReport(string rptFormat, string action, string FromDate, string ToDate)
        {
            try
            {
                string comid = HttpContext.Session.GetString("comid");

                var reportname = "";
                var filename = "";
                string redirectUrl = "";
                if (action == "PrintWelfare")
                {
                    reportname = "rptSDBill";
                    filename = "rptSDBill" + DateTime.Now.Date.ToString();
                    HttpContext.Session.SetString("reportquery", "Exec [rptBillListReport] '" + comid + "','" + FromDate + "','" + ToDate + "','Welfare'");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Accounts/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }


                string DataSourceName = "DataSet1";


                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");// Session["ReportPath"].ToString();
                clsReport.strQueryMain = HttpContext.Session.GetString("reportquery");
                clsReport.strDSNMain = DataSourceName;

                var ConstrName = "ApplicationServices";
                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat }); //Repository.GenerateReport(clsReport.strReportPathMain, clsReport.strQueryMain, ConstrName, rptFormat);
                redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }

            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }

            return Json(new { Success = 0, ex = new Exception("Unable to Open").Message.ToString() });


        }

        private bool PurchaseRequisitionMainExists(int id)
        {
            return db.PurchaseRequisitionMain.Any(e => e.PurReqId == id);
        }
    }
}
