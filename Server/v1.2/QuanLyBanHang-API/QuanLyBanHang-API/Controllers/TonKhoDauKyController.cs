using EntityModel.DataModel;
using QuanLyBanHang_API;

namespace Server.Controllers
{
    public class TonKhoDauKyController : BaseController<eTonKhoDauKy>
    {
        public TonKhoDauKyController(IRepositoryCollection Collection) : base(Collection)
        {
        }
    }
}
