using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Bussiness
{
    public class OrderfeedetailBLL
    {
        private IOrderfeedetail iOrderfeedetail = new OrderfeedetailService();

        public List<order_feedetail> GetOrder_Feedetails(int[] billid)
        {
            return iOrderfeedetail.GetOrder_Feedetails(billid);
        }
    }
}
