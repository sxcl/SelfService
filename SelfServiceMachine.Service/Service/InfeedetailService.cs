using System;
using System.Collections.Generic;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SResponse;
using SelfServiceMachine.Service.IService;
using SqlSugar;

namespace SelfServiceMachine.Service.Service
{
    public class InfeedetailService : BaseService<in_feedetail>, IInfeedetail
    {
        public decimal DidNotPay(int inid)
        {
            var query = "select SUM(totalprices) from in_orderfeedetail where inid = @inid and billid not in (select billid from in_feedetail where inid = @inid)";
            try
            {
                return Convert.ToDecimal(db.Ado.GetString(query, new SugarParameter[]
                    {
                new SugarParameter("@inid",inid)
                    }));
            }
            catch
            {
                return 0;
            }
        }

        public List<BedFeeItem> GetBedFeeItems(int inid)
        {
            return db.Queryable<in_feedetail>().Where(x => x.inid == inid).OrderBy(it => it.addtime).Select(f => new BedFeeItem
            {
                costName = f.itemname,
                costAmout = f.totalprice,
                costType = f.itemtype
            }).ToList();
        }
    }
}
