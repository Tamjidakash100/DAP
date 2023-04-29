using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
//using AlanJuden.MvcReportViewer;

namespace GTERP.Controllers.Account
{
    [OverridableAuthorize]
    public class PostDocumentController : Controller
    {
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
        private GTRDBContext db;
        //public CommercialRepository Repository { get; set; } ///for report service
        PermissionLevel PL;
        public PostDocumentController(GTRDBContext _db, PermissionLevel _pl)
        {
            db = _db;
            // Repository = repository; ///for report service
            PL = _pl;
        }

        public static List<SelectListItem> DocTypeList = new List<SelectListItem>()
        {
            new SelectListItem() { Text="Store Requisition", Value="SRR"},
            new SelectListItem() { Text="Issue", Value="ISSUE"},
            new SelectListItem() { Text="Purchase Requisition", Value="PR"},
            new SelectListItem() { Text="Purchase Order", Value="PO"},
            new SelectListItem() { Text="Goods Receive", Value="GRR"}
        };

        /// <summary>
        /// only for create production module
        /// </summary>
        public static List<SelectListItem> DocTypeListProduction = new List<SelectListItem>()
        {
            new SelectListItem() { Text="Store Requistion", Value="GRR"},
            new SelectListItem() { Text="Transfer", Value="SRR"},
            new SelectListItem() { Text="Issue", Value="ISSUE"},
            //new SelectListItem() { Text="Purchase Requisition", Value="PR"},
           // new SelectListItem() { Text="Purchase Order", Value="PO"},
            
        };

