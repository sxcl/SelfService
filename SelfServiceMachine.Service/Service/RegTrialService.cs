using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;

namespace SelfServiceMachine.Service.Service
{
    public class RegTrialService : BaseService<reg_trial>, IRegTrial
    {
        public int AddReturnId(reg_trial reg_Trial)
        {
            return db.Insertable(reg_Trial).ExecuteReturnIdentity();
        }
    }
}
