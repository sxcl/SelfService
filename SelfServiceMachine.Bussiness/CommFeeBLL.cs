using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SelfServiceMachine.Bussiness
{
    public class CommFeeBLL
    {
        private ICommFee iCommfee = new CommFeeService();

        public List<comm_fee_view> GetComm_Fee_Views(int itemid)
        {
            return iCommfee.GetComm_Fee_Views(itemid);
        }

        public bool IsPackage(Expression<Func<comm_fee, bool>> whereLambda)
        {
            return iCommfee.Get(whereLambda).packages > 0;
        }

        public comm_fee Get(Expression<Func<comm_fee, bool>> whereLambda)
        {
            return iCommfee.Get(whereLambda);
        }

        public comm_fee Get(int itemid)
        {
            return iCommfee.GetComm_Fee(itemid).FirstOrDefault();
        }
    }
}
