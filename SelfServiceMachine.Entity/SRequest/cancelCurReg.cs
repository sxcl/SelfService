using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SRequest
{
    public class cancelCurReg
    {
        /// <summary>
        /// 医院代码
        /// </summary>
        public string branchCode { get; set; }
        /// <summary>
        /// 当班挂号流水号
        /// </summary>
        public string hisOrdNum { get; set; }
        /// <summary>
        /// 公众服务平台订单号
        /// </summary>
        public string psOrdNum { get; set; }
        /// <summary>
        /// 取消来源
        /// </summary>
        public string cancelMode { get; set; }
        /// <summary>
        /// 取消时间
        /// </summary>
        public string cancelTime { get; set; }
        /// <summary>
        /// 取消原因
        /// </summary>
        public string cancelReason { get; set; }
    }
}
