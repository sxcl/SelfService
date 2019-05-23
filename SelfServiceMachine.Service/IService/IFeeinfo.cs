using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SlefServiceModels;

namespace SelfServiceMachine.Service.IService
{
    public interface IFeeinfo : IBase<fee_info>
    {
        int AddReturnId(fee_info fee_Info);
        RegisteredTrial GetTrialData(int regid);
    }
}
