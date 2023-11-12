using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTemplate.Models;

namespace TestTemplate.Models
{
    public class TimModel
    {
        public List<CoSo> CoSo { get; set; }
        public List<NhanVien> NhanVien { get; set; }
        public List<user_KhachHang> KhachHang { get; set; }
        public List<PhanCong> phanCongs { get; set; }
        public string sTuKhoa { get; set; }
    }
}