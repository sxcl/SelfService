using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SResponse;
using System.Collections.Generic;

namespace SelfServiceMachine.Service.IService
{
    public interface IFeeDepositDetail : IBase<fee_depositdetail>
    {
        List<DepositItem> GetDepositItems(int did, string payMode, string beginDate, string endDate, string sno);
    }
}
