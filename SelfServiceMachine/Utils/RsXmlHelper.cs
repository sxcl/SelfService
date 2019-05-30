using SelfServiceMachine.Common;
using SelfServiceMachine.Models.Response;

namespace SelfServiceMachine.Utils
{
    /// <summary>
    /// 默认XML格式
    /// </summary>
    public class RsXmlHelper
    {
        /// <summary>
        /// 只返回状态码和消息
        /// </summary>
        /// <param name="resCode"></param>
        /// <param name="resResult"></param>
        /// <returns></returns>
        public static string ResXml(int resCode, string resResult)
        {
            return XMLHelper.XmlSerialize(new response<rsBaseModel>()
            {
                model = new rsBaseModel()
                {
                    resultCode = resCode,
                    resultMessage = resResult
                }
            });
        }

        /// <summary>
        /// 只返回状态码和消息
        /// </summary>
        /// <param name="resCode"></param>
        /// <param name="resResult"></param>
        /// <returns></returns>
        public static string ResXml(string resCode, string resResult)
        {
            return XMLHelper.XmlSerialize(new response<rsBaseModelP>()
            {
                model = new rsBaseModelP()
                {
                    resultCode = resCode,
                    resultMessage = resResult
                }
            });
        }
    }
}
