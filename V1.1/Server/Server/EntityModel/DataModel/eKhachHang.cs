namespace EntityModel.DataModel
{
    public class eKhachHang : Master
    {
        public int IDGioiTinh { get; set; }
        public string GioiTinh { get; set; }
        public System.DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public int IDTinhThanh { get; set; }
        public string TinhThanh { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public byte[] HinhAnh { get; set; }
    }
}
