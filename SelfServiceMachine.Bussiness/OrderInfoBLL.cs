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

        public List<Entity.SResponse.MZFeeList> GetMZFeeLists(int cardType, string cardNo,string beginDate,string endDate)
        {
            var para = CodeConvertUtils.GetCardTypeByType(cardType);
            para += " = '" + cardNo + "'";

            return iOrderinfo.GetMZFeeLists(para);
        }

        public List<Entity.SResponse.MZFeeDetail> GetMZFeeDetails(string regid, string billid)
        {
            return iOrderinfo.GetMZFeeDetails(regid, billid);
        }

        public List<order_info> GetMZOrderInfo(string regid, string billid)
        {
            return iOrderinfo.GetMZOrderInfo(Convert.ToInt32(regid), billid);
        }

        public bool GetHasOrderByRegid(string mzFeeIdList)
        {
            return iOrderinfo.HasOrderByRegid(Convert.ToInt32(mzFeeIdList));
        }

        public List<order_info> GetMZFeeByBillids(string recipeNo)
        {
            return iOrderinfo.GetMZFeeByBillids(recipeNo).Where(x => x.bstatus == "已发送").ToList();
        }

        public bool PayOrder(int[] billid)
        {
            return false;
        }

        public List<order_info> GetOrderByRegId(int regid)
        {
            return iOrderinfo.GetList(x => x.regid == regid);
        }

        public bool Updates(List<order_info> orderInfoList)
        {
            return iOrderinfo.Updates(orderInfoList);
        }

        public List<order_info> Get(int regid, string billid)
        {
            if (string.IsNullOrWhiteSpace(billid))
            {
                return iOrderinfo.GetList(x => x.regid == regid);
            }
            else
            {
                return iOrderinfo.GetMZFeeByBillids(billid);
            }
        }
    }
}
