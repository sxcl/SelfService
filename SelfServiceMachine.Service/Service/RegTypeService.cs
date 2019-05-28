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
            var query = "select rt.regtype as category,su.userno as doctorCode,rt.doctor as doctorName,levels as doctorTitle,null as doctorIntrodution,null as doctorSex,null as doctorBirth,null as doctorSkill,null as picture,rt.regtid from reg_type rt left join reg_manage rm on rt.regtid = rm.regtid left join sys_userinfo su on rt.uid = su.userid left join sys_dept sd on rt.deptid = sd.id where sd.code = '{0}' and su.userno like '%{1}%' and rm.bookdate >= '{2}' and rm.bookdate <= '{3}' group by rt.regtype,su.userno,rt.doctor,levels,rt.regtid";

            var list = db.Ado.SqlQuery<Entity.SResponse.AdogCurRegItem>(string.Format(query, deptCode, doctorCode, beginDate, endDate));

            foreach (var item in list)
            {
                item.item = new List<Entity.SResponse.TimeItems>();
                var timequery = "select distinct rm.timeflag as timeFlag,1 as hasDetailTime,ra.booktime1 as beginTime,ra.booktime2 as endTime,1 as workStatus,qty as totalNum,(select count(1) from reg_arrange where mgrid = rm.mgrid and reg_arrange.regno  = 0) as leftNum,0 as regFee,(select top 1 prices from comm_fee where itemid = rm.itemid and costtype = 3) as treatFee,rm.mgrid as scheduleNo from reg_manage rm right join reg_arrange ra on rm.mgrid = ra.mgrid where regtid = @regtid and ra.bookdate >= @beginDate and ra.bookdate <= @endDate";

                item.item = db.Ado.SqlQuery<Entity.SResponse.TimeItems>(timequery, new SugarParameter[] { new SugarParameter("@regtid", item.regtid), new SugarParameter("@beginDate", beginDate), new SugarParameter("@endDate", endDate) });
            }

            return list;
        }
    }
}
