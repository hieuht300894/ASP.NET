using EntityModel.DataModel;
using QuanLyBanHang_API;

namespace Server.Controllers
{
    public class PhanQuyenController : BaseController<xPhanQuyen>
    {
        public PhanQuyenController(IRepositoryCollection Collection) : base(Collection)
        {
        }
    }
}
