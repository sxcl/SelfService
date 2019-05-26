using System;

namespace SelfServiceMachine.Entity
{
    //reg_trial
    public class reg_trial
    {

        /// <summary>
		/// id
        /// </summary>
        public int id
        {
            get;
            set;
        }
        /// <summary>
        /// 费用单据号
        /// </summary>
        public string aae072
        {
            get;
            set;
        }
        /// <summary>
        /// 费用序列号
        /// </summary>
        public string bkf500
        {
            get;
            set;
        }
        /// <summary>
        /// 社保目录编码
        /// </summary>
        public string ake001
        {
            get;
            set;
        }
        /// <summary>
        /// 协议机构内部诊疗目录编码
        /// </summary>
        public string ake005
        {
            get;
            set;
        }
        /// <summary>
        /// 协议机构内部诊疗目录名称
        /// </summary>
        public string ake006
        {
            get;
            set;
        }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal aae019
        {
            get;
            set;
        }
        /// <summary>
        /// 挂号主键
        /// </summary>
        public int regid
        {
            get;
            set;
        }
        /// <summary>
        /// addtime
        /// </summary>
        public DateTime addtime
        {
            get;
            set;
        }
    }
}
