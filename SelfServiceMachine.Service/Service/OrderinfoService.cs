using System.Collections.Generic;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SlefServiceModels;
using SelfServiceMachine.Service.IService;

namespace SelfServiceMachine.Service.Service
{
    public class OrderinfoService : BaseService<order_info>, IOrderinfo
    {
        public List<MZFeeDetail> GetMZFeeDetails(string billid)
        {
            var query = "select o.addtime as itemTime,itemname as itemTime,itemtype as itemType,dpunit as itemUnit,itemid as itemId,scode as tybm,ccode as yljgnbbm,null as jsxm,prices as itemPrice,spec as itemSpec,total as itemNumber,totalprices as itemTotalFee,o.dept as deptName,su.userno as doctorCode,oi.doctor as doctorName,null as itemGroup,oi.billid as mzFeeId,null as budgetFlag,null as recipeNo from order_feedetail o left join order_info oi on o.billid = oi.billid left join sys_userinfo su on oi.uid = su.userid where o.billid = @billid";

            return db.Ado.SqlQuery<MZFeeDetail>(query, new { billid });
        }

        public List<MZFeeList> GetMZFeeLists(string strWhere)
        {
            var query = "SELECT billid as mzFeeId,o.addtime as time,s.userno as doctorCode,o.doctor as doctorName,o.dept as deptName,sd.code as deptCode,r.feetype as MZ_TYPE,o.totprice as payAmout,null as medicareAmout,o.totprice as totalAmout,null as recipeNo,null as Attachment FROM [ZSHIS].[dbo].[order_info] o left join sys_userinfo s on o.uid = s.userid left join sys_dept sd on sd.name = o.dept left join reg_info r on o.regid = r.regid left join pt_info p on r.pid = p.pid where " + strWhere;

            return db.Ado.SqlQuery<MZFeeList>(query);
        }
    }
}
