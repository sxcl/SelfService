using System.Collections.Generic;
using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SResponse
{
    public class queryPatientHospital
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        [XmlElement("item")]
        public List<patienthosItem> items { get; set; }
    }

    public class patienthosItem
    {
        public string patientID { get; set; }
        public string admissionNo { get; set; }
        public string inDate { get; set; }
        public string patName { get; set; }
        public string deptName { get; set; }
        public string doctorName { get; set; }
    }
}
