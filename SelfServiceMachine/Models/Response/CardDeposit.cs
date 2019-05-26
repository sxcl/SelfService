using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SelfServiceMachine.Models.Response
{
    [XmlRoot("Response")]
    public class CardDeposit
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        public string czzh { get; set; }
        public string czye { get; set; }
        public string czhzhye { get; set; }
    }
}
