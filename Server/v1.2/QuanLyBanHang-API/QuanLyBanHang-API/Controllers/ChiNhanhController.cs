using EntityModel.DataModel;
using QuanLyBanHang_API;

namespace Server.Controllers
{
    public class ChiNhanhController : BaseController<xChiNhanh>
    {
        public ChiNhanhController(IRepositoryCollection Collection) : base(Collection)
        {
        }
    }
}
