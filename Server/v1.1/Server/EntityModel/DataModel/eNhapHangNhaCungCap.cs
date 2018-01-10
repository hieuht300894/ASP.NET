
using System.Collections.Generic;

namespace EntityModel.DataModel
{
    public class eNhapHangNhaCungCap : Master, INhaCungCap
    {
        public string MaLoHang { get; set; }
        public System.DateTime NgayNhap { get; set; }
        public int IDNhaCungCap { get; set; }
        public string MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public decimal SoLuong { get; set; }
        public decimal ThanhTien { get; set; }
        public decimal VAT { get; set; }
        public decimal TienVAT { get; set; }
        public decimal ChietKhau { get; set; }
        public decimal TienChietKhau { get; set; }
        public decimal TongTien { get; set; }
        public decimal NoCu { get; set; }
        public decimal ThanhToan { get; set; }
        public decimal ConLai { get; set; }
        public virtual ICollection<eNhapHangNhaCungCapChiTiet> eNhapHangNhaCungCapChiTiet { get; set; } = new HashSet<eNhapHangNhaCungCapChiTiet>();
    }
}
