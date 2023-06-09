using Microsoft.EntityFrameworkCore;

namespace SmartClassAPI.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }
        # region DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<MonHoc> MonHocs { get; set; }
        public DbSet<LopHoc> LopHocs { get; set; }
        public DbSet<TaiLieuHocTap> TaiLieuHocTaps { get; set; }
        public DbSet<PhongHocData> PhongHocDatas { get; set; }
        public DbSet<DevicesData> DevicesDatas { get; set; }
        public DbSet<TkbData> TkbDatas { get; set; }
        public DbSet<LoaiUserData> LoaiUserData { get; set; }
        public DbSet<TTMonDT> TinhTrangMonHocDTs { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<QuanLyBuoiHoc> QuanLyBuoiHoc { get; set; }
        public DbSet<TinhTrangBuoiHoc> TinhTrangBuoiHocs { get; set; }
        public DbSet<NhanDienData> NhanDienDatas { get; set; }
        public DbSet<CanhBao> CanhBaos { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // tạo Fluent API
            modelBuilder.Entity<PhongHocData>(e =>
            {
                e.ToTable("PhongHoc");
                e.HasKey(ph => ph.IdPhongHoc);
                //e.Property(ph => ph.TenPhongHoc).HasDefaultValue();
            });
            modelBuilder.Entity<LopHoc>(en =>
            {
                en.ToTable("LopHoc");
                en.HasKey(lh => lh.IdLopHoc);
                //en.Property(lh => lh.NgayTao).HasDefaultValueSql("getutc7date()");
            });
            modelBuilder.Entity<MonHoc>(ent =>
            {
                ent.ToTable("MonHoc");
                ent.HasKey(mh => mh.IdMonHoc);
                //ent.Property(mh => mh.TenMonHoc).HasDefaultValue();
            });
            modelBuilder.Entity<TkbData>(enti =>
            {
                enti.ToTable("ThoiKhoaBieu");
                enti.HasKey(e => new { e.IdLopHoc, e.IdPhongHoc, e.IdMonHoc });

                enti.HasOne(e => e.LopHoc)
                    .WithMany(e => e.TkbDatas)
                    .HasForeignKey(e => e.IdLopHoc)
                    .HasConstraintName("FK_Tkb_LopHoc");
                enti.HasOne(e => e.MonHoc)
                    .WithMany(e => e.TkbDatas)
                    .HasForeignKey(e => e.IdMonHoc)
                    .HasConstraintName("FK_Tkb_MonHoc");
                enti.HasOne(e => e.PhongHocData)
                    .WithMany(e => e.TkbDatas)
                    .HasForeignKey(e => e.IdPhongHoc)
                    .HasConstraintName("FK_Tkb_PhongHoc");
            });
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    //optionsBuilder.UseSqlServer(connectionString);
        //    optionsBuilder.UseLazyLoadingProxies();
        //}
    }

}
