using SelfServiceMachine.Entity;
using System;

namespace SelfServiceMachine.Service.IService
{
    public interface IInReginfo : IBase<in_reginfo>
    {
        object GetOutDate(int inid);
        string GetInCount(string idno);
    }
}
