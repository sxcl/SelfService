using SelfServiceMachine.Entity.SlefServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SelfServiceMachine.Models.Response
{
    public class getMZFeeDetail
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        [XmlArray("noface"), XmlArrayItem("item")]
        public List<MZFeeDetail> item { get; set; }
    }
}
