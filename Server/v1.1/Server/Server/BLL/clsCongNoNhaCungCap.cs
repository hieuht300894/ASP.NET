using EntityModel.DataModel;
using Server.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Server.BLL
{
    public class clsCongNoNhaCungCap : clsFunction<eCongNoNhaCungCap>
    {
        #region Contructor
        protected clsCongNoNhaCungCap() { }
        public new static clsCongNoNhaCungCap Instance
        {
            get { return new clsCongNoNhaCungCap(); }
        }
        #endregion

        public async Task<ActionResult> CongNoHienTai(int IDMaster, int IDNhaCungCap, DateTime NgayHienTai)
        {
            aModel db = new aModel();
            try
            {
                IEnumerable<eCongNoNhaCungCap> lstCongNo = await db.eCongNoNhaCungCap.Where(x => x.IDNhaCungCap == IDNhaCungCap).ToListAsync();
                lstCongNo = lstCongNo.Where(x => x.Ngay.Date <= NgayHienTai.Date);

                eCongNoNhaCungCap congNo = lstCongNo.FirstOrDefault(x => x.IDMaster == IDMaster) ?? new eCongNoNhaCungCap();
                congNo.ConLai = lstCongNo.Where(x => x.IDMaster != IDMaster).ToList().Sum(x => x.ConLai);
                return Ok(congNo);
            }
            catch { return BadRequest(new eCongNoNhaCungCap()); }
        }
    }
}