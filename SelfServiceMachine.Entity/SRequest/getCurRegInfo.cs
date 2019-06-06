namespace SelfServiceMachine.Entity.SRequest
{
    public class getCurRegInfo
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
        /// 开始时间
        /// </summary>
        public string beginDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string endDate { get; set; }
    }
}
