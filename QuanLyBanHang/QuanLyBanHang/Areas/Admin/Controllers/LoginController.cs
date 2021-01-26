using QuanLyBanHang.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseIO;
using Model;
using QuanLyBanHang.Common.Session;

namespace QuanLyBanHang.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginAccount account)
        {
            if(ModelState.IsValid)
            {
                bool result = new AdminUserDAO().Login(account.username, account.password);
                if(result)
                {
                    LoginUser usersession = new LoginUser();
                    usersession.username = account.username;
                    Session.Add(ConstaintUser.USER_SESSION, account);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("ErrorLogin", "Đăng nhập không thành công!");
                }
            }
            return View(account);
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}