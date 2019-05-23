using System.Collections.Generic;
using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SlefServiceModels
{
    public class RegisteredTrial
    {
        public string akc190 { get; set; }
        public string aaz500 { get; set; }
        public string alc005 { get; set; }
        public string aka130 { get; set; }
        public string akf001 { get; set; }
        public string bkc368 { get; set; }
        public string aka120 { get; set; }
        public string akc188 { get; set; }
        public string akc189 { get; set; }
        public string akc264 { get; set; }
        public int listsize { get; set; }
        [XmlArray("noface"),XmlArrayItem("input")]
        public List<Trial> inputlist { get; set; }
    }

    public class Trial
    {
        public string aae072 { get; set; }
        public string bkf500 { get; set; }
        public string ake001 { get; set; }
        public string ake005 { get; set; }
        public string ake006 { get; set; }
        public string aae019 { get; set; }
    }
}
