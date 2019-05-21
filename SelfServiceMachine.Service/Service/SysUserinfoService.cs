using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SlefServiceModels;
using SelfServiceMachine.Service.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Service.Service
{
    public class SysUserinfoService : BaseService<sys_userinfo>, ISysUserinfo
    {
        public List<rDoctorItem> GetRDoctorItems(string deptCode)
        {
            var query = "select null as branchCode,sd.hosp as branchName,sd.code as deptCode,sd.name as deptName,userno as doctorCode,userno as doctorNo,username as doctorName,null as doctorSex,null as doctorBirth,null as doctorTelephone,null as doctorSkill,null as doctorIntrodution,levels as doctorTitle,null as picture from sys_userinfo su left join sys_dept sd on su.dept = sd.name left join reg_type rt on su.userid = rt.uid where sd.code = @deptCode and business like '%医生%'";

            return db.Ado.SqlQuery<rDoctorItem>(query, new { deptCode });
        }
    }
}
