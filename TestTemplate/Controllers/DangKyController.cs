using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTemplate.Models;

namespace TestTemplate.Controllers
{
    public class DangKyController : Controller
    {
        // GET: DangKy
        QLDSEntities db = new QLDSEntities();
        private static int MaKH = 1; // Biến đếm mã khách hàng
        private static int MaTK = 1; // Biến đếm mã khách hàng
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(DangKy model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var check_userName = db.user_KhachHang.Where(u => u.username == model.userName).SingleOrDefault();
            if (check_userName != null)
            {
                TempData["LoiUserName"] = "Tên đăng nhập đã được sử dụng !";
                return View();
            }

            else
            {
                // Lưu khách hàng vào cơ sở dữ liệu
                var lastCustomer = db.user_KhachHang.OrderByDescending(kh => kh.MaKH).FirstOrDefault();
                if (lastCustomer != null)
                {
                    // Nếu có khách hàng trong cơ sở dữ liệu, lấy giá trị của MaKhachHang lớn nhất và tăng lên 1.
                    MaKH = int.Parse(lastCustomer.MaKH) + 1;
                }
                // Tạo mã khách hàng dưới dạng "001", "002", ...
                string makh = $"{MaKH:D3}";
                MaKH++;
                user_KhachHang khachHang = new user_KhachHang()
                {
                    MaKH = makh,
                    HoTen = model.hoTen,
                    SoDienThoai = model.soDienThoai,
                    Email = model.email,
                    username = model.userName,
                    password = model.password
                };
                db.user_KhachHang.Add(khachHang);

                //Lưu tài khoản khách hàng
                var checkMTK = db.TaiKhoans.OrderByDescending(tk => tk.MaTK).FirstOrDefault();
                if (checkMTK != null)
                {
                    // Nếu có tài khoản trong cơ sở dữ liệu, lấy giá trị của MaTK lớn nhất và tăng lên 1.
                    MaTK = int.Parse(checkMTK.MaTK) + 1;
                }
                // Tạo mã tài khoản dưới dạng "001", "002", ...
                string maTK = $"{MaTK:D3}";
                MaTK++;

                TaiKhoan taiKhoan = new TaiKhoan()
                {
                    MaTK = maTK,
                    MaKH = khachHang.MaKH,
                    username = model.userName,
                    password = model.password
                };
                
                

                db.TaiKhoans.Add(taiKhoan);

                db.SaveChanges();
            }

            TempData["DangKyThanhCong"] = "Đăng ký thành công";
            ViewBag.DangKyThanhCong = TempData["DangKyThanhCong"] as string;
            return View();
        }

       
    }
}