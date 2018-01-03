
namespace GameFrameWork.Resource
{
    /// <summary>
    /// 版本资源列表更新成功事件
    /// </summary>
    public sealed class VersionListUpdateSuccessEventArgs : GameFrameworkEventArgs
    {
        /// <summary>
        /// 初始化版本资源列表更新成功事件的新实例
        /// </summary>
        /// <param name="downloadPath">下载资源后的存放路径</param>
        /// <param name="downloadUri">下载地址</param>
        public VersionListUpdateSuccessEventArgs(string downloadPath, string downloadUri)
        {
            DownloadPath = downloadPath;
            DownloadUri = downloadUri;
        }

        /// <summary>
        /// 获取下载资源后的存放路径
        /// </summary>
        public string DownloadPath
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取下载地址
        /// </summary>
        public string DownloadUri
        {
            get;
            private set;
        }
    }
}
