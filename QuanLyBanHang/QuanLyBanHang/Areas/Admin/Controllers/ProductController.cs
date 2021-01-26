using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseIO;
using Model;
using QuanLyBanHang.Areas.Admin.Data;
using QuanLyBanHang.Common.Session;

namespace QuanLyBanHang.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        #region product
        public ActionResult Product()
        {
            var res = new ProductDAO().ListProduct();
            ViewBag.Product = new ProductDAO().listall();
            return View(res);
        }
        [HttpPost]
        public ActionResult ListSubProduct(int ID)
        {
            var res = new ProductDAO().listsubproduct(ID);
            return View("~/Areas/Admin/Views/Product/ProductReplace.cshtml", res);
        }
        public ActionResult CreateProduct()
        {
            ViewBag.Listall = new ProductDAO().listall();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult CreateProduct(Product entity)
        {
            var session = (LoginAccount)Session[ConstaintUser.USER_SESSION];
            var res = new ProductDAO().CreateProduct(session.username, entity);
            if (!res)
                return Json(new
                {
                    Status = false,
                    Message = "Thêm không thành công"
                });
            else
            {
                return Json(new
                {
                    Status = true,
                    Message = "Thêm thành công",
                    url = Url.Action("Product", "Product")
                });
            }
        }
        public ActionResult ProductDetails(int ID)
        {
            var res = new ProductDAO().FindProduct(ID);
            ViewBag.Category = new ProductDAO().Category(res.CategoryID);
            return View(res);
        }
        [HttpGet]
        public ActionResult EditProduct(int ID)
        {
            var res = new ProductDAO().FindProduct(ID);
            ViewBag.Listall = new ProductDAO().listall();
            return View(res);
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult EditProduct(Product entity)
        {
            var session = (LoginAccount)Session[ConstaintUser.USER_SESSION];
            var res = new ProductDAO().EditProduct(session.username, entity);
            if (!res)
                return Json(new
                {
                    Status = false,
                    Message = "Sửa thông tin không thành công"
                });
            else
            {
                return Json(new
                {
                    Status = true,
                    Message = "Sửa thông tin thành công",
                    url = Url.Action("Product", "Product")
                });
            }
        }
        [HttpPost]
        public ActionResult DeleteProduct(int ID)
        {
            new ProductDAO().DeleteProduct(ID);
            return RedirectToAction("Product");
        }
        #endregion
        #region Product Category
        public ActionResult ProductCategory()
        {
            var res = new ProductDAO().listshowonhome();
            ViewBag.Category = new ProductDAO().listshowonhome();
            return View(res);
        }
        [HttpPost]
        public ActionResult ListSubCategory(int ID)
        {
            var res = new ProductDAO().listsubcate(ID);
            return View("~/Areas/Admin/Views/Product/CategoryReplace.cshtml",res);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Listall = new ProductDAO().listall();
            return View();
        }
        [HttpPost]
        public JsonResult Create(ProductCategory entity)
        {
            var session = (LoginAccount)Session[ConstaintUser.USER_SESSION];
            var res = new ProductDAO().Create(session.username, entity);
            if (!res)
                return Json(new
                {
                    Status = false,
                    Message = "Thêm không thành công"
                });
            else
            {
                return Json(new
                {
                    Status = true,
                    Message = "Thêm thành công",
                    url = Url.Action("ProductCategory", "Product")
                });
            }
        }
        public ActionResult Details(int ID)
        {
            var res = new ProductDAO().FindCtgrByID(ID);
            ViewBag.Category = new ProductDAO().Category(res.ParentID);
            return View(res);
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var res = new ProductDAO().FindCtgrByID(ID);
            ViewBag.Listall = new ProductDAO().listall();
            return View(res);
        }
        [HttpPost]
        public JsonResult Edit(ProductCategory entity)
        {
            var session = (LoginAccount)Session[ConstaintUser.USER_SESSION];
            var res = new ProductDAO().Edit(session.username, entity);
            if (!res)
                return Json(new
                {
                    Status = false,
                    Message = "Sửa thông tin không thành công"
                });
            else
            {
                return Json(new
                {
                    Status = true,
                    Message = "Sửa thông tin thành công",
                    url = Url.Action("ProductCategory", "Product")
                });
            }
        }
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            new ProductDAO().Delete(ID);
            return RedirectToAction("ProductCategory");
        }
        #endregion
    }
}