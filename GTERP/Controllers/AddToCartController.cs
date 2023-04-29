using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GTERP.Controllers
{
    [OverridableAuthorize]
    public class AddToCartController : Controller
    {
        DataTable dt;
        private GTRDBContext db;
        public AddToCartController(GTRDBContext context)
        {
            db = context;
        }
        // GET: AddToCart



        [HttpPost]
        public JsonResult Add(CartOrderMain cartordermain)
        {
            try
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

                //if (ModelState.IsValid)
                {
                    GTERP.Models.Product cartproduct = db.Products.Where(x => x.ProductId == cartordermain.CartorderDetails.FirstOrDefault().ProductId).FirstOrDefault();

                    var cartlist = HttpContext.Session.GetObject<List<CartOrderDetails>>("cartlist");

                    // If sales main has SalesID then we can understand we have existing sales Information
                    // So we need to Perform Update Operation
                    int i = cartlist.Count() + 1;

                    // Perform Update
                    if (cartlist.Count == 0)
                    {
                        List<CartOrderDetails> li = new List<CartOrderDetails>();

                        foreach (CartOrderDetails mo in cartordermain.CartorderDetails)
                        {
                            mo.vProductName = cartproduct;
                            mo.RowNo = i;
                            mo.UnitPrice = float.Parse(mo.vProductName.SalePrice.ToString());
                            mo.Amount = float.Parse(mo.vProductName.SalePrice.ToString()) * mo.Qty;
                            li.Add(mo);
                            i++;
                        }

                        HttpContext.Session.SetObject("cartlist", li);
                        HttpContext.Session.SetObject("cartlistcount", li.Count());


                    }
                    else
                    {
                        //float PrevQty = 0;
                        foreach (CartOrderDetails mo in cartordermain.CartorderDetails)
                        {
                            var prevCartproduct = cartlist.Where(x => x.ProductId == cartordermain.CartorderDetails.FirstOrDefault().ProductId).FirstOrDefault();

                            if (prevCartproduct != null)
                            {
                                //prevCartproduct.vProductName = cartproduct;
                                prevCartproduct.Qty = (mo.Qty + prevCartproduct.Qty);
                                prevCartproduct.Amount = float.Parse(prevCartproduct.UnitPrice.ToString()) * (float.Parse(prevCartproduct.Qty.ToString()));
                                //cartlist.Add(mo);
                                i++;
                            }
                            else
                            {
                                mo.vProductName = cartproduct;
                                mo.RowNo = i;
                                mo.UnitPrice = float.Parse(mo.vProductName.SalePrice.ToString());
                                mo.Amount = float.Parse(mo.vProductName.SalePrice.ToString()) * mo.Qty;
                                cartlist.Add(mo);
                                i++;
                            }
                        }
                        HttpContext.Session.SetObject("cartlist", cartlist);
                        HttpContext.Session.SetObject("cartlistcount", cartlist.Count());


                    }



                    // If Sucess== 1 then Save/Update Successfull else there it has Exception
                    return Json(new { Success = 1, SalesID = cartordermain.CartOrderId, ex = "" });
                }
            }
            catch (Exception ex)
            {

                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.Message.ToString() });
            }

            return Json(new { Success = 0, ex = new Exception("Unable to save").Message.ToString() });
        }

        public ActionResult Myorder()
        {

            List<CartOrderDetails> myorderabc = HttpContext.Session.GetObject<List<CartOrderDetails>>("cartlist").ToList();


            return View(myorderabc);

        }

        public ActionResult Remove(CartOrderDetails mob)
        {
            //var cartlist = HttpContext.Session.GetObject<List<SalesSub>>("cartlist");

            List<CartOrderDetails> li = HttpContext.Session.GetObject<List<CartOrderDetails>>("cartlist");
            li.RemoveAll(x => x.ProductId == mob.ProductId);
            HttpContext.Session.SetObject("cartlist", li);
            HttpContext.Session.SetObject("cartlistcount", li.Count()); ;
            return RedirectToAction("Myorder", "AddToCart");
            //return View();
        }
    }
}