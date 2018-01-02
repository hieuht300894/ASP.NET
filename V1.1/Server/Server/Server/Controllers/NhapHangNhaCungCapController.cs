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
        public override ActionResult GetAll()
        {
            return Ok(clsNhapHangNhaCungCap.Instance.GetAll());
        }

        public override ActionResult GetByID(Int32 id)
        {
            return Ok(clsNhapHangNhaCungCap.Instance.GetByID(id));
        }

        [HttpGet()]
        [Route("CongNoHienTai/{IDMaster}/{IDNhaCungCap}/{NgayHienTai}")]
        public ActionResult CongNoHienTai(int IDMaster, int IDNhaCungCap, DateTime NgayHienTai)
        {
            return Ok(clsCongNoNhaCungCap.Instance.CongNoHienTai(IDMaster, IDNhaCungCap, NgayHienTai));
        }
    }
}
