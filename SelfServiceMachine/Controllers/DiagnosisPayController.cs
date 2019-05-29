using Microsoft.AspNetCore.Mvc;
using SelfServiceMachine.Bussiness;
using SelfServiceMachine.Common;
using SelfServiceMachine.Models.Request;
using SelfServiceMachine.Models.Response;
using SelfServiceMachine.Utils;
using System;
using System.Linq;

namespace SelfServiceMachine.Controllers
{
    /// <summary>
    /// 诊疗付费
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
        /// <param name="getMZFeeList"></param>
        /// <returns></returns>
        [HttpPost("getMZFeeList")]
        public string GetMZFeeList(request<Entity.SRequest.getMZFeeList> getMZFeeList)
        {
            //if (string.IsNullOrWhiteSpace(getMZFeeListXML))
            //{
            //    return XMLHelper.XmlSerialize(new BaseXMLModel()
            //    {
            //        resultCode = -1,
            //        resultMessage = "XML不能为空"
            //    });
            //}

            //var getMZFeeList = XMLHelper.DESerializer<Entity.SlefServiceModels.GetMZFeeList>(getMZFeeListXML);
            if (getMZFeeList == null)
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "XML格式错误"
                });
            }

            var feeItems = orderInfoBLL.GetMZFeeLists(getMZFeeList.model.patCardType, getMZFeeList.model.patCardNo);
            if (feeItems.Count > 0)
            {
                return XMLHelper.XmlSerialize(new Entity.SResponse.getMZFeeList()
                {
                    resultCode = 0,
                    resultMessage = "",
                    item = feeItems
                });
            }
            else
            {
                //return XMLHelper.XmlSerialize(new Models.Response.GetMZFeeList()
                //{
                //    resultCode = 1,
                //    resultMessage = "暂无待缴费订单"
                //});
                return RsXmlHelper.ResXml(1, "暂无待缴费订单");
            }
        }

        /// <summary>
        /// 门诊待缴费记录明细查询
        /// </summary>
        /// <param name="getMZFeeDetail"></param>
        /// <returns></returns>
        [HttpPost("getMZFeeDetail")]
        public string GetMZFeeDetail(request<Entity.SRequest.getMZFeeDetail> getMZFeeDetail)
        {
            //if (!string.IsNullOrWhiteSpace(getMZFeeDetailXML))
            //{
            //    return XMLHelper.XmlSerialize(new BaseXMLModel()
            //    {
            //        resultCode = -1,
            //        resultMessage = "XML不能为空"
            //    });
            //}

            //var getMZFeeDetail = XMLHelper.DESerializer<Entity.SRequest.getMZFeeDetail>(getMZFeeDetailXML);
            if (getMZFeeDetail == null)
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "XML格式错误"
                });
            }

            var MZFeeList = orderInfoBLL.GetMZFeeDetails(getMZFeeDetail.model.mzFeeId);
            if (MZFeeList.Count > 0)
            {
                return XMLHelper.XmlSerialize(new Entity.SResponse.getMZFeeDetail()
                {
                    resultCode = 0,
                    resultMessage = "",
                    item = MZFeeList
                });
            }
            else
            {
                return XMLHelper.XmlSerialize(new Entity.SResponse.getMZFeeDetail()
                {
                    resultCode = 1,
                    resultMessage = "暂无数据"
                });
            }
        }

        /// <summary>
        /// 门诊缴费订单支付 (含社保)
        /// </summary>
        /// <param name="ackPayOrder"></param>
        /// <returns></returns>
        [HttpPost("ackPayOrder")]
        public string AckPayOrder(request<Entity.SRequest.ackPayOrder> ackPayOrder)
        {
            if (ackPayOrder == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            var orderList = orderInfoBLL.GetHasOrderByRegId(ackPayOrder.model.mzFeeIdList);
            if (!orderList) //判断是否有医嘱单号
            {
                return RsXmlHelper.ResXml(1, "暂无缴费订单");
            }

            var orderInfoList = orderInfoBLL.GetMZFeeByBillids(ackPayOrder.model.recipeNo);
            if (orderInfoList.Where(x => x.feestatus == "已收费") != null || orderInfoList.Where(x => x.feestatus == "已收费").Count() > 0)
            {
                return RsXmlHelper.ResXml(1, "本次缴费包含已缴费的处方单");
            }

            if (Convert.ToDecimal(ackPayOrder.model.totalAmout) < orderInfoList.Sum(x => x.totprice))
            {
                return RsXmlHelper.ResXml(1, "支付金额小于订单总金额");
            }
            if (string.IsNullOrWhiteSpace(ackPayOrder.model.ybjmc) && string.IsNullOrWhiteSpace(ackPayOrder.model.mzlsh)) //自费
            {
                orderInfoBLL.PayOrder(orderInfoList.Select(x => x.billid).ToArray());
            }
            else //医保
            {

            }
            return null;
        }
    }
}