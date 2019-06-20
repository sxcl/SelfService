using System.Collections.Generic;
using SelfServiceMachine.Common;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SResponse;
using SelfServiceMachine.Service.IService;
using SqlSugar;

namespace SelfServiceMachine.Service.Service
{
    public class FeeDepositDetailService : BaseService<fee_depositdetail>, IFeeDepositDetail
    {
        public List<DepositItem> GetDepositItems(int did, string payMode, string beginDate, string endDate, string sno)
        {
            var list = db.Queryable<fee_depositdetail>()
                .WhereIF(!string.IsNullOrEmpty(beginDate), it => SqlFunc.Between(it.addtime, beginDate, endDate))
                .WhereIF(!string.IsNullOrEmpty(sno), it => it.paysn == sno)
                .WhereIF(!string.IsNullOrEmpty(payMode), it => it.paytype == payMode)
                .Where(x => x.did == did)
                .Select(f => new DepositItem
                {
                    branchCode = "",
                    branchName = "",
                    payAmout = (f.price * 100).ToString(),
                    hisOrdNum = f.detailid.ToString(),
                    agtOrdNum = f.paysn,
                    payMode = f.paytype.ToString(),
                    payStatus = "1",
                    balance = ""
                }).ToList();

            foreach (var item in list)
            {
                item.hisOrdNum = EString.ZeroFill(item.hisOrdNum);
                item.receiptNum = EString.ZeroFill(item.hisOrdNum);
                item.payMode = CodeConvertUtils.GetDepositType(item.payMode);
            }

            return list;
        }
    }
}
