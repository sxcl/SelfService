using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SRequest
{
    [XmlRoot("Request")]
    public class getBillInfos
    {
        public string branchCode { get; set; }
        public string billDate { get; set; }
        public string payMode { get; set; }
        public string pageNo { get; set; }
        public string pageNumber { get; set; }
    }
}
