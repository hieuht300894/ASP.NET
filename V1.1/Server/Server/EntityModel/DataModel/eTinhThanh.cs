

namespace EntityModel.DataModel
{
    public class eTinhThanh : Master, ITinhThanh, ILoai
    {
        public string DienGiai { get; set; }
        public string PostalCode { get; set; }
        public string LocationCode { get; set; }
        public string ZipCode { get; set; }
        public int IDTinhThanh { get; set; }
        public string MaTinhThanh { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string TenTinhThanh { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int IDLoai { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string MaLoai { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string TenLoai { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
