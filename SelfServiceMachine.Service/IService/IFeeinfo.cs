using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.Insurance;
using SelfServiceMachine.Entity.SlefServiceModels;

namespace SelfServiceMachine.Service.IService
{
    public interface IFeeinfo : IBase<fee_info>
    {
        int AddReturnId(fee_info fee_Info);
        MZ001 GetTrialData(int regid);
        fee_info GetFee_InfoByRegTrial(int feeid);
    }
}
