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
    public class NhanVienController : Controller
    {
        QLDSEntities db = new QLDSEntities();

        public ActionResult DanhSachNhanVien(int? page)
        {
            List<NhanVien> danhSachNhanVien = db.NhanViens.ToList();
            //Tạo biến số sản phẩm trên trang
            int PageSize = 7;
            // Tạo biến số trang hiện tại
            int PageNumber = (page ?? 1);
            return View(danhSachNhanVien.OrderBy(n => n.MaNV).ToPagedList(PageNumber, PageSize));
        }

        [Authorize(Roles = "Them")]
        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(NhanVien model)
        {

            if (string.IsNullOrEmpty(model.MaNV) == true || string.IsNullOrEmpty(model.HoTen) == true ||
             string.IsNullOrEmpty(model.GioiTinh) == true || string.IsNullOrEmpty(model.SDT) == true || 
             string.IsNullOrEmpty(model.Email) == true || string.IsNullOrEmpty(model.CCCD) == true)
            {
                ModelState.AddModelError("", "Thiếu thông tin");
                return View(model);
            }


            try
            {
                db.NhanViens.Add(model);
                db.SaveChanges();
                return RedirectToAction("DanhSachNhanVien");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        [Authorize(Roles = "Sua")]
        public ActionResult CapNhat(string id)
        {
            var model_Edit = db.NhanViens.Find(id);
            return View(model_Edit);
        }

        [HttpPost]
        public ActionResult CapNhat(NhanVien model_Edit)
        {

            if (string.IsNullOrEmpty(model_Edit.HoTen) == true || string.IsNullOrEmpty(model_Edit.GioiTinh) == true ||
                    string.IsNullOrEmpty(model_Edit.SDT) == true || string.IsNullOrEmpty(model_Edit.Email) == true || string.IsNullOrEmpty(model_Edit.CCCD) == true)
            {
                ModelState.AddModelError("", "Thiếu thông tin");
                return View(model_Edit);
            }
            var updateNhanVien = db.NhanViens.Find(model_Edit.MaNV);
            try
            {
                updateNhanVien.HoTen = model_Edit.HoTen;
                updateNhanVien.NgaySinh = model_Edit.NgaySinh;
                updateNhanVien.GioiTinh = model_Edit.GioiTinh;
                updateNhanVien.SDT = model_Edit.SDT;
                updateNhanVien.Email = model_Edit.Email;
                updateNhanVien.CCCD = model_Edit.CCCD;

                db.SaveChanges();
                return RedirectToAction("DanhSachNhanVien");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model_Edit);
            }
        }

        [Authorize(Roles = "Xoa")]
        public ActionResult Xoa(string id)
        {
            var model = db.NhanViens.Find(id);
            db.NhanViens.Remove(model);
            db.SaveChanges();
            return RedirectToAction("DanhSachNhanVien");
        }
    }
}