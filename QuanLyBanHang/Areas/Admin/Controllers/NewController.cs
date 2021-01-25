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
    public class NewController : BaseController
    {
        // GET: Admin/New
        #region new category
        public ActionResult NewCategory()
        {
            var res = new NewDAO().listcategory();
            return View(res);
        }

        public ActionResult CreateNewCategory()
        {
            ViewBag.Listall = new NewDAO().listcategory();
            return View();
        }
        [HttpPost]
        public JsonResult CreateNewCategory(NewCategory entity)
        {
            var session = (LoginAccount)Session[ConstaintUser.USER_SESSION];
            var res = new NewDAO().Create(session.username, entity);
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
                    url = Url.Action("NewCategory", "New")
                });
            }
        }
        public ActionResult DetailNewCategory(int ID)
        {
            var res = new NewDAO().FindCtgrByID(ID);
            ViewBag.Category = new NewDAO().Category(res.ParentID);
            return View(res);
        }
        public ActionResult EditNewCategory(int ID)
        {
            var res = new NewDAO().FindCtgrByID(ID);
            ViewBag.Listall = new NewDAO().listcategory();
            return View(res);
        }
        [HttpPost]
        public JsonResult EditNewCategory(NewCategory entity)
        {
            var session = (LoginAccount)Session[ConstaintUser.USER_SESSION];
            var res = new NewDAO().Edit(session.username, entity);
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
                    url = Url.Action("NewCategory", "New")
                });
            }
        }
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            new NewDAO().Delete(ID);
            return RedirectToAction("NewCategory");
        }
        #endregion
        #region new
        public ActionResult News()
        {
            var res = new NewDAO().listnew();
            return View(res);
        }
        public ActionResult CreateNew()
        {
            ViewBag.Category = new NewDAO().listcategory();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult CreateNew(New entity)
        {
            var session = (LoginAccount)Session[ConstaintUser.USER_SESSION];
            var res = new NewDAO().CreateNew(session.username, entity);
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
                    url = Url.Action("News","New")
                });
            }
        }
        public ActionResult NewDetail(int ID)
        {
            var res = new NewDAO().FindNew(ID);
            ViewBag.Category = new NewDAO().Category(res.CategoryID);
            return View(res);
        }
        [HttpGet]
        public ActionResult EditNew(int ID)
        {
            var res = new NewDAO().FindNew(ID);
            ViewBag.Listall = new NewDAO().listcategory();
            return View(res);
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult EditNew(New entity)
        {
            var session = (LoginAccount)Session[ConstaintUser.USER_SESSION];
            var res = new NewDAO().EditNew(session.username, entity);
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
                    url = Url.Action("News", "New")
                });
            }
        }
        [HttpPost]
        public ActionResult DeleteNew(int ID)
        {
            new NewDAO().DeleteNew(ID);
            return RedirectToAction("News");
        }
        #endregion
    }
}