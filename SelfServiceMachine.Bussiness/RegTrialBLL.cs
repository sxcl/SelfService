using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;
using System.Collections.Generic;

namespace SelfServiceMachine.Bussiness
{
    public class RegTrialBLL
    {
        private IRegTrial iRegTrial = new RegTrialService();

        public bool Adds(List<reg_trial> reg_Trials)
        {
            return iRegTrial.Adds(reg_Trials.ToArray());
        }
    }
}
