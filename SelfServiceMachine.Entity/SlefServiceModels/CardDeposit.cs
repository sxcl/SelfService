using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SlefServiceModels
{
    [XmlRoot("request")]
    public class CardDeposit
    {
        public string branchCode { get; set; }
        public string czkh { get; set; }
        public string czrsfzh { get; set; }
        public string czrjzkhr { get; set; }
        public string czje { get; set; }
        public string czdh { get; set; }
        public string czdsfdh { get; set; }
        public string xm { get; set; }
        public string type { get; set; }
    }
}
