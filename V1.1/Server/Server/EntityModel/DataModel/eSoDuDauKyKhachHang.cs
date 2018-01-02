using EntityModel.General;

namespace EntityModel.DataModel
{
    public class eSoDuDauKyKhachHang : Master
    {
        public int IDKhachHang { get; set; }
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public System.DateTime NgayNhap { get; set; }
        public decimal SoTien { get; set; }
    }
}
