using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SRequest
{
    public class ComplementDeposit
    {
        public string branchCode { get; set; }
        public string beginDate { get; set; }
        public string endDate { get; set; }
    }
}
