using System;
using System.Collections.Generic;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;

namespace SelfServiceMachine.Service.Service
{
    public class OrderinfoService : BaseService<order_info>, IOrderinfo
    {
        public List<order_info> GetMZFeeByBillids(string billids)
        {
            var iNums = Array.ConvertAll(billids.Split(","), s => int.Parse(s));
            return db.Queryable<order_info>().In(iNums).ToList();
        }

        public List<Entity.SResponse.MZFeeDetail> GetMZFeeDetails(string regid, string billid)
        {
            var query = "";
            if (!string.IsNullOrWhiteSpace(billid))
            {
                query = "select o.addtime as itemTime,itemname as itemName,itemtype as itemType,dpunit as itemUnit,itemid as itemId,scode as tybm,ccode as yljgnbbm,null as jsxm,prices*100 as itemPrice,spec as itemSpec,total as itemNumber,totalprices*100 as itemTotalFee,o.dept as deptName,su.userno as doctorCode,oi.doctor as doctorName,null as itemGroup,oi.regid as mzFeeId,null as budgetFlag,o.billid as recipeNo from order_feedetail o left join order_info oi on o.billid = oi.billid left join sys_userinfo su on oi.uid = su.userid where oi.regid = @regid and o.billid = @billid and oi.feestatus = '未收费'";
            }
            else
            {
                query = "select o.addtime as itemTime,itemname as itemName,itemtype as itemType,dpunit as itemUnit,itemid as itemId,scode as tybm,ccode as yljgnbbm,null as jsxm,prices*100 as itemPrice,spec as itemSpec,total as itemNumber,totalprices*100 as itemTotalFee,o.dept as deptName,su.userno as doctorCode,oi.doctor as doctorName,null as itemGroup,oi.regid as mzFeeId,null as budgetFlag,o.billid as recipeNo from order_feedetail o left join order_info oi on o.billid = oi.billid left join sys_userinfo su on oi.uid = su.userid where oi.regid = @regid and oi.feestatus = '未收费'";
            }

            return db.Ado.SqlQuery<Entity.SResponse.MZFeeDetail>(query, new { regid, billid });
        }

        public List<Entity.SResponse.MZFeeList> GetMZFeeLists(string strWhere)
        {
            var query = "SELECT o.regid as mzFeeId,o.addtime as time,s.userno as doctorCode,o.doctor as doctorName,o.dept as deptName,sd.code as deptCode,r.feetype as MZ_TYPE,o.totprice*100 as payAmout,null as medicareAmout,o.totprice*100 as totalAmout,billid as recipeNo,null as Attachment FROM [ZSHIS].[dbo].[order_info] o left join sys_userinfo s on o.uid = s.userid left join sys_dept sd on sd.name = o.dept left join reg_info r on o.regid = r.regid left join pt_info p on r.pid = p.pid where " + strWhere + " and (sd.type = '医疗' or sd.type is null) and o.feestatus = '未收费'";

            return db.Ado.SqlQuery<Entity.SResponse.MZFeeList>(query);
        }

        public List<order_info> GetMZOrderInfo(int regid, string billid)
        {
            if (!string.IsNullOrWhiteSpace(billid))
            {
                var iNums = Array.ConvertAll(billid.Split(","), s => int.Parse(s));
                return db.Queryable<order_info>().In(x => x.billid, iNums).ToList();
            }
            else
            {
                return db.Queryable<order_info>().Where(x => x.regid == regid).ToList();
            }
        }

        public bool HasOrderByVisid(int visid)
        {
            return db.Queryable<order_info>().Any(oi => oi.visid == visid);
        }

        public bool Updates(List<order_info> order_Infos)
        {
            return db.Updateable(order_Infos).ExecuteCommand() > 0;
        }
    }
}
