using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SRequest
{
    public class payDeposit
    {
        public string branchCode { get; set; }
        public string patientID { get; set; }
        public string admissionNo { get; set; }
        public string inTime { get; set; }
        public string psOrdNum { get; set; }
        public string agtOrdNum { get; set; }
        public string agtCode { get; set; }
        public string payMode { get; set; }
        public string payAmout { get; set; }
        public string payTime { get; set; }
        public string reprePatCardType { get; set; }
        public string reprePatCardNo { get; set; }
        public string reprePatName { get; set; }
    }
}
