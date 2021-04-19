namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAIHANG")]
    public partial class LOAIHANG
    {
        [Key]
        public int ma { get; set; }

        [StringLength(50)]
        [Display(Name="Loại")]
        [Required(ErrorMessage="Bạn phải nhập dữ liệu")]
        public string loai { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập dữ liệu")]
        [Display(Name = "Mã loại áo")]
        public int? maloaiao { get; set; }

        [Display(Name = "Đường dẫn")]
        [StringLength(50)]
        public string link { get; set; }

        [Display(Name = "Sắp xếp")]
        public int? sapxep { get; set; }
    }
}
