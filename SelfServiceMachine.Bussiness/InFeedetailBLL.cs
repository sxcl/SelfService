using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SResponse;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;
using System.Collections.Generic;

namespace SelfServiceMachine.Bussiness
{
    public class InFeedetailBLL
    {
        private IInfeedetail iInfeedetail = new InfeedetailService();

        public List<BedFeeItem> GetIn_FeedItem(int inid)
        {
            return iInfeedetail.GetBedFeeItems(inid);
        }

        public List<in_feedetail> GetIn_Feedetails(int inid)
        {
            return iInfeedetail.GetList(x => x.inid == inid);
        }

        public decimal GetNotPay(int inid)
        {
            return iInfeedetail.DidNotPay(inid);
        }
    }
}
