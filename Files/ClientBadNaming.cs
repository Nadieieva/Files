using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Files
{
    [XmlRoot("cl")]
    public class ClientBadNaming
    {
        public string fn { get; set; }
        public string ln { get; set; }
        public string mn { get; set; }
        public string p { get; set; }
        public string e { get; set; }
        public int bd { get; set; }
        public int bm { get; set; }
        public int by { get; set; }
        public string hl1 { get; set; }
        public string hc { get; set; }
        public string hs { get; set; }
        public int hz { get; set; }
        public string wl1 { get; set; }
        public string wc { get; set; }
        public string ws { get; set; }
        public int wz { get; set; }
    }
}
