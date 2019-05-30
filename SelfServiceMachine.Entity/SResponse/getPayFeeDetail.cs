﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SResponse
{
    public class getPayFeeDetail
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        [XmlArray("noface"), XmlArrayItem("item")]
        public List<PayFeeDetailItem> item { get; set; }
    }

    public class PayFeeDetailItem
    {
        public DateTime itemTime { get; set; }
        public string recipeNo { get; set; }
        public string itemName { get; set; }
        public string itemUnit { get; set; }
        public string itemId { get; set; }
        public string itemCount { get; set; }
        public string itemPrice { get; set; }
        public string itemTotalFee { get; set; }
        public string deptCode { get; set; }
        public string doctorCode { get; set; }
    }
}