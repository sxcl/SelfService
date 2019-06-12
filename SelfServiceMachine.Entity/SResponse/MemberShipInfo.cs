using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SResponse
{
    [XmlRoot("Response")]
    public class MemberShipInfo
    {
        [XmlElement("resultCode")]
        public int ResultCode { get; set; }
        [XmlElement("resultMessage")]
        public string ResultMessage { get; set; }
        [XmlElement("idcardh")]
        public string Idcardh { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("sex")]
        public string Sex { get; set; }
        [XmlElement("ye")]
        public decimal Ye { get; set; }
    }
}
