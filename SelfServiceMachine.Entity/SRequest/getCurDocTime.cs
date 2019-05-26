using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SRequest
{
    public class getCurDocTime
    {
        public string branchCode { get; set; }
        public string deptCode { get; set; }
        public string doctorCode { get; set; }
        public string timeFlag { get; set; }
    }
}
