using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SResponse
{
    public class createACard
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        public int patCardType { get; set; }
        public string patCardNo { get; set; }
    }
}
