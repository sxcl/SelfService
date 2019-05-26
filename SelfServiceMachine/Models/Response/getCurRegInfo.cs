﻿using SelfServiceMachine.Entity.SlefServiceModels;
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
        [XmlArray("noface"), XmlArrayItem("item")]
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