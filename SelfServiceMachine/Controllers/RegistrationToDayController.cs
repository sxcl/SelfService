using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using SelfServiceMachine.Bussiness;
using SelfServiceMachine.Common;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.Insurance;
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
            //if (string.IsNullOrWhiteSpace(orderCurRegXML))
            //{
            //    return RsXmlHelper.ResXml(-1, "XML不能为空");
            //}

            //var orderCurRegInfo = XMLHelper.DESerializer<request<Entity.SRequest.orderCurReg>>(orderCurRegXML);
            if (orderCurRegInfo == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            reg_arrange reg_Arrange = null;
            pt_info pt_Info = null;
            if (!string.IsNullOrWhiteSpace(orderCurRegInfo.model.workId))
            {
                reg_Arrange = regArrangeBLL.GetReg_Arrange(Convert.ToInt32(orderCurRegInfo.model.workId));
            }
            else
            {
                var dept = sysDeptBLL.GetDeptByCode(orderCurRegInfo.model.deptCode);
                var doctor = sysUserinfoBLL.GetRDoctor(orderCurRegInfo.model.doctorCode);
                reg_Arrange = regArrangeBLL.GetReg_Arrange(dept.name, doctor.username, orderCurRegInfo.model.beginTime, orderCurRegInfo.model.endTime, Convert.ToInt32(orderCurRegInfo.model.timeFlag));
            }
            var feetype = "";
            if (!string.IsNullOrWhiteSpace(orderCurRegInfo.model.SSCblx) && !string.IsNullOrWhiteSpace(orderCurRegInfo.model.SSCardNumber) && !string.IsNullOrWhiteSpace(orderCurRegInfo.model.SSComputerNumber) && !string.IsNullOrWhiteSpace(orderCurRegInfo.model.SSCodeId) && !string.IsNullOrWhiteSpace(orderCurRegInfo.model.SShylx) && !string.IsNullOrWhiteSpace(orderCurRegInfo.model.SSPwd))
            {
                feetype = "医疗保险";
                pt_Info = ptInfoBLL.GetPt_Info(x => x.yno == orderCurRegInfo.model.SSComputerNumber);
            }
            else
            {
                feetype = "自费";
                pt_Info = ptInfoBLL.GetPt_Info(x => x.cno == orderCurRegInfo.model.patCardNo || x.idno == orderCurRegInfo.model.patCardNo);
            }

            var reg_Info = reginfoBLL.Add(new reg_info()
            {
                feetype = feetype
            }, pt_Info, reg_Arrange, orderCurRegInfo.model.orderNo, out decimal amount);
            if (reg_Info == null)
            {
                return RsXmlHelper.ResXml(99, "挂号失败");
            }
            else
            {
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
        }

        /// <summary>
        /// 当天挂号支付 （当天挂号,含社保）
        /// </summary>
        /// <param name="payCurReg"></param>
        /// <returns></returns>
        [HttpPost("payCurReg")]
        public string PayCurReg(request<Entity.SRequest.payCurReg> payCurReg)
        {
            //if (string.IsNullOrWhiteSpace(payCurRegXML))
            //{
            //    return RsXmlHelper.ResXml(-1, "XML不能为空");
            //}

            //var payCurReg = XMLHelper.DESerializer<request<Entity.SRequest.payCurReg>>(payCurRegXML);
            if (payCurReg == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            string floor = "";
            if (payCurReg.model.payMethod == "1") //自费
            {
                var regInfo = reginfoBLL.GetReg_Info(Convert.ToInt32(payCurReg.model.hisOrdNum));
                if (regInfo == null)
                {
                    return RsXmlHelper.ResXml(99, "挂号信息为空");
                }

                var fee_info = feeinfoBLL.GetFee_InfoByRegInfo(Convert.ToInt32(payCurReg.model.hisOrdNum));

                fee_info.del = false;
                fee_info.addtime = Convert.ToDateTime(payCurReg.model.payTime);
                fee_info.amountrec = Convert.ToDecimal(payCurReg.model.payAmout) / 100;
                fee_info.amountcol = Convert.ToDecimal(payCurReg.model.payAmout) / 100;
                fee_info.extern_memo = "hisOrdNum:" + payCurReg.model.hisOrdNum + ",psOrdNum:" + payCurReg.model.psOrdNum + ",agtOrdNum:" + payCurReg.model.agtOrdNum + ",agtCode:" + payCurReg.model.agtCode + ",payMode:" + payCurReg.model.payMode + ",payMethod:" + payCurReg.model.payMethod + ",payAmout:" + Convert.ToDecimal(payCurReg.model.payAmout) / 100 + ",payTime:" + payCurReg.model.payTime;

                var feeinfodetails = feeInfodetailBLL.GetFee_Infodetails(fee_info.feeid);
                feeinfodetails.ForEach(x => x.del = false);
                feeInfodetailBLL.Updates(feeinfodetails);

                regInfo.del = false;
                reginfoBLL.UpdateRegInfo(regInfo);
                floor = sysDeptBLL.GetFloorByName(regInfo.dept);

                feeinfoBLL.Update(fee_info);
                feeinfoBLL.AddFeechannel(new fee_channel()
                {
                    feeid = fee_info.feeid,
                    chnn = payCurReg.model.payMode,
                    amount = Convert.ToDecimal(payCurReg.model.payAmout) / 100,
                    del = false,
                    sno = payCurReg.model.psOrdNum
                });
            }
            else //医保
            {

            }

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

            reg_arrange reg_Arrange = new reg_arrange();
            var dept = new sys_dept();
            var doctor = new sys_userinfo();
            if (!string.IsNullOrWhiteSpace(getClinicalTrial.model.workId))
            {
                reg_Arrange = regArrangeBLL.GetReg_Arrange(Convert.ToInt32(getClinicalTrial.model.workId));
            }
            else
            {
                dept = sysDeptBLL.GetDeptByCode(getClinicalTrial.model.deptCode);
                doctor = sysUserinfoBLL.GetRDoctor(getClinicalTrial.model.doctorCode);
                reg_Arrange = regArrangeBLL.GetReg_Arrange(dept.name, doctor.username, getClinicalTrial.model.beginTime, getClinicalTrial.model.endTime, Convert.ToInt32(getClinicalTrial.model.timeFlag));
            }
            if (reg_Arrange == null)
            {
                return RsXmlHelper.ResXml(-1, "号源信息为空");
            }

            var commFees = commFeeBLL.GetComm_Fee_Views(Convert.ToInt32(reg_Arrange.itemid));

            var mzno = commKeyBLL.GetMZNO();
            var mz001 = new Entity.SRequest.MZ001()
            {
                akc190 = "HZS10" + mzno,
                aaz500 = getClinicalTrial.model.SSCardNumber,
                alc005 = "",
                aka130 = "11",
                akf001 = dept.ybno,
                bkc368 = "1",
                akc264 = commFees.Sum(x => x.prices).ToString(),
                listsize = commFees.Count.ToString()
            };
            mz001.inputlist = new System.Collections.Generic.List<Entity.SRequest.inputlist5>();
            List<reg_trial> reg_Trials = new List<reg_trial>();
            foreach (var commFee in commFees)
            {
                var inputlist5 = new Entity.SRequest.inputlist5()
                {
                    aae072 = commKeyBLL.GetYBDJH().ToString(),
                    bkf500 = commKeyBLL.GetYBXLH().ToString(),
                    ake001 = commFee.scode,
                    ake005 = commFee.itemid,
                    ake006 = commFee.itemname,
                    aae019 = commFee.prices.ToString()
                };
                mz001.inputlist.Add(inputlist5);
                reg_Trials.Add(new reg_trial()
                {
                    aae072 = inputlist5.aae072,
                    bkf500 = inputlist5.bkf500,
                    ake001 = inputlist5.ake001,
                    ake005 = inputlist5.ake005,
                    ake006 = inputlist5.ake006,
                    aae019 = Convert.ToDecimal(inputlist5.aae019),
                    mzno = mzno,
                    addtime = DateTime.Now
                });
            }


            var ybsssno = commKeyBLL.GetYBNO();

            var ybSno = "HZS10" + DateTime.Now.ToString("yyyyMMdd") + ybsssno;
            var getVerifyCodeResult = JsonOperator.JsonDeserialize<Entity.SResponse.getVerifyCode>(HttpHelper.Post("http://192.168.88.134:8300/YBDLL/domain/getVerifyCode", JsonOperator.JsonSerialize(new getVerifyCode() { inParam = "XX001|" + ybSno + "|H1110|" }), Encoding.UTF8, 1));
            if (getVerifyCodeResult.resultCode != 0)
            {
                return null;
            }

            var version = getVerifyCodeResult.outParam.Split("|")[2];
            var verify = getVerifyCodeResult.outParam.Split("|")[0] + "|" + getVerifyCodeResult.outParam.Split("|")[1];
            var result = HealthInsuranceHelper.RegTrial("MZ001", version, verify, ybsssno.ToString(), mz001);
            if (result.transReturnCode == "0")
            {
                reg_Trials.ForEach(x => x.serialNumber = result.serialNumber);
                regTrialBLL.Adds(reg_Trials);
                return RsXmlHelper.ResXml(0, "医保试算成功");
            }
            else
            {
                return RsXmlHelper.ResXml(-1, result.transReturnMessage);
            }
        }
    }
}