namespace SelfServiceMachine.Model
{
    /// <summary>
    /// 医保配置
    /// </summary>
    public class MedicalConfig
    {
        /// <summary>
        /// 医保接口地址
        /// </summary>
        public static string MedicalInsuranceAddress = "http://192.168.1.88:6666/szsi-portal/transData";
        /// <summary>
        /// 请求格式
        /// </summary>
        public static string ContentType = "application/json";
        /// <summary>
        /// 操作员编码
        /// </summary>
        public static string operatorCode = "xxk001";
        /// <summary>
        /// 操作员姓名
        /// </summary>
        public static string operatorName = "信息科";
        /// <summary>
        /// 操作员密码
        /// </summary>
        public static string operatorPwd = "123456";
        /// <summary>
        /// 医疗机构编码
        /// </summary>
        public static string medicareCode = "HZS10";
        /// <summary>
        /// 默认交易返回码
        /// </summary>
        public static string transReturnCode = "00000000";
        /// <summary>
        /// 默认交易版本号
        /// </summary>
        public static string transVersion = "V0.2";
        /// <summary>
        /// 发卡地行政区划代码(深圳：440300)
        /// </summary>
        public static string cardArea = "440300";
    }
}
