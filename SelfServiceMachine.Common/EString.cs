using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
