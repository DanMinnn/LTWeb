using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTemplate.Models;
using System.Web.Security;

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

            var admin = db.QuanTriViens.SingleOrDefault(m => m.TenDangNhap == user && m.MatKhau == password);
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
                // Lấy ra quyền tương ứng với QTV
                var lstQuyen = db.PhanQuyens.Where(n => n.MaQTV == admin.MaQTV);
                // Duyệt list quyền
                string Quyen = "";
                foreach(var item in lstQuyen)
                {
                    Quyen += item.Quyen.MaQuyen + ",";
                }
                Quyen = Quyen.Substring(0, Quyen.Length - 1); // Cắt dấu ","
                PhanQuyen(admin.MaQTV, Quyen);
                return RedirectToAction("Index", "ThongKe", new { area = "Admin" });
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
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public void PhanQuyen(string user, string quyen)
        {
            FormsAuthentication.Initialize();

            var ticket = new FormsAuthenticationTicket(1, 
                                                        user,
                                                        DateTime.Now,// begin
                                                        DateTime.Now.AddHours(3), // timeout
                                                        false,// remeber ?
                                                        quyen,
                                                        FormsAuthentication.FormsCookiePath);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));

            if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;

            Response.Cookies.Add(cookie);
        }
    }
}