namespace SelfServiceMachine.Entity.SRequest
{
    public class getMZPatient
    {
        /// <summary>
        /// 医院代码
        /// </summary>
        public string branchCode { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string patName { get; set; }
        /// <summary>
        /// 诊疗卡类型
        /// </summary>
        public int patCardType { get; set; }
        /// <summary>
        /// 诊疗卡号码
        /// </summary>
        public string patCardNo { get; set; }
    }
}
