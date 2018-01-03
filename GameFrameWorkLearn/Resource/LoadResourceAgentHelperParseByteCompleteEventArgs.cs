

namespace GameFrameWork.Resource
{
    /// <summary>
    /// 加载资源代理辅助器异步将资源二进制流转换为加载对象完成事件
    /// </summary>
    public sealed class LoadResourceAgentHelperParseByteCompleteEventArgs : GameFrameworkEventArgs
    {
        /// <summary>
        /// 初始化加载资源代理辅助器异步将资源二进制流转换为加载对象完成事件的新实例
        /// </summary>
        /// <param name="resource"></param>
        public LoadResourceAgentHelperParseByteCompleteEventArgs(object resource)
        {
            Resource = resource;
        }

        /// <summary>
        /// 获取加载对象
        /// </summary>
        public object Resource
        {
            get;
            private set;
        }
    }
}
