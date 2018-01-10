using EntityModel.DataModel;
using Server.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Server.BLL
{
    public class clsTinhThanh : clsFunction<eTinhThanh>
    {
        #region Contructor
        protected clsTinhThanh() { }
        public new static clsTinhThanh Instance
        {
            get { return new clsTinhThanh(); }
        }
        #endregion

        public async Task<IList<eTinhThanh>> DanhSach63TinhThanh()
        {
            aModel db = new aModel();
            try
            {
                IList<eTinhThanh> lstResult = await db.eTinhThanh.Where(x => x.IDLoai >= 1 && x.IDLoai <= 2).ToListAsync();
                return lstResult;
            }
            catch { return new List<eTinhThanh>(); }
        }

        public IList<eTinhThanh> DanhSachTinhThanh()
        {
            aModel db = new aModel();
            try
            {
                IList<eTinhThanh> lstResult = db.eTinhThanh.ToList();
                return lstResult;
            }
            catch { return new List<eTinhThanh>(); }
        }
    }
}