namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETDATHANG")]
    public partial class CHITIETDATHANG
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name="Số hóa đơn")]
        public int sohoadon { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name="Mã hàng")]
        public int mahang { get; set; }

        [Display(Name="Số lượng")]
        public int? soluong { get; set; }

        [Display(Name="Giá bán")]
        public double? giaban { get; set; }
    }
}
