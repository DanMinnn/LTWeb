using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestTemplate.Models
{
    public class DatSan
    {
        public string ma_danhmuc { get; set; }
        public string ma_San { get; set; }
        public string ma_KH { get; set; }
        public string ngayDatSan { get; set; } // Thêm thuộc tính ngày đặt sân kiểu string
        public string gioBatDau { get; set; } // Thêm thuộc tính giờ bắt đầu kiểu string
        public string gioKetThuc { get; set; }
    }
}