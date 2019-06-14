using System.Collections.Generic;
using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SResponse
{
    [XmlRoot("Response")]
    public class ComplementDeposit
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        [XmlElement("item")]
        public List<ComplementDepositItem> item { get; set; }
    }

    public class ComplementDepositItem
    {
        public string patientID { get; set; }
        public string admissionNo { get; set; }
        public string inTime { get; set; }
        public string patName { get; set; }
        public string patCardType { get; set; }
        public string patCardNo { get; set; }
        public string balance { get; set; }
        public string inDate { get; set; }
    }
}
