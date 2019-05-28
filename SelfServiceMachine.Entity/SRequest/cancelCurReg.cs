using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SRequest
{
    public class cancelCurReg
    {
        public string branchCode { get; set; }
        public string hisOrdNum { get; set; }
        public string psOrdNum { get; set; }
        public string cancelMode { get; set; }
        public string cancelTime { get; set; }
        public string cancelReason { get; set; }
    }
}
