using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SelfServiceMachine.Entity
{
    ///<summary>
    ///1.2会员卡明细
    ///</summary>
    [SugarTable("card_infodetail")]
    public partial class card_infodetail
    {
           public card_infodetail(){


           }
           /// <summary>
           /// Desc:外键
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? cid {get;set;}

           /// <summary>
           /// Desc:消费金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? amouts {get;set;}

           /// <summary>
           /// Desc:余额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? balance {get;set;}

           /// <summary>
           /// Desc:消费类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ctype {get;set;}

           /// <summary>
           /// Desc:消费id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? aid {get;set;}

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
           public int cdid {get;set;}

           /// <summary>
           /// Desc:是否代付
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? payforother {get;set;}

           /// <summary>
           /// Desc:代付卡号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string payforcard {get;set;}

           /// <summary>
           /// Desc:是否删除
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public bool? del {get;set;}

           /// <summary>
           /// Desc:结账信息主键
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? feeid {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string memo {get;set;}

    }
}
