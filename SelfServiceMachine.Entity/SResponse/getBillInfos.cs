using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SResponse
{
    [XmlRoot("Response")]
    public class getBillInfos
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        public int pageNo { get; set; }
        public int hasNextPage { get; set; }
    }

    public class BillInfoItem
    {
        public string agtOrdNum { get; set; }
        public string hisOrdNum { get; set; }
        public string hisJrnNum { get; set; }
        public string orderType { get; set; }
        public string payMode { get; set; }
        public string payType { get; set; }
        public string feeType { get; set; }
    }
}
