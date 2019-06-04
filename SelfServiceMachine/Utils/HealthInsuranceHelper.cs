using SelfServiceMachine.Common;
using SelfServiceMachine.Model;
using System;
using System.Net;
using System.Text;

namespace SelfServiceMachine.Utils
{
    /// <summary>
    /// 医保帮助类
    /// </summary>
    public class HealthInsuranceHelper
    {
        /// <summary>
        /// 挂号试算
        /// </summary>
        /// <param name="transType"></param>
        /// <param name="transVersion"></param>
        /// <param name="verifyCode"></param>
        /// <param name="serNum"></param>
        /// <param name="transBody"></param>
        /// <returns></returns>
        public static T RegTrial<T>(string transType, string transVersion, string verifyCode, string serNum, object transBody)
        {
            var serialNumber = "HZS10" + DateTime.Now.ToString("yyyyMMdd") + serNum;
            HealthMessage healthMessage = new HealthMessage()
            {
                transTime = DateTime.Now.ToString("yyyyMMddHHmmss:fff"),
                transType = transType,
                transReturnCode = "",
                transReturnMessage = "",
                transVersion = transVersion,
                serialNumber = serialNumber,
                cardArea = "440300",
                hospitalCode = "HZS10",
                operatorCode = "jeff",
                operatorName = "松下乘凉",
                operatorPass = "123",
                transBody = transBody,
                transChannel = "10",
                verifyCode = verifyCode,
                extendDeviceId = "",
                extendUserId = "",
                extendSerialNumber = ""
            };

            var obj = PostData(JsonOperator.JsonSerialize(healthMessage));

            
            return JsonOperator.JsonDeserialize<T>(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string PostData(string entity)
        {
            WebClient webClient = new WebClient();
            byte[] postData;
            byte[] byRemoteInfo;
            string rtn = "";
            try
            {
                webClient.Headers.Add("Content-Type", MedicalConfig.ContentType);
                postData = Encoding.UTF8.GetBytes(entity);
                byRemoteInfo = webClient.UploadData(MedicalConfig.MedicalInsuranceAddress, "POST", postData);
                rtn = Encoding.UTF8.GetString(byRemoteInfo);
            }
            catch (Exception ex)
            {
                rtn = ex.ToString();
            }

            return rtn;
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