        // GET: Acc_VoucherMain
        public ViewResult Index(string FromDate, string ToDate, string criteria, string DocType, int DeptId, int PrdUnitId)
        {
            var transactioncomid = HttpContext.Session.GetString("comid");
            //var comid = HttpContext.Session.GetString("comid");
            //var userid = HttpContext.Session.GetString("userid");


            DateTime dtFrom = Convert.ToDateTime(DateTime.Now.Date.ToString("dd-MMM-yy"));
            DateTime dtTo = Convert.ToDateTime(DateTime.Now.Date.ToString("dd-MMM-yy"));
            if (criteria == null)
            {
                criteria = "UnPost";
            }

            UserPermission permission = HttpContext.Session.GetObject<UserPermission>("userpermission");
            if (permission.IsProduction)
            {
                ViewData["DocType"] = new SelectList(DocTypeListProduction, "Value", "Text");
            }
            else
            {
                ViewData["DocType"] = new SelectList(DocTypeList, "Value", "Text");
            }

            ViewData["DeptId"] = new SelectList(db.Cat_Department, "DeptId", "DeptName");
            ViewData["PrdUnitId"] = new SelectList(PL.GetPrdUnit().Select(x => new { x.PrdUnitId, x.PrdUnitShortName }), "PrdUnitId", "PrdUnitShortName", PrdUnitId);


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
            //ViewBag.Acc_VoucherNoPrefix = db.Acc_VoucherNoPrefixes.Include(x => x.vVoucherTypes).Where(x => x.isVisible == true && x.vVoucherTypes.isSystem == false).ToList();

            //transactioncomid = "1";
            //var a = ;
            // return View(db.Acc_VoucherMains.Where(p => p.ComId == transactioncomid).ToList());

            List<DocumentList> doclist = new List<DocumentList>();
            DocumentList doc;

            ViewBag.Isleave = false;
            ViewBag.Title = criteria;
            var srrlist = db.StoreRequisitionMain.Take(0).ToList();
            var issuelist = db.IssueMain.Take(0).ToList();
            var prlist = db.PurchaseRequisitionMain.Take(0).ToList();
            var polist = db.PurchaseOrderMain.Take(0).ToList();
            var grrlist = db.GoodsReceiveMain.Take(0).ToList();

            var lvList = new List<HR_Leave_Avail>();


            if (DocType == "SRR")
            {
                if (criteria == "All")
                {
                    srrlist = PL.GetSRR().Where(p => p.ReqDate >= dtFrom && p.ReqDate <= dtTo).ToList();
                }
                else if (criteria == "Post")
                {
                    srrlist = PL.GetSRR().Where(p => p.ReqDate >= dtFrom && p.ReqDate <= dtTo && p.Status > 0).OrderByDescending(o => o.StoreReqId).ToList();
                }
                else if (criteria == "UnPost")
                {
                    srrlist = PL.GetSRR().Where(p => p.ReqDate >= dtFrom && p.ReqDate <= dtTo && p.Status == 0).OrderBy(p => p.ReqDate).ToList();
                }



                foreach (var item in srrlist)
                {
                    doc = new DocumentList();
                    doc.DocumentId = item.StoreReqId;
                    doc.DocumentNo = item.SRNo;
                    doc.DocumentDate = item.ReqDate.ToString("dd-MMM-yy");
                    doc.DocumentType = "SRR";
                    doc.NetAmount = 0;
                    doc.Remarks = item.Remarks;
                    doc.DocumentStatus = item.Status.ToString() != "0" ? "Posted" : "Not Posted";

                    doclist.Add(doc);
                }
            }
            if (DocType == "ISSUE")
            {
                if (criteria == "All")
                {
                    issuelist = PL.GetIssue().Where(p => p.IssueDate >= dtFrom && p.IssueDate <= dtTo && p.PrdUnitId == PrdUnitId).ToList();
                }
                else if (criteria == "Post")
                {
                    issuelist = PL.GetIssue().Where(p => p.IssueDate >= dtFrom && p.IssueDate <= dtTo && p.PrdUnitId == PrdUnitId && p.Status > 0).OrderByDescending(o => o.IssueMainId).ToList();
                }
                else if (criteria == "UnPost")
                {
                    issuelist = PL.GetIssue().Where(p => p.IssueDate >= dtFrom && p.IssueDate <= dtTo && p.PrdUnitId == PrdUnitId && p.Status == 0).OrderBy(p => p.IssueDate).ToList();
                }



                foreach (var item in issuelist)
                {
                    doc = new DocumentList();
                    doc.DocumentId = item.IssueMainId;
                    doc.DocumentNo = "IN No : " + item.IssueNo + " SRR No : " + item.ManualSRRNo;
                    doc.DocumentDate = item.IssueDate.ToString("dd-MMM-yy");
                    doc.DocumentType = "ISSUE";
                    doc.NetAmount = item.NetIssueValue; //(decimal)item.NetIssueValue;
                    doc.Remarks = item.Remarks;
                    doc.DocumentStatus = item.Status.ToString() != "0" ? "Posted" : "Not Posted";

                    doclist.Add(doc);
                }
            }
            if (DocType == "PR")
            {
                if (criteria == "All")
                {
                    prlist = PL.GetPR().Where(p => p.ReqDate >= dtFrom && p.ReqDate <= dtTo).ToList();
                }
                else if (criteria == "Post")
                {
                    prlist = PL.GetPR().Where(p => p.ReqDate >= dtFrom && p.ReqDate <= dtTo && p.Status > 0).OrderByDescending(o => o.PurReqId).ToList();
                }
                else if (criteria == "UnPost")
                {
                    prlist = PL.GetPR().Where(p => p.ReqDate >= dtFrom && p.ReqDate <= dtTo && p.Status == 0).OrderBy(p => p.ReqDate).ToList();
                }

                foreach (var item in prlist)
                {
                    doc = new DocumentList();
                    doc.DocumentId = item.PurReqId;
                    doc.DocumentNo = item.PRNo;
                    doc.DocumentDate = item.ReqDate.ToString("dd-MMM-yy");
                    doc.DocumentType = "PR";
                    doc.NetAmount = 0;
                    doc.Remarks = item.Remarks;
                    doc.DocumentStatus = item.Status.ToString() != "0" ? "Posted" : "Not Posted";

                    doclist.Add(doc);
                }
            }
            if (DocType == "PO")
            {
                if (criteria == "All")
                {
                    polist = PL.GetPO().Where(p => p.PODate >= dtFrom && p.PODate <= dtTo).ToList();
                }
                else if (criteria == "Post")
                {
                    polist = PL.GetPO().Where(p => p.PODate >= dtFrom && p.PODate <= dtTo && p.Status > 0).OrderByDescending(o => o.PurOrderMainId).ToList();
                }
                else if (criteria == "UnPost")
                {
                    polist = db.PurchaseOrderMain.Where(p => p.PODate >= dtFrom && p.PODate <= dtTo && p.Status == 0).OrderBy(p => p.PODate).ToList();
                }

                foreach (var item in polist)
                {
                    doc = new DocumentList();
                    doc.DocumentId = item.PurOrderMainId;
                    doc.DocumentNo = item.PONo;
                    doc.DocumentDate = item.PODate.ToString("dd-MMM-yy");
                    doc.DocumentType = "PO";
                    doc.NetAmount = item.TotalPOValue;
                    doc.Remarks = item.Remarks;
                    doc.DocumentStatus = item.Status.ToString() != "0" ? "Posted" : "Not Posted";

                    doclist.Add(doc);
                }
            }
            if (DocType == "GRR")
            {
                if (criteria == "All")
                {
                    grrlist = PL.GetGRR().Where(p => p.GRRDate >= dtFrom && p.GRRDate <= dtTo).ToList();
                }
                else if (criteria == "Post")
                {
                    grrlist = PL.GetGRR().Where(p => p.GRRDate >= dtFrom && p.GRRDate <= dtTo && p.Status > 0).OrderByDescending(o => o.GRRMainId).ToList();
                }
                else if (criteria == "UnPost")
                {
                    grrlist = PL.GetGRR().Where(p => p.GRRDate >= dtFrom && p.GRRDate <= dtTo && p.Status == 0).OrderBy(p => p.GRRDate).ToList();
                }


                foreach (var item in grrlist)
                {
                    doc = new DocumentList();
                    doc.DocumentId = item.GRRMainId;
                    doc.DocumentNo = item.GRRNo;
                    doc.DocumentDate = item.GRRDate.ToString("dd-MMM-yy");
                    doc.DocumentType = "GRR";
                    doc.NetAmount = item.NetGRRValue;
                    doc.Remarks = item.Remarks;
                    doc.DocumentStatus = item.Status.ToString() != "0" ? "Posted" : "Not Posted";

                    doclist.Add(doc);
                }
            }
            if (DocType == "Leave")
            {
                ViewBag.Isleave = true;
                if (criteria == null)
                {
                    criteria = "Pending";
                }

                ViewBag.Title = criteria;
                if (criteria == "All")
                {
                    lvList = db.HR_Leave_Avail.Include(l => l.HR_Emp_Info).ThenInclude(l => l.Cat_Department).Where(p => p.ComId == transactioncomid && p.DtInput.Value.Date >= dtFrom.Date &&
                        p.DtInput.Value.Date <= dtTo.Date && p.HR_Emp_Info.DeptId == DeptId).ToList();
                }
                else if (criteria == "Pending")
                {
                    ViewBag.Title = criteria;
                    lvList = db.HR_Leave_Avail.Include(l => l.HR_Emp_Info).ThenInclude(l => l.Cat_Department).Where(p => p.ComId == transactioncomid && p.DtInput.Value.Date >= dtFrom.Date &&
                    p.DtInput.Value.Date <= dtTo.Date && p.HR_Emp_Info.DeptId == DeptId && p.Status == 0).ToList();
                }
                else if (criteria == "Approved")
                {
                    lvList = db.HR_Leave_Avail.Include(l => l.HR_Emp_Info).Include(l => l.HR_Emp_Info.Cat_Department).Where(p => p.ComId == transactioncomid && (p.DtInput.Value.Date >= dtFrom.Date &&
                    p.DtInput.Value.Date <= dtTo.Date) && p.HR_Emp_Info.DeptId == DeptId && p.Status == 1).ToList();
                }
                else if (criteria == "DisApproved")
                {
                    lvList = db.HR_Leave_Avail.Include(l => l.HR_Emp_Info).Include(l => l.HR_Emp_Info.Cat_Department).Where(p => p.ComId == transactioncomid && (p.DtInput.Value.Date >= dtFrom.Date &&
                    p.DtInput.Value.Date <= dtTo.Date) && p.HR_Emp_Info.DeptId == DeptId && p.Status == 2).ToList();
                }


                foreach (var item in lvList)
                {
                    doc = new DocumentList();
                    doc.DocumentId = item.LvId;
                    doc.DocumentNo = item.HR_Emp_Info != null ? item.HR_Emp_Info.EmpCode + "-" + item.HR_Emp_Info.EmpName : "";
                    doc.DocumentDate = item.DtFrom.ToString("dd-MMM-yy") + " - " + item.DtTo.ToString("dd-MMM-yy");
                    doc.DocumentType = item.LvType;
                    doc.Remarks = item.TotalDay.ToString();

                    if (item.Status == 0) doc.DocumentStatus = "Pending";
                    else if (item.Status == 1) doc.DocumentStatus = "Approved";
                    else if (item.Status == 2) doc.DocumentStatus = "DisApproved";

                    //doc.DeptId = item.HR_Emp_Info.Cat_Department.DeptName;

                    doclist.Add(doc);
                }
            }

            return View(doclist);
        }



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(Acc_VoucherMain model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var values = prcSaveData(model);
        //            ViewBag["Message"] = values;
        //            if (values == "Data Posted Successfuly")
        //            {
        //                TempData["successmessage"] = values;
        //                return RedirectToAction("Index");
        //            }
        //            ViewBag.IsError = true;
        //            ModelState.AddModelError("CustomError", values);
        //            return View(model);
        //        }
        //        return View(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.IsError = true;
        //        ModelState.AddModelError("CustomError", ex.Message);
        //        return View(model);
        //    }
        //}
        public ActionResult Print(int? id, string type, string docname)
        {
            try
            {


                var comid = HttpContext.Session.GetString("comid");
                var userid = HttpContext.Session.GetString("userid");
                string SqlCmd = "";
                string ReportPath = "";
                var ConstrName = "ApplicationServices";
                var ReportType = "PDF";
                string DataSourceName = "DataSet1";
                string filename = "";
                var reportname = "";


                if (docname.ToUpper() == "Issue".ToUpper())
                {
                    reportname = "rptSRForm";
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Inventory/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("reportquery", "Exec [Inv_rptIndIssueDetails] '" + comid + "', 'ISSUENW' ," + id + ", '01-Jan-1900', '01-Jan-1900'");

                    filename = db.IssueMain.Where(x => x.IssueMainId == id).Select(x => x.IssueNo).Single();
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                    //var a = Session["PrintFileName"].ToString();



                    HttpContext.Session.SetObject("rptList", postData);
                }
                else if (docname.ToUpper() == "Store Requisition".ToUpper())
                {
                    reportname = "rptSRForm";
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Inventory/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("reportquery", "Exec [Inv_rptIndIssueDetails] '" + comid + "', 'ISSUENW' ," + id + ", '01-Jan-1900', '01-Jan-1900'");

                    filename = db.IssueMain.Where(x => x.IssueMainId == id).Select(x => x.IssueNo).Single();
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                    //var a = Session["PrintFileName"].ToString();



                    HttpContext.Session.SetObject("rptList", postData);
                }
                else if (docname.ToUpper() == "Purchase Requisition".ToUpper())
                {
                    reportname = "rptSRForm";
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Inventory/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("reportquery", "Exec [Inv_rptIndIssueDetails] '" + comid + "', 'ISSUENW' ," + id + ", '01-Jan-1900', '01-Jan-1900'");

                    filename = db.IssueMain.Where(x => x.IssueMainId == id).Select(x => x.IssueNo).Single();
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                    //var a = Session["PrintFileName"].ToString();



                    HttpContext.Session.SetObject("rptList", postData);
                }
                else if (docname.ToUpper() == "Purchase Order".ToUpper())
                {
                    reportname = "rptSRForm";
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Inventory/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("reportquery", "Exec [Inv_rptIndIssueDetails] '" + comid + "', 'ISSUENW' ," + id + ", '01-Jan-1900', '01-Jan-1900'");

                    filename = db.IssueMain.Where(x => x.IssueMainId == id).Select(x => x.IssueNo).Single();
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                    //var a = Session["PrintFileName"].ToString();



                    HttpContext.Session.SetObject("rptList", postData);
                }
                else if (docname.ToUpper() == "Goods Receive".ToUpper())
                {
                    reportname = "rptMRRForm";
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Inventory/" + reportname + ".rdlc");
                    HttpContext.Session.SetString("reportquery", "Exec [Inv_rptIndGRRDetails] '" + comid + "', 'ISSUENW' ," + id + ", '01-Jan-1900', '01-Jan-1900'");

                    filename = db.IssueMain.Where(x => x.IssueMainId == id).Select(x => x.IssueNo).Single();
                    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                    //var a = Session["PrintFileName"].ToString();



                    HttpContext.Session.SetObject("rptList", postData);
                }

                //else if (docname == "")
                //{

                //    reportname = "rptShowVoucher";


                //    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Accounts/" + reportname + ".rdlc");
                //    var str = db.Acc_VoucherMains.Include(x => x.Acc_VoucherType).FirstOrDefault().Acc_VoucherType.VoucherTypeNameShort;// "VPC";
                //    var Currency = "1";
                //    HttpContext.Session.SetString("reportquery", "Exec Acc_rptVoucher 0, 'VID','All','dapa26-414a-44e4-a287-18e846b51d99', '01-Jan-1900', '01-Jan-1900', '" + str + "','" + str + "', " + id + ", " + Currency + ", 0");


                //    //Session["reportquery"] = "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.[rptCommercialInvoice_Export] '" + id + "','" + AppData.AppData.intComId + "'";
                //    filename = db.StoreRequisitionMain.Where(x => x.StoreReqId == id).Select(x => x.SRNo + "_" + x.ReqRef).Single();
                //    HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


                //    //postData.Add(1, new subReport("rptInvoice_Terms", "", "DataSet1", "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.rptInvoice_Terms '" + id + "','" +HttpContext.Session.GetString("comid"); + "',''"));

                //    HttpContext.Session.SetObject("rptList", postData);
                //}




                //Common.Classes.clsMain.intHasSubReport = 0;
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("reportquery");
                clsReport.strDSNMain = DataSourceName;




                SqlCmd = clsReport.strQueryMain;
                ReportPath = clsReport.strReportPathMain;
                ReportType = "PDF";

                //string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); // this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //Repository.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);
                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType });
                return Redirect(callBackUrl);

                ///return RedirectToAction("Index", "ReportViewer");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [Obsolete]
        [ValidateAntiForgeryToken]
        public JsonResult SetProcess(string[] docid, string criteria, string[] doctype)
        {
            try
            {
                string[] docidsuccess = new string[docid.Length + 1];
                var comid = HttpContext.Session.GetString("comid");
                var userid = HttpContext.Session.GetString("userid");
                //using (var tr = db.Database.BeginTransaction())
                //{
                string data = "";
                //try
                //{
                if (criteria.ToUpper().ToString() == "Post".ToUpper())
                {
                    if (docid.Count() > 0)
                    {
                        for (var i = 0; i < docid.Count(); i++)
                        {
                            string docidsingle = docid[i];
                            string doctypesingle = doctype[i];

                            if (doctypesingle == "SRR")
                            {
                                var singlevoucher = db.StoreRequisitionMain.Where(x => x.StoreReqId == int.Parse(docidsingle) && x.Status == 0).FirstOrDefault();
                                if (singlevoucher != null)
                                {
                                    singlevoucher.Status = 1;
                                    db.Entry(singlevoucher).State = EntityState.Modified;
                                }
                            }
                            else if (doctypesingle == "ISSUE")
                            {

                                var singlevoucher = db.IssueMain.Include(x => x.IssueSub).ThenInclude(x => x.IssueSubWarehouse).Where(x => x.IssueMainId == int.Parse(docidsingle) && x.Status == 0).FirstOrDefault();

                                if (singlevoucher != null)
                                {
                                    var singlestorerequisition = db.StoreRequisitionMain.Where(x => x.StoreReqId == singlevoucher.StoreReqId).FirstOrDefault();
                                    using (var tr = db.Database.BeginTransaction())
                                    {
                                        try
                                        {

                                            if (singlevoucher.IsDirectIssue)
                                            {

                                                foreach (IssueSub ss in singlevoucher.IssueSub)
                                                {
                                                    Inventory inv = db.Inventory.Where(x => x.ProductId == ss.ProductId && x.WareHouseId == ss.WarehouseId).FirstOrDefault();
                                                    CostCalculated cstcal = db.CostCalculated.Where(x => x.ProductId == ss.ProductId && x.WarehouseId == ss.WarehouseId && x.isDelete == false).OrderByDescending(x => x.CostCalculatedId).FirstOrDefault();

                                                    if (inv != null) ///added by fahad for solving error if no ware house found then no update of the data
                                                    {
                                                        if (cstcal == null)
                                                        {
                                                            var productname = db.Products.Where(x => x.ProductId == inv.ProductId).Select(x => x.ProductName).FirstOrDefault();
                                                            var warehousename = db.Warehouses.Where(x => x.WarehouseId == inv.WareHouseId).Select(x => x.WhName).FirstOrDefault();

                                                            var msg = "Document no: " + singlevoucher.IssueNo + " " + productname + " not Stock in the " + warehousename + ".";
                                                            return Json(new { Success = "3", ex = msg, docidsuccess = docidsuccess });
                                                        }

                                                        //if (inv.CurrentStock >= ss.IssueQty)
                                                        if (cstcal.WarehouseId == 1 && cstcal.ProductId == ss.ProductId && cstcal.WarehouseId == ss.WarehouseId && cstcal.CurrQty == -(ss.IssueQty) && cstcal.IssueMainId == ss.IssueMainId)
                                                        {
                                                            return Json(new { Success = "3", ex = "Duplicate Data Found.Can't do Process. Please contact with your Administrator.", docidsuccess = docidsuccess });
                                                        }

                                                        if (cstcal.PrevQty + cstcal.CurrQty >= ss.IssueQty || cstcal.ProductId == 13729 || cstcal.ProductId == 13730)/// special for production finishing goods
                                                        {

                                                            inv.IssueQty = inv.IssueQty + ss.IssueQty;
                                                            //inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty);
                                                            inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty + inv.GoodsReceiveQty + inv.IssueRtnQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty + inv.IssueQty + inv.GoodsRcvRtnQty);

                                                            db.Entry(inv).State = EntityState.Modified;
                                                        }
                                                        else
                                                        {
                                                            var productname = db.Products.Where(x => x.ProductId == inv.ProductId).Select(x => x.ProductName).FirstOrDefault();
                                                            var warehousename = db.Warehouses.Where(x => x.WarehouseId == inv.WareHouseId).Select(x => x.WhName).FirstOrDefault();

                                                            var msg = "Document no: " + singlevoucher.IssueNo + " " + productname + " not Stock in the " + warehousename + ". Warehouse Qty is " + (cstcal.PrevQty + cstcal.CurrQty) + ". Total Shortage Qty is " + (ss.IssueQty - (cstcal.PrevQty + cstcal.CurrQty)) + ".";
                                                            return Json(new { Success = "3", ex = msg, docidsuccess = docidsuccess });
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //var comid = HttpContext.Session.GetString("comid");
                                                        //var userid = HttpContext.Session.GetString("userid");
                                                        //var productname = db.Products.Where(x => x.ProductId == inv.ProductId).Select(x => x.ProductName).FirstOrDefault();
                                                        //var msg = "No warehouse found for this "+ productname;
                                                        //return Json(new { Success = "3", ex = msg });

                                                        Inventory insertinv = new Inventory();

                                                        insertinv.ProductId = int.Parse(ss.ProductId.ToString());
                                                        insertinv.WareHouseId = int.Parse(ss.WarehouseId.ToString());
                                                        insertinv.OpStock = 0;

                                                        insertinv.PurQty = 0;
                                                        insertinv.PurRetQty = 0;
                                                        insertinv.PurExcQty = 0;

                                                        insertinv.SalesQty = 0;
                                                        insertinv.SalesRetQty = 0;
                                                        insertinv.SalesExcQty = 0;

                                                        insertinv.ChallanQty = 0;
                                                        insertinv.EnStock = 0;
                                                        insertinv.CurrentStock = 0;

                                                        insertinv.GoodsReceiveQty = 0;
                                                        insertinv.IssueQty = 0;
                                                        insertinv.GoodsRcvRtnQty = 0;
                                                        insertinv.IssueRtnQty = 0;

                                                        insertinv.comid = comid;
                                                        insertinv.userid = userid;
                                                        insertinv.useridUpdate = userid;
                                                        insertinv.DateAdded = DateTime.Now;
                                                        insertinv.DateUpdated = DateTime.Now;
                                                        insertinv.OpeningStockDate = ss.IssueMain.IssueDate;
                                                        insertinv.Remarks = "Auto From Issue Post";
                                                        db.Entry(insertinv).State = EntityState.Added;
                                                        db.SaveChanges();

                                                        inv = db.Inventory.Where(x => x.ProductId == ss.ProductId && x.WareHouseId == ss.WarehouseId).FirstOrDefault();

                                                        inv.IssueQty = inv.IssueQty + ss.IssueQty;
                                                        //inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty);
                                                        inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty + inv.GoodsReceiveQty + inv.IssueRtnQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty + inv.IssueQty + inv.GoodsRcvRtnQty);
                                                        db.Entry(inv).State = EntityState.Modified;
                                                    }
                                                }


                                            }
                                            else
                                            {


                                                foreach (IssueSub ss in singlevoucher.IssueSub)
                                                {
                                                    foreach (IssueSubWarehouse wh in ss.IssueSubWarehouse)
                                                    {
                                                        Inventory inv = db.Inventory.Where(x => x.ProductId == wh.ProductId && x.WareHouseId == wh.WarehouseId).FirstOrDefault();

                                                        CostCalculated cstcal = db.CostCalculated.Where(x => x.ProductId == ss.ProductId && x.WarehouseId == wh.WarehouseId && x.isDelete == false).OrderByDescending(x => x.CostCalculatedId).FirstOrDefault();
                                                        var productname = db.Products.Where(x => x.ProductId == ss.ProductId).Select(x => x.ProductName).FirstOrDefault();
                                                        var warehousename = db.Warehouses.Where(x => x.WarehouseId == wh.WarehouseId).Select(x => x.WhName).FirstOrDefault();

                                                        if (cstcal != null)
                                                        {
                                                            if ((cstcal.PrevQty + cstcal.CurrQty) < ss.IssueQty)/// check qty
                                                            {

                                                                var msg = "Document no: " + singlevoucher.IssueNo + " " + productname + " not Stock in the " + warehousename + ". Warehouse Qty is " + (cstcal.PrevQty + cstcal.CurrQty) + ". Total Shortage Qty is " + (ss.IssueQty - (cstcal.PrevQty + cstcal.CurrQty)) + ".";
                                                                return Json(new { Success = "3", ex = msg, docidsuccess = docidsuccess });
                                                            }
                                                        }
                                                        else
                                                        {
                                                            var msg = "Document no: " + singlevoucher.IssueNo + " " + productname + " not Stock in the " + warehousename + " not in stock. Warehouse Qty is 0.";
                                                            return Json(new { Success = "3", ex = msg, docidsuccess = docidsuccess });
                                                        }



                                                        if (inv != null) ///added by fahad for solving error if no ware house found then no update of the data
                                                        {

                                                            inv.IssueQty = inv.IssueQty + wh.IssueQty;
                                                            //inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty);
                                                            inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty + inv.GoodsReceiveQty + inv.IssueRtnQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty + inv.IssueQty + inv.GoodsRcvRtnQty);

                                                            db.Entry(inv).State = EntityState.Modified;
                                                            db.SaveChanges();
                                                        }
                                                        else
                                                        {
                                                            //var comid = HttpContext.Session.GetString("comid");
                                                            //var userid = HttpContext.Session.GetString("userid");

                                                            Inventory insertinv = new Inventory();

                                                            insertinv.ProductId = int.Parse(wh.ProductId.ToString());
                                                            insertinv.WareHouseId = int.Parse(wh.WarehouseId.ToString());
                                                            insertinv.OpStock = 0;

                                                            insertinv.PurQty = 0;
                                                            insertinv.PurRetQty = 0;
                                                            insertinv.PurExcQty = 0;

                                                            insertinv.SalesQty = 0;
                                                            insertinv.SalesRetQty = 0;
                                                            insertinv.SalesExcQty = 0;

                                                            insertinv.ChallanQty = 0;
                                                            insertinv.EnStock = 0;
                                                            insertinv.CurrentStock = 0;

                                                            insertinv.GoodsReceiveQty = 0;
                                                            insertinv.IssueQty = 0;
                                                            insertinv.GoodsRcvRtnQty = 0;
                                                            insertinv.IssueRtnQty = 0;

                                                            insertinv.comid = comid;
                                                            insertinv.userid = userid;
                                                            insertinv.useridUpdate = userid;
                                                            insertinv.DateAdded = DateTime.Now;
                                                            insertinv.DateUpdated = DateTime.Now;
                                                            insertinv.OpeningStockDate = ss.IssueMain.IssueDate;
                                                            insertinv.Remarks = "Auto From Issue Post";
                                                            db.Entry(insertinv).State = EntityState.Added;
                                                            db.SaveChanges();

                                                            inv = db.Inventory.Where(x => x.ProductId == wh.ProductId && x.WareHouseId == wh.WarehouseId).FirstOrDefault();

                                                            inv.IssueQty = inv.IssueQty + wh.IssueQty;
                                                            //inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty);
                                                            inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty + inv.GoodsReceiveQty + inv.IssueRtnQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty + inv.IssueQty + inv.GoodsRcvRtnQty);
                                                            db.Entry(inv).State = EntityState.Modified;
                                                            db.SaveChanges();
                                                        }

                                                    }
                                                }





                                            }
                                            singlevoucher.Status = 1;
                                            db.Entry(singlevoucher).State = EntityState.Modified;

                                            // success document
                                            docidsuccess[i] = docidsingle;


                                            #region For Substore auto receive - GRR
                                            ////newly added code by fahad for check and perfection the code
                                            /////////////if sub store issue is enable then auto qty increase in the sub store receiving qty to issue product and balance calculation 

                                            if (singlestorerequisition != null)
                                            {///need to check those code today 19-sep-2020
                                                if (singlestorerequisition.IsSubStore == true)
                                                {
                                                    var subwarehouseid = singlestorerequisition.SubWarehouseId;



                                                    foreach (IssueSub ss in singlevoucher.IssueSub)
                                                    {
                                                        //foreach (IssueSubWarehouse wh in ss.IssueSubWarehouse)
                                                        //{
                                                        Inventory inv = db.Inventory.Where(x => x.ProductId == ss.ProductId && x.WareHouseId == subwarehouseid).FirstOrDefault();
                                                        if (inv != null) ///added by fahad for solving error if no ware house found then no update of the data
                                                        {

                                                            inv.GoodsReceiveQty = inv.GoodsReceiveQty + ss.IssueQty;
                                                            //inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty);
                                                            inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty + inv.GoodsReceiveQty + inv.IssueRtnQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty + inv.IssueQty + inv.GoodsRcvRtnQty);

                                                            db.Entry(inv).State = EntityState.Modified;
                                                            db.SaveChanges();
                                                        }
                                                        else
                                                        {
                                                            //var comid = HttpContext.Session.GetString("comid");
                                                            //var userid = HttpContext.Session.GetString("userid");

                                                            Inventory insertinv = new Inventory();

                                                            insertinv.ProductId = int.Parse(ss.ProductId.ToString());
                                                            insertinv.WareHouseId = int.Parse(subwarehouseid.ToString());
                                                            insertinv.OpStock = 0;

                                                            insertinv.PurQty = 0;
                                                            insertinv.PurRetQty = 0;
                                                            insertinv.PurExcQty = 0;

                                                            insertinv.SalesQty = 0;
                                                            insertinv.SalesRetQty = 0;
                                                            insertinv.SalesExcQty = 0;

                                                            insertinv.ChallanQty = 0;
                                                            insertinv.EnStock = 0;
                                                            insertinv.CurrentStock = ss.IssueQty;

                                                            insertinv.GoodsReceiveQty = ss.IssueQty;
                                                            insertinv.IssueQty = 0;
                                                            insertinv.GoodsRcvRtnQty = 0;
                                                            insertinv.IssueRtnQty = 0;

                                                            insertinv.comid = comid;
                                                            insertinv.userid = userid;
                                                            insertinv.useridUpdate = userid;
                                                            insertinv.DateAdded = DateTime.Now;
                                                            insertinv.DateUpdated = DateTime.Now;
                                                            insertinv.OpeningStockDate = ss.IssueMain.IssueDate;
                                                            insertinv.Remarks = "Auto From SubStore Issue Post";
                                                            db.Entry(insertinv).State = EntityState.Added;

                                                            db.SaveChanges();



                                                            ////need to check from here for auto posting to grr if store req issubstoreissue == true // fahad need to check
                                                            //inv = db.Inventory.Where(x => x.ProductId == wh.ProductId && x.WareHouseId == subwarehouseid && x.comid == comid).FirstOrDefault();


                                                            ////inv.GoodsReceiveQty = inv.GoodsReceiveQty + wh.IssueQty;
                                                            ////inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty);
                                                            //inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty + inv.GoodsReceiveQty + inv.IssueRtnQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty + inv.IssueQty + inv.GoodsRcvRtnQty);

                                                            //db.Entry(inv).State = EntityState.Modified;
                                                            //db.SaveChanges();




                                                        }

                                                        //db.SaveChanges();
                                                        //}
                                                        //exec CustBill_Corporate.dbo.[prcAvgCostingProcess] 'grr' , 'grrid' , comid
                                                        ///@Type varchar(30), @Id bigint , @ComId varchar(200) --, @ProductId int

                                                        //exec CustBill_Corporate.dbo.[prcAvgCostingProcess] 'grr' , 'grrid' , comid
                                                    }






                                                    //var a = db.Database.ExecuteSqlCommand("Exec prcAvgCostingProcess @Type ,@Id, @ComId ", new SqlParameter("@Type", "Issue"), new SqlParameter("@Id", singlevoucher.IssueMainId), new SqlParameter("@ComId", singlevoucher.ComId));


                                                }
                                            }

                                        }
                                        catch (SqlException ex)
                                        {

                                            Console.WriteLine(ex.Message);
                                            tr.Rollback();

                                            return Json(new { Success = "3", ex = "Something Wrong" });

                                        }

                                        tr.Commit();


                                        if (singlevoucher != null)
                                        {
                                            var query = $"Exec prcAvgCostingProcess {"Issue"},{singlevoucher.IssueMainId},'{singlevoucher.ComId}'";

                                            SqlParameter[] sqlParameter = new SqlParameter[4];
                                            sqlParameter[0] = new SqlParameter("@Type", "Issue");
                                            sqlParameter[1] = new SqlParameter("@Id", singlevoucher.IssueMainId);
                                            sqlParameter[2] = new SqlParameter("@comId", singlevoucher.ComId);
                                            sqlParameter[3] = new SqlParameter("@userid", userid);


                                            Helper.ExecProc("prcAvgCostingProcess", sqlParameter);
                                            //var a = db.Database.ExecuteSqlCommand("Exec prcAvgCostingProcess @Type ,@Id, @ComId ", new SqlParameter("@Type", "Issue"), new SqlParameter("@Id", singlevoucher.IssueMainId), new SqlParameter("@ComId", singlevoucher.ComId));

                                        }


                                        if (singlestorerequisition != null)
                                        {
                                            var query = $"Exec prcAvgCostingProcess {"'StoreReq'"},{singlestorerequisition.StoreReqId},'{singlevoucher.ComId}'";
                                            SqlParameter[] sqlParameter1 = new SqlParameter[4];
                                            sqlParameter1[0] = new SqlParameter("@Type", "StoreReq");
                                            sqlParameter1[1] = new SqlParameter("@Id", singlestorerequisition.StoreReqId);
                                            sqlParameter1[2] = new SqlParameter("@comId", singlevoucher.ComId);
                                            sqlParameter1[3] = new SqlParameter("@userid", userid);


                                            Helper.ExecProc("prcAvgCostingProcess", sqlParameter1);

                                        }


                                        #endregion

                                    }
                                }
                            }
                            else if (doctypesingle == "PR")
                            {
                                var singlevoucher = db.PurchaseRequisitionMain.Where(x => x.PurReqId == int.Parse(docidsingle) && x.Status == 0).FirstOrDefault();

                                if (singlevoucher != null)
                                {
                                    singlevoucher.Status = 1;
                                    db.Entry(singlevoucher).State = EntityState.Modified;
                                }
                            }
                            else if (doctypesingle == "PO")
                            {
                                var singlevoucher = db.PurchaseOrderMain.Where(x => x.PurOrderMainId == int.Parse(docidsingle) && x.Status == 0).FirstOrDefault();

                                if (singlevoucher != null)
                                {
                                    singlevoucher.Status = 1;
                                    db.Entry(singlevoucher).State = EntityState.Modified;
                                }
                            }
                            else if (doctypesingle == "GRR")
                            {
                                //var statusupdate = db.GoodsReceiveMain.Where(x => x.GRRMainId == int.Parse(docidsingle)).FirstOrDefault();
                                //var goodsreceivesub = db.GoodsReceiveSub.Include(x => x.GoodsReceiveSubWarehouse).Where(x => x.GRRMainId == int.Parse(docidsingle));
                                var singlevoucher = db.GoodsReceiveMain.Include(x => x.GoodsReceiveSub).ThenInclude(x => x.GoodsReceiveSubWarehouse).Where(x => x.GRRMainId == int.Parse(docidsingle) && x.Status == 0).FirstOrDefault();

                                if (singlevoucher != null)
                                {
                                    if (singlevoucher.IsDirectGRR == true)
                                    {

                                        foreach (GoodsReceiveSub ss in singlevoucher.GoodsReceiveSub)
                                        {

                                            Inventory inv = db.Inventory.Where(x => x.ProductId == ss.ProductId && x.WareHouseId == ss.WarehouseId).FirstOrDefault();
                                            if (inv != null) ///added by fahad for solving error if no ware house found then no update of the data
                                            {

                                                inv.GoodsReceiveQty = inv.GoodsReceiveQty + ss.Quality;
                                                //inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty);
                                                inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty + inv.GoodsReceiveQty + inv.IssueRtnQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty + inv.IssueQty + inv.GoodsRcvRtnQty);

                                                db.Entry(inv).State = EntityState.Modified;
                                            }
                                            else
                                            {


                                                Inventory insertinv = new Inventory();

                                                insertinv.ProductId = int.Parse(ss.ProductId.ToString());
                                                insertinv.WareHouseId = int.Parse(ss.WarehouseId.ToString());
                                                insertinv.OpStock = 0;

                                                insertinv.PurQty = 0;
                                                insertinv.PurRetQty = 0;
                                                insertinv.PurExcQty = 0;

                                                insertinv.SalesQty = 0;
                                                insertinv.SalesRetQty = 0;
                                                insertinv.SalesExcQty = 0;

                                                insertinv.ChallanQty = 0;
                                                insertinv.EnStock = 0;
                                                insertinv.CurrentStock = 0;

                                                insertinv.GoodsReceiveQty = 0;
                                                insertinv.IssueQty = 0;
                                                insertinv.GoodsRcvRtnQty = 0;
                                                insertinv.IssueRtnQty = 0;

                                                insertinv.comid = comid;
                                                insertinv.userid = userid;
                                                insertinv.useridUpdate = userid;
                                                insertinv.DateAdded = DateTime.Now;
                                                insertinv.DateUpdated = DateTime.Now;
                                                insertinv.OpeningStockDate = ss.GoodsReceiveMain.GRRDate;
                                                insertinv.Remarks = "Auto From GRR Post";
                                                db.Entry(insertinv).State = EntityState.Added;
                                                db.SaveChanges();

                                                inv = db.Inventory.Where(x => x.ProductId == ss.ProductId && x.WareHouseId == ss.WarehouseId).FirstOrDefault();

                                                inv.GoodsReceiveQty = inv.GoodsReceiveQty + ss.Quality;
                                                //inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty);
                                                inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty + inv.GoodsReceiveQty + inv.IssueRtnQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty + inv.IssueQty + inv.GoodsRcvRtnQty);

                                                db.Entry(inv).State = EntityState.Modified;
                                            }
                                            db.SaveChanges();
                                        }



                                    }
                                    else
                                    {
                                        foreach (GoodsReceiveSub ss in singlevoucher.GoodsReceiveSub)
                                        {
                                            foreach (GoodsReceiveSubWarehouse wh in ss.GoodsReceiveSubWarehouse)
                                            {
                                                Inventory inv = db.Inventory.Where(x => x.ProductId == wh.ProductId && x.WareHouseId == wh.WarehouseId).FirstOrDefault();
                                                if (inv != null) ///added by fahad for solving error if no ware house found then no update of the data
                                                {

                                                    inv.GoodsReceiveQty = inv.GoodsReceiveQty + wh.GRRQty;
                                                    //inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty);
                                                    inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty + inv.GoodsReceiveQty + inv.IssueRtnQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty + inv.IssueQty + inv.GoodsRcvRtnQty);

                                                    db.Entry(inv).State = EntityState.Modified;
                                                }
                                                else
                                                {
                                                    Inventory insertinv = new Inventory();

                                                    insertinv.ProductId = int.Parse(wh.ProductId.ToString());
                                                    insertinv.WareHouseId = int.Parse(wh.WarehouseId.ToString());
                                                    insertinv.OpStock = 0;

                                                    insertinv.PurQty = 0;
                                                    insertinv.PurRetQty = 0;
                                                    insertinv.PurExcQty = 0;

                                                    insertinv.SalesQty = 0;
                                                    insertinv.SalesRetQty = 0;
                                                    insertinv.SalesExcQty = 0;

                                                    insertinv.ChallanQty = 0;
                                                    insertinv.EnStock = 0;
                                                    insertinv.CurrentStock = 0;

                                                    insertinv.GoodsReceiveQty = 0;
                                                    insertinv.IssueQty = 0;
                                                    insertinv.GoodsRcvRtnQty = 0;
                                                    insertinv.IssueRtnQty = 0;

                                                    insertinv.comid = comid;
                                                    insertinv.userid = userid;
                                                    insertinv.useridUpdate = userid;
                                                    insertinv.DateAdded = DateTime.Now;
                                                    insertinv.DateUpdated = DateTime.Now;
                                                    insertinv.OpeningStockDate = ss.GoodsReceiveMain.GRRDate;
                                                    insertinv.Remarks = "Auto From GRR Post";
                                                    db.Entry(insertinv).State = EntityState.Added;
                                                    db.SaveChanges();

                                                    inv = db.Inventory.Where(x => x.ProductId == wh.ProductId && x.WareHouseId == wh.WarehouseId).FirstOrDefault();

                                                    inv.GoodsReceiveQty = inv.GoodsReceiveQty + wh.GRRQty;
                                                    //inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty);
                                                    inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty + inv.GoodsReceiveQty + inv.IssueRtnQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty + inv.IssueQty + inv.GoodsRcvRtnQty);

                                                    db.Entry(inv).State = EntityState.Modified;
                                                    db.SaveChanges();




                                                }
                                            }
                                            //exec CustBill_Corporate.dbo.[prcAvgCostingProcess] 'grr' , 'grrid' , comid
                                            ///@Type varchar(30), @Id bigint , @ComId varchar(200) --, @ProductId int

                                            //exec CustBill_Corporate.dbo.[prcAvgCostingProcess] 'grr' , 'grrid' , comid
                                        }
                                    }

