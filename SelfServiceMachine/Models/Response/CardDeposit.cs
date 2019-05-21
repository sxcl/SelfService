using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfServiceMachine.Models.Response
{
    public class CardDeposit
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        public string czzh { get; set; }
        public string czye { get; set; }
        public string czhzhye { get; set; }
    }
}
