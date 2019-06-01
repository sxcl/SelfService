using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SResponse
{
    public class orderCurReg
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        public string hisOrdNum { get; set; }
        public object SSInfo { get; set; }
        public string regFee { get; set; }
        public string treatFee { get; set; }
        public string desc { get; set; }
    }
}
