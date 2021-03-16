using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseIO;

namespace QuanLyBanHang.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Slide = new SlideDAO().topSlide();
            var res = new ProductDAO().ListSaleProduct();
            return View(res);
        }
    }
}