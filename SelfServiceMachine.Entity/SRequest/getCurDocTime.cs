using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SRequest
{
    public class getCurDocTime
    {
        /// <summary>
        /// 医院代码
        /// </summary>
        public string branchCode { get; set; }
        /// <summary>
        /// 科室代码
        /// </summary>
        public string deptCode { get; set; }
        /// <summary>
        /// 医生/专科代码
        /// </summary>
        public string doctorCode { get; set; }
        /// <summary>
        /// 时段
        /// </summary>
        public string timeFlag { get; set; }
    }
}
