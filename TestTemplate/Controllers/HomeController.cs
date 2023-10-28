using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTemplate.Models;

namespace TestTemplate.Controllers
{
    public class HomeController : Controller
    {
        QLDSEntities db = new QLDSEntities();
        
        public ActionResult Index()
        {

            // Lần lượt tạo ViewBag để lấy list cơ sở từ sql
            // Lấy thông báo đặt sân thành công từ TempData (nếu có)
            ViewBag.ThongBaoDatSan = TempData["ThongBaoDatSan"] as string;
            //List bóng đá
            var listCsBongDa = db.CoSoes.Where(n => n.MaLoaiCS == "bongDa");
            // Gán vào ViewBag
            ViewBag.CsBongDa = listCsBongDa;

            //List bóng rổ
            var listCsBongRo = db.CoSoes.Where(n => n.MaLoaiCS == "bongRo");
            // Gán vào ViewBag
            ViewBag.CsBongRo = listCsBongRo;

            //List bóng cầu lông
            var listCsCauLong = db.CoSoes.Where(n => n.MaLoaiCS == "cauLong");
            // Gán vào ViewBag
            ViewBag.CsCauLong = listCsCauLong;

            //List bóng tennis
            var listCsTennis = db.CoSoes.Where(n => n.MaLoaiCS == "quanVot");
            // Gán vào ViewBag
            ViewBag.CsTennis = listCsTennis;

            return View();
            //return RedirectToAction("DangNhap", "HomeAdmin", new { area = "Admin" });
        }

        
        
    }
}