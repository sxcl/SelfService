﻿using SelfServiceMachine.Common;
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

        public List<Entity.SResponse.MZFeeDetail> GetMZFeeDetails(string visid, string billid)
        {
            return iOrderinfo.GetMZFeeDetails(visid, billid);
        }

        public bool GetHasOrderByVisid(string mzFeeIdList)
        {
            return iOrderinfo.HasOrderByVisid(Convert.ToInt32(mzFeeIdList));
        }

        public List<order_info> GetMZFeeByBillids(string recipeNo)
        {
            return iOrderinfo.GetMZFeeByBillids(recipeNo).Where(x => x.bstatus == "已发送").ToList();
        }

        public bool PayOrder(int[] billid)
        {
            return false;
        }

        public List<order_info> GetOrderByVisid(int visid)
        {
            return iOrderinfo.GetList(x => x.visid == visid);
        }

        public bool Updates(List<order_info> orderInfoList)
        {
            return iOrderinfo.Updates(orderInfoList);
        }
    }
}
