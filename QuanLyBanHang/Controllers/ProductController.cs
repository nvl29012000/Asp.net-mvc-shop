using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseIO;

namespace QuanLyBanHang.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Products()
        {
            var res = new ProductDAO().ListProduct();
            return View(res);
        }
        
        public ActionResult ProductDetails(int ID)
        {
            var res = new ProductDAO().FindProduct(ID);
            ViewBag.ListSame = new ProductDAO().ListSameProduct(res.CategoryID);
            ViewBag.ListAll = new ProductDAO().ListProduct().OrderByDescending(x=> x.CreatedDate).Take(8);
            return View(res);
        }
    }
}