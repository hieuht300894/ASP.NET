

using System;

namespace EntityModel.DataModel
{
    public class eTonKhoDauKy : Master, INhomSanPham, ISanPham, IDonViTinh, IKho
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
        public System.DateTime NgayKiem { get; set; }
        public DateTime? HanSuDung { get; set; }
        public decimal SoLuong { get; set; }
        public int IDNhomSanPham { get ; set ; }
        public string MaNhomSanPham { get ; set ; }
        public string TenNhomSanPham { get ; set ; }
    }
}
