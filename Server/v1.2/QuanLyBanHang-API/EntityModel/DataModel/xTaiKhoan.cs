

namespace EntityModel.DataModel
{
    public partial class xTaiKhoan : Master, INhanVien,INhomQuyen
    {
        public string DiaChiIP { get; set; } = string.Empty;
        public int IDNhanVien { get ; set ; }
        public string MaNhanVien { get ; set ; }
        public string TenNhanVien { get ; set ; }
        public int IDNhomQuyen { get ; set ; }
        public string MaNhomQuyen { get ; set ; }
        public string TenNhomQuyen { get ; set ; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
