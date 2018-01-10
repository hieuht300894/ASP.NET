using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class Detail
    {
        private static Int32 _keyID = 0;
        public static Int32 _KeyID { get { return _keyID--; } }

        public Int32 KeyID { get; set; } = _KeyID;
        public String GhiChu { get; set; } = string.Empty;
        public Int32 TrangThai { get; set; } = 1;
        public Boolean MacDinh { get; set; }
    }
}
