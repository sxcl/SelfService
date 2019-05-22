namespace SelfServiceMachine.Common
{
    public class CodeConvertUtils
    {
        /// <summary>
        /// 根据idType获取int值
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int GetIdNoType(string type)
        {
            switch (type)
            {
                case "港澳通行证或护照":
                    return 2;
                case "其他有效身份证件":
                    return 4;
                case "居民身份证":
                    return 1;
                default:
                    return 1;
            }
        }


        /// <summary>
        /// 根据idType获取string值
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetIdNoType(int type)
        {
            switch (type)
            {
                case 1:
                    return "居民身份证";
                case 2:
                case 4:
                    return "港澳通行证或护照";
                default:
                    return "居民身份证";
            }
        }

        /// <summary>
        /// 根据字段名获取cardType
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int GetCardTypeByType(string type)
        {
            switch (type)
            {
                case "yno":
                    return 2;
                case "ybidentity":
                    return 3;
                case "cno":
                    return 1;
                case "idno":
                    return 5;
                case "tel":
                    return 10;
                default:
                    return -1;
            }
        }

        /// <summary>
        /// 根据id获取cardType
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetCardTypeByType(int cardType)
        {
            var para = "";
            switch (cardType)
            {
                case 1:
                    para = "cno";
                    break;
                case 2:
                    para = "yno";
                    break;
                case 3:
                    para = "ybidentity";
                    break;
                case 5:
                    para = "idno";
                    break;
                case 7:
                    para = "mzno";
                    break;
                case 10:
                    para = "tel";
                    break;
                default:
                    para = "cno";
                    break;
            }
            return para;
        }
    }
}
