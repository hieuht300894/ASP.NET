using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Model
{
    public class UserInfo
    {
        public xPersonnel xPersonnel { get; set; } = new xPersonnel();
        public xAccount xAccount { get; set; } = new xAccount();
    }

}
