using EntityModel.General;

namespace EntityModel.DataModel
{
    public partial class xFeature : Master
    {
        //public string KeyID { get; set; }
        //public string IDGroup { get; set; }
        //public string VN { get; set; }
        //public string EN { get; set; }
        //public bool IsAdd { get; set; }
        //public bool IsEdit { get; set; }
        //public bool IsDelete { get; set; }
        //public bool IsPrintPreview { get; set; }
        //public bool IsExportExcel { get; set; }
        //public bool IsSave { get; set; }
        //public bool IsEnable { get; set; }
        //public int ItemCount { get; set; }
        //public int Level { get; set; }


        public string Controller { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string Method { get; set; } = string.Empty;
        public string Template { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
    }
}
