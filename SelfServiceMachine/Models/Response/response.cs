using System.Xml.Serialization;

namespace SelfServiceMachine.Models.Response
{
    /// <summary>
    /// 返回体公共类（正确实例）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [XmlRoot("response")]
    public class response<T> where T : class, new()
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("params")]
        public T model { get; set; }
    }
}
