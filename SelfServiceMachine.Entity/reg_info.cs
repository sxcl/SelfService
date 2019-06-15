using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SelfServiceMachine.Entity
{
    ///<summary>
    ///2.2挂号信息
    ///</summary>
    [SugarTable("reg_info")]
    public partial class reg_info
    {
           public reg_info(){


           }
           /// <summary>
           /// Desc:患者id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? pid {get;set;}

           /// <summary>
           /// Desc:号源id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? argid {get;set;}

           /// <summary>
           /// Desc:挂号类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string rtype {get;set;}

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
           /// Desc:费别
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string feetype {get;set;}

           /// <summary>
           /// Desc:门诊号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int mzno {get;set;}

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
           /// Desc:年龄类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string agetype {get;set;}

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
           /// Desc:来院途径
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string psource {get;set;}

           /// <summary>
           /// Desc:电话
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string tel {get;set;}

           /// <summary>
           /// Desc:备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string memo {get;set;}

           /// <summary>
           /// Desc:联系人姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string pname2 {get;set;}

           /// <summary>
           /// Desc:联系人电话
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ptel2 {get;set;}

           /// <summary>
           /// Desc:联系人地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string paddr3 {get;set;}

           /// <summary>
           /// Desc:与患者关系
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string prelation {get;set;}

           /// <summary>
           /// Desc:挂号状态
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string status {get;set;}

           /// <summary>
           /// Desc:有效期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? validate {get;set;}

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
           public int regid {get;set;}

           /// <summary>
           /// Desc:是否删除
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public bool? del {get;set;}

           /// <summary>
           /// Desc:公共号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public bool? iscomm {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string doctor2 {get;set;}

    }
}
