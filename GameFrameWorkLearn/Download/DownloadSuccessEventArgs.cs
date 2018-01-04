

namespace GameFrameWork.Download
{
    /// <summary>
    /// 下载成功事件
    /// </summary>
    public sealed class DownloadSuccessEventArgs : GameFrameworkEventArgs
    {
        /// <summary>
        /// 初始化下载成功事件的新实例
        /// </summary>
        /// <param name="serialID">下载任务的序列编号</param>
        /// <param name="downloadPath">下载后的存放路径</param>
        /// <param name="downloadUri">下载地址</param>
        /// <param name="currentLength"></param>
        /// <param name="userData"></param>
        public DownloadSuccessEventArgs(int serialID, string downloadPath, string downloadUri, int currentLength, object userData)
        {
            SerialID = serialID;
            DownloadPath = downloadPath;
            DownloadUri = downloadUri;
            CurrentLength = currentLength;
            UserData = userData;
        }

        /// <summary>
        /// 获取下载任务的序列编号
        /// </summary>
        public int SerialID { get; private set; }

        /// <summary>
        /// 获取下载后存放路径
        /// </summary>
        public string DownloadPath { get; private set; }

        /// <summary>
        /// 获取下载地址
        /// </summary>
        public string DownloadUri { get; private set; }

        /// <summary>
        /// 获取当前大小
        /// </summary>
        public int CurrentLength { get; private set; }

        /// <summary>
        /// 获取用户自定义的数据
        /// </summary>
        public object UserData { get; private set; }
    }
}
