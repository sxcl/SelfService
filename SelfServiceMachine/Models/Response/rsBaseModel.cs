using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfServiceMachine.Models.Response
{
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
