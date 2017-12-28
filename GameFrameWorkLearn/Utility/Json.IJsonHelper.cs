using System;

namespace GameFrameWork
{
    public static partial class Utility
    {
        public static partial class Json
        {
            /// <summary>
            /// Json辅助器接口
            /// </summary>
            public interface IJsonHelper
            {
                /// <summary>
                /// 将对象序列化为Json字符串
                /// </summary>
                /// <param name="obj">要序列化的对象</param>
                /// <returns>序列化后的Json字符串</returns>
                string ToJson(object obj);

                /// <summary>
                /// 将Json字符串反序列化为对象
                /// </summary>
                /// <typeparam name="T">对象类型</typeparam>
                /// <param name="json">要反序列化的Json字符串</param>
                /// <returns>反序列化后的对象</returns>
                T ToObject<T>(string json);

                /// <summary>
                /// 将Json字符串反序列化为对象
                /// </summary>
                /// <param name="objectType">对象类型</param>
                /// <param name="json">要反序列化的Json字符串</param>
                /// <returns>反序列化后的对象</returns>
                object ToObject(Type objectType, string json);
            }
        }
    }
}
