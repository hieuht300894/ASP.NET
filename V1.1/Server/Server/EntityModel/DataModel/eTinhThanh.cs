

namespace EntityModel.DataModel
{
    public class eTinhThanh : Master
    {
        public int IDLoai { get; set; }
        public string Loai { get; set; }
        public string DienGiai { get; set; }
        public string PostalCode { get; set; }
        public string LocationCode { get; set; }
        public string ZipCode { get; set; }
        public int IDTinhThanh { get; set; }
        public string TinhThanh { get; set; }
    }
}
