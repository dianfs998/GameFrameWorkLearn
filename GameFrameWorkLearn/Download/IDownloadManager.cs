using System;

namespace GameFrameWork.Download
{
    /// <summary>
    /// 下载管理器接口
    /// </summary>
    public interface IDownloadManager
    {
        /// <summary>
        /// 获取下载总代理数量
        /// </summary>
        int TotalAgentCount { get; }

        /// <summary>
        /// 获取可用下载代理数量
        /// </summary>
        int FreeAgentCount { get; }

        /// <summary>
        /// 获取工作中下载代理数量
        /// </summary>
        int WorkingAgentCount { get; }

        /// <summary>
        /// 获取等待下载任务数量
        /// </summary>
        int WaitingTaskCount { get; }

        /// <summary>
        /// 获取或设置将缓冲区写入磁盘的临界大小
        /// </summary>
        int FlushSize { get; set; }

        /// <summary>
        /// 获取或设置下载超时时长，以秒为单位
        /// </summary>
        float Timeout { get; set; }

        /// <summary>
        /// 获取当前下载速度
        /// </summary>
        float CurrentSpeed { get; }

        event EventHandler<DownloadStartEventArgs> DownloadStart;
    }
}
