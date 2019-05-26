using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SlefServiceModels;
using SelfServiceMachine.Service.IService;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Service.Service
{
    public class RegTypeService : BaseService<reg_type>, IRegType
    {
        public List<Entity.SResponse.AdogCurRegItem> gCurRegInfos(string deptCode, string doctorCode, string beginDate, string endDate)
        {
            var query = "SELECT reg_type.[regtype] as category ,sys_userinfo.userno as doctorCode ,reg_manage.[doctor] as doctorName ,null as doctorTitle ,null as doctorIntrodution ,null as doctorSex ,null as doctorBirth ,null as doctorSkill ,null as picture,reg_type.regtid FROM [ZSHIS].[dbo].[reg_type] INNER JOIN sys_userinfo ON reg_type.uid = sys_userinfo.userid INNER JOIN sys_dept ON reg_type.deptid = sys_dept.id INNER JOIN reg_manage ON reg_manage.regtid = reg_type.regtid WHERE sys_dept.code = '{0}' AND sys_userinfo.userno LIKE '%{1}%' AND reg_manage.bookdate >= '{2}' AND reg_manage.bookdate <= '{3}'  GROUP BY reg_type.[regtype] ,sys_userinfo.userno ,reg_manage.[doctor] ,reg_type.regtid";

            var list = db.Ado.SqlQuery<Entity.SResponse.AdogCurRegItem>(string.Format(query, deptCode, doctorCode, beginDate, endDate));

            foreach (var item in list)
            {
                item.item = new List<Entity.SResponse.TimeItems>();
                var timequery = "select rm.timeflag as timeFlag,1 as hasDetailTime,ra.booktime1 as beginTime,ra.booktime2 as endTime,1 as workStatus,qty as totalNum,(select count(1) from reg_arrange where mgrid = rm.mgrid and reg_arrange.regno  = 0) as leftNum,0 as regFee,(select top 1 prices from comm_fee where itemid = rm.itemid and costtype = 3) as treatFee,ra.argid as scheduleNo from reg_manage rm right join reg_arrange ra on rm.mgrid = ra.mgrid where regtid = @regtid and ra.bookdate >= @beginDate and ra.bookdate <= @endDate";

                item.item = db.Ado.SqlQuery<Entity.SResponse.TimeItems>(timequery, new SugarParameter[] { new SugarParameter("@regtid", item.regtid), new SugarParameter("@beginDate", beginDate), new SugarParameter("@endDate", endDate) });
            }

            return list;
        }
    }
}
