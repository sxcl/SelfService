using System;
using System.Linq.Expressions;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;

namespace SelfServiceMachine.Bussiness
{
    public class FeeTrialBLL
    {
        private IFeeTrial iFeeTrial = new FeeTrialService();

        public bool Add(fee_trial fee_Trial)
        {
            return iFeeTrial.Add(fee_Trial);
        }

        public fee_trial Get(Expression<Func<fee_trial, bool>> whereLambda)
        {
            return iFeeTrial.Get(whereLambda);
        }
    }
}
