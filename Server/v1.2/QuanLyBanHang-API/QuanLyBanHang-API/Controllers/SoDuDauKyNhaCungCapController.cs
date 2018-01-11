using EntityModel.DataModel;
using QuanLyBanHang_API;

namespace Server.Controllers
{
    public class SoDuDauKyNhaCungCapController : BaseController<eSoDuDauKyNhaCungCap>
    {
        public SoDuDauKyNhaCungCapController(IRepositoryCollection Collection) : base(Collection)
        {
        }
    }
}
