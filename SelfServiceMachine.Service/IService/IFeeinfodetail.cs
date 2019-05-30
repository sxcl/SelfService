using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SResponse;
using System.Collections.Generic;

namespace SelfServiceMachine.Service.IService
{
    public interface IFeeinfodetail : IBase<fee_infodetail>
    {
        List<PayFeeDetailItem> GetPayFeeDetailItems(int feeid);
        bool Updates(List<fee_infodetail> fee_Infodetails);
    }
}
