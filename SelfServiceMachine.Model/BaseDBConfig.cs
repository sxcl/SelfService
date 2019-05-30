namespace SelfServiceMachine.Model
{
    public class BaseDBConfig
    {
        public static string ConnectionString = "Data Source=192.168.15.11;Initial Catalog=ZSHIS;Persist Security Info=True;User ID=sa;Password=sa";
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
        public static string operatorCode = "xxk";
        /// <summary>
        /// 操作员姓名
        /// </summary>
        public static string operatorName = "松下乘凉";
        /// <summary>
        /// 操作员密码
        /// </summary>
        public static string operatorPwd = "123";
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
        public static string transVersion = "V0.1";
        /// <summary>
        /// 发卡地行政区划代码(深圳：440300)
        /// </summary>
        public static string cardArea = "440300";
    }
}