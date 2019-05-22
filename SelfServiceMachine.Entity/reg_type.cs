using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SelfServiceMachine.Entity
{
    ///<summary>
    ///2.3挂号类型
    ///</summary>
    [SugarTable("reg_type")]
    public partial class reg_type
    {
           public reg_type(){


           }
           /// <summary>
           /// Desc:编号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string regtno {get;set;}

           /// <summary>
           /// Desc:挂号类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string regtype {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? deptid {get;set;}

           /// <summary>
           /// Desc:挂号科室
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string dept {get;set;}

           /// <summary>
           /// Desc:挂号医生
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
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int regtid {get;set;}

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
           public DateTime? addtime {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? moditime {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string addperson {get;set;}

           /// <summary>
           /// Desc:公共号，0否1是
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public bool? iscomm {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? uid {get;set;}

    }
}
