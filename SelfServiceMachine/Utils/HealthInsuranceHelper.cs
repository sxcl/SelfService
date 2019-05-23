using System;

namespace SelfServiceMachine.Utils
{
    /// <summary>
    /// 医保帮助类
    /// </summary>
    public class HealthInsuranceHelper
    {
        /// <summary>
        /// 试算
        /// </summary>
        /// <param name="transType"></param>
        /// <param name="transVersion"></param>
        /// <param name="verifyCode"></param>
        /// <param name="serNum"></param>
        /// <param name="transBody"></param>
        /// <returns></returns>
        public static string Trial(string transType, string transVersion, string verifyCode, string serNum, object transBody)
        {
            var serialNumber = "HZS10" + DateTime.Now.ToString("yyyyMMdd") + serNum;
            HealthMessage healthMessage = new HealthMessage()
            {
                transTime = DateTime.Now.ToString("yyyyMMddHHmmss:fff"),
                transType = transType,
                transReturnCode = null,
                transReturnMessage = null,
                transVersion = transVersion,
                serialNumber = serialNumber,
                cardArea = "440300",
                hospitalCode = "HZS10",
                operatorCode = "jeff",
                operatorName = "jeff",
                operatorPass = null,
                transBody = transBody,
                transChannel = "10",
                verifyCode = verifyCode,
                extendDeviceId = null,
                extendUserId = null,
                extendSerialNumber = null
            };
            return null;
        }
    }

    class HealthMessage
    {
        public string transTime { get; set; }
        public string transType { get; set; }
        public string transReturnCode { get; set; }
        public string transReturnMessage { get; set; }
        public string transVersion { get; set; }
        public string serialNumber { get; set; }
        public string cardArea { get; set; }
        public string hospitalCode { get; set; }
        public string operatorCode { get; set; }
        public string operatorName { get; set; }
        public string operatorPass { get; set; }
        public object transBody { get; set; }
        public string transChannel { get; set; }
        public string verifyCode { get; set; }
        public string extendDeviceId { get; set; }
        public string extendUserId { get; set; }
        public string extendSerialNumber { get; set; }
    }
}
