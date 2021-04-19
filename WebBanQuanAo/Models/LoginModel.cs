using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanQuanAo.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="Bạn phải nhập tên đăng nhập")]
        public string UserName { get; set; }

        [Required(ErrorMessage="Bạn phải nhập mật khẩu")]
        public string Password { get; set; }
    }
}