using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTemplate.Models;
using PagedList;

namespace TestTemplate.Areas.Admin.Controllers
{
    [Authorize(Roles = "XemDanhSach")]

    public class PhanCongController : Controller
    {
        // GET: Admin/PhanCong
        QLDSEntities db = new QLDSEntities();
        public ActionResult DanhSachPhanCong(int? page)
        {
            List<PhanCong> dsPhanCongs = db.PhanCongs.ToList();
            //Tạo biến số sản phẩm trên trang
            int PageSize = 6;
            // Tạo biến số trang hiện tại
            int PageNumber = (page ?? 1);
            return View(dsPhanCongs.OrderBy(n => n.MaCS).ToPagedList(PageNumber, PageSize));
        }

        [Authorize(Roles = "Them")]
        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(PhanCong pc)
        {
            if(string.IsNullOrEmpty(pc.MaCS) == true ||
                string.IsNullOrEmpty(pc.MaNV) == true)
            {
                ModelState.AddModelError("", "Thiếu thông tin");
                return View(pc);
            }

            try
            {
                db.PhanCongs.Add(pc);
                db.SaveChanges();
                return RedirectToAction("DanhSachPhanCong");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(pc);
            }
        }

        [Authorize(Roles = "Sua")]
        public ActionResult CapNhatPC(int id)
        {
            var pc = db.PhanCongs.Find(id);
            return View(pc);
        }
        [HttpPost]
        public ActionResult CapNhatPC(PhanCong pc)
        {
            if (string.IsNullOrEmpty(pc.MaNV) == true || string.IsNullOrEmpty(pc.MaCS) == true)
            {
                ModelState.AddModelError("", "Thiếu thông tin");
                return View(pc);
            }

            var updatePC = db.PhanCongs.Find(pc.MaPC);
            try
            {
                updatePC.MaNV = pc.MaNV;
                updatePC.MaCS = pc.MaCS;
                updatePC.GhiChu = pc.GhiChu;

                db.SaveChanges();
                return RedirectToAction("DanhSachPhanCong");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(pc);
            }
        }

        [Authorize(Roles = "Xoa")]
        public ActionResult Xoa(int id)
        {
            var model = db.PhanCongs.Find(id);
            db.PhanCongs.Remove(model);
            db.SaveChanges();
            return RedirectToAction("DanhSachPhanCong");
        }
    }
}