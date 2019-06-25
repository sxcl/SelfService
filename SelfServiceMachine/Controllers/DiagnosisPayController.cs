using Microsoft.AspNetCore.Mvc;
using SelfServiceMachine.Bussiness;
using SelfServiceMachine.Bussiness.Immunity;
using SelfServiceMachine.Bussiness.Ivf;
using SelfServiceMachine.Common;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SRequest;
using SelfServiceMachine.Entity.ViewModels;
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
        /// 
        /// </summary>
        public CommFeeBLL commFeeBLL;
        /// <summary>
        /// 
        /// </summary>
        public CommMedBLL commMedBLL;
        /// <summary>
        /// 
        /// </summary>
        public CommYbCodeBLL commYbCodeBLL;

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
            commFeeBLL = new CommFeeBLL();
            commMedBLL = new CommMedBLL();
            commYbCodeBLL = new CommYbCodeBLL();
        }

        /// <summary>
        /// 门诊待缴费记录查询
        /// </summary>
        /// <param name="getMZFeeList"></param>
        /// <returns></returns>
        [HttpPost("getMZFeeList")]
        public string GetMZFeeList(request<getMZFeeList> getMZFeeList)
        {
            if (getMZFeeList == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            var feeItems = orderInfoBLL.GetMZFeeLists(getMZFeeList.model.patCardType, getMZFeeList.model.patCardNo, "", "");
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
                return RsXmlHelper.ResXml(1, "暂无待缴费订单");
            }
        }

        /// <summary>
        /// 门诊待缴费记录明细查询
        /// </summary>
        /// <param name="getMZFeeDetail"></param>
        /// <returns></returns>
        [HttpPost("getMZFeeDetail")]
        public string GetMZFeeDetail(request<getMZFeeDetail> getMZFeeDetail)
        {
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

            var feeInfo = feeinfoBLL.Get(ackPayOrder.model.agtOrdNum);
            if (feeInfo != null)
            {
                return XMLHelper.XmlSerialize(new response<Entity.SResponse.ackPayOrder>()
                {
                    model = new Entity.SResponse.ackPayOrder()
                    {
                        resultCode = 0,
                        resultMessage = "",
                        hisOrdNum = feeInfo.feeid.ToString(),
                        hisMessage = "支付成功"
                    }
                });
            }

            var orderList = orderInfoBLL.GetHasOrderByRegid(ackPayOrder.model.mzFeeIdList);
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
                orderInfoList = orderInfoBLL.GetOrderByRegId(Convert.ToInt32(ackPayOrder.model.mzFeeIdList));
            }

            var totalAmount = 0M;
            if (orderInfoList.Where(x => x.feestatus == "未收费").Count() > 0)
            {
                totalAmount = Convert.ToDecimal(orderInfoList.Sum(x => x.totprice));
            }

            if (Convert.ToDecimal(ackPayOrder.model.totalAmout) / 100 != totalAmount)
            {
                return RsXmlHelper.ResXml(1, "支付金额小于订单总金额");
            }

            orderInfoBLL.PayOrder(orderInfoList.Select(x => x.billid).ToArray());
            var orderfeeList = orderfeedetailBLL.GetOrder_Feedetails(orderInfoList.Select(x => x.billid).ToArray());

            var regInfo = reginfoBLL.GetReg_Info(Convert.ToInt32(orderInfoList.FirstOrDefault().regid));//挂号信息

            ImmunityBLL immunityBLL = new ImmunityBLL();
            IvfBLL ivfBLL = new IvfBLL();
            foreach (var orderInfo in orderInfoList)
            {
                orderInfo.feetime = DateTime.Now;
                orderInfo.feestatus = "已收费";
                if (orderInfo.extern_source == "ivf")
                {
                    ivfBLL.SetIvfToll(orderInfo.billid, orderInfo.extern_source);
                }
                else if (orderInfo.extern_source == "immunity")
                {
                    immunityBLL.SetImmunityToll(orderInfo.billid, orderInfo.extern_source);
                }
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
                chnnsno = ackPayOrder.model.psOrdNum
            });

            if (!string.IsNullOrWhiteSpace(ackPayOrder.model.ybjmc) && !string.IsNullOrWhiteSpace(ackPayOrder.model.mzlsh))  //医保
            {
                feeinfoBLL.AddFeechannel(new fee_channel()
                {
                    feeid = feeid,
                    chnn = "医疗保险",
                    amount = (Convert.ToDecimal(ackPayOrder.model.totalAmout) - Convert.ToDecimal(ackPayOrder.model.payAmout)) / 100,
                    del = false,
                    chnnsno = ackPayOrder.model.mzlsh
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
        public string GetPayFeeDetail(request<getPayFeeDetail> getPayFeeDetail)
        {
            if (getPayFeeDetail == null)
            {
                return RsXmlHelper.ResXml(-1, "XML个数错误");
            }

            var itemList = feeInfodetailBLL.GetPayFeeDetailItems(Convert.ToInt32(getPayFeeDetail.model.MzFeeId));

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

            var regInfo = reginfoBLL.Get(x => x.regid == Convert.ToInt32(getMZInsurance.model.mzFeeId));
            if (regInfo == null)
            {
                return RsXmlHelper.ResXml(-1, "挂号信息为空");
            }

            var orderInfoList = orderInfoBLL.Get(getMZInsurance.model.mzFeeId, getMZInsurance.model.mzBillId);
            var orderFeedetails = orderfeedetailBLL.GetOrder_Feedetails(orderInfoList.Select(x => x.billid).ToArray());

            var ybsssno = commKeyBLL.GetYBNO();
            var ybSno = "HZS10" + DateTime.Now.ToString("yyyyMMdd") + ybsssno;

            FY001 fY001 = new FY001()
            {
                akc190 = "HZS10" + regInfo.mzno,
                bke384 = ybSno,
                listsize = orderFeedetails.Count,
            };
            fY001.inputlist = new List<inputlistfy001>();
            foreach (var order_Feedetail in orderFeedetails)
            {
                if (order_Feedetail.itemtype == "中草药" || order_Feedetail.itemtype == "中成药" || order_Feedetail.itemtype == "西药")
                {
                    var commMed = commMedBLL.Get(x => x.itemid == order_Feedetail.itemid);
                    fY001.inputlist.Add(new inputlistfy001()
                    {
                        aae072 = order_Feedetail.billid.ToString(),
                        bkc369 = "1",
                        bkf500 = order_Feedetail.bdfeeid.ToString(),
                        ake001 = commMed.ybcode,
                        ake002 = commMed.itemname,
                        bkm017 = commMed.stdcode,
                        ake005 = commMed.itemid,
                        ake006 = commMed.itemname,
                        akc225 = order_Feedetail.prices.ToString(),
                        akc264 = order_Feedetail.totalprices.ToString(),
                        aka067 = commMed.bscunit,
                        aka070 = commYbCodeBLL.GetYbCodeByName("AKA070", commMed.dosage),
                        aka074 = commMed.spec,
                        akc226 = (Convert.ToInt32(order_Feedetail.total) * Convert.ToInt32(order_Feedetail.dppack)).ToString(),
                        akc271 = Convert.ToDateTime(order_Feedetail.addtime).ToString("yyyyMMdd"),
                        bkc320 = doctor.ybno
                    });
                }
                else
                {
                    var commFee = new comm_fee();
                    var isPackage = commFeeBLL.IsPackage(x => x.itemid == order_Feedetail.itemid && x.costtype == "5");
                    if (isPackage)
                    {
                        commFee = commFeeBLL.Get(Convert.ToInt32(order_Feedetail.itemid));
                    }
                    else
                    {
                        commFee = commFeeBLL.Get(x => x.itemid == order_Feedetail.itemid && x.costtype == "5");
                    }
                    fY001.inputlist.Add(new inputlistfy001()
                    {
                        aae072 = order_Feedetail.billid.ToString(),
                        bkc369 = "1",
                        bkf500 = order_Feedetail.bdfeeid.ToString(),
                        ake001 = commFee.scode,
                        ake002 = commFee.itemname,
                        bkm017 = commFee.scode,
                        ake005 = commFee.itemid,
                        ake006 = commFee.itemname,
                        ala026 = "",
                        aka070 = "",
                        aka074 = order_Feedetail.spec,
                        akc225 = decimal.Round(Convert.ToDecimal(order_Feedetail.prices), 2).ToString(),
                        akc226 = Convert.ToInt32(order_Feedetail.total).ToString(),
                        akc264 = decimal.Round(Convert.ToDecimal(order_Feedetail.totalprices), 2).ToString(),
                        aka067 = order_Feedetail.dpunit,
                        akc271 = Convert.ToDateTime(order_Feedetail.addtime).ToString("yyyyMMdd"),
                        bkc320 = doctor.ybno,
                        cke400 = ""
                    });
                }
            }

            FY004 fY004 = new FY004()
            {
                akc190 = "HZS10" + regInfo.mzno,
                aka130 = "11",
                bkc320 = doctor.ybno,
                ckc350 = doctor.username,
                aka030 = "12",
                akc264 = Math.Round(Convert.ToDecimal(orderInfoList.Sum(x => x.totprice)), 2).ToString(),
                ckc601 = "0",
                bke384 = "HZS10" + DateTime.Now.ToString("yyyyMMdd") + ybsssno
            };

            var getVerifyCodeResult = JsonOperator.JsonDeserialize<Entity.SResponse.getVerifyCode>(HttpHelper.Post("http://192.168.88.134:8300/YBDLL/domain/getVerifyCode", JsonOperator.JsonSerialize(new getVerifyCode() { inParam = "FY001|" + ybSno + "|HZS10|" }), Encoding.UTF8, 1));
            if (getVerifyCodeResult.resultCode != 0 || getVerifyCodeResult.resultCode != 00000000)
            {
                return RsXmlHelper.ResXml(-1, getVerifyCodeResult.resultMsg);
            }

            var version = getVerifyCodeResult.outParam.Split("|")[2];
            var verify = getVerifyCodeResult.outParam.Split("|")[0] + "|" + getVerifyCodeResult.outParam.Split("|")[1];

            var resultFy001 = HealthInsuranceHelper.RegTrial<BaseMedInsurance<Entity.SResponse.FY001>>("FY001", version, verify, ybsssno.ToString(), fY001);
            if (resultFy001.transReturnCode != "0" && resultFy001.transReturnCode != "00000000")
            {
                return RsXmlHelper.ResXml(-1, resultFy001.transReturnMessage + JsonOperator.JsonSerialize(fY001) + "出参：" + JsonOperator.JsonSerialize(resultFy001));
            }

            getVerifyCodeResult = JsonOperator.JsonDeserialize<Entity.SResponse.getVerifyCode>(HttpHelper.Post("http://192.168.88.134:8300/YBDLL/domain/getVerifyCode", JsonOperator.JsonSerialize(new getVerifyCode() { inParam = "FY004|" + ybSno + "|HZS10|" }), Encoding.UTF8, 1));

            var result = HealthInsuranceHelper.RegTrial<BaseMedInsurance<Entity.SResponse.FY004>>("FY004", version, verify, ybsssno.ToString(), fY004);

            if (result.transReturnCode == "0" || result.transReturnCode == "00000000")
            {
                feeTrialBLL.Add(new fee_trial()
                {
                    akc190 = fY004.akc190,
                    aka130 = fY004.aka130,
                    bkc320 = fY004.bkc320,
                    ckc350 = fY004.ckc350,
                    aka030 = fY004.aka030,
                    akc264 = Convert.ToDecimal(fY004.akc264),
                    ckc601 = fY004.ckc601,
                    bke384 = fY004.bke384
                });

                return XMLHelper.XmlSerialize(new response<Entity.SResponse.getMZInsurance>()
                {

                    model = new Entity.SResponse.getMZInsurance()
                    {
                        resultCode = 0,
                        mzFeeId = regInfo.regid,
                        mzBillId = string.Join(",", orderInfoList.Select(x => x.billid)),
                        time = DateTime.Now,
                        SSFeeNo = fY004.akc190,
                        SSSerNum = fY004.bke384,
                        recipeCount = orderInfoList.Count.ToString(),
                        mzCategory = "普通",
                        doctorCode = doctor.userno,
                        doctorName = doctor.username,
                        deptCode = dept.code,
                        deptName = dept.name,
                        payType = "医保",
                        payAmount = result.transBody.akb067.ToString(),
                        accountAmount = result.transBody.akb066.ToString(),
                        medicareAmount = result.transBody.akb068.ToString(),
                        insuranceAmout = (result.transBody.akb068 + result.transBody.akb066).ToString(),
                        totalAmout = result.transBody.akc264.ToString(),
                        akc190 = fY004.akc190,
                        cardArea = result.cardArea,
                        SSInfoNew = JsonOperator.JsonSerialize(result.transBody)
                    }
                });
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

            var ptInfo = ptInfoBLL.GetPtInfoByCardNo("", Convert.ToInt32(settleMZInsurance.model.patCardType), settleMZInsurance.model.patCardNo);
            if (ptInfo == null)
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

            var FeeTrail = feeTrialBLL.Get(x => x.bke384 == settleMZInsurance.model.SSSerNo);
            if (FeeTrail == null && !string.IsNullOrWhiteSpace(FeeTrail.transBody))
            {
                //return RsXmlHelper.ResXml(0, JsonOperator.JsonSerialize(FeeTrail.transBody));
                return XMLHelper.XmlSerialize(new response<FeeSettlement>()
                {
                    model = new FeeSettlement()
                    {
                        resultCode = 0,
                        resultMessage = FeeTrail.transBody,
                        akc190 = FeeTrail.akc190
                    }
                });
            }
            FY005 fY005 = new FY005()
            {
                aaz500 = settleMZInsurance.model.socialSecurityNo,
                bzz269 = string.IsNullOrWhiteSpace(settleMZInsurance.model.patCardPwd) ? "000000" : settleMZInsurance.model.patCardPwd,
                akc190 = FeeTrail.akc190,
                aka130 = FeeTrail.aka130,
                bkc320 = FeeTrail.bkc320,
                ckc350 = FeeTrail.ckc350,
                aka030 = FeeTrail.aka030,
                akc264 = FeeTrail.akc264.ToString(),
                ckc601 = FeeTrail.ckc601,
                bke384 = FeeTrail.bke384
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
            if (result.transReturnCode == "0" || result.transReturnCode == "00000000")
            {

                var resultObj = new Entity.SResponse.getMZInsurance()
                {
                    resultCode = 0,
                    resultMessage = "",
                    mzFeeId = regInfo.regid,
                    mzBillId = string.Join(",", orderInfoList.Select(x => x.billid)),
                    SSFeeNo = ybSno,
                    SSBillNumber = null,
                    time = DateTime.Now,
                    recipeCount = orderInfoList.Count.ToString(),
                    deptCode = dept.code,
                    doctorCode = doctor.userno,
                    doctorName = doctor.username,
                    payType = "医保",
                    payAmount = result.transBody.akb067.ToString(),
                    totalAmout = orderInfoList.Sum(x => x.totprice).ToString(),
                    akc190 = fY005.akc190,
                    SSInfoNew = JsonOperator.JsonSerialize(result.transBody)
                };
                return XMLHelper.XmlSerialize(new response<FeeSettlement>()
                {
                    model = new FeeSettlement()
                    {
                        resultCode = 0,
                        resultMessage = JsonOperator.JsonSerialize(result.transBody),
                        akc190 = fY005.akc190
                    }
                });
            }
            else
            {
                return RsXmlHelper.ResXml(-1, result.transReturnMessage + "{" + JsonOperator.JsonSerialize(fY005) + "}");
            }
        }
    }
}