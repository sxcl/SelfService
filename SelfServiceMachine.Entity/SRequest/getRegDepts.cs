using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SRequest
{
    public class getRegDepts
    {
        /// <summary>
        /// 医院代码
        /// </summary>
        public string branchCode { get; set; }
        /// <summary>
        /// 父科室代码
        /// </summary>
        public string parentDeptCode { get; set; }
    }
}
