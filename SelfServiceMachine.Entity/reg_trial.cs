using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SelfServiceMachine.Entity
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("reg_trial")]
    public partial class reg_trial
    {
           public reg_trial(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int id {get;set;}

           /// <summary>
           /// Desc:费用单据号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string aae072 {get;set;}

           /// <summary>
           /// Desc:费用序列号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string bkf500 {get;set;}

           /// <summary>
           /// Desc:社保目录编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ake001 {get;set;}

           /// <summary>
           /// Desc:协议机构内部诊疗目录编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ake005 {get;set;}

           /// <summary>
           /// Desc:协议机构内部诊疗目录名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ake006 {get;set;}

           /// <summary>
           /// Desc:金额
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal aae019 {get;set;}

           /// <summary>
           /// Desc:挂号主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int regid {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime addtime {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? mzno {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string serialNumber {get;set;}

    }
}
