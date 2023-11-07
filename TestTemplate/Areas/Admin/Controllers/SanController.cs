using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTemplate.Models;
using PagedList;
using System.Web.UI;

namespace TestTemplate.Areas.Admin.Controllers
{
    public class SanController : Controller
    {
        // GET: Admin/San
        QLDSEntities db = new QLDSEntities();

        public ActionResult DanhSachSan(int ?page)
        {
            List<San> ds = db.Sans.ToList();
            int PageSize = 6;
           //Tạo biến số trang hiện tại
            int PageNumber = (page ?? 1);
            return View(ds.OrderBy(n => n.MaSan).ToPagedList(PageNumber, PageSize));
           
        }
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(San model)
        {
            if (ModelState.IsValid)
            {
                // Thêm sân mới vào cơ sở dữ liệu
                db.Sans.Add(model);
                db.SaveChanges();

                // Chuyển hướng đến trang danh sách sân sau khi thêm mới thành công
                return RedirectToAction("DanhSachSan");
            }

            // Nếu có lỗi nhập liệu, hiển thị lại chế độ xem "ThemMoi" để người dùng có thể sửa lỗi
            return View(model);
        }
        public ActionResult CapNhat(string id)
        {
            var model_Edit = db.Sans.Find(id);
            return View(model_Edit);
        }
        public ActionResult Xoa(string id)
        {
           
            return RedirectToAction("DanhSachSan");
        }
    }

}