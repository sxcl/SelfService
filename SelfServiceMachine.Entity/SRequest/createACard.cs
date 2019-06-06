using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SRequest
{
    public class createACard
    {
        /// <summary>
        /// 医院代码
        /// </summary>
        public string branchCode { get; set; }
        /// <summary>
        /// 患者类型
        /// </summary>
        public string patType { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string patName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string patSex { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int patAge { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public string patBirth { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string patAddress { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string patMobile { get; set; }
        /// <summary>
        /// 医保卡号
        /// </summary>
        public string patYbkh { get; set; }
        /// <summary>
        /// 电脑号
        /// </summary>
        public string patDnh { get; set; }
        /// <summary>
        /// 医保加密串
        /// </summary>
        public string patYbjbmc { get; set; }
        /// <summary>
        /// 参保类型
        /// </summary>
        public string patCblx { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public int patIdType { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string patIdNo { get; set; }
        /// <summary>
        /// 监护人姓名
        /// </summary>
        public string guardName { get; set; }
        /// <summary>
        /// 监护人证件类型
        /// </summary>
        public string guardIdType { get; set; }
        /// <summary>
        /// 监护人证件号码
        /// </summary>
        public string guardIdNo { get; set; }
    }
}
