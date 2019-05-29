using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SResponse
{
    public class createACard
    {
        public string resultCode { get; set; }
        public string resultMessage { get; set; }
        public string patCardType { get; set; }
        public string patCardNo { get; set; }
    }
}
