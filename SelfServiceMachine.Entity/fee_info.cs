using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SelfServiceMachine.Entity
{
    ///<summary>
    ///3.1病人结账信息
    ///</summary>
    [SugarTable("fee_info")]
    public partial class fee_info
    {
           public fee_info(){


           }
           /// <summary>
           /// Desc:收费id
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int feeid {get;set;}

           /// <summary>
           /// Desc:门诊号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? mzno {get;set;}

           /// <summary>
           /// Desc:患者id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? pid {get;set;}

           /// <summary>
           /// Desc:挂号id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? regid {get;set;}

           /// <summary>
           /// Desc:单据号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string billno {get;set;}

           /// <summary>
           /// Desc:发票号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string invno {get;set;}

           /// <summary>
           /// Desc:收费类型,0门诊1住院2挂号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? ftype {get;set;}

           /// <summary>
           /// Desc:应收金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? amountrec {get;set;}

           /// <summary>
           /// Desc:实收金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? amountcol {get;set;}

           /// <summary>
           /// Desc:应找
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? amountbak {get;set;}

           /// <summary>
           /// Desc:尾数处理
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? mantissa {get;set;}

           /// <summary>
           /// Desc:收费员id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? userid {get;set;}

           /// <summary>
           /// Desc:收费员
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string username {get;set;}

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
           /// Desc:打印次数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? printqty {get;set;}

           /// <summary>
           /// Desc:冲销id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? feeidoff {get;set;}

           /// <summary>
           /// Desc:标记
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? signs {get;set;}

           /// <summary>
           /// Desc:收费状态
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
           /// Desc:交易流水号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string sno {get;set;}

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
           public string extern_memo {get;set;}

    }
}
