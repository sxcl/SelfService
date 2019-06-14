using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SelfServiceMachine.Entity
{
    ///<summary>
    ///8.3住院记录医嘱单
    ///</summary>
    [SugarTable("in_orderinfo")]
    public partial class in_orderinfo
    {
           public in_orderinfo(){


           }
           /// <summary>
           /// Desc:就诊id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? visid {get;set;}

           /// <summary>
           /// Desc:患者id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? pid {get;set;}

           /// <summary>
           /// Desc:入院记录主键
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? inid {get;set;}

           /// <summary>
           /// Desc:医嘱主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int billid {get;set;}

           /// <summary>
           /// Desc:开嘱时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? btime {get;set;}

           /// <summary>
           /// Desc:患者姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string pname {get;set;}

           /// <summary>
           /// Desc:患者年龄
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string age {get;set;}

           /// <summary>
           /// Desc:性别
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string sex {get;set;}

           /// <summary>
           /// Desc:地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string addr {get;set;}

           /// <summary>
           /// Desc:手机
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string tel {get;set;}

           /// <summary>
           /// Desc:诊断
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string diag {get;set;}

           /// <summary>
           /// Desc:诊断编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string diagcode {get;set;}

           /// <summary>
           /// Desc:体格检查
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string phyexam {get;set;}

           /// <summary>
           /// Desc:辅助检查
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string supexam {get;set;}

           /// <summary>
           /// Desc:临床诊断
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string examdiag {get;set;}

           /// <summary>
           /// Desc:检查目的
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string examaim {get;set;}

           /// <summary>
           /// Desc:医嘱类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ordertype {get;set;}

           /// <summary>
           /// Desc:备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string memo {get;set;}

           /// <summary>
           /// Desc:开嘱科室
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string billdept {get;set;}

           /// <summary>
           /// Desc:开嘱医生
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string doctor {get;set;}

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

           /// <summary>
           /// Desc:医技单打印时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? printtime {get;set;}

           /// <summary>
           /// Desc:中医诊断
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string tcmdiag {get;set;}

           /// <summary>
           /// Desc:	中医诊断编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string tcmdiagcode {get;set;}

           /// <summary>
           /// Desc:中医症候
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string symptom {get;set;}

           /// <summary>
           /// Desc:中医症候编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string symptomcode {get;set;}

    }
}
