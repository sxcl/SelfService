using SelfServiceMachine.Entity.SlefServiceModels;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Bussiness
{
    public class RegTypeBLL
    {
        private IRegType IRegType = new RegTypeService();

        public List<AdogCurRegItem> gCurRegInfos(string deptCode, string doctorCode, string beginDate, string endDate)
        {
            return IRegType.gCurRegInfos(deptCode, doctorCode, beginDate, endDate);
        }
    }
}
