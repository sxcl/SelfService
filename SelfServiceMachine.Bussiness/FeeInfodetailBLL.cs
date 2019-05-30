using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Bussiness
{
    public class FeeInfodetailBLL
    {
        private IFeeinfodetail iFeeinfodetail = new FeeinfodetailService();

        public bool Adds(List<fee_infodetail> fee_Infodetails)
        {
            return iFeeinfodetail.Adds(fee_Infodetails.ToArray());
        }

        public List<Entity.SResponse.PayFeeDetailItem> GetPayFeeDetailItems(int feeid)
        {
            return iFeeinfodetail.GetPayFeeDetailItems(feeid);
        }

        public List<fee_infodetail> GetFee_Infodetails(int feeid)
        {
            return iFeeinfodetail.GetList(x=>x.feeid == feeid && x.del == true);
        }

        public bool Updates(List<fee_infodetail> fee_Infodetails)
        {
            return iFeeinfodetail.Updates(fee_Infodetails);
        }
    }
}
