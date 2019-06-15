using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SResponse
{
    public class getCurRegInfo
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        [XmlElement("collections")]
        public List<AdogCurRegItem> item { get; set; }
    }

    public class AdogCurRegItem
    {
        public string category { get; set; }
        public string doctorCode { get; set; }
        public string doctorName { get; set; }
        public string doctorTitle { get; set; }
        public string doctorIntrodution { get; set; }
        public string doctorSex { get; set; }
        public string doctorBirth { get; set; }
        public string doctorSkill { get; set; }
        public string picture { get; set; }
        public int regtid { get; set; }
        [ XmlElement("item")]
        public List<TimeItems> item { get; set; }
    }

    public class TimeItems
    {
        public int timeFlag { get; set; }
        public int hasDetailTime { get; set; }
        public string beginTime { get; set; }
        public string endTime { get; set; }
        public int workStatus { get; set; }
        public int totalNum { get; set; }
        public int leftNum { get; set; }
        public string regFee { get; set; }
        public string treatFee { get; set; }
        public int scheduleNo { get; set; }
    }
}
