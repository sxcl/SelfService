using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;
using System.Collections.Generic;

namespace SelfServiceMachine.Bussiness
{
    public class RegTrialdetailBLL
    {
        private IRegTrialdetail iRegTrialdetail = new RegTrialdetailService();

        public bool Add(reg_trialdetail reg_Trialdetail)
        {
            return iRegTrialdetail.Add(reg_Trialdetail);
        }

        public bool Adds(List<reg_trialdetail> reg_Trialdetails)
        {
            return iRegTrialdetail.Adds(reg_Trialdetails.ToArray());
        }

        public List<reg_trialdetail> GetList(int regtrialid)
        {
            return iRegTrialdetail.GetList(x => x.id == regtrialid);
        }
    }
}
