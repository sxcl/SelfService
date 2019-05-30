using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SResponse
{
    public class ackPayOrder
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        public string hisOrdNum { get; set; }
        public string receiptNum { get; set; }
        public string barCode { get; set; }
        public string hisMessage { get; set; }
    }
}
