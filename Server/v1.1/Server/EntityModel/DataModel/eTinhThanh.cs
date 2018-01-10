

namespace EntityModel.DataModel
{
    public class eTinhThanh : Master, ITinhThanh, ILoai
    {
        public string DienGiai { get; set; }
        public string PostalCode { get; set; }
        public string LocationCode { get; set; }
        public string ZipCode { get; set; }
        public int IDTinhThanh { get; set; }
        public string MaTinhThanh { get ; set ; }
        public string TenTinhThanh { get ; set ; }
        public int IDLoai { get ; set ; }
        public string MaLoai { get ; set ; }
        public string TenLoai { get ; set ; }
    }
}
