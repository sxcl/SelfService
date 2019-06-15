using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SRequest
{
    public class payCurReg
    {
        /// <summary>
        /// 医院代码
        /// </summary>
        public string branchCode { get; set; }
        /// <summary>
        /// 医院挂号流水号
        /// </summary>
        public string hisOrdNum { get; set; }
        /// <summary>
        /// 公众服务平台订单号
        /// </summary>
        public string psOrdNum { get; set; }
        /// <summary>
        /// 收单机构流水号
        /// </summary>
        public string agtOrdNum { get; set; }
        /// <summary>
        /// 收单机构代码
        /// </summary>
        public string agtCode { get; set; }
        /// <summary>
        /// 支付渠道
        /// </summary>
        public string payMode { get; set; }
        /// <summary>
        /// 交易方式
        /// </summary>
        public string payMethod { get; set; }
        /// <summary>
        /// 支付总金额
        /// </summary>
        public string payAmout { get; set; }
        /// <summary>
        /// 支付时间
        /// </summary>
        public string payTime { get; set; }
        /// <summary>
        /// 社保流水号
        /// </summary>
        public string SSSerialNo { get; set; }
        /// <summary>
        /// 社保缴费金额
        /// </summary>
        public string SSMoney { get; set; }
        /// <summary>
        /// 社保支付结果串
        /// </summary>
        [XmlElement("Item")]
        public List<SSItems> item { get; set; }
    }

    public class SSItems
    {
        /// <summary>
        /// 医疗费用支付项目
        /// </summary>
        public string Zfxm { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal? Je { get; set; }
    }
}
