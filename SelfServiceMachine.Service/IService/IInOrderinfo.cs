using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SResponse;
using System.Collections.Generic;

namespace SelfServiceMachine.Service.IService
{
    public interface IInOrderinfo : IBase<in_orderinfo>
    {
        List<BedFeeItem> GetIn_FeedItem(int inid);
    }
}
