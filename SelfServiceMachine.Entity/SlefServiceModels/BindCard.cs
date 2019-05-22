using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SlefServiceModels
{
    public class BindCard
    {
        public string branchCode { get; set; }
        public string patCardNo { get; set; }
        public string PatId { get; set; }
        public string PatName { get; set; }
        public string bindType { get; set; }
    }
}
