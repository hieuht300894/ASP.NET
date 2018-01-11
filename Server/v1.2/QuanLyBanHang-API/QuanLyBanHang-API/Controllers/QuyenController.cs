using EntityModel.DataModel;
using QuanLyBanHang_API;

namespace Server.Controllers
{
    public class QuyenController : BaseController<xQuyen>
    {
        public QuyenController(IRepositoryCollection Collection) : base(Collection)
        {
        }
    }
}
