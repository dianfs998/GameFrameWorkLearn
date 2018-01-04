﻿

namespace GameFrameWork.Download
{
    /// <summary>
    /// 下载代理辅助器错误事件
    /// </summary>
    public sealed class DownloadAgentHelperErrorEventArgs : GameFrameworkEventArgs
    {
        /// <summary>
        /// 初始化下载代理辅助器错误事件的新实例
        /// </summary>
        /// <param name="errorMessage">错误信息</param>
        public DownloadAgentHelperErrorEventArgs(string errorMessage)
        {
            ErrorMessage = errorMessage;
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
