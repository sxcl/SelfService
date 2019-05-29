using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SResponse
{
    public class getMZFeeList
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        [XmlArray("noface"), XmlArrayItem("item")]
        public List<MZFeeList> item { get; set; }
    }

    public class MZFeeList
    {
        public string mzFeeId { get; set; }
        public DateTime time { get; set; }
        public string doctorCode { get; set; }
        public string doctorName { get; set; }
        public string deptName { get; set; }
        public string deptCode { get; set; }
        public string MZ_TYPE { get; set; }
        public decimal payAmout { get; set; }
        public decimal medicareAmout { get; set; }
        public decimal totalAmout { get; set; }
        public string recipeNo { get; set; }
        public string Attachment { get; set; }
    }
}
