using SelfServiceMachine.Entity.SlefServiceModels;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;
using System.Collections.Generic;

namespace SelfServiceMachine.Bussiness
{
    public class SysUserinfoBLL
    {
        private ISysUserinfo IUserinfo = new SysUserinfoService();

        public List<rDoctorItem> GetRDoctorItems(string deptCode)
        {
            return IUserinfo.GetRDoctorItems(deptCode);
        }
    }
}
