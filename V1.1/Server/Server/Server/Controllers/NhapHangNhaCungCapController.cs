using EntityModel.DataModel;
using Server.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    public class NhapHangNhaCungCapController : BaseController<eNhapHangNhaCungCap>
    {
        public async override Task<ActionResult> GetAll()
        {
            return Ok(await clsNhapHangNhaCungCap.Instance.GetAll());
        }

        public async override Task<ActionResult> GetByID(Int32? KeyID)
        {
            return Ok(await clsNhapHangNhaCungCap.Instance.GetByID(KeyID.HasValue ? KeyID.Value : 0));
        }

        [HttpGet, Route("{IDMaster}/{IDNhaCungCap}/{NgayHienTai}")]
        public async Task<ActionResult> CongNoHienTai(int IDMaster, int IDNhaCungCap, DateTime NgayHienTai)
        {
            return Ok(await clsCongNoNhaCungCap.Instance.CongNoHienTai(IDMaster, IDNhaCungCap, NgayHienTai));
        }
    }
}
