using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfServiceMachine.Models.Response
{
    /// <summary>
    /// 患者建档
    /// </summary>
    public class createACard
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        public int patCardType { get; set; }
        public string patCardNo { get; set; }
    }
}
