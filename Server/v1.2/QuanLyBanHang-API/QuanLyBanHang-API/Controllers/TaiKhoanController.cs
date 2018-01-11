using EntityModel.DataModel;
using QuanLyBanHang_API;

namespace Server.Controllers
{
    public class TaiKhoanController : BaseController<xTaiKhoan>
    {
        public TaiKhoanController(IRepositoryCollection Collection) : base(Collection)
        {
        }
    }
}
