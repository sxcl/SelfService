using System.Collections.Generic;
using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SResponse
{
    [XmlRoot("Response")]
    public class getBillInfos
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        public int pageNo { get; set; }
        public int hasNextPage { get; set; }
        [XmlElement("item")]
        public List<BillInfoItem> item { get; set; }
    }

    public class BillInfoItem
    {
        public string agtOrdNum { get; set; }
        public string psOrdNum { get; set; }
        public string orderType { get; set; }
        public string payMode { get; set; }
        public string payAmt { get; set; }
        public string payTime { get; set; }
        public string feeType { get; set; }
    }
}
