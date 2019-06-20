using System;
using System.Linq;
using System.Linq.Expressions;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;
using SqlSugar;

namespace SelfServiceMachine.Bussiness
{
    public class InReginfoBLL
    {
        private IInReginfo iInReginfo = new InReginfoService();

        public in_reginfo GetReginfo(string inid)
        {
            var exp = Expressionable.Create<in_reginfo>()
                .And(x => x.inid == Convert.ToInt32(inid))
                .ToExpression();
            return iInReginfo.Get(exp);
        }

        public in_reginfo GetDescFirst(Expression<Func<in_reginfo, bool>> whereLambda)
        {
            return iInReginfo.GetList(whereLambda).OrderByDescending(x => x.addtime).FirstOrDefault();
        }

        public object GetOutDate(int inid)
        {
            return iInReginfo.GetOutDate(inid);
        }

        public string GetInCount(string idno)
        {
            return iInReginfo.GetInCount(idno);
        }
    }
}
