using EntityModel.DataModel;
using QuanLyBanHang_API;

namespace Server.Controllers
{
    public class DonViTinhController : BaseController<eDonViTinh>
    {
        public DonViTinhController(IRepositoryCollection Collection) : base(Collection)
        {
        }
    }
}
