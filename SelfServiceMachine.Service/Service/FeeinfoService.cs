using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.Insurance;
using SelfServiceMachine.Entity.SlefServiceModels;
using SelfServiceMachine.Service.IService;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace SelfServiceMachine.Service.Service
{
    public class FeeinfoService : BaseService<fee_info>, IFeeinfo
    {
        public int AddReturnId(fee_info fee_Info)
        {
            return db.Insertable(fee_Info).ExecuteReturnIdentity();
        }

        public fee_info GetFee_InfoByRegTrial(int feeid)
        {
            return Get(x => x.feeid == feeid && x.ftype == 2);
        }

        public MZ001 GetTrialData(int regid)
        {
            var query = "select mzno as akc190,null as aaz500,null as alc005,11 asaka130,sd.ybno as akf001,CASE r.rtype WHEN '普通' THEN '1' WHEN '主治' THEN '2' WHEN '主任' THEN '3' WHEN '免收诊金' THEN '4' WHEN '专家' THEN '5' ELSE '0' END as bkc368,null as aka120,null as akc188,null as akc189 from reg_info r left join sys_dept sd on r.dept = sd.name where r.regid = @regid and sd.ybno is not null";
            var trial = db.Ado.SqlQuery<MZ001>(query, new { regid }).FirstOrDefault();
            if (trial != null)
            {
                return trial;
            }
            else
                return null;
        }

        public bool DeleteFeeinfo(int regid, string sno)
        {
            var delQuery = "delete fee_info where regid = @regid and ftype = 2 and sno = @sno";

            return Convert.ToInt32(db.Ado.GetScalar(delQuery, new SqlParameter[] {
                new SqlParameter("@regid", regid),
                new SqlParameter("@sno",sno)
            })) > 0;
        }
    }
}
