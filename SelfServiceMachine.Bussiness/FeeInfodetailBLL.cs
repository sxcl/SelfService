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
    }
}
