using Microsoft.AspNetCore.Mvc;
using SelfServiceMachine.Bussiness;
using SelfServiceMachine.Common;
using SelfServiceMachine.Entity.SlefServiceModels;
using SelfServiceMachine.Models.Response;

namespace SelfServiceMachine.Controllers
{
    /// <summary>
    /// 挂号
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        /// <summary>
        /// 科室业务类
        /// </summary>
        public SysDeptBLL sysDeptBLL;
        /// <summary>
        /// 用户业务类
        /// </summary>
        public SysUserinfoBLL SysUserinfoBLL;
        /// <summary>
        /// 号源业务类
        /// </summary>
        public RegArrangeBLL regArrangeBLL;

        /// <summary>
        /// 构造函数
        /// </summary>
        public RegistrationController()
        {
            sysDeptBLL = new SysDeptBLL();
            SysUserinfoBLL = new SysUserinfoBLL();
            regArrangeBLL = new RegArrangeBLL();
        }

        /// <summary>
        /// 可挂号科室查询（ 当天挂号也可以用  ）
        /// </summary>
        /// <param name="getRegDeptsXML"></param>
        /// <returns></returns>
        [HttpGet("getRegDepts")]
        public string GetRegDepts(string getRegDeptsXML)
        {
            if (string.IsNullOrWhiteSpace(getRegDeptsXML))
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "XML不能为空"
                });
            }

            var getRegDepts = XMLHelper.DESerializer<Entity.SlefServiceModels.GetRegDepts>(getRegDeptsXML);
            if (getRegDepts == null)
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "XML格式错误"
                });
            }

            var deptItems = sysDeptBLL.GetGDeptItems(getRegDepts.parentDeptCode);
            if (deptItems.Count > 0)
            {
                return XMLHelper.XmlSerialize(new Models.Response.GetRegDepts()
                {
                    resultCode = 0,
                    resultMessage = "",
                    item = deptItems
                });
            }
            else
            {
                return XMLHelper.XmlSerialize(new Models.Response.GetRegDepts()
                {
                    resultCode = 1,
                    resultMessage = "暂无数据"
                });
            }
        }

        /// <summary>
        /// 可挂号医生查询（ 当天挂号也可以用  ）
        /// </summary>
        /// <param name="getRegDoctorsXML"></param>
        /// <returns></returns>
        [HttpGet("getRegDoctors")]
        public string getRegDoctors(string getRegDoctorsXML)
        {
            if (string.IsNullOrWhiteSpace(getRegDoctorsXML))
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "XML不能为空"
                });
            }

            var GetRegDoctors = XMLHelper.DESerializer<GetRegDoctors>(getRegDoctorsXML);
            if (GetRegDoctors == null)
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "XML格式错误"
                });
            }

            var itemList = SysUserinfoBLL.GetRDoctorItems(GetRegDoctors.doctorCode);
            if (itemList.Count > 0)
            {
                return XMLHelper.XmlSerialize(new Models.Response.getRegDoctors()
                {
                    resultCode = 0,
                    resultMessage = "",
                    item = itemList
                });
            }
            else
            {
                return XMLHelper.XmlSerialize(new Models.Response.getRegDoctors()
                {
                    resultCode = 1,
                    resultMessage = "暂无数据"
                });
            }
        }

        /// <summary>
        /// 科室号源信息查询
        /// </summary>
        /// <param name="getDeptRegXML"></param>
        /// <returns></returns>
        [HttpGet("getDeptReg")]
        public string getDeptReg(string getDeptRegXML)
        {
            if (string.IsNullOrWhiteSpace(getDeptRegXML))
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "XML不能为空"
                });
            }

            var getDeptReg = XMLHelper.DESerializer<GetDeptReg>(getDeptRegXML);
            if (getDeptReg == null)
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = 99,
                    resultMessage = "XML格式错误"
                });
            }

            var dept = sysDeptBLL.GetDeptByCode(getDeptReg.deptCode);
            if (dept == null)
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = 99,
                    resultMessage = "科室code不存在"
                });
            }
            var regarrList = regArrangeBLL.GetDeptRegItems(dept.name, getDeptReg.beginDate, getDeptReg.endDate);
            if (regarrList.Count > 0)
            {
                return XMLHelper.XmlSerialize(new Models.Response.getDeptReg()
                {
                    resultCode = 0,
                    resultMessage = "",
                    item = regarrList
                });
            }
            else
            {
                return XMLHelper.XmlSerialize(new Models.Response.getDeptReg()
                {
                    resultCode = 1,
                    resultMessage = "数据为空"
                });
            }
        }
    }
}