using System;

namespace GameFrameWork
{
    public static partial class Utility
    {
        /// <summary>
        /// Json相关的实用函数
        /// </summary>
        public static partial class Json
        {
            private static IJsonHelper s_JsonHelper = null;

            /// <summary>
            /// 设置Json辅助器
            /// </summary>
            /// <param name="jsonHelper"></param>
            public static void SetJsonHelper(IJsonHelper jsonHelper)
            {
                s_JsonHelper = jsonHelper;
            }

            /// <summary>
            /// 将对象序列化为Json字符串
            /// </summary>
            /// <param name="obj">要序列化的对象</param>
            /// <returns>序列化后的Json字符串</returns>
            public static string ToJson(object obj)
            {
                if(s_JsonHelper == null)
                {
                    throw new GameFrameworkException("JsonHelper is invalid");
                }

                return s_JsonHelper.ToJson(obj);
            }

            /// <summary>
            /// 将对象序列化为Json流
            /// </summary>
            /// <param name="obj">要序列化的对象</param>
            /// <returns>序列化后的Json流</returns>
            public static byte[] ToJsonData(object obj)
            {
                return Converter.GetBytes(ToJson(obj));
            }

            /// <summary>
            /// 将Json字符串反序列化为对象
            /// </summary>
            /// <typeparam name="T">对象类型</typeparam>
            /// <param name="json">要反序列化的Json字符串</param>
            /// <returns>反序列化后的对象</returns>
            public static T ToObject<T>(string json)
            {
                if(s_JsonHelper == null)
                {
                    throw new GameFrameworkException("JsonHelper is invalid");
                }

                return s_JsonHelper.ToObject<T>(json);
            }

            /// <summary>
            /// 将Json字符串反序列化为对象
            /// </summary>
            /// <param name="objectType">对象类型</param>
            /// <param name="json">要反序列化的Json字符串</param>
            /// <returns>反序列化后的对象</returns>
            public static object ToObject(Type objectType, string json)
            {
                if(s_JsonHelper == null)
                {
                    throw new GameFrameworkException("JsonHelper is invalid");
                }

                if(objectType == null)
                {
                    throw new GameFrameworkException("Type is invalid");
                }

                return s_JsonHelper.ToObject(objectType, json);
            }

            /// <summary>
            /// 将Json流反序列化为对象
            /// </summary>
            /// <typeparam name="T">对象类型</typeparam>
            /// <param name="jsonData">要反序列化的Json流</param>
            /// <returns>反序列化后的对象</returns>
            public static T ToObject<T>(byte[] jsonData)
            {
                return ToObject<T>(Converter.GetString(jsonData));
            }

            /// <summary>
            /// 将Json流反序列化为对象
            /// </summary>
            /// <param name="objectType">对象类型</param>
            /// <param name="jsonData">要反序列化的Json流</param>
            /// <returns>反序列化后的对象</returns>
            public static object ToObject(Type objectType, byte[] jsonData)
            {
                return ToObject(objectType, Converter.GetString(jsonData));
            }
        }
    }
}
