using Microsoft.AspNetCore.Mvc;
using SelfServiceMachine.Bussiness;
using SelfServiceMachine.Common;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SRequest;
using SelfServiceMachine.Models.Request;
using SelfServiceMachine.Models.Response;
using SelfServiceMachine.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        /// 
        /// </summary>
        public PtInfoBLL ptInfoBLL;
        /// <summary>
        /// 
        /// </summary>
        public SysDeptBLL sysDeptBLL;
        /// <summary>
        /// 
        /// </summary>
        public SysUserinfoBLL sysUserinfoBLL;
        /// <summary>
        /// 
        /// </summary>
        public FeeTrialBLL feeTrialBLL;
        /// <summary>
        /// 
        /// </summary>
        public CommKeyBLL commKeyBLL;

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
            ptInfoBLL = new PtInfoBLL();
            sysDeptBLL = new SysDeptBLL();
            sysUserinfoBLL = new SysUserinfoBLL();
            feeTrialBLL = new FeeTrialBLL();
            commKeyBLL = new CommKeyBLL();
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
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            var feeItems = orderInfoBLL.GetMZFeeLists(getMZFeeList.model.patCardType, getMZFeeList.model.patCardNo);
            if (feeItems.Count > 0)
            {
                return XMLHelper.XmlSerialize(new response<Entity.SResponse.getMZFeeList>()
                {
                    model = new Entity.SResponse.getMZFeeList()
                    {
                        resultCode = 0,
                        resultMessage = "",
                        item = feeItems
                    }
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
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            var MZFeeList = orderInfoBLL.GetMZFeeDetails(getMZFeeDetail.model.mzFeeId, getMZFeeDetail.model.recipeNo);
            if (MZFeeList.Count > 0)
            {
                return XMLHelper.XmlSerialize(new response<Entity.SResponse.getMZFeeDetail>()
                {
                    model = new Entity.SResponse.getMZFeeDetail()
                    {
                        resultCode = 0,
                        resultMessage = "",
                        item = MZFeeList
                    }
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

            if (string.IsNullOrWhiteSpace(ackPayOrder.model.ybjmc) && string.IsNullOrWhiteSpace(ackPayOrder.model.mzlsh)) //自费
            {
                feeinfoBLL.AddFeechannel(new fee_channel()
                {
                    feeid = feeid,
                    chnn = ackPayOrder.model.payMode,
                    amount = Convert.ToDecimal(ackPayOrder.model.totalAmout) / 100,
                    del = false,
                    sno = ackPayOrder.model.agtOrdNum
                });
            }
            else //医保
            {
                feeinfoBLL.AddFeechannel(new fee_channel()
                {
                    feeid = feeid,
                    chnn = ackPayOrder.model.payMode,
                    amount = (Convert.ToDecimal(ackPayOrder.model.totalAmout) - Convert.ToDecimal(ackPayOrder.model.payAmout)) / 100,
                    del = false,
                    sno = ackPayOrder.model.mzlsh
                });
            }
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

        /// <summary>
        /// 门诊已缴费记录明细查询
        /// </summary>
        /// <param name="getPayFeeDetail"></param>
        /// <returns></returns>
        [HttpPost("getPayFeeDetail")]
        public string GetPayFeeDetail(request<Entity.SRequest.getPayFeeDetail> getPayFeeDetail)
        {
            if (getPayFeeDetail == null)
            {
                return RsXmlHelper.ResXml(-1, "XML个数错误");
            }

            var itemList = feeInfodetailBLL.GetPayFeeDetailItems(Convert.ToInt32(getPayFeeDetail.model.mzFeeIdList));

            if (itemList != null && itemList.Count > 0)
            {
                return XMLHelper.XmlSerialize(new response<Entity.SResponse.getPayFeeDetail>()
                {
                    model = new Entity.SResponse.getPayFeeDetail()
                    {
                        resultCode = 0,
                        item = itemList
                    }
                });
            }
            else
            {
                return RsXmlHelper.ResXml(1, "暂无数据");
            }
        }

        /// <summary>
        /// 医保门诊预结算
        /// </summary>
        /// <param name="getMZInsurance"></param>
        /// <returns></returns>
        [HttpPost("getMZInsurance")]
        public string GetMZInsurance(request<getMZInsurance> getMZInsurance)
        {
            if (getMZInsurance == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            var ptInfo = ptInfoBLL.GetPtInfoByCardNo("", Convert.ToInt32(getMZInsurance.model.patCardType), getMZInsurance.model.patCardNo);
            if (ptInfo == null)
            {
                return RsXmlHelper.ResXml(-1, "患者信息为空");
            }

            var dept = sysDeptBLL.GetDeptByCode(getMZInsurance.model.deptCode);
            var doctor = sysUserinfoBLL.GetRDoctor(getMZInsurance.model.doctorCode);

            var regInfo = reginfoBLL.Get(x => x.doctor == doctor.username && x.dept == dept.name && x.pid == ptInfo.pid);
            if (regInfo == null)
            {
                return RsXmlHelper.ResXml(-1, "挂号信息为空");
            }

            var orderInfoList = orderInfoBLL.Get(getMZInsurance.model.mzFeeId, getMZInsurance.model.mzBillId);

            var ybsssno = commKeyBLL.GetYBNO();
            FY004 fY004 = new FY004()
            {
                akc190 = "HZS10" + regInfo.mzno,
                aka130 = "11",
                bkc320 = doctor.ybno,
                ckc350 = doctor.username,
                aka030 = "",
                akc264 = Math.Round(Convert.ToDecimal(orderInfoList.Sum(x => x.totprice)), 2).ToString(),
                ckc601 = "0",
                bke384 = "HZS10" + DateTime.Now.ToString("yyyyMMdd") + ybsssno
            };


            var ybSno = "HZS10" + DateTime.Now.ToString("yyyyMMdd") + ybsssno;
            var getVerifyCodeResult = JsonOperator.JsonDeserialize<Entity.SResponse.getVerifyCode>(HttpHelper.Post("http://192.168.88.134:8300/YBDLL/domain/getVerifyCode", JsonOperator.JsonSerialize(new getVerifyCode() { inParam = "FY004|" + ybSno + "|HZS10|" }), Encoding.UTF8, 1));
            if (getVerifyCodeResult.resultCode != 0)
            {
                return null;
            }

            var version = getVerifyCodeResult.outParam.Split("|")[2];
            var verify = getVerifyCodeResult.outParam.Split("|")[0] + "|" + getVerifyCodeResult.outParam.Split("|")[1];
            var result = HealthInsuranceHelper.RegTrial<BaseMedInsurance<Entity.SResponse.FY004>>("FY004", version, verify, ybsssno.ToString(), fY004);

            if (result.transReturnCode == "0")
            {
                //feeTrialBLL.Add(new fee_trial()
                //{
                //    akc190 = fY004.akc190,
                //    aka130 = fY004.aka130,
                //    bkc320 = fY004.bkc320,
                //    ckc350 = fY004.ckc350,
                //    aka030 = fY004.aka030,
                //    akc264 = Convert.ToDecimal(fY004.akc264),
                //    ckc601 = fY004.ckc601,
                //    bke384 = fY004.bke384
                //});
                return RsXmlHelper.ResXml(0, result.transReturnMessage);
            }
            else
            {
                return RsXmlHelper.ResXml(-1, result.transReturnMessage);
            }
        }

        /// <summary>
        /// 医保门诊结算支付
        /// </summary>
        /// <param name="settleMZInsurance"></param>
        /// <returns></returns>
        [HttpPost("settleMZInsurance")]
        public string SettleMZInsurance(request<settleMZInsurance> settleMZInsurance)
        {
            if (settleMZInsurance == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            var dept = sysDeptBLL.GetDeptByCode(settleMZInsurance.model.deptCode);
            var doctor = sysUserinfoBLL.GetRDoctor(settleMZInsurance.model.doctorCode);

            var pt_Info = ptInfoBLL.GetPtInfoByCardNo("", Convert.ToInt32(settleMZInsurance.model.patCardType), settleMZInsurance.model.patCardNo);
            if (pt_Info == null)
            {
                return RsXmlHelper.ResXml(-1, "患者信息为空");
            }

            var regInfo = reginfoBLL.GetReg_Info(Convert.ToInt32(settleMZInsurance.model.mzFeeId));

            var orderInfoList = orderInfoBLL.GetMZOrderInfo(settleMZInsurance.model.mzFeeId, settleMZInsurance.model.mzBillId);
            if (regInfo == null)
            {
                return RsXmlHelper.ResXml(-1, "挂号信息为空");
            }

            var ybsssno = commKeyBLL.GetYBNO();
            FY005 fY005 = new FY005()
            {
                aaz500 = pt_Info.ybidentity,
                bzz269 = settleMZInsurance.model.patCardPwd,
                akc190 = "HZS10" + regInfo.mzno,
                aka130 = "11",
                bkc320 = doctor.ybno,
                ckc350 = doctor.username,
                aka030 = "",
                akc264 = Math.Round(Convert.ToDecimal(orderInfoList.Sum(x => x.totprice))).ToString(),
                ckc601 = "0",
                bke384 = "HZS10" + DateTime.Now.ToString("yyyyMMdd") + ybsssno
            };

            var ybSno = "HZS10" + DateTime.Now.ToString("yyyyMMdd") + ybsssno;
            var getVerifyCodeResult = JsonOperator.JsonDeserialize<Entity.SResponse.getVerifyCode>(HttpHelper.Post("http://192.168.88.134:8300/YBDLL/domain/getVerifyCode", JsonOperator.JsonSerialize(new getVerifyCode() { inParam = "FY005|" + ybSno + "|HZS10|" }), Encoding.UTF8, 1));
            if (getVerifyCodeResult.resultCode != 0)
            {
                return null;
            }

            var version = getVerifyCodeResult.outParam.Split("|")[2];
            var verify = getVerifyCodeResult.outParam.Split("|")[0] + "|" + getVerifyCodeResult.outParam.Split("|")[1];
            var result = HealthInsuranceHelper.RegTrial<BaseMedInsurance<Entity.SResponse.FY005>>("FY005", version, verify, ybsssno.ToString(), fY005);
            if (result.transReturnCode == "0")
            {
                feeTrialBLL.Add(new fee_trial()
                {
                    akc190 = fY005.akc190,
                    aka130 = fY005.aka130,
                    bkc320 = fY005.bkc320,
                    ckc350 = fY005.ckc350,
                    aka030 = fY005.aka030,
                    akc264 = Convert.ToDecimal(fY005.akc264),
                    ckc601 = fY005.ckc601,
                    bke384 = fY005.bke384
                });
                return RsXmlHelper.ResXml(0, result.transReturnMessage);
            }
            else
            {
                return RsXmlHelper.ResXml(-1, result.transReturnMessage);
            }
        }
    }
}