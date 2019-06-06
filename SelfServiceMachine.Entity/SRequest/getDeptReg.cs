using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SRequest
{
    public class getDeptReg
    {
        /// <summary>
        /// 号源开始日期
        /// </summary>
        public string beginDate { get; set; }
        /// <summary>
        /// 号源结束日期
        /// </summary>
        public string endDate { get; set; }
        /// <summary>
        /// 医院代码
        /// </summary>
        public string branchCode { get; set; }
        /// <summary>
        /// 科室代码
        /// </summary>
        public string deptCode { get; set; }
    }
}
