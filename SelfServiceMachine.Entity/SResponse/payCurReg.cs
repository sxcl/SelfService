using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SResponse
{
    public class payCurReg
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        public string receiptNum { get; set; }
        public string serialNum { get; set; }
        public string visitLocation { get; set; }
        public string barCode { get; set; }
        public string visitDesc { get; set; }
    }
}
