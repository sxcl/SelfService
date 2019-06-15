using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SResponse
{
    public class getPayFeeDetail
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        [XmlElement("item")]
        public List<PayFeeDetailItem> item { get; set; }
    }

    public class PayFeeDetailItem
    {

        public string itemTime { get; set; }
        public string recipeNo { get; set; }
        public string itemName { get; set; }
        public string itemUnit { get; set; }
        public string itemId { get; set; }
        public int itemCount { get; set; }
        public decimal itemPrice { get; set; }
        public decimal itemTotalFee { get; set; }
        public string deptCode { get; set; }
        public string doctorCode { get; set; }
    }
}
