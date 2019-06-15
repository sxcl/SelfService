using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SResponse
{
    public class getDeptReg
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        [XmlElement("item")]
        public List<DeptRegItem> item { get; set; }
    }

    public class DeptRegItem
    {
        public string scheduleDate { get; set; }
        public int totalNum { get; set; }
        public int leftNum { get; set; }
    }
}
