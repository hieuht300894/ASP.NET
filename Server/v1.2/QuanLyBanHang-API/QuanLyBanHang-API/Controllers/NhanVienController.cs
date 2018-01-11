using EntityModel.DataModel;
using QuanLyBanHang_API;

namespace Server.Controllers
{
    public class NhanVienController : BaseController<xNhanVien>
    {
        public NhanVienController(IRepositoryCollection Collection) : base(Collection)
        {
        }
    }
}
