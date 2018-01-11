using EntityModel.DataModel;
using QuanLyBanHang_API;

namespace Server.Controllers
{
    public class KhachHangController : BaseController<eKhachHang>
    {
        public KhachHangController(IRepositoryCollection Collection) : base(Collection)
        {
        }
    }
}
