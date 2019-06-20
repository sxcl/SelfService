using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;
using System;
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

        public int AddReturnId(reg_trial reg_Trial)
        {
            return iRegTrial.AddReturnId(reg_Trial);
        }

        public reg_trial Get(int regid)
        {
            return iRegTrial.Get(x => x.regid == regid);
        }

        public void Update(reg_trial reg_Trial)
        {
            iRegTrial.Update(reg_Trial);
        }
    }
}
