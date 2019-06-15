using System.Collections.Generic;
using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SResponse
{
    public class getPayList
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        [XmlElement("item")]
        public List<getPayItem> item { get; set; }
    }

    public class getPayItem
    {
        public string branchCode { get; set; }
        public string branchName { get; set; }
        public string hisOrdNum { get; set; }
        public string mzFeeIdList { get; set; }
        public string payTime { get; set; }
        public string payStatus { get; set; }
        public string itemType { get; set; }
        public string ItemTotal { get; set; }
        public string payType { get; set; }
        public string payAmout { get; set; }
        public string totalAmout { get; set; }
        public string hisMessage { get; set; }
        public string socialInsurance { get; set; }
        public string restsAmount { get; set; }
        public string deptName { get; set; }
    }
}
