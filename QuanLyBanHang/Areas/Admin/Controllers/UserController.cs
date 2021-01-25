using DatabaseIO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyBanHang.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult AdminUser()
        {
            IEnumerable<AdminUser> result = new AdminUserDAO().listall();
            return View(result);
        }
        [HttpPost]
        public JsonResult AddUser(AdminUser user)
        {
            bool res = new AdminUserDAO().AddUser(user);
            var userrespone = new AdminUserDAO().FindUser(user);
            if (res == false)
            {
                return Json(new
                {
                    Message = "Tài khoản đã tồn tại"
                }) ;
            }
            else
            {
                return Json(new
                {
                    ID = userrespone.ID,
                    Username = userrespone.Username,
                    Status  = userrespone.Status,
                    Message = "Thêm tài khoản thành công"
                });
            }
        }
        [HttpPost]
        public ActionResult ChangeStatus(int ID)
        {
            AdminUser change = new AdminUserDAO().ChangeStatus(ID);
            return View("~/Areas/Admin/Views/User/_ChangeStatus.cshtml", change);
        }
        
        public ActionResult TestCK()
        {
            return View();
        }
    }
}