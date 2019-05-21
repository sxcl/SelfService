using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SlefServiceModels
{
    public class GetDeptReg
    {
        public string beginDate { get; set; }
        public string endDate { get; set; }
        public string branchCode { get; set; }
        public string deptCode { get; set; }
    }
}
