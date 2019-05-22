using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelfServiceMachine.Bussiness;
using SelfServiceMachine.Common;
using SelfServiceMachine.Entity.SlefServiceModels;
using SelfServiceMachine.Models.Response;

namespace SelfServiceMachine.Controllers
{
    /// <summary>
    /// 诊疗付款
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisPayController : ControllerBase
    {
        /// <summary>
        /// 医嘱单
        /// </summary>
        public OrderInfoBLL orderInfoBLL;

        /// <summary>
        /// 构造函数
        /// </summary>
        public DiagnosisPayController()
        {
            orderInfoBLL = new OrderInfoBLL();
        }

        /// <summary>
        /// 门诊待缴费记录查询
        /// </summary>
        /// <param name="getMZFeeListXML"></param>
        /// <returns></returns>
        [HttpGet("getMZFeeList")]
        public string GetMZFeeList(string getMZFeeListXML)
        {
            if (string.IsNullOrWhiteSpace(getMZFeeListXML))
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "XML不能为空"
                });
            }

            var getMZFeeList = XMLHelper.DESerializer<Entity.SlefServiceModels.GetMZFeeList>(getMZFeeListXML);
            if (getMZFeeList == null)
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "XML格式错误"
                });
            }

            var feeItems = orderInfoBLL.GetMZFeeLists(getMZFeeList.patCardType, getMZFeeList.patCardNo);
            if (feeItems.Count > 0)
            {
                return XMLHelper.XmlSerialize(new Models.Response.GetMZFeeList()
                {
                    resultCode = 0,
                    resultMessage = "",
                    item = feeItems
                });
            }
            else
            {
                return XMLHelper.XmlSerialize(new Models.Response.GetMZFeeList()
                {
                    resultCode = 1,
                    resultMessage = "暂无待缴费订单"
                });
            }
        }

        /// <summary>
        /// 门诊待缴费记录明细查询
        /// </summary>
        /// <param name="getMZFeeDetailXML"></param>
        /// <returns></returns>
        [HttpGet("getMZFeeDetail")]
        public string GetMZFeeDetail(string getMZFeeDetailXML)
        {
            if (!string.IsNullOrWhiteSpace(getMZFeeDetailXML))
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "XML不能为空"
                });
            }

            var getMZFeeDetail = XMLHelper.DESerializer<Entity.SlefServiceModels.getMZFeeDetail>(getMZFeeDetailXML);
            if (getMZFeeDetail == null)
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "XML格式错误"
                });
            }

            var MZFeeList = orderInfoBLL.GetMZFeeDetails(getMZFeeDetail.mzFeeId);
            if (MZFeeList.Count > 0)
            {
                return XMLHelper.XmlSerialize(new Models.Response.getMZFeeDetail()
                {
                    resultCode = 0,
                    resultMessage = "",
                    item = MZFeeList
                });
            }
            else
            {
                return XMLHelper.XmlSerialize(new Models.Response.getMZFeeDetail()
                {
                    resultCode = 1,
                    resultMessage = "暂无数据"
                });
            }
        }
    }
}