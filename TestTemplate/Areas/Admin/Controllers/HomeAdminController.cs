using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TestTemplate.Models;
using PagedList;

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

        public ActionResult DangXuat()
        {
            //xóa session
            Session.Remove("admin");
            // Xóa authentication form
            FormsAuthentication.SignOut();

            return RedirectToAction("DangNhap", "DangNhap", new { area = "" });
        }
        public ActionResult DanhSachLichDat(int? page)
        {
            List<LichDat> dsLichDat = db.LichDats.ToList();
            //Tạo biến số sản phẩm trên trang
            int PageSize = 6;
            // Tạo biến số trang hiện tại
            int PageNumber = (page ?? 1);
            return View(dsLichDat.OrderBy(n => n.MaLichDat).ToPagedList(PageNumber, PageSize));
        }
    }
}