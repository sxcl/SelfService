using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SelfServiceMachine.Entity
{
    ///<summary>
    ///8.4住院记录医嘱明细
    ///</summary>
    [SugarTable("in_orderdetail")]
    public partial class in_orderdetail
    {
           public in_orderdetail(){


           }
           /// <summary>
           /// Desc:医嘱主键
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? billid {get;set;}

           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int bdid {get;set;}

           /// <summary>
           /// Desc:医嘱分类
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ordertype {get;set;}

           /// <summary>
           /// Desc:诊疗id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? dgid {get;set;}

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
           /// Desc:项目类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string itemtype {get;set;}

           /// <summary>
           /// Desc:单价
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? prices {get;set;}

           /// <summary>
           /// Desc:基本单位
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string bscunit {get;set;}

           /// <summary>
           /// Desc:住院包装
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? ippack {get;set;}

           /// <summary>
           /// Desc:住院单位
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ipunit {get;set;}

           /// <summary>
           /// Desc:规格
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string spec {get;set;}

           /// <summary>
           /// Desc:每次用量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? dose {get;set;}

           /// <summary>
           /// Desc:频次
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string freq {get;set;}

           /// <summary>
           /// Desc:总量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? total {get;set;}

           /// <summary>
           /// Desc:总价
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? totalprices {get;set;}

           /// <summary>
           /// Desc:给药途径
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string way {get;set;}

           /// <summary>
           /// Desc:药品同组
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string medgroup {get;set;}

           /// <summary>
           /// Desc:检查部位
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string position {get;set;}

           /// <summary>
           /// Desc:标本类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string sample {get;set;}

           /// <summary>
           /// Desc:检验类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string labtype {get;set;}

           /// <summary>
           /// Desc:执行科室
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string execdept {get;set;}

           /// <summary>
           /// Desc:发药状态
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string medstatus {get;set;}

           /// <summary>
           /// Desc:医嘱嘱托
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string entrust {get;set;}

           /// <summary>
           /// Desc:执行方案
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string sch {get;set;}

           /// <summary>
           /// Desc:首日次数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? firstqty {get;set;}

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
           /// Desc:备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string memo {get;set;}

           /// <summary>
           /// Desc:校对时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? prooftime {get;set;}

           /// <summary>
           /// Desc:校对人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string proofperson {get;set;}

           /// <summary>
           /// Desc:停嘱时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? stoptime {get;set;}

           /// <summary>
           /// Desc:停驻人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string stopperson {get;set;}

           /// <summary>
           /// Desc:医嘱状态
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string orderstatus {get;set;}

           /// <summary>
           /// Desc:附加执行科室
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string otexecdept {get;set;}

           /// <summary>
           /// Desc:是否删除
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public bool? del {get;set;}

           /// <summary>
           /// Desc:煎法
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string decoction {get;set;}

           /// <summary>
           /// Desc:上次执行时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? lasttime {get;set;}

           /// <summary>
           /// Desc:剂型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string dosage {get;set;}

           /// <summary>
           /// Desc:医保名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ybname {get;set;}

           /// <summary>
           /// Desc:收费类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string pricetype {get;set;}

           /// <summary>
           /// Desc:确认停嘱时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? stoptime2 {get;set;}

           /// <summary>
           /// Desc:确认停嘱护士
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string stopperson2 {get;set;}

           /// <summary>
           /// Desc:审核时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? audittime {get;set;}

           /// <summary>
           /// Desc:审核者
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string auditor {get;set;}

           /// <summary>
           /// Desc:天数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? day {get;set;}

    }
}
