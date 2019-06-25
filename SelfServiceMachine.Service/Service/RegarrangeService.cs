using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SlefServiceModels;
using SelfServiceMachine.Service.IService;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SelfServiceMachine.Service.Service
{
    public class RegarrangeService : BaseService<reg_arrange>, IRegarrange
    {

        public List<Entity.SResponse.DeptRegItem> GetReg_arrange(string dept, string beginDate, string endDate)
        {
            var query = "select r.bookdate as scheduleDate,COUNT(r.argid) as totalNum,SUM(case when r.regno = 0 then 1 else 0 end) as leftNum from reg_arrange r WITH(NOLOCK) where r.dept = @dept and DATEDIFF(DAY,bookdate,@beginDate) <= 0 and DATEDIFF(DAY,bookdate,@endDate) >= 0 and r.booktime2 > (Select CONVERT(varchar(100), GETDATE(), 108)) and r.del = 0 group by r.bookdate,r.mgrid order by scheduleDate desc";

            return db.Ado.SqlQuery<Entity.SResponse.DeptRegItem>(query, new { dept, beginDate, endDate });
        }

        public int GetRegArr(string dept, string date, string regtype, string doctor, string itemid)
        {
            var query = "select COUNT(1) from reg_arrange where DATEDIFF(DAY,bookdate,@date) = 0 and regtype = '@regtype' and dept = '@dept' and doctor = '@doctor' and itemid = @itemid and regno = 0;";

            return db.Ado.GetInt(query, new SugarParameter[]
            {
                new SugarParameter("@date",date),
                new SugarParameter("@regtype",regtype),
                new SugarParameter("@dept",dept),
                new SugarParameter("@doctor",doctor),
                new SugarParameter("@itemid",itemid)
            });
        }

        public reg_arrange GetReg_arrange(string dept, string doctor, string beginTime, string endTime, int timeFlag)
        {
            var query = "";
            if (timeFlag == 0)
            {
                query = "select ra.* from reg_arrange ra where ra.booktime1 >= '" + beginTime + "' and ra.booktime2 <= '" + endTime + "' and dept = @dept and doctor = @doctor and regno = 0 and DATEDIFF(DAY,bookdate,GETDATE()) = 0";
            }
            else if (timeFlag == 1)
            {
                query = "select ra.* from reg_arrange ra where ra.booktime1 >= '" + beginTime + "' and ra.booktime2 <= '" + endTime + "' and booktime1 >= '00:00:00' and booktime2 <= '14:00:00' and dept = @dept and doctor = @doctor and regno = 0 and DATEDIFF(DAY,bookdate,GETDATE()) = 0";
            }
            else
            {
                query = "select ra.* from reg_arrange ra where ra.booktime1 >= '" + beginTime + "' and ra.booktime2 <= '" + endTime + "' and booktime1 >= '14:00:00' and booktime2 <= '23:59:59' and dept = @dept and doctor = @doctor and regno = 0 and DATEDIFF(DAY,bookdate,GETDATE()) = 0";
            }

            return db.Ado.SqlQuery<reg_arrange>(query, new SugarParameter[] { new SugarParameter("@dept", dept), new SugarParameter("@doctor", doctor) }).FirstOrDefault();
        }

        public bool UpdateRegArrToZero(int argid)
        {
            var query = "update reg_arrange set regno = 0 where argid = @argid";
            return Convert.ToInt32(db.Ado.GetScalar(query, new SqlParameter("@argid", argid))) > 0;
        }
    }
}
