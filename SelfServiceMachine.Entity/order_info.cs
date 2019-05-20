using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SelfServiceMachine.Entity
{
    ///<summary>
    ///5.2就诊记录医嘱单
    ///</summary>
    [SugarTable("order_info")]
    public partial class order_info
    {
           public order_info(){


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
           /// Desc:门诊号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string mzno {get;set;}

           /// <summary>
           /// Desc:挂号主键
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? regid {get;set;}

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
           /// Desc:诊断编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string diagcode {get;set;}

           /// <summary>
           /// Desc:检查目的
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string examaim {get;set;}

           /// <summary>
           /// Desc:医嘱状态
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string bstatus {get;set;}

           /// <summary>
           /// Desc:收费时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? feetime {get;set;}

           /// <summary>
           /// Desc:收费状态
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string feestatus {get;set;}

           /// <summary>
           /// Desc:执行状态
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string zstatus {get;set;}

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
           /// Desc:开单科室
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string dept {get;set;}

           /// <summary>
           /// Desc:开嘱医生
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string doctor {get;set;}

           /// <summary>
           /// Desc:合计价格
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? totprice {get;set;}

           /// <summary>
           /// Desc:微信支付
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string wxcontent {get;set;}

           /// <summary>
           /// Desc:支付宝支付
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string zfbcontent {get;set;}

           /// <summary>
           /// Desc:会员支付
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string paycontent {get;set;}

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
           /// Desc:生殖ap_id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? extern_billid {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string extern_source {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string extern_payguid {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string extern_week1 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string extern_week2 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string extern_simplify {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string extern_spouse {get;set;}

           /// <summary>
           /// Desc:中医诊断
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string tcmdiag {get;set;}

           /// <summary>
           /// Desc:中医诊断编码
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
