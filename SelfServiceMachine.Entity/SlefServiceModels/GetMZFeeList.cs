using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SlefServiceModels
{
    [XmlRoot("request")]
    public class GetMZFeeList
    {
        public string branchCode { get; set; }
        public int patCardType { get; set; }
        public string patCardNo { get; set; }
        public string callSource { get; set; }
    }
}
