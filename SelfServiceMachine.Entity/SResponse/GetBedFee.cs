using System.Collections.Generic;
using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SResponse
{
    [XmlRoot("Response")]
    public class GetBedFee
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        public decimal? totalFee { get; set; }
        public decimal? medicareFee { get; set; }
        public decimal? selfFee { get; set; }
        public decimal? payedFee { get; set; }
        public decimal? leftPreFee { get; set; }
        public decimal? leftFee { get; set; }
        [XmlElement("item")]
        public List<BedFeeItem> items { get; set; }
    }

    public class BedFeeItem
    {
        public string costType { get; set; }
        public string costName { get; set; }
        public decimal? costAmout { get; set; }
    }
}
