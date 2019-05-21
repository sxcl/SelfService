using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SelfServiceMachine.Entity
{
    ///<summary>
    ///2.5预约号源
    ///</summary>
    [SugarTable("reg_arrange")]
    public partial class reg_arrange
    {
           public reg_arrange(){


           }
           /// <summary>
           /// Desc:号类
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string regtype {get;set;}

           /// <summary>
           /// Desc:科室
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string dept {get;set;}

           /// <summary>
           /// Desc:医生
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string doctor {get;set;}

           /// <summary>
           /// Desc:收费项目id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string itemid {get;set;}

           /// <summary>
           /// Desc:收费项目
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string itemname {get;set;}

           /// <summary>
           /// Desc:挂号id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? regno {get;set;}

           /// <summary>
           /// Desc:挂号日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? bookdate {get;set;}

           /// <summary>
           /// Desc:开始时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string booktime1 {get;set;}

           /// <summary>
           /// Desc:结束时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string booktime2 {get;set;}

           /// <summary>
           /// Desc:号码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string arrayno {get;set;}

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
           public int argid {get;set;}

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
           public int? mgrid {get;set;}

    }
}
