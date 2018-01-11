using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace QuanLyBanHang_API.Controllers
{
    public class CongNoNhaCungCapController : BaseController<eCongNoNhaCungCap>
    {
        public CongNoNhaCungCapController(IRepositoryCollection Collection) : base(Collection)
        {
        }

        [HttpGet]
        public async Task<IHttpActionResult> CongNoHienTai(int IDMaster, int IDNhaCungCap, DateTime NgayHienTai)
        {
            Instance.Context = new aModel();
            try
            {
                IEnumerable<eCongNoNhaCungCap> lstCongNo = await Instance.Context.eCongNoNhaCungCap.Where(x => x.IDNhaCungCap == IDNhaCungCap).ToListAsync();
                lstCongNo = lstCongNo.Where(x => x.Ngay.Date <= NgayHienTai.Date);

                eCongNoNhaCungCap congNo = lstCongNo.FirstOrDefault(x => x.IDMaster == IDMaster) ?? new eCongNoNhaCungCap();
                congNo.ConLai = lstCongNo.Where(x => x.IDMaster != IDMaster).ToList().Sum(x => x.ConLai);
                return Ok(congNo);
            }
            catch { return BadRequest(); }
        }
    }
}