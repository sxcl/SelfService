﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SRequest
{
    public class getRegDepts
    {
        public int branchCode { get; set; }
        public string parentDeptCode { get; set; }
    }
}
