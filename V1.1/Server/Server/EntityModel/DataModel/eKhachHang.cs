namespace EntityModel.DataModel
{
    public class eKhachHang : Master, ITinhThanh, IGioiTinh
    {
        public System.DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public byte[] HinhAnh { get; set; }
        public int IDTinhThanh { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string MaTinhThanh { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string TenTinhThanh { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int IDGioiTinh { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string MaGioiTinh { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string TenGioiTinh { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
