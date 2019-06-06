namespace SelfServiceMachine.Entity.SRequest
{
    public class getMZFeeList
    {
        /// <summary>
        /// 医院代码
        /// </summary>
        public string branchCode { get; set; }
        /// <summary>
        /// 诊疗卡类型
        /// </summary>
        public int patCardType { get; set; }
        /// <summary>
        /// 诊疗卡号
        /// </summary>
        public string patCardNo { get; set; }
        /// <summary>
        /// 调用来源
        /// </summary>
        public string callSource { get; set; }
    }
}
