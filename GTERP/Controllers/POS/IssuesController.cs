using DataTablesParser;
using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.Common;
using GTERP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static GTERP.Controllers.CompanyPermissionsController;


namespace GTERP.Controllers.POS
{
    [OverridableAuthorize]
    public class IssuesController : Controller
    {
        private readonly GTRDBContext db;
        private TransactionLogRepository tranlog;
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
        //public CommercialRepository Repository { get; set; }
        POSRepository POS;
        PermissionLevel PL;
        public IssuesController(GTRDBContext context, TransactionLogRepository tran, POSRepository _POS, PermissionLevel _pl)
        {
            db = context;
            tranlog = tran;
            //Repository = rep;
            POS = _POS;
            PL = _pl;
        }

        // GET: Issues
        public async Task<IActionResult> Index()
        {
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");
            //var gTRDBContext = db.StoreRequisitionMain.Where(x => x.ComId == comid).Include(s => s.ApprovedBy).Include(s => s.Department).Include(s => s.PrdUnit).Include(s => s.Purpose).Include(s => s.RecommenedBy);

            ///////////get user list from the server //////

            var appKey = HttpContext.Session.GetString("appkey");
            var model = new GetUserModel();
            model.AppKey = Guid.Parse(appKey);
            WebHelper webHelper = new WebHelper();
            string req = JsonConvert.SerializeObject(model);
            //Uri url = new Uri(string.Format("https://localhost:44336/api/user/GetUsersCompanies"));
            //Uri url = new Uri(string.Format("https://pqstec.com:92/api/User/GetUsersCompanies")); ///enable ssl certificate for secure connection
            Uri url = new Uri(string.Format("https://www.gtrbd.net/Support/api/AccountAPI/GetUsersCompanies"));
            string response = webHelper.GetUserCompany(url, req);
            GetResponse res = new GetResponse(response);

            var list = res.MyUsers.ToList();
            List<string> moduleUser = PL.GetModuleUser().ToList();

            var l = new List<CompanyPermissionsController.AspnetUserList>();
            foreach (var c in list)
            {
                if (moduleUser.Contains(c.UserID))
                {
                    var le = new CompanyPermissionsController.AspnetUserList();
                    le.Email = c.UserName;
                    le.UserId = c.UserID;
                    le.UserName = c.UserName;
                    l.Add(le);
                }
            }

            ViewBag.Userlist = new SelectList(l, "UserId", "UserName", userid);


            var lastissueMain = db.IssueMain.Where(x => x.ComId == comid && x.UserId == userid).OrderByDescending(x => x.IssueMainId).FirstOrDefault();

            if (lastissueMain != null)
            {

                ViewData["PrdUnitId"] = new SelectList(PL.GetPrdUnit().Select(x => new { x.PrdUnitId, x.PrdUnitShortName }), "PrdUnitId", "PrdUnitShortName", lastissueMain.PrdUnitId);
            }
            else
            {
                ViewData["PrdUnitId"] = new SelectList(PL.GetPrdUnit().Where(x => x.comid == comid).Select(x => new { x.PrdUnitId, x.PrdUnitShortName }), "PrdUnitId", "PrdUnitShortName");

            }




            //return View(await gTRDBContext.ToListAsync());
            return View();
        }

        public partial class IssueResult
        {
            public int IssueMainId { get; set; }
            public string IssueNo { get; set; }

            public string IssueDate { get; set; }

            public string IssueRef { get; set; }

            public string Department { get; set; }

            public string PrdUnitName { get; set; }
            public string SRNo { get; set; }

            public string SRDate { get; set; }


            public string TypeName { get; set; }
            public string CurCode { get; set; }
            public float ConvertionRate { get; set; }
            public float TotalIssueValue { get; set; }
            public float? Deduction { get; set; }
            public float? NetIssueValue { get; set; }
            public string SectName { get; set; }

            //public DateTime GateInHouseDate { get; set; }
            //public DateTime? ExpectedReciveDate { get; set; }
            public string TermsAndCondition { get; set; }
            public string Remarks { get; set; }
            public string Status { get; set; }
            public string Store { get; set; }

            public string InNo { get; set; }
            public string InDate { get; set; }


            public List<ItemResult> ItemResultList { get; set; }

        }
        public class ItemResult
        {
            public string ItemName { get; set; }
            public string ItemCode { get; set; }
            public string IssueQty { get; set; }

            public string IssueRate { get; set; }

            public string IssueValue { get; set; }

        }
        public IActionResult Get(string UserList, string FromDate, string ToDate, string PrdUnitId, int isAll)
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

                UserPermission permission = HttpContext.Session.GetObject<UserPermission>("userpermission");

