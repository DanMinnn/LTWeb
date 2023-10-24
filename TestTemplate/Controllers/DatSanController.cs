using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTemplate.Models;

namespace TestTemplate.Controllers
{
    public class DatSanController : Controller
    {
        // GET: DatSan
        private static int madatsanCounter = 1; // Biến đếm mã đặt sân
        private static int maKHCounter = 1; // Biến đếm mã khách hàng
        public ActionResult Index(string id_coso, string ten_coso)
        {
            Session["ten_coso"] = ten_coso;
            Session["id_coso"] = id_coso;
            return View();
        }


        [HttpPost]
        public ActionResult Index(DatSan model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!kiemtra_TG_Trandau(model.gioBatDau, model.gioKetThuc))
            {
                ModelState.AddModelError("", "Thời gian bạn chọn không hợp lệ, vui lòng chọn lại\n  Thời gian mở cửa từ 7 giờ sáng đến 23 giờ cùng ngày.\nTổng thời gian trận đấu phải kéo dài từ 30 phút trở lên và không được đặt quá 1 tháng trước thời gian hiện tại.");
                return View(model);
            }


            string id_coso = Session["id_coso"] as string;
            var maSanDaChon = model.ma_San;
            QuanLyDatSanEntities db = new QuanLyDatSanEntities();


            foreach (var lich in db.LichDats.Where(c => c.MaSan == maSanDaChon))
            {
                if (KiemTraTrungLich(lich, model.gioBatDau, model.gioKetThuc))
                {
                    ModelState.AddModelError("", "Thời gian đã bị trùng lịch, vui lòng chọn khung giờ khác");
                    return View(model);
                }
            }
    
            // Lưu model vào TempData để sử dụng sau này
            TempData["ThongTinDatSan"] = model;

            return RedirectToAction("XacNhanDatSan",model);
        }

        public ActionResult XacNhanDatSan(DatSan model)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult XacNhanDatSan()
        {
            // Lấy thông tin đặt sân từ TempData
            var model = TempData["ThongTinDatSan"] as DatSan;
            if (model == null)
            {
                // Xử lý lỗi nếu không có thông tin đặt sân
                return RedirectToAction("danhsach");
            }
            QuanLyDatSanEntities db = new QuanLyDatSanEntities();

            // Tiến hành lưu thông tin vào cơ sở dữ liệu ở đây, tương tự như bạn đã làm trong action "danhsach"
            bool ktr_kh = db.user_KhachHang.Any(kh => kh.SoDienThoai == model.soDienThoai && kh.HoTen == model.hoTen && kh.Email == model.email);
            string maDatSan = $"{model.ma_San}_{madatsanCounter:D3}";
            madatsanCounter++;
            user_KhachHang kh_ms = null;
            if (ktr_kh)
            {
                kh_ms = db.user_KhachHang.SingleOrDefault(kh => kh.SoDienThoai == model.soDienThoai && kh.Email == model.email && kh.HoTen == model.hoTen);
            }
            else
            {
                int soLuongKhachHangCungSDT = db.user_KhachHang.Count(kh => kh.SoDienThoai == model.soDienThoai);

                if (soLuongKhachHangCungSDT >= 6)
                {
                    ModelState.AddModelError("", "Số điện thoại này đã có quá nhiều khách hàng liên kết. Không thể tiếp tục đặt sân với số điện thoại này.");
                    return View(model);
                }

                var lastCustomer = db.user_KhachHang.OrderByDescending(kh => kh.MaKH).FirstOrDefault();
                if (lastCustomer != null)
                {
                    // Nếu có khách hàng trong cơ sở dữ liệu, lấy giá trị của MaKhachHang lớn nhất và tăng lên 1.
                    maKHCounter = int.Parse(lastCustomer.MaKH) + 1;
                }
                // Tạo mã khách hàng dưới dạng "001", "002", ...
                string makh = $"{maKHCounter:D3}";
                maKHCounter++;
                kh_ms = new user_KhachHang
                {
                    MaKH = makh,
                    HoTen = model.hoTen,
                    SoDienThoai = model.soDienThoai,
                    Email = model.email
                };
                db.user_KhachHang.Add(kh_ms);
            }

            LichDat ld_ms = new LichDat
            {
                MaLichDat = maDatSan,
                MaKhachHang = kh_ms.MaKH,
                MaSan = model.ma_San,
                ThoiGianBatDau = model.gioBatDau,
                ThoiGianKetThuc = model.gioKetThuc
            };

            db.LichDats.Add(ld_ms);

            // Lưu thay đổi vào cơ sở dữ liệu
            db.SaveChanges();

            //thông báo khi đặt thành côg
            TempData["ThongBaoDatSan"] = "Đặt sân thành công!";

            // Chuyển hướng sau khi lưu vào cơ sở dữ liệu
            return RedirectToAction("Index","Football");
        }


        // Phương thức kiểm tra trùng lịch
        private bool KiemTraTrungLich(LichDat lich, DateTime gioBatDau, DateTime gioKetThuc)
        {
            // Kiểm tra xem thời gian bắt đầu và kết thúc của lịch đã nhập có trùng với lịch trong cơ sở dữ liệu không
            if ((gioBatDau >= lich.ThoiGianBatDau && gioBatDau < lich.ThoiGianKetThuc) ||
                (gioKetThuc > lich.ThoiGianBatDau && gioKetThuc <= lich.ThoiGianKetThuc) ||
                (gioBatDau <= lich.ThoiGianBatDau && gioKetThuc >= lich.ThoiGianKetThuc))
            {
                return true; // Có trùng lịch
            }

            return false; // Không trùng lịch
        }

        public bool kiemtra_TG_Trandau(DateTime tg_batdau, DateTime tg_ketthuc)
        {
            TimeSpan duration = tg_ketthuc - tg_batdau;

            if (tg_ketthuc <= DateTime.Now || tg_batdau.Hour < 7 || tg_ketthuc.Hour > 23 || tg_batdau > DateTime.Now.AddMonths(1))
            {
                return false; // Thời gian kết thúc không hợp lệ hoặc nằm ngoài giờ mở cửa hoặc cách thời gian hiện tại quá 1 tháng.
            }

            if (tg_batdau <= DateTime.Now.AddMinutes(30) || tg_batdau >= tg_ketthuc || duration.TotalHours < 0.5 || duration.TotalHours >= 5)
            {
                return false; // Thời gian đặt sân không hợp lệ.
            }

            return true; // Thời gian hợp lệ.
        }

        // Trong phương thức hoặc công việc kiểm tra thời gian đã qua
        public void XoaLichDatDaQuaThoiGian()
        {
            using (var context = new QuanLyDatSanEntities()) // Thay thế bằng DbContext của bạn
            {
                DateTime now = DateTime.Now;

                // Lấy danh sách các lịch đặt đã qua thời gian hiện tại
                var lichDatCanXoa = context.LichDats.Where(ld => ld.ThoiGianKetThuc < now).ToList();

                foreach (var lichDat in lichDatCanXoa)
                {
                    context.LichDats.Remove(lichDat); // Xoá lịch đặt đã qua thời gian
                }

                context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }
        }
    }
}