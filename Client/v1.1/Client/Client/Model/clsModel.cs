using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Model
{
    class clsModel
    {

    }

    public class ControlObject
    {
        public Control ctrMain { get; set; }
        public RepositoryItem repoMain { get; set; }
    }

    public class Loai
    {
        public int KeyID { get; set; }
        public string Ten { get; set; }
        public static List<Loai> LoaiDonViHanhChinh()
        {
            List<Loai> lstResult = new List<Loai>();
            lstResult.Add(new Loai() { KeyID = 1, Ten = "Thành phố trực thuộc TW" });
            lstResult.Add(new Loai() { KeyID = 2, Ten = "Tỉnh" });
            lstResult.Add(new Loai() { KeyID = 3, Ten = "Quận" });
            lstResult.Add(new Loai() { KeyID = 4, Ten = "Huyện" });
            lstResult.Add(new Loai() { KeyID = 5, Ten = "Thành phố trực thuộc tỉnh" });
            lstResult.Add(new Loai() { KeyID = 6, Ten = "Thị xã" });
            lstResult.Add(new Loai() { KeyID = 7, Ten = "Phường" });
            lstResult.Add(new Loai() { KeyID = 8, Ten = "Thị trấn" });
            lstResult.Add(new Loai() { KeyID = 9, Ten = "Xã" });
            return lstResult;
        }
        public static List<Loai> LoaiNhomKhachHang()
        {
            List<Loai> lstResult = new List<Loai>();
            lstResult.Add(new Loai() { KeyID = 1, Ten = "Khách lẻ" });
            lstResult.Add(new Loai() { KeyID = 2, Ten = "Khách sỉ" });
            lstResult.Add(new Loai() { KeyID = 3, Ten = "Khách VIP" });
            return lstResult;
        }
        public static List<Loai> LoaiGioiTinh()
        {
            List<Loai> lstResult = new List<Loai>();
            lstResult.Add(new Loai() { KeyID = 1, Ten = "Nam" });
            lstResult.Add(new Loai() { KeyID = 2, Ten = "Nữ" });
            return lstResult;
        }
    }
}
