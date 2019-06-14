using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SelfServiceMachine.Entity
{
    ///<summary>
    ///8.6住院收费明细
    ///</summary>
    [SugarTable("in_feedetail")]
    public partial class in_feedetail
    {
           public in_feedetail(){


           }
           /// <summary>
           /// Desc:入院主键
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? inid {get;set;}

           /// <summary>
           /// Desc:住院号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string inno {get;set;}

           /// <summary>
           /// Desc:患者id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? pid {get;set;}

           /// <summary>
           /// Desc:医嘱主键
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? billid {get;set;}

           /// <summary>
           /// Desc:医嘱收费id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? bdid {get;set;}

           /// <summary>
           /// Desc:诊疗项目id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string dgid {get;set;}

           /// <summary>
           /// Desc:收费项目id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string itemid {get;set;}

           /// <summary>
           /// Desc:项目名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string itemname {get;set;}

           /// <summary>
           /// Desc:规格
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string spec {get;set;}

           /// <summary>
           /// Desc:项目分类
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string itemtype {get;set;}

           /// <summary>
           /// Desc:单位
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string unit {get;set;}

           /// <summary>
           /// Desc:单价
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? prices {get;set;}

           /// <summary>
           /// Desc:数量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? qty {get;set;}

           /// <summary>
           /// Desc:总价
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? totalprice {get;set;}

           /// <summary>
           /// Desc:费别
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string feetype {get;set;}

           /// <summary>
           /// Desc:折扣
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? disc {get;set;}

           /// <summary>
           /// Desc:执行科室
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? execdept {get;set;}

           /// <summary>
           /// Desc:执行科室ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string execdeptid {get;set;}

           /// <summary>
           /// Desc:执行时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? exectime {get;set;}

           /// <summary>
           /// Desc:执行情况
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? status {get;set;}

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
           public int feedtlid {get;set;}

           /// <summary>
           /// Desc:开嘱科室
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string billdept {get;set;}

           /// <summary>
           /// Desc:是否删除
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public bool? del {get;set;}

    }
}
