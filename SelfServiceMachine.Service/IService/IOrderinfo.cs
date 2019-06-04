using SelfServiceMachine.Entity;
using System.Collections.Generic;

namespace SelfServiceMachine.Service.IService
{
    public interface IOrderinfo : IBase<order_info>
    {
        List<Entity.SResponse.MZFeeList> GetMZFeeLists(string strWhere);
        List<Entity.SResponse.MZFeeDetail> GetMZFeeDetails(string regid, string billid);
        List<order_info> GetMZFeeByBillids(string billids);
        bool HasOrderByRegid(int regid);
        bool Updates(List<order_info> order_Infos);
        List<order_info> GetMZOrderInfo(int regid, string billid);
    }
}
