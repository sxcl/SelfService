using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SelfServiceMachine.Entity
{
    ///<summary>
    ///3.5住院预交金
    ///</summary>
    [SugarTable("fee_deposit")]
    public partial class fee_deposit
    {
           public fee_deposit(){


           }
           /// <summary>
           /// Desc:患者id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? pid {get;set;}

           /// <summary>
           /// Desc:住院号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string inno {get;set;}

           /// <summary>
           /// Desc:费别
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string feetype {get;set;}

           /// <summary>
           /// Desc:入院登记主键
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? inid {get;set;}

           /// <summary>
           /// Desc:患者姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string pname {get;set;}

           /// <summary>
           /// Desc:性别
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string sex {get;set;}

           /// <summary>
           /// Desc:年龄
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string age {get;set;}

           /// <summary>
           /// Desc:收费科室
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string dept {get;set;}

           /// <summary>
           /// Desc:总额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? totalprice {get;set;}

           /// <summary>
           /// Desc:余额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? leftprice {get;set;}

           /// <summary>
           /// Desc:状态
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string status {get;set;}

           /// <summary>
           /// Desc:添加人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string addperson {get;set;}

           /// <summary>
           /// Desc:新增时间
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
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int did {get;set;}

           /// <summary>
           /// Desc:是否删除
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public bool? del {get;set;}

    }
}
