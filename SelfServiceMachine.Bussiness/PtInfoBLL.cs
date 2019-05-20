using SelfServiceMachine.Entity;
using SelfServiceMachine.Model;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;

namespace SelfServiceMachine.Bussiness
{
    public class PtInfoBLL
    {
        private IPtInfo IPtInfo = new PtInfoService();

        public pt_info GetById(long id)
        {
            return IPtInfo.Get(id);
        }

        public TableModel<pt_info> GetPageList(int pageIndex, int pageSize)
        {
            return IPtInfo.GetPageList(pageIndex, pageSize);
        }

        public MessageModel<pt_info> Add(pt_info entity)
        {
            if (IPtInfo.Add(entity))
                return new MessageModel<pt_info> { Success = true, Msg = "操作成功" };
            else
                return new MessageModel<pt_info> { Success = false, Msg = "操作失败" };
        }

        public MessageModel<pt_info> Update(pt_info entity)
        {
            if (IPtInfo.Update(entity))
                return new MessageModel<pt_info> { Success = true, Msg = "操作成功" };
            else
                return new MessageModel<pt_info> { Success = false, Msg = "操作失败" };
        }

        public MessageModel<pt_info> Dels(dynamic[] ids)
        {
            if (IPtInfo.Dels(ids))
                return new MessageModel<pt_info> { Success = true, Msg = "操作成功" };
            else
                return new MessageModel<pt_info> { Success = false, Msg = "操作失败" };
        }
    }
}
