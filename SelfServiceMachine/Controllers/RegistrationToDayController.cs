using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using SelfServiceMachine.Bussiness;
using SelfServiceMachine.Common;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SRequest;
using SelfServiceMachine.Models.Request;
using SelfServiceMachine.Models.Response;
using SelfServiceMachine.Utils;

namespace SelfServiceMachine.Controllers
{
    /// <summary>
    /// 当天挂号
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationToDayController : ControllerBase
    {
        /// <summary>
        /// 号源类型
        /// </summary>
        public RegTypeBLL regTypeBLL;
        /// <summary>
        /// 
        /// </summary>
        public RegManageBLL regManageBLL;
        /// <summary>
        /// 
        /// </summary>
        public TempRegBLL tempRegBLL;
        /// <summary>
        /// 
        /// </summary>
        public RegArrangeBLL regArrangeBLL;
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
        public ReginfoBLL reginfoBLL;
        /// <summary>
        /// 
        /// </summary>
        public PtInfoBLL ptInfoBLL;
        /// <summary>
        /// 
        /// </summary>
        public FeeinfoBLL feeinfoBLL;
        /// <summary>
        /// 
        /// </summary>
        public CommFeeBLL commFeeBLL;
        /// <summary>
        /// 
        /// </summary>
        public CommKeyBLL commKeyBLL;
        /// <summary>
        /// 
        /// </summary>
        public FeeInfodetailBLL feeInfodetailBLL;
        /// <summary>
        /// 
        /// </summary>
        public RegTrialBLL regTrialBLL;
        /// <summary>
        /// 
        /// </summary>
        public RegTrialdetailBLL regTrialdetailBLL;

        /// <summary>
        /// 构造函数
        /// </summary>
        public RegistrationToDayController()
        {
            regTypeBLL = new RegTypeBLL();
            regManageBLL = new RegManageBLL();
            tempRegBLL = new TempRegBLL();
            regArrangeBLL = new RegArrangeBLL();
            sysDeptBLL = new SysDeptBLL();
            sysUserinfoBLL = new SysUserinfoBLL();
            reginfoBLL = new ReginfoBLL();
            ptInfoBLL = new PtInfoBLL();
            feeinfoBLL = new FeeinfoBLL();
            commFeeBLL = new CommFeeBLL();
            commKeyBLL = new CommKeyBLL();
            feeInfodetailBLL = new FeeInfodetailBLL();
            regTrialBLL = new RegTrialBLL();
            regTrialdetailBLL = new RegTrialdetailBLL();
        }

        /// <summary>
        /// 当天号源信息查询
        /// </summary>
        /// <param name="getCurRegInfo"></param>
        /// <returns></returns>
        [HttpPost("getCurRegInfo")]
        public string GetCurRegInfo(request<Entity.SRequest.getCurRegInfo> getCurRegInfo)
        {
            //if (string.IsNullOrWhiteSpace(getCurRegInfoXml))
            //{
            //    return RsXmlHelper.ResXml(-1, "XML不能为空");
            //}

            //var getCurRegInfo = XMLHelper.DESerializer<request<Entity.SRequest.getCurRegInfo>>(getCurRegInfoXml);
            if (getCurRegInfo == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            var gCurRegInfoResult = regTypeBLL.gCurRegInfos(getCurRegInfo.model.deptCode, getCurRegInfo.model.doctorCode, getCurRegInfo.model.beginDate, getCurRegInfo.model.endDate);

            if (gCurRegInfoResult == null || gCurRegInfoResult.Count <= 0)
            {
                return XMLHelper.XmlSerialize(new response<Entity.SResponse.getCurRegInfo>()
                {
                    model = new Entity.SResponse.getCurRegInfo()
                    {
                        resultCode = 1,
                        resultMessage = "暂无号源数据",
                    }
                });
            }
            return XMLHelper.XmlSerialize(new response<Entity.SResponse.getCurRegInfo>()
            {
                model = new Entity.SResponse.getCurRegInfo()
                {
                    resultCode = 0,
                    resultMessage = "",
                    item = gCurRegInfoResult
                }
            });
        }

        /// <summary>
        /// 医生当天分时查询
        /// </summary>
        /// <param name="getCurDocTimeInfo"></param>
        /// <returns></returns>
        [HttpPost("getCurDocTime")]
        public string GetCurDocTime(request<Entity.SRequest.getCurDocTime> getCurDocTimeInfo)
        {
            //if (string.IsNullOrWhiteSpace(getCurDocTimeXml))
            //{
            //    return RsXmlHelper.ResXml(-1, "XML不能为空");
            //}

            //var getCurDocTimeInfo = XMLHelper.DESerializer<request<Entity.SRequest.getCurDocTime>>(getCurDocTimeXml);
            if (getCurDocTimeInfo == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            var obj = regManageBLL.GetCDocTimeItems(getCurDocTimeInfo.model.deptCode, getCurDocTimeInfo.model.doctorCode, Convert.ToInt32(getCurDocTimeInfo.model.timeFlag));

            return XMLHelper.XmlSerialize(new response<Entity.SResponse.getCurDocTime>()
            {
                model = new Entity.SResponse.getCurDocTime()
                {
                    resultCode = 0,
                    resultMessage = "",
                    item = obj
                }
            });
        }

        /// <summary>
        /// 当天挂号  （ 当天挂号 ）
        /// </summary>
        /// <param name="orderCurRegInfo"></param>
        /// <returns></returns>
        [HttpPost("orderCurReg")]
        public string OrderCurReg(request<Entity.SRequest.orderCurReg> orderCurRegInfo)
        {
            if (orderCurRegInfo == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            reg_arrange reg_Arrange = null;
            pt_info pt_Info = null;
            var dept = new sys_dept();
            var doctor = new sys_userinfo();

            if (!string.IsNullOrWhiteSpace(orderCurRegInfo.model.workId))
            {
                reg_Arrange = regArrangeBLL.GetReg_Arrange(Convert.ToInt32(orderCurRegInfo.model.workId));
            }
            else
            {
                dept = sysDeptBLL.GetDeptByCode(orderCurRegInfo.model.deptCode);
                doctor = sysUserinfoBLL.GetRDoctor(orderCurRegInfo.model.doctorCode);
                reg_Arrange = regArrangeBLL.GetReg_Arrange(dept.name, doctor.username, orderCurRegInfo.model.beginTime, orderCurRegInfo.model.endTime, Convert.ToInt32(orderCurRegInfo.model.timeFlag));
            }
            var feetype = "";
            if (!string.IsNullOrWhiteSpace(orderCurRegInfo.model.SSCardNumber) && !string.IsNullOrWhiteSpace(orderCurRegInfo.model.SSCodeId))
            {
                feetype = "医疗保险";
                if (string.IsNullOrWhiteSpace(orderCurRegInfo.model.SSPwd))
                {
                    orderCurRegInfo.model.SSPwd = "000000";
                }
                pt_Info = ptInfoBLL.GetPt_Info(x => x.yno == orderCurRegInfo.model.SSCardNumber);
                if (pt_Info == null)
                {
                    pt_Info = ptInfoBLL.GetPt_Info(x => x.cno == orderCurRegInfo.model.patCardNo || x.idno == orderCurRegInfo.model.patCardNo);
                }
            }
            else
            {
                feetype = "自费";
                pt_Info = ptInfoBLL.GetPt_Info(x => x.cno == orderCurRegInfo.model.patCardNo || x.idno == orderCurRegInfo.model.patCardNo);
            }



            var regInfo = reginfoBLL.Get(x => x.doctor == doctor.username && x.dept == dept.name && pt_Info.pid == x.pid && x.status == "候诊" && x.validate > DateTime.Now);
            if (regInfo != null)
            {
                return RsXmlHelper.ResXml(-1, "你已挂当前科室号");
            }

            var reg_Info = reginfoBLL.Add(new reg_info()
            {
                feetype = feetype
            }, pt_Info, reg_Arrange, orderCurRegInfo.model.orderNo, out decimal amount, out int mzno, out int feeid, out List<comm_fee> commFees);

            if (reg_Info == null)
            {
                return RsXmlHelper.ResXml(99, "挂号失败");
            }

            if (feetype == "医疗保险")
            {
                var regtrialId = regTrialBLL.AddReturnId(new reg_trial()
                {
                    akc190 = "HZS10" + mzno,
                    aaz500 = orderCurRegInfo.model.SSCodeId,
                    bzz269 = orderCurRegInfo.model.SSPwd,
                    aka130 = "11",
                    akf001 = dept.ybno,
                    bkc368 = CodeConvertUtils.SwichRegType(reg_Arrange.regtype).ToString(),
                    bke384 = "HZS10" + DateTime.Now.ToString("yyyyMMdd") + feeid,
                    akc264 = commFees.Sum(x => x.prices),
                    regid = reg_Info.regid
                });

                List<reg_trialdetail> reg_Trialdetails = new List<reg_trialdetail>();
                foreach (var commFee in commFees)
                {
                    reg_Trialdetails.Add(new reg_trialdetail()
                    {
                        regtrialid = regtrialId,
                        aae072 = commKeyBLL.GetYBDJH().ToString(),
                        bkf500 = commKeyBLL.GetYBXLH().ToString(),
                        ake001 = commFee.scode,
                        ake005 = commFee.itemid,
                        ake006 = commFee.itemname,
                        aae019 = commFee.prices
                    });
                }
                regTrialdetailBLL.Adds(reg_Trialdetails);
            }

            return XMLHelper.XmlSerialize(new response<Entity.SResponse.orderCurReg>()
            {
                model = new Entity.SResponse.orderCurReg()
                {
                    resultCode = 0,
                    resultMessage = "",
                    hisOrdNum = reg_Info.regid.ToString(),
                    treatFee = amount.ToString()
                }
            });
        }

        /// <summary>
        /// 当天挂号支付 （当天挂号,含社保）
        /// </summary>
        /// <param name="payCurReg"></param>
        /// <returns></returns>
        [HttpPost("payCurReg")]
        public string PayCurReg(request<Entity.SRequest.payCurReg> payCurReg)
        {
            if (payCurReg == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            string floor = "";
            //if (payCurReg.model.payMethod == "1") //自费
            //{
            var regInfo = reginfoBLL.GetReg_Info(Convert.ToInt32(payCurReg.model.hisOrdNum));
            if (regInfo == null)
            {
                return RsXmlHelper.ResXml(99, "挂号信息为空");
            }

            var fee_info = feeinfoBLL.GetFee_InfoByRegInfo(Convert.ToInt32(payCurReg.model.hisOrdNum));

            fee_info.del = false;
            fee_info.addtime = payCurReg.model.payTime == null ? DateTime.Now : Convert.ToDateTime(payCurReg.model.payTime);
            fee_info.amountrec = Convert.ToDecimal(payCurReg.model.payAmout) / 100;
            fee_info.amountcol = Convert.ToDecimal(payCurReg.model.payAmout) / 100;
            fee_info.extern_memo = "hisOrdNum:" + payCurReg.model.hisOrdNum + ",psOrdNum:" + payCurReg.model.psOrdNum + ",agtOrdNum:" + payCurReg.model.agtOrdNum + ",agtCode:" + payCurReg.model.agtCode + ",payMode:" + payCurReg.model.payMode + ",payMethod:" + payCurReg.model.payMethod + ",payAmout:" + Convert.ToDecimal(payCurReg.model.payAmout) / 100 + ",payTime:" + payCurReg.model.payTime + (!string.IsNullOrWhiteSpace(payCurReg.model.SSSerialNo) ? "，自费金额：" + (Convert.ToDecimal(payCurReg.model.payAmout) - Convert.ToDecimal(payCurReg.model.SSMoney)) + "。" : "。");

            var feeinfodetails = feeInfodetailBLL.GetFee_Infodetails(fee_info.feeid);
            feeInfodetailBLL.Updates(feeinfodetails);

            regInfo.del = false;
            reginfoBLL.UpdateRegInfo(regInfo);
            floor = sysDeptBLL.GetFloorByName(regInfo.dept);

            feeinfoBLL.Update(fee_info);

            if ((Convert.ToDecimal(payCurReg.model.payAmout) - Convert.ToDecimal(payCurReg.model.SSMoney)) > 0)
            {
                feeinfoBLL.AddFeechannel(new fee_channel()
                {
                    feeid = fee_info.feeid,
                    chnn = payCurReg.model.payMode,
                    amount = (Convert.ToDecimal(payCurReg.model.payAmout) - Convert.ToDecimal(payCurReg.model.SSMoney)) / 100,
                    del = false,
                    sno = payCurReg.model.psOrdNum
                });
            }

            if (payCurReg.model.payMethod == "2")//医保
            {
                feeinfoBLL.AddFeechannel(new fee_channel()
                {
                    feeid = fee_info.feeid,
                    chnn = "医疗保险",
                    amount = Convert.ToDecimal(payCurReg.model.SSMoney) / 100,
                    del = false,
                    sno = payCurReg.model.SSSerialNo
                });
            }
            //}
            //else //医保
            //{

            //}

            return XMLHelper.XmlSerialize(new response<Entity.SResponse.payCurReg>()
            {
                model = new Entity.SResponse.payCurReg()
                {
                    resultCode = 0,
                    resultMessage = "",
                    visitLocation = floor
                }
            });
        }

        /// <summary>
        /// 取消当天挂号 （ 当天挂号 ）
        /// </summary>
        /// <param name="cancelCurReg"></param>
        /// <returns></returns>
        [HttpPost("cancelCurReg")]
        public string CancelCurReg(request<cancelCurReg> cancelCurReg)
        {
            //if (string.IsNullOrWhiteSpace(cancelCurRegXML))
            //{
            //    return RsXmlHelper.ResXml(-1, "XML不能为空");
            //}

            //var cancelCurReg = XMLHelper.DESerializer<request<cancelCurReg>>(cancelCurRegXML);
            if (cancelCurReg == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            var regInfo = reginfoBLL.GetReg_Info(Convert.ToInt32(cancelCurReg.model.hisOrdNum));
            if (regInfo == null)
            {
                return RsXmlHelper.ResXml(99, "挂号信息不存在");
            }

            regArrangeBLL.UpdateRegNoZero(Convert.ToInt32(regInfo.argid));
            feeinfoBLL.DeleteFeeInfoByRegid(regInfo.regid, cancelCurReg.model.psOrdNum);
            reginfoBLL.DeleteReginfo(regInfo.regid);

            //return XMLHelper.XmlSerialize(new response<Entity.SResponse>)
            return RsXmlHelper.ResXml(0, "取消挂号成功");
        }

        /// <summary>
        /// 医保门诊预结算
        /// </summary>
        /// <param name="getClinicalTrial"></param>
        /// <returns></returns>
        [HttpPost("getMZInsurance")]
        public string GetMZInsurance(request<getClinicalTrial> getClinicalTrial)
        {
            #region 废弃
            //if (string.IsNullOrWhiteSpace(trialCalculationXML))
            //{
            //    return RsXmlHelper.ResXml(-1, "XML不能为空");
            //}

            //var getMZinsu = XMLHelper.DESerializer<request<Entity.SRequest.getMZInsurance>>(trialCalculationXML);
            //if (getMZinsu == null)
            //{
            //    return RsXmlHelper.ResXml(-1, "XML格式错误");
            //}

            //var ptInfo = ptInfoBLL.GetPtInfoByCardNo("", getMZinsu.model.patCardType, getMZinsu.model.patCardNo);
            //if (ptInfo == null)
            //{
            //    return RsXmlHelper.ResXml(99, "找不到患者信息");
            //}

            //var feeInfo = feeinfoBLL.GetFee_Info(getMZinsu.model.mzFeeId);
            //if (feeInfo == null)
            //{
            //    return RsXmlHelper.ResXml(99, "无挂号记录");
            //}

            //var regInfo = reginfoBLL.GetReg_Info(Convert.ToInt32(feeInfo.regid));
            //if (regInfo == null)
            //{
            //    return RsXmlHelper.ResXml(99, "无挂号记录");
            //}

            //var itemid = regArrangeBLL.GetItemIdByRegno(regInfo.regid);
            //var commFee = commFeeBLL.GetComm_Fee_Views(itemid);
            //var mzModel001 = feeinfoBLL.GetTrialData(regInfo.regid);

            //inputlist5 inputlist5 = new inputlist5()
            //{
            //    aae072 = regInfo.regid.ToString(),
            //    bkf500 = regInfo.regid.ToString(),
            //    ake001 = commFee.Fccode,
            //    ake005 = commFee.Fitemid,
            //    ake006 = commFee.Fitemname,
            //    aae019 = commFee.Fprices.ToString()
            //};
            //mzModel001.akc264 = inputlist5.aae019;
            //mzModel001.inputlist = new System.Collections.Generic.List<inputlist5>()
            //{
            //    inputlist5
            //};
            //HealthInsuranceHelper.Trial("MZ001", "", "", "", inputlist5); 
            #endregion
            if (getClinicalTrial == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            var reg_Trial = regTrialBLL.Get(Convert.ToInt32(getClinicalTrial.model.hisOrdNum));
            var reg_trialDetails = regTrialdetailBLL.GetList(reg_Trial.id);

            #region 废弃代码
            //reg_arrange reg_Arrange = new reg_arrange();
            //var dept = new sys_dept();
            //var doctor = new sys_userinfo();
            //if (!string.IsNullOrWhiteSpace(getClinicalTrial.model.workId))
            //{
            //    reg_Arrange = regArrangeBLL.GetReg_Arrange(Convert.ToInt32(getClinicalTrial.model.workId));
            //}
            //else
            //{
            //    dept = sysDeptBLL.GetDeptByCode(getClinicalTrial.model.deptCode);
            //    doctor = sysUserinfoBLL.GetRDoctor(getClinicalTrial.model.doctorCode);
            //    reg_Arrange = regArrangeBLL.GetReg_Arrange(dept.name, doctor.username, getClinicalTrial.model.beginTime, getClinicalTrial.model.endTime, Convert.ToInt32(getClinicalTrial.model.timeFlag));
            //}
            //if (reg_Arrange == null)
            //{
            //    return RsXmlHelper.ResXml(-1, "号源信息为空");
            //}

            //var commFees = commFeeBLL.GetComm_Fee_Views(Convert.ToInt32(reg_Arrange.itemid));

            //var mzno = commKeyBLL.GetMZNO(); 
            #endregion
            var mz001 = new Entity.SRequest.MZ001()
            {
                akc190 = reg_Trial.akc190,
                aaz500 = reg_Trial.aaz500,
                alc005 = reg_Trial.alc005,
                aka130 = reg_Trial.aka130,
                akf001 = reg_Trial.akf001,
                bkc368 = reg_Trial.bkc368,
                akc264 = reg_Trial.akc264.ToString(),
                listsize = reg_trialDetails.Count.ToString()
            };

            mz001.inputlist = new List<Entity.SRequest.inputlist5>();
            foreach (var reg_Trialdetail in reg_trialDetails)
            {
                var inputlist5 = new inputlist5()
                {
                    aae072 = reg_Trialdetail.aae072,
                    bkf500 = reg_Trialdetail.bkf500,
                    ake001 = reg_Trialdetail.ake001,
                    ake005 = reg_Trialdetail.ake005,
                    ake006 = reg_Trialdetail.ake006,
                    aae019 = reg_Trialdetail.aae019.ToString()
                };
                mz001.inputlist.Add(inputlist5);
            }


            var ybsssno = commKeyBLL.GetYBNO();

            var ybSno = "HZS10" + DateTime.Now.ToString("yyyyMMdd") + ybsssno;
            var getVerifyCodeResult = JsonOperator.JsonDeserialize<Entity.SResponse.getVerifyCode>(HttpHelper.Post("http://192.168.88.134:8300/YBDLL/domain/getVerifyCode", JsonOperator.JsonSerialize(new getVerifyCode() { inParam = "XX001|" + ybSno + "|HZS10|" }), Encoding.UTF8, 1));
            if (getVerifyCodeResult.resultCode != 0)
            {
                return null;
            }

            var version = getVerifyCodeResult.outParam.Split("|")[2];
            var verify = getVerifyCodeResult.outParam.Split("|")[0] + "|" + getVerifyCodeResult.outParam.Split("|")[1];
            var result = HealthInsuranceHelper.RegTrial<Entity.SResponse.pre_settlement>("MZ001", version, verify, ybsssno.ToString(), mz001);
            if (result.transReturnCode == "0" || result.transReturnCode == "00000000")
            {
                //reg_Trials.ForEach(x => x.serialNumber = result.serialNumber);
                //regTrialBLL.Adds(reg_Trials);
                return XMLHelper.XmlSerialize(new response<Entity.SResponse.getClinicalTrial>()
                {
                    model = new Entity.SResponse.getClinicalTrial()
                    {
                        resultCode = 0,
                        resultMessage = JsonOperator.JsonSerialize(result.transBody),
                        SSSerNum = ybSno
                    }
                });
            }
            else
            {
                return RsXmlHelper.ResXml(-1, result.transReturnMessage);
            }
        }

        /// <summary>
        /// 门诊医保挂号结算
        /// </summary>
        /// <param name="getRegSettlement"></param>
        /// <returns></returns>
        [HttpPost("getRegSettlement")]
        public string GetRegSettlement(request<getRegSettlement> getRegSettlement)
        {
            if (getRegSettlement == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            var reg_Trial = regTrialBLL.Get(Convert.ToInt32(getRegSettlement.model.hisOrdNum));
            var reg_trialDetails = regTrialdetailBLL.GetList(reg_Trial.id);

            MZ002 mZ002 = new MZ002()
            {
                akc190 = reg_Trial.akc190,
                aaz500 = reg_Trial.aaz500,
                bzz269 = reg_Trial.bzz269,
                alc005 = reg_Trial.alc005,
                aka130 = reg_Trial.aka130,
                akf001 = reg_Trial.akf001,
                bkc368 = reg_Trial.bkc368,
                aka120 = reg_Trial.aka120,
                akc188 = reg_Trial.akc188,
                akc189 = reg_Trial.akc189,
                bke384 = reg_Trial.bke384,
                akc264 = Convert.ToDecimal(reg_Trial.akc264),
                listsize = reg_trialDetails.Count
            };
            mZ002.inputlist = new List<inputlist>();
            foreach (var reg_Trialdetail in reg_trialDetails)
            {
                mZ002.inputlist.Add(new inputlist()
                {
                    aae072 = reg_Trialdetail.aae072,
                    bkf500 = reg_Trialdetail.bkf500,
                    ake001 = reg_Trialdetail.ake001,
                    ake005 = reg_Trialdetail.ake005,
                    ake006 = reg_Trialdetail.ake006,
                    aae019 = Convert.ToDecimal(reg_Trialdetail.aae019)
                });
            }

            var ybsssno = commKeyBLL.GetYBNO();

            var ybSno = "HZS10" + DateTime.Now.ToString("yyyyMMdd") + ybsssno;
            var getVerifyCodeResult = JsonOperator.JsonDeserialize<Entity.SResponse.getVerifyCode>(HttpHelper.Post("http://192.168.88.134:8300/YBDLL/domain/getVerifyCode", JsonOperator.JsonSerialize(new getVerifyCode() { inParam = "XX001|" + ybSno + "|HZS10|" }), Encoding.UTF8, 1));
            if (getVerifyCodeResult.resultCode != 0)
            {
                return null;
            }

            var version = getVerifyCodeResult.outParam.Split("|")[2];
            var verify = getVerifyCodeResult.outParam.Split("|")[0] + "|" + getVerifyCodeResult.outParam.Split("|")[1];
            var result = HealthInsuranceHelper.RegTrial<BaseMedInsurance<Entity.SResponse.MZ002>>("MZ002", version, verify, ybsssno.ToString(), mZ002);

            return result.transReturnCode == "0" || result.transReturnCode == "00000000"
                ? RsXmlHelper.ResXml(0, JsonOperator.JsonSerialize(result.transBody))
                : RsXmlHelper.ResXml(99, result.transReturnMessage);
        }

        /// <summary>
        /// 交易退费
        /// </summary>
        /// <param name="tradingrefund"></param>
        /// <returns></returns>
        [HttpPost("tradingrefund")]
        public string TradingRefund(request<Entity.SRequest.JY002> tradingrefund)
        {
            var ybsssno = commKeyBLL.GetYBNO();
            var ybSno = "HZS10" + DateTime.Now.ToString("yyyyMMdd") + ybsssno;

            var getVerifyCodeResult = JsonOperator.JsonDeserialize<Entity.SResponse.getVerifyCode>(HttpHelper.Post("http://192.168.88.134:8300/YBDLL/domain/getVerifyCode", JsonOperator.JsonSerialize(new getVerifyCode() { inParam = "JY002|" + ybSno + "|HZS10|" }), Encoding.UTF8, 1));
            if (getVerifyCodeResult.resultCode != 0)
            {
                return null;
            }

            var version = getVerifyCodeResult.outParam.Split("|")[2];
            var verify = getVerifyCodeResult.outParam.Split("|")[0] + "|" + getVerifyCodeResult.outParam.Split("|")[1];
            Entity.SRequest.JY002 jY002 = new JY002()
            {
                akc190 = tradingrefund.model.akc190,
                bke384 = tradingrefund.model.bke384
            };

            var result = HealthInsuranceHelper.RegTrial<BaseMedInsurance<Entity.SResponse.JY002>>("JY002", version, verify, ybsssno.ToString(), jY002);
            if (result.transReturnCode == "0" || result.transReturnCode == "00000000")
            {
                return XMLHelper.XmlSerialize(new response<Entity.SResponse.JY002>()
                {
                    model = new Entity.SResponse.JY002()
                    {
                        resultCode = 0,
                        resultMessage = JsonOperator.JsonSerialize(result)
                    }
                });
            }
            else
            {
                return RsXmlHelper.ResXml(-1, JsonOperator.JsonSerialize(result));
            }
        }
    }
}