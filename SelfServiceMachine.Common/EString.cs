using System;

namespace SelfServiceMachine.Common
{
    public class EString
    {
        public static int GetAge(string m_Str)
        {
            int m_Y1 = DateTime.Parse(m_Str).Year;
            int m_Y2 = DateTime.Now.Year;
            int m_Age = m_Y2 - m_Y1;
            return m_Age;
        }

        public static string ZeroFill(int number)
        {
            if (number > 10000000)
            {
                return number.ToString();
            }
            else
            {
                return number.ToString().PadLeft(8, '0'); //一共8位,位数不够时从左边开始用0补
            }
        }

        public static string ZeroFill(string number)
        {
            if (number.Length > 8)
            {
                return number;
            }
            else
            {
                return number.ToString().PadLeft(8, '0'); //一共8位,位数不够时从左边开始用0补
            }
        }
    }
}
