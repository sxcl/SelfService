﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfServiceMachine.Models.Response
{
    public class orderCurReg
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        public string hisOrdNum { get; set; }
        public string SSInfo { get; set; }
        public string regFee { get; set; }
        public string treatFee { get; set; }
        public string desc { get; set; }
    }
}
