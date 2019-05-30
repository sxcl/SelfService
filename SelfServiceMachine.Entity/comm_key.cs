using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SelfServiceMachine.Entity
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("comm_key")]
    public partial class comm_key
    {
           public comm_key(){


           }
           /// <summary>
           /// Desc:字段名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string type {get;set;}

           /// <summary>
           /// Desc:序列号头
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string headname {get;set;}

           /// <summary>
           /// Desc:序列号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? id {get;set;}

           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int sn {get;set;}

    }
}
