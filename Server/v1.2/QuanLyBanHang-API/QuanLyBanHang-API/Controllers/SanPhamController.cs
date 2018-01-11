using EntityModel.DataModel;
using QuanLyBanHang_API;

namespace Server.Controllers
{
    public class SanPhamController : BaseController<eSanPham>
    {
        public SanPhamController(IRepositoryCollection Collection) : base(Collection)
        {
        }
    }
}
