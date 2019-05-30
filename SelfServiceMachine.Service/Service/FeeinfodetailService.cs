using System.Collections.Generic;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SResponse;
using SelfServiceMachine.Service.IService;
using SqlSugar;

namespace SelfServiceMachine.Service.Service
{
    public class FeeinfodetailService : BaseService<fee_infodetail>, IFeeinfodetail
    {
        public List<PayFeeDetailItem> GetPayFeeDetailItems(int feeid)
        {
            var query = "select o.addtime as itemTime,o.billid as recipeNo,o.itemname as itemName,o.spec as itemUnit,o.itemid as itemId,o.total as itemCount,o.prices as itemPrice,o.totalprices as itemTotalFee,sd.code as deptCode,null as doctorCode from fee_infodetail fd left join fee_info f on fd.feeid = f.feeid left join order_detail o on fd.billid = o.billid left join sys_dept sd on o.dept = sd.name where (sd.type = '医疗' or sd.type is null) and f.feeid = @feeid";

            return db.Ado.SqlQuery<PayFeeDetailItem>(query, new SugarParameter("@feeid", feeid));
        }

        public bool Updates(List<fee_infodetail> fee_Infodetails)
        {
            return db.Updateable(fee_Infodetails).ExecuteCommand() > 0;
        }
    }
}
