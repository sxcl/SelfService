namespace SelfServiceMachine.Entity.SRequest
{
    public class getPayFeeDetail
    {
        /// <summary>
        /// 医院代码
        /// </summary>
        public string branchCode { get; set; }
        /// <summary>
        /// 缴费的发票号码
        /// </summary>
        public string MzFeeId { get; set; }
    }
}
