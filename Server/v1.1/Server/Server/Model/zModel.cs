using EntityModel.DataModel;
using Server.Utils;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

namespace Server.Model
{
    public class zModel : DbContext
    {
        /*
         * Add-Migration db1 -context zModel
         * Update-Database -context zModel
         * Remove-Migration -context zModel
         */

        #region Cấu hình
        public virtual DbSet<eHienThi> eHienThi { get; set; }
        public virtual DbSet<eQuyDoiDonVi> eQuyDoiDonVi { get; set; }
        public virtual DbSet<eQuyDoiTienTe> eQuyDoiTienTe { get; set; }
        #endregion

        #region Hệ thống
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
        #endregion

        #region Danh mục
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
        #endregion

        #region Khai báo đầu kỳ
        public virtual DbSet<eTonKhoDauKy> eTonKhoDauKy { get; set; }
        public virtual DbSet<eSoDuDauKyKhachHang> eSoDuDauKyKhachHang { get; set; }
        public virtual DbSet<eSoDuDauKyNhaCungCap> eSoDuDauKyNhaCungCap { get; set; }
        #endregion

        #region Công nợ
        public virtual DbSet<eCongNoNhaCungCap> eCongNoNhaCungCap { get; set; }
        #endregion

        #region Chức năng
        public virtual DbSet<eNhapHangNhaCungCap> eNhapHangNhaCungCap { get; set; }
        public virtual DbSet<eNhapHangNhaCungCapChiTiet> eNhapHangNhaCungCapChiTiet { get; set; }
        public virtual DbSet<eTonKho> eTonKho { get; set; }
        #endregion

        public zModel() : base(ModuleHelper.ConnectionString)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Table Name
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
            #endregion

            #region Cấu hình
            modelBuilder.Entity<eHienThi>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eQuyDoiDonVi>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eQuyDoiTienTe>().HasKey(x => x.KeyID);
            #endregion

            #region Hệ thống
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
            #endregion

            #region Danh mục
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
            #endregion

            #region Khai báo đầu kỳ
            modelBuilder.Entity<eTonKhoDauKy>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eSoDuDauKyKhachHang>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eSoDuDauKyNhaCungCap>().HasKey(x => x.KeyID);
            #endregion

            #region Công nợ
            modelBuilder.Entity<eCongNoNhaCungCap>().HasKey(x => x.KeyID);
            #endregion

            #region Chức năng
            modelBuilder.Entity<eNhapHangNhaCungCap>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eNhapHangNhaCungCapChiTiet>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eTonKho>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eNhapHangNhaCungCap>().Ignore(x => x.eNhapHangNhaCungCapChiTiet);
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
