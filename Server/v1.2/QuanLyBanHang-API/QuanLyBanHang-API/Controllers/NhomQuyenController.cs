using EntityModel.DataModel;
using QuanLyBanHang_API;

namespace Server.Controllers
{
    public class NhomQuyenController : BaseController<xQuyen>
    {
        public NhomQuyenController(IRepositoryCollection Collection) : base(Collection)
        {
        }
    }
}
