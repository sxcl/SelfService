using SelfServiceMachine.Entity.SlefServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SelfServiceMachine.Models.Response
{
    public class getCurRegInfo
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        [XmlArray("noface"), XmlArrayItem("collections")]
        public List<AdogCurRegItem> item { get; set; }
    }
}
