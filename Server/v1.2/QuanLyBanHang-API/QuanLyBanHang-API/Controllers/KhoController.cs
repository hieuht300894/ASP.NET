using EntityModel.DataModel;
using QuanLyBanHang_API;

namespace Server.Controllers
{
    public class KhoController : BaseController<eKho>
    {
        public KhoController(IRepositoryCollection Collection) : base(Collection)
        {
        }
    }
}
