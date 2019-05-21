using System;
using Microsoft.AspNetCore.Mvc;
using SelfServiceMachine.Bussiness;
using SelfServiceMachine.Common;
using SelfServiceMachine.Models.Response;

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
        /// 号源类型
        /// </summary>
        public RegManageBLL regManageBLL;

        /// <summary>
        /// 构造函数
        /// </summary>
        public RegistrationToDayController()
        {
            regTypeBLL = new RegTypeBLL();
            regManageBLL = new RegManageBLL();
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
    }
}