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
            var res = new ProductDAO().ListProduct().Take(4);
            return View(res);
        }
    }
}