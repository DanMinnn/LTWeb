using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTemplate.Models;

namespace TestTemplate.Areas.Admin.Controllers
{
    public class CoSoController : Controller
    {
        // GET: Admin/CoSo
        QuanLyDatSanEntities db = new QuanLyDatSanEntities();

        public ActionResult DanhSachCoSo()
        {
            List<coso> danhSachCoSo = db.cosoes.ToList();
            return View(danhSachCoSo);
        }

        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(coso model, HttpPostedFileBase fileAnh)
        {
            if (fileAnh.ContentLength > 0)
            {
                string rootFolder = Server.MapPath("/Content/img/");
                string pathImage = rootFolder + fileAnh.FileName;
                fileAnh.SaveAs(pathImage);
                model.hinhanh = fileAnh.FileName;
            }

            if (string.IsNullOrEmpty(model.macs) == true || string.IsNullOrEmpty(model.tencs) == true ||
                string.IsNullOrEmpty(model.hinhanh) == true || string.IsNullOrEmpty(model.link) == true ||
                    string.IsNullOrEmpty(model.mucgia) == true || string.IsNullOrEmpty(model.diachi) == true)
            {
                ModelState.AddModelError("", "Thiếu thông tin");
                return View(model);
            }

           
            try
            {
                db.cosoes.Add(model);
                db.SaveChanges();
                return RedirectToAction("DanhSachCoSo");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        public ActionResult CapNhat(string id)
        {
            var model_Edit = db.cosoes.Find(id);
            return View(model_Edit);
        }

        [HttpPost]
        public ActionResult CapNhat(coso model_Edit, HttpPostedFileBase fileAnh)
        {
            if (fileAnh.ContentLength > 0)
            {
                string rootFolder = Server.MapPath("/Content/img/");
                string pathImage = rootFolder + fileAnh.FileName;
                fileAnh.SaveAs(pathImage);
                model_Edit.hinhanh = fileAnh.FileName;
            }

            if (string.IsNullOrEmpty(model_Edit.tencs) == true ||
                string.IsNullOrEmpty(model_Edit.hinhanh) == true || string.IsNullOrEmpty(model_Edit.link) == true ||
                    string.IsNullOrEmpty(model_Edit.mucgia) == true || string.IsNullOrEmpty(model_Edit.diachi) == true)
            {
                ModelState.AddModelError("", "Thiếu thông tin");
                return View(model_Edit);
            }
            
           

            var updateCoSo = db.cosoes.Find(model_Edit.macs);
            try
            {
                updateCoSo.tencs = model_Edit.tencs;
                updateCoSo.hinhanh = model_Edit.hinhanh;
                updateCoSo.diachi = model_Edit.diachi;
                updateCoSo.link = model_Edit.link;
                updateCoSo.mucgia = model_Edit.mucgia;
                updateCoSo.mals = model_Edit.mals;

                db.SaveChanges();
                return RedirectToAction("DanhSachCoSo");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model_Edit);
            }
        }

        public ActionResult Xoa(string id)
        {
            var model = db.cosoes.Find(id);
            db.cosoes.Remove(model);
            db.SaveChanges();
            return RedirectToAction("DanhSachCoSo");
        }
    }
}