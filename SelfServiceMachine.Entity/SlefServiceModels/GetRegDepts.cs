using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SlefServiceModels
{
    public class GetRegDepts
    {
        public int branchCode { get; set; }
        public string parentDeptCode { get; set; }
    }
}
