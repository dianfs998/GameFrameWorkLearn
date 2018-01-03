using System;

namespace GameFrameWork.DataTable
{
    public interface IDataTableManager
    {
        /// <summary>
        /// 获取数据表数量
        /// </summary>
        int Count { get; }

        /// <summary>
        /// 加载数据表时加载依赖资源事件
        /// </summary>
        event EventHandler<LoadDataTableDependencyAssetEventArgs> loadDataTableDependencyAsset;

        /// <summary>
        /// 加载数据表成功事件
        /// </summary>
        event EventHandler<LoadDataTableSuccessEventArgs> loadDataTableSuccess;

        /// <summary>
        /// 加载数据表失败事件
        /// </summary>
        event EventHandler<LoadDataTableFailureEventArgs> loadDataTableFailure;

        /// <summary>
        /// 加载数据表更新事件
        /// </summary>
        event EventHandler<LoadDataTableUpdateEventArgs> loadDataTableUpdate;

        //todo
    }
}
