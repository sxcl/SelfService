using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SelfServiceMachine.Bussiness;
using SelfServiceMachine.Common;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SResponse;
using SelfServiceMachine.Models.Request;
using SelfServiceMachine.Models.Response;
using SelfServiceMachine.Utils;

namespace SelfServiceMachine.Controllers
{
    /// <summary>
    /// 住院押金
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DepositInHospitalController : ControllerBase
    {
        /// <summary>
        /// 入院信息业务类
        /// </summary>
        public InReginfoBLL inReginfoBLL;
        /// <summary>
        /// 入院预交金业务类
        /// </summary>
        public FeeDepositBLL feeDepositBLL;
        /// <summary>
        /// 入院信息业务类
        /// </summary>
        public FeeDepositDetailBLL feeDepositDetailBLL;
        /// <summary>
        /// 
        /// </summary>
        public InInsuranceBLL inInsuranceBLL;
        /// <summary>
        /// 
        /// </summary>
        public InFeedetailBLL inFeedetailBLL;
        /// <summary>
        /// 
        /// </summary>
        public InOrderinfoBLL inOrderinfoBLL;

        /// <summary>
        /// 构造函数
        /// </summary>
        public DepositInHospitalController()
        {
            inReginfoBLL = new InReginfoBLL();
            feeDepositBLL = new FeeDepositBLL();
            feeDepositDetailBLL = new FeeDepositDetailBLL();
            inInsuranceBLL = new InInsuranceBLL();
            inFeedetailBLL = new InFeedetailBLL();
            inOrderinfoBLL = new InOrderinfoBLL();
        }

        /// <summary>
        /// 住院费用查询
        /// </summary>
        /// <param name="getBedFee"></param>
        /// <returns></returns>
        [HttpPost("getBedFee")]
        public string GetBedFee(request<Entity.SRequest.GetBedFee> getBedFee)
        {
            if (getBedFee == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            var inReginfo = inReginfoBLL.GetReginfo(getBedFee.model.patientID);
            if (inReginfo == null)
            {
                return RsXmlHelper.ResXml(-1, "无该患者入院信息");
            }

            var inInsurance = inInsuranceBLL.GetIn_Insurance(inReginfo.inid);
            var List = inOrderinfoBLL.GetIn_FeedItem(inReginfo.inid);
            var feedetailList = inFeedetailBLL.GetIn_Feedetails(inReginfo.inid);
            var feeDeposit = feeDepositBLL.GetFee_Deposit(x => x.inid == inReginfo.inid);

            return XMLHelper.XmlSerialize(new response<Entity.SResponse.GetBedFee>()
            {
                model = new Entity.SResponse.GetBedFee()
                {
                    resultCode = 0,
                    resultMessage = "",
                    totalFee = (inInsurance != null ? inInsurance.ttprice : List.Sum(x => x.costAmout)) * 100,
                    medicareFee = (inInsurance != null ? inInsurance.fundttprice : 0) * 100,
                    selfFee = (inInsurance != null ? inInsurance.selfprice : List.Sum(x => x.costAmout)) * 100,
                    payedFee = feeDeposit.totalprice * 100,
                    leftPreFee = (feeDeposit.totalprice - List.Sum(x => x.costAmout)) * 100,
                    leftFee = (List.Sum(x => x.costAmout) - feeDeposit.totalprice) * 100,
                    items = List
                }
            });
        }

        /// <summary>
        /// 住院押金补缴支付
        /// </summary>
        /// <returns></returns>
        [HttpPost("payDeposit")]
        public string PayDeposit(request<Entity.SRequest.payDeposit> payDeposit)
        {
            if (payDeposit == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            in_reginfo in_Reginfo = null;
            if (!string.IsNullOrWhiteSpace(payDeposit.model.patientID))
            {
                in_Reginfo = inReginfoBLL.GetReginfo(payDeposit.model.patientID);
            }
            else
            {
                return RsXmlHelper.ResXml(-1, "入院号不能为空");
            }
            string memo = "住院记录ID：{0}，公众服务平台订单号：{1}，收单机构流水号：{2}，收单机构代码：{3}，支付方式：{4}，补缴押金金额：{5}，支付时间：{6}，代缴人证件类型：{7}，代缴人证件号码：{8}，代缴人姓名：{9}。";
            memo = string.Format(memo, payDeposit.model.patientID, payDeposit.model.psOrdNum, payDeposit.model.agtOrdNum, payDeposit.model.agtCode, payDeposit.model.payMode, Convert.ToInt32(payDeposit.model.payAmout) / 100, payDeposit.model.payTime, payDeposit.model.reprePatCardType, payDeposit.model.reprePatCardNo, payDeposit.model.reprePatName);

            var fdid = feeDepositBLL.AdvancePayment(in_Reginfo, payDeposit.model.payMode, Convert.ToInt32(payDeposit.model.payAmout) / 100, payDeposit.model.psOrdNum, memo, out decimal leftPrice);

            return XMLHelper.XmlSerialize(new response<Entity.SResponse.payDeposit>()
            {
                model = new Entity.SResponse.payDeposit()
                {
                    resultCode = 0,
                    resultMessage = "",
                    hisOrdNum = EString.ZeroFill(fdid),
                    balance = (leftPrice * 100).ToString()
                }
            });
        }

        /// <summary>
        /// 住院押金补缴记录查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("getDepositList")]
        public string GetDepositList(request<Entity.SRequest.GetDepositList> getDepositList)
        {
            if (getDepositList == null)
            {
                return RsXmlHelper.ResXml(-1, "XML不能为空");
            }
            var feeDeposit = feeDepositBLL.GetFee_Deposit(x => x.inid == Convert.ToInt32(getDepositList.model.patientID));
            if (feeDeposit == null)
            {
                return RsXmlHelper.ResXml(-1, "暂无预交金缴费记录");
            }
            var list = feeDepositBLL.GetDepositItems(feeDeposit.did, !string.IsNullOrWhiteSpace(getDepositList.model.payMode) ? CodeConvertUtils.GetChannByCode(Convert.ToInt32(getDepositList.model.payMode)) : "", getDepositList.model.beginDate, getDepositList.model.endDate, getDepositList.model.psOrdNum);

            if (list.Count > 0)
            {
                return XMLHelper.XmlSerialize(new response<Entity.SResponse.GetDepositList>()
                {
                    model = new Entity.SResponse.GetDepositList()
                    {
                        resultCode = 0,
                        resultMessage = "",
                        item = list
                    }
                });
            }
            else
            {
                return RsXmlHelper.ResXml(99, "暂无缴费记录");
            }
        }

        /// <summary>
        /// 住院押金不足列表
        /// </summary>
        /// <returns></returns>
        [HttpPost("complementDeposit")]
        public string ComplementDeposit(request<Entity.SRequest.ComplementDeposit> complement)
        {
            if (complement == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            var list = feeDepositBLL.GetComplementDepositItems(complement.model.beginDate, complement.model.endDate);
            if (list.Count > 0)
            {
                return XMLHelper.XmlSerialize(new response<Entity.SResponse.ComplementDeposit>()
                {
                    model = new Entity.SResponse.ComplementDeposit()
                    {
                        resultCode = 0,
                        resultMessage = "",
                        item = list
                    }
                });
            }
            else
            {
                return RsXmlHelper.ResXml(99, "数据为空");
            }
        }

        /// <summary>
        /// 患者住院信息查询
        /// </summary>
        /// <param name="queryPatientHospital"></param>
        /// <returns></returns>
        [HttpPost("queryPatientHospital")]
        public string QueryPatientHospital(request<Entity.SRequest.queryPatientHospital> queryPatientHospital)
        {
            if (queryPatientHospital == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            var inReginfo = inReginfoBLL.GetDescFirst(x => x.idno == queryPatientHospital.model.patCardNo);
            if (inReginfo == null)
            {
                return RsXmlHelper.ResXml(-1, "无患者入院信息");
            }

            return XMLHelper.XmlSerialize(new response<Entity.SResponse.queryPatientHospital>()
            {
                model = new Entity.SResponse.queryPatientHospital()
                {
                    resultCode = 0,
                    resultMessage = "",
                    items = new List<patienthosItem>()
                    {
                        new patienthosItem()
                        {
                            patientID = inReginfo.inid.ToString(),
                            admissionNo = inReginfo.inno,
                            inDate = inReginfo.intime.ToString(),
                            inTime = inReginfoBLL.GetInCount(inReginfo.idno),
                            patName = inReginfo.pname,
                            deptName = inReginfo.indept,
                            doctorName = inReginfo.resident,
                            idCard = inReginfo.idno,
                            outDate = inReginfoBLL.GetOutDate(inReginfo.inid).ToString(),
                            patiId = inReginfo.pid.ToString()
                        }
                    }
                }
            });
        }
    }
}