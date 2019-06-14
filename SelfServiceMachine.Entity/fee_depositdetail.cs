using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SelfServiceMachine.Entity
{
    ///<summary>
    ///3.6住院预交金明细
    ///</summary>
    [SugarTable("fee_depositdetail")]
    public partial class fee_depositdetail
    {
           public fee_depositdetail(){


           }
           /// <summary>
           /// Desc:预交金主键
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? did {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string type {get;set;}

           /// <summary>
           /// Desc:金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? price {get;set;}

           /// <summary>
           /// Desc:付款方式
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string paytype {get;set;}

           /// <summary>
           /// Desc:添加时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? addtime {get;set;}

           /// <summary>
           /// Desc:修改时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? moditime {get;set;}

           /// <summary>
           /// Desc:添加人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string addperson {get;set;}

           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int detailid {get;set;}

           /// <summary>
           /// Desc:是否删除
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public bool? del {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string paysn {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string memo {get;set;}

    }
}
