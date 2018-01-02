using EntityModel.General;

namespace EntityModel.DataModel
{
   public class eTonKho : Master
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
        public decimal SoLuongNhap { get; set; }
        public decimal SoLuongXuat { get; set; }
        public decimal SoLuongTraNhaCungCap { get; set; }
        public decimal SoLuongKhachHangTra { get; set; }
        public decimal SoLuongTon { get; set; }
    }
}
