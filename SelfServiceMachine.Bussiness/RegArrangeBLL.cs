using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;
using System;
using System.Collections.Generic;

namespace SelfServiceMachine.Bussiness
{
    public class RegArrangeBLL
    {
        private IRegarrange Iregarrange = new RegarrangeService();

        public List<Entity.SlefServiceModels.DeptRegItem> GetDeptRegItems(string dept, string beginDate, string endDate)
        {
            var list = Iregarrange.GetReg_arrange(dept, beginDate, endDate);

            List<Entity.SlefServiceModels.DeptRegItem> deptRegItems = new List<Entity.SlefServiceModels.DeptRegItem>();
            foreach (var li in list)
            {
                deptRegItems.Add(new Entity.SlefServiceModels.DeptRegItem()
                {
                    scheduleDate = li.bookdate.ToString(),
                    totalNum = Convert.ToInt32(li.qty),
                    leftNum = Iregarrange.GetRegArr(li.dept, li.bookdate.ToString(), li.regtype, li.doctor, li.itemid.ToString())
                });
            }

            return deptRegItems;
        }

        public reg_arrange GetReg_Arrange(int argid)
        {
            return Iregarrange.Get(x => x.argid == argid && x.regno != null && x.regno != 0);
        }

        public reg_arrange GetReg_Arrange(string dept,string doctor)
        {
            return Iregarrange.GetReg_arrange(dept, doctor);
        }
    }
}
