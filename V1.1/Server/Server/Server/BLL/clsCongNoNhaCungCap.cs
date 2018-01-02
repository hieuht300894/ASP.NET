using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

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

        public eCongNoNhaCungCap CongNoHienTai(int IDMaster, int IDNhaCungCap, DateTime NgayHienTai)
        {
            try
            {
                db = new Model.aModel();
                IEnumerable<eCongNoNhaCungCap> lstCongNo = db.eCongNoNhaCungCap.Where(x => x.IDNhaCungCap == IDNhaCungCap).ToList();
                lstCongNo = lstCongNo.Where(x => x.Ngay.Date <= NgayHienTai.Date);

                eCongNoNhaCungCap congNo = lstCongNo.FirstOrDefault(x => x.IDMaster == IDMaster) ?? new eCongNoNhaCungCap();
                congNo.ConLai = lstCongNo.Where(x => x.IDMaster != IDMaster).ToList().Sum(x => x.ConLai);
                return congNo;
            }
            catch { return new eCongNoNhaCungCap(); }
        }
    }
}