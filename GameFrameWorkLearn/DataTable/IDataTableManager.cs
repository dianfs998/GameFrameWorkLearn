using System;
using GameFrameWork.Resource;

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
        event EventHandler<LoadDataTableDependencyAssetEventArgs> LoadDataTableDependencyAsset;

        /// <summary>
        /// 加载数据表成功事件
        /// </summary>
        event EventHandler<LoadDataTableSuccessEventArgs> LoadDataTableSuccess;

        /// <summary>
        /// 加载数据表失败事件
        /// </summary>
        event EventHandler<LoadDataTableFailureEventArgs> LoadDataTableFailure;

        /// <summary>
        /// 加载数据表更新事件
        /// </summary>
        event EventHandler<LoadDataTableUpdateEventArgs> LoadDataTableUpdate;

        /// <summary>
        /// 设置资源管理器
        /// </summary>
        /// <param name="resourceManager">资源管理器</param>
        void SetResourceManager(IResourceManager resourceManager);

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="dataTableHelper"></param>
        void SetDataTableHelper(IDataTableHelper dataTableHelper);
    }
}
