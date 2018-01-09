

namespace EntityModel.DataModel
{
    public partial class xTaiKhoan : Master, INhanVien,INhomQuyen
    {
        public string DiaChiIP { get; set; } = string.Empty;
        public int IDNhanVien { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string MaNhanVien { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string TenNhanVien { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int IDNhomQuyen { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string MaNhomQuyen { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string TenNhomQuyen { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
