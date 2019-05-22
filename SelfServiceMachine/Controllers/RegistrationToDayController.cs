using System;
using Microsoft.AspNetCore.Mvc;
using SelfServiceMachine.Bussiness;
using SelfServiceMachine.Common;
using SelfServiceMachine.Entity;
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
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "XML不能为空"
                });
            }

            var getCurRegInfo = XMLHelper.DESerializer<Entity.SlefServiceModels.getCurRegInfo>(getCurRegInfoXml);
            if (getCurRegInfo == null)
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "XML格式错误"
                });
            }

            var gCurRegInfoResult = regTypeBLL.gCurRegInfos(getCurRegInfo.deptCode, getCurRegInfo.doctorCode, getCurRegInfo.beginDate, getCurRegInfo.endDate);

            return XMLHelper.XmlSerialize(new getCurRegInfo()
            {
                resultCode = 0,
                resultMessage = "",
                item = gCurRegInfoResult
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
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "XML不能为空"
                });
            }

            var getCurDocTimeInfo = XMLHelper.DESerializer<Entity.SlefServiceModels.getCurDocTime>(getCurDocTimeXml);
            if (getCurDocTimeInfo == null)
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "XML格式错误"
                });
            }

            var obj = regManageBLL.GetCDocTimeItems(getCurDocTimeInfo.deptCode, getCurDocTimeInfo.doctorCode, Convert.ToInt32(getCurDocTimeInfo.timeFlag));

            return XMLHelper.XmlSerialize(new getCurDocTime()
            {
                resultCode = 0,
                resultMessage = "",
                item = obj
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
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "XML不能为空"
                });
            }

            var orderCurRegInfo = XMLHelper.DESerializer<Entity.SlefServiceModels.orderCurReg>(orderCurRegXML);
            if (orderCurRegInfo == null)
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "XML格式错误"
                });
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
        [HttpPost("trialCalculation")]
        public string TrialCalculation(string trialCalculationXML)
        {
            return null;
        }
    }
}