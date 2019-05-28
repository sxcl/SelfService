using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SlefServiceModels;
using SelfServiceMachine.Service.IService;
using System.Collections.Generic;

namespace SelfServiceMachine.Service.Service
{
    public class SysdeptService : BaseService<sys_dept>, ISysDept
    {
        public List<Entity.SResponse.GDeptItem> GetGDeptItems(string fCode)
        {
            if (string.IsNullOrWhiteSpace(fCode))
            {
                fCode = "D02";
            }
            var query = "select distinct null as branchCode,hosp as branchName,code as deptCode,name as deptName,null as deptTelephone,contents as deptDescription,floor as deptLocation,(select code from sys_dept where id = sd.fid group by code) as parentDeptCode from sys_dept sd left join reg_type rt on sd.id = rt.deptid where fid = (select id from sys_dept where code = @fcode)";

            return db.Ado.SqlQuery<Entity.SResponse.GDeptItem>(query, new { fcode = fCode });
        }
    }
}
