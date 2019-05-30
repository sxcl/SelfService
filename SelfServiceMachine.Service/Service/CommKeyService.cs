using SelfServiceMachine.Entity;
using SelfServiceMachine.Service.IService;

namespace SelfServiceMachine.Service.Service
{
    public class CommKeyService : BaseService<comm_key>, ICommKey
    {
        public int GetMZNO()
        {
            db.Ado.ExecuteCommand("update comm_key set id += 1 where type = '门诊流水号' and headname = 'MZ'");
            return db.Ado.GetInt("select id from comm_key where type = '门诊流水号' and headname = 'MZ'");
        }

        public int GetYBDJH()
        {
            db.Ado.ExecuteCommand("update comm_key set id += 1 where type = '医保费用单据号' and headname = 'YBFYDJH'");
            return db.Ado.GetInt("select id from comm_key where type = '医保费用单据号' and headname = 'YBFYDJH'");
        }

        public int GetYBXLH()
        {
            db.Ado.ExecuteCommand("update comm_key set id += 1 where type = '医保费用序列号' and headname = 'YBFYXLH'");
            return db.Ado.GetInt("select id from comm_key where type = '医保费用序列号' and headname = 'YBFYXLH'");
        }

        public int GetYBNO()
        {
            db.Ado.ExecuteCommand("update comm_key set id += 1 where type = '医保流水号' and headname = 'YB'");
            return db.Ado.GetInt("select id from comm_key where type = '医保流水号' and headname = 'YB'");
        }
    }
}
