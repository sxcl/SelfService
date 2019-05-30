using SelfServiceMachine.Entity;

namespace SelfServiceMachine.Service.IService
{
    public interface ICommKey : IBase<comm_key>
    {
        int GetMZNO();
        int GetYBDJH();
        int GetYBXLH();
        int GetYBNO();
    }
}
