using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SRequest
{
    [XmlRoot("Request")]
    public class getBillInfos
    {
        public string branchCode { get; set; }
        public string billDate { get; set; }
        public int payMode { get; set; }
        public int pageNo { get; set; }
        public int pageNumber { get; set; }
    }
}
