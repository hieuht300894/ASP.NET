using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Model
{
    public class UserSetting
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsRemember { get; set; }
        public string Domain { get; set; } = string.Empty;
        public string Port { get; set; } = string.Empty;
        public string Template { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
