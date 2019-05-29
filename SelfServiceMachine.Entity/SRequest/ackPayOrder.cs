using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SRequest
{
    public class ackPayOrder
    {
        public string branchCode { get; set; }
        public string mzFeeIdList { get; set; }
        public string payAmout { get; set; }
        public string totalAmout { get; set; }
        public string psOrdNum { get; set; }
        public string agtOrdNum { get; set; }
        public string agtCode { get; set; }
        public string payMode { get; set; }
        public string payTime { get; set; }
        public string ybjmc { get; set; }
        public string mzlsh { get; set; }
        public string djh { get; set; }
        public string xjhj { get; set; }
        public string jzhj { get; set; }
        public string payType { get; set; }
        public string recipeNo { get; set; }
        public string SSBillNumber { get; set; }
        public string SSItems { get; set; }
    }
}
