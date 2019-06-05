using System.Collections.Generic;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;
using SqlSugar;

namespace SelfServiceMachine.Service.Service
{
    public class CommFeeService : BaseService<comm_fee>, ICommFee
    {
        public List<comm_fee> GetComm_Fee(int itemid)
        {
            var query = "SELECT a.itemid AS 父项目id,a.itemcombid AS 子项目id,b.* FROM dbo.comm_feecomb a  LEFT JOIN dbo.comm_fee b ON b.itemid = a.itemcombid WHERE a.itemid='" + itemid + "' and b.costtype = 5";

            return db.Ado.SqlQuery<comm_fee>(query);
        }

        public List<comm_fee_view> GetComm_Fee_Views(int itemid)
        {
            var query = "select * from comm_fee_view where itemid = @itemid and costtype = 5";

            return db.Ado.SqlQuery<comm_fee_view>(query, new SugarParameter("@itemid", itemid));
        }
    }
}
