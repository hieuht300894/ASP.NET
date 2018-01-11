using EntityModel.DataModel;
using QuanLyBanHang_API;

namespace Server.Controllers
{
    public class NhomKhachHangController : BaseController<eNhomKhachHang>
    {
        public NhomKhachHangController(IRepositoryCollection Collection) : base(Collection)
        {
        }
    }
}
