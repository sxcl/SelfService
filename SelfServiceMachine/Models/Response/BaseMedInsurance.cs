namespace SelfServiceMachine.Models.Response
{
    /// <summary>
    /// 医保请求基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseMedInsurance<T> where T : class, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public string transTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string transType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string transReturnCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string transReturnMessage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string transVersion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string serialNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cardArea { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hospitalCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string operatorCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string operatorName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string operatorPass { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public T transBody { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string verifyCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string extendDeviceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string transChannel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string extendUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string extendSerialNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string caz055 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string aae501 { get; set; }
    }
}
