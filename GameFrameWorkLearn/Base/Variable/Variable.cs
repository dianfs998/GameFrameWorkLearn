using System;

namespace GameFrameWork
{
    /// <summary>
    /// 变量
    /// </summary>
    public abstract class Variable
    {
        /// <summary>
        /// 初始化变量的新实例
        /// </summary>
        protected Variable() { }

        /// <summary>
        /// 获取变量类型
        /// </summary>
        public abstract Type Type
        {
            get;
        }

        /// <summary>
        /// 获取变量值
        /// </summary>
        /// <returns></returns>
        public abstract object GetValue();

        /// <summary>
        /// 设置变量值
        /// </summary>
        /// <param name="value"></param>
        public abstract void SetValue(object value);

        /// <summary>
        /// 重置变量值
        /// </summary>
        public abstract void Reset();
    }
}
