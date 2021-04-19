namespace Models.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WebBanQuanAoDbContext : DbContext
    {
        public WebBanQuanAoDbContext()
            : base("name=WebBanQuanAoDbContext")
        {
        }

        public virtual DbSet<CHITIETDATHANG> CHITIETDATHANGs { get; set; }
        public virtual DbSet<DONDATHANG> DONDATHANGs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LOAIAO> LOAIAOs { get; set; }
        public virtual DbSet<LOAIHANG> LOAIHANGs { get; set; }
        public virtual DbSet<MATHANG> MATHANGs { get; set; }
        public virtual DbSet<QUANLY> QUANLies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.dienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<LOAIAO>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<LOAIAO>()
                .Property(e => e.metatitle)
                .IsUnicode(false);

            modelBuilder.Entity<LOAIHANG>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.kichthuoc)
                .IsUnicode(false);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.hinhanh)
                .IsUnicode(false);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.metatitle)
                .IsUnicode(false);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.giaban)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.giagoc)
                .HasPrecision(18, 0);

            modelBuilder.Entity<QUANLY>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<QUANLY>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<QUANLY>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<QUANLY>()
                .Property(e => e.phone)
                .IsUnicode(false);
        }
    }
}
