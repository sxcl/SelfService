using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;

namespace SelfServiceMachine.Bussiness
{
    public class TempRegBLL
    {
        private ITempReg ITempReg = new TempRegService();

        public bool Add(temp_reg temp_Reg)
        {
            return ITempReg.Add(temp_Reg);
        }
    }
}
