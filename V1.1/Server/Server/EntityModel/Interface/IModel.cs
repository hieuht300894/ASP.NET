using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public interface ISanPham { Int32 IDSanPham { get; set; } String MaSanPham { get; set; } String TenSanPham { get; set; } }
    public interface IDonViTinh { Int32 IDDonViTinh { get; set; } String MaDonViTinh { get; set; } String TenDonViTinh { get; set; } }
    public interface IKhachHang { Int32 IDKhachHang { get; set; } String MaKhachHang { get; set; } String TenKhachHang { get; set; } }
    public interface IKho { Int32 IDKho { get; set; } String MaKho { get; set; } String TenKho { get; set; } }
    public interface INhaCungCap { Int32 IDNhaCungCap { get; set; } String MaNhaCungCap { get; set; } String TenNhaCungCap { get; set; } }
    public interface INhomSanPham { Int32 IDNhomSanPham { get; set; } String MaNhomSanPham { get; set; } String TenNhomSanPham { get; set; } }
    public interface ITienTe { Int32 IDTienTe { get; set; } String MaTienTe { get; set; } String TenTienTe { get; set; } }
    public interface ITinhThanh { Int32 IDTinhThanh { get; set; } String MaTinhThanh { get; set; } String TenTinhThanh { get; set; } }
    public interface ITaiKhoan { Int32 IDTaiKhoan { get; set; } String MaTaiKhoan { get; set; } String TenTaiKhoan { get; set; } }
    public interface IChiNhanh { Int32 IDChiNhanh { get; set; } String MaChiNhanh { get; set; } String TenChiNhanh { get; set; } }
    public interface IChucNang { Int32 IDChucNang { get; set; } String MaChucNang { get; set; } String TenChucNang { get; set; } }
    public interface IQuyen { Int32 IDQuyen { get; set; } String MaQuyen { get; set; } String TenQuyen { get; set; } }
    public interface INhanVien { Int32 IDNhanVien { get; set; } String MaNhanVien { get; set; } String TenNhanVien { get; set; } }
    public interface IPhanQuyen { Int32 IDPhanQuyen { get; set; } String MaPhanQuyen { get; set; } String TenPhanQuyen { get; set; } }

}
