namespace SelfServiceMachine.Service.IService
{
    public interface ICommYbCode
    {
        string GetYbCodeByName(string codeType, string name);
    }
}
