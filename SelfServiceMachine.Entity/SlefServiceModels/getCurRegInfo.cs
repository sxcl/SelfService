using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SlefServiceModels
{
    public class getCurRegInfo
    {
        public string branchCode { get; set; }
        public string deptCode { get; set; }
        public string doctorCode { get; set; }
        public string beginDate { get; set; }
        public string endDate { get; set; }
    }
}
