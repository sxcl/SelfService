using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SRequest
{
    public class GetDepositList
    {
        public string branchCode { get; set; }
        public string patientID { get; set; }
        public string admissionNo { get; set; }
        public string inTime { get; set; }
        public string payMode { get; set; }
        public string beginDate { get; set; }
        public string endDate { get; set; }
        public string psOrdNum { get; set; }
    }
}
