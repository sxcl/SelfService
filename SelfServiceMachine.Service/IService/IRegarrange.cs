using SelfServiceMachine.Entity;
using System.Collections.Generic;

namespace SelfServiceMachine.Service.IService
{
    public interface IRegarrange : IBase<reg_arrange>
    {
        List<Entity.SResponse.DeptRegItem> GetReg_arrange(string dept, string beginDate, string endDate);
        reg_arrange GetReg_arrange(string dept, string doctor, string beginTime, string endTime,int timeFlag);
        int GetRegArr(string dept, string date, string regtype, string doctor, string itemid);
        bool UpdateRegArrToZero(int argid);
    }
}
