using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SRequest
{
    public class getClinicalTrial
    {
        public int patCardType { get; set; }
        public string patCardNo { get; set; }
        public int workId { get; set; }
    }
}
