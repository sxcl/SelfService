using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SResponse;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;

namespace SelfServiceMachine.Bussiness
{
    public class FeeDepositBLL
    {
        private IFeeDeposit iFeeDeposit = new FeeDepositService();
        private IFeeDepositDetail iFeeDepositdetail = new FeeDepositDetailService();

        /// <summary>
        /// 预交金缴费
        /// </summary>
        /// <param name="in_Reginfo">入院信息</param>
        /// <param name="payType">支付类型</param>
        /// <param name="payAmount">缴费金额</param>
        /// <param name="paySno">流水号</param>
        public int AdvancePayment(in_reginfo in_Reginfo, string payType, decimal payAmount, string paySno, string memo, out decimal leftPrice)
        {
            var isFirstDeposit = true;

            var feeDeposit = iFeeDeposit.Get(x => x.inid == in_Reginfo.inid);
            if (feeDeposit == null) //判断是否第一次缴费
            {
                iFeeDeposit.Add(new fee_deposit()
                {
                    pid = in_Reginfo.pid,
                    inno = in_Reginfo.inno,
                    feetype = in_Reginfo.feetype,
                    inid = in_Reginfo.inid,
                    pname = in_Reginfo.pname,
                    sex = in_Reginfo.sex,
                    age = in_Reginfo.age,
                    dept = in_Reginfo.indept,
                    totalprice = payAmount,
                    leftprice = payAmount,
                    status = in_Reginfo.status,
                    addperson = "自助机",
                    addtime = DateTime.Now,
                    del = false
                });
                leftPrice = payAmount;
            }
            else
            {
                isFirstDeposit = false;

                feeDeposit.totalprice += payAmount;
                feeDeposit.leftprice += payAmount;

                leftPrice = Convert.ToDecimal(feeDeposit.leftprice);
            }

            var id = iFeeDepositdetail.AddReturnId(new fee_depositdetail()
            {
                did = feeDeposit.did,
                type = "预交金收费",
                paytype = payType,
                price = payAmount,
                addtime = DateTime.Now,
                addperson = "自助机缴费",
                del = false,
                paysn = paySno,
                memo = memo
            });

            if (!isFirstDeposit)
            {
                iFeeDeposit.Update(feeDeposit);
            }

            return id;
        }

        public List<DepositItem> GetDepositItems(int did, string payMode, string beginDate, string endDate, string sno)
        {
            return iFeeDepositdetail.GetDepositItems(did, payMode, beginDate, endDate, sno);
        }

        public fee_deposit GetFee_Deposit(Expression<Func<fee_deposit, bool>> whereLambda)
        {
            return iFeeDeposit.Get(whereLambda);
        }

        public List<ComplementDepositItem> GetComplementDepositItems(string beginDate,string endDate)
        {
            return iFeeDeposit.GetComplementDepositItems(beginDate, endDate);
        }
    }
}
