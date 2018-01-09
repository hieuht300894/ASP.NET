

namespace EntityModel.DataModel
{
    public class xPhanQuyen : Master
    {
        public int IDPermission { get; set; } 
        public string PermissionName { get; set; } = string.Empty;
        public int IDFeature { get; set; }
        public string Controller { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string Method { get; set; } = string.Empty;
        public string Template { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
    }
}
