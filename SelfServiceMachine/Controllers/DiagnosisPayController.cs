using Microsoft.AspNetCore.Mvc;
using SelfServiceMachine.Bussiness;
using SelfServiceMachine.Common;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Models.Request;
using SelfServiceMachine.Models.Response;
using SelfServiceMachine.Utils;
using System;
using System.Collections.Generic;
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
        /// 
        /// </summary>
        public OrderfeedetailBLL orderfeedetailBLL;
        /// <summary>
        /// 
        /// </summary>
        public ReginfoBLL reginfoBLL;
        /// <summary>
        /// 
        /// </summary>
        public FeeinfoBLL feeinfoBLL;
        /// <summary>
        /// 
        /// </summary>
        public FeeInfodetailBLL feeInfodetailBLL;

        /// <summary>
        /// 构造函数
        /// </summary>
        public DiagnosisPayController()
        {
            orderInfoBLL = new OrderInfoBLL();
            orderfeedetailBLL = new OrderfeedetailBLL();
            reginfoBLL = new ReginfoBLL();
            feeinfoBLL = new FeeinfoBLL();
            feeInfodetailBLL = new FeeInfodetailBLL();
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

            var MZFeeList = orderInfoBLL.GetMZFeeDetails(getMZFeeDetail.model.mzFeeId, getMZFeeDetail.model.recipeNo);
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

            var orderList = orderInfoBLL.GetHasOrderByVisid(ackPayOrder.model.mzFeeIdList);
            if (!orderList) //判断是否有医嘱单号
            {
                return RsXmlHelper.ResXml(1, "暂无缴费订单");
            }

            var orderInfoList = new List<order_info>();
            if (!string.IsNullOrWhiteSpace(ackPayOrder.model.recipeNo))
            {
                orderInfoList = orderInfoBLL.GetMZFeeByBillids(ackPayOrder.model.recipeNo);
            }
            else
            {
                orderInfoList = orderInfoBLL.GetOrderByVisid(Convert.ToInt32(ackPayOrder.model.mzFeeIdList));
            }
            if (orderInfoList.Where(x => x.feestatus == "已收费") != null && orderInfoList.Where(x => x.feestatus == "已收费").Count() > 0)
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

                var orderfeeList = orderfeedetailBLL.GetOrder_Feedetails(orderInfoList.Select(x => x.billid).ToArray());

                var regInfo = reginfoBLL.GetReg_Info(Convert.ToInt32(orderInfoList.FirstOrDefault().regid));//挂号信息

                foreach (var orderInfo in orderInfoList)
                {
                    orderInfo.feetime = DateTime.Now;
                    orderInfo.feestatus = "已收费";
                }
                orderInfoBLL.Updates(orderInfoList);

                var feeid = feeinfoBLL.AddReturnId(new fee_info()
                {
                    mzno = regInfo.mzno,
                    pid = regInfo.pid,
                    regid = regInfo.regid,
                    ftype = 0,
                    amountrec = orderInfoList.Sum(x => x.totprice),
                    amountcol = Convert.ToDecimal(ackPayOrder.model.totalAmout) / 100,
                    userid = 89757,
                    username = "自助机",
                    addtime = DateTime.Now,
                    printqty = 0,
                    status = 0,
                    del = false
                });

                List<fee_infodetail> fee_Infodetails = new List<fee_infodetail>();
                foreach (var order_Feedetail in orderfeeList)
                {
                    fee_Infodetails.Add(new fee_infodetail()
                    {
                        billid = order_Feedetail.billid,
                        bdid = order_Feedetail.bdid,
                        dgid = order_Feedetail.dgid?.ToString(),
                        itemid = order_Feedetail.itemid,
                        itemname = order_Feedetail.itemname,
                        spec = order_Feedetail.spec,
                        itemtype = order_Feedetail.itemtype,
                        unit = order_Feedetail.dpunit,
                        prices = order_Feedetail.prices,
                        qty = order_Feedetail.total,
                        feetype = regInfo.feetype,
                        totalprice = order_Feedetail.totalprices,
                        bdfeeid = order_Feedetail.bdfeeid,
                        execdept = order_Feedetail.dept,
                        status = 0,
                        addtime = DateTime.Now,
                        addperson = "自助机",
                        del = false,
                        dosage = order_Feedetail.dosage,
                        ybname = order_Feedetail.ybname,
                        feeid = feeid
                    });
                }
                feeInfodetailBLL.Adds(fee_Infodetails);
                feeinfoBLL.AddFeechannel(new fee_channel()
                {
                    feeid = feeid,
                    chnn = ackPayOrder.model.payMode,
                    amount = Convert.ToDecimal(ackPayOrder.model.totalAmout) / 100,
                    del = false,
                    sno = ackPayOrder.model.agtOrdNum
                });

                return XMLHelper.XmlSerialize(new response<Entity.SResponse.ackPayOrder>()
                {
                    model = new Entity.SResponse.ackPayOrder()
                    {
                        resultCode = 0,
                        resultMessage = "",
                        hisOrdNum = feeid.ToString(),
                        hisMessage = "支付成功"
                    }
                });
            }
            else //医保
            {

            }
            return null;
        }

        /// <summary>
        /// 门诊已缴费记录查询
        /// </summary>
        /// <param name="getPayList"></param>
        /// <returns></returns>
        [HttpPost("getPayList")]
        public string GetPayList(request<Entity.SRequest.getPayList> getPayList)
        {
            if (getPayList == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            var para = CodeConvertUtils.GetCardTypeByType(Convert.ToInt32(getPayList.model.patCardType));

            var ptInfo = feeinfoBLL.GetFee_Infos(para, getPayList.model.patCardNo);
            var itemList = feeinfoBLL.GetPayItems(ptInfo.pid);

            if (itemList != null && itemList.Count > 0)
            {
                return XMLHelper.XmlSerialize(new response<Entity.SResponse.getPayList>()
                {
                    model = new Entity.SResponse.getPayList()
                    {
                        resultCode = 0,
                        item = itemList
                    }
                });
            }
            else
            {
                return XMLHelper.XmlSerialize(new response<Entity.SResponse.getPayList>()
                {
                    model = new Entity.SResponse.getPayList()
                    {
                        resultCode = 1,
                        resultMessage = "暂无数据"
                    }
                });
            }
        }
    }
}