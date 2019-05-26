namespace SelfServiceMachine.Entity.SRequest
{
    public class getMZInsurance
    {
        public string branchCode { get; set; }
        public int patCardType { get; set; }
        public string patCardNo { get; set; }
        public int mzFeeId { get; set; }
        public string mzBillId { get; set; }
        public string deptCode { get; set; }
        public string doctorCode { get; set; }
    }
}
