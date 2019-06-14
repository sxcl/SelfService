using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SResponse
{
    [XmlRoot("Response")]
    public class payDeposit
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        public string hisOrdNum { get; set; }
        public string receiptNum { get; set; }
        public string barCode { get; set; }
        public string balance { get; set; }
    }
}
