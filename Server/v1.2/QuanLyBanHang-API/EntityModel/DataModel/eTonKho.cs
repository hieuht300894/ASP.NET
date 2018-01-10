

namespace EntityModel.DataModel
{
    public class eTonKho : Master, INhomSanPham, ISanPham, IDonViTinh, IKho
    {
        public System.DateTime Ngay { get; set; }
        public int IDSanPham { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int IDNhomSanPham { get; set; }
        public string MaNhomSanPham { get; set; }
        public string TenNhomSanPham { get; set; }
        public int IDDonViTinh { get; set; }
        public string MaDonViTinh { get; set; }
        public string TenDonViTinh { get; set; }
        public int IDKho { get; set; }
        public string MaKho { get; set; }
        public string TenKho { get; set; }
        public System.DateTime? HanSuDung { get; set; }
        public int IDMaster { get; set; }
        public int IDDetail { get; set; }
        public bool IsSoDuDauKy { get; set; }
        public bool IsNhapHang { get; set; }
        public bool IsXuatHang { get; set; }
        public bool IsTraHangNhaCungCap { get; set; }
        public bool IsKhachHangTra { get; set; }
        public decimal SoLuongSi { get; set; }
        public decimal SoLuongLe { get; set; }
        public decimal SoLuong { get; set; }
    }
}
