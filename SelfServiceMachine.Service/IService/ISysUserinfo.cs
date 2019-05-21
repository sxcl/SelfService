using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SlefServiceModels;
using System.Collections.Generic;

namespace SelfServiceMachine.Service.IService
{
    public interface ISysUserinfo : IBase<sys_userinfo>
    {
        List<rDoctorItem> GetRDoctorItems(string deptCode);
    }
}
