using SelfServiceMachine.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Service.IService
{
    public interface IFeeinfo : IBase<fee_info>
    {
        int AddReturnId(fee_info fee_Info);
    }
}
