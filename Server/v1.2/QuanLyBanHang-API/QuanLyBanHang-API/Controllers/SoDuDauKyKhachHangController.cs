using EntityModel.DataModel;
using QuanLyBanHang_API;

namespace Server.Controllers
{
    public class SoDuDauKyKhachHangController : BaseController<eSoDuDauKyKhachHang>
    {
        public SoDuDauKyKhachHangController(IRepositoryCollection Collection) : base(Collection)
        {
        }
    }
}
