using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SlefServiceModels
{
    public class GDeptItem
    {
        public string branchCode { get; set; }
        public string branchName { get; set; }
        public string deptCode { get; set; }
        public string deptName { get; set; }
        public string deptTelephone { get; set; }
        public string deptDescription { get; set; }
        public string deptLocation { get; set; }
        public string parentDeptCode { get; set; }
    }
}
