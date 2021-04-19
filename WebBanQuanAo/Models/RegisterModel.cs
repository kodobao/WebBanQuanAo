using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanQuanAo.Models
{
    public class RegisterModel
    {

        [Required(ErrorMessage="Bạn chưa nhập họ và tên")]
        [Display(Name = "Họ và tên")]
        public string tenkhachhang { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập tên đăng nhập")]
        [Display(Name = "Tên đăng nhập")]
        public string username { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Email")]
        [Display(Name = "Email")]
        public string email {get; set;}

        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại")]
        [Display(Name = "Số điện thoại")]
        public string dienthoai {get; set;}

        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ")]
        [Display(Name = "Địa chỉ")]
        public string diachi {get; set;}

        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        public string password {get; set;}

        [Compare("password", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
        [Display(Name = "Nhập lại mật khẩu")]
        public string confirmpassowrd {get; set;}

        [Display(Name="Tỉnh/thành")]
        public string provinceID { set; get; }

        [Display(Name = "Quận/Quyện")]
        public string districtID { set; get; }

    }
}