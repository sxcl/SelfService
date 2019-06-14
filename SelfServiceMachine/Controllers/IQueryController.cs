using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelfServiceMachine.Bussiness;

namespace SelfServiceMachine.Controllers
{
    /// <summary>
    /// 智能查询
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class IQueryController : ControllerBase
    {
        /// <summary>
        /// 费用业务类
        /// </summary>
        public FeeinfoBLL feeinfoBLL;

        /// <summary>
        /// 构造函数
        /// </summary>
        public IQueryController()
        {
            feeinfoBLL = new FeeinfoBLL();
        }

        /// <summary>
        /// 账单下载（挂号、缴费、住院押金）
        /// </summary>
        /// <returns></returns>
        [HttpPost("getBillInfos")]
        public string GetBillInfos()
        {
            return null;
        }
    }
}