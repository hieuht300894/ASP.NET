using EntityModel.DataModel;
using QuanLyBanHang_API;

namespace Server.Controllers
{
    public class TienTeController : BaseController<eTienTe>
    {
        public TienTeController(IRepositoryCollection Collection) : base(Collection)
        {
        }
    }
}
