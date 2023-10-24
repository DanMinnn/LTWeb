using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTemplate.Models;

namespace TestTemplate.Controllers
{
    public class FootballController : Controller
    {
        // GET: About
        QuanLyDatSanEntities db = new QuanLyDatSanEntities();
        public ActionResult Index()
        {
            // Lấy thông báo đặt sân thành công từ TempData (nếu có)
            ViewBag.ThongBaoDatSan = TempData["ThongBaoDatSan"] as string;
            var lstCSBongDa = db.CoSoes.Where(n => n.MaLoaiCS == "bongDa");  
            //ViewBag.CsBongDa = lstCSBongDa;
            return View(lstCSBongDa);
        }


    }
}