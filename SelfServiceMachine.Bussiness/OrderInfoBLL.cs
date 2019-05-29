using SelfServiceMachine.Common;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SelfServiceMachine.Bussiness
{
    public class OrderInfoBLL
    {
        private IOrderinfo iOrderinfo = new OrderinfoService();

        public List<Entity.SResponse.MZFeeList> GetMZFeeLists(int cardType, string cardNo)
        {
            var para = CodeConvertUtils.GetCardTypeByType(cardType);
            para += " = '" + cardNo + "'";

            return iOrderinfo.GetMZFeeLists(para);
        }

        public List<Entity.SResponse.MZFeeDetail> GetMZFeeDetails(string billid)
        {
            return iOrderinfo.GetMZFeeDetails(billid);
        }

        public bool GetHasOrderByRegId(string mzFeeIdList)
        {
            return iOrderinfo.HasOrderByRegId(Convert.ToInt32(mzFeeIdList));
        }

        public List<order_info> GetMZFeeByBillids(string recipeNo)
        {
            return iOrderinfo.GetMZFeeByBillids(recipeNo).Where(x => x.bstatus == "已发送").ToList();
        }

        public bool PayOrder(int[] billid)
        {
            return false;
        }
    }
}
