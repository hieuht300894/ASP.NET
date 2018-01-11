using EntityModel.DataModel;
using QuanLyBanHang_API;

namespace Server.Controllers
{
    public class NhomNhaCungCapController : BaseController<eNhomNhaCungCap>
    {
        public NhomNhaCungCapController(IRepositoryCollection Collection) : base(Collection)
        {
        }
    }
}
