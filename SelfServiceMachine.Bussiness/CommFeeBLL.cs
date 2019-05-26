using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;
using System.Collections.Generic;
using System.Linq;

namespace SelfServiceMachine.Bussiness
{
    public class CommFeeBLL
    {
        private ICommFee iCommfee = new CommFeeService();

        public comm_fee_view GetComm_Fee_Views(int itemid)
        {
            return iCommfee.GetComm_Fee_Views(itemid).First();
        }
    }
}
