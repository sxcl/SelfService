using System.Collections.Generic;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;

namespace SelfServiceMachine.Service.Service
{
    public class OrderfeedetailService : BaseService<order_feedetail>, IOrderfeedetail
    {
        public List<order_feedetail> GetOrder_Feedetails(int[] billid)
        {
            var inList = db.Queryable<order_feedetail>().In(x => x.billid, billid).ToList();

            return inList;
        }
    }
}
