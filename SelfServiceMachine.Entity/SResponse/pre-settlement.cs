using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Entity.SResponse
{
    public class pre_settlement
    {
        /// <summary>
        /// 
        /// </summary>
        public string transTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string transType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string transReturnCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string transReturnMessage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string transVersion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string serialNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cardArea { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hospitalCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string operatorCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string operatorName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string operatorPass { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TransBody transBody { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string verifyCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string extendDeviceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string transChannel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string extendUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string extendSerialNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string caz055 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string aae501 { get; set; }
    }

    public class TransBody
    {
        public decimal akc264 { get; set; }
        public decimal akb068 { get; set; }
        public decimal akb066 { get; set; }
        public decimal akb067 { get; set; }
        public decimal aae240 { get; set; }
        public List<outputlist> outputlist { get; set; }
        public List<outputlist2> outputlist2 { get; set; }
    }

    public class outputlist
    {
        public string aaa036 { get; set; }
        public decimal aae019 { get; set; }
    }

    public class outputlist2
    {
        public string aka037 { get; set; }
        public decimal bke264 { get; set; }
    }
}
