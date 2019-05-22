using SelfServiceMachine.Entity.SlefServiceModels;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SelfServiceMachine.Models.Response
{
    public class getRegDoctors
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        [XmlArray("noface"), XmlArrayItem("item")]
        public List<rDoctorItem> item { get; set; }
    }
}
