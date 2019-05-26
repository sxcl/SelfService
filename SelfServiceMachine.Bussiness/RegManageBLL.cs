using SelfServiceMachine.Entity.SlefServiceModels;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;
using System.Collections.Generic;

namespace SelfServiceMachine.Bussiness
{
    public class RegManageBLL
    {
        private IRegmanage IRegmanage = new RegManageService();

        public List<Entity.SResponse.cDocTimeItem> GetCDocTimeItems(string deptCode, string doctorCode, int Timeflag)
        {
            return IRegmanage.GetCDocTimeItems(deptCode, doctorCode, Timeflag);
        }
    }
}
