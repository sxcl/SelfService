using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SlefServiceModels;
using System.Collections.Generic;

namespace SelfServiceMachine.Service.IService
{
    public interface IOrderinfo : IBase<order_info>
    {
        List<MZFeeList> GetMZFeeLists(string strWhere);
        List<MZFeeDetail> GetMZFeeDetails(string billid);
    }
}
