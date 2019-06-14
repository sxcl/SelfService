using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SelfServiceMachine.Entity
{
    ///<summary>
    ///8.2住院记录主表
    ///</summary>
    [SugarTable("in_record")]
    public partial class in_record
    {
           public in_record(){


           }
           /// <summary>
           /// Desc:就诊id
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int visid {get;set;}

           /// <summary>
           /// Desc:入院登记主键
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? inid {get;set;}

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
           /// Desc:挂号主键
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? regid {get;set;}

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
           /// Desc:是否删除
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public bool? del {get;set;}

    }
}
