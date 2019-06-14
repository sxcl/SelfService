using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SResponse;
using System.Collections.Generic;

namespace SelfServiceMachine.Service.IService
{
    public interface IFeeDeposit : IBase<fee_deposit>
    {
        List<ComplementDepositItem> GetComplementDepositItems(string beginDate, string engDate);
    }
}
