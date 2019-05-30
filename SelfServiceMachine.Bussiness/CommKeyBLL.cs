using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;

namespace SelfServiceMachine.Bussiness
{
    public class CommKeyBLL
    {
        private ICommKey iCommKey = new CommKeyService();

        /// <summary>
        /// 获取门诊流水号
        /// </summary>
        /// <returns></returns>
        public int GetMZNO()
        {
            return iCommKey.GetMZNO();
        }

        /// <summary>
        /// 费用单据号
        /// </summary>
        /// <returns></returns>
        public int GetYBDJH()
        {
            return iCommKey.GetYBDJH();
        }

        /// <summary>
        /// 费用序列号
        /// </summary>
        /// <returns></returns>
        public int GetYBXLH()
        {
            return iCommKey.GetYBXLH();
        }

        /// <summary>
        /// 医保流水号
        /// </summary>
        /// <returns></returns>
        public int GetYBNO()
        {
            return iCommKey.GetYBNO();
        }
    }
}
