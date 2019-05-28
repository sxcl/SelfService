using System;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SelfServiceMachine.Common
{
    public class XMLHelper
    {
        /// <summary>
        /// XML To Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strXML"></param>
        /// <returns></returns>
        public static T DESerializer<T>(string strXML) where T : class
        {
            strXML = strXML.Replace("<![CDATA[", "").Replace("]]>", "");
            using (StringReader sr = new StringReader(strXML))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return serializer.Deserialize(sr) as T;
            }
        }

        /// <summary>
        /// XML To Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strXML"></param>
        /// <returns></returns>
        public static T DESerializerNoCData<T>(string strXML) where T : class
        {
            using (StringReader sr = new StringReader(strXML))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return serializer.Deserialize(sr) as T;
            }
        }

        /// <summary>
        /// Entity To XML
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string XmlSerialize<T>(T obj)
        {
            using (StringWriter sw = new StringWriter())
            {
                Type t = obj.GetType();

                XmlSerializerNamespaces _namespaces = new XmlSerializerNamespaces(new XmlQualifiedName[] {
                    new XmlQualifiedName(string.Empty,"")
                });
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(sw, obj, _namespaces);
                sw.Close();
                return sw.ToString().Replace("<noface>", "").Replace("</noface>", "").Replace("<noface />", "").Replace("<noface/>", "");
            }
        }

        public static string CDataToXml(DataTable dt)
        {
            if (dt != null)
            {
                MemoryStream ms = null;
                XmlTextWriter XmlWt = null;
                try
                {
                    ms = new MemoryStream();
                    XmlWt = new XmlTextWriter(ms, Encoding.Unicode);
                    dt.WriteXml(XmlWt);
                    int count = (int)ms.Length;
                    byte[] temp = new byte[count];
                    ms.Seek(0, SeekOrigin.Begin);
                    ms.Read(temp, 0, count);
                    UnicodeEncoding ucode = new UnicodeEncoding();
                    string returnValue = ucode.GetString(temp).Trim();
                    // return returnValue; //带有命名空间 
                    //去掉命名空间
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(returnValue);
                    return doc.DocumentElement.InnerXml;
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    //释放资源  
                    if (XmlWt != null)
                    {
                        XmlWt.Close();
                        ms.Close();
                        ms.Dispose();
                    }
                }
            }
            else
            {
                return "";
            }
        }
    }
}
