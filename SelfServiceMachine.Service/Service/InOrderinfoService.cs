using System.Collections.Generic;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SResponse;
using SelfServiceMachine.Service.IService;

namespace SelfServiceMachine.Service.Service
{
    public class InOrderinfoService : BaseService<in_orderinfo>, IInOrderinfo
    {
        public List<BedFeeItem> GetIn_FeedItem(int inid)
        {
            return db.Queryable<in_orderfeedetail>()
                .Where(x => x.inid == inid)
                .Select(f => new BedFeeItem()
                {
                    costType = f.itemtype,
                    costAmout = f.totalprices * 100,
                    costName = f.itemname
                }).ToList();
        }
    }
}
