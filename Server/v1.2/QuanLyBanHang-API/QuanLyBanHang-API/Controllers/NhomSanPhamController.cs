using EntityModel.DataModel;
using QuanLyBanHang_API;

namespace Server.Controllers
{
    public class NhomSanPhamController : BaseController<eNhomSanPham>
    {
        public NhomSanPhamController(IRepositoryCollection Collection) : base(Collection)
        {
        }
    }
}
