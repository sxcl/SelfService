namespace SelfServiceMachine.Entity.SRequest
{
    public class cardDeposit
    {
        /// <summary>
        /// 医院代码
        /// </summary>
        public string branchCode { get; set; }
        /// <summary>
        /// 充值卡号
        /// </summary>
        public string czkh { get; set; }
        /// <summary>
        /// 充值人身份证号
        /// </summary>
        public string czrsfzh { get; set; }
        /// <summary>
        /// 充值人就诊卡号
        /// </summary>
        public string czrjzkhr { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        public string czje { get; set; }
        /// <summary>
        /// 充值平台订单号
        /// </summary>
        public string czdh { get; set; }
        /// <summary>
        /// 充值第三方订单号
        /// </summary>
        public string czdsfdh { get; set; }
        /// <summary>
        /// 充值人姓名
        /// </summary>
        public string xm { get; set; }
        /// <summary>
        /// 充值方式
        /// </summary>
        public string type { get; set; }
    }
}
