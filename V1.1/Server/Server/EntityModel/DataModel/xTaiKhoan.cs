

namespace EntityModel.DataModel
{
    public partial class xTaiKhoan : Master
    {
        public string PersonelName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int IDPermission { get; set; }
        public string PermissionName { get; set; } = string.Empty;
        public string IPAddress { get; set; } = string.Empty;
    }
}
