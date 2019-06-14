using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SResponse;
using System.Collections.Generic;

namespace SelfServiceMachine.Service.IService
{
    public interface IInfeedetail : IBase<in_feedetail>
    {
        List<BedFeeItem> GetBedFeeItems(int inid);
        decimal DidNotPay(int inid);
    }
}
