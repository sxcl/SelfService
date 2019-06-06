using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SRequest
{
    public class getMZFeeDetail
    {
        /// <summary>
        /// 医院代码
        /// </summary>
        public string branchCode { get; set; }
        /// <summary>
        /// 缴费项唯一标识（就诊序号）
        /// </summary>
        public string mzFeeId { get; set; }
        /// <summary>
        /// 处方号码
        /// </summary>
        public string recipeNo { get; set; }
    }
}
