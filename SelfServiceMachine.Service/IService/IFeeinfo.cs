using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.Insurance;
using System.Collections.Generic;

namespace SelfServiceMachine.Service.IService
{
    public interface IFeeinfo : IBase<fee_info>
    {
        MZ001 GetTrialData(int regid);
        fee_info GetFee_InfoByRegTrial(int feeid);
        bool DeleteFeeinfo(int regid, string sno);
        List<Entity.SResponse.getPayItem> GetPayItems(int pid);
        List<Entity.SResponse.BillInfoItem> getBillInfos(string billDate, int paymodel, int pageNo, int pageNumber);
    }
}
