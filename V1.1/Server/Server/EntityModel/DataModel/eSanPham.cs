namespace EntityModel.DataModel
{
    public class eSanPham : Master, IDonViTinh
    {
        //[NotMapped]
        //public Color Color { get; set; }
        public int ColorHex { get; set; }
        public string MauSac { get; set; }
        public string KichThuoc { get; set; }
        public int IDDonViTinh { get; set; }
        public string MaDonViTinh { get; set; }
        public string TenDonViTinh { get; set; }
    }
}
