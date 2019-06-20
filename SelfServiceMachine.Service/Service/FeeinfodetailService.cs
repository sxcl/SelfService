using System.Collections.Generic;
using System.Data.SqlClient;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SResponse;
using SelfServiceMachine.Service.IService;
using SqlSugar;

namespace SelfServiceMachine.Service.Service
{
    public class FeeinfodetailService : BaseService<fee_infodetail>, IFeeinfodetail
    {
        public List<Entity.SResponse.PayFeeDetailItem> GetPayFeeDetailItems(int feeid)
        {
            var query = "select o.addtime as itemTime,o.billid as recipeNo,o.itemname as itemName,o.spec as itemUnit,o.itemid as itemId,o.total as itemCount,(o.prices*100) as itemPrice,(o.totalprices*100) as itemTotalFee,sd.code as deptCode,null as doctorCode from fee_infodetail fd left join fee_info f on fd.feeid = f.feeid left join order_detail o on fd.billid = o.billid left join sys_dept sd on o.dept = sd.name where (sd.type = '医疗' or sd.type is null) and f.regid = '" + feeid + "' group by o.addtime,o.billid,o.itemname,o.spec,o.itemid,o.total,o.prices,o.totalprices,sd.code";

            return db.Ado.SqlQuery<PayFeeDetailItem>(query);
        }

        public bool Updates(List<fee_infodetail> fee_Infodetails)
        {
            return db.Updateable(fee_Infodetails).ExecuteCommand() > 0;
        }
    }
}
