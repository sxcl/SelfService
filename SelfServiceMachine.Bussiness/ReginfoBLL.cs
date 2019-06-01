using SelfServiceMachine.Common;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SelfServiceMachine.Bussiness
{
    public class ReginfoBLL
    {
        private IReginfo iReginfo = new RegInfoService();
        private IRegarrange iRegarrange = new RegarrangeService();
        private IFeeinfo iFeeinfo = new FeeinfoService();
        private IFeeinfodetail iFeeinfodetail = new FeeinfodetailService();

        public reg_info Add(reg_info reg_Info, pt_info pt_Info, reg_arrange reg_Arrange, string sno, out decimal amount, out int mzno, out int feeid, out List<comm_fee> commFees)
        {
            reg_Info.pid = pt_Info.pid;
            reg_Info.argid = reg_Arrange.argid;
            reg_Info.rtype = reg_Arrange.regtype;
            reg_Info.dept = reg_Arrange.dept;
            reg_Info.doctor = reg_Arrange.doctor;
            List<string> mznoQuery = new List<string>()
            {
                "update comm_key set id += 1 where sn = 52;",
                "SELECT [id] FROM [ZSHIS].[dbo].[comm_key] WHERE sn = 52"
            };

            mzno = iReginfo.GetMzno(mznoQuery);
            reg_Info.mzno = mzno;
            reg_Info.pname = pt_Info.pname;
            reg_Info.sex = pt_Info.sex;
            reg_Info.age = EString.GetAge(pt_Info.birth.ToString()).ToString();
            reg_Info.agetype = "岁";
            reg_Info.birth = pt_Info.birth;
            reg_Info.addr1 = pt_Info.addr1;
            reg_Info.addr3 = pt_Info.addr3;
            reg_Info.tel = pt_Info.tel;
            reg_Info.memo = "自助机挂号";
            reg_Info.addperson = "自助机";
            reg_Info.status = "候诊";
            reg_Info.addtime = DateTime.Now;
            reg_Info.del = true;

            var sysdictList = iReginfo.GetSysDict("SELECT [id] ,[fid] ,[code] ,[type] ,[detail] ,[sortno] ,[memo] ,[status] ,[del] ,[addtime] ,[moditime] ,[addperson] ,[fth] FROM [ZSHIS].[dbo].[sys_dict] where fid = 13999");

            var dept = string.Empty;
            if (sysdictList.Where(x => x.type == reg_Arrange.dept && x.type != "全部科室").Count() > 0)
            {
                dept = reg_Arrange.dept;
            }
            else
            {
                dept = "所有科室";
            }

            DateTime validate;
            var memo = Convert.ToInt32(sysdictList.Where(x => x.detail == reg_Info.feetype && x.type == dept).FirstOrDefault().memo);
            if (memo == 0)
            {
                validate = Convert.ToDateTime("9999-12-31");
            }
            else
            {
                validate = Convert.ToDateTime(DateTime.Now.AddDays(memo).ToShortDateString() + " 23:59:59");
            }

            var isCommQuery = "SELECT TOP 1 [iscomm] FROM [ZSHIS].[dbo].[reg_type] inner join reg_manage on reg_type.regtid = reg_manage.regtid where reg_type.del = 0 and reg_manage.del = 0 and mgrid = " + reg_Arrange.mgrid;
            reg_Info.iscomm = iReginfo.GetComm(isCommQuery) > 0;
            reg_Info.validate = validate;

            var regid = iReginfo.Add(reg_Info);
            reg_Info.regid = regid;

            List<int> itemid = new List<int>();
            itemid.Add(Convert.ToInt32(reg_Arrange.itemid));
            commFees = iReginfo.GetComm_Fees(itemid.ToArray(), reg_Info.feetype == "医疗保险" ? 5 : 3);

            fee_info fee_Info = new fee_info()
            {
                pid = pt_Info.pid,
                mzno = mzno,
                regid = regid,
                userid = 89757,
                ftype = 2,
                amountcol = commFees.Sum(x => x.prices),
                amountrec = commFees.Sum(x => x.prices),
                amountbak = 0,
                mantissa = 0,
                username = "自助机挂号",
                addtime = DateTime.Now,
                printqty = 0,
                feeidoff = 0,
                del = true,
                status = 0,
                sno = sno
            };

            feeid = iFeeinfo.AddReturnId(fee_Info);
            var FeeInfoDetail = new List<fee_infodetail>();
            foreach (var commfee in commFees)
            {
                FeeInfoDetail.Add(new fee_infodetail()
                {
                    feeid = feeid,
                    billid = 0,
                    bdid = 0,
                    dgid = commfee.dgid,
                    itemid = commfee.itemid ?? commfee.itemid,
                    itemname = commfee.itemname ?? commfee.itemname,
                    spec = "",
                    itemtype = commfee.itemtype ?? commfee.itemtype,
                    unit = commfee.unit,
                    prices = commfee.prices == 0 ? commfee.prices : commfee.prices,
                    qty = 1,
                    totalprice = commfee.prices == 0 ? commfee.prices * 1 : commfee.prices * 1,
                    feetype = reg_Info.feetype,
                    disc = 0,
                    execdept = reg_Arrange.dept,
                    exectime = DateTime.Now,
                    addtime = DateTime.Now,
                    del = true,
                    addperson = "自助机缴费",
                    status = 0
                });
            }
            amount = Convert.ToDecimal(commFees.Sum(x => x.prices) * 100);

            iFeeinfodetail.Adds(FeeInfoDetail.ToArray());
            reg_Arrange.regno = reg_Info.regid;
            reg_Arrange.moditime = DateTime.Now;
            iRegarrange.Update(reg_Arrange);
            return reg_Info;
        }

        public reg_info GetReg_Info(int regid)
        {
            return iReginfo.Get(regid);
        }

        public bool DeleteReginfo(int regid)
        {
            return iReginfo.Del(regid);
        }

        public bool UpdateRegInfo(reg_info reg_Info)
        {
            return iReginfo.Update(reg_Info);
        }

        public reg_info Get(Expression<Func<reg_info, bool>> whereLambda)
        {
            return iReginfo.Get(whereLambda);
        }
    }
}
