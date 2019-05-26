using System.Xml.Serialization;

namespace SelfServiceMachine.Models.Request
{
    /// <summary>
    /// 请求体公共类（正确实例）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [XmlRoot("request")]
    public class request<T> where T : class, new()
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("params")]
        public T model { get; set; }
    }
}
