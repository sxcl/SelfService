using System;
using Microsoft.AspNetCore.Mvc;
using SelfServiceMachine.Bussiness;
using SelfServiceMachine.Common;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.Insurance;
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
        }

        /// <summary>
        /// 当天号源信息查询
        /// </summary>
        /// <param name="getCurRegInfoXml"></param>
        /// <returns></returns>
        [HttpGet("getCurRegInfo")]
        public string getCurRegInfo(string getCurRegInfoXml)
        {
            if (string.IsNullOrWhiteSpace(getCurRegInfoXml))
            {
                return RsXmlHelper.ResXml(-1, "XML不能为空");
            }

            var getCurRegInfo = XMLHelper.DESerializer<request<Entity.SRequest.getCurRegInfo>>(getCurRegInfoXml);
            if (getCurRegInfo == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            var gCurRegInfoResult = regTypeBLL.gCurRegInfos(getCurRegInfo.model.deptCode, getCurRegInfo.model.doctorCode, getCurRegInfo.model.beginDate, getCurRegInfo.model.endDate);

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
        /// <param name="getCurDocTimeXml"></param>
        /// <returns></returns>
        [HttpGet("getCurDocTime")]
        public string getCurDocTime(string getCurDocTimeXml)
        {
            if (string.IsNullOrWhiteSpace(getCurDocTimeXml))
            {
                return RsXmlHelper.ResXml(-1, "XML不能为空");
            }

            var getCurDocTimeInfo = XMLHelper.DESerializer<request<Entity.SRequest.getCurDocTime>>(getCurDocTimeXml);
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
        /// <param name="orderCurRegXML"></param>
        /// <returns></returns>
        [HttpPost("orderCurReg")]
        public string orderCurReg(string orderCurRegXML)
        {
            if (string.IsNullOrWhiteSpace(orderCurRegXML))
            {
                return RsXmlHelper.ResXml(-1, "XML不能为空");
            }

            var orderCurRegInfo = XMLHelper.DESerializer<Entity.SlefServiceModels.orderCurReg>(orderCurRegXML);
            if (orderCurRegInfo == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            reg_arrange reg_Arrange = null;
            pt_info pt_Info = null;
            if (orderCurRegInfo.workId != null)
            {
                reg_Arrange = regArrangeBLL.GetReg_Arrange(Convert.ToInt32(orderCurRegInfo.workId));
            }
            else
            {
                var dept = sysDeptBLL.GetDeptByCode(orderCurRegInfo.doctorCode);
                var doctor = sysUserinfoBLL.GetRDoctor(orderCurRegInfo.doctorCode);
                reg_Arrange = regArrangeBLL.GetReg_Arrange(dept.name, doctor.userno);
            }
            var feetype = "";
            if (!string.IsNullOrWhiteSpace(orderCurRegInfo.SSCblx) || !string.IsNullOrWhiteSpace(orderCurRegInfo.SSCardNumber) || !string.IsNullOrWhiteSpace(orderCurRegInfo.SSComputerNumber) || !string.IsNullOrWhiteSpace(orderCurRegInfo.SSCodeId) || !string.IsNullOrWhiteSpace(orderCurRegInfo.SShylx) || !string.IsNullOrWhiteSpace(orderCurRegInfo.SSPwd))
            {
                feetype = "医疗保险";
                pt_Info = ptInfoBLL.GetPt_Info(x => x.yno == orderCurRegInfo.SSComputerNumber);
            }
            else
            {
                feetype = "自费";
                pt_Info = ptInfoBLL.GetPt_Info(x => x.cno == orderCurRegInfo.patCardNo || x.idno == orderCurRegInfo.patCardNo);
            }
            var reg_Info = reginfoBLL.Add(new reg_info()
            {
                feetype = feetype
            }, pt_Info, reg_Arrange);

            return null;
        }

        /// <summary>
        /// 医保挂号试算
        /// </summary>
        /// <param name="trialCalculationXML"></param>
        /// <returns></returns>
        [HttpPost("getMZInsurance")]
        public string getMZInsurance(string trialCalculationXML)
        {
            if (string.IsNullOrWhiteSpace(trialCalculationXML))
            {
                return RsXmlHelper.ResXml(-1, "XML不能为空");
            }

            var getMZinsu = XMLHelper.DESerializer<request<Entity.SRequest.getMZInsurance>>(trialCalculationXML);
            if (getMZinsu == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            var ptInfo = ptInfoBLL.GetPtInfoByCardNo("", getMZinsu.model.patCardType, getMZinsu.model.patCardNo);
            if (ptInfo == null)
            {
                return RsXmlHelper.ResXml(99, "找不到患者信息");
            }

            var feeInfo = feeinfoBLL.GetFee_Info(getMZinsu.model.mzFeeId);
            if (feeInfo == null)
            {
                return RsXmlHelper.ResXml(99, "无挂号记录");
            }

            var regInfo = reginfoBLL.GetReg_Info(Convert.ToInt32(feeInfo.regid));
            if (regInfo == null)
            {
                return RsXmlHelper.ResXml(99, "无挂号记录");
            }

            var itemid = regArrangeBLL.GetItemIdByRegno(regInfo.regid);
            var commFee = commFeeBLL.GetComm_Fee_Views(itemid);
            var mzModel001 = feeinfoBLL.GetTrialData(regInfo.regid);

            inputlist5 inputlist5 = new inputlist5()
            {
                aae072 = regInfo.regid.ToString(),
                bkf500 = regInfo.regid.ToString(),
                ake001 = commFee.Fccode,
                ake005 = commFee.Fitemid,
                ake006 = commFee.Fitemname,
                aae019 = commFee.Fprices.ToString()
            };
            mzModel001.akc264 = inputlist5.aae019;
            mzModel001.inputlist = new System.Collections.Generic.List<inputlist5>()
            {
                inputlist5
            };
            HealthInsuranceHelper.Trial("MZ001", "", "", "", inputlist5);

            return null;
        }
    }
}