using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SRequest
{
    public class ackPayOrder
    {
        /// <summary>
        /// 医院代码
        /// </summary>
        public string branchCode { get; set; }
        /// <summary>
        /// 缴费项列表
        /// </summary>
        public string mzFeeIdList { get; set; }
        /// <summary>
        /// 付款金额
        /// </summary>
        public string payAmout { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        public string totalAmout { get; set; }
        /// <summary>
        /// 公众服务平台订单号
        /// </summary>
        public string psOrdNum { get; set; }
        /// <summary>
        /// 收单机构流水号
        /// </summary>
        public string agtOrdNum { get; set; }
        /// <summary>
        /// 收单机构代码
        /// </summary>
        public string agtCode { get; set; }
        /// <summary>
        /// 付款方式
        /// </summary>
        public string payMode { get; set; }
        /// <summary>
        /// 付款时间
        /// </summary>
        public string payTime { get; set; }
        /// <summary>
        /// 医保串
        /// </summary>
        public string ybjmc { get; set; }
        /// <summary>
        /// 医保门诊流水号
        /// </summary>
        public string mzlsh { get; set; }
        /// <summary>
        /// 单据号
        /// </summary>
        public string djh { get; set; }
        /// <summary>
        /// 现金合计
        /// </summary>
        public string xjhj { get; set; }
        /// <summary>
        /// 记账合计
        /// </summary>
        public string jzhj { get; set; }
        /// <summary>
        /// 缴费类型
        /// </summary>
        public string payType { get; set; }
        /// <summary>
        /// 处方号
        /// </summary>
        public string recipeNo { get; set; }
        /// <summary>
        /// 医保患者性质
        /// </summary>
        public string SSBillNumber { get; set; }
        /// <summary>
        /// 医保结算串
        /// </summary>
        public string SSItems { get; set; }
    }
}
