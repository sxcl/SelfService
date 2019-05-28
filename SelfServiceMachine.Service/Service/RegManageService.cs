using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SlefServiceModels;
using SelfServiceMachine.Service.IService;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Service.Service
{
    public class RegManageService : BaseService<reg_manage>, IRegmanage
    {
        public List<Entity.SResponse.cDocTimeItem> GetCDocTimeItems(string deptCode, string doctorCode, int Timeflag)
        {
            var query = "";
            if (Timeflag == 0)
            {
                query = "select booktime1 as beginTime,booktime2 as endTime,0.00 as regFee,(select top 1 prices from comm_fee where itemid = rm.itemid and costtype = 3) as treatFee,1 as workStatus,rm.qty as totalNum,(select count(1) from reg_arrange where mgrid = rm.mgrid and reg_arrange.regno  = 0) as leftNum from reg_manage rm inner join reg_type rt on rm.regtid = rt.regtid inner join sys_userinfo su on su.userid = rt.uid inner join sys_dept sd on sd.id = rt.deptid where rm.gstatus = 1 and rm.del = 0 and su.userno = @userno and sd.code = @deptcode and DATEDIFF(DAY,rm.bookdate,GETDATE()) = 0";
            }
            else
            {
                query = "select booktime1 as beginTime,booktime2 as endTime,0.00 as regFee,(select top 1 prices from comm_fee where itemid = rm.itemid and costtype = 3) as treatFee,1 as workStatus,rm.qty as totalNum,(select count(1) from reg_arrange where mgrid = rm.mgrid and reg_arrange.regno  = 0) as leftNum from reg_manage rm inner join reg_type rt on rm.regtid = rt.regtid inner join sys_userinfo su on su.userid = rt.uid inner join sys_dept sd on sd.id = rt.deptid where rm.gstatus = 1 and rm.del = 0 and su.userno = @userno and sd.code = @deptcode and rm.timeflag = @timeflag and DATEDIFF(DAY,rm.bookdate,GETDATE()) = 0";
            }

            return db.Ado.SqlQuery<Entity.SResponse.cDocTimeItem>(query, new SugarParameter[] { new SugarParameter("@timeflag", Timeflag), new SugarParameter("@deptcode", deptCode), new SugarParameter("@userno", doctorCode) });
        }
    }
}
