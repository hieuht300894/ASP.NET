

namespace EntityModel.DataModel
{
    public class eNhapHangNhaCungCapChiTiet : Master,INhapHangNhaCungCap, INhomSanPham, ISanPham, IDonViTinh, IKho
    {
        public int IDSanPham { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int IDDonViTinh { get; set; }
        public string MaDonViTinh { get; set; }
        public string TenDonViTinh { get; set; }
        public int IDKho { get; set; }
        public string MaKho { get; set; }
        public string TenKho { get; set; }
        public System.DateTime? HanSuDung { get; set; }
        public decimal SoLuongSi { get; set; }
        public decimal SoLuongLe { get; set; }
        public decimal SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        public decimal VAT { get; set; }
        public decimal TienVAT { get; set; }
        public decimal ChietKhau { get; set; }
        public decimal TienChietKhau { get; set; }
        public decimal TongTien { get; set; }
        public int IDNhomSanPham { get ; set ; }
        public string MaNhomSanPham { get ; set ; }
        public string TenNhomSanPham { get ; set ; }
        public string MaNhapHangNhaCungCap { get ; set ; }
        public string TenNhapHangNhaCungCap { get ; set ; }
        public int IDNhapHangNhaCungCap { get ; set ; }
    }
}
