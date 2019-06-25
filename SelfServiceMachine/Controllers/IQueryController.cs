using Microsoft.AspNetCore.Mvc;
using SelfServiceMachine.Bussiness;
using SelfServiceMachine.Common;
using SelfServiceMachine.Models.Request;
using SelfServiceMachine.Models.Response;
using SelfServiceMachine.Utils;

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
        public string GetBillInfos(request<Entity.SRequest.getBillInfos> getBill)
        {
            if (getBill == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            return XMLHelper.XmlSerialize(new response<Entity.SResponse.getBillInfos>()
            {
                model = new Entity.SResponse.getBillInfos()
                {
                    resultCode = 0,
                    resultMessage = "",
                    item = feeinfoBLL.getBillInfos(getBill.model.billDate, getBill.model.payMode, getBill.model.pageNo, getBill.model.pageNumber)
                }
            });

        }
    }
}