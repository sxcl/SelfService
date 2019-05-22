using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Bussiness
{
    public class FeeinfoBLL
    {
        private IFeeinfo iFeeinfo = new FeeinfoService();
        private IFeeinfodetail iFeeinfodetail = new FeeinfodetailService();
        private IFeechannel iFeechannel = new FeechannelService();

        /// <summary>
        /// 充值
        /// </summary>
        /// <returns></returns>
        public bool DepositFeeinfo(int pid, int ftype, decimal amountrec, decimal amountcol, int userid, string username, string sno, string type, out int feeid)
        {
            feeid = iFeeinfo.AddReturnId(new Entity.fee_info()
            {
                pid = pid,
                ftype = 0,
                amountrec = amountrec,
                amountcol = amountcol,
                amountbak = 0,
                mantissa = 0,
                userid = 89757,
                username = "自助机",
                addtime = DateTime.Now,
                printqty = 0,
                status = 0,
                del = false,
                sno = sno
            });

            return iFeechannel.Add(new Entity.fee_channel()
            {
                feeid = feeid,
                chnn = type,
                amount = amountcol,
                del = false
            });
        }
    }
}
