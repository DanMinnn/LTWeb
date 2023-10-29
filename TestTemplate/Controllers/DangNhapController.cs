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
            var khachHang = db.user_KhachHang.SingleOrDefault(m => m.username == user && m.password == password);
            var admin = db.QuanTriViens.SingleOrDefault(m => m.TenDangNhap.ToLower() == user.ToLower() && m.MatKhau == password);

            if (khachHang != null)
            {
                // tạo session và gán giá trị
                Session["user"] = khachHang;
                return RedirectToAction("Index", "Home");
            }
            else if(admin != null)
            {
                // tạo session và gán giá trị
                Session["admin"] = admin;
                return RedirectToAction("Index", "HomeAdmin", new { area = "Admin" });
            }
            else
            {
                TempData["error"] = "Tên đăng nhập hoặc mật khẩu không đúng !";
                return View();
            }
        }

        public ActionResult DangXuat()
        {
            //return RedirectToAction("DangNhap", "HomeAdmin", new { area = "Admin" });
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}