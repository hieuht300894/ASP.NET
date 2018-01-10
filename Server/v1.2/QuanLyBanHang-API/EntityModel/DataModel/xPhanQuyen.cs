

namespace EntityModel.DataModel
{
    public class xPhanQuyen : Master, INhomQuyen, IQuyen
    {
        //public int IDPermission { get; set; } 
        //public string PermissionName { get; set; } = string.Empty;
        //public int IDFeature { get; set; }
        //public string Controller { get; set; } = string.Empty;
        //public string Action { get; set; } = string.Empty;
        //public string Method { get; set; } = string.Empty;
        //public string Template { get; set; } = string.Empty;
        //public string Path { get; set; } = string.Empty;
        public int IDNhomQuyen { get ; set ; }
        public string MaNhomQuyen { get ; set ; }
        public string TenNhomQuyen { get ; set ; }
        public int IDQuyen { get ; set ; }
        public string Controller { get ; set ; }
        public string Action { get ; set ; }
        public string Method { get ; set ; }
        public string Template { get ; set ; }
        public string Path { get ; set ; }
    }
}
