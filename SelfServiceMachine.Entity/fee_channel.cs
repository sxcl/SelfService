using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SelfServiceMachine.Entity
{
    ///<summary>
    ///3.4病人结账方式
    ///</summary>
    [SugarTable("fee_channel")]
    public partial class fee_channel
    {
           public fee_channel(){


           }
           /// <summary>
           /// Desc:收费id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? feeid {get;set;}

           /// <summary>
           /// Desc:支付方式
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string chnn {get;set;}

           /// <summary>
           /// Desc:金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? amount {get;set;}

           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int chnnid {get;set;}

           /// <summary>
           /// Desc:是否删除
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public bool? del {get;set;}

    }
}
