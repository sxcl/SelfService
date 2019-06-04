using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;
using SqlSugar;

namespace SelfServiceMachine.Service.Service
{
    public class CommYbCodeService : BaseService<comm_ybcode>, ICommYbCode
    {
        public string GetYbCodeByName(string codeType, string name)
        {
            return db.Ado.GetString("select ybid from comm_ybcode where tbcode = @tbcode and ybidname = @ybidname", new SugarParameter[] { new SugarParameter("@tbcode", codeType), new SugarParameter("@ybidname", name) });
        }
    }
}
