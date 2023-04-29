using DataTablesParser;
using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.Common;
using GTERP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GTERP.Controllers.INV
{
    [OverridableAuthorize]

    public class SystemAdminController : Controller
    {
        private GTRDBContext db = new GTRDBContext();
        private TransactionLogRepository tranlog;
        PermissionLevel PL;

        public SystemAdminController(GTRDBContext context, TransactionLogRepository tran, PermissionLevel _pl)
        {
            tranlog = tran;
            db = context;
            PL = _pl;
            //Repository = rep;
        }

        public class GetUserModel
        {
            public Guid AppKey { get; set; }

        }

        public IActionResult UserLogingList()
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



            return View();
        }



        public class UserLogResult : UserLogingInfo
        {
            public string logindatestring { get; set; }
            public string logintimestring { get; set; }


        }



        public JsonResult Get(string UserList, string FromDate, string ToDate)
        {
            try
            {
                string comid = (HttpContext.Session.GetString("comid"));


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


                var userlogininfodata = db.UserLogingInfos.Where(x => x.comid == comid).OrderByDescending(x => x.UserLogingInfoId);


                if (y.ToString().Length > 0)
                {


                }
                else
                {
                    if (UserList == null)
                    {
                        userlogininfodata = db.UserLogingInfos.Where(x => x.comid == comid && x.LoginDate >= dtFrom && x.LoginDate <= dtTo).OrderByDescending(x => x.UserLogingInfoId);

                    }
                    else
                    {

                        userlogininfodata = db.UserLogingInfos.Where(x => x.comid == comid && x.userid == UserList && x.LoginDate >= dtFrom && x.LoginDate <= dtTo).OrderByDescending(x => x.UserLogingInfoId);
                    }

                }

                //var abc = db.SystemAdmin.Include(y => y.vPrimaryCategory);
                var query = (from e in userlogininfodata
                             select new UserLogingInfo
                             {
                                 UserLogingInfoId = e.UserLogingInfoId,
                                 WebLink = e.WebLink,
                                 LoginDate = e.LoginDate,

                                 LoginTime = e.LoginTime,
                                 PcName = e.PcName,
                                 MacAddress = e.MacAddress,
                                 IPAddress = e.IPAddress,
                                 DeviceType = e.DeviceType,
                                 Platform = e.Platform,
                                 WebBrowserName = e.WebBrowserName,
                                 //logindatestring = "",//e.LoginDate.HasValue ? e.LoginDate.ToString("dd-MMM-yy"),
                                 //logintimestring = "",//e.LoginTime.GetValueOrDefault().ToString("HH:mm:ss"),
                                 LongString = e.LongString,
                                 Status = e.Status,
                                 UserName = e.UserName

                             });



                var parser = new Parser<UserLogingInfo>(Request.Form, query);

                return Json(parser.Parse());

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


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
