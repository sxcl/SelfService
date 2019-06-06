using System;

namespace SelfServiceMachine.Entity.SResponse
{
    public class getMZInsurance
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        public int mzFeeId { get; set; }
        public string mzBillId { get; set; }
        public string SSFeeNo { get; set; }
        public string SSBillNumber { get; set; }
        public string cancelSerialNo { get; set; }
        public string cancelBillNo { get; set; }
        public DateTime time { get; set; }
        public string recipeCount { get; set; }
        public string mzCategory { get; set; }
        public string specificCategory { get; set; }
        public string diagnosis { get; set; }
        public string diagnosisDetail { get; set; }
        public string deptCode { get; set; }
        public string deptName { get; set; }
        public string doctorCode { get; set; }
        public string doctorName { get; set; }
        public string doctorTelephone { get; set; }
        public string payType { get; set; }
        public string payAmount { get; set; }
        public string insuranceAmout { get; set; }
        public string accountAmount { get; set; }
        public string medicareAmount { get; set; }
        public string insuranceAmount { get; set; }
        public string totalAmout { get; set; }
        public string SSInfoNew { get; set; }
        public string SSSerNum { get; set; }
    }
}
