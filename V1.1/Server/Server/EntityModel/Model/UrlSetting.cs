using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Model
{
    public class UrlSetting
    {
        public string Domain { get; set; } = string.Empty;
        public string Port { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
