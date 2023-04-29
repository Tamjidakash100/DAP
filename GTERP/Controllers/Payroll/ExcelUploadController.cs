using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using GTERP.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace GTERP.Controllers.Payroll
{
    [OverridableAuthorize]
    public class ExcelUploadController : Controller
    {
        #region Feilds and Constructor
        private GTRDBContext db;
        [Obsolete]
        private IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public ExcelUploadController(GTRDBContext context, IHostingEnvironment hostingEnvironment)
        {
            db = context;
            _hostingEnvironment = hostingEnvironment;
        }
        #endregion





        private Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
        //public ExcelUploadController(GTRDBContext context)
        //{
        //    Context = context;
        //}

        public GTRDBContext Context { get; set; }

        public IActionResult Index()
        {
            var comid = HttpContext.Session.GetString("comid");
            return View();
        }


        [HttpPost]
        [Obsolete]
        public ActionResult UploadFiles(IList<IFormFile> fileData)
        {
            try
            {

                #region excelupload
                //var userid = HttpContext.Session.GetString("userid");
                var userid = HttpContext.Session.GetString("userid");
                var conString = db.Database.GetDbConnection().ConnectionString;


                if (userid.ToString() == "" || userid == null)
                {

                    return BadRequest();
                }



                IList<IFormFile> files = HttpContext.Request.Form.Files.ToList();
                //string filePath=string.Empty ;

                //var upload = Path.Combine("C:\\D drive");
                foreach (IFormFile file in files)
                {
                    //string upload = Path.Combine("~/Content/Upload/");
                    //string uploadlocation = Path.Combine("Content/Upload/");
                    string uploadlocation = Path.GetFullPath("Content/Upload/");

                    if (!Directory.Exists(uploadlocation))
                    {
                        Directory.CreateDirectory(uploadlocation);
                    }

                    string filePath = uploadlocation + Path.GetFileName(file.FileName);
                    string extension = Path.GetExtension(file.FileName);
                    var fileStream = new FileStream(filePath, FileMode.Create);
                    file.CopyTo(fileStream);
                    fileStream.Close();


                    //if (file.Length > 0)
                    //{
                    //    var filePath = Path.Combine(upload, file.FileName);

                    //    var fileStream = new FileStream(filePath, FileMode.Create);
                    //    file.CopyTo(fileStream);


                    //    string extension = Path.GetExtension(file.FileName);

                    ReadExcelFile(userid, conString, filePath);

                    //}
                }


                #endregion


                ViewBag.Title = "Create";
                ViewBag.BuyerID = 1;



                return Json(new { Success = 1 });
            }
            catch (Exception ex)
            {

                return Json(new { Success = 0, ex = ex.Message.ToString() });

            }

        }

        [Obsolete]
        public ActionResult Download(string file)
        {

            string filepath = _hostingEnvironment.WebRootPath + "\\SampleFormat\\" + file;
            if (!System.IO.File.Exists(filepath))
            {
                return NotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(filepath);
            var response = new FileContentResult(fileBytes, "application/octet-stream")
            {
                FileDownloadName = file
            };
            return response;
        }


        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]

        [HttpPost]
        public ActionResult UploadFilesPOList()
        {
            try
            {

                #region excelupload
                //var userid = HttpContext.Session.GetString("userid");
                var userid = HttpContext.Session.GetString("userid");

                if (userid.ToString() == "" || userid == null)
                {

                    return BadRequest();
                }
                #endregion


                ViewBag.Title = "Create";
                ViewBag.BuyerID = 1;

                List<Temp_COM_MasterLC_Detail> data = db.Temp_COM_MasterLC_Details.Where(m => m.userid == userid.ToString()).ToList();
                // return Json(data, JsonRequestBehavior.AllowGet);
                return Json(data);

            }
            catch (Exception ex)
            {

                return Json(new { Success = 0, ex = ex.Message.ToString() });

            }

        }

        static void ReadExcelFile(string userid, string conString, string filepath)
        {
            try
            {


                DataTable dt0 = new DataTable();
                DataTable dt1 = new DataTable();


                using (SpreadsheetDocument spreadSheetDocument = SpreadsheetDocument.Open(filepath, false))
                {

                    WorkbookPart workbookPart = spreadSheetDocument.WorkbookPart;
                    IEnumerable<Sheet> sheets = spreadSheetDocument.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();


                    foreach (var everysheet in sheets)
                    {
                        string relationshipId = everysheet.Id.Value;
                        string SheetName = everysheet.Name;

                        WorksheetPart worksheetPart = (WorksheetPart)spreadSheetDocument.WorkbookPart.GetPartById(relationshipId);
                        Worksheet workSheet = worksheetPart.Worksheet;
                        SheetData sheetData = workSheet.GetFirstChild<SheetData>();
                        IEnumerable<Row> rows = sheetData.Descendants<Row>();


                        if (SheetName == "OTFC")
                        {
                            foreach (Cell cell in rows.ElementAt(0))
                            {
                                dt0.Columns.Add(GetCellValue(spreadSheetDocument, cell));
                            }

                            int countcolumn = dt0.Columns.Count;
                            //dt0.Columns.Add("UserId");



                            foreach (Row row in rows) //this will also include your header row...
                            {
                                if (row.RowIndex > 0) // && row.RowIndex < rows.Count() - 3
                                {
                                    DataRow tempRow = dt0.NewRow();

                                    for (int i = 0; i < countcolumn; i++)
                                    {
                                        tempRow[i] = GetCellValue(spreadSheetDocument, row.Descendants<Cell>().ElementAt(i));

                                        var da = tempRow[i].ToString();
                                        if (i == 1 && da == "")   // for ignore null value emp code 
                                        {
                                            goto NotFoundEmpCode;
                                        }


                                        Console.WriteLine(dt0.Columns[i].ColumnName.ToUpper().Contains("InputDate".ToUpper()));

                                        if (dt0.Columns[i].ColumnName.ToUpper().Contains("InputDate".ToUpper()))
                                        {
                                            if (tempRow[i].ToString().Length > 1 && tempRow[i].ToString().IsNumeric())
                                            {
                                                tempRow[i] = string.Format("{0}", DateTime.FromOADate(int.Parse(tempRow[i].ToString())));

                                            }
                                        }
                                        //else if (dt0.Columns[i].ColumnName.ToUpper().Contains("userid".ToUpper()))
                                        //{
                                        //    tempRow[i] = userid.ToString();
                                        //}

                                    }
                                    //Console.WriteLine(row.RowIndex.ToString());
                                    //tempRow["userid"] = userid;
                                    dt0.Rows.Add(tempRow);

                                NotFoundEmpCode:
                                    Console.WriteLine("Not Found Emp Code That's why this row not added");
                                }


                            }

                            dt0.Rows.RemoveAt(0); //...so i'm taking it out here.


                        }
                    }
                }



                #region details ///details table function///
                //var conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                string table_Details = "HR_Temp_OT_FC";
                //string connectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand("delete from dbo." + table_Details, con);
                con.Open();
                cmd.ExecuteNonQuery();
                //Response.Redirect("done.aspx");
                con.Close();



                using (SqlConnection conn = new SqlConnection(conString))
                {
                    SqlBulkCopy bulkCopy = new SqlBulkCopy(conn)
                    {
                        //bulkCopy.DestinationTableName = table;
                        DestinationTableName = "dbo." + table_Details // "+"_Temp
                    };
                    conn.Open();


                    DataTable schema = conn.GetSchema("Columns", new[] { null, null, table_Details, null });
                    foreach (DataColumn sourceColumn in dt0.Columns)
                    {
                        foreach (DataRow row in schema.Rows)
                        {
                            if (string.Equals(sourceColumn.ColumnName, (string)row["COLUMN_NAME"], StringComparison.OrdinalIgnoreCase))
                            {
                                bulkCopy.ColumnMappings.Add(sourceColumn.ColumnName, (string)row["COLUMN_NAME"]);
                                break;
                            }
                            //bulkCopy.ColumnMappings.Add("userid", (string)row["COLUMN_NAME"]);
                        }
                    }
                    bulkCopy.WriteToServer(dt0);

                    conn.Close();
                }
                #endregion



                //#region Master //// master table function

                //string table_Master = "Temp_COM_MasterLC_Masters";
                ////String connectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
                ////SqlConnection con = new SqlConnection(connectionString);
                //cmd = new SqlCommand("delete from dbo." + table_Master + " where  userid is null or userid   in ('" + userid + "', '')", con);
                //con.Open();
                //cmd.ExecuteNonQuery();
                ////Response.Redirect("done.aspx");
                //con.Close();




                //using (SqlConnection conn = new SqlConnection(conString))
                //{



                //    SqlBulkCopy bulkCopy = new SqlBulkCopy(conn)
                //    {
                //        //bulkCopy.DestinationTableName = table;
                //        DestinationTableName = "dbo." + table_Master // "+"_Temp
                //    };
                //    conn.Open();


                //    DataTable calculatetable = CustomTable(dt1, userid);  ////for convert row into a column and save into a datatable

                //    DataTable schema = conn.GetSchema("Columns", new[] { null, null, table_Master, null });
                //    foreach (DataColumn sourceColumn in calculatetable.Columns)
                //    {
                //        foreach (DataRow row in schema.Rows)
                //        {
                //            if (string.Equals(sourceColumn.ColumnName, (string)row["COLUMN_NAME"], StringComparison.OrdinalIgnoreCase))
                //            {
                //                bulkCopy.ColumnMappings.Add(sourceColumn.ColumnName, (string)row["COLUMN_NAME"]);
                //                break;
                //            }
                //            //bulkCopy.ColumnMappings.Add("userid", (string)row["COLUMN_NAME"]);
                //        }
                //    }
                //    bulkCopy.WriteToServer(calculatetable);
                //}
                //#endregion

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetCellValue(SpreadsheetDocument document, Cell cell)
        {


            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
            var x = cell.StyleIndex;

            if (cell.CellValue == null) { return ""; }

            string value = cell.CellValue.InnerXml;

            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                string a = stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
                return a;
            }
            else
            {
                return value;
            }
        }

        public static DataTable CustomTable(DataTable excelTable, string currentuserid)
        {
            DataTable table = new DataTable();


            for (int index = 0; index < excelTable.Rows.Count; index++)
            {
                DataRow excelRow = excelTable.Rows[index];

                //var col  = table.Columns.Add("Category", typeof(String));
                string x = excelTable.Rows[index][1].ToString();
                if (x.Length > 1)
                {
                    //var col = 
                    table.Columns.Add(x, typeof(string));
                }
            }
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("SL", typeof(int));
            table.Columns.Add("userid", typeof(string));



            table.Rows.Add();
            DataRow fahad = table.Rows[0];
            object userid = currentuserid;
            fahad["SL"] = 1;
            fahad["Id"] = 1;
            fahad["userid"] = currentuserid;

            int i = 0;
            for (int index = 0; index < excelTable.Rows.Count; index++)
            {
                var colname = table.Columns[i].ColumnName.ToUpper();

                DataRow excelRow = excelTable.Rows[index];
                string x = excelTable.Rows[index][2].ToString();


                if (colname.Contains("date".ToUpper()))
                {
                    if (x.Length > 1 && x.IsNumeric())
                    {

                        fahad[i] = string.Format("{0}", DateTime.FromOADate(int.Parse(excelRow["Information"].ToString())));

                        //i++;
                    }
                }
                else
                {

                    //var col  = table.Columns.Add("Category", typeof(String));

                    if (x.Length > 1)
                    {

                        fahad[i] = string.Format("{0}", excelRow["Information"].ToString());

                    }

                }
                i++;

            }
            return table;
        } /// <summary>


        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

    }
}