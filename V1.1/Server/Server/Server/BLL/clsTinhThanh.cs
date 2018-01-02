using EntityModel.DataModel;
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

        public List<eTinhThanh> DanhSach63TinhThanh()
        {
            try
            {
                db = new Model.aModel();
                List<eTinhThanh> lstResult = db.eTinhThanh.Where(x => x.IDLoai >= 1 && x.IDLoai <= 2).ToList();
                return lstResult;
            }
            catch { return new List<eTinhThanh>(); }
        }
    }
}