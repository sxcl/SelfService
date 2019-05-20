using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SelfServiceMachine.Entity
{
    ///<summary>
    ///2.1患者基本信息
    ///</summary>
    [SugarTable("pt_info")]
    public partial class pt_info
    {
           public pt_info(){


           }
           /// <summary>
           /// Desc:患者id
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int pid {get;set;}

           /// <summary>
           /// Desc:医保卡号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string yno {get;set;}

           /// <summary>
           /// Desc:就诊卡号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string cno {get;set;}

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
           /// Desc:证件类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string idtype {get;set;}

           /// <summary>
           /// Desc:证件号码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string idno {get;set;}

           /// <summary>
           /// Desc:出生日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? birth {get;set;}

           /// <summary>
           /// Desc:地区
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string addr1 {get;set;}

           /// <summary>
           /// Desc:详细地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string addr3 {get;set;}

           /// <summary>
           /// Desc:手机
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string tel {get;set;}

           /// <summary>
           /// Desc:工作单位
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string pcomp {get;set;}

           /// <summary>
           /// Desc:来院途径
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string psource {get;set;}

           /// <summary>
           /// Desc:过敏史
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string anaphylaxis {get;set;}

           /// <summary>
           /// Desc:备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string memo {get;set;}

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
           /// Desc:国籍
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string nationality {get;set;}

           /// <summary>
           /// Desc:民族
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string nation {get;set;}

           /// <summary>
           /// Desc:是否删除
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public bool? del {get;set;}

           /// <summary>
           /// Desc:卡识别码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ybidentity {get;set;}

           /// <summary>
           /// Desc:姓名拼音码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string pinyin {get;set;}

           /// <summary>
           /// Desc:医保加密串
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string patYbjbmc {get;set;}

           /// <summary>
           /// Desc:参保类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string patCblx {get;set;}

    }
}
