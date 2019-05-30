using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SRequest
{
    public class getClinicalTrial
    {
        public string workId { get; set; }
        public string patCardType { get; set; }
        public string patCardNo { get; set; }
        public string ghhj { get; set; }
        public string regFee { get; set; }
        public string orderTime { get; set; }
        public string SSCardNumber { get; set; }
        public string beginTime { get; set; }
        public string timeFlag { get; set; }
        public string endTime { get; set; }
        public string doctorCode { get; set; }
        public string deptCode { get; set; }
    }
}
