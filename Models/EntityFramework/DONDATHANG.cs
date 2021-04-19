namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONDATHANG")]
    public partial class DONDATHANG
    {
        [Display(Name = "Ngày đặt hàng")]
        public DateTime? ngaydathang { get; set; }

        [Display(Name = "Ngày giao hàng")]
        public DateTime? ngaygiaohang { get; set; }

        [Display(Name = "Ngày chuyển hàng")]
        public DateTime? ngaychuyenhang { get; set; }

        [Display(Name = "Nơi giao hàng")]
        [StringLength(200)]
        public string noigiaohang { get; set; }

        [Display(Name = "Mã khách hàng")]
        [Required(ErrorMessage="Bạn phải nhập dữ liệu")]
        public int makhachhang { get; set; }

        [Display(Name = "Tên khách hàng")]
        public int? trangthai { get; set; }

        [Key]
        public int sohoadon { get; set; }
    }
}
