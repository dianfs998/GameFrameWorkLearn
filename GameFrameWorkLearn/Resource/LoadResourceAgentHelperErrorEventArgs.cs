

namespace GameFrameWork.Resource
{
    /// <summary>
    /// 加载资源代理辅助器错误事件
    /// </summary>
    public sealed class LoadResourceAgentHelperErrorEventArgs : GameFrameworkEventArgs
    {
        /// <summary>
        /// 初始化加载资源代理辅助器错误事件的新实例
        /// </summary>
        /// <param name="state">加载资源状态</param>
        /// <param name="errorMessage">错误信息</param>
        public LoadResourceAgentHelperErrorEventArgs(LoadResourceStatus state, string errorMessage)
        {
            State = state;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// 获取加载资源状态
        /// </summary>
        public LoadResourceStatus State
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取错误信息
        /// </summary>
        public string ErrorMessage
        {
            get;
            private set;
        }
    }
}
