using SelfServiceMachine.Entity;
using System.Collections.Generic;

namespace SelfServiceMachine.Service.IService
{
    public interface IOrderfeedetail : IBase<order_feedetail>
    {
        List<order_feedetail> GetOrder_Feedetails(int[] billid);
    }
}