                if (permission.IsMedical)
                {
                    if (y.ToString().Length > 0)
                    {
                        var query = from e in db.IssueMain
                                    .Include(x => x.IssueSub)
                                    .ThenInclude(x => x.vProduct)
                                    .Include(x => x.PrdUnit)
                                    .Where(x => x.ComId == comid && x.PrdUnit.PrdUnitShortName.Contains("MED"))
                                    .OrderByDescending(x => x.IssueMainId)

                                        //let ImagePath = e.ImagePath + e.ProductId + e.FileExtension
                                    let ItemDesc = e.IssueSub != null ? e.IssueSub//Take(1).
                                    .Select(x => new ItemResult
                                    {
                                        ItemName = x.vProduct.ProductName,
                                        ItemCode = x.vProduct.ProductCode,
                                        IssueQty = x.IssueQty.ToString(),
                                        IssueRate = x.Rate.ToString(),
                                        IssueValue = x.TotalValue.ToString()
                                    })
                                    .Take(1).ToList() : null

                                    select new IssueResult
                                    {
                                        IssueMainId = e.IssueMainId,
                                        IssueNo = e.IssueNo,
                                        IssueDate = e.IssueDate.ToString("dd-MMM-yy"),

                                        IssueRef = e.IssueRef,
                                        Department = e.Department.DeptName,
                                        PrdUnitName = e.PrdUnit != null ? e.PrdUnit.PrdUnitName : "",

                                        SRNo = e.StoreRequisitionMain != null ? e.StoreRequisitionMain.SRNo : e.ManualSRRNo,
                                        SRDate = e.ManualSRRDate.HasValue ? e.ManualSRRDate.Value.ToString("dd-MMM-yy") : "[N/A]",

                                        //TypeName = e.PaymentType!=null?e.PaymentType.TypeName:"",
                                        CurCode = e.Currency != null ? e.Currency.CurCode : "",
                                        ConvertionRate = e.ConvertionRate,
                                        TotalIssueValue = e.TotalIssueValue,
                                        Deduction = e.Deduction,
                                        NetIssueValue = e.NetIssueValue,
                                        SectName = e.Section != null ? e.Section.SectName : "",

                                        ItemResultList = ItemDesc,
                                        //InNo = e.INNo,
                                        //InDate = e.INDate.HasValue ? e.INDate.Value.ToString("dd-MMM-yy") : "[N/A]",

                                        //ExpectedReciveDate = e.ExpectedReciveDate,
                                        //TermsAndCondition = e.TermsAndCondition,
                                        Status = e.Status.ToString() != "0" ? "Posted" : "Not Posted",
                                        Store = e.IsSubStore ? "Sub Store" : "Main Store",
                                        Remarks = e.Remarks
                                    };


                        var parser = new Parser<IssueResult>(Request.Form, query);

                        return Json(parser.Parse());

                    }
                    else
                    {

                        if (PrdUnitId != null && UserList != null)
                        {
                            var querytest = from e in db.IssueMain.Include(x => x.PrdUnit)
                                    .Where(x => x.ComId == comid && x.PrdUnit.PrdUnitShortName.Contains("MED"))
                            .Where(p => (p.IssueDate >= dtFrom && p.IssueDate <= dtTo))
                            //.Where(p => p.userid == UserList)
                            .Where(p => p.UserId.ToLower().Contains(UserList.ToLower()))
                            //.Where(p => p.CustomerId == int.Parse(PrdUnitId))

                            .OrderByDescending(x => x.IssueMainId)

                                            let ItemDesc = e.IssueSub != null ? e.IssueSub.Select(x => new ItemResult { ItemName = x.vProduct.ProductName, ItemCode = x.vProduct.ProductCode, IssueQty = x.IssueQty.ToString(), IssueRate = x.Rate.ToString(), IssueValue = x.TotalValue.ToString() }).ToList() : null


                                            //let ImagePath = e.ImagePath + e.ProductId + e.FileExtension
                                            select new IssueResult
                                            {
                                                IssueMainId = e.IssueMainId,
                                                IssueNo = e.IssueNo,
                                                IssueDate = e.IssueDate.ToString("dd-MMM-yy"),

                                                IssueRef = e.IssueRef,
                                                Department = e.Department.DeptName,
                                                PrdUnitName = e.PrdUnit != null ? e.PrdUnit.PrdUnitName : "",

                                                SRNo = e.StoreRequisitionMain != null ? e.StoreRequisitionMain.SRNo : e.ManualSRRNo,
                                                SRDate = e.ManualSRRDate.HasValue ? e.ManualSRRDate.Value.ToString("dd-MMM-yy") : "[N/A]",

                                                //TypeName = e.PaymentType!=null?e.PaymentType.TypeName:"",
                                                CurCode = e.Currency != null ? e.Currency.CurCode : "",
                                                ConvertionRate = e.ConvertionRate,
                                                TotalIssueValue = e.TotalIssueValue,
                                                Deduction = e.Deduction,
                                                NetIssueValue = e.NetIssueValue,
                                                SectName = e.Section != null ? e.Section.SectName : "",

                                                ItemResultList = ItemDesc,
                                                //InNo = e.INNo,
                                                //InDate = e.INDate.HasValue ? e.INDate.Value.ToString("dd-MMM-yy") : "[N/A]",

                                                //ExpectedReciveDate = e.ExpectedReciveDate,
                                                //TermsAndCondition = e.TermsAndCondition,
                                                Status = e.Status.ToString() != "0" ? "Posted" : "Not Posted",
                                                Store = e.IsSubStore ? "Sub Store" : "Main Store",
                                                Remarks = e.Remarks
                                            };

                            var parser = new Parser<IssueResult>(Request.Form, querytest);
                            return Json(parser.Parse());
                        }
                        else if (PrdUnitId != null && UserList == null)
                        {
                            var querytest = from e in db.IssueMain.Include(x => x.PrdUnit)
                                    .Where(x => x.ComId == comid && x.PrdUnit.PrdUnitShortName.Contains("MED"))
                            .Where(p => (p.IssueDate >= dtFrom && p.IssueDate <= dtTo))
                            //.Where(p => p.userid == UserList)
                            // .Where(p => p.CustomerId == int.Parse(PrdUnitId))

                            .OrderByDescending(x => x.IssueMainId)

                                            let ItemDesc = e.IssueSub != null ? e.IssueSub.Select(x => new ItemResult { ItemName = x.vProduct.ProductName, ItemCode = x.vProduct.ProductCode, IssueQty = x.IssueQty.ToString(), IssueRate = x.Rate.ToString(), IssueValue = x.TotalValue.ToString() }).ToList() : null

                                            //let ImagePath = e.ImagePath + e.ProductId + e.FileExtension
                                            select new IssueResult
                                            {
                                                IssueMainId = e.IssueMainId,
                                                IssueNo = e.IssueNo,
                                                IssueDate = e.IssueDate.ToString("dd-MMM-yy"),

                                                IssueRef = e.IssueRef,
                                                Department = e.Department.DeptName,
                                                PrdUnitName = e.PrdUnit != null ? e.PrdUnit.PrdUnitName : "",

                                                SRNo = e.StoreRequisitionMain != null ? e.StoreRequisitionMain.SRNo : e.ManualSRRNo,
                                                SRDate = e.ManualSRRDate.HasValue ? e.ManualSRRDate.Value.ToString("dd-MMM-yy") : "[N/A]",


                                                //TypeName = e.PaymentType!=null?e.PaymentType.TypeName:"",
                                                CurCode = e.Currency != null ? e.Currency.CurCode : "",
                                                ConvertionRate = e.ConvertionRate,
                                                TotalIssueValue = e.TotalIssueValue,
                                                Deduction = e.Deduction,
                                                NetIssueValue = e.NetIssueValue,
                                                SectName = e.Section != null ? e.Section.SectName : "",

                                                ItemResultList = ItemDesc,

                                                //InNo = e.INNo,
                                                //InDate = e.INDate.HasValue ? e.INDate.Value.ToString("dd-MMM-yy") : "[N/A]",

                                                //ExpectedReciveDate = e.ExpectedReciveDate,
                                                //TermsAndCondition = e.TermsAndCondition,
                                                Status = e.Status.ToString() != "0" ? "Posted" : "Not Posted",
                                                Store = e.IsSubStore ? "Sub Store" : "Main Store",
                                                Remarks = e.Remarks
                                            };

                            var parser = new Parser<IssueResult>(Request.Form, querytest);
                            return Json(parser.Parse());
                        }
                        else if (PrdUnitId == null && UserList != null)
                        {

                            var querytest = from e in db.IssueMain.Include(x => x.PrdUnit)
                                    .Where(x => x.ComId == comid && x.PrdUnit.PrdUnitShortName.Contains("MED"))
                            .Where(p => (p.IssueDate >= dtFrom && p.IssueDate <= dtTo))
                            //.Where(p => p.userid == UserList)
                            .Where(p => p.UserId.ToLower().Contains(UserList.ToLower()))


                            .OrderByDescending(x => x.IssueMainId)

                                            let ItemDesc = e.IssueSub != null ? e.IssueSub.Select(x => new ItemResult { ItemName = x.vProduct.ProductName, ItemCode = x.vProduct.ProductCode, IssueQty = x.IssueQty.ToString(), IssueRate = x.Rate.ToString(), IssueValue = x.TotalValue.ToString() }).ToList() : null


                                            //let ImagePath = e.ImagePath + e.ProductId + e.FileExtension
                                            select new IssueResult
                                            {
                                                IssueMainId = e.IssueMainId,
                                                IssueNo = e.IssueNo,
                                                IssueDate = e.IssueDate.ToString("dd-MMM-yy"),

                                                IssueRef = e.IssueRef,
                                                Department = e.Department.DeptName,
                                                PrdUnitName = e.PrdUnit != null ? e.PrdUnit.PrdUnitName : "",

                                                SRNo = e.StoreRequisitionMain != null ? e.StoreRequisitionMain.SRNo : e.ManualSRRNo,
                                                SRDate = e.ManualSRRDate.HasValue ? e.ManualSRRDate.Value.ToString("dd-MMM-yy") : "[N/A]",

                                                //TypeName = e.PaymentType!=null?e.PaymentType.TypeName:"",
                                                CurCode = e.Currency != null ? e.Currency.CurCode : "",
                                                ConvertionRate = e.ConvertionRate,
                                                TotalIssueValue = e.TotalIssueValue,
                                                Deduction = e.Deduction,
                                                NetIssueValue = e.NetIssueValue,
                                                SectName = e.Section != null ? e.Section.SectName : "",

                                                ItemResultList = ItemDesc,
                                                //InNo = e.INNo,
                                                //InDate = e.INDate.HasValue ? e.INDate.Value.ToString("dd-MMM-yy") : "[N/A]",

                                                //ExpectedReciveDate = e.ExpectedReciveDate,
                                                //TermsAndCondition = e.TermsAndCondition,
                                                Status = e.Status.ToString() != "0" ? "Posted" : "Not Posted",
                                                Store = e.IsSubStore ? "Sub Store" : "Main Store",
                                                Remarks = e.Remarks
                                            };
                            var parser = new Parser<IssueResult>(Request.Form, querytest);
                            return Json(parser.Parse());
                        }
                        else
                        {

                            var querytest = from e in db.IssueMain.Include(x => x.PrdUnit)
                                    .Where(x => x.ComId == comid && x.PrdUnit.PrdUnitShortName.Contains("MED"))
                            .Where(p => (p.IssueDate >= dtFrom && p.IssueDate <= dtTo))

                            .OrderByDescending(x => x.IssueMainId)

                                            let ItemDesc = e.IssueSub != null ? e.IssueSub.Select(x => new ItemResult { ItemName = x.vProduct.ProductName, ItemCode = x.vProduct.ProductCode, IssueQty = x.IssueQty.ToString(), IssueRate = x.Rate.ToString(), IssueValue = x.TotalValue.ToString() }).ToList() : null


                                            //let ImagePath = e.ImagePath + e.ProductId + e.FileExtension
                                            select new IssueResult
                                            {
                                                IssueMainId = e.IssueMainId,
                                                IssueNo = e.IssueNo,
                                                IssueDate = e.IssueDate.ToString("dd-MMM-yy"),

                                                IssueRef = e.IssueRef,
                                                Department = e.Department.DeptName,
                                                PrdUnitName = e.PrdUnit != null ? e.PrdUnit.PrdUnitName : "",

                                                SRNo = e.StoreRequisitionMain != null ? e.StoreRequisitionMain.SRNo : e.ManualSRRNo,
                                                SRDate = e.ManualSRRDate.HasValue ? e.ManualSRRDate.Value.ToString("dd-MMM-yy") : "[N/A]",


                                                //TypeName = e.PaymentType!=null?e.PaymentType.TypeName:"",
                                                CurCode = e.Currency != null ? e.Currency.CurCode : "",
                                                ConvertionRate = e.ConvertionRate,
                                                TotalIssueValue = e.TotalIssueValue,
                                                Deduction = e.Deduction,
                                                NetIssueValue = e.NetIssueValue,
                                                SectName = e.Section != null ? e.Section.SectName : "",

                                                ItemResultList = ItemDesc,

                                                //InNo = e.INNo,
                                                //InDate = e.INDate.HasValue ? e.INDate.Value.ToString("dd-MMM-yy") : "[N/A]",

                                                //ExpectedReciveDate = e.ExpectedReciveDate,
                                                //TermsAndCondition = e.TermsAndCondition,
                                                Status = e.Status.ToString() != "0" ? "Posted" : "Not Posted",
                                                Store = e.IsSubStore ? "Sub Store" : "Main Store",
                                                Remarks = e.Remarks
                                            };


                            var parser = new Parser<IssueResult>(Request.Form, querytest);
                            return Json(parser.Parse());
                        }

                    }
                }
                else if (permission.IsProduction)
                {
                    if (y.ToString().Length > 0)
                    {
                        var query = from e in db.IssueMain
                                    .Include(x => x.IssueSub)
                                    .ThenInclude(x => x.vProduct)
                                    .Include(x => x.PrdUnit)
                                    .Where(x => x.ComId == comid && x.PrdUnit.PrdUnitShortName.Contains("UN1") && x.PrdUnit.PrdUnitShortName.Contains("UN2"))
                                    .OrderByDescending(x => x.IssueMainId)

                                        //let ImagePath = e.ImagePath + e.ProductId + e.FileExtension
                                    let ItemDesc = e.IssueSub != null ? e.IssueSub//Take(1).
                                    .Select(x => new ItemResult
                                    {
                                        ItemName = x.vProduct.ProductName,
                                        ItemCode = x.vProduct.ProductCode,
                                        IssueQty = x.IssueQty.ToString(),
                                        IssueRate = x.Rate.ToString(),
                                        IssueValue = x.TotalValue.ToString()
                                    })
                                    .Take(1).ToList() : null

                                    select new IssueResult
                                    {
                                        IssueMainId = e.IssueMainId,
                                        IssueNo = e.IssueNo,
                                        IssueDate = e.IssueDate.ToString("dd-MMM-yy"),

                                        IssueRef = e.IssueRef,
                                        Department = e.Department.DeptName,
                                        PrdUnitName = e.PrdUnit != null ? e.PrdUnit.PrdUnitName : "",

                                        SRNo = e.StoreRequisitionMain != null ? e.StoreRequisitionMain.SRNo : e.ManualSRRNo,
                                        SRDate = e.ManualSRRDate.HasValue ? e.ManualSRRDate.Value.ToString("dd-MMM-yy") : "[N/A]",

                                        //TypeName = e.PaymentType!=null?e.PaymentType.TypeName:"",
                                        CurCode = e.Currency != null ? e.Currency.CurCode : "",
                                        ConvertionRate = e.ConvertionRate,
                                        TotalIssueValue = e.TotalIssueValue,
                                        Deduction = e.Deduction,
                                        NetIssueValue = e.NetIssueValue,
                                        SectName = e.Section != null ? e.Section.SectName : "",

                                        ItemResultList = ItemDesc,
                                        //InNo = e.INNo,
                                        //InDate = e.INDate.HasValue ? e.INDate.Value.ToString("dd-MMM-yy") : "[N/A]",

                                        //ExpectedReciveDate = e.ExpectedReciveDate,
                                        //TermsAndCondition = e.TermsAndCondition,
                                        Status = e.Status.ToString() != "0" ? "Posted" : "Not Posted",
                                        Store = e.IsSubStore ? "Sub Store" : "Main Store",
                                        Remarks = e.Remarks
                                    };


                        var parser = new Parser<IssueResult>(Request.Form, query);

                        return Json(parser.Parse());

                    }
                    else
                    {

                        if (PrdUnitId != null && UserList != null)
                        {
                            var querytest = from e in db.IssueMain.Include(x => x.PrdUnit)
                                    .Where(x => x.ComId == comid && x.PrdUnit.PrdUnitShortName.Contains("UN1") || x.PrdUnit.PrdUnitShortName.Contains("UN2"))
                            .Where(p => (p.IssueDate >= dtFrom && p.IssueDate <= dtTo))
                            //.Where(p => p.userid == UserList)
                            .Where(p => p.UserId.ToLower().Contains(UserList.ToLower()))
                            //.Where(p => p.CustomerId == int.Parse(PrdUnitId))

                            .OrderByDescending(x => x.IssueMainId)

                                            let ItemDesc = e.IssueSub != null ? e.IssueSub.Select(x => new ItemResult { ItemName = x.vProduct.ProductName, ItemCode = x.vProduct.ProductCode, IssueQty = x.IssueQty.ToString(), IssueRate = x.Rate.ToString(), IssueValue = x.TotalValue.ToString() }).ToList() : null


                                            //let ImagePath = e.ImagePath + e.ProductId + e.FileExtension
                                            select new IssueResult
                                            {
                                                IssueMainId = e.IssueMainId,
                                                IssueNo = e.IssueNo,
                                                IssueDate = e.IssueDate.ToString("dd-MMM-yy"),

                                                IssueRef = e.IssueRef,
                                                Department = e.Department.DeptName,
                                                PrdUnitName = e.PrdUnit != null ? e.PrdUnit.PrdUnitName : "",

                                                SRNo = e.StoreRequisitionMain != null ? e.StoreRequisitionMain.SRNo : e.ManualSRRNo,
                                                SRDate = e.ManualSRRDate.HasValue ? e.ManualSRRDate.Value.ToString("dd-MMM-yy") : "[N/A]",

                                                //TypeName = e.PaymentType!=null?e.PaymentType.TypeName:"",
                                                CurCode = e.Currency != null ? e.Currency.CurCode : "",
                                                ConvertionRate = e.ConvertionRate,
                                                TotalIssueValue = e.TotalIssueValue,
                                                Deduction = e.Deduction,
                                                NetIssueValue = e.NetIssueValue,
                                                SectName = e.Section != null ? e.Section.SectName : "",

                                                ItemResultList = ItemDesc,
                                                //InNo = e.INNo,
                                                //InDate = e.INDate.HasValue ? e.INDate.Value.ToString("dd-MMM-yy") : "[N/A]",

                                                //ExpectedReciveDate = e.ExpectedReciveDate,
                                                //TermsAndCondition = e.TermsAndCondition,
                                                Status = e.Status.ToString() != "0" ? "Posted" : "Not Posted",
                                                Store = e.IsSubStore ? "Sub Store" : "Main Store",
                                                Remarks = e.Remarks
                                            };

                            var parser = new Parser<IssueResult>(Request.Form, querytest);
                            return Json(parser.Parse());
                        }
                        else if (PrdUnitId != null && UserList == null)
                        {
                            var querytest = from e in db.IssueMain.Include(x => x.PrdUnit)
                                    .Where(x => x.ComId == comid && x.PrdUnit.PrdUnitShortName.Contains("UN1") || x.PrdUnit.PrdUnitShortName.Contains("UN2"))
                            .Where(p => (p.IssueDate >= dtFrom && p.IssueDate <= dtTo))
                            //.Where(p => p.userid == UserList)
                            // .Where(p => p.CustomerId == int.Parse(PrdUnitId))

                            .OrderByDescending(x => x.IssueMainId)

                                            let ItemDesc = e.IssueSub != null ? e.IssueSub.Select(x => new ItemResult { ItemName = x.vProduct.ProductName, ItemCode = x.vProduct.ProductCode, IssueQty = x.IssueQty.ToString(), IssueRate = x.Rate.ToString(), IssueValue = x.TotalValue.ToString() }).ToList() : null

                                            //let ImagePath = e.ImagePath + e.ProductId + e.FileExtension
                                            select new IssueResult
                                            {
                                                IssueMainId = e.IssueMainId,
                                                IssueNo = e.IssueNo,
                                                IssueDate = e.IssueDate.ToString("dd-MMM-yy"),

                                                IssueRef = e.IssueRef,
                                                Department = e.Department.DeptName,
                                                PrdUnitName = e.PrdUnit != null ? e.PrdUnit.PrdUnitName : "",

                                                SRNo = e.StoreRequisitionMain != null ? e.StoreRequisitionMain.SRNo : e.ManualSRRNo,
                                                SRDate = e.ManualSRRDate.HasValue ? e.ManualSRRDate.Value.ToString("dd-MMM-yy") : "[N/A]",


                                                //TypeName = e.PaymentType!=null?e.PaymentType.TypeName:"",
                                                CurCode = e.Currency != null ? e.Currency.CurCode : "",
                                                ConvertionRate = e.ConvertionRate,
                                                TotalIssueValue = e.TotalIssueValue,
                                                Deduction = e.Deduction,
                                                NetIssueValue = e.NetIssueValue,
                                                SectName = e.Section != null ? e.Section.SectName : "",

                                                ItemResultList = ItemDesc,

                                                //InNo = e.INNo,
                                                //InDate = e.INDate.HasValue ? e.INDate.Value.ToString("dd-MMM-yy") : "[N/A]",

                                                //ExpectedReciveDate = e.ExpectedReciveDate,
                                                //TermsAndCondition = e.TermsAndCondition,
                                                Status = e.Status.ToString() != "0" ? "Posted" : "Not Posted",
                                                Store = e.IsSubStore ? "Sub Store" : "Main Store",
                                                Remarks = e.Remarks
                                            };

                            var parser = new Parser<IssueResult>(Request.Form, querytest);
                            return Json(parser.Parse());
                        }
                        else if (PrdUnitId == null && UserList != null)
                        {

                            var querytest = from e in db.IssueMain.Include(x => x.PrdUnit)
                                    .Where(x => x.ComId == comid && x.PrdUnit.PrdUnitShortName.Contains("UN1") || x.PrdUnit.PrdUnitShortName.Contains("UN2"))
                            .Where(p => (p.IssueDate >= dtFrom && p.IssueDate <= dtTo))
                            //.Where(p => p.userid == UserList)
                            .Where(p => p.UserId.ToLower().Contains(UserList.ToLower()))


                            .OrderByDescending(x => x.IssueMainId)

                                            let ItemDesc = e.IssueSub != null ? e.IssueSub.Select(x => new ItemResult { ItemName = x.vProduct.ProductName, ItemCode = x.vProduct.ProductCode, IssueQty = x.IssueQty.ToString(), IssueRate = x.Rate.ToString(), IssueValue = x.TotalValue.ToString() }).ToList() : null


                                            //let ImagePath = e.ImagePath + e.ProductId + e.FileExtension
                                            select new IssueResult
                                            {
                                                IssueMainId = e.IssueMainId,
                                                IssueNo = e.IssueNo,
                                                IssueDate = e.IssueDate.ToString("dd-MMM-yy"),

                                                IssueRef = e.IssueRef,
                                                Department = e.Department.DeptName,
                                                PrdUnitName = e.PrdUnit != null ? e.PrdUnit.PrdUnitName : "",

                                                SRNo = e.StoreRequisitionMain != null ? e.StoreRequisitionMain.SRNo : e.ManualSRRNo,
                                                SRDate = e.ManualSRRDate.HasValue ? e.ManualSRRDate.Value.ToString("dd-MMM-yy") : "[N/A]",

                                                //TypeName = e.PaymentType!=null?e.PaymentType.TypeName:"",
                                                CurCode = e.Currency != null ? e.Currency.CurCode : "",
                                                ConvertionRate = e.ConvertionRate,
                                                TotalIssueValue = e.TotalIssueValue,
                                                Deduction = e.Deduction,
                                                NetIssueValue = e.NetIssueValue,
                                                SectName = e.Section != null ? e.Section.SectName : "",

                                                ItemResultList = ItemDesc,
                                                //InNo = e.INNo,
                                                //InDate = e.INDate.HasValue ? e.INDate.Value.ToString("dd-MMM-yy") : "[N/A]",

                                                //ExpectedReciveDate = e.ExpectedReciveDate,
                                                //TermsAndCondition = e.TermsAndCondition,
                                                Status = e.Status.ToString() != "0" ? "Posted" : "Not Posted",
                                                Store = e.IsSubStore ? "Sub Store" : "Main Store",
                                                Remarks = e.Remarks
                                            };
                            var parser = new Parser<IssueResult>(Request.Form, querytest);
                            return Json(parser.Parse());
                        }
                        else
                        {

                            var querytest = from e in db.IssueMain.Include(x => x.PrdUnit)
                                    .Where(x => x.ComId == comid && x.PrdUnit.PrdUnitShortName.Contains("UN1") || x.PrdUnit.PrdUnitShortName.Contains("UN2"))
                            .Where(p => (p.IssueDate >= dtFrom && p.IssueDate <= dtTo))

                            .OrderByDescending(x => x.IssueMainId)

                                            let ItemDesc = e.IssueSub != null ? e.IssueSub.Select(x => new ItemResult { ItemName = x.vProduct.ProductName, ItemCode = x.vProduct.ProductCode, IssueQty = x.IssueQty.ToString(), IssueRate = x.Rate.ToString(), IssueValue = x.TotalValue.ToString() }).ToList() : null


                                            //let ImagePath = e.ImagePath + e.ProductId + e.FileExtension
                                            select new IssueResult
                                            {
                                                IssueMainId = e.IssueMainId,
                                                IssueNo = e.IssueNo,
                                                IssueDate = e.IssueDate.ToString("dd-MMM-yy"),

                                                IssueRef = e.IssueRef,
                                                Department = e.Department.DeptName,
                                                PrdUnitName = e.PrdUnit != null ? e.PrdUnit.PrdUnitName : "",

                                                SRNo = e.StoreRequisitionMain != null ? e.StoreRequisitionMain.SRNo : e.ManualSRRNo,
                                                SRDate = e.ManualSRRDate.HasValue ? e.ManualSRRDate.Value.ToString("dd-MMM-yy") : "[N/A]",


                                                //TypeName = e.PaymentType!=null?e.PaymentType.TypeName:"",
                                                CurCode = e.Currency != null ? e.Currency.CurCode : "",
                                                ConvertionRate = e.ConvertionRate,
                                                TotalIssueValue = e.TotalIssueValue,
                                                Deduction = e.Deduction,
                                                NetIssueValue = e.NetIssueValue,
                                                SectName = e.Section != null ? e.Section.SectName : "",

                                                ItemResultList = ItemDesc,

                                                //InNo = e.INNo,
                                                //InDate = e.INDate.HasValue ? e.INDate.Value.ToString("dd-MMM-yy") : "[N/A]",

                                                //ExpectedReciveDate = e.ExpectedReciveDate,
                                                //TermsAndCondition = e.TermsAndCondition,
                                                Status = e.Status.ToString() != "0" ? "Posted" : "Not Posted",
                                                Store = e.IsSubStore ? "Sub Store" : "Main Store",
                                                Remarks = e.Remarks
                                            };


                            var parser = new Parser<IssueResult>(Request.Form, querytest);
                            return Json(parser.Parse());
                        }

                    }
                }
                else
                {
                    if (y.ToString().Length > 0)
                    {


                        var query = from e in db.IssueMain
                                    .Include(x => x.IssueSub)
                                    .ThenInclude(x => x.vProduct)
                                    .Where(x => x.ComId == comid)
                                    .OrderByDescending(x => x.IssueMainId)
                                        //let ImagePath = e.ImagePath + e.ProductId + e.FileExtension
                                    let ItemDesc = e.IssueSub != null ? e.IssueSub//Take(1).
                                    .Select(x => new ItemResult
                                    {
                                        ItemName = x.vProduct.ProductName,
                                        ItemCode = x.vProduct.ProductCode,
                                        IssueQty = x.IssueQty.ToString(),
                                        IssueRate = x.Rate.ToString(),
                                        IssueValue = x.TotalValue.ToString()
                                    })
                                    .Take(1).ToList() : null

                                    select new IssueResult
                                    {
                                        IssueMainId = e.IssueMainId,
                                        IssueNo = e.IssueNo,
                                        IssueDate = e.IssueDate.ToString("dd-MMM-yy"),

                                        IssueRef = e.IssueRef,
                                        Department = e.Department.DeptName,
                                        PrdUnitName = e.PrdUnit != null ? e.PrdUnit.PrdUnitName : "",

                                        SRNo = e.StoreRequisitionMain != null ? e.StoreRequisitionMain.SRNo : e.ManualSRRNo,
                                        SRDate = e.ManualSRRDate.HasValue ? e.ManualSRRDate.Value.ToString("dd-MMM-yy") : "[N/A]",

                                        //TypeName = e.PaymentType!=null?e.PaymentType.TypeName:"",
                                        CurCode = e.Currency != null ? e.Currency.CurCode : "",
                                        ConvertionRate = e.ConvertionRate,
                                        TotalIssueValue = e.TotalIssueValue,
                                        Deduction = e.Deduction,
                                        NetIssueValue = e.NetIssueValue,
                                        SectName = e.Section != null ? e.Section.SectName : "",

                                        ItemResultList = ItemDesc,
                                        //InNo = e.INNo,
                                        //InDate = e.INDate.HasValue ? e.INDate.Value.ToString("dd-MMM-yy") : "[N/A]",

                                        //ExpectedReciveDate = e.ExpectedReciveDate,
                                        //TermsAndCondition = e.TermsAndCondition,
                                        Status = e.Status.ToString() != "0" ? "Posted" : "Not Posted",
                                        Store = e.IsSubStore ? "Sub Store" : "Main Store",
                                        Remarks = e.Remarks
                                    };


                        var parser = new Parser<IssueResult>(Request.Form, query);

                        return Json(parser.Parse());

                    }
                    else
                    {


                        if (PrdUnitId != null && UserList != null)
                        {
                            var querytest = from e in db.IssueMain
                            .Where(x => x.ComId == comid)
                            .Where(p => (p.IssueDate >= dtFrom && p.IssueDate <= dtTo))
                            //.Where(p => p.userid == UserList)
                            .Where(p => p.UserId.ToLower().Contains(UserList.ToLower()))
                            //.Where(p => p.CustomerId == int.Parse(PrdUnitId))

                            .OrderByDescending(x => x.IssueMainId)

                                            let ItemDesc = e.IssueSub != null ? e.IssueSub.Select(x => new ItemResult { ItemName = x.vProduct.ProductName, ItemCode = x.vProduct.ProductCode, IssueQty = x.IssueQty.ToString(), IssueRate = x.Rate.ToString(), IssueValue = x.TotalValue.ToString() }).ToList() : null


                                            //let ImagePath = e.ImagePath + e.ProductId + e.FileExtension
                                            select new IssueResult
                                            {
                                                IssueMainId = e.IssueMainId,
                                                IssueNo = e.IssueNo,
                                                IssueDate = e.IssueDate.ToString("dd-MMM-yy"),

                                                IssueRef = e.IssueRef,
                                                Department = e.Department.DeptName,
                                                PrdUnitName = e.PrdUnit != null ? e.PrdUnit.PrdUnitName : "",

                                                SRNo = e.StoreRequisitionMain != null ? e.StoreRequisitionMain.SRNo : e.ManualSRRNo,
                                                SRDate = e.ManualSRRDate.HasValue ? e.ManualSRRDate.Value.ToString("dd-MMM-yy") : "[N/A]",

                                                //TypeName = e.PaymentType!=null?e.PaymentType.TypeName:"",
                                                CurCode = e.Currency != null ? e.Currency.CurCode : "",
                                                ConvertionRate = e.ConvertionRate,
                                                TotalIssueValue = e.TotalIssueValue,
                                                Deduction = e.Deduction,
                                                NetIssueValue = e.NetIssueValue,
                                                SectName = e.Section != null ? e.Section.SectName : "",

                                                ItemResultList = ItemDesc,
                                                //InNo = e.INNo,
                                                //InDate = e.INDate.HasValue ? e.INDate.Value.ToString("dd-MMM-yy") : "[N/A]",

                                                //ExpectedReciveDate = e.ExpectedReciveDate,
                                                //TermsAndCondition = e.TermsAndCondition,
                                                Status = e.Status.ToString() != "0" ? "Posted" : "Not Posted",
                                                Store = e.IsSubStore ? "Sub Store" : "Main Store",
                                                Remarks = e.Remarks
                                            };

                            var parser = new Parser<IssueResult>(Request.Form, querytest);
                            return Json(parser.Parse());
                        }
                        else if (PrdUnitId != null && UserList == null)
                        {
                            var querytest = from e in db.IssueMain
                            .Where(x => x.ComId == comid)
                            .Where(p => (p.IssueDate >= dtFrom && p.IssueDate <= dtTo))
                            //.Where(p => p.userid == UserList)
                            // .Where(p => p.CustomerId == int.Parse(PrdUnitId))

                            .OrderByDescending(x => x.IssueMainId)

                                            let ItemDesc = e.IssueSub != null ? e.IssueSub.Select(x => new ItemResult { ItemName = x.vProduct.ProductName, ItemCode = x.vProduct.ProductCode, IssueQty = x.IssueQty.ToString(), IssueRate = x.Rate.ToString(), IssueValue = x.TotalValue.ToString() }).ToList() : null

                                            //let ImagePath = e.ImagePath + e.ProductId + e.FileExtension
                                            select new IssueResult
                                            {
                                                IssueMainId = e.IssueMainId,
                                                IssueNo = e.IssueNo,
                                                IssueDate = e.IssueDate.ToString("dd-MMM-yy"),

                                                IssueRef = e.IssueRef,
                                                Department = e.Department.DeptName,
                                                PrdUnitName = e.PrdUnit != null ? e.PrdUnit.PrdUnitName : "",

                                                SRNo = e.StoreRequisitionMain != null ? e.StoreRequisitionMain.SRNo : e.ManualSRRNo,
                                                SRDate = e.ManualSRRDate.HasValue ? e.ManualSRRDate.Value.ToString("dd-MMM-yy") : "[N/A]",


                                                //TypeName = e.PaymentType!=null?e.PaymentType.TypeName:"",
                                                CurCode = e.Currency != null ? e.Currency.CurCode : "",
                                                ConvertionRate = e.ConvertionRate,
                                                TotalIssueValue = e.TotalIssueValue,
                                                Deduction = e.Deduction,
                                                NetIssueValue = e.NetIssueValue,
                                                SectName = e.Section != null ? e.Section.SectName : "",

                                                ItemResultList = ItemDesc,

                                                //InNo = e.INNo,
                                                //InDate = e.INDate.HasValue ? e.INDate.Value.ToString("dd-MMM-yy") : "[N/A]",

                                                //ExpectedReciveDate = e.ExpectedReciveDate,
                                                //TermsAndCondition = e.TermsAndCondition,
                                                Status = e.Status.ToString() != "0" ? "Posted" : "Not Posted",
                                                Store = e.IsSubStore ? "Sub Store" : "Main Store",
                                                Remarks = e.Remarks
                                            };

                            var parser = new Parser<IssueResult>(Request.Form, querytest);
                            return Json(parser.Parse());
                        }
                        else if (PrdUnitId == null && UserList != null)
                        {

                            var querytest = from e in db.IssueMain
                            .Where(x => x.ComId == comid)
                            .Where(p => (p.IssueDate >= dtFrom && p.IssueDate <= dtTo))
                            //.Where(p => p.userid == UserList)
                            .Where(p => p.UserId.ToLower().Contains(UserList.ToLower()))


                            .OrderByDescending(x => x.IssueMainId)

                                            let ItemDesc = e.IssueSub != null ? e.IssueSub.Select(x => new ItemResult { ItemName = x.vProduct.ProductName, ItemCode = x.vProduct.ProductCode, IssueQty = x.IssueQty.ToString(), IssueRate = x.Rate.ToString(), IssueValue = x.TotalValue.ToString() }).ToList() : null


                                            //let ImagePath = e.ImagePath + e.ProductId + e.FileExtension
                                            select new IssueResult
                                            {
                                                IssueMainId = e.IssueMainId,
                                                IssueNo = e.IssueNo,
                                                IssueDate = e.IssueDate.ToString("dd-MMM-yy"),

                                                IssueRef = e.IssueRef,
                                                Department = e.Department.DeptName,
                                                PrdUnitName = e.PrdUnit != null ? e.PrdUnit.PrdUnitName : "",

                                                SRNo = e.StoreRequisitionMain != null ? e.StoreRequisitionMain.SRNo : e.ManualSRRNo,
                                                SRDate = e.ManualSRRDate.HasValue ? e.ManualSRRDate.Value.ToString("dd-MMM-yy") : "[N/A]",

                                                //TypeName = e.PaymentType!=null?e.PaymentType.TypeName:"",
                                                CurCode = e.Currency != null ? e.Currency.CurCode : "",
                                                ConvertionRate = e.ConvertionRate,
                                                TotalIssueValue = e.TotalIssueValue,
                                                Deduction = e.Deduction,
                                                NetIssueValue = e.NetIssueValue,
                                                SectName = e.Section != null ? e.Section.SectName : "",

                                                ItemResultList = ItemDesc,
                                                //InNo = e.INNo,
                                                //InDate = e.INDate.HasValue ? e.INDate.Value.ToString("dd-MMM-yy") : "[N/A]",

                                                //ExpectedReciveDate = e.ExpectedReciveDate,
                                                //TermsAndCondition = e.TermsAndCondition,
                                                Status = e.Status.ToString() != "0" ? "Posted" : "Not Posted",
                                                Store = e.IsSubStore ? "Sub Store" : "Main Store",
                                                Remarks = e.Remarks
                                            };
                            var parser = new Parser<IssueResult>(Request.Form, querytest);
                            return Json(parser.Parse());
                        }
                        else
                        {

                            var querytest = from e in db.IssueMain
                            .Where(x => x.ComId == comid)
                            .Where(p => (p.IssueDate >= dtFrom && p.IssueDate <= dtTo))

                            .OrderByDescending(x => x.IssueMainId)

                                            let ItemDesc = e.IssueSub != null ? e.IssueSub.Select(x => new ItemResult { ItemName = x.vProduct.ProductName, ItemCode = x.vProduct.ProductCode, IssueQty = x.IssueQty.ToString(), IssueRate = x.Rate.ToString(), IssueValue = x.TotalValue.ToString() }).ToList() : null


                                            //let ImagePath = e.ImagePath + e.ProductId + e.FileExtension
                                            select new IssueResult
                                            {
                                                IssueMainId = e.IssueMainId,
                                                IssueNo = e.IssueNo,
                                                IssueDate = e.IssueDate.ToString("dd-MMM-yy"),

                                                IssueRef = e.IssueRef,
                                                Department = e.Department.DeptName,
                                                PrdUnitName = e.PrdUnit != null ? e.PrdUnit.PrdUnitName : "",

                                                SRNo = e.StoreRequisitionMain != null ? e.StoreRequisitionMain.SRNo : e.ManualSRRNo,
                                                SRDate = e.ManualSRRDate.HasValue ? e.ManualSRRDate.Value.ToString("dd-MMM-yy") : "[N/A]",


                                                //TypeName = e.PaymentType!=null?e.PaymentType.TypeName:"",
                                                CurCode = e.Currency != null ? e.Currency.CurCode : "",
                                                ConvertionRate = e.ConvertionRate,
                                                TotalIssueValue = e.TotalIssueValue,
                                                Deduction = e.Deduction,
                                                NetIssueValue = e.NetIssueValue,
                                                SectName = e.Section != null ? e.Section.SectName : "",

                                                ItemResultList = ItemDesc,

                                                //InNo = e.INNo,
                                                //InDate = e.INDate.HasValue ? e.INDate.Value.ToString("dd-MMM-yy") : "[N/A]",

                                                //ExpectedReciveDate = e.ExpectedReciveDate,
                                                //TermsAndCondition = e.TermsAndCondition,
                                                Status = e.Status.ToString() != "0" ? "Posted" : "Not Posted",
                                                Store = e.IsSubStore ? "Sub Store" : "Main Store",
                                                Remarks = e.Remarks
                                            };


                            var parser = new Parser<IssueResult>(Request.Form, querytest);
                            return Json(parser.Parse());
                        }

                    }
                }



            }
            catch (Exception ex)
            {
                return Json(new { Success = "0", error = ex.Message });
                //throw ex;
            }

        }


        // GET: Issues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issueMain = await db.IssueMain
                .Include(i => i.Section)
                .Include(i => i.Currency)
                //.Include(i => i.PaymentType)
                .Include(i => i.PrdUnit)
                .Include(i => i.StoreRequisitionMain)
                //.Include(i => i.Supplier)
                .FirstOrDefaultAsync(m => m.IssueMainId == id);
            if (issueMain == null)
            {
                return NotFound();
            }

            return View(issueMain);
        }

        public async Task<IActionResult> GetCurrencyRate(int id)
        {
            var CurrencyRate = db.Currency.Where(c => c.CurrencyId == id);
            return Json(CurrencyRate);
        }

        public IActionResult GetDepartmentByStoreReqId(int id)
        {
            var Department = db.StoreRequisitionMain.Where(p => p.StoreReqId == id).Select(p => new
            {
                DeptName = p.Department.DeptName,
                SectId = p.SectId,
                DeptId = p.DepartmentId,
                PrdUnitId = p.PrdUnitId,
                SRNo = p.SRNo,
                INNo = p.INNo,
                INDate = p.INDate,
                ReqRef = p.ReqRef,
                Remarks = p.Remarks,
                ReqDate = p.ReqDate


            }).FirstOrDefault();
            return Json(Department);
        }

        public JsonResult GetStoreRequisitionDataById(int? StoreReqId)
        {
            try
            {



                //List<PurchaseOrderDetailsModel> purchaseRequisitionMain = new List<PurchaseOrderDetailsModel>();


                var comid = HttpContext.Session.GetString("comid");
                var userid = HttpContext.Session.GetString("userid");

                var quary = $"EXEC IssueDetailsInformation '{comid}','{userid}',{StoreReqId}";

                SqlParameter[] parameters = new SqlParameter[3];

                parameters[0] = new SqlParameter("@comid", comid);
                parameters[1] = new SqlParameter("@userid", userid);
                parameters[2] = new SqlParameter("@StoreReqId", StoreReqId);
                //parameters[3] = new SqlParameter("@IsSubStore", false);
                List<IssueDetailsModel> IssueDetailsInformation = Helper.ExecProcMapTList<IssueDetailsModel>("IssueDetailsInformation", parameters);

                return Json(IssueDetailsInformation);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public JsonResult GetSubStoreRequisitionDataById(int? StoreReqId)
        {
            try
            {
                //List<PurchaseOrderDetailsModel> purchaseRequisitionMain = new List<PurchaseOrderDetailsModel>();


                var comid = HttpContext.Session.GetString("comid");
                var userid = HttpContext.Session.GetString("userid");

                var quary = $"EXEC IssueDetailsInformation '{comid}','{userid}',{StoreReqId}";

                SqlParameter[] parameters = new SqlParameter[4];

                parameters[0] = new SqlParameter("@comid", comid);
                parameters[1] = new SqlParameter("@userid", userid);
                parameters[2] = new SqlParameter("@StoreReqId", StoreReqId);
                parameters[3] = new SqlParameter("@IsSubStore", true);
                List<IssueDetailsModel> IssueDetailsInformation = Helper.ExecProcMapTList<IssueDetailsModel>("IssueDetailsInformation", parameters);

                return Json(IssueDetailsInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public class IssueDetailsModel
        {
            public int? IssueMainId { get; set; }
            public int? IssueSubId { get; set; }
            public int? ProductId { get; set; }
            public int? UnitId { get; set; }
            public string SLNo { get; set; }
            public string ProductName { get; set; }
            public string UnitName { get; set; }
            public decimal? StoreReqQty { get; set; }
            public decimal? RequisitionQty { get; set; }
            public decimal? RemainingReqQty { get; set; }
            public decimal? StoreQty { get; set; }
            public decimal? Rate { get; set; }
            public decimal? TotalValue { get; set; }
            public string Remarks { get; set; }
            public int? StoreReqId { get; set; }
            public int? StoreReqSubId { get; set; }
        }

        // GET: Issues/Create
        public IActionResult Create(bool isSubStore, bool? isRateCheck)
        {
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");
            var pcname = HttpContext.Session.GetString("pcname");

            IssueMain issuereq = new IssueMain();
            issuereq.IssueDate = DateTime.Now.Date;
            issuereq.INDate = DateTime.Now.Date;
            ViewBag.Title = "Create";
            ViewBag.IsSubStore = isSubStore;
            ViewBag.IsRateCheck = isRateCheck;

            // set products in session
            POS.SetProductInSession();

            if (isSubStore)
            {
                issuereq.IsSubStore = true;

                ViewData["SectId"] = new SelectList(db.Cat_Section.Where(x => x.ComId == comid), "SectId", "SectName");
                ViewData["DeptId"] = new SelectList(db.Cat_Department.Where(x => x.ComId == comid), "DeptId", "DeptName");
                //ViewData["SubSectId"] = new SelectList(db.Cat_SubSection.Where(x => x.ComId == comid), "SubSectId", "SubSectName");
                ViewData["CurrencyId"] = new SelectList(db.Currency.OrderByDescending(x => x.isDefault).OrderByDescending(x => x.isDefault), "CurrencyId", "CurCode");
                ViewData["PaymentTypeId"] = new SelectList(db.PaymentTypes, "PaymentTypeId", "TypeName");
                ViewData["PrdUnitId"] = new SelectList(PL.GetPrdUnit(), "PrdUnitId", "PrdUnitShortName");

                var storeRequisitions = PL.GetSRR().Where(x => x.Complete == 0 && x.Status > 0 && x.IsSubStore == true)
                    .Select(s => new { Value = s.StoreReqId, Text = s.SRNo + " [S.S.]" });

                ViewData["StoreReqId"] = new SelectList(storeRequisitions, "Value", "Text");

                //Need to change himu

                ViewData["WarehouseId"] = new SelectList(PL.GetWarehouse().Where(x => x.comid == comid && x.WarehouseId != 0 && x.WhType == "L" && x.ParentId != null && x.IsSubWarehouse == true), "WarehouseId", "WhShortName");
                this.ViewBag.WarehouseList = PL.GetWarehouse().Where(x => x.WarehouseId > 0 && x.WhType == "L" && x.IsSubWarehouse == true);
                return View(issuereq);
            }
            else
            {
                issuereq.IsSubStore = false;

                ViewData["SectId"] = new SelectList(db.Cat_Section.Where(x => x.ComId == comid), "SectId", "SectName");
                ViewData["DeptId"] = new SelectList(db.Cat_Department.Where(x => x.ComId == comid), "DeptId", "DeptName");
                //ViewData["SubSectId"] = new SelectList(db.Cat_SubSection.Where(x => x.ComId == comid), "SubSectId", "SubSectName");
                ViewData["CurrencyId"] = new SelectList(db.Currency.OrderByDescending(x => x.isDefault), "CurrencyId", "CurCode");
                ViewData["PaymentTypeId"] = new SelectList(db.PaymentTypes, "PaymentTypeId", "TypeName");
                ViewData["PrdUnitId"] = new SelectList(PL.GetPrdUnit(), "PrdUnitId", "PrdUnitShortName");
                ViewData["StoreReqId"] = new SelectList(PL.GetSRR().Where(x => x.Complete == 0 && x.Status > 0), "StoreReqId", "SRNo"); /* && x.IsSubStore == false*/
                ViewData["WarehouseId"] = new SelectList(PL.GetWarehouse().Where(x => x.WarehouseId != 0 && x.WhType == "L" && x.ParentId != null), "WarehouseId", "WhShortName");
                this.ViewBag.WarehouseList = PL.GetWarehouse().Where(x => x.WarehouseId != 0 && x.WhType == "L");
                return View(issuereq);
            }


            //ViewBag.Title = "Create";
            //ViewData["SectId"] = new SelectList(db.Section.Where(x => x.ComId == comid), "SectId", "SectName");
            //ViewData["CurrencyId"] = new SelectList(db.Currency, "CurrencyId", "CurCode");
            //ViewData["PaymentTypeId"] = new SelectList(db.PaymentTypes, "PaymentTypeId", "TypeName");
            //ViewData["PrdUnitId"] = new SelectList(db.PrdUnits.Where(x => x.comid == comid), "PrdUnitId", "PrdUnitName");
            //ViewData["StoreReqId"] = new SelectList(db.StoreRequisitionMain.Where(x => x.ComId == comid && x.Complete == 0 && x.Status > 0 && x.IsSubStore == false), "StoreReqId", "SRNo");
            //ViewData["WarehouseId"] = new SelectList(db.Warehouses.Where(x => x.comid == comid && x.WhType == "L" && x.ParentId != null), "WarehouseId", "WhShortName");
            //this.ViewBag.WarehouseList = db.Warehouses.Where(x => x.comid == comid && x.WhType == "L");
            //ViewData["SupplierId"] = new SelectList(db.Suppliers.Where(x => x.comid == comid), "SupplierId", "SupplierName");
            //return View(issuereq);
        }



        public IActionResult DirectIssue(bool isSubStore)
        {

            var comid = (HttpContext.Session.GetString("comid"));
            var userid = (HttpContext.Session.GetString("userid"));
            IssueMain issueMain = new IssueMain();


            var lastissueMain = db.IssueMain.Where(x => x.ComId == comid && x.UserId == userid).OrderByDescending(x => x.IssueMainId).FirstOrDefault();

            if (lastissueMain != null)
            {

                issueMain.IssueDate = lastissueMain.IssueDate;
                issueMain.ManualSRRDate = lastissueMain.ManualSRRDate;
                ViewData["PrdUnitId"] = new SelectList(PL.GetPrdUnit().Select(x => new { x.PrdUnitId, x.PrdUnitShortName }), "PrdUnitId", "PrdUnitShortName", lastissueMain.PrdUnitId);



            }
            else
            {

                issueMain.IssueDate = DateTime.Now.Date;
                issueMain.INDate = DateTime.Now.Date;
                issueMain.ManualSRRDate = DateTime.Now.Date;
                ViewData["PrdUnitId"] = new SelectList(PL.GetPrdUnit().Select(x => new { x.PrdUnitId, x.PrdUnitShortName }), "PrdUnitId", "PrdUnitShortName");


            }


            ViewBag.IsSubStore = isSubStore;

            if (isSubStore)
            {
                this.ViewBag.WarehouseList = PL.GetWarehouse().Where(x => x.comid == comid && x.WarehouseId != 0 && x.WhType == "L" && x.IsSubWarehouse == true);
            }
            else
            {
                this.ViewBag.WarehouseList = PL.GetWarehouse().Where(x => x.comid == comid && x.WarehouseId != 0 && x.WhType == "L");
            }

            // set products in session
            POS.SetProductInSession();

            ViewBag.Title = "Create";
            ViewData["SectId"] = new SelectList(db.Cat_Section.Where(x => x.ComId == comid), "SectId", "SectName");
            // ViewData["DeptId"] = new SelectList(db.Cat_Department.Where(x => x.ComId == comid), "DeptId", "DeptName");
            ViewData["CurrencyId"] = new SelectList(db.Currency.OrderByDescending(x => x.isDefault), "CurrencyId", "CurCode");
            ViewData["PaymentTypeId"] = new SelectList(db.PaymentTypes, "PaymentTypeId", "TypeName");

            //ViewData["PurReqId"] = new SelectList(db.PurchaseRequisitionMain.Where(x => x.ComId == comid), "PurReqId", "PRNo");
            //ViewData["PurOrderMainId"] = new SelectList(db.PurchaseOrderMain.Where(x => x.ComId == comid), "PurOrderMainId", "PONo");
            ViewData["SupplierId"] = new SelectList(db.Suppliers.Where(x => x.comid == comid), "SupplierId", "SupplierName");
            ViewData["WarehouseId"] = new SelectList(PL.GetWarehouse().Where(x => x.WarehouseId != 0 && x.WhType == "L"), "WarehouseId", "WhShortName");

            ViewData["BOMMainId"] = new SelectList(db.BOMMain.Where(x => x.ComId == comid), "BOMMainId", "AssembleName");

            ViewData["Employees"] = new SelectList(db.HR_Emp_Info.Where(x => x.ComId == comid && x.IsInactive == false).Select(x => new { x.EmpId, x.EmpCode, x.EmpName }), "EmpId", "EmpName");
            //ViewData["CategoryId"] = new SelectList(db.Categories.Where(x => x.comid == comid).Select(x => new { x.CategoryId, x.Name }), "CategoryId", "Name");

            #region CategoryId viewbag selectlist
            List<Category> categorydb = PL.GetCategory().Where(c => c.CategoryId > 0).ToList();

            List<SelectListItem> categoryid = new List<SelectListItem>();
            //categoryid.Add(new SelectListItem { Text = "--Please Select--", Value = "-1" });

            var permission = HttpContext.Session.GetObject<UserPermission>("userpermission");
            if (!permission.IsProduction && !permission.IsMedical)
            {
                categoryid.Add(new SelectListItem { Text = "=ALL=", Value = "0" });
            }

            //licities.Add(new SelectListItem { Text = "--Select State--", Value = "0" });
            if (categorydb != null)
            {
                foreach (Category x in categorydb)
                {
                    categoryid.Add(new SelectListItem { Text = x.Name, Value = x.CategoryId.ToString() });
                }
            }
            ViewData["CategoryId"] = (categoryid);
            #endregion


            ViewData["DeptId"] = new SelectList(db.Cat_Department.Where(x => x.ComId == comid).Select(x => new { x.DeptId, x.DeptName }), "DeptId", "DeptName");
            //ViewData["PrdUnitId"] = new SelectList(db.PrdUnits.Where(x => x.comid == comid).Select(x => new { x.PrdUnitId, x.PrdUnitShortName }), "PrdUnitId", "PrdUnitShortName");
            ViewData["PurposeId"] = new SelectList(db.Purpose.Select(x => new { x.PurposeId, x.PurposeName }), "PurposeId", "PurposeName");

            ViewData["ProductId"] = new SelectList(db.Products.Take(0).Where(x => x.comid == comid).Select(x => new { x.ProductId, x.ProductName }), "ProductId", "ProductName");

            ViewData["UnitId"] = new SelectList(db.Unit.Select(x => new { x.UnitId, x.UnitName }), "UnitId", "UnitName");

            ViewData["Patient"] = new SelectList(db.Cat_Variable.Where(c => c.VarType == "ReleationType").OrderBy(c => c.SLNo), "VarName", "VarName");
            var empInfo = (from emp in db.HR_Emp_Info
                           join d in db.Cat_Department on emp.DeptId equals d.DeptId
                           join s in db.Cat_Section on emp.SectId equals s.SectId
                           join des in db.Cat_Designation on emp.DesigId equals des.DesigId
                           where emp.ComId == comid && emp.IsInactive == false
                           select new
                           {
                               Value = emp.EmpId,
                               Text = emp.EmpCode + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                           }).ToList();

            ViewData["EmpId"] = new SelectList(empInfo, "Value", "Text");

            var doctorInfo = (from emp in db.HR_Emp_Info
                              join d in db.Cat_Department on emp.DeptId equals d.DeptId
                              join s in db.Cat_Section on emp.SectId equals s.SectId
                              join des in db.Cat_Designation on emp.DesigId equals des.DesigId
                              where emp.ComId == comid && des.DesigName.ToUpper().Contains("MEDICAL OFFICER") && emp.IsInactive == false
                              orderby emp.EmpCode
                              select new
                              {
                                  Value = emp.EmpId,
                                  Text = emp.EmpCode + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                              }).ToList();

            ViewData["DoctorId"] = new SelectList(doctorInfo, "Value", "Text"); // only for medical
            return View(issueMain);
        }

        public IActionResult SubStoreCreate()
        {
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");
            var pcname = HttpContext.Session.GetString("pcname");

            IssueMain issuereq = new IssueMain();
            issuereq.IssueDate = DateTime.Now.Date;
            issuereq.IsSubStore = true;


            ViewBag.Title = "Create";
            ViewData["SectId"] = new SelectList(db.Cat_Section.Where(x => x.ComId == comid), "SectId", "SectName");
            ViewData["CurrencyId"] = new SelectList(db.Currency.OrderByDescending(x => x.isDefault), "CurrencyId", "CurCode");
            ViewData["PaymentTypeId"] = new SelectList(db.PaymentTypes, "PaymentTypeId", "TypeName");
            ViewData["PrdUnitId"] = new SelectList(PL.GetPrdUnit(), "PrdUnitId", "PrdUnitName");
            ViewData["StoreReqId"] = new SelectList(db.StoreRequisitionMain.Where(x => x.ComId == comid && x.Complete == 0 && x.Status > 0 && x.IsSubStore == true), "StoreReqId", "SRNo");

            //Need to change himu

            ViewData["WarehouseId"] = new SelectList(PL.GetWarehouse().Where(x => x.WarehouseId != 0 && x.WhType == "L" && x.ParentId != null && x.WarehouseId == 5), "WarehouseId", "WhShortName");
            this.ViewBag.WarehouseList = PL.GetWarehouse().Where(x => x.WarehouseId != 0 && x.WhType == "L");
            //ViewData["SupplierId"] = new SelectList(db.Suppliers.Where(x => x.comid == comid), "SupplierId", "SupplierName");
            return View(issuereq);
        }

        // POST: Issues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IssueMain issueMain)
        {
            try
            {


                //var errors = ModelState.Where(x => x.Value.Errors.Any())
                //               .Select(x => new { x.Key, x.Value.Errors });
                var result = "";
                //if (ModelState.IsValid)
                //{

                var comid = HttpContext.Session.GetString("comid");
                var userid = HttpContext.Session.GetString("userid");
                var pcname = HttpContext.Session.GetString("pcname");
                var nowdate = DateTime.Now;





                DateTime date = issueMain.IssueDate;
                var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                var activefiscalmonth = db.Acc_FiscalMonths.Where(x => x.ComId == comid && x.OpeningdtFrom >= firstDayOfMonth && x.ClosingdtTo <= lastDayOfMonth).FirstOrDefault();// && x.dtFrom.ToString() == monthid.ToString()
                if (activefiscalmonth == null)
                {
                    return Json(new { Success = 0, ex = "No Active Fiscal Month Found" });
                }
                var activefiscalyear = db.Acc_FiscalYears.Where(x => x.FYId == activefiscalmonth.FYId).FirstOrDefault();
                if (activefiscalyear == null)
                {
                    return Json(new { Success = 0, ex = "No Active Fiscal Year Found" });
                }


                // Duplicate Issue no check

                var duplicateDocument = db.IssueMain.Where(i => i.IssueNo == issueMain.IssueNo && i.IssueMainId != issueMain.IssueMainId && i.ComId == comid && i.FiscalYearId == activefiscalyear.FiscalYearId).FirstOrDefault();
                if (duplicateDocument != null)
                {
                    return Json(new { Success = 0, ex = issueMain.IssueNo + " already exist. Document No can not Duplicate." });
                }



                var lockCheck = db.HR_ProcessLock
                .Where(p => p.LockType.Contains("Store Lock") && p.DtDate.Date <= issueMain.IssueDate.Date && p.DtToDate.Value.Date >= issueMain.IssueDate.Date
                    && p.IsLock == true).FirstOrDefault();

                if (lockCheck != null)
                {
                    return Json(new { Success = 0, ex = "Store Lock this date!!!" });
                }

                //foreach (var item in issueMain.IssueSub)
                //{
                //    if (item.IssueQty==0)
                //    {
                //        item.TotalValue = item.Rate;
                //    }
                //}


                using (var tr = db.Database.BeginTransaction())
                {
                    if (issueMain != null)
                    {

                        try
                        {
                            if (issueMain.IssueMainId > 0)
                            {

                                issueMain.FiscalMonthId = activefiscalmonth.FiscalMonthId;
                                issueMain.FiscalYearId = activefiscalyear.FiscalYearId;

                                var currentissuesub = db.IssueSub.Include(x => x.IssueSubWarehouse).Where(p => p.IssueMainId == issueMain.IssueMainId);


                                foreach (IssueSub ss in currentissuesub)
                                {
                                    db.IssueSub.Remove(ss);
                                }
                                db.SaveChanges();


                                foreach (IssueSub item in issueMain.IssueSub)
                                {
                                    if (item.IssueSubId > 0)
                                    {
                                        foreach (IssueSub ss in issueMain.IssueSub)
                                        {
                                            if (ss.IssueSubWarehouse != null)
                                            {
                                                foreach (IssueSubWarehouse sss in ss.IssueSubWarehouse)
                                                {
                                                    sss.IssueSubWarehouseId = 0;
                                                }
                                            }
                                            item.IssueSubId = 0;
                                            db.IssueSub.Add(item);

                                        }

                                    }
                                    else
                                    {
                                        db.IssueSub.Add(item);
                                    }
                                }
                                issueMain.UpdateByUserId = userid;
                                issueMain.DateUpdated = nowdate;
                                db.Entry(issueMain).State = EntityState.Modified;
                                result = "2";

                                db.SaveChanges();

                                if (!issueMain.IsDirectIssue)
                                {

                                    SqlParameter[] sqlParameter = new SqlParameter[3];
                                    sqlParameter[0] = new SqlParameter("@ComId", comid);
                                    sqlParameter[1] = new SqlParameter("@Id", issueMain.IssueMainId);
                                    sqlParameter[2] = new SqlParameter("@Type", "Update");

                                    Helper.ExecProc("prcProcessUpdateSRRAfterIssue", sqlParameter);
                                }
                            }
                            else
                            {
                                issueMain.FiscalMonthId = activefiscalmonth.FiscalMonthId;
                                issueMain.FiscalYearId = activefiscalyear.FiscalYearId;

                                issueMain.ComId = comid;
                                issueMain.UserId = userid;
                                issueMain.PcName = pcname;
                                issueMain.DateAdded = nowdate;


                                db.Add(issueMain);
                                result = "1";
                                db.SaveChanges();

                                if (!issueMain.IsDirectIssue)
                                {

                                    SqlParameter[] sqlParameter = new SqlParameter[3];
                                    sqlParameter[0] = new SqlParameter("@ComId", comid);
                                    sqlParameter[1] = new SqlParameter("@Id", issueMain.IssueMainId);
                                    sqlParameter[2] = new SqlParameter("@Type", "Insert");


                                    Helper.ExecProc("prcProcessUpdateSRRAfterIssue", sqlParameter);
                                }
                            }



                        }
                        catch (SqlException ex)
                        {

                            Console.WriteLine(ex.Message);
                            tr.Rollback();
                            return Json(new { Success = 0, ex = ex });

                        }
                    }
                    tr.Commit();
                }



                //if (issueMain.IssueMainId > 0)
                //{

                //    var CurrentIssueSub = db.IssueSub.Include(x => x.IssueSubWarehouse).Where(p => p.IssueMainId == issueMain.IssueMainId);
                //    //db.IssueSub.RemoveRange(CurrentIssueSub);
                //    //db.SaveChanges();

                //    foreach (IssueSub ss in CurrentIssueSub)
                //    {
                //        db.IssueSub.Remove(ss);
                //    }
                //    db.SaveChanges();


                //    foreach (IssueSub item in issueMain.IssueSub)
                //    {
                //        if (item.IssueSubId > 0)
                //        {
                //            //foreach (IssueSubWarehouse itemwarehouse in item.IssueSubWarehouse)
                //            //{
                //            //    if (itemwarehouse.IssueSubWarehouseId > 0)
                //            //    {
                //            //        db.Entry(itemwarehouse).State = EntityState.Modified;
                //            //    }
                //            //    else
                //            //    {
                //            //        db.IssueSubWarehouse.Add(itemwarehouse);
                //            //    }
                //            //}

                //            //item.DateUpdated = date;
                //            //item.UpdateByUserId = userid;
                //            //db.Entry(item).State = EntityState.Modified;


                //            ////////////////////////////////////////////////////// fahad



                //            //foreach (Acc_VoucherSubCheckno ss in CurrentVoucherCheck)
                //            //    db.Acc_VoucherSubs.Remove(ss);
                //            //db.SaveChanges();


                //            foreach (IssueSub ss in issueMain.IssueSub)
                //            {
                //                //var CurrentIssueSubWarehouse = db.IssueSubWarehouse.Where(p => p.IssueSubId == ss.IssueSubId);
                //                //db.IssueSubWarehouse.RemoveRange(CurrentIssueSubWarehouse);
                //                //db.SaveChanges();



                //                //////foreach (IssueSubWarehouse sss in ss.IssueSubWarehouse)
                //                //////{
                //                //////    //sss.IssueSubId = issuesubid;
                //                //////    sss.IssueSubWarehouseId = 0;

                //                //////    //db.IssueSubWarehouse.Add(sss);
                //                //////}

                //                ////////if (ss.VoucherSubId > 0)
                //                ////////{
                //                ////////db.Entry(ss).State = EntityState.Modified;
                //                //////ss.IssueSubId = 0;
                //                ////////db.IssueSub.Add(ss);
                //                ////////db.SaveChanges();
                //                ////////db.Entry(ss).GetDatabaseValues();
                //                ////////int issuesubid = ss.IssueSubId;
                //                // Yes it's here
                //                //}
                //                //else
                //                //{
                //                //    //db.Acc_VoucherSubs.Add(ss);
                //                //    db.Acc_VoucherSubs.Add(ss);
                //                //}


                //                foreach (IssueSubWarehouse sss in ss.IssueSubWarehouse)
                //                {
                //                    //sss.IssueSubId = issuesubid;
                //                    sss.IssueSubWarehouseId = 0;

                //                    //db.IssueSubWarehouse.Add(sss);
                //                }
                //                item.IssueSubId = 0;
                //                db.IssueSub.Add(item);

                //            }
                //            ////////////////////////////////////////////////////////////////////////// fahad

                //        }
                //        else
                //        {
                //            //item.ComId = comid;
                //            //item.UserId = userid;
                //            //item.PcName = pcname;
                //            //item.DateAdded = date;
                //            db.IssueSub.Add(item);
                //        }
                //    }
                //    issueMain.UpdateByUserId = userid;
                //    issueMain.DateUpdated = date;
                //    db.Entry(issueMain).State = EntityState.Modified;
                //    result = "2";
                //}
                //else
                //{
                //    issueMain.ComId = comid;
                //    issueMain.UserId = userid;
                //    issueMain.PcName = pcname;
                //    issueMain.DateAdded = date;
                //    //issueMain.IssueSub.FirstOrDefault().ComId = comid;
                //    //issueMain.IssueSub.FirstOrDefault().UserId = userid;
                //    //issueMain.IssueSub.FirstOrDefault().PcName = pcname;
                //    //issueMain.IssueSub.FirstOrDefault().DateAdded = date;

                //    db.Add(issueMain);
                //    result = "1";
                //}
                //db.SaveChanges();
                //}
                ViewData["SectId"] = new SelectList(db.Cat_Section.Where(x => x.ComId == comid), "SectId", "SectName", issueMain.SectId);
                ViewData["CurrencyId"] = new SelectList(db.Currency.OrderByDescending(x => x.isDefault), "CurrencyId", "CurCode", issueMain.CurrencyId);
                //ViewData["PaymentTypeId"] = new SelectList(db.PaymentTypes, "PaymentTypeId", "TypeName", issueMain.PaymentTypeId);
                ViewData["PrdUnitId"] = new SelectList(db.PrdUnits.Where(x => x.comid == comid), "PrdUnitId", "PrdUnitName", issueMain.PrdUnitId);
                ViewData["PurReqId"] = new SelectList(db.PurchaseRequisitionMain.Where(x => x.ComId == comid), "PurReqId", "PRNo", issueMain.StoreReqId);
                //ViewData["SupplierId"] = new SelectList(db.Suppliers.Where(x => x.comid == comid), "SupplierId", "SupplierName", issueMain.SupplierId);
                return Json(new { Success = result, ex = "" });
            }
            catch (Exception ex)
            {

                //throw ex;
                return Json(new { Success = 0, ex = ex });
            }
        }


        public IActionResult GetCategoryProductInfo(int id)
        {
            var prdunits = db.PrdUnits.Find(id);
            string comid = HttpContext.Session.GetString("comid");

            if (prdunits == null)
            {

                prdunits = db.PrdUnits.Where(x => x.PrdUnitId > 0).OrderBy(x => x.PrdUnitId).FirstOrDefault();
            }
            if (prdunits.PrdUnitName.ToUpper().Contains("MEDICAL"))// only for medical
            {
                var categorys = db.Categories.Where(X => X.comid == comid)
                    .Select(c => new
                    {
                        CategoryId = c.CategoryId,
                        Name = c.Name
                    }).Where(c => c.Name.ToUpper().Contains("MEDICAL")).ToList();

                var products = db.Products.Where(X => X.comid == comid)//.Include(a=>a.vPrimaryCategory)
                    .Select(c => new
                    {
                        ProductId = c.ProductId,
                        CategoryId = c.CategoryId,
                        Name = c.ProductName + " [ " + c.ProductCode + " ]"
                    }).Where(p => p.CategoryId == categorys.FirstOrDefault().CategoryId).ToList();

                var warehouses = db.Warehouses.Where(X => X.comid == comid).Where(x => x.WhType == "L" && x.IsMedicalWarehouse == true && x.IsConsumableWarehouse == true)                  //.Where(x => x.WhName.ToUpper().Contains("Med"))
                .Select(w => new
                {
                    WarehouseId = w.WarehouseId,
                    WhName = w.WhName
                }).ToList();

                return Json(new { Categorys = categorys, Products = products, Warehouses = warehouses });
            }
            if (prdunits.PrdUnitName.ToUpper().Contains("UNIT 1") || prdunits.PrdUnitName.ToUpper().Contains("UNIT 2"))// only for medical
            {
                var categorys = db.Categories.Where(X => X.comid == comid).Select(c => new
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name
                }).ToList();

                var products = db.Products.Where(X => X.comid == comid).Take(1) //.Include(a=>a.vPrimaryCategory)
                    .Select(c => new
                    {
                        ProductId = c.ProductId,
                        CategoryId = c.CategoryId,
                        Name = c.ProductName
                    }).Where(p => p.CategoryId == categorys.FirstOrDefault().CategoryId).ToList();

                var wh = prdunits.PrdUnitName.ToUpper().Contains("UNIT 1") ? "DAP-1" : "DAP-2";

                var warehouses = db.Warehouses.Where(X => X.comid == comid)
                    .Where(x => x.WhType == "L" && x.WhName == wh && x.IsProductionWarehouse == true && x.IsConsumableWarehouse == true)     //.Where(x => x.WhName.ToUpper().Contains("Med"))
                    .Select(w => new
                    {
                        WarehouseId = w.WarehouseId,
                        WhName = w.WhName
                    }).ToList();

                return Json(new { Categorys = categorys, Products = products, Warehouses = warehouses });

            }
            else
            {

                #region CategoryId viewbag selectlist
                //List<Category> categorydb = POS.GetCategory(comid).ToList();

                //List<SelectListItem> categoryid = new List<SelectListItem>();
                //categoryid.Add(new SelectListItem { Text = "--Please Select--", Value = "-1" });
                //categoryid.Add(new SelectListItem { Text = "=ALL=", Value = "0" });



                //licities.Add(new SelectListItem { Text = "--Select State--", Value = "0" });
                //if (categorydb != null)
                //{
                //    foreach (Category x in categorydb)
                //    {
                //        categoryid.Add(new SelectListItem { Text = x.Name, Value = x.CategoryId.ToString() });
                //    }
                //}
                //ViewData["CategoryId"] = (categoryid);
                #endregion

                var categorys = db.Categories.Where(X => X.comid == comid).Select(c => new
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name
                }).ToList();


                //categorys.Add(new { CategoryId = -1, Name = "--Please Select--" });
                categorys.Add(new { CategoryId = 0, Name = "=ALL=" });

                var categorylist = categorys.OrderBy(x => x.CategoryId);


                var warehouses = db.Warehouses.Where(X => X.comid == comid).Where(x => x.WhType == "L" && x.WarehouseId != 0 && x.IsConsumableWarehouse == false).Select(w => new
                {
                    WarehouseId = w.WarehouseId,
                    WhName = w.WhName,
                    WhType = w.WhType,
                    ParentId = w.ParentId
                }).ToList();
                //db.Warehouses.Where(x => x.comid == comid && x.WhType == "L" && x.ParentId != null)
                //db.Products.Where(p => p.CategoryId == categorys.FirstOrDefault().CategoryId).ToList();
                return Json(new { Categorys = categorylist, Products = "", Warehouses = warehouses });
            }

        }



        public ActionResult Print(int? id, string type)
        {
            string SqlCmd = "";
            string ReportPath = "";
            var ConstrName = "ApplicationServices";
            var ReportType = "PDF";
            var comid = HttpContext.Session.GetString("comid");


            //var abcvouchermain = db.PurchaseRequisitionMain.Where(x => x.PurReqId == id && x.ComId == comid).FirstOrDefault();

            //var reportname = "rptIssueIndividual";
            var reportname = "rptSRForm";
            ///@ComId nvarchar(200),@Type varchar(10),@ID int,@dtFrom smalldatetime,@dtTo smalldatetime
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Inventory/" + reportname + ".rdlc");
            //var str = db.Acc_VoucherMains.Include(x => x.Acc_VoucherType).FirstOrDefault().Acc_VoucherType.VoucherTypeNameShort;// "VPC";
            HttpContext.Session.SetString("reportquery", "Exec [Inv_rptIndIssueDetails] '" + comid + "', 'ISSUENW' ," + id + ", '01-Jan-1900', '01-Jan-1900'");


            //Session["reportquery"] = "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.[rptCommercialInvoice_Export] '" + id + "','" + AppData.AppData.intComId + "'";
            string filename = db.IssueMain.Where(x => x.IssueMainId == id).Select(x => x.IssueNo).Single();
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
            string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); // this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //Repository.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

            return Redirect(callBackUrl);

            ///return RedirectToAction("Index", "ReportViewer");


        }



        public IActionResult GetInventory(int prdId, int whId)
        {
            string comid = HttpContext.Session.GetString("comid");
            //var inv = db.Inventory.Where(i => i.WareHouseId == whId && i.ProductId == prdId && i.comid==comid)
            //   .Select(w => new
            //   {
            //       WareHouseId = w.WareHouseId,
            //       ProductId = w.ProductId,
            //       CurrentStock = w.CurrentStock
            //   }).FirstOrDefault();
            //return Json(inv);


            /// for calculate pending document qty 
            //var notPosted = db.IssueSub.Include(i => i.IssueMain)
            //    .Where(i => i.ProductId == prdId && i.WarehouseId == whId && i.IssueMain.Status==0)
            //    .Select(i=> i.IssueQty).Sum();

            var notPosted = 0;


            var costcal = db.CostCalculated.Where(x => x.WarehouseId == whId && x.ProductId == prdId && x.isDelete == false).OrderByDescending(x => x.CostCalculatedId).FirstOrDefault();

            var inv = db.Products.Include(x => x.vProductUnit).Include(x => x.CostCalculated).Where(x => x.comid == comid).Select(p => new
            {
                p.ProductId,
                p.ProductName,
                p.ProductBrand,
                p.ProductModel,
                UnitName = p.vProductUnit.UnitName,
                p.UnitId,
                WareHouseId = whId,
                AvgRate = p.CostCalculated.Where(x => x.WarehouseId == whId && x.isDelete == false).OrderByDescending(x => x.CostCalculatedId).Take(1).Select(x => x.CalculatedPrice).FirstOrDefault().ToString(), //lastpurchaseprice,
                //CurrentStock = p.CostCalculated.Where(x => x.WarehouseId == whId && x.isDelete == false).OrderByDescending(x => x.CostCalculatedId).Select(x => x.CurrQty).ToString()
                CurrentStock = costcal != null ? (costcal.PrevQty + costcal.CurrQty - notPosted) : 0, /// costcalculated stock qty - pending document qty
            }).Where(p => p.ProductId == prdId).FirstOrDefault();// ToList();

            ///ProductData.CostPrice = db.PurchaseOrderMain.Include(x => x.PurchaseOrderSub).Where(x => x.ComId == comid).Select(x=>x.p).OrderByDescending(x => x.PODate);
            //ProductData.CostPrice = db.GoodsReceiveSub.Include(x => x.GoodsReceiveMain).Where(x => x.GoodsReceiveMain.ComId == comid && x.ProductId == id).OrderByDescending(x => x.PurchaseOrderSub.PurchaseOrderMain.PODate).Take(1).Select(x => x.Rate);


            return Json(inv);

        }

        public IActionResult GetBOMProduct(int prdUnitId)
        {
            string comid = HttpContext.Session.GetString("comid");



            var bomSub = (from bom in db.BOMSub
                          join bomMain in db.BOMMain on bom.BOMMainId equals bomMain.BOMMainId
                          join p in db.Products on bom.InvProductId equals p.ProductId
                          join u in db.Unit on p.UnitId equals u.UnitId
                          join w in db.Warehouses on bom.WarehouseId equals w.WarehouseId
                          where bomMain.PrdUnitId == prdUnitId && bom.ComId == comid

                          select new
                          {
                              BOMMainId = bom.BOMMainId,
                              BOMSubId = bom.BOMSubId,
                              ProductId = bom.InvProductId,
                              Consumption = bom.Consumption,
                              Remarks = bom.Remarks,
                              ProductName = p.ProductName,
                              UnitName = u.UnitName,
                              WarehouseId = w.WarehouseId,
                              WhName = w.WhName,
                              SLNo = bom.SLNo

                          }).OrderBy(x => x.SLNo).ToList();
            return Json(bomSub);
        }



        // GET: Issues/Edit/5
        public async Task<IActionResult> View(int? id, bool isRateCheck)
        {
            try
            {


                if (id == null)
                {
                    return NotFound();
                }
                var comid = HttpContext.Session.GetString("comid");
                var userid = HttpContext.Session.GetString("userid");
                var pcname = HttpContext.Session.GetString("pcname");



                ViewBag.Title = "Edit";
                var issueMain = await db.IssueMain
                    .Include(p => p.IssueSub)
                    .ThenInclude(p => p.vProduct)
                    .ThenInclude(p => p.vProductUnit)
                    .Include(g => g.IssueSub)
                    .ThenInclude(g => g.vWarehouse)
                    .Include(p => p.IssueSub)
                    .ThenInclude(p => p.IssueSubWarehouse)
                    .ThenInclude(p => p.vWarehouse)
                    .FirstOrDefaultAsync(m => m.IssueMainId == id);
                if (issueMain == null)
                {
                    return NotFound();
                }

                this.ViewBag.WarehouseList = PL.GetWarehouse().Where(x => x.WhType == "L");

                // set products in session
                POS.SetProductInSession();

                var quary = $"EXEC IssueDetailsInformation '{comid}','{userid}',{issueMain.StoreReqId},{issueMain.IssueMainId}";
                SqlParameter[] parameters = new SqlParameter[5];
                parameters[0] = new SqlParameter("@comid", comid);
                parameters[1] = new SqlParameter("@userid", userid);
                parameters[2] = new SqlParameter("@StoreReqId", issueMain.StoreReqId.ToString());
                parameters[3] = new SqlParameter("@IssueId", issueMain.IssueMainId);
                parameters[4] = new SqlParameter("@IsSubStore", issueMain.IsSubStore);
                List<IssueDetailsModel> IssueDetailsInformation = Helper.ExecProcMapTList<IssueDetailsModel>("IssueDetailsInformation", parameters);

                //if (IssueDetailsInformation.Count > 0)
                //{
                //    foreach (var DBitem in issueMain.IssueSub)
                //    {

                //        var abc = IssueDetailsInformation.Where(x => x.ProductId == DBitem.ProductId);
                //        //if (abc.FirstOrDefault().RemainingReqQty != null)
                //        {
                //            //DBitem.RemainingReqQty = abc.FirstOrDefault().RemainingReqQty ? 0;
                //            DBitem.RemainingReqQty = abc != null ? abc.FirstOrDefault().RemainingReqQty : 0;

                //        }
                //    }

                //}

                ViewBag.IsSubStore = issueMain.IsSubStore;
                ViewBag.IsRateCheck = isRateCheck;

                if (issueMain.IsSubStore)
                {
                    ViewData["SectId"] = new SelectList(db.Cat_Section.Where(x => x.ComId == comid), "SectId", "SectName", issueMain.SectId);
                    ViewData["DeptId"] = new SelectList(db.Cat_Department.Where(x => x.ComId == comid), "DeptId", "DeptName", issueMain.DeptId);
                    //ViewData["SubSectId"] = new SelectList(db.Cat_SubSection.Where(x => x.ComId == comid), "SubSectId", "SubSectName");
                    ViewData["CurrencyId"] = new SelectList(db.Currency.OrderByDescending(x => x.isDefault), "CurrencyId", "CurCode", issueMain.CurrencyId);
                    //ViewData["PaymentTypeId"] = new SelectList(db.PaymentTypes, "PaymentTypeId", "TypeName", issueMain.PaymentTypeId);
                    ViewData["PrdUnitId"] = new SelectList(PL.GetPrdUnit(), "PrdUnitId", "PrdUnitShortName", issueMain.PrdUnitId);
                    //ViewData["StoreReqId"] = new SelectList(db.StoreRequisitionMain.Where(x => x.ComId == comid), "StoreReqId", "SRNo", issueMain.StoreReqId);

                    //var storeRequisitions = db.StoreRequisitionMain
                    //    .Where(x => x.ComId == comid && x.Complete == 0 && x.Status > 0 && x.IsSubStore == true)
                    //    .Select(s => new { Value = s.StoreReqId, Text = s.SRNo + " [S.S.]" });

                    //ViewData["StoreReqId"] = new SelectList(storeRequisitions, "Value", "Text", issueMain.StoreReqId);

                    //Need to change himu

                    //ViewData["WarehouseId"] = new SelectList(db.Warehouses.Where(x => x.comid == comid && x.WhType == "L" && x.ParentId != null && x.IsSubWarehouse == true), "WarehouseId", "WhShortName" );

                    ViewData["StoreReqId"] = new SelectList(db.StoreRequisitionMain.Where(x => x.ComId == comid && x.StoreReqId == issueMain.StoreReqId), "StoreReqId", "SRNo", issueMain.StoreReqId);

                    ViewData["WarehouseId"] = new SelectList(PL.GetWarehouse().Where(x => x.comid == comid && x.WarehouseId != 0 && x.WhType == "L" && x.ParentId != null && x.IsSubWarehouse == true), "WarehouseId", "WhShortName");
                    //ViewData["SupplierId"] = new SelectList(db.Suppliers.Where(x => x.comid == comid), "SupplierId", "SupplierName", issueMain.SupplierId);
                    if (issueMain.IsDirectIssue)
                    {
                        ViewData["Patient"] = new SelectList(db.Cat_Variable.Where(c => c.VarType == "ReleationType").OrderBy(c => c.SLNo), "VarName", "VarName");
                        var empInfo = (from emp in db.HR_Emp_Info
                                       join d in db.Cat_Department on emp.DeptId equals d.DeptId
                                       join s in db.Cat_Section on emp.SectId equals s.SectId
                                       join des in db.Cat_Designation on emp.DesigId equals des.DesigId
                                       where emp.ComId == comid
                                       select new
                                       {
                                           Value = emp.EmpId,
                                           Text = emp.EmpCode + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                                       }).ToList();

                        ViewData["EmpId"] = new SelectList(empInfo, "Value", "Text", issueMain.EmpId);
                        ViewData["BOMMainId"] = new SelectList(db.BOMMain.Where(x => x.ComId == comid), "BOMMainId", "AssembleName", issueMain.BOMMainId);

                        var doctorInfo = (from emp in db.HR_Emp_Info
                                          join d in db.Cat_Department on emp.DeptId equals d.DeptId
                                          join s in db.Cat_Section on emp.SectId equals s.SectId
                                          join des in db.Cat_Designation on emp.DesigId equals des.DesigId
                                          where emp.ComId == comid && des.DesigName.ToUpper().Contains("MEDICAL OFFICER")
                                          orderby emp.EmpCode
                                          select new
                                          {
                                              Value = emp.EmpId,
                                              Text = emp.EmpCode + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                                          }).ToList();

                        ViewData["DoctorId"] = new SelectList(doctorInfo, "Value", "Text", issueMain.DoctorId);

                        #region CategoryId viewbag selectlist
                        List<Category> categorydb = POS.GetCategory(comid).ToList();

                        List<SelectListItem> categoryid = new List<SelectListItem>();
                        //categoryid.Add(new SelectListItem { Text = "--Please Select--", Value = "-1" });
                        categoryid.Add(new SelectListItem { Text = "=ALL=", Value = "0" });



                        //licities.Add(new SelectListItem { Text = "--Select State--", Value = "0" });
                        if (categorydb != null)
                        {
                            foreach (Category x in categorydb)
                            {
                                categoryid.Add(new SelectListItem { Text = x.Name, Value = x.CategoryId.ToString() });
                            }
                        }
                        ViewData["CategoryId"] = (categoryid);
                        #endregion

                        return View("ViewDirectIssue", issueMain);
                    }
                    return View("ViewCreate", issueMain);
                }
                else
                {
                    ViewData["SectId"] = new SelectList(db.Cat_Section.Where(x => x.ComId == comid), "SectId", "SectName", issueMain.SectId);
                    ViewData["DeptId"] = new SelectList(db.Cat_Department.Where(x => x.ComId == comid), "DeptId", "DeptName", issueMain.DeptId);
                    //ViewData["SubSectId"] = new SelectList(db.Cat_SubSection.Where(x => x.ComId == comid), "SubSectId", "SubSectName");
                    ViewData["CurrencyId"] = new SelectList(db.Currency.OrderByDescending(x => x.isDefault), "CurrencyId", "CurCode", issueMain.CurrencyId);
                    //ViewData["PaymentTypeId"] = new SelectList(db.PaymentTypes, "PaymentTypeId", "TypeName", issueMain.PaymentTypeId);
                    ViewData["PrdUnitId"] = new SelectList(PL.GetPrdUnit(), "PrdUnitId", "PrdUnitShortName", issueMain.PrdUnitId);
                    //ViewData["StoreReqId"] = new SelectList(db.StoreRequisitionMain.Where(x => x.ComId == comid), "StoreReqId", "SRNo", issueMain.StoreReqId);
                    //var storeRequisitions = db.StoreRequisitionMain
                    //   .Where(x => x.ComId == comid && x.Complete == 0 && x.Status > 0 && x.IsSubStore == true)
                    //   .Select(s => new { Value = s.StoreReqId, Text = s.SRNo });

                    //ViewData["StoreReqId"] = new SelectList(storeRequisitions, "Value", "Text", issueMain.StoreReqId);

                    ViewData["StoreReqId"] = new SelectList(db.StoreRequisitionMain.Where(x => x.ComId == comid && x.StoreReqId == issueMain.StoreReqId), "StoreReqId", "SRNo", issueMain.StoreReqId);


                    ViewData["WarehouseId"] = new SelectList(PL.GetWarehouse().Where(x => x.WarehouseId != 0 && x.WhType == "L" && x.ParentId != null), "WarehouseId", "WhShortName");
                    //ViewData["SupplierId"] = new SelectList(db.Suppliers.Where(x => x.comid == comid), "SupplierId", "SupplierName", issueMain.SupplierId);

                    if (issueMain.IsDirectIssue)
                    {
                        ViewData["Patient"] = new SelectList(db.Cat_Variable.Where(c => c.VarType == "ReleationType").OrderBy(c => c.SLNo), "VarName", "VarName");
                        var empInfo = (from emp in db.HR_Emp_Info
                                       join d in db.Cat_Department on emp.DeptId equals d.DeptId
                                       join s in db.Cat_Section on emp.SectId equals s.SectId
                                       join des in db.Cat_Designation on emp.DesigId equals des.DesigId
                                       where emp.ComId == comid
                                       select new
                                       {
                                           Value = emp.EmpId,
                                           Text = emp.EmpCode + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                                       }).ToList();

                        ViewData["EmpId"] = new SelectList(empInfo, "Value", "Text", issueMain.EmpId);

                        var doctorInfo = (from emp in db.HR_Emp_Info
                                          join d in db.Cat_Department on emp.DeptId equals d.DeptId
                                          join s in db.Cat_Section on emp.SectId equals s.SectId
                                          join des in db.Cat_Designation on emp.DesigId equals des.DesigId
                                          where emp.ComId == comid && des.DesigName.ToUpper().Contains("MEDICAL OFFICER")
                                          orderby emp.EmpCode
                                          select new
                                          {
                                              Value = emp.EmpId,
                                              Text = emp.EmpCode + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                                          }).ToList();

                        ViewData["DoctorId"] = new SelectList(doctorInfo, "Value", "Text", issueMain.DoctorId);
                        ViewData["BOMMainId"] = new SelectList(db.BOMMain.Where(x => x.ComId == comid), "BOMMainId", "AssembleName", issueMain.BOMMainId);

                        #region CategoryId viewbag selectlist
                        List<Category> categorydb = POS.GetCategory(comid).ToList();

                        List<SelectListItem> categoryid = new List<SelectListItem>();
                        //categoryid.Add(new SelectListItem { Text = "--Please Select--", Value = "-1" });
                        categoryid.Add(new SelectListItem { Text = "=ALL=", Value = "0" });



                        //licities.Add(new SelectListItem { Text = "--Select State--", Value = "0" });
                        if (categorydb != null)
                        {
                            foreach (Category x in categorydb)
                            {
                                categoryid.Add(new SelectListItem { Text = x.Name, Value = x.CategoryId.ToString() });
                            }
                        }
                        ViewData["CategoryId"] = (categoryid);
                        #endregion


                        return View("ViewDirectIssue", issueMain);

                    }
                    return View("ViewCreate", issueMain);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        // GET: Issues/Edit/5
        public async Task<IActionResult> Edit(int? id, bool isRateCheck)
        {
            try
            {


                if (id == null)
                {
                    return NotFound();
                }
                var comid = HttpContext.Session.GetString("comid");
                var userid = HttpContext.Session.GetString("userid");
                var pcname = HttpContext.Session.GetString("pcname");



                ViewBag.Title = "Edit";
                var issueMain = await db.IssueMain
                    .Include(p => p.IssueSub)
                    .ThenInclude(p => p.vProduct)
                    .ThenInclude(p => p.vProductUnit)
                    .Include(g => g.IssueSub)
                    .ThenInclude(g => g.vWarehouse)
                    .Include(p => p.IssueSub)
                    .ThenInclude(p => p.IssueSubWarehouse)
                    .ThenInclude(p => p.vWarehouse)
                    .FirstOrDefaultAsync(m => m.IssueMainId == id && m.Status == 0);

                if (issueMain == null)
                {
                    return NotFound();
                }

                this.ViewBag.WarehouseList = PL.GetWarehouse().Where(x => x.WhType == "L");


                // set products in session
                POS.SetProductInSession();

                var quary = $"EXEC IssueDetailsInformation '{comid}','{userid}',{issueMain.StoreReqId},{issueMain.IssueMainId}";
                SqlParameter[] parameters = new SqlParameter[5];
                parameters[0] = new SqlParameter("@comid", comid);
                parameters[1] = new SqlParameter("@userid", userid);
                parameters[2] = new SqlParameter("@StoreReqId", issueMain.StoreReqId.ToString());
                parameters[3] = new SqlParameter("@IssueId", issueMain.IssueMainId);
                parameters[4] = new SqlParameter("@IsSubStore", issueMain.IsSubStore);
                List<IssueDetailsModel> IssueDetailsInformation = Helper.ExecProcMapTList<IssueDetailsModel>("IssueDetailsInformation", parameters);

                //if (IssueDetailsInformation.Count > 0)
                //{
                //    foreach (var DBitem in issueMain.IssueSub)
                //    {

                //        var abc = IssueDetailsInformation.Where(x => x.ProductId == DBitem.ProductId);
                //        //if (abc.FirstOrDefault().RemainingReqQty != null)
                //        {
                //            //DBitem.RemainingReqQty = abc.FirstOrDefault().RemainingReqQty ? 0;
                //            DBitem.RemainingReqQty = abc != null ? abc.FirstOrDefault().RemainingReqQty : 0;

                //        }
                //    }

                //}

                ViewBag.IsSubStore = issueMain.IsSubStore;
                ViewBag.IsRateCheck = isRateCheck;

                if (issueMain.IsSubStore)
                {
                    ViewData["SectId"] = new SelectList(db.Cat_Section.Where(x => x.ComId == comid), "SectId", "SectName", issueMain.SectId);
                    ViewData["DeptId"] = new SelectList(db.Cat_Department.Where(x => x.ComId == comid), "DeptId", "DeptName", issueMain.DeptId);
                    //ViewData["SubSectId"] = new SelectList(db.Cat_SubSection.Where(x => x.ComId == comid), "SubSectId", "SubSectName");
                    ViewData["CurrencyId"] = new SelectList(db.Currency.OrderByDescending(x => x.isDefault), "CurrencyId", "CurCode", issueMain.CurrencyId);
                    //ViewData["PaymentTypeId"] = new SelectList(db.PaymentTypes, "PaymentTypeId", "TypeName", issueMain.PaymentTypeId);
                    ViewData["PrdUnitId"] = new SelectList(PL.GetPrdUnit(), "PrdUnitId", "PrdUnitShortName", issueMain.PrdUnitId);
                    //ViewData["StoreReqId"] = new SelectList(db.StoreRequisitionMain.Where(x => x.ComId == comid), "StoreReqId", "SRNo", issueMain.StoreReqId);

                    //var storeRequisitions = db.StoreRequisitionMain
                    //    .Where(x => x.ComId == comid && x.Complete == 0 && x.Status > 0 && x.IsSubStore == true)
                    //    .Select(s => new { Value = s.StoreReqId, Text = s.SRNo + " [S.S.]" });

                    //ViewData["StoreReqId"] = new SelectList(storeRequisitions, "Value", "Text", issueMain.StoreReqId);

                    //Need to change himu

                    //ViewData["WarehouseId"] = new SelectList(db.Warehouses.Where(x => x.comid == comid && x.WhType == "L" && x.ParentId != null && x.IsSubWarehouse == true), "WarehouseId", "WhShortName" );

                    ViewData["StoreReqId"] = new SelectList(db.StoreRequisitionMain.Where(x => x.ComId == comid && x.StoreReqId == issueMain.StoreReqId), "StoreReqId", "SRNo", issueMain.StoreReqId);
                    ViewData["WarehouseId"] = new SelectList(PL.GetWarehouse().Where(x => x.comid == comid && x.WarehouseId != 0 && x.WhType == "L" && x.ParentId != null && x.IsSubWarehouse == true), "WarehouseId", "WhShortName");
                    //ViewData["SupplierId"] = new SelectList(db.Suppliers.Where(x => x.comid == comid), "SupplierId", "SupplierName", issueMain.SupplierId);
                    if (issueMain.IsDirectIssue)
                    {
                        ViewData["Patient"] = new SelectList(db.Cat_Variable.Where(c => c.VarType == "ReleationType").OrderBy(c => c.SLNo), "VarName", "VarName");
                        var empInfo = (from emp in db.HR_Emp_Info
                                       join d in db.Cat_Department on emp.DeptId equals d.DeptId
                                       join s in db.Cat_Section on emp.SectId equals s.SectId
                                       join des in db.Cat_Designation on emp.DesigId equals des.DesigId
                                       where emp.ComId == comid
                                       select new
                                       {
                                           Value = emp.EmpId,
                                           Text = emp.EmpCode + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                                       }).ToList();

                        ViewData["EmpId"] = new SelectList(empInfo, "Value", "Text", issueMain.EmpId);
                        ViewData["BOMMainId"] = new SelectList(db.BOMMain.Where(x => x.ComId == comid), "BOMMainId", "AssembleName", issueMain.BOMMainId);

                        var doctorInfo = (from emp in db.HR_Emp_Info
                                          join d in db.Cat_Department on emp.DeptId equals d.DeptId
                                          join s in db.Cat_Section on emp.SectId equals s.SectId
                                          join des in db.Cat_Designation on emp.DesigId equals des.DesigId
                                          where emp.ComId == comid && des.DesigName.ToUpper().Contains("MEDICAL OFFICER")
                                          orderby emp.EmpCode
                                          select new
                                          {
                                              Value = emp.EmpId,
                                              Text = emp.EmpCode + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                                          }).ToList();

                        ViewData["DoctorId"] = new SelectList(doctorInfo, "Value", "Text", issueMain.DoctorId);

                        #region CategoryId viewbag selectlist
                        List<Category> categorydb = POS.GetCategory(comid).ToList();

                        List<SelectListItem> categoryid = new List<SelectListItem>();
                        //categoryid.Add(new SelectListItem { Text = "--Please Select--", Value = "-1" });
                        categoryid.Add(new SelectListItem { Text = "=ALL=", Value = "0" });



                        //licities.Add(new SelectListItem { Text = "--Select State--", Value = "0" });
                        if (categorydb != null)
                        {
                            foreach (Category x in categorydb)
                            {
                                categoryid.Add(new SelectListItem { Text = x.Name, Value = x.CategoryId.ToString() });
                            }
                        }
                        ViewData["CategoryId"] = (categoryid);
                        #endregion

                        return View("DirectIssue", issueMain);
                    }
                    return View("Create", issueMain);
                }
                else
                {
                    ViewData["SectId"] = new SelectList(db.Cat_Section.Where(x => x.ComId == comid), "SectId", "SectName", issueMain.SectId);
                    ViewData["DeptId"] = new SelectList(db.Cat_Department.Where(x => x.ComId == comid), "DeptId", "DeptName", issueMain.DeptId);
                    //ViewData["SubSectId"] = new SelectList(db.Cat_SubSection.Where(x => x.ComId == comid), "SubSectId", "SubSectName");
                    ViewData["CurrencyId"] = new SelectList(db.Currency.OrderByDescending(x => x.isDefault), "CurrencyId", "CurCode", issueMain.CurrencyId);
                    //ViewData["PaymentTypeId"] = new SelectList(db.PaymentTypes, "PaymentTypeId", "TypeName", issueMain.PaymentTypeId);
                    ViewData["PrdUnitId"] = new SelectList(PL.GetPrdUnit(), "PrdUnitId", "PrdUnitShortName", issueMain.PrdUnitId);
                    //ViewData["StoreReqId"] = new SelectList(db.StoreRequisitionMain.Where(x => x.ComId == comid), "StoreReqId", "SRNo", issueMain.StoreReqId);
                    //var storeRequisitions = db.StoreRequisitionMain
                    //   .Where(x => x.ComId == comid && x.Complete == 0 && x.Status > 0 && x.IsSubStore == true)
                    //   .Select(s => new { Value = s.StoreReqId, Text = s.SRNo });

                    //ViewData["StoreReqId"] = new SelectList(storeRequisitions, "Value", "Text", issueMain.StoreReqId);

                    ViewData["StoreReqId"] = new SelectList(db.StoreRequisitionMain.Where(x => x.ComId == comid && x.StoreReqId == issueMain.StoreReqId), "StoreReqId", "SRNo", issueMain.StoreReqId);

                    ViewData["WarehouseId"] = new SelectList(PL.GetWarehouse().Where(x => x.WarehouseId != 0 && x.WhType == "L" && x.ParentId != null), "WarehouseId", "WhShortName");
                    //ViewData["SupplierId"] = new SelectList(db.Suppliers.Where(x => x.comid == comid), "SupplierId", "SupplierName", issueMain.SupplierId);

                    if (issueMain.IsDirectIssue)
                    {
                        ViewData["Patient"] = new SelectList(db.Cat_Variable.Where(c => c.VarType == "ReleationType").OrderBy(c => c.SLNo), "VarName", "VarName");
                        var empInfo = (from emp in db.HR_Emp_Info
                                       join d in db.Cat_Department on emp.DeptId equals d.DeptId
                                       join s in db.Cat_Section on emp.SectId equals s.SectId
                                       join des in db.Cat_Designation on emp.DesigId equals des.DesigId
                                       where emp.ComId == comid
                                       select new
                                       {
                                           Value = emp.EmpId,
                                           Text = emp.EmpCode + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                                       }).ToList();

                        ViewData["EmpId"] = new SelectList(empInfo, "Value", "Text", issueMain.EmpId);

                        var doctorInfo = (from emp in db.HR_Emp_Info
                                          join d in db.Cat_Department on emp.DeptId equals d.DeptId
                                          join s in db.Cat_Section on emp.SectId equals s.SectId
                                          join des in db.Cat_Designation on emp.DesigId equals des.DesigId
                                          where emp.ComId == comid && des.DesigName.ToUpper().Contains("MEDICAL OFFICER")
                                          orderby emp.EmpCode
                                          select new
                                          {
                                              Value = emp.EmpId,
                                              Text = emp.EmpCode + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                                          }).ToList();

                        ViewData["DoctorId"] = new SelectList(doctorInfo, "Value", "Text", issueMain.DoctorId);
                        ViewData["BOMMainId"] = new SelectList(db.BOMMain.Where(x => x.ComId == comid), "BOMMainId", "AssembleName", issueMain.BOMMainId);

                        #region CategoryId viewbag selectlist
                        List<Category> categorydb = POS.GetCategory(comid).ToList();

                        List<SelectListItem> categoryid = new List<SelectListItem>();
                        //categoryid.Add(new SelectListItem { Text = "--Please Select--", Value = "-1" });
                        categoryid.Add(new SelectListItem { Text = "=ALL=", Value = "0" });



                        //licities.Add(new SelectListItem { Text = "--Select State--", Value = "0" });
                        if (categorydb != null)
                        {
                            foreach (Category x in categorydb)
                            {
                                categoryid.Add(new SelectListItem { Text = x.Name, Value = x.CategoryId.ToString() });
                            }
                        }
                        ViewData["CategoryId"] = (categoryid);
                        #endregion


                        return View("DirectIssue", issueMain);

                    }
                    return View("Create", issueMain);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }


        // POST: Issues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IssueMain issueMain)
        {
            if (id != issueMain.IssueMainId)
            {
                return NotFound();
            }
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");
            var pcname = HttpContext.Session.GetString("pcname");

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(issueMain);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IssueMainExists(issueMain.IssueMainId))
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
            ViewData["SectId"] = new SelectList(db.Cat_Section.Where(x => x.ComId == comid), "SectId", "SectName", issueMain.SectId);
            ViewData["CurrencyId"] = new SelectList(db.Currency.OrderByDescending(x => x.isDefault), "CurrencyId", "CurrencyId", issueMain.CurrencyId);
            //ViewData["PaymentTypeId"] = new SelectList(db.PaymentTypes, "PaymentTypeId", "TypeName", issueMain.PaymentTypeId);
            ViewData["PrdUnitId"] = new SelectList(db.PrdUnits.Where(x => x.comid == comid), "PrdUnitId", "PrdUnitId", issueMain.PrdUnitId);
            ViewData["StoreReqId"] = new SelectList(db.StoreRequisitionMain.Where(x => x.ComId == comid && x.Complete == 0 && x.Status > 0), "StoreReqId", "SRNo", issueMain.StoreReqId);
            ViewData["WarehouseId"] = new SelectList(db.Warehouses.Where(x => x.comid == comid && x.WhType == "L" && x.ParentId != null), "WarehouseId", "WhShortName");
            //ViewData["SupplierId"] = new SelectList(db.Suppliers.Where(x => x.comid == comid), "SupplierId", "City", issueMain.SupplierId);
            return View(issueMain);
        }

        // GET: Issues/Delete/5
        public async Task<IActionResult> Delete(int? id, bool isRateCheck)
        {
            if (id == null)
            {
                return NotFound();
            }
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");
            var pcname = HttpContext.Session.GetString("pcname");




            ViewBag.Title = "Delete";
            var issueMain = await db.IssueMain
                .Include(p => p.IssueSub)
                .ThenInclude(p => p.vProduct)
                .ThenInclude(p => p.vProductUnit)
                .Include(g => g.IssueSub)
                .ThenInclude(g => g.vWarehouse)
                .Include(p => p.IssueSub)
                .ThenInclude(p => p.IssueSubWarehouse)
                .ThenInclude(p => p.vWarehouse)
                .FirstOrDefaultAsync(m => m.IssueMainId == id && m.Status == 0);
            if (issueMain == null)
            {
                return NotFound();
            }

            this.ViewBag.WarehouseList = PL.GetWarehouse().Where(x => x.WhType == "L");

            // set products in session
            POS.SetProductInSession();

            ViewBag.IsSubStore = issueMain.IsSubStore;
            ViewBag.IsRateCheck = isRateCheck;

            if (issueMain.IsSubStore)
            {
                ViewData["SectId"] = new SelectList(db.Cat_Section.Where(x => x.ComId == comid), "SectId", "SectName", issueMain.SectId);
                ViewData["DeptId"] = new SelectList(db.Cat_Department.Where(x => x.ComId == comid), "DeptId", "DeptName", issueMain.DeptId);
                //ViewData["SubSectId"] = new SelectList(db.Cat_SubSection.Where(x => x.ComId == comid), "SubSectId", "SubSectName");
                ViewData["CurrencyId"] = new SelectList(db.Currency.OrderByDescending(x => x.isDefault), "CurrencyId", "CurCode", issueMain.CurrencyId);
                //ViewData["PaymentTypeId"] = new SelectList(db.PaymentTypes, "PaymentTypeId", "TypeName", issueMain.PaymentTypeId);
                ViewData["PrdUnitId"] = new SelectList(PL.GetPrdUnit(), "PrdUnitId", "PrdUnitShortName", issueMain.PrdUnitId);
                //ViewData["StoreReqId"] = new SelectList(db.StoreRequisitionMain.Where(x => x.ComId == comid), "StoreReqId", "SRNo", issueMain.StoreReqId);

                //var storeRequisitions = db.StoreRequisitionMain
                //    .Where(x => x.ComId == comid && x.Complete == 0 && x.Status > 0 && x.IsSubStore == true)
                //    .Select(s => new { Value = s.StoreReqId, Text = s.SRNo + " [S.S.]" });

                //ViewData["StoreReqId"] = new SelectList(storeRequisitions, "Value", "Text", issueMain.StoreReqId);

                //Need to change himu

                //ViewData["WarehouseId"] = new SelectList(db.Warehouses.Where(x => x.comid == comid && x.WhType == "L" && x.ParentId != null && x.IsSubWarehouse == true), "WarehouseId", "WhShortName");

                ViewData["StoreReqId"] = new SelectList(db.StoreRequisitionMain.Where(x => x.ComId == comid && x.StoreReqId == issueMain.StoreReqId), "StoreReqId", "SRNo", issueMain.StoreReqId);
                ViewData["WarehouseId"] = new SelectList(PL.GetWarehouse().Where(x => x.WarehouseId != 0 && x.WhType == "L" && x.ParentId != null && x.IsSubWarehouse == true), "WarehouseId", "WhShortName");
                //ViewData["SupplierId"] = new SelectList(db.Suppliers.Where(x => x.comid == comid), "SupplierId", "SupplierName", issueMain.SupplierId);
                if (issueMain.IsDirectIssue)
                {
                    ViewData["Patient"] = new SelectList(db.Cat_Variable.Where(c => c.VarType == "ReleationType").OrderBy(c => c.SLNo), "VarName", "VarName");
                    var empInfo = (from emp in db.HR_Emp_Info
                                   join d in db.Cat_Department on emp.DeptId equals d.DeptId
                                   join s in db.Cat_Section on emp.SectId equals s.SectId
                                   join des in db.Cat_Designation on emp.DesigId equals des.DesigId
                                   where emp.ComId == comid
                                   select new
                                   {
                                       Value = emp.EmpId,
                                       Text = emp.EmpCode + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                                   }).ToList();

                    ViewData["EmpId"] = new SelectList(empInfo, "Value", "Text", issueMain.EmpId);

                    var doctorInfo = (from emp in db.HR_Emp_Info
                                      join d in db.Cat_Department on emp.DeptId equals d.DeptId
                                      join s in db.Cat_Section on emp.SectId equals s.SectId
                                      join des in db.Cat_Designation on emp.DesigId equals des.DesigId
                                      where emp.ComId == comid && des.DesigName.ToUpper().Contains("MEDICAL OFFICER")
                                      orderby emp.EmpCode
                                      select new
                                      {
                                          Value = emp.EmpId,
                                          Text = emp.EmpCode + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                                      }).ToList();

                    ViewData["DoctorId"] = new SelectList(doctorInfo, "Value", "Text", issueMain.DoctorId);
                    ViewData["BOMMainId"] = new SelectList(db.BOMMain.Where(x => x.ComId == comid), "BOMMainId", "AssembleName", issueMain.BOMMainId);
                    #region CategoryId viewbag selectlist
                    List<Category> categorydb = POS.GetCategory(comid).ToList();

                    List<SelectListItem> categoryid = new List<SelectListItem>();
                    //categoryid.Add(new SelectListItem { Text = "--Please Select--", Value = "-1" });
                    categoryid.Add(new SelectListItem { Text = "=ALL=", Value = "0" });



                    //licities.Add(new SelectListItem { Text = "--Select State--", Value = "0" });
                    if (categorydb != null)
                    {
                        foreach (Category x in categorydb)
                        {
                            categoryid.Add(new SelectListItem { Text = x.Name, Value = x.CategoryId.ToString() });
                        }
                    }
                    ViewData["CategoryId"] = (categoryid);
                    #endregion
                    return View("DirectIssue", issueMain);
                }
                return View("Create", issueMain);
            }
            else
            {
                ViewData["SectId"] = new SelectList(db.Cat_Section.Where(x => x.ComId == comid), "SectId", "SectName", issueMain.SectId);
                //ViewData["SubSectId"] = new SelectList(db.Cat_SubSection.Where(x => x.ComId == comid), "SubSectId", "SubSectName");

                ViewData["CurrencyId"] = new SelectList(db.Currency.OrderByDescending(x => x.isDefault), "CurrencyId", "CurCode", issueMain.CurrencyId);
                //ViewData["PaymentTypeId"] = new SelectList(db.PaymentTypes, "PaymentTypeId", "TypeName", issueMain.PaymentTypeId);
                ViewData["PrdUnitId"] = new SelectList(PL.GetPrdUnit(), "PrdUnitId", "PrdUnitName", issueMain.PrdUnitId);
                //ViewData["StoreReqId"] = new SelectList(db.StoreRequisitionMain.Where(x => x.ComId == comid), "StoreReqId", "SRNo", issueMain.StoreReqId);
                //var storeRequisitions = db.StoreRequisitionMain
                //   .Where(x => x.ComId == comid && x.Complete == 0 && x.Status > 0 && x.IsSubStore == false)
                //   .Select(s => new { Value = s.StoreReqId, Text = s.SRNo });

                ViewData["StoreReqId"] = new SelectList(db.StoreRequisitionMain.Where(x => x.ComId == comid && x.StoreReqId == issueMain.StoreReqId), "StoreReqId", "SRNo", issueMain.StoreReqId);


                ViewData["WarehouseId"] = new SelectList(PL.GetWarehouse().Where(x => x.WarehouseId != 0 && x.WhType == "L" && x.ParentId != null), "WarehouseId", "WhShortName");
                //ViewData["SupplierId"] = new SelectList(db.Suppliers.Where(x => x.comid == comid), "SupplierId", "SupplierName", issueMain.SupplierId);
                if (issueMain.IsDirectIssue)
                {
                    ViewData["Patient"] = new SelectList(db.Cat_Variable.Where(c => c.VarType == "ReleationType").OrderBy(c => c.SLNo), "VarName", "VarName");
                    var empInfo = (from emp in db.HR_Emp_Info
                                   join d in db.Cat_Department on emp.DeptId equals d.DeptId
                                   join s in db.Cat_Section on emp.SectId equals s.SectId
                                   join des in db.Cat_Designation on emp.DesigId equals des.DesigId
                                   where emp.ComId == comid
                                   select new
                                   {
                                       Value = emp.EmpId,
                                       Text = emp.EmpCode + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                                   }).ToList();

                    ViewData["EmpId"] = new SelectList(empInfo, "Value", "Text", issueMain.EmpId);

                    var doctorInfo = (from emp in db.HR_Emp_Info
                                      join d in db.Cat_Department on emp.DeptId equals d.DeptId
                                      join s in db.Cat_Section on emp.SectId equals s.SectId
                                      join des in db.Cat_Designation on emp.DesigId equals des.DesigId
                                      where emp.ComId == comid && des.DesigName.ToUpper().Contains("MEDICAL OFFICER")
                                      orderby emp.EmpCode
                                      select new
                                      {
                                          Value = emp.EmpId,
                                          Text = emp.EmpCode + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                                      }).ToList();

                    ViewData["DoctorId"] = new SelectList(doctorInfo, "Value", "Text", issueMain.DoctorId);
                    ViewData["BOMMainId"] = new SelectList(db.BOMMain.Where(x => x.ComId == comid), "BOMMainId", "AssembleName", issueMain.BOMMainId);
                    #region CategoryId viewbag selectlist
                    List<Category> categorydb = POS.GetCategory(comid).ToList();

                    List<SelectListItem> categoryid = new List<SelectListItem>();
                    //categoryid.Add(new SelectListItem { Text = "--Please Select--", Value = "-1" });
                    categoryid.Add(new SelectListItem { Text = "=ALL=", Value = "0" });



                    //licities.Add(new SelectListItem { Text = "--Select State--", Value = "0" });
                    if (categorydb != null)
                    {
                        foreach (Category x in categorydb)
                        {
                            categoryid.Add(new SelectListItem { Text = x.Name, Value = x.CategoryId.ToString() });
                        }
                    }
                    ViewData["CategoryId"] = (categoryid);
                    #endregion
                    return View("DirectIssue", issueMain);
                }
                return View("Create", issueMain);
            }
        }

        // POST: Issues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {


                //var issueMain = await db.IssueMain.FindAsync(id);
                var issueMain = await db.IssueMain
                   .Include(p => p.IssueSub)
                   .Include(p => p.IssueSub).ThenInclude(p => p.IssueSubWarehouse)
                   .FirstOrDefaultAsync(m => m.IssueMainId == id && m.Status == 0);
                if (issueMain == null)
                {
                    return NotFound();
                }


                if (issueMain.IsDirectIssue)
                {
                    var costCalculations = await db.CostCalculated.Where(a => a.isDelete == true && a.IssueMainId == issueMain.IssueMainId).ToListAsync();

                    if (costCalculations.Count > 0)
                    {
                        foreach (var item in costCalculations)
                        {
                            item.DeletedDocNo = "Issue Main Id: " + item.IssueMainId;
                            item.IssueMainId = null;
                            db.Entry(item).State = EntityState.Modified;
                            await db.SaveChangesAsync();
                        }
                    }
                }
                else
                {
                    var costCalculationsissue = await db.CostCalculated.Where(a => a.isDelete == true && a.IssueMainId == issueMain.IssueMainId).ToListAsync();

                    if (costCalculationsissue.Count > 0)
                    {
                        foreach (var item in costCalculationsissue)
                        {
                            item.DeletedDocNo = "Issue Main Id: " + item.IssueMainId;
                            item.IssueMainId = null;
                            db.Entry(item).State = EntityState.Modified;
                            await db.SaveChangesAsync();
                        }
                    }

                    var costCalculationsSR = await db.CostCalculated.Where(a => a.isDelete == true && a.StoreReqId == issueMain.StoreReqId && a.StoreReqId != null).ToListAsync();

                    if (costCalculationsSR.Count > 0)
                    {
                        foreach (var item in costCalculationsSR)
                        {
                            item.DeletedDocNo = "Store Req Id: " + item.StoreReqId;
                            item.StoreReqId = null;
                            db.Entry(item).State = EntityState.Modified;
                            await db.SaveChangesAsync();
                        }
                    }

                    /// remove sub warehouse receiving data
                    foreach (var item in issueMain.IssueSub)
                    {
                        db.RemoveRange(item.IssueSubWarehouse);
                        await db.SaveChangesAsync();
                    }
                }




                /// remove sub data
                db.RemoveRange(issueMain.IssueSub);
                db.RemoveRange(issueMain);

                await db.SaveChangesAsync();

                return Json(new { Success = 1, ex = "Data Delete Successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex });

                throw ex;
            }
            //return RedirectToAction(nameof(Index));
        }


        public JsonResult GetProducts(int? id)
        {
            var comid = HttpContext.Session.GetString("comid");
            IEnumerable<object> product;
            if (id != null)
            {
                if (id == 0 || id == -1)
                {
                    //product = db.Products.Where(x => x.comid == comid).Select(x => new { x.ProductId, x.ProductName }).ToList();
                    product = new SelectList(db.Products.Where(x => x.AccIdInventory != x.AccIdConsumption).Where(x => x.comid == comid && x.AccIdConsumption > 0).Select(s => new { Text = s.ProductName + " - [ " + s.ProductCode + " ]", Value = s.ProductId }).ToList(), "Value", "Text");

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

        private bool IssueMainExists(int id)
        {
            return db.IssueMain.Any(e => e.IssueMainId == id);
        }


        [HttpPost, ActionName("PrintIssueSummary")]
        public JsonResult PrintIssueSummary(string rptFormat, string action, string FromDate, string ToDate, string PrdUnitId)
        {
            try
            {
                string comid = HttpContext.Session.GetString("comid");

                var reportname = "";
                var filename = "";
                string redirectUrl = "";
                //return Json(new { Success = 1, TermsId = param, ex = "" });
                if (action == "PrintIssueSummary")
                {
                    //redirectUrl = new UrlHelper(Request.RequestContext).Action(action, "COM_BBLC_Master", new { FromDate = FromDate, ToDate = ToDate, Supplierid = SupplierId, CommercialCompanyId = CommercialCompanyId }); //, new { companyId = "7e96b930-a786-44dd-8576-052ce608e38f" }
                    reportname = "rptIssueSummary";
                    filename = "rptIssueSummary" + DateTime.Now.Date.ToString();
                    var query = "Exec [Inv_rptIssueSummary] '" + comid + "'";
                    HttpContext.Session.SetString("reportquery", "Exec [Inv_rptIssueSummary] '" + comid + "','" + FromDate + "','" + ToDate + "' , '" + PrdUnitId + "'  ");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Inventory/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }


                string DataSourceName = "DataSet1";

                //HttpContext.Session.SetObject("Acc_rptList", postData);

                //Common.Classes.clsMain.intHasSubReport = 0;
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");// Session["ReportPath"].ToString();
                clsReport.strQueryMain = HttpContext.Session.GetString("reportquery");
                clsReport.strDSNMain = DataSourceName;

                //var ConstrName = "ApplicationServices";
                //string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat }); //this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat }); //Repository.GenerateReport(clsReport.strReportPathMain, clsReport.strQueryMain, ConstrName, rptFormat);
                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat });
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




        [HttpPost, ActionName("PrintIssueDetails")]
        public JsonResult IssueDetailsReport(string rptFormat, string action, string FromDate, string ToDate, string PrdUnitId)
        {
            try
            {
                string comid = HttpContext.Session.GetString("comid");

                var reportname = "";
                var filename = "";
                string redirectUrl = "";
                //return Json(new { Success = 1, TermsId = param, ex = "" });
                if (action == "PrintIssueDetails")
                {
                    //redirectUrl = new UrlHelper(Request.RequestContext).Action(action, "COM_BBLC_Master", new { FromDate = FromDate, ToDate = ToDate, Supplierid = SupplierId, CommercialCompanyId = CommercialCompanyId }); //, new { companyId = "7e96b930-a786-44dd-8576-052ce608e38f" }
                    reportname = "rptIssueDetails";
                    filename = "IssueDetails" + DateTime.Now.Date.ToString();
                    var query = "Exec [Inv_IssueDetails] '" + comid + "'";
                    HttpContext.Session.SetString("reportquery", "Exec [Inv_IssueDetails] '" + comid + "','" + FromDate + "','" + ToDate + "', '" + PrdUnitId + "' ");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Inventory/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }


                string DataSourceName = "DataSet1";

                //HttpContext.Session.SetObject("Acc_rptList", postData);

                //Common.Classes.clsMain.intHasSubReport = 0;
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");// Session["ReportPath"].ToString();
                clsReport.strQueryMain = HttpContext.Session.GetString("reportquery");
                clsReport.strDSNMain = DataSourceName;

                //var ConstrName = "ApplicationServices";
                //string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat }); //this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat }); //Repository.GenerateReport(clsReport.strReportPathMain, clsReport.strQueryMain, ConstrName, rptFormat);
                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat });
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



        [HttpPost, ActionName("PrintIssueVoucher")]
        public JsonResult PrintIssueVoucher(string rptFormat, string action, string FromDate, string ToDate, string PrdUnitId)
        {
            try
            {
                string comid = HttpContext.Session.GetString("comid");

                var reportname = "";
                var filename = "";
                string redirectUrl = "";
                //return Json(new { Success = 1, TermsId = param, ex = "" });
                if (action == "PrintIssueVoucher")
                {
                    //redirectUrl = new UrlHelper(Request.RequestContext).Action(action, "COM_BBLC_Master", new { FromDate = FromDate, ToDate = ToDate, Supplierid = SupplierId, CommercialCompanyId = CommercialCompanyId }); //, new { companyId = "7e96b930-a786-44dd-8576-052ce608e38f" }
                    reportname = "rptIssueVoucher";
                    filename = "IssueVoucher" + DateTime.Now.Date.ToString();
                    var query = "Exec [Inv_IssueVoucher] '" + comid + "'";
                    HttpContext.Session.SetString("reportquery", "Exec [Inv_IssueVoucher] '" + comid + "','" + FromDate + "','" + ToDate + "',0,'" + PrdUnitId + "' ");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Inventory/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }


                string DataSourceName = "DataSet1";

                //HttpContext.Session.SetObject("Acc_rptList", postData);

                //Common.Classes.clsMain.intHasSubReport = 0;
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");// Session["ReportPath"].ToString();
                clsReport.strQueryMain = HttpContext.Session.GetString("reportquery");
                clsReport.strDSNMain = DataSourceName;

                //var ConstrName = "ApplicationServices";
                //string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat }); //this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat }); //Repository.GenerateReport(clsReport.strReportPathMain, clsReport.strQueryMain, ConstrName, rptFormat);
                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat });
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







        [HttpPost, ActionName("PrintMissingSequence")]
        public JsonResult PrintMissingSequence(string rptFormat, string action, string Type, string FromNo, string ToNo, string PrdUnitId, string FromDate, string ToDate)
        {
            try
            {
                string comid = HttpContext.Session.GetString("comid");

                var reportname = "";
                var filename = "";
                string redirectUrl = "";
                //return Json(new { Success = 1, TermsId = param, ex = "" });
                if (action == "PrintMissingSequence")
                {
                    //redirectUrl = new UrlHelper(Request.RequestContext).Action(action, "COM_BBLC_Master", new { FromDate = FromDate, ToDate = ToDate, Supplierid = SupplierId, CommercialCompanyId = CommercialCompanyId }); //, new { companyId = "7e96b930-a786-44dd-8576-052ce608e38f" }
                    reportname = "rpt_MissingSequence";
                    filename = "rpt_MissingSequence" + DateTime.Now.Date.ToString();
                    var query = "Exec [rpt_MissingSequence] '" + comid + "' , ";
                    HttpContext.Session.SetString("reportquery", "Exec [rpt_MissingSequence] '" + comid + "',  '" + Type + "' , '" + FromNo + "','" + ToNo + "' , '" + PrdUnitId + "' , '" + FromDate + "' , '" + ToDate + "' ");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Inventory/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                }


                string DataSourceName = "DataSet1";

                //HttpContext.Session.SetObject("Acc_rptList", postData);

                //Common.Classes.clsMain.intHasSubReport = 0;
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");// Session["ReportPath"].ToString();
                clsReport.strQueryMain = HttpContext.Session.GetString("reportquery");
                clsReport.strDSNMain = DataSourceName;

                //var ConstrName = "ApplicationServices";
                //string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat }); //this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat }); //Repository.GenerateReport(clsReport.strReportPathMain, clsReport.strQueryMain, ConstrName, rptFormat);
                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat });
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

    }
}
