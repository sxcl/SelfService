﻿using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.ViewModels;
using SelfServiceMachine.Model;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SelfServiceMachine.Bussiness
{
    public class PtInfoBLL
    {
        private IPtInfo IPtInfo = new PtInfoService();

        public pt_info GetPtInfoByCardNo(string patName, int patCardType, string patCardNo)
        {
            pt_info pt_Info = null;
            switch (patCardType)
            {
                case 1:
                    pt_Info = IPtInfo.Get(x => x.cno == patCardNo);
                    break;
                case 2:
                    pt_Info = IPtInfo.Get(x => x.yno == patCardNo);
                    break;
                case 3:
                    pt_Info = IPtInfo.Get(x => x.yno == patCardNo);
                    break;
                case 5:
                    pt_Info = IPtInfo.Get(patCardNo);
                    break;
                case 10:
                    pt_Info = IPtInfo.Get(x => x.tel == patCardNo);
                    break;
                default:
                    pt_Info = IPtInfo.Get(x => x.cno == patCardNo);
                    break;
            }
            return pt_Info;
        }

        public pt_info GetPt_Info(Expression<Func<pt_info,bool>> whereLambda)
        {
            return IPtInfo.Get(whereLambda);
        }

        public pt_info GetInfoByCard(string PatId,string PatName)
        {
            return IPtInfo.Get(x => x.idno == PatId);
        }

        public bool BindCard(string idno, string cno, string pname)
        {
            var ptInfoList = IPtInfo.GetList(x => x.idno == idno && x.pname == pname);
            if (ptInfoList == null)
            {
                return false;
            }

            ptInfoList.ForEach(x => x.cno = cno);

            return false;
        }

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

        public List<MembershipModels> GetMembershipModels()
        {
            return IPtInfo.GetMembership();
        }
    }
}
