using SelfServiceMachine.Entity.SResponse;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;
using System.Collections.Generic;

namespace SelfServiceMachine.Bussiness
{
    public class InOrderinfoBLL
    {
        private IInOrderinfo iInOrderinfo = new InOrderinfoService();

        public List<BedFeeItem> GetIn_FeedItem(int inid)
        {
            return iInOrderinfo.GetIn_FeedItem(inid);
        }
    }
}
