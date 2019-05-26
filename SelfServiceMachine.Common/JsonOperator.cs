using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Data;

namespace SelfServiceMachine.Common
{
    public static class JsonOperator
    {
        /// <summary>
        /// Json 序列化
        /// </summary>
        /// <param name="value"></param>
        /// <param name="converters"></param>
        /// <returns></returns>
        public static string JsonSerialize(object value, params JsonConverter[] converters)
        {
            if (value != null)
            {
                if (converters != null && converters.Length > 0)
                {
                    return JsonConvert.SerializeObject(value, converters);
                }
                else
                {
                    if (value is DataSet)
                        return JsonConvert.SerializeObject(value, new DataSetConverter());
                    else if (value is DataTable)
                        return JsonConvert.SerializeObject(value, new DataTableConverter());
                    else
                        return JsonConvert.SerializeObject(value);
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Json反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="converters"></param>
        /// <returns></returns>
        public static T JsonDeserialize<T>(string value, params JsonConverter[] converters)
        {
            if (string.IsNullOrEmpty(value))
                return default(T);

            if (converters != null && converters.Length > 0)
            {
                return JsonConvert.DeserializeObject<T>(value, converters);
            }
            else
            {
                Type type = typeof(T);

                if (type == typeof(DataSet))
                {
                    return JsonConvert.DeserializeObject<T>(value, new DataSetConverter());
                }
                else if (type == typeof(DataTable))
                {
                    return JsonConvert.DeserializeObject<T>(value, new DataTableConverter());
                }
                return JsonConvert.DeserializeObject<T>(value);
            }
        }
    }
}
