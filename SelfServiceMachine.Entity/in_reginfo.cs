using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SelfServiceMachine.Entity
{
    ///<summary>
    ///8.1入院登记
    ///</summary>
    [SugarTable("in_reginfo")]
    public partial class in_reginfo
    {
           public in_reginfo(){


           }
           /// <summary>
           /// Desc:患者id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? pid {get;set;}

           /// <summary>
           /// Desc:保险机构
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string comp {get;set;}

           /// <summary>
           /// Desc:电脑号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string yno {get;set;}

           /// <summary>
           /// Desc:医保卡号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ycno {get;set;}

           /// <summary>
           /// Desc:社保登记号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string yregno {get;set;}

           /// <summary>
           /// Desc:就业状态
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string jstatus {get;set;}

           /// <summary>
           /// Desc:险种
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ytype {get;set;}

           /// <summary>
           /// Desc:结算前余额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? befamount {get;set;}

           /// <summary>
           /// Desc:住院号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string inno {get;set;}

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
           /// Desc:证件号码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string idno {get;set;}

           /// <summary>
           /// Desc:证件类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string idtype {get;set;}

           /// <summary>
           /// Desc:婚姻状态
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string marriage {get;set;}

           /// <summary>
           /// Desc:血型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string bloodtype {get;set;}

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
           /// Desc:职业
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string job {get;set;}

           /// <summary>
           /// Desc:费别
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string feetype {get;set;}

           /// <summary>
           /// Desc:医保等级
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string yblevel {get;set;}

           /// <summary>
           /// Desc:现住址省区市
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string nowaddrarea {get;set;}

           /// <summary>
           /// Desc:现住址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string nowaddr {get;set;}

           /// <summary>
           /// Desc:户口地址省区市
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string rgstaddrarea {get;set;}

           /// <summary>
           /// Desc:户口地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string rgstaddr {get;set;}

           /// <summary>
           /// Desc:出生地址省市区
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string born {get;set;}

           /// <summary>
           /// Desc:出生地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string bornaddr {get;set;}

           /// <summary>
           /// Desc:籍贯省市区
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string nativeaddrarea {get;set;}

           /// <summary>
           /// Desc:移动电话
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string tel {get;set;}

           /// <summary>
           /// Desc:工作单位
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string company {get;set;}

           /// <summary>
           /// Desc:联系人姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string contactname {get;set;}

           /// <summary>
           /// Desc:联系人电话
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string contacttel {get;set;}

           /// <summary>
           /// Desc:联系人地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string contactaddr {get;set;}

           /// <summary>
           /// Desc:联系人关系
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string prelation {get;set;}

           /// <summary>
           /// Desc:入院科室
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string indept {get;set;}

           /// <summary>
           /// Desc:入院病区
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string inarea {get;set;}

           /// <summary>
           /// Desc:入院次数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? qty {get;set;}

           /// <summary>
           /// Desc:住院床位
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string bedno {get;set;}

           /// <summary>
           /// Desc:是否包房
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public bool? allroom {get;set;}

           /// <summary>
           /// Desc:护理等级
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string nursing {get;set;}

           /// <summary>
           /// Desc:饮食情况
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string food {get;set;}

           /// <summary>
           /// Desc:责任护士
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string prinurse {get;set;}

           /// <summary>
           /// Desc:管床护士
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string bednurse {get;set;}

           /// <summary>
           /// Desc:住院医师
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string resident {get;set;}

           /// <summary>
           /// Desc:上级医师
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string charge {get;set;}

           /// <summary>
           /// Desc:门诊医生
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string opdoctor {get;set;}

           /// <summary>
           /// Desc:门诊诊断
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string opdiag {get;set;}

           /// <summary>
           /// Desc:入院诊断
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string indiag {get;set;}

           /// <summary>
           /// Desc:诊断编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string diagcode {get;set;}

           /// <summary>
           /// Desc:入院类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string intype {get;set;}

           /// <summary>
           /// Desc:入院方式
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string way {get;set;}

           /// <summary>
           /// Desc:入院病况
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string situation {get;set;}

           /// <summary>
           /// Desc:入院时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? intime {get;set;}

           /// <summary>
           /// Desc:入科时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? indepttime {get;set;}

           /// <summary>
           /// Desc:病人状态
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string status {get;set;}

           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int inid {get;set;}

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
           /// Desc:是否删除
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public bool? del {get;set;}

           /// <summary>
           /// Desc:参保地
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string areano {get;set;}

    }
}
