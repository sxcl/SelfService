using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SlefServiceModels
{
    public class cDocTimeItem
    {
        public string beginTime { get; set; }
        public string endTime { get; set; }
        public string regFee { get; set; }
        public string treatFee { get; set; }
        public int workStatus { get; set; }
        public int totalNum { get; set; }
        public int leftNum { get; set; }
    }
}
