namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [Key]
        public int ma { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name="Tên khách hàng")]
        public string tenkhachhang { get; set; }

        [StringLength(200)]
        [Display(Name = "Địa chỉ")]
        public string diachi { get; set; }

        [StringLength(12)]
        [Display(Name = "Điện thoại")]
        public string dienthoai { get; set; }

        [StringLength(200)]
        [Display(Name = "Email")]
        public string email { get; set; }

        [StringLength(50)]
        [Display(Name = "UserName")]
        public string username { get; set; }

        [StringLength(100)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Display(Name = "Trạng thái")]
        public int? trangthai { get; set; }
    }
}
