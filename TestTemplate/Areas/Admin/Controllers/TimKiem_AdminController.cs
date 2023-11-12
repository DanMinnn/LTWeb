using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTemplate.Models;

namespace TestTemplate.Areas.Admin.Controllers
{
    public class TimKiem_AdminController : Controller
    {
        // GET: Admin/TimKiem
        QLDSEntities db = new QLDSEntities();
        public ActionResult TimKiem(string sTuKhoa)
        {
            var coSo = db.CoSoes.Where(cs => cs.TenCS.Contains(sTuKhoa)).ToList();
            var nhanVien = db.NhanViens.Where(nv => nv.HoTen.Contains(sTuKhoa) 
            || nv.MaNV.Contains(sTuKhoa)).ToList();
            var khachHang = db.user_KhachHang.Where(kh => kh.HoTen.Contains(sTuKhoa)).ToList();
            var phanCongs = db.PhanCongs.Where(pc => pc.NhanVien.HoTen.Contains(sTuKhoa)).ToList();

            return View("TimKiem", new TimModel { 
                CoSo = coSo,
                NhanVien = nhanVien,
                KhachHang = khachHang,
                phanCongs = phanCongs,
                sTuKhoa = sTuKhoa
            });
        }
    }
}