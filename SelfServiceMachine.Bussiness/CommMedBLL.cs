using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;
using System;
using System.Linq.Expressions;

namespace SelfServiceMachine.Bussiness
{
    public class CommMedBLL
    {
        private ICommMed iCommMed = new CommMedService();

        public comm_med Get(Expression<Func<comm_med, bool>> whereLambda)
        {
            return iCommMed.Get(whereLambda);
        }
    }
}
