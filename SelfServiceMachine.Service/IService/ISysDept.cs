using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SlefServiceModels;
using System.Collections.Generic;

namespace SelfServiceMachine.Service.IService
{
    public interface ISysDept:IBase<sys_dept>
    {
        List<Entity.SResponse.GDeptItem> GetGDeptItems(string fCode);
    }
}
