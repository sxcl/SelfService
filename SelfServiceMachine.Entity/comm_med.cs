using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SelfServiceMachine.Entity
{
    ///<summary>
    ///4.3药品目录
    ///</summary>
    [SugarTable("comm_med")]
    public partial class comm_med
    {
           public comm_med(){


           }
           /// <summary>
           /// Desc:品种id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string varid {get;set;}

           /// <summary>
           /// Desc:品种名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string varname {get;set;}

           /// <summary>
           /// Desc:药品名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string itemname {get;set;}

           /// <summary>
           /// Desc:商品名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string commname {get;set;}

           /// <summary>
           /// Desc:商标
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string trademark {get;set;}

           /// <summary>
           /// Desc:商品编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string itemid {get;set;}

           /// <summary>
           /// Desc:类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string itemtype {get;set;}

           /// <summary>
           /// Desc:类型编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string itemtypeid {get;set;}

           /// <summary>
           /// Desc:医保编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ybcode {get;set;}

           /// <summary>
           /// Desc:全国编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ccode {get;set;}

           /// <summary>
           /// Desc:规格
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string spec {get;set;}

           /// <summary>
           /// Desc:基本单位
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string bscunit {get;set;}

           /// <summary>
           /// Desc:剂量单位
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string dsunit {get;set;}

           /// <summary>
           /// Desc:剂量包装
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? dspack {get;set;}

           /// <summary>
           /// Desc:剂型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string dosage {get;set;}

           /// <summary>
           /// Desc:门诊包装
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? dppack {get;set;}

           /// <summary>
           /// Desc:门诊单位
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string dpunit {get;set;}

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
           /// Desc:药库包装
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? storpack {get;set;}

           /// <summary>
           /// Desc:药库单位
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string storunit {get;set;}

           /// <summary>
           /// Desc:成本价
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? costprice {get;set;}

           /// <summary>
           /// Desc:售价
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? sellprice {get;set;}

           /// <summary>
           /// Desc:批准文号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string apnumber {get;set;}

           /// <summary>
           /// Desc:备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string memo {get;set;}

           /// <summary>
           /// Desc:收费类别
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string pricetype {get;set;}

           /// <summary>
           /// Desc:财务费别
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ftype {get;set;}

           /// <summary>
           /// Desc:病案费别
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string mrtype {get;set;}

           /// <summary>
           /// Desc:门诊处方职务
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string dpjob {get;set;}

           /// <summary>
           /// Desc:住院处方职务
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ipjob {get;set;}

           /// <summary>
           /// Desc:DDD值
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? ddds {get;set;}

           /// <summary>
           /// Desc:基本药物
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string basemed {get;set;}

           /// <summary>
           /// Desc:抗菌药物
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string antidrug {get;set;}

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
           /// Desc:标签
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string tags {get;set;}

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
           /// Desc:停止时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? stoptime {get;set;}

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
           public int medid {get;set;}

           /// <summary>
           /// Desc:状态
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? status {get;set;}

           /// <summary>
           /// Desc:可分次数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? dives {get;set;}

           /// <summary>
           /// Desc:产地
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string oriplace {get;set;}

           /// <summary>
           /// Desc:是否删除
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public bool? del {get;set;}

           /// <summary>
           /// Desc:偿付类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string rbtype {get;set;}

           /// <summary>
           /// Desc:药理毒性
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string toxicity {get;set;}

           /// <summary>
           /// Desc:本位码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string stdcode {get;set;}

           /// <summary>
           /// Desc:医保名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ybname {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string cname {get;set;}

           /// <summary>
           /// Desc:处方类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string recipetype {get;set;}

    }
}
