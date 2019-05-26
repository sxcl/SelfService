using SelfServiceMachine.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SelfServiceMachine.Service.Service
{
    /// <summary>
    /// 服务层基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseService<T> where T : class, new()
    {


        public SqlSugarClient db;
        public SimpleClient sdb;

        public BaseService()
        {
            db = GetClient();
            this.sdb = db.GetSimpleClient();
        }

        /// <summary>
        /// 获取客户端
        /// </summary>
        /// <returns></returns>
        private SqlSugarClient GetClient()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = BaseDBConfig.ConnectionString,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true
            });
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
            return db;
        }

        #region CRUD
        public TableModel<T> GetPageList(int pageIndex, int pageSize)
        {
            PageModel p = new PageModel()
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            Expression<Func<T, bool>> ex = (it => 1 == 1);
            List<T> data = sdb.GetPageList(ex, p);
            var t = new TableModel<T>
            {
                Code = 0,
                Count = p.PageCount,
                Data = data,
                Msg = "成功"
            };
            return t;
        }

        public T Get(long id)
        {
            return db.Queryable<T>().InSingle(id);
        }

        public T Get(Expression<Func<T, bool>> whereLambda)
        {
            return db.Queryable<T>().Where(whereLambda).First();
        }

        public List<T> GetList(Expression<Func<T, bool>> whereLambda)
        {
            return db.Queryable<T>().Where(whereLambda).ToList();
        }

        public bool Add(T entity)
        {
            return sdb.Insert(entity);
        }

        public bool Update(T entity)
        {
            return sdb.Update(entity);
        }

        public bool Dels(dynamic[] ids)
        {
            return sdb.DeleteByIds<T>(ids);
        }
        #endregion
    }
}
