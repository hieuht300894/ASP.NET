using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class ThongTinNguoiDung
    {
        public xNhanVien xPersonnel { get; set; } = new xNhanVien();
        public xTaiKhoan xAccount { get; set; } = new xTaiKhoan();
    }

}
