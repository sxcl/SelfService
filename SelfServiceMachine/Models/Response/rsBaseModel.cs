namespace SelfServiceMachine.Models.Response
{
    /// <summary>
    /// 返回的XML体
    /// </summary>
    public class rsBaseModel
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

    /// <summary>
    /// 返回XML基类
    /// </summary>
    public class rsBaseModelP
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public string resultCode { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string resultMessage { get; set; }
    }
}
