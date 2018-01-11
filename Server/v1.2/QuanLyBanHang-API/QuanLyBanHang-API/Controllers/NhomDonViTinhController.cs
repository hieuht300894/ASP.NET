using EntityModel.DataModel;
using QuanLyBanHang_API;

namespace Server.Controllers
{
    public class NhomDonViTinhController : BaseController<eNhomDonViTinh>
    {
        public NhomDonViTinhController(IRepositoryCollection Collection) : base(Collection)
        {
        }
    }
}
