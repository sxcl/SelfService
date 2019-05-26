using SelfServiceMachine.Entity;
using System.Collections.Generic;

namespace SelfServiceMachine.Service.IService
{
    public interface ICommFee : IBase<comm_fee>
    {
        List<comm_fee_view> GetComm_Fee_Views(int itemid);
    }
}
