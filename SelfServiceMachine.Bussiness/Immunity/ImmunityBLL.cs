using SelfServiceMachine.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Bussiness.Immunity
{
    public class ImmunityBLL
    {
        public bool SetImmunityToll(int billid, string extern_source)
        {
            try
            {
                string sql;

                if (extern_source.Equals("Immunity", StringComparison.InvariantCultureIgnoreCase))
                {
                    sql = "update [192.168.100.4].Immunity.dbo.pt_mainRecipe2 SET feestatus='已收费',feetime=getdate() where hisbillid=@billid";
                }
                else
                {
                    sql = "update [192.168.100.4].Immunity2.dbo.pt_mainRecipe2 SET feestatus='已收费',feetime=getdate() where hisbillid=@billid";
                }

                var result = DbHelperSQL.ExecuteSql(sql, new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("billid",billid)
            });

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool SetImmunityRefund(int billid, string extern_source)
        {
            try
            {
                string sql;

                if (extern_source.Equals("Immunity", StringComparison.InvariantCultureIgnoreCase))
                {
                    sql = "update [192.168.100.4].Immunity.dbo.pt_mainRecipe2 SET feestatus='已退费',feetime=getdate() where hisbillid=@billid";
                }
                else
                {
                    sql = "update [192.168.100.4].Immunity2.dbo.pt_mainRecipe2 SET feestatus='已退费',feetime=getdate() where hisbillid=@billid";
                }

                var result = DbHelperSQL.ExecuteSql(sql, new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("billid",billid)
            });

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
