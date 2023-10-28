using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTemplate.Models;

namespace TestTemplate.Controllers
{
    public class DangNhapController : Controller
    {
        QLDSEntities db = new QLDSEntities();
        // GET: DangNhap
        public ActionResult DangNhap()
        {
            //return RedirectToAction("DangNhap", "HomeAdmin", new { area = "Admin" });

            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(string user, string password)
        {
            //Check db
            var khachHang = db.user_KhachHang.SingleOrDefault(m => m.username.ToLower() == user.ToLower() && m.password == password);
            if(khachHang != null)
            {
                // tạo session và gán giá trị
                Session["user"] = khachHang;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["error"] = "Tên đăng nhập hoặc mật khẩu không đúng !";
                return View();
            }
           

            //Check code
            //if (user.ToLower() == "admin" && password == "1234")
            //{
            //    Session["user"] = "admin"; // phiên làm việc;
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    TempData["error"] = "Tên đăng nhập hoặc mật khẩu không đúng !";
            //    return View();
            //}
        }

        public ActionResult DangXuat()
        {
            //return RedirectToAction("DangNhap", "HomeAdmin", new { area = "Admin" });
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}