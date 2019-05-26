using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SlefServiceModels;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;
using System;
using System.Collections.Generic;

namespace SelfServiceMachine.Bussiness
{
    public class SysUserinfoBLL
    {
        private ISysUserinfo IUserinfo = new SysUserinfoService();

        public List<SelfServiceMachine.Entity.SResponse.rDoctorItem> GetRDoctorItems(string deptCode)
        {
            return IUserinfo.GetRDoctorItems(deptCode);
        }

        public sys_userinfo GetRDoctor(string doctorCode)
        {
            return IUserinfo.Get(x => x.userno == doctorCode && x.del == false);
        }
    }
}
