using Microsoft.AspNetCore.Mvc;
using SelfServiceMachine.Bussiness;
using SelfServiceMachine.Common;
using SelfServiceMachine.Models.Request;
using SelfServiceMachine.Models.Response;
using SelfServiceMachine.Utils;
using SelfServiceMachine.Entity.SRequest;

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
        /// <param name="getRegDepts"></param>
        /// <returns></returns>
        [HttpPost("getRegDepts")]
        public string GetRegDepts(request<getRegDepts> getRegDepts)
        {
            //if (string.IsNullOrWhiteSpace(getRegDeptsXML))
            //{
            //    return RsXmlHelper.ResXml(-1, "XML不能为空");
            //}

            //var getRegDepts = XMLHelper.DESerializer<request<getRegDepts>>(getRegDeptsXML);
            if (getRegDepts == null)
            {
                return RsXmlHelper.ResXml("-1", "XML格式错误");
            }

            var deptItems = sysDeptBLL.GetGDeptItems(getRegDepts.model.parentDeptCode);
            if (deptItems.Count > 0)
            {
                return XMLHelper.XmlSerialize(new response<Entity.SResponse.getRegDepts>()
                {
                    model = new Entity.SResponse.getRegDepts()
                    {
                        resultCode = 0,
                        resultMessage = "",
                        item = deptItems
                    }
                });
            }
            else
            {
                return RsXmlHelper.ResXml("-1", "暂无数据");
            }
        }

        /// <summary>
        /// 可挂号医生查询（ 当天挂号也可以用  ）
        /// </summary>
        /// <param name="GetRegDoctors"></param>
        /// <returns></returns>
        [HttpPost("getRegDoctors")]
        public string GetRegDoctors(request<Entity.SRequest.getRegDoctors> GetRegDoctors)
        {
            //if (string.IsNullOrWhiteSpace(getRegDoctorsXML))
            //{
            //    return RsXmlHelper.ResXml(-1, "XML不能为空");
            //}

            //var GetRegDoctors = XMLHelper.DESerializer<request<Entity.SRequest.getRegDoctors>>(getRegDoctorsXML);
            if (GetRegDoctors == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            var itemList = SysUserinfoBLL.GetRDoctorItems(GetRegDoctors.model.deptCode);
            if (itemList.Count > 0)
            {
                return XMLHelper.XmlSerialize(new response<Entity.SResponse.getRegDoctors>()
                {
                    model = new Entity.SResponse.getRegDoctors()
                    {
                        resultCode = 0,
                        resultMessage = "",
                        item = itemList
                    }
                });
            }
            else
            {
                return RsXmlHelper.ResXml(-1, "暂无数据");
            }
        }

        /// <summary>
        /// 科室号源信息查询
        /// </summary>
        /// <param name="getDeptReg"></param>
        /// <returns></returns>
        [HttpPost("getDeptReg")]
        public string GetDeptReg(request<Entity.SRequest.getDeptReg> getDeptReg)
        {
            //if (string.IsNullOrWhiteSpace(getDeptRegXML))
            //{
            //    return RsXmlHelper.ResXml(-1, "XML不能为空");
            //}

            //var getDeptReg = XMLHelper.DESerializer<request<Entity.SRequest.getDeptReg>>(getDeptRegXML);
            if (getDeptReg == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            var dept = sysDeptBLL.GetDeptByCode(getDeptReg.model.deptCode);
            if (dept == null)
            {
                return RsXmlHelper.ResXml(99, "科室code不存在");
            }
            var regarrList = regArrangeBLL.GetDeptRegItems(dept.name, getDeptReg.model.beginDate, getDeptReg.model.endDate);
            if (regarrList.Count > 0)
            {
                return XMLHelper.XmlSerialize(new response<Entity.SResponse.getDeptReg>()
                {
                    model = new Entity.SResponse.getDeptReg()
                    {
                        resultCode = 0,
                        resultMessage = "",
                        item = regarrList
                    }
                });
            }
            else
            {
                return RsXmlHelper.ResXml(99, "数据为空");
            }
        }
    }
}