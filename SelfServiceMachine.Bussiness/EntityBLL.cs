using SelfServiceMachine.Model;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;

namespace SelfServiceMachine.Bussiness
{
    public class EntityBLL
    {
        private IEntity iService = new EntityService();

        public MessageModel<string> CreateEntity(string entityName, string contentRootPath,string nameSpace)
        {
            string[] arr = contentRootPath.Split("\\");
            string baseFileProvider = "";
            for (int i = 0; i < arr.Length; i++)
            {
                baseFileProvider += arr[i];
                baseFileProvider += "\\";
            }
            string filePath = baseFileProvider + "..\\SelfServiceMachine.Entity";
            if (iService.CreateEntity(entityName, filePath, nameSpace))
                return new MessageModel<string> { Success = true, Msg = "生成成功" };
            else
                return new MessageModel<string> { Success = false, Msg = "生成失败" };
        }
    }
}
