using EntityModel.DataModel;
using QuanLyBanHang_API;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Server.Controllers
{
    public class TinhThanhController : BaseController<eTinhThanh>
    {
        public TinhThanhController(IRepositoryCollection Collection) : base(Collection)
        {
        }

        [HttpGet]
        public async Task<IHttpActionResult> DanhSach63TinhThanh()
        {
            Instance.Context = new aModel();
            try
            {
                IList<eTinhThanh> lstResult = await Instance.Context.eTinhThanh.Where(x => x.IDLoai >= 1 && x.IDLoai <= 2).ToListAsync();
                return Ok(lstResult);
            }
            catch { return BadRequest(); }
        }
    }
}
