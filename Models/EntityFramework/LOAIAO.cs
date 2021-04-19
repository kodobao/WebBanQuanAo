namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAIAO")]
    public partial class LOAIAO
    {
        [Key]
        public int ma { get; set; }

        [Column("loaiao")]
        [StringLength(50)]
        [Required(ErrorMessage = "Bạn phải nhập dữ liệu")]
        [Display(Name="Loại áo")]
        public string loaiao1 { get; set; }

        [StringLength(50)]
        [Display(Name = "Đường dẫn")]
        public string link { get; set; }

        [StringLength(50)]
        [Display(Name = "Metatitle")]
        public string metatitle { get; set; }

        [Display(Name = "Sắp xếp")]
        public int? sapxep { get; set; }
    }
}
