using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SelfServiceMachine.Entity
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("in_insurance")]
    public partial class in_insurance
    {
           public in_insurance(){


           }
           /// <summary>
           /// Desc:住院主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int indid {get;set;}

           /// <summary>
           /// Desc:医疗费总额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? ttprice {get;set;}

           /// <summary>
           /// Desc:医保基金支付金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? fundttprice {get;set;}

           /// <summary>
           /// Desc:医保个人账户支付金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? fundselfttprice {get;set;}

           /// <summary>
           /// Desc:个人现金支付金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? selfttprice {get;set;}

           /// <summary>
           /// Desc:比例自付
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? percentprice {get;set;}

           /// <summary>
           /// Desc:住院起付线
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? startprice {get;set;}

           /// <summary>
           /// Desc:自费部分
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? selfprice {get;set;}

           /// <summary>
           /// Desc:添加时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? addtime {get;set;}

    }
}
