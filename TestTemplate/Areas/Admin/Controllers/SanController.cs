﻿using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTemplate.Models;

namespace TestTemplate.Areas.Admin.Controllers
{
    public class SanController : Controller
    {
        QLDSEntities db = new QLDSEntities();

        public ActionResult DanhSachSan(int? page)
        {
            List<San> danhSachSan = db.Sans.ToList();
            //Tạo biến số sản phẩm trên trang
            int PageSize = 6;
            // Tạo biến số trang hiện tại
            int PageNumber = (page ?? 1);
            return View(danhSachSan.OrderBy(n => n.MaSan).ToPagedList(PageNumber, PageSize));
        }

        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(San s)
        {
            if (string.IsNullOrEmpty(s.MaSan) == true ||
                string.IsNullOrEmpty(s.GiaSan) == true ||
                string.IsNullOrEmpty(s.DanhMucSan.LoaiSan) == true)
            {
                ModelState.AddModelError("", "Thiếu thông tin");
                return View(s);
            }

            try
            {
                db.Sans.Add(s);
                db.SaveChanges();
                return RedirectToAction("DanhSachSan");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(s);
            }
        }

        public ActionResult CapNhat(string id)
        {
            var model_Edit = db.Sans.Find(id);
            return View(model_Edit);
        }

        [HttpPost]
        public ActionResult CapNhat(San model_Edit)
        {
                  if(string.IsNullOrEmpty(model_Edit.GiaSan) == true || string.IsNullOrEmpty(model_Edit.DanhMucSan.LoaiSan) == true)
            {
                ModelState.AddModelError("", "Thiếu thông tin");
                return View(model_Edit);
            }



            var updateSan = db.Sans.Find(model_Edit.MaSan);
            try
            {
                updateSan.SoSan = model_Edit.SoSan;
                updateSan.GiaSan = model_Edit.GiaSan;
                updateSan.DanhMucSan.LoaiSan = model_Edit.DanhMucSan.LoaiSan;

                db.SaveChanges();
                return RedirectToAction("DanhSachSan");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model_Edit);
            }
        }

        public ActionResult Xoa(string id)
        {
            var model = db.Sans.Find(id);
            db.Sans.Remove(model);
            db.SaveChanges();
            return RedirectToAction("DanhSachSan");
        }
    }
}