using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTemplate.Models;


namespace TestTemplate.Controllers
{
    public class LichSuDatSanController : Controller
    {
        QLDSEntities db = new QLDSEntities();
        
        // GET: LichSuDatSan
        public ActionResult Index()
        {
            user_KhachHang khachHang = (user_KhachHang)Session["user"];

            List<LichDat> lichDats = db.LichDats.Where(ld => ld.MaKhachHang == khachHang.MaKH).ToList();
            return View(lichDats);
        }

        public ActionResult HuySan(string maLichDat)
        {
            // Tìm lịch đặt sân dựa trên mã lịch đặt (maLichDat)
            var lichDat = db.LichDats.FirstOrDefault(c => c.MaLichDat == maLichDat);
            if (lichDat != null)
            {
                if (lichDat.ThoiGianBatDau <= DateTime.Now)
                {
                    ModelState.AddModelError("", "Bạn không thể huỷ sân vì đang trong giờ diễn ra trận đấu!");
                    return View();
                }

                // Cập nhật trạng thái của lịch đặt thành "Đã huỷ"
                lichDat.TrangThai = "Đã huỷ";

                // Lưu thay đổi vào cơ sở dữ liệu
                db.SaveChanges();

                // Chuyển hướng hoặc trả về thông báo thành công
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Không tìm thấy lịch đặt!");
                return View();
            }
                
        }

        public ActionResult XemHoaDon(string maLichDat)
        {
            List<HoaDon> lstHD = db.HoaDons.Where(c => c.MaLichDat == maLichDat).ToList();
            return View(lstHD);
        }

        public ActionResult CTHD(string maHD)
        {
            List<CTHD> dsCTHDs = db.CTHDs.Where(c => c.MaHoaDon == maHD).ToList();
            return View(dsCTHDs);
        }

    }
}