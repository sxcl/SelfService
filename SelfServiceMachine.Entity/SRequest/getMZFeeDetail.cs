﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SRequest
{
    public class getMZFeeDetail
    {
        public string branchCode { get; set; }
        public string mzFeeId { get; set; }
        public string recipeNo { get; set; }
    }
}
