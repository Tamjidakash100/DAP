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
    public class CostAllocationController : Controller
    {
        private readonly GTRDBContext db;
        private TransactionLogRepository tranlog;
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
        public clsProcedure clsProc { get; }
        //public CommercialRepository Repository { get; set; }



        public CostAllocationController(GTRDBContext gtrdb, TransactionLogRepository tran)
        {
            db = gtrdb;
            tranlog = tran;
            //Repository = rep;
        }

        // GET: PurchaseRequisition
        public async Task<IActionResult> Index()
        {
            //var comid = HttpContext.Session.GetString("comid");
            //var userid = HttpContext.Session.GetString("userid");
            ////var gTRDBContext = db.StoreRequisitionMain.Where(x => x.ComId == comid).Include(s => s.ApprovedBy).Include(s => s.Department).Include(s => s.PrdUnit).Include(s => s.Purpose).Include(s => s.RecommenedBy);

            /////////////get user list from the server //////

            //var appKey = HttpContext.Session.GetString("appkey");
            //var model = new GetUserModel();
            //model.AppKey = Guid.Parse(appKey);
            //WebHelper webHelper = new WebHelper();
            //string req = JsonConvert.SerializeObject(model);
            ////Uri url = new Uri(string.Format("https://localhost:44336/api/user/GetUsersCompanies"));
            ////Uri url = new Uri(string.Format("https://pqstec.com:92/api/User/GetUsersCompanies")); ///enable ssl certificate for secure connection
            //Uri url = new Uri(string.Format("https://www.gtrbd.net/Support/api/AccountAPI/GetUsersCompanies"));
            //string response = webHelper.GetUserCompany(url, req);
            //GetResponse res = new GetResponse(response);

            //var list = res.MyUsers.ToList();
            //var l = new List<CompanyPermissionsController.AspnetUserList>();
            //foreach (var c in list)
            //{
            //    var le = new CompanyPermissionsController.AspnetUserList();
            //    le.Email = c.UserName;
            //    le.UserId = c.UserID;
            //    le.UserName = c.UserName;
            //    l.Add(le);
            //}

            //ViewBag.Userlist = new SelectList(l, "UserId", "UserName", userid);
            string comid = HttpContext.Session.GetString("comid");

            var fiscalYear = db.Acc_FiscalYears.Where(f => f.isRunning == true && f.isWorking == true).FirstOrDefault();
            if (fiscalYear != null)
            {
                var fiscalMonth = db.Acc_FiscalMonths.Where(f => f.OpeningdtFrom.Date <= DateTime.Now.Date && f.ClosingdtTo >= DateTime.Now.Date).FirstOrDefault();

                ViewBag.FiscalYearId = new SelectList(db.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", fiscalYear.FiscalYearId);
                ViewBag.FiscalMonthId = new SelectList(db.Acc_FiscalMonths.OrderByDescending(y => y.MonthName), "FiscalMonthId", "MonthName", fiscalMonth.FiscalMonthId);

            }
            else
            {
                ViewBag.FiscalYearId = new SelectList(db.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName");
                ViewBag.FiscalMonthId = new SelectList(db.Acc_FiscalMonths.OrderByDescending(y => y.MonthName), "FiscalMonthId", "MonthName");

            }

            ViewBag.CostAlloMainId = new SelectList(db.CostAllocation_Main.Where(x => x.ComId == comid).Select(s => new { Text = s.Name, Value = s.CostAlloMainId }).ToList(), "Value", "Text");


            return View(await db.CostAllocation_Main.Include(p => p.Acc_FiscalYear).Include(p => p.Acc_FiscalMonth).ToListAsync());


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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CostAllocation_Main CostAllocation_Main)
        {
            try
            {
                //    var errors = ModelState.Where(x => x.Value.Errors.Any())
                //.Select(x => new { x.Key, x.Value.Errors });

                if (ModelState.IsValid)
                {
                    if (CostAllocation_Main.CostAlloMainId > 0)
                    {
                        CostAllocation_Main.DateUpdated = DateTime.Now;
                        CostAllocation_Main.ComId = HttpContext.Session.GetString("comid");
                        CostAllocation_Main.UpdateByUserId = HttpContext.Session.GetString("userid");
                        CostAllocation_Main.DateUpdated = DateTime.Now;

                        if (CostAllocation_Main.UserId == null)
                        {
                            CostAllocation_Main.UserId = HttpContext.Session.GetString("userid");
                        }
                        CostAllocation_Main.UpdateByUserId = HttpContext.Session.GetString("userid");


                        if (CostAllocation_Main.CostAllocation_Detailses != null)
                        {
                            foreach (var item in CostAllocation_Main.CostAllocation_Detailses)
                            {
                                if (item.IsDelete)
                                {
                                    db.Entry(item).State = EntityState.Deleted;
                                }
                                else
                                {

                                    if (item.CostAlloSubId > 0)
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
                        if (CostAllocation_Main.CostAllocation_Distributes != null)
                        {
                            foreach (var item in CostAllocation_Main.CostAllocation_Distributes)
                            {
                                if (item.IsDelete)
                                {
                                    db.Entry(item).State = EntityState.Deleted;

                                }
                                else
                                {
                                    if (item.CostAlloDistributeId > 0)
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
                        db.Entry(CostAllocation_Main).State = EntityState.Modified;
                        db.SaveChanges();

                        TempData["Status"] = "2";
                        TempData["Message"] = "Data Update Successfully";

                        return Json(new { Success = 2, data = CostAllocation_Main.CostAlloMainId, ex = TempData["Message"].ToString() });
                    }
                    else
                    {
                        CostAllocation_Main.UserId = HttpContext.Session.GetString("userid");
                        CostAllocation_Main.ComId = (HttpContext.Session.GetString("comid"));
                        CostAllocation_Main.DateAdded = DateTime.Now;

                        if (CostAllocation_Main.CostAllocation_Detailses != null)
                        {
                            foreach (var item in CostAllocation_Main.CostAllocation_Detailses)
                            {
                                item.DateAdded = DateTime.Now;
                            }
                        }
                        if (CostAllocation_Main.CostAllocation_Distributes != null)
                        {
                            foreach (var item in CostAllocation_Main.CostAllocation_Distributes)
                            {
                                item.DateAdded = DateTime.Now;
                            }
                        }

                        db.CostAllocation_Main.Add(CostAllocation_Main);
                        db.SaveChanges();
                        //TempData["Status"] = "1";
                        TempData["Message"] = "Data Save Successfully";

                        return Json(new { Success = 1, data = CostAllocation_Main.CostAlloMainId, ex = TempData["Message"].ToString() }); ;
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
                var comid = (HttpContext.Session.GetString("comid"));



                var product = db.Products.Where(y => y.ProductId == id && y.comid == comid).SingleOrDefault();
                var unit = db.Unit.Where(y => y.UnitId == product.UnitId).SingleOrDefault();


                return Json(unit);
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

        public JsonResult GetProducts(int? id)
        {
            var comid = HttpContext.Session.GetString("comid");
            IEnumerable<object> product;
            if (id != null)
            {
                if (id == 0 || id == -1)
                {
                    //product = db.Products.Where(x => x.comid == comid).Select(x => new { x.ProductId, x.ProductName }).ToList();
                    product = new SelectList(db.Products.Where(x => x.comid == comid).Select(s => new { Text = s.ProductName + " - [ " + s.ProductCode + " ]", Value = s.ProductId }).ToList(), "Value", "Text");

                }
                else
                {
                    product = new SelectList(db.Products.Where(x => x.comid == comid && x.CategoryId == id).Select(s => new { Text = s.ProductName + " - [ " + s.ProductCode + " ]", Value = s.ProductId }).ToList(), "Value", "Text");
                    //product = db.Products.Where(x => x.CategoryId == id).Select(x => new { x.ProductId, x.ProductName }).ToList();
                }
            }
            else
            {
                //product = db.Products.Where(x => x.comid == comid).Select(x => new { x.ProductId, x.ProductName }).ToList();
                product = new SelectList(db.Products.Take(0).Where(x => x.comid == comid).Select(s => new { Text = s.ProductName + " - [ " + s.ProductCode + " ]", Value = s.ProductId }).ToList(), "Value", "Text");

            }
            return Json(new { item = product });
        }

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

            CostAllocation_Main CostAllocation_Main = await db.CostAllocation_Main
                .Include(p => p.CostAllocation_Detailses)
                .ThenInclude(p => p.Acc_ChartOfAccount)
                .Include(p => p.CostAllocation_Distributes)
                .ThenInclude(p => p.Acc_ChartOfAccount)
                .Include(p => p.Acc_FiscalYear).Include(p => p.Acc_FiscalMonth)
                .Where(p => p.CostAlloMainId == id)
                .FirstOrDefaultAsync();

            if (CostAllocation_Main == null)
            {
                return NotFound();
            }
            InitViewBag("Edit", id, CostAllocation_Main);
            //return Json(new {data= purchaseRequisitionMain });
            return View("Create", CostAllocation_Main);
        }

        // POST: PurchaseRequisition/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, PurchaseRequisitionMain purchaseRequisitionMain)
        //{
        //    var comid = HttpContext.Session.GetString("comid");

        //    if (id != purchaseRequisitionMain.PurReqId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            db.Update(purchaseRequisitionMain);
        //            await db.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PurchaseRequisitionMainExists(purchaseRequisitionMain.PurReqId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ApprovedByEmpId"] = new SelectList(db.HR_Emp_Info.Where(x=>x.ComId == comid), "EmployeeId", "EmployeeName", purchaseRequisitionMain.ApprovedByEmpId);
        //    ViewData["DepartmentId"] = new SelectList(db.Cat_Department.Where(x => x.ComId == comid), "DeptId", "DeptName", purchaseRequisitionMain.DepartmentId);
        //    ViewData["PrdUnitId"] = new SelectList(db.PrdUnits.Where(x => x.comid == comid), "PrdUnitId", "PrdUnitShortName", purchaseRequisitionMain.PrdUnitId);
        //    ViewData["PurposeId"] = new SelectList(db.Purpose, "PurposeId", "PurposeName", purchaseRequisitionMain.PurposeId);
        //    ViewData["RecommenedByEmpId"] = new SelectList(db.HR_Emp_Info.Where(x => x.ComId == comid), "EmployeeId", "EmployeeName", purchaseRequisitionMain.RecommenedByEmpId);
        //    ViewData["ProductId"] = new SelectList(db.Products.Where(x => x.comid == comid), "ProductId", "ProductName");
        //    ViewData["UnitId"] = new SelectList(db.Unit, "UnitId", "UnitName");
        //    ViewData["SectId"] = new SelectList(db.Cat_Section.Select(x => new { x.SectId, x.SectName }), "SectId", "SectName", purchaseRequisitionMain.SectId);
        //    return View(purchaseRequisitionMain);
        //}

        // GET: PurchaseRequisition/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";

            CostAllocation_Main CostAllocation_Main = await db.CostAllocation_Main
                .Include(p => p.CostAllocation_Detailses)
                .ThenInclude(p => p.Acc_ChartOfAccount)
                .Include(p => p.CostAllocation_Distributes)
                .ThenInclude(p => p.Acc_ChartOfAccount)
                .Include(p => p.Acc_FiscalYear).Include(p => p.Acc_FiscalMonth)
                .Where(p => p.CostAlloMainId == id)
                .FirstOrDefaultAsync();
            // PurchaseRequisitionMain purchaseRequisitionMain = await db.PurchaseRequisitionMain.FindAsync(id);
            if (CostAllocation_Main == null)
            {
                return NotFound();
            }
            InitViewBag("Delete", id, CostAllocation_Main);
            //return Json(new {data= purchaseRequisitionMain });
            return View("Create", CostAllocation_Main);

        }

        // POST: PurchaseRequisition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var CostAllocation_Main = await db.CostAllocation_Main.FindAsync(id);
                db.CostAllocation_Main.Remove(CostAllocation_Main);
                await db.SaveChangesAsync();


                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), CostAllocation_Main.CostAlloMainId.ToString(), "Delete", CostAllocation_Main.CostAlloMainId.ToString());

                return Json(new { Success = 1, CostAlloMainId = CostAllocation_Main.CostAlloMainId, ex = "" });

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
        private void InitViewBag(string title, int? id = null, CostAllocation_Main CostAllocationMian = null)
        {
            var comid = HttpContext.Session.GetString("comid");

            ViewBag.Title = title;
            if (title == "Create")
            {
                var fiscalYear = db.Acc_FiscalYears.Where(f => f.isRunning == true && f.isWorking == true).FirstOrDefault();
                if (fiscalYear != null)
                {
                    var fiscalMonth = db.Acc_FiscalMonths.Where(f => f.OpeningdtFrom.Date <= DateTime.Now.Date && f.ClosingdtTo >= DateTime.Now.Date).FirstOrDefault();

                    ViewBag.FiscalYearId = new SelectList(db.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", fiscalYear.FiscalYearId);
                    ViewBag.FiscalMonthId = new SelectList(db.Acc_FiscalMonths.OrderByDescending(y => y.MonthName), "FiscalMonthId", "MonthName", fiscalMonth.FiscalMonthId);

                }
                else
                {
                    ViewBag.FiscalYearId = new SelectList(db.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName");
                    ViewBag.FiscalMonthId = new SelectList(db.Acc_FiscalMonths.OrderByDescending(y => y.MonthName), "FiscalMonthId", "MonthName");

                }

                ViewBag.AccId = new SelectList(db.Acc_ChartOfAccounts.Where(x => x.comid == comid).Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text");

                //ViewData["ProductId"] = new SelectList(db.Products.Where(c => c.comid == comid), "ProductId", "ProductName");

            }
            else if (title == "Edit" || title == "Delete")
            {

                ViewBag.FiscalYearId = new SelectList(db.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", CostAllocationMian.FiscalYearId);
                ViewBag.FiscalMonthId = new SelectList(db.Acc_FiscalMonths.OrderByDescending(y => y.MonthName), "FiscalMonthId", "MonthName", CostAllocationMian.FiscalMonthId);

                ViewBag.AccId = new SelectList(db.Acc_ChartOfAccounts.Where(x => x.comid == comid).Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text");
            }

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


        private bool PurchaseRequisitionMainExists(int id)
        {
            return db.PurchaseRequisitionMain.Any(e => e.PurReqId == id);
        }
    }
}
