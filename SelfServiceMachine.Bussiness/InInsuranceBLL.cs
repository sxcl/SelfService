using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;

namespace SelfServiceMachine.Bussiness
{
    public class InInsuranceBLL
    {
        private IInInsurance inInsurance = new InInsuranceService();

        public in_insurance GetIn_Insurance(int inid)
        {
            return inInsurance.Get(x => x.indid == inid);
        }
    }
}
