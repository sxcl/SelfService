using SelfServiceMachine.Common;
using SelfServiceMachine.Entity.SlefServiceModels;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;
using System.Collections.Generic;

namespace SelfServiceMachine.Bussiness
{
    public class OrderInfoBLL
    {
        private IOrderinfo iOrderinfo = new OrderinfoService();

        public List<MZFeeList> GetMZFeeLists(int cardType, string cardNo)
        {
            var para = CodeConvertUtils.GetCardTypeByType(cardType);
            para += " = " + cardNo;

            return iOrderinfo.GetMZFeeLists(para);
        }

        public List<MZFeeDetail> GetMZFeeDetails(string billid)
        {
            return iOrderinfo.GetMZFeeDetails(billid);
        }
    }
}
