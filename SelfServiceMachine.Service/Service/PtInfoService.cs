using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.ViewModels;
using SelfServiceMachine.Model;
using SelfServiceMachine.Service.IService;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SelfServiceMachine.Service.Service
{
    public class PtInfoService : BaseService<pt_info>, IPtInfo
    {
        public SimpleClient<pt_info> pdb = new SimpleClient<pt_info>(BaseDB.GetClient());
        #region base

        /// <summary>
        /// 添加患者信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public new bool Add(pt_info entity)
        {
            return pdb.Insert(entity);
        }

        /// <summary>
        /// 删除患者信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public new bool Dels(dynamic[] ids)
        {
            return pdb.DeleteByIds(ids);
        }

        /// <summary>
        /// 获取单个患者
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public new pt_info Get(long id)
        {
            return pdb.GetById(id);
        }

        /// <summary>
        /// 通过拉姆达表达式获取患者信息
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public new pt_info Get(Expression<Func<pt_info, bool>> whereLambda)
        {
            return pdb.GetList(whereLambda).FirstOrDefault();
        }

        public pt_info Get(string idno)
        {
            var query = "select * from pt_info where idno = @idno";
            return db.Ado.SqlQuerySingle<pt_info>(query, new { idno });
        }

        public new List<pt_info> GetList(Expression<Func<pt_info, bool>> whereLambda)
        {
            return pdb.GetList(whereLambda);
        }

        public List<MembershipModels> GetMembership()
        {
            var list = db.Queryable<card_info, pt_info>((ci, pt) => new object[] {
            JoinType.Left,ci.pid == pt.pid})
            .Select<MembershipModels>().Where(ci => ci.Cno != null).Take(200).ToList();
            return list;
        }

        public new TableModel<pt_info> GetPageList(int pageIndex, int pageSize)
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

        public new bool Update(pt_info entity)
        {
            return pdb.Update(entity);
        }
        #endregion
    }
}
