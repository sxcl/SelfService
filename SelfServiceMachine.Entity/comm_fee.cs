using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SelfServiceMachine.Entity
{
    ///<summary>
    ///4.1收费项目
    ///</summary>
    [SugarTable("comm_fee")]
    public partial class comm_fee
    {
           public comm_fee(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string costtype {get;set;}

           /// <summary>
           /// Desc:诊疗id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string dgid {get;set;}

           /// <summary>
           /// Desc:项目id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string itemid {get;set;}

           /// <summary>
           /// Desc:标准编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string scode {get;set;}

           /// <summary>
           /// Desc:全国编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ccode {get;set;}

           /// <summary>
           /// Desc:项目名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string itemname {get;set;}

           /// <summary>
           /// Desc:项目别名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string aliasname {get;set;}

           /// <summary>
           /// Desc:是否套餐
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? packages {get;set;}

           /// <summary>
           /// Desc:拼音码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string pinyin {get;set;}

           /// <summary>
           /// Desc:五笔码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string wubi {get;set;}

           /// <summary>
           /// Desc:项目类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string itemtype {get;set;}

           /// <summary>
           /// Desc:财务费别
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ftype {get;set;}

           /// <summary>
           /// Desc:检验类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string labtype {get;set;}

           /// <summary>
           /// Desc:标本类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string sample {get;set;}

           /// <summary>
           /// Desc:单位
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string unit {get;set;}

           /// <summary>
           /// Desc:收费类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string pricetype {get;set;}

           /// <summary>
           /// Desc:收费价格
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? prices {get;set;}

           /// <summary>
           /// Desc:执行科室
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string dept {get;set;}

           /// <summary>
           /// Desc:有效期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? valdate {get;set;}

           /// <summary>
           /// Desc:备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string memo {get;set;}

           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int cfid {get;set;}

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
           /// Desc:状态
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? status {get;set;}

           /// <summary>
           /// Desc:是否删除
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public bool? del {get;set;}

           /// <summary>
           /// Desc:使用方式:单独,无
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string usetype {get;set;}

           /// <summary>
           /// Desc:排序号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public double? sortno {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string sname {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string cname {get;set;}

           /// <summary>
           /// Desc:卫生材料产地
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string memo2 {get;set;}

    }
}
