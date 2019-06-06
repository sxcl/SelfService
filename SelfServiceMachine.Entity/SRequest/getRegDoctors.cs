namespace SelfServiceMachine.Entity.SRequest
{
    public class getRegDoctors
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
        /// 医生代码
        /// </summary>
        public string doctorCode { get; set; }
    }
}
