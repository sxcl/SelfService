using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SRequest
{
    [XmlRoot("Request")]
    public class GetBedFee
    {
        public string branchCode { get; set; }
        public string patientID { get; set; }
        public string admissionNo { get; set; }
        public string inTime { get; set; }
    }
}
