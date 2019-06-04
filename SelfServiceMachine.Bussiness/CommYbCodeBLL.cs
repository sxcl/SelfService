using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;

namespace SelfServiceMachine.Bussiness
{
    public class CommYbCodeBLL
    {
        private ICommYbCode iCommYbCode = new CommYbCodeService();

        public string GetYbCodeByName(string codeType, string name)
        {
            return iCommYbCode.GetYbCodeByName(codeType, name);
        }
    }
}
