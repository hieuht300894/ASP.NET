using EntityModel.DataModel;
using Server.BLL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    public class TinhThanhController : BaseController<eTinhThanh>
    {
        [HttpGet]
        [Route("DanhSach63TinhThanh")]
        public ActionResult DanhSach63TinhThanh()
        {
            return Ok(clsTinhThanh.Instance.DanhSach63TinhThanh());
        }
    }
}
