using SelfServiceMachine.Entity;
using System.Collections.Generic;

namespace SelfServiceMachine.Service.IService
{
    public interface IRegmanage:IBase<reg_manage>
    {
        List<Entity.SResponse.cDocTimeItem> GetCDocTimeItems(string deptCode, string doctorCode, int Timeflag);
    }
}
