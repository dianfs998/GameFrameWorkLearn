

namespace GameFrameWork.Resource
{
    /// <summary>
    /// 检查资源完成事件
    /// </summary>
    public sealed class ResourceCheckCompleteEventArgs : GameFrameworkEventArgs
    {
        /// <summary>
        /// 初始化检查资源完成事件的新实例
        /// </summary>
        /// <param name="removedCount"></param>
        /// <param name="updateCount"></param>
        /// <param name="updateTotalLength"></param>
        /// <param name="updateTotalZipLength"></param>
        public ResourceCheckCompleteEventArgs(int removedCount, int updateCount, int updateTotalLength, int updateTotalZipLength)
        {
            RemovedCount = removedCount;
            UpdateCount = updateCount;
            UpdateTotalLength = updateTotalLength;
            UpdateTotalZipLength = updateTotalZipLength;
        }

        /// <summary>
        /// 获取已移除的资源数量
        /// </summary>
        public int RemovedCount
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取要更新的资源数量
        /// </summary>
        public int UpdateCount
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取要更新的资源总大小
        /// </summary>
        public int UpdateTotalLength
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取要更新的资源压缩包总大小
        /// </summary>
        public int UpdateTotalZipLength
        {
            get;
            private set;
        }
    }
}
