using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SResponse;
using SelfServiceMachine.Service.IService;
using SqlSugar;
using System.Collections.Generic;

namespace SelfServiceMachine.Service.Service
{
    public class FeeDepositService : BaseService<fee_deposit>, IFeeDeposit
    {
        public List<ComplementDepositItem> GetComplementDepositItems(string beginDate, string engDate)
        {
            var query = "select * from (select r.inid as patientID,r.inno as admissionNo,r.pname as patName,(CASE p.yno WHEN NULL THEN 1 ELSE 3 END) as patCardType,(CASE p.yno WHEN NULL THEN p.yno ELSE cno END) as patCardNo,d.leftprice as balance,r.intime as inDate,SUM(f.totalprices) as totalprice from in_reginfo r left join in_orderfeedetail f on r.inid = f.inid left join pt_info p on p.pid = r.pid left join fee_deposit d on d.inid = r.inid group by r.inid,r.inno,r.pname,d.leftprice,p.cno,p.yno,r.intime) as temp where temp.totalprice > temp.balance and inDate >= @beginDate and inDate <= @endDate";
            return db.Ado.SqlQuery<ComplementDepositItem>(query, new SugarParameter[]
            {
                new SugarParameter("@beginDate",beginDate),
                new SugarParameter("@endDate",engDate)
            });
        }
    }
}
