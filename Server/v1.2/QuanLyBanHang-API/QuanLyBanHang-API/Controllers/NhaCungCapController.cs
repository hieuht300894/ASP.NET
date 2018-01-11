using EntityModel.DataModel;
using QuanLyBanHang_API;

namespace Server.Controllers
{
    public class NhaCungCapController : BaseController<eNhaCungCap>
    {
        public NhaCungCapController(IRepositoryCollection Collection) : base(Collection)
        {
        }
    }
}
