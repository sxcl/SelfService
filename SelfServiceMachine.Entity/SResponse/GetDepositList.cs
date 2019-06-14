using System.Collections.Generic;
using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SResponse
{
    [XmlRoot("Reponse")]
    public class GetDepositList
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        [XmlElement("item")]
        public List<DepositItem> item { get; set; }
    }

    public class DepositItem
    {
        public string branchCode { get; set; }
        public string branchName { get; set; }
        public string hisOrdNum { get; set; }
        public string psOrdNum { get; set; }
        public string agtOrdNum { get; set; }
        public string agtCode { get; set; }
        public string payMode { get; set; }
        public string payAmout { get; set; }
        public string payTime { get; set; }
        public string payStatus { get; set; }
        public string balance { get; set; }
        public string sterilisation { get; set; }
        public string receiptNum { get; set; }
        public string hisMessage { get; set; }
    }
}
