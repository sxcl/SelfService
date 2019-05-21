using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;
using System;

namespace SelfServiceMachine.Bussiness
{
    public class CardInfoBLL
    {
        private ICardinfo ICardinfo = new CardInfoService();
        private ICardinfodetail ICardinfodetail = new CardinfodetailService();

        public card_info CardDeposit(string czkh, string czrsfzh, string czrjzkhr, decimal czje, string czdh, string czdsfdh, string xm, string type, int feeid)
        {
            var cardinfo = ICardinfo.Get(x => x.cno == czkh);

            cardinfo.cmoney += czje;
            ICardinfodetail.Add(new card_infodetail()
            {
                cid = cardinfo.cid,
                amouts = czje,
                aid = feeid,
                feeid = feeid,
                balance = cardinfo.cmoney,
                ctype = "会员充值",
                addperson = "自助机充值",
                addtime = DateTime.Now,
                del = false,
                memo = "充值人身份证号:" + czrsfzh + ",充值人就诊卡号:" + czrjzkhr + ",充值金额:" + czje + ",充值平台订单号:" + czdh + ",充值第三方订单号:" + czdsfdh + ",充值人姓名:" + xm + ",充值方式:" + type
            });

            ICardinfo.Update(cardinfo);
            return cardinfo;
        }

        public card_info GetCardByCno(string cno)
        {
            return ICardinfo.Get(x => x.cno == cno);
        }

        public bool UpdateCard(card_info card_Info)
        {
            return ICardinfo.Update(card_Info);
        }


        public card_info CreateCard(card_info card_Info)
        {
            var res = ICardinfo.Add(card_Info);
            if (res)
            {
                return card_Info;
            }
            else
            {
                return null;
            }
        }
    }
}
