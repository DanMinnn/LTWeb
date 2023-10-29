using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TestTemplate.Models;    

namespace TestTemplate.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        QLDSEntities db = new QLDSEntities();
        public ActionResult Index()
        {
                return View();
        }

        //public ActionResult DangNhap()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult DangNhap(string user, string password)
        //{
        //    //Check db
               
        //    //Check code
        //    if(user.ToLower() == "admin" && password == "1234")
        //    {
        //        Session["user"] = "admin"; // phiên làm việc;
        //        return RedirectToAction("Index");
        //    }    
        //    else
        //    {
        //        TempData["error"] = "Tên đăng nhập hoặc mật khẩu không đúng !";
        //        return View();
        //    }
        //}

        public ActionResult DangXuat()
        {
            //xóa session
            Session.Remove("admin");
            // Xóa authentication form
            FormsAuthentication.SignOut();

            return RedirectToAction("DangNhap", "DangNhap", new { area = "" });
        }

        //public ActionResult DanhSachCoSo()
        //{
        //    //1. Lấy danh sách dữ liệu trong bảng
        //    List<coso> danhSachCoSo = db.cosoes.ToList();  
        //    return View(danhSachCoSo);
        //}

        public ActionResult DanhSachNhanVien()
        {
            List<NhanVien> danhSachNhanVien = db.NhanViens.ToList();
            return View(danhSachNhanVien);
        }

        public ActionResult DanhSachSan()
        {
            List<San> dsSan = db.Sans.ToList();
            return View(dsSan);
        }

        public ActionResult DanhSachLichDat()
        {
            List<LichDat> dsLichDat = db.LichDats.ToList();
            return View(dsLichDat);
        }

    }
}