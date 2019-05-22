using System.Collections.Generic;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;

namespace SelfServiceMachine.Service.Service
{
    public class RegInfoService : BaseService<reg_info>, IReginfo
    {
        public int GetComm(string SQL)
        {
            return db.Ado.GetInt(SQL);
        }

        public List<comm_fee> GetComm_Fees(int[] itemid, int costtype)
        {
            return db.Ado.SqlQuery<comm_fee>("select * from comm_fee where itemid in (@itemid) and costtype = @costtype", new { itemid, costtype });
        }

        public int GetMzno(List<string> SQLString)
        {
            if (SQLString.Count < 2)
            {
                return 0;
            }
            db.Ado.ExecuteCommand(SQLString[0]);
            return db.Ado.GetInt(SQLString[1]);
        }

        public List<sys_dict> GetSysDict(string SQL)
        {
            return db.Ado.SqlQuery<sys_dict>(SQL);
        }

        public bool InsertFee(fee_info fee_Info, List<fee_infodetail> fee_Infodetails, List<fee_channel> fee_Channels)
        {
            var feeid = db.Insertable(fee_Info).ExecuteReturnIdentity();
            foreach (var fee_Infodetail in fee_Infodetails)
            {
                fee_Infodetail.feeid = feeid;
                db.Insertable(fee_Infodetail);
            }

            foreach (var fee_Channel in fee_Channels)
            {
                fee_Channel.feeid = feeid;
                db.Insertable(fee_Channels);
            }
            return feeid > 0;
        }

        int IReginfo.Add(reg_info reg_Info)
        {
            return db.Insertable(reg_Info).ExecuteReturnIdentity();
        }

    }
}
