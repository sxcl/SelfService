using System;

namespace SelfServiceMachine.Entity.SlefServiceModels
{
    public class orderCurReg
    {
        public string psOrdNum { get; set; }
        public string branchCode { get; set; }
        public string deptCode { get; set; }
        public string doctorCode { get; set; }
        public int timeFlag { get; set; }
        public string beginTime { get; set; }
        public string endTime { get; set; }
        public int? workId { get; set; }
        public string ghhj { get; set; }
        public string regFee { get; set; }
        public decimal? treatFee { get; set; }
        public decimal? regType { get; set; }
        public int patCardType { get; set; }
        public string patCardNo { get; set; }
        public int orderMode { get; set; }
        public DateTime orderTime { get; set; }
        public string orderNo { get; set; }
        public string SSCblx { get; set; }
        public string SSCardNumber { get; set; }
        public string SSComputerNumber { get; set; }
        public string SSCodeId { get; set; }
        public string SShylx { get; set; }
        public string SSPwd { get; set; }
        public string transVersion { get; set; }
        public string verifyCode { get; set; }
    }
}
