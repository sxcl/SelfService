using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SlefServiceModels
{
    public class MZFeeList
    {
        public int mzFeeId { get; set; }
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
