using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanQuanAo.Areas.Admin.Models
{
    public class AccountModel
    {
        [Display(Name="Tên đăng nhập")]
        [Required(ErrorMessage="Bạn phải nhập tên đăng nhập")]
        public string UserName { get; set; }

        [Display(Name="Mật khẩu")]
        [Required(ErrorMessage="Bạn phải nhập mật khẩu")]
        public string Password { get; set; }
        
    }
}