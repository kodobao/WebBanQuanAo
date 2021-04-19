namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MATHANG")]
    public partial class MATHANG
    {
        [Key]
        public int ma { get; set; }

        [StringLength(200)]
        [Display(Name="Tên hàng")]
        [Required(ErrorMessage="Bạn chưa nhập tên hàng")]
        public string tenhang { get; set; }

        [Display(Name = "Số lượng")]
        public int? soluong { get; set; }

        [Display(Name = "Màu sắc")]
        [StringLength(50)]
        public string mausac { get; set; }

        [Display(Name = "Kích thước")]
        [StringLength(25)]
        public string kichthuoc { get; set; }

        [Display(Name = "Mã loại hàng")]
        public int? maloaihang { get; set; }

        [Display(Name = "Hình ảnh")]
        [StringLength(512)]
        public string hinhanh { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(1024)]
        [DataType(DataType.MultilineText)]
        public string mota { get; set; }

        [Display(Name = "Ngày nhập")]
        public DateTime? ngaynhap { get; set; }

        [Display(Name = "Đường dẫn")]
        [StringLength(50)]
        public string metatitle { get; set; }

        [Display(Name = "Giá bán")]
        public decimal? giaban { get; set; }

        [Display(Name = "Giá gốc")]
        public decimal? giagoc { get; set; }

        [Display(Name = "Lượt xem")]
        public int? luotxem { get; set; }

        [Display(Name = "Trạng thái")]
        public bool? trangthai { get; set; }
    }
}
