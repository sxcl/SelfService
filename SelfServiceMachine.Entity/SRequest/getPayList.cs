namespace SelfServiceMachine.Entity.SRequest
{
    public class getPayList
    {
        /// <summary>
        /// 医院代码
        /// </summary>
        public string branchCode { get; set; }
        /// <summary>
        /// 诊疗卡类型
        /// </summary>
        public string patCardType { get; set; }
        /// <summary>
        /// 诊疗卡号
        /// </summary>
        public string patCardNo { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public string payMode { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string beginDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string endDate { get; set; }
    }
}
