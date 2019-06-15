using System.Collections.Generic;
using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SResponse
{
    public class getCurDocTime
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        [XmlElement("item")]
        public List<cDocTimeItem> item { get; set; }
    }

    public class cDocTimeItem
    {
        public string beginTime { get; set; }
        public string endTime { get; set; }
        public string regFee { get; set; }
        public string treatFee { get; set; }
        public int workStatus { get; set; }
        public int totalNum { get; set; }
        public int leftNum { get; set; }
    }
}
