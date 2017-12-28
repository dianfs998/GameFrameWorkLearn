

namespace GameFrameWork
{
    public static partial class Utility
    {
        /// <summary>
        /// 随机相关的实用函数
        /// </summary>
        public static class Random
        {
            private static readonly System.Random s_Random = new System.Random();

            /// <summary>
            /// 返回非负随机数
            /// </summary>
            /// <returns>大于等于零且小于System.Int32.MaxValue的32位带符号整数</returns>
            public static int GetRandom()
            {
                return s_Random.Next();
            }

            /// <summary>
            /// 返回一个小于所指定最大值的非负随机数
            /// </summary>
            /// <param name="maxValue">要生成的随机数的上界（随机数不能取该上界值），maxValue必须大于等于零</param>
            /// <returns>大于等于零且小于maxValue的32位带符号整数,返回值的范围通常包括0但不包括maxValue，不过如果maxValue等于零，则返回maxValue</returns>
            public static int GetRandom(int maxValue)
            {
                return s_Random.Next(maxValue);
            }

            /// <summary>
            /// 返回一个指定范围内的随机数
            /// </summary>
            /// <param name="minValue">要生成的随机数的下界（随机数可能取该下界值）</param>
            /// <param name="maxValue">要生成的随机数的上界（随机数不能取该上界值），maxValue必须大于等于minValue</param>
            /// <returns>大于等于minValue且小于maxValue的32位带符号整数,返回值的范围通常包括minValue但不包括maxValue，不过如果maxValue等于minValue，则返回minValue</returns>
            public static int GetRandom(int minValue, int maxValue)
            {
                return s_Random.Next(minValue, maxValue);
            }

            /// <summary>
            /// 返回一个介于0.0和1.0之间的随机数
            /// </summary>
            /// <returns>大于等于0.0并且小于1.0的双精度浮点数</returns>
            public static double GetRandomDouble()
            {
                return s_Random.NextDouble();
            }

            /// <summary>
            /// 用随机数填充指定字节数组的元素
            /// </summary>
            /// <param name="buffer">包含随机数的字节数组</param>
            public static void GetRandomBytes(byte[] buffer)
            {
                s_Random.NextBytes(buffer);
            }
        }
    }
}
