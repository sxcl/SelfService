using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SelfServiceMachine.Entity
{
    ///<summary>
    ///10.10科室管理
    ///</summary>
    [SugarTable("sys_dept")]
    public partial class sys_dept
    {
           public sys_dept(){


           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int id {get;set;}

           /// <summary>
           /// Desc:编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string code {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string hosp {get;set;}

           /// <summary>
           /// Desc:名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string name {get;set;}

           /// <summary>
           /// Desc:父id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? fid {get;set;}

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
           /// Desc:业务性质
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string type {get;set;}

           /// <summary>
           /// Desc:科室描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string contents {get;set;}

           /// <summary>
           /// Desc:科室楼层
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string floor {get;set;}

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
           /// Desc:
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public bool? del {get;set;}

           /// <summary>
           /// Desc:医保编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ybno {get;set;}

    }
}
