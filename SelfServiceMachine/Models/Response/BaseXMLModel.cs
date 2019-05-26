using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SelfServiceMachine.Models.Response
{
    /// <summary>
    /// 基本返回值
    /// </summary>
    [XmlRoot("response")]
    public class BaseXMLModelResponse
    {
        [XmlElement("result")]
        public BaseXMLModel BaseXMLModel { get; set; }
    }

    public class BaseXMLModel
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int resultCode { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string resultMessage { get; set; }
    }
}
