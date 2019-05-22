using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;

namespace SelfServiceMachine.Service.Service
{
    public class FeeinfoService : BaseService<fee_info>, IFeeinfo
    {
        public int AddReturnId(fee_info fee_Info)
        {
            return db.Insertable(fee_Info).ExecuteReturnIdentity();
        }
    }
}
