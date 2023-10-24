using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestTemplate.Models
{
    public class DangKy
    {
        [Required(ErrorMessage = "Bạn chưa nhập họ tên !")]
        public string hoTen { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Email không hợp lệ.")]
        public string email { get; set; }
        [Required(ErrorMessage = "Số điện thoại là trường bắt buộc.")]
        [RegularExpression(@"^(\+\d{1,3}[- ]?)?\d{10}$", ErrorMessage = "Số điện thoại không hợp lệ.")]
        public string soDienThoai { get; set; }
        [Required(ErrorMessage = "Tên tài khoản đã được sử dụng !")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu")]
        [StringLength(12, ErrorMessage = "Mật khẩu tối thiểu {2} và tối đa {1} ký tự ", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])[a-zA-Z0-9]+$", ErrorMessage = "Mật khẩu phải có chữ hoa, chữ thường và số")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("password", ErrorMessage = "Mật khẩu không khớp")]
        public string confirm_password { get; set; }

    }
}


