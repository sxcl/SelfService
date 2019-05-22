using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SlefServiceModels;
using System.Collections.Generic;

namespace SelfServiceMachine.Service.IService
{
    public interface IRegType : IBase<reg_type>
    {
        List<AdogCurRegItem> gCurRegInfos(string deptCode, string doctorCode, string beginDate, string endDate);
    }
}
