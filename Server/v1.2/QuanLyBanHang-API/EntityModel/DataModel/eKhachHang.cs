namespace EntityModel.DataModel
{
    public class eKhachHang : Master, ITinhThanh, IGioiTinh
    {
        public System.DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public byte[] HinhAnh { get; set; }
        public int IDTinhThanh { get ; set ; }
        public string MaTinhThanh { get ; set ; }
        public string TenTinhThanh { get ; set ; }
        public int IDGioiTinh { get ; set ; }
        public string MaGioiTinh { get ; set ; }
        public string TenGioiTinh { get ; set ; }
    }
}
