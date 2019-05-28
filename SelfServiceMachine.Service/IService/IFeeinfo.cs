using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.Insurance;

namespace SelfServiceMachine.Service.IService
{
    public interface IFeeinfo : IBase<fee_info>
    {
        int AddReturnId(fee_info fee_Info);
        MZ001 GetTrialData(int regid);
        fee_info GetFee_InfoByRegTrial(int feeid);
        bool DeleteFeeinfo(int regid, string sno);
    }
}
