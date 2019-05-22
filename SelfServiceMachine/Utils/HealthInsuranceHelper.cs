using SSCARDDRIVEROCXLib;
using System;

namespace SelfServiceMachine.Utils
{
    public class HealthInsuranceHelper
    {
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

        /// <summary>
        /// 获取交易验证码和版本号（无卡）
        /// </summary>
        /// <param name="inParams">执行本函数时交易信息，包括：交易类型|交易流水号|医药机构编码|</param>
        /// <returns></returns>
        public static string GetVcode(string inParams)
        {
            if (!string.IsNullOrEmpty(inParams))
            {
                string outResult = "";
                try
                {
                    SSCARD szCard = new SSCARD();
                    var result = szCard.iVerifyCode(inParams);
                    if (result.ToString().Trim().Equals("0"))
                    {
                        outResult = szCard.pOutInfo;
                    }
                    else
                    {
                        outResult = result.ToString();
                    }
                }
                catch (Exception error)
                {
                    outResult = $"获取验证码失败！{error}";
                    throw;
                }
                return outResult;
            }
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
