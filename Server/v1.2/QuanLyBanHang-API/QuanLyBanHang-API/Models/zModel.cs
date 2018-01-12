using EntityModel.DataModel;
using QuanLyBanHang_API.Utils;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace QuanLyBanHang_API
{
    public class zModel : DbContext
    {
        /*
         * Add-Migration db1 -context zModel
         * Update-Database -context zModel
         * Remove-Migration -context zModel
         */

        public virtual DbSet<eHienThi> eHienThi { get; set; }
        public virtual DbSet<eQuyDoiDonVi> eQuyDoiDonVi { get; set; }
        public virtual DbSet<eQuyDoiTienTe> eQuyDoiTienTe { get; set; }
        public virtual DbSet<xTaiKhoan> xTaiKhoan { get; set; }
        public virtual DbSet<xChiNhanh> xChiNhanh { get; set; }
        public virtual DbSet<xNhanVien> xNhanVien { get; set; }
        public virtual DbSet<xCauHinh> xCauHinh { get; set; }
        public virtual DbSet<xHienThi> xHienThi { get; set; }
        public virtual DbSet<xNhomQuyen> xNhomQuyen { get; set; }
        public virtual DbSet<xNgonNgu> xNgonNgu { get; set; }
        public virtual DbSet<xQuyen> xQuyen { get; set; }
        public virtual DbSet<xPhanQuyen> xPhanQuyen { get; set; }
        public virtual DbSet<xLichSu> xLichSu { get; set; }
        public virtual DbSet<eDonViTinh> eDonViTinh { get; set; }
        public virtual DbSet<eKhachHang> eKhachHang { get; set; }
        public virtual DbSet<eKho> eKho { get; set; }
        public virtual DbSet<eNhaCungCap> eNhaCungCap { get; set; }
        public virtual DbSet<eNhomDonViTinh> eNhomDonViTinh { get; set; }
        public virtual DbSet<eNhomKhachHang> eNhomKhachHang { get; set; }
        public virtual DbSet<eNhomNhaCungCap> eNhomNhaCungCap { get; set; }
        public virtual DbSet<eNhomSanPham> eNhomSanPham { get; set; }
        public virtual DbSet<eSanPham> eSanPham { get; set; }
        public virtual DbSet<eTienTe> eTienTe { get; set; }
        public virtual DbSet<eTinhThanh> eTinhThanh { get; set; }
        public virtual DbSet<eTonKhoDauKy> eTonKhoDauKy { get; set; }
        public virtual DbSet<eSoDuDauKyKhachHang> eSoDuDauKyKhachHang { get; set; }
        public virtual DbSet<eSoDuDauKyNhaCungCap> eSoDuDauKyNhaCungCap { get; set; }
        public virtual DbSet<eCongNoNhaCungCap> eCongNoNhaCungCap { get; set; }
        public virtual DbSet<eNhapHangNhaCungCap> eNhapHangNhaCungCap { get; set; }
        public virtual DbSet<eNhapHangNhaCungCapChiTiet> eNhapHangNhaCungCapChiTiet { get; set; }
        public virtual DbSet<eTonKho> eTonKho { get; set; }
        public virtual DbSet<eLoai> eLoai { get; set; }
        public virtual DbSet<eCauHinhMa> eCauHinhMa { get; set; }

        public zModel() : base(ModuleHelper.ConnectionString)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region TableName
            modelBuilder.Entity<eHienThi>().ToTable("eHienThi");
            modelBuilder.Entity<eQuyDoiDonVi>().ToTable("eQuyDoiDonVi");
            modelBuilder.Entity<eQuyDoiTienTe>().ToTable("eQuyDoiTienTe");
            modelBuilder.Entity<eDonViTinh>().ToTable("eDonViTinh");
            modelBuilder.Entity<eKhachHang>().ToTable("eKhachHang");
            modelBuilder.Entity<eKho>().ToTable("eKho");
            modelBuilder.Entity<eNhaCungCap>().ToTable("eNhaCungCap");
            modelBuilder.Entity<eNhomDonViTinh>().ToTable("eNhomDonViTinh");
            modelBuilder.Entity<eNhomKhachHang>().ToTable("eNhomKhachHang");
            modelBuilder.Entity<eNhomNhaCungCap>().ToTable("eNhomNhaCungCap");
            modelBuilder.Entity<eNhomSanPham>().ToTable("eNhomSanPham");
            modelBuilder.Entity<eTienTe>().ToTable("eTienTe");
            modelBuilder.Entity<eTinhThanh>().ToTable("eTinhThanh");
            modelBuilder.Entity<eSanPham>().ToTable("eSanPham");
            modelBuilder.Entity<eTonKhoDauKy>().ToTable("eTonKhoDauKy");
            modelBuilder.Entity<eSoDuDauKyKhachHang>().ToTable("eSoDuDauKyKhachHang");
            modelBuilder.Entity<eSoDuDauKyNhaCungCap>().ToTable("eSoDuDauKyNhaCungCap");
            modelBuilder.Entity<eCongNoNhaCungCap>().ToTable("eCongNoNhaCungCap");
            modelBuilder.Entity<eNhapHangNhaCungCap>().ToTable("eNhapHangNhaCungCap");
            modelBuilder.Entity<eNhapHangNhaCungCapChiTiet>().ToTable("eNhapHangNhaCungCapChiTiet");
            modelBuilder.Entity<eTonKho>().ToTable("eTonKho");
            modelBuilder.Entity<xTaiKhoan>().ToTable("xTaiKhoan");
            modelBuilder.Entity<xChiNhanh>().ToTable("xChiNhanh");
            modelBuilder.Entity<xNhanVien>().ToTable("xNhanVien");
            modelBuilder.Entity<xCauHinh>().ToTable("xCauHinh");
            modelBuilder.Entity<xHienThi>().ToTable("xHienThi");
            modelBuilder.Entity<xNhomQuyen>().ToTable("xNhomQuyen");
            modelBuilder.Entity<xNgonNgu>().ToTable("xNgonNgu");
            modelBuilder.Entity<xQuyen>().ToTable("xQuyen");
            modelBuilder.Entity<xPhanQuyen>().ToTable("xPhanQuyen");
            modelBuilder.Entity<xLichSu>().ToTable("xLichSu");
            modelBuilder.Entity<eCauHinhMa>().ToTable("eCauHinhMa");
            modelBuilder.Entity<eLoai>().ToTable("eLoai");
            #endregion

            #region PrimaryKey
            modelBuilder.Entity<eHienThi>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eQuyDoiDonVi>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eQuyDoiTienTe>().HasKey(x => x.KeyID);
            modelBuilder.Entity<xTaiKhoan>().HasKey(x => x.KeyID);
            modelBuilder.Entity<xTaiKhoan>().Property(x => x.KeyID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            modelBuilder.Entity<xChiNhanh>().HasKey(x => x.KeyID);
            modelBuilder.Entity<xNhanVien>().HasKey(x => x.KeyID);
            modelBuilder.Entity<xCauHinh>().HasKey(x => x.KeyID);
            modelBuilder.Entity<xHienThi>().HasKey(x => x.KeyID);
            modelBuilder.Entity<xNhomQuyen>().HasKey(x => x.KeyID);
            modelBuilder.Entity<xNgonNgu>().HasKey(x => x.KeyID);
            modelBuilder.Entity<xQuyen>().HasKey(x => x.KeyID);
            modelBuilder.Entity<xPhanQuyen>().HasKey(x => x.KeyID);
            modelBuilder.Entity<xLichSu>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eDonViTinh>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eKhachHang>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eKho>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eNhaCungCap>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eNhomDonViTinh>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eNhomKhachHang>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eNhomNhaCungCap>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eNhomSanPham>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eTienTe>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eTinhThanh>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eSanPham>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eTonKhoDauKy>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eSoDuDauKyKhachHang>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eSoDuDauKyNhaCungCap>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eCongNoNhaCungCap>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eNhapHangNhaCungCap>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eNhapHangNhaCungCapChiTiet>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eTonKho>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eCauHinhMa>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eLoai>().HasKey(x => x.KeyID);
            #endregion

            #region Ignore
            modelBuilder.Entity<eNhapHangNhaCungCap>().Ignore(x => x.eNhapHangNhaCungCapChiTiet);

            modelBuilder.Entity<eTinhThanh>().Ignore(x => x.DienGiai);
            modelBuilder.Entity<eTinhThanh>().Ignore(x => x.PostalCode);
            modelBuilder.Entity<eTinhThanh>().Ignore(x => x.LocationCode);
            modelBuilder.Entity<eTinhThanh>().Ignore(x => x.ZipCode);
            modelBuilder.Entity<eTinhThanh>().Ignore(x => x.MaTinhThanh);
            modelBuilder.Entity<eTinhThanh>().Ignore(x => x.MaLoai);
            modelBuilder.Entity<eTinhThanh>().Ignore(x => x.Ma);
            modelBuilder.Entity<eTinhThanh>().Ignore(x => x.NgayTao);
            modelBuilder.Entity<eTinhThanh>().Ignore(x => x.NguoiTao);
            modelBuilder.Entity<eTinhThanh>().Ignore(x => x.MaNguoiTao);
            modelBuilder.Entity<eTinhThanh>().Ignore(x => x.TenNguoiTao);
            modelBuilder.Entity<eTinhThanh>().Ignore(x => x.NgayCapNhat);
            modelBuilder.Entity<eTinhThanh>().Ignore(x => x.NguoiCapNhat);
            modelBuilder.Entity<eTinhThanh>().Ignore(x => x.MaNguoiCapNhat);
            modelBuilder.Entity<eTinhThanh>().Ignore(x => x.TenNguoiCapNhat);
            modelBuilder.Entity<eTinhThanh>().Ignore(x => x.GhiChu);

            modelBuilder.Entity<xQuyen>().Ignore(x => x.Ma);
            modelBuilder.Entity<xQuyen>().Ignore(x => x.Ten);
            modelBuilder.Entity<xQuyen>().Ignore(x => x.NgayTao);
            modelBuilder.Entity<xQuyen>().Ignore(x => x.NguoiTao);
            modelBuilder.Entity<xQuyen>().Ignore(x => x.MaNguoiTao);
            modelBuilder.Entity<xQuyen>().Ignore(x => x.TenNguoiTao);
            modelBuilder.Entity<xQuyen>().Ignore(x => x.NgayCapNhat);
            modelBuilder.Entity<xQuyen>().Ignore(x => x.NguoiCapNhat);
            modelBuilder.Entity<xQuyen>().Ignore(x => x.MaNguoiCapNhat);
            modelBuilder.Entity<xQuyen>().Ignore(x => x.TenNguoiCapNhat);
            modelBuilder.Entity<xQuyen>().Ignore(x => x.GhiChu);

            modelBuilder.Entity<xTaiKhoan>().Ignore(x => x.Ma);
            modelBuilder.Entity<xTaiKhoan>().Ignore(x => x.Ten);

            modelBuilder.Entity<xLichSu>().Ignore(x => x.Ma);
            modelBuilder.Entity<xLichSu>().Ignore(x => x.Ten);
            modelBuilder.Entity<xLichSu>().Ignore(x => x.NgayTao);
            modelBuilder.Entity<xLichSu>().Ignore(x => x.NguoiTao);
            modelBuilder.Entity<xLichSu>().Ignore(x => x.MaNguoiTao);
            modelBuilder.Entity<xLichSu>().Ignore(x => x.TenNguoiTao);
            modelBuilder.Entity<xLichSu>().Ignore(x => x.NgayCapNhat);
            modelBuilder.Entity<xLichSu>().Ignore(x => x.NguoiCapNhat);
            modelBuilder.Entity<xLichSu>().Ignore(x => x.MaNguoiCapNhat);
            modelBuilder.Entity<xLichSu>().Ignore(x => x.TenNguoiCapNhat);
            modelBuilder.Entity<xLichSu>().Ignore(x => x.GhiChu);

            modelBuilder.Entity<eQuyDoiDonVi>().Ignore(x => x.Ma);
            modelBuilder.Entity<eQuyDoiDonVi>().Ignore(x => x.Ten);
            modelBuilder.Entity<eQuyDoiDonVi>().Ignore(x => x.NgayTao);
            modelBuilder.Entity<eQuyDoiDonVi>().Ignore(x => x.NguoiTao);
            modelBuilder.Entity<eQuyDoiDonVi>().Ignore(x => x.MaNguoiTao);
            modelBuilder.Entity<eQuyDoiDonVi>().Ignore(x => x.TenNguoiTao);
            modelBuilder.Entity<eQuyDoiDonVi>().Ignore(x => x.NgayCapNhat);
            modelBuilder.Entity<eQuyDoiDonVi>().Ignore(x => x.NguoiCapNhat);
            modelBuilder.Entity<eQuyDoiDonVi>().Ignore(x => x.MaNguoiCapNhat);
            modelBuilder.Entity<eQuyDoiDonVi>().Ignore(x => x.TenNguoiCapNhat);
            modelBuilder.Entity<eQuyDoiDonVi>().Ignore(x => x.GhiChu);

            modelBuilder.Entity<eLoai>().Ignore(x => x.Ma);
            modelBuilder.Entity<eLoai>().Ignore(x => x.NgayTao);
            modelBuilder.Entity<eLoai>().Ignore(x => x.NguoiTao);
            modelBuilder.Entity<eLoai>().Ignore(x => x.MaNguoiTao);
            modelBuilder.Entity<eLoai>().Ignore(x => x.TenNguoiTao);
            modelBuilder.Entity<eLoai>().Ignore(x => x.NgayCapNhat);
            modelBuilder.Entity<eLoai>().Ignore(x => x.NguoiCapNhat);
            modelBuilder.Entity<eLoai>().Ignore(x => x.MaNguoiCapNhat);
            modelBuilder.Entity<eLoai>().Ignore(x => x.TenNguoiCapNhat);
            modelBuilder.Entity<eLoai>().Ignore(x => x.GhiChu);
            #endregion
        }
    }

    public class MyConfiguration : DbMigrationsConfiguration<aModel>
    {
        public MyConfiguration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }
    }
}
