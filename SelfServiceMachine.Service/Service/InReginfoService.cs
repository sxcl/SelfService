using System;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;

namespace SelfServiceMachine.Service.Service
{
    public class InReginfoService : BaseService<in_reginfo>, IInReginfo
    {
        public string GetInCount(string idno)
        {
            var query = "select count(1) from in_reginfo where idno = @idno group by idno";
            return db.Ado.GetString(query, new { idno });
        }

        public object GetOutDate(int inid)
        {
            var query = "select addtime from in_sheet where inid = @inid and situation = '出院'";
            var date = db.Ado.GetString(query, new { inid });
            if (date == null)
            {
                return null;
            }
            else
            {
                return date;
            }
        }
    }
}
