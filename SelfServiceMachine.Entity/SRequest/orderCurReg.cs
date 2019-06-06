using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SRequest
{
    public class orderCurReg
    {
        /// <summary>
        /// 公众服务平台订单号
        /// </summary>
        public string psOrdNum { get; set; }
        /// <summary>
        /// 医院代码
        /// </summary>
        public string branchCode { get; set; }
        /// <summary>
        /// 科室代码
        /// </summary>
        public string deptCode { get; set; }
        /// <summary>
        /// 医生/专科代码
        /// </summary>
        public string doctorCode { get; set; }
        /// <summary>
        /// 时段
        /// </summary>
        public string timeFlag { get; set; }
        /// <summary>
        /// 分时开始时间
        /// </summary>
        public string beginTime { get; set; }
        /// <summary>
        /// 分时结束时间
        /// </summary>
        public string endTime { get; set; }
        /// <summary>
        /// 排班 ID
        /// </summary>
        public string workId { get; set; }
        /// <summary>
        /// 挂号费合计
        /// </summary>
        public string ghhj { get; set; }
        /// <summary>
        /// 挂号费
        /// </summary>
        public string regFee { get; set; }
        /// <summary>
        /// 诊疗费
        /// </summary>
        public string treatFee { get; set; }
        /// <summary>
        /// 挂号类型
        /// </summary>
        public string regType { get; set; }
        /// <summary>
        /// 患者诊疗卡类型
        /// </summary>
        public string patCardType { get; set; }
        /// <summary>
        /// 患者诊疗卡号码
        /// </summary>
        public string patCardNo { get; set; }
        /// <summary>
        /// 预约方式
        /// </summary>
        public string orderMode { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public string orderTime { get; set; }
        /// <summary>
        /// 预约号码
        /// </summary>
        public string orderNo { get; set; }
        /// <summary>
        /// 参保类型
        /// </summary>
        public string SSCblx { get; set; }
        /// <summary>
        /// 社保卡号
        /// </summary>
        public string SSCardNumber { get; set; }
        /// <summary>
        /// 社保电脑号
        /// </summary>
        public string SSComputerNumber { get; set; }
        /// <summary>
        /// 社保加密串
        /// </summary>
        public string SSCodeId { get; set; }
        /// <summary>
        /// 号源类型
        /// </summary>
        public string SShylx { get; set; }
        /// <summary>
        /// 社保卡密码
        /// </summary>
        public string SSPwd { get; set; }
    }
}