                                    singlevoucher.Status = 1;
                                    db.Entry(singlevoucher).State = EntityState.Modified;


                                    var query = $"Exec prcAvgCostingProcess {"GoodsReceive"},{singlevoucher.GRRMainId},'{singlevoucher.ComId}'";

                                    SqlParameter[] sqlParameter = new SqlParameter[4];
                                    sqlParameter[0] = new SqlParameter("@Type", "GoodsReceive");
                                    sqlParameter[1] = new SqlParameter("@Id", singlevoucher.GRRMainId);
                                    sqlParameter[2] = new SqlParameter("@comId", singlevoucher.ComId);
                                    sqlParameter[3] = new SqlParameter("@userid", userid);


                                    Helper.ExecProc("prcAvgCostingProcess", sqlParameter);

                                    //var a = db.Database.ExecuteSqlCommand("Exec prcAvgCostingProcess @Type ,@Id, @ComId ", new SqlParameter("@Type", "GoodsReceive"), new SqlParameter("@Id", singlevoucher.GRRMainId), new SqlParameter("@ComId", singlevoucher.ComId));


                                    //statusupdate.Status = 1;
                                    //db.Entry(statusupdate).State = EntityState.Modified;
                                }
                            }
                            else if (doctypesingle == "Leave")
                            {
                                var lvAvail = db.HR_Leave_Avail.Where(x => x.LvId == int.Parse(docidsingle)).FirstOrDefault();
                                lvAvail.Status = 1;
                                db.Entry(lvAvail).State = EntityState.Modified;
                            }
                            db.SaveChanges();
                        }
                    }
                }
                else if (criteria.ToUpper().ToString() == "UnPost".ToUpper())
                {
                    if (docid.Count() > 0)
                    {
                        //// These line of code for unpost issue document descending order accroding to posted docuemnt
                        // its workig on issue document 
                        if (doctype[0] == "ISSUE")
                        {
                            var postedDoc = db.CostCalculated.Where(c => c.isDelete == false
                                          && docid.ToList().Contains(c.IssueMainId.ToString()))
                                            .OrderByDescending(c => c.CostCalculatedId).ToList();
                            if (postedDoc.Count > 0)
                            {
                                docid = postedDoc.Select(c => c.IssueMainId.ToString()).Distinct().ToArray();
                            }

                        }




                        for (var i = 0; i < docid.Count(); i++)
                        {
                            string docidsingle = docid[i];
                            string doctypesingle = doctype[i];


                            if (doctypesingle == "SRR")
                            {
                                var singlevoucher = db.StoreRequisitionMain.Where(x => x.StoreReqId == int.Parse(docidsingle) && x.Status == 1).FirstOrDefault();

                                if (singlevoucher != null)
                                {
                                    singlevoucher.Status = 0;
                                    db.Entry(singlevoucher).State = EntityState.Modified;
                                }
                            }
                            else if (doctypesingle == "ISSUE")
                            {
                                var singlevoucher = db.IssueMain.Include(x => x.IssueSub).ThenInclude(x => x.IssueSubWarehouse).Where(x => x.IssueMainId == int.Parse(docidsingle) && x.Status == 1).FirstOrDefault();

                                if (singlevoucher != null)
                                {
                                    using (var tr = db.Database.BeginTransaction())
                                    {

                                        try
                                        {

                                            if (singlevoucher.IsDirectIssue)
                                            {
                                                foreach (var ss in singlevoucher.IssueSub.OrderByDescending(i => i.IssueSubId))
                                                {

                                                    //Inventory inv = db.Inventory.Where(x => x.ProductId == ss.ProductId && x.WareHouseId == ss.WarehouseId).FirstOrDefault();

                                                    //if (inv != null)
                                                    //{
                                                    //    inv.IssueQty = inv.IssueQty - ss.IssueQty;
                                                    //    inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty + inv.GoodsReceiveQty + inv.IssueRtnQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty + inv.IssueQty + inv.GoodsRcvRtnQty);
                                                    //    db.Entry(inv).State = EntityState.Modified;
                                                    //    db.SaveChanges();
                                                    //}
                                                    ///// we need to throw or run some process to calculate the inventory qty properly // by fahad // by himu 7 mar 21
                                                    ///


                                                    CostCalculated costcalculateddb = db.CostCalculated.Where(x => x.comid == singlevoucher.ComId && x.ProductId == ss.ProductId && x.WarehouseId == ss.WarehouseId && x.IssueMainId == singlevoucher.IssueMainId && x.isDelete == false).FirstOrDefault();



                                                    if (costcalculateddb != null)
                                                    {

                                                        ///////Himu coding for checking the greater number of document which contains same product
                                                        CostCalculated nextTranCheck =
                                                            db.CostCalculated
                                                            .Include(x => x.vIssueMain)
                                                            .Include(x => x.vGoodsReceiveMain)
                                                            .Include(x => x.vStoreRequsitionMain)
                                                            .Where(x => x.comid == singlevoucher.ComId && x.ProductId == ss.ProductId && x.WarehouseId == ss.WarehouseId && x.isDelete == false && x.IssueMainId != int.Parse(docidsingle) && x.CostCalculatedId > costcalculateddb.CostCalculatedId).OrderByDescending(i => i.CostCalculatedId).FirstOrDefault();


                                                        var message = "Please Unpost Last Document. Other wise you can not post the document";
                                                        if (nextTranCheck != null)
                                                        {
                                                            if (nextTranCheck.vIssueMain != null)
                                                            {
                                                                message = message + " Issue No : " + nextTranCheck.vIssueMain.IssueNo + ", Date: " + nextTranCheck.vIssueMain.IssueDate.ToString("dd-MMM-yyyy");
                                                            }
                                                            else if (nextTranCheck.vGoodsReceiveMain != null)
                                                            {
                                                                message = message + " GRR / MR No : " + nextTranCheck.vGoodsReceiveMain.GRRNo + ", Date: " + nextTranCheck.vGoodsReceiveMain.GRRDate.ToString("dd-MMM-yyyy");
                                                            }
                                                            else if (nextTranCheck.vStoreRequsitionMain != null)
                                                            {
                                                                message = message + " Store Req. No : " + nextTranCheck.vStoreRequsitionMain.SRNo + ", Date: " + nextTranCheck.vStoreRequsitionMain.ReqDate.ToString("dd-MMM-yyyy");
                                                            }
                                                            else
                                                            {
                                                                message = " Nothing Found";
                                                            }



                                                            return Json(new { Success = "3", ex = message });
                                                        }

                                                        costcalculateddb.isDelete = true;
                                                        db.Entry(costcalculateddb).State = EntityState.Modified;
                                                        db.SaveChanges();
                                                    }

                                                }
                                            }
                                            else
                                            {
                                                foreach (var ss in singlevoucher.IssueSub.OrderByDescending(c => c.IssueSubId))
                                                {
                                                    foreach (IssueSubWarehouse wh in ss.IssueSubWarehouse)
                                                    {
                                                        //Inventory inv = db.Inventory.Where(x => x.ProductId == wh.ProductId && x.WareHouseId == wh.WarehouseId).FirstOrDefault();

                                                        //if (inv != null)
                                                        //{
                                                        //    inv.IssueQty = inv.IssueQty - wh.IssueQty;
                                                        //    inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty + inv.GoodsReceiveQty + inv.IssueRtnQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty + inv.IssueQty + inv.GoodsRcvRtnQty);
                                                        //    db.Entry(inv).State = EntityState.Modified;
                                                        //    db.SaveChanges();
                                                        //}
                                                        /////himu  coding for auto grr unpost and 
                                                        ///


                                                        var strReq = db.StoreRequisitionMain.Where(x => x.StoreReqId == singlevoucher.StoreReqId).FirstOrDefault();
                                                        if (strReq != null && strReq.SubWarehouseId != null)
                                                        {
                                                            CostCalculated costcalcualtedStorereq = db.CostCalculated.Where(x => x.comid == singlevoucher.ComId && x.ProductId == wh.ProductId && x.WarehouseId == strReq.SubWarehouseId && x.StoreReqId == strReq.StoreReqId && x.isDelete == false).FirstOrDefault();
                                                            if (costcalcualtedStorereq != null)
                                                            {
                                                                ///////Himu coding for checking the greater number of document which contains same product
                                                                CostCalculated nextTranCheck =
                                                                    db.CostCalculated
                                                                    .Include(x => x.vIssueMain)
                                                                    .Include(x => x.vGoodsReceiveMain)
                                                                    .Include(x => x.vStoreRequsitionMain)
                                                                    .Where(x => x.comid == singlevoucher.ComId && x.ProductId == wh.ProductId && x.WarehouseId == strReq.SubWarehouseId && x.isDelete == false && x.StoreReqId != strReq.StoreReqId && x.CostCalculatedId > costcalcualtedStorereq.CostCalculatedId).OrderByDescending(i => i.CostCalculatedId).FirstOrDefault();

                                                                var message = "Please Unpost Last Document. Other wise you can not post the document";
                                                                if (nextTranCheck != null)
                                                                {
                                                                    if (nextTranCheck.vIssueMain != null)
                                                                        message = message + " Issue No : " + nextTranCheck.vIssueMain.IssueNo + ", Date: " + nextTranCheck.vIssueMain.IssueDate.ToString("dd-MMM-yyyy");
                                                                    else if (nextTranCheck.vGoodsReceiveMain != null)
                                                                        message = message + " GRR / MR No : " + nextTranCheck.vGoodsReceiveMain.GRRNo + ", Date: " + nextTranCheck.vGoodsReceiveMain.GRRDate.ToString("dd-MMM-yyyy");
                                                                    else if (nextTranCheck.vStoreRequsitionMain != null)
                                                                        message = message + " Store Req. No : " + nextTranCheck.vStoreRequsitionMain.SRNo + nextTranCheck.vStoreRequsitionMain.ReqDate.ToString("dd-MMM-yyyy");
                                                                    else
                                                                        message = " Nothing Found";

                                                                    return Json(new { Success = "3", ex = message });
                                                                }
                                                                costcalcualtedStorereq.isDelete = true;
                                                                db.Entry(costcalcualtedStorereq).State = EntityState.Modified;
                                                                db.SaveChanges();
                                                            }
                                                        }



                                                        /////
                                                        CostCalculated costcalculateddb = db.CostCalculated.Where(x => x.comid == singlevoucher.ComId && x.ProductId == wh.ProductId && x.WarehouseId == wh.WarehouseId && x.IssueMainId == singlevoucher.IssueMainId && x.isDelete == false).FirstOrDefault();
                                                        if (costcalculateddb != null)
                                                        {
                                                            ///////Himu coding for checking the greater number of document which contains same product
                                                            CostCalculated nextTranCheck =
                                                                db.CostCalculated
                                                                .Include(x => x.vIssueMain)
                                                                .Include(x => x.vGoodsReceiveMain)
                                                                .Include(x => x.vStoreRequsitionMain)
                                                                .Where(x => x.comid == singlevoucher.ComId && x.ProductId == wh.ProductId && x.WarehouseId == wh.WarehouseId && x.isDelete == false && x.IssueMainId != singlevoucher.IssueMainId && x.CostCalculatedId > costcalculateddb.CostCalculatedId).OrderByDescending(i => i.CostCalculatedId).FirstOrDefault();

                                                            var message = "Please Unpost Last Document. Other wise you can not post the document";
                                                            if (nextTranCheck != null)
                                                            {
                                                                if (nextTranCheck.vIssueMain != null)
                                                                    message = message + " Issue No : " + nextTranCheck.vIssueMain.IssueNo.ToString();
                                                                else if (nextTranCheck.vGoodsReceiveMain != null)
                                                                    message = message + " GRR / MR No : " + nextTranCheck.vGoodsReceiveMain.GRRNo.ToString();
                                                                else if (nextTranCheck.vStoreRequsitionMain != null)
                                                                    message = message + " Store Req. No : " + nextTranCheck.vStoreRequsitionMain.SRNo.ToString();
                                                                else
                                                                    message = " Nothing Found";

                                                                return Json(new { Success = "3", ex = message });
                                                            }
                                                            costcalculateddb.isDelete = true;
                                                            db.Entry(costcalculateddb).State = EntityState.Modified;
                                                            db.SaveChanges();
                                                        }

                                                    }
                                                }
                                            }

                                            singlevoucher.Status = 0;
                                            db.Entry(singlevoucher).State = EntityState.Modified;


                                            var singlestorerequisition = db.StoreRequisitionMain.Where(x => x.StoreReqId == singlevoucher.StoreReqId).FirstOrDefault();
                                            if (singlestorerequisition != null)
                                            {///need to check those code today 19-sep-2020
                                                if (singlestorerequisition.IsSubStore == true)
                                                {
                                                    foreach (var ss in singlevoucher.IssueSub)
                                                    {
                                                        ////foreach (IssueSubWarehouse wh in ss.IssueSubWarehouse)
                                                        ////{
                                                        //Inventory inv = db.Inventory.Where(x => x.ProductId == ss.ProductId && x.WareHouseId == singlestorerequisition.SubWarehouseId).FirstOrDefault();

                                                        //if (inv != null)
                                                        //{
                                                        //    inv.GoodsReceiveQty = inv.GoodsReceiveQty - ss.IssueQty;
                                                        //    inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty + inv.GoodsReceiveQty + inv.IssueRtnQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty + inv.IssueQty + inv.GoodsRcvRtnQty);
                                                        //    db.Entry(inv).State = EntityState.Modified;
                                                        //    db.SaveChanges();
                                                        //}



                                                        CostCalculated costcalculateddb = db.CostCalculated.Where(x => x.comid == singlestorerequisition.ComId && x.ProductId == ss.ProductId && x.WarehouseId == ss.WarehouseId && x.StoreReqId == singlestorerequisition.StoreReqId && x.isDelete == false).FirstOrDefault();
                                                        if (costcalculateddb != null)
                                                        {
                                                            ///////Himu coding for checking the greater number of document which contains same product
                                                            CostCalculated nextTranCheck =
                                                                db.CostCalculated
                                                                .Include(x => x.vIssueMain)
                                                                .Include(x => x.vGoodsReceiveMain)
                                                                .Include(x => x.vStoreRequsitionMain)
                                                                .Where(x => x.comid == singlestorerequisition.ComId && x.ProductId == ss.ProductId && x.WarehouseId == ss.WarehouseId && x.isDelete == false && x.StoreReqId != singlestorerequisition.StoreReqId && x.CostCalculatedId > costcalculateddb.CostCalculatedId).OrderByDescending(i => i.CostCalculatedId).FirstOrDefault();

                                                            var message = "Please Unpost Last Document. Other wise you can not post the document";
                                                            if (nextTranCheck != null)
                                                            {
                                                                if (nextTranCheck.vIssueMain != null)
                                                                    message = message + " Issue No : " + nextTranCheck.vIssueMain.IssueNo.ToString();
                                                                else if (nextTranCheck.vGoodsReceiveMain != null)
                                                                    message = message + " GRR / MR No : " + nextTranCheck.vGoodsReceiveMain.GRRNo.ToString();
                                                                else if (nextTranCheck.vStoreRequsitionMain != null)
                                                                    message = message + " Store Req. No : " + nextTranCheck.vStoreRequsitionMain.SRNo.ToString();
                                                                else
                                                                    message = " Nothing Found";

                                                                return Json(new { Success = "3", ex = message });
                                                            }
                                                            costcalculateddb.isDelete = true;
                                                            db.Entry(costcalculateddb).State = EntityState.Modified;
                                                        }
                                                        db.SaveChanges();


                                                        //}
                                                    }
                                                }
                                            }
                                        }
                                        catch (SqlException ex)
                                        {

                                            Console.WriteLine(ex.Message);
                                            tr.Rollback();

                                            return Json(new { Success = "3", ex = "Something Wrong" });

                                        }

                                        tr.Commit();
                                    }
                                }
                            }
                            else if (doctypesingle == "PR")
                            {
                                var singlevoucher = db.PurchaseRequisitionMain.Where(x => x.PurReqId == int.Parse(docidsingle) && x.Status == 1).FirstOrDefault();

                                if (singlevoucher != null)
                                {
                                    singlevoucher.Status = 0;
                                    db.Entry(singlevoucher).State = EntityState.Modified;
                                }
                            }
                            else if (doctypesingle == "PO")
                            {
                                var singlevoucher = db.PurchaseOrderMain.Where(x => x.PurOrderMainId == int.Parse(docidsingle) && x.Status == 1).FirstOrDefault();
                                if (singlevoucher != null)
                                {
                                    singlevoucher.Status = 0;
                                    db.Entry(singlevoucher).State = EntityState.Modified;
                                }



                            }
                            else if (doctypesingle == "GRR")
                            {
                                var singlevoucher = db.GoodsReceiveMain.Include(x => x.GoodsReceiveSub).ThenInclude(x => x.GoodsReceiveSubWarehouse).Where(x => x.GRRMainId == int.Parse(docidsingle) && x.Status == 1).FirstOrDefault();
                                if (singlevoucher != null)
                                {
                                    using (var tr = db.Database.BeginTransaction())
                                    {
                                        try
                                        {
                                            if (singlevoucher.IsDirectGRR)
                                            {
                                                foreach (var ss in singlevoucher.GoodsReceiveSub)
                                                {

                                                    //Inventory inv = db.Inventory.Where(x => x.ProductId == ss.ProductId && x.WareHouseId == ss.WarehouseId).FirstOrDefault();

                                                    //if (inv != null)
                                                    //{
                                                    //    inv.GoodsReceiveQty = inv.GoodsReceiveQty - ss.Quality;
                                                    //    inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty + inv.GoodsReceiveQty + inv.IssueRtnQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty + inv.IssueQty + inv.GoodsRcvRtnQty);
                                                    //    db.Entry(inv).State = EntityState.Modified;
                                                    //}
                                                    //db.SaveChanges();



                                                    CostCalculated costcalculateddb = db.CostCalculated.Where(x => x.comid == singlevoucher.ComId && x.ProductId == ss.ProductId && x.WarehouseId == ss.WarehouseId && x.GRRMainId == singlevoucher.GRRMainId && x.isDelete == false).FirstOrDefault();
                                                    if (costcalculateddb != null)
                                                    {
                                                        ///////Himu coding for checking the greater number of document which contains same product
                                                        CostCalculated nextTranCheck =
                                                            db.CostCalculated
                                                            .Include(x => x.vIssueMain)
                                                            .Include(x => x.vGoodsReceiveMain)
                                                            .Include(x => x.vStoreRequsitionMain)
                                                            .Where(x => x.comid == singlevoucher.ComId && x.ProductId == ss.ProductId && x.WarehouseId == ss.WarehouseId && x.isDelete == false && x.GRRMainId != singlevoucher.GRRMainId && x.CostCalculatedId > costcalculateddb.CostCalculatedId).OrderByDescending(i => i.CostCalculatedId).FirstOrDefault();

                                                        var message = "Please Unpost Last Document. Other wise you can not post the document";
                                                        if (nextTranCheck != null)
                                                        {
                                                            if (nextTranCheck.vIssueMain != null)
                                                                message = message + " Issue No : " + nextTranCheck.vIssueMain.IssueNo.ToString();
                                                            else if (nextTranCheck.vGoodsReceiveMain != null)
                                                                message = message + " GRR / MR No : " + nextTranCheck.vGoodsReceiveMain.GRRNo.ToString();
                                                            else if (nextTranCheck.vStoreRequsitionMain != null)
                                                                message = message + " Store Req. No : " + nextTranCheck.vStoreRequsitionMain.SRNo.ToString();
                                                            else
                                                                message = " Nothing Found";

                                                            return Json(new { Success = "3", ex = message });
                                                        }
                                                        costcalculateddb.isDelete = true;
                                                        db.Entry(costcalculateddb).State = EntityState.Modified;
                                                    }
                                                    db.SaveChanges();


                                                }
                                            }
                                            else
                                            {


                                                foreach (var ss in singlevoucher.GoodsReceiveSub)
                                                {
                                                    foreach (GoodsReceiveSubWarehouse wh in ss.GoodsReceiveSubWarehouse)
                                                    {
                                                        //Inventory inv = db.Inventory.Where(x => x.ProductId == wh.ProductId && x.WareHouseId == wh.WarehouseId).FirstOrDefault();

                                                        //if (inv != null)
                                                        //{
                                                        //    inv.GoodsReceiveQty = inv.GoodsReceiveQty - wh.GRRQty;
                                                        //    inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty + inv.GoodsReceiveQty + inv.IssueRtnQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty + inv.IssueQty + inv.GoodsRcvRtnQty);
                                                        //    db.Entry(inv).State = EntityState.Modified;
                                                        //}

                                                        //db.SaveChanges();

                                                        CostCalculated costcalculateddb = db.CostCalculated.Where(x => x.comid == singlevoucher.ComId && x.ProductId == wh.ProductId && x.WarehouseId == wh.WarehouseId && x.GRRMainId == singlevoucher.GRRMainId && x.isDelete == false).FirstOrDefault();
                                                        if (costcalculateddb != null)
                                                        {
                                                            ///////Himu coding for checking the greater number of document which contains same product
                                                            CostCalculated nextTranCheck =
                                                                db.CostCalculated
                                                                .Include(x => x.vIssueMain)
                                                                .Include(x => x.vGoodsReceiveMain)
                                                                .Include(x => x.vStoreRequsitionMain)
                                                                .Where(x => x.comid == singlevoucher.ComId && x.ProductId == wh.ProductId && x.WarehouseId == wh.WarehouseId && x.isDelete == false && x.GRRMainId != singlevoucher.GRRMainId && x.CostCalculatedId > costcalculateddb.CostCalculatedId).OrderByDescending(i => i.CostCalculatedId).FirstOrDefault();

                                                            var message = "Please Unpost Last Document. Other wise you can not post the document";
                                                            if (nextTranCheck != null)
                                                            {
                                                                if (nextTranCheck.vIssueMain != null)
                                                                    message = message + " Issue No : " + nextTranCheck.vIssueMain.IssueNo.ToString();
                                                                else if (nextTranCheck.vGoodsReceiveMain != null)
                                                                    message = message + " GRR / MR No : " + nextTranCheck.vGoodsReceiveMain.GRRNo.ToString();
                                                                else if (nextTranCheck.vStoreRequsitionMain != null)
                                                                    message = message + " Store Req. No : " + nextTranCheck.vStoreRequsitionMain.SRNo.ToString();
                                                                else
                                                                    message = " Nothing Found";

                                                                return Json(new { Success = "3", ex = message });
                                                            }
                                                            costcalculateddb.isDelete = true;
                                                            db.Entry(costcalculateddb).State = EntityState.Modified;
                                                        }
                                                        db.SaveChanges();

                                                    }
                                                }

                                            }

                                            singlevoucher.Status = 0;
                                            db.Entry(singlevoucher).State = EntityState.Modified;
                                        }
                                        catch (SqlException ex)
                                        {

                                            Console.WriteLine(ex.Message);
                                            tr.Rollback();

                                            return Json(new { Success = "3", ex = "Something Wrong" });

                                        }

                                        tr.Commit();
                                    }
                                }

                            }
                            else if (doctypesingle == "Leave")
                            {
                                var lvAvail = db.HR_Leave_Avail.Where(x => x.LvId == int.Parse(docidsingle)).FirstOrDefault();
                                lvAvail.Status = 2;
                                db.Entry(lvAvail).State = EntityState.Modified;
                            }
                            db.SaveChanges();


                        }
                    }

                }


                //}
                //catch (SqlException ex)
                //{

                //    Console.WriteLine(ex.Message);
                //    tr.Rollback();
                //    return Json(new { Success = 0, ex = ex });

                //}
                //tr.Commit();

                return Json(new { Success = "1", ex = "Data Post/Unpost Successfully" });

                //}
            }
            catch (Exception ex)
            {
                return Json(new { Success = "3", ex = ex.Message });
                throw ex;

            }


        }
        public ActionResult create()
        {
            return View();
        }
        public string prcSaveData(Acc_VoucherMain model)
        {
            ArrayList arQuery = new ArrayList();

            try
            {
                var sqlQuery = "";
                // Count total Debit & Credit
                //foreach (var item in model.Collection)
                //{
                //    if (item.IsCheck == true)
                //    {
                //        sqlQuery = " Update tblAcc_Voucher_Main Set IsPosted = 1 ,LuserIdCheck = " + Session["Luserid"].ToString() + "   Where ComId = " + HttpContext.Session.GetString("comid").ToString() + " And docid = " + (item.docid) + "";
                //        arQuery.Add(sqlQuery);
                //    }
                //}
                //clsCon.GTRSaveDataWithSQLCommand(arQuery);
                return "Data Posted Successfuly";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            finally
            {
                //clsCon = null;
            }
        }

    }
}