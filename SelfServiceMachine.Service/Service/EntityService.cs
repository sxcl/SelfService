using SelfServiceMachine.Model;
using SelfServiceMachine.Service.IService;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Service.Service
{
    /// <summary>
    /// 实体操作服务
    /// </summary>
    public class EntityService : BaseDB, IEntity
    {
        public SqlSugarClient db = GetClient();
        /// <summary>
        /// 生成实体类
        /// </summary>
        /// <param name="entityName"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool CreateEntity(string entityName, string filePath, string nameSpace)
        {
            try
            {
                db.DbFirst.IsCreateAttribute().Where(entityName).CreateClassFile(filePath, nameSpace);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
