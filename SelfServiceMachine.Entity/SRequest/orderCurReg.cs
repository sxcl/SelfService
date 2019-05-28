using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SRequest
{
    public class orderCurReg
    {
        public string psOrdNum { get; set; }
        public string branchCode { get; set; }
        public string deptCode { get; set; }
        public string doctorCode { get; set; }
        public string timeFlag { get; set; }
        public string beginTime { get; set; }
        public string endTime { get; set; }
        public string workId { get; set; }
        public string ghhj { get; set; }
        public string regFee { get; set; }
        public string treatFee { get; set; }
        public string regType { get; set; }
        public string patCardType { get; set; }
        public string patCardNo { get; set; }
        public string orderMode { get; set; }
        public string orderTime { get; set; }
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
