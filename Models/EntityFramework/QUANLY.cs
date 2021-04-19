namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUANLY")]
    public partial class QUANLY
    {
        [Key]
        [StringLength(50)]
        public string username { get; set; }

        [Required]
        [StringLength(100)]
        public string password { get; set; }

        [StringLength(200)]
        public string fullname { get; set; }

        [StringLength(200)]
        public string email { get; set; }

        public int? IsAdmin { get; set; }

        public int? Allower { get; set; }

        [StringLength(50)]
        public string phone { get; set; }
    }
}
