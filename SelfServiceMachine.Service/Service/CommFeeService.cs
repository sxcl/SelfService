using System.Collections.Generic;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;
using SqlSugar;

namespace SelfServiceMachine.Service.Service
{
    public class CommFeeService : BaseService<comm_fee>, ICommFee
    {
        public List<comm_fee_view> GetComm_Fee_Views(int itemid)
        {
            var query = "select * from comm_fee_view where itemid = @itemid and costtype = 5";

            return db.Ado.SqlQuery<comm_fee_view>(query, new SugarParameter("@itemid", itemid));
        }
    }
}
