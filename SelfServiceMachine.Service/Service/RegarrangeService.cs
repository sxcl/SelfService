using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SlefServiceModels;
using SelfServiceMachine.Service.IService;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelfServiceMachine.Service.Service
{
    public class RegarrangeService : BaseService<reg_arrange>, IRegarrange
    {

        public List<reg_manage> GetReg_arrange(string dept, string beginDate, string endDate)
        {
            var query = "select regtype,dept,doctor,itemid,bookdate,SUM(qty) as qty from reg_manage where DATEDIFF(DAY,bookdate,'@beginDate') <= 0 and DATEDIFF(DAY,bookdate,'@endDate') >= 0 and gstatus = 1 and dept = @dept group by regtype,dept,doctor,itemid,bookdate";

            return db.Ado.SqlQuery<reg_manage>(query, new { dept, beginDate, endDate });
        }

        public int GetRegArr(string dept, string date, string regtype, string doctor, string itemid)
        {
            var query = "select COUNT(1) from reg_arrange where DATEDIFF(DAY,bookdate,'@date') = 0 and regtype = '@regtype' and dept = '@dept' and doctor = '@doctor' and itemid = @itemid and regno = 0;";

            return db.Ado.GetInt(query, new SugarParameter[]
            {
                new SugarParameter("@date",date),
                new SugarParameter("@regtype",regtype),
                new SugarParameter("@dept",dept),
                new SugarParameter("@doctor",doctor),
                new SugarParameter("@itemid",itemid)
            });
        }

        public reg_arrange GetReg_arrange(string dept, string doctor)
        {
            var query = "select top 1 ra.* from reg_arrange ra where ra.booktime1 >= '06:00:00' and ra.booktime2 <= '12:00:00' and DATEDIFF(DAY,ra.addtime,GETDATE()) = 0 and dept = @dept and doctor = @doctor and regno is null";

            return db.Ado.SqlQuery<reg_arrange>(query, new SugarParameter[] { new SugarParameter("@dept", dept), new SugarParameter("@doctor", doctor) }).FirstOrDefault();
        }
    }
}
