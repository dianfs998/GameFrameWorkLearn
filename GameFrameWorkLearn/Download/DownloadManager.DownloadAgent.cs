using System;
using System.IO;

namespace GameFrameWork.Download
{

    internal partial class DownloadManager
    {
        /// <summary>
        /// 下载代理
        /// </summary>
        private sealed class DownloadAgent : ITaskAgent<DownloadTask>, IDisposable
        {
            private readonly IDownloadAgentHelper m_Helper;
            private DownloadTask m_Task;
            private FileStream m_FileStream;
            private int m_WaitingFlushSize;
            private float m_WaitTime;
            private int m_StartLength;
            private int m_DownloadedLength;
            private int m_SavedLength;
            private bool m_Disposed;

            public 
        }
    }
}
