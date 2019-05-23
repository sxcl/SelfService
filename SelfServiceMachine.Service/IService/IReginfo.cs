using SelfServiceMachine.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Service.IService
{
    public interface IReginfo : IBase<reg_info>
    {
        int Add(reg_info reg_Info);
        int GetMzno(List<string> SQLString);
        int GetComm(string SQL);
        List<sys_dict> GetSysDict(string SQL);
        List<comm_fee> GetComm_Fees(int[] itemid, int costtype);
        bool InsertFee(fee_info fee_Info, List<fee_infodetail> fee_Infodetails, List<fee_channel> fee_Channel);
        
    }
}
