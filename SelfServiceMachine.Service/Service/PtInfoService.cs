﻿using SelfServiceMachine.Entity;
using SelfServiceMachine.Model;
using SelfServiceMachine.Service.IService;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SelfServiceMachine.Service.Service
{
    public class PtInfoService : BaseDB, IPtInfo
    {
        public SimpleClient<pt_info> pdb = new SimpleClient<pt_info>(BaseDB.GetClient());
        #region base
        public bool Add(pt_info entity)
        {
            return pdb.Insert(entity);
        }

        public bool Dels(dynamic[] ids)
        {
            return pdb.DeleteByIds(ids);
        }

        public pt_info Get(long id)
        {
            return pdb.GetById(id);
        }

        public TableModel<pt_info> GetPageList(int pageIndex, int pageSize)
        {
            PageModel p = new PageModel() { PageIndex = pageIndex, PageSize = pageSize };
            Expression<Func<pt_info, bool>> ex = (it => 1 == 1);
            List<pt_info> data = pdb.GetPageList(ex, p);
            TableModel<pt_info> t = new TableModel<pt_info>
            {
                Code = 0,
                Count = p.PageCount,
                Data = data,
                Msg = "成功"
            };
            return t;
        }

        public bool Update(pt_info entity)
        {
            return pdb.Update(entity);
        } 
        #endregion
    }
}