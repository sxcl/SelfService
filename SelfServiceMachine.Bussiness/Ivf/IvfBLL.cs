using SelfServiceMachine.Common;
using System;

namespace SelfServiceMachine.Bussiness.Ivf
{
    public class IvfBLL
    {
        public bool SetIvfToll(int billid, string extern_source)
        {
            try
            {
                string sql;
                if (extern_source.Equals("ivf", StringComparison.InvariantCultureIgnoreCase))
                {
                    sql = "update [192.168.100.4].ivf.dbo.pt_mainRecipe2 SET feestatus='已收费',feetime=getdate() where hisbillid=@billid";
                }
                else
                {
                    sql = "update [192.168.100.4].ivf_test.dbo.pt_mainRecipe2 SET feestatus='已收费',feetime=getdate() where hisbillid=@billid";
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

        public bool SetIvfRefund(int billid, string extern_source)
        {
            try
            {
                string sql;
                if (extern_source.Equals("ivf", StringComparison.InvariantCultureIgnoreCase))
                {
                    sql = "update [192.168.100.4].ivf.dbo.pt_mainRecipe2 SET feestatus='已退费',feetime=getdate() where hisbillid=@billid";
                }
                else
                {
                    sql = "update [192.168.100.4].ivf_test.dbo.pt_mainRecipe2 SET feestatus='已退费',feetime=getdate() where hisbillid=@billid";
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
