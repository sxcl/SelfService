using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.Insurance;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SelfServiceMachine.Bussiness
{
    public class FeeinfoBLL
    {
        private IFeeinfo iFeeinfo = new FeeinfoService();
        private IPtInfo iPtInfo = new PtInfoService();
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
                ftype = 3,
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

            return iFeechannel.Add(new fee_channel()
            {
                feeid = feeid,
                chnn = type,
                amount = amountcol,
                del = false
            });
        }

        public fee_info GetFee_Info(int feeid)
        {
            return iFeeinfo.GetFee_InfoByRegTrial(feeid);
        }

        public MZ001 GetTrialData(int regid)
        {
            return iFeeinfo.GetTrialData(regid);
        }

        public fee_info GetFee_InfoByRegInfo(int regid)
        {
            return iFeeinfo.GetList(x => x.regid == regid && x.ftype == 2).FirstOrDefault();
        }

        public bool AddFeechannel(fee_channel fee_Channel)
        {
            return iFeechannel.Add(fee_Channel);
        }

        public bool Update(fee_info fee_Info)
        {
            return iFeeinfo.Update(fee_Info);
        }

        public bool DeleteFeeInfoByRegid(int regid, string sno)
        {
            return iFeeinfo.DeleteFeeinfo(regid, sno);
        }

        public bool Add(fee_info fee_info)
        {
            return iFeeinfo.Add(fee_info);
        }

        public int AddReturnId(fee_info fee_Info)
        {
            return iFeeinfo.AddReturnId(fee_Info);
        }

        public pt_info GetFee_Infos(string cardtype, string cardno)
        {
            if (cardtype == "idno")
            {
                return iPtInfo.Get(x => x.idno == cardno);
            }
            else if (cardtype == "cno")
            {
                return iPtInfo.Get(x => x.cno == cardno);
            }
            else if (cardtype == "yno")
            {
                return iPtInfo.Get(x => x.yno == cardno);
            }
            else if (cardtype == "ybidentity")
            {
                return iPtInfo.Get(x => x.ybidentity == cardno);
            }
            else if (cardtype == "tel")
            {
                return iPtInfo.Get(x => x.tel == cardno);
            }
            else
            {
                return iPtInfo.Get(x => x.idno == cardno);
            }
        }

        public List<Entity.SResponse.getPayItem> GetPayItems(int pid)
        {
            return iFeeinfo.GetPayItems(pid);
        }

        public fee_info Get(string sno)
        {
            return iFeeinfo.Get(x => x.sno == sno);
        }
    }
}
