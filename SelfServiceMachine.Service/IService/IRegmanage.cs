using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SlefServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Service.IService
{
    public interface IRegmanage:IBase<reg_manage>
    {
        List<cDocTimeItem> GetCDocTimeItems(string deptCode, string doctorCode, int Timeflag);
    }
}
