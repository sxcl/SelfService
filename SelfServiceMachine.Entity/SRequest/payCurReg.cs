using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SRequest
{
    public class payCurReg
    {
        public string branchCode { get; set; }
        public string hisOrdNum { get; set; }
        public string psOrdNum { get; set; }
        public string agtOrdNum { get; set; }
        public string agtCode { get; set; }
        public string payMode { get; set; }
        public string payMethod { get; set; }
        public string payAmout { get; set; }
        public string payTime { get; set; }
        public string SSSerialNo { get; set; }
        public string SSMoney { get; set; }
        [XmlArray("SSItems"), XmlArrayItem("Item")]
        public List<SSItems> item { get; set; }
    }

    public class SSItems
    {
        public string Zfxm { get; set; }
        public decimal? Je { get; set; }
    }
}
