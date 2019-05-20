using System.Collections.Generic;

namespace SelfServiceMachine.Model
{
    /// <summary>
    /// 通用返回信息类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MessageModel<T>
    {
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public List<T> Data { get; set; }
    }
}
