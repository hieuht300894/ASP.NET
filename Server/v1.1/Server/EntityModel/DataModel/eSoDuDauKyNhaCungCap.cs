

namespace EntityModel.DataModel
{
    public class eSoDuDauKyNhaCungCap : Master,INhaCungCap
    {
        public int IDNhaCungCap { get; set; }
        public string MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public System.DateTime NgayNhap { get; set; }
        public decimal SoTien { get; set; }
    }
}
