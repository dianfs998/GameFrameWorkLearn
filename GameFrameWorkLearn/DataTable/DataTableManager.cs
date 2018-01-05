﻿using System;
using System.Collections.Generic;
using GameFrameWork.Resource;

namespace GameFrameWork.DataTable
{
    /// <summary>
    /// 数据表管理器
    /// </summary>
    internal sealed partial class DataTableManager : GameFrameworkModule, IDataTableManager
    {
        private readonly Dictionary<string, DataTableBase> m_DataTables;
        private readonly LoadAssetCallbacks m_LoadAssetCallbacks;
        private IResourceManager m_ResourceManager;
        private IDataTableHelper m_DataTableHelper;
        private EventHandler<LoadDataTableSuccessEventArgs> m_LoadDataTableSuccessEventHandler;
        private EventHandler<LoadDataTableFailureEventArgs> m_LoadDataTableFailureEventHandler;
        private EventHandler<LoadDataTableUpdateEventArgs> m_LoadDataTableUpdateEventHandler;
        private EventHandler<LoadDataTableDependencyAssetEventArgs> m_LoadDataTableDependencyAssetEventHandler;

        /// <summary>
        /// 初始化数据表管理器的新实例
        /// </summary>
        public DataTableManager()
        {
            m_DataTables = new Dictionary<string, DataTableBase>();
            m_LoadAssetCallbacks = new LoadAssetCallbacks(LoadDataTableSuccessCallback, LoadDataTableFailureCallback, LoadDataTableUpdateCallback, LoadDataTableDependencyAssetCallback);
            m_ResourceManager = null;
            m_DataTableHelper = null;
            m_LoadDataTableSuccessEventHandler = null;
            m_LoadDataTableFailureEventHandler = null;
            m_LoadDataTableUpdateEventHandler = null;
            m_LoadDataTableDependencyAssetEventHandler = null;
        }

        /// <summary>
        /// 获取数据表数量
        /// </summary>
        public int Count
        {
            get { return m_DataTables.Count; }
        }

        /// <summary>
        /// 加载数据表成功事件
        /// </summary>
        public event EventHandler<LoadDataTableSuccessEventArgs> LoadDataTableSuccess
        {
            add
            {
                m_LoadDataTableSuccessEventHandler += value;
            }
            remove
            {
                m_LoadDataTableSuccessEventHandler -= value;
            }
        }

        /// <summary>
        /// 加载数据表失败事件
        /// </summary>
        public event EventHandler<LoadDataTableFailureEventArgs> LoadDataTableFailure
        {
            add
            {
                m_LoadDataTableFailureEventHandler += value;
            }
            remove
            {
                m_LoadDataTableFailureEventHandler -= value;
            }
        }

        /// <summary>
        /// 加载数据表更新事件
        /// </summary>
        public event EventHandler<LoadDataTableUpdateEventArgs> LoadDataTableUpdate
        {
            add
            {
                m_LoadDataTableUpdateEventHandler += value;
            }
            remove
            {
                m_LoadDataTableUpdateEventHandler -= value;
            }
        }

        /// <summary>
        /// 加载数据表时加载依赖资源事件
        /// </summary>
        public event EventHandler<LoadDataTableDependencyAssetEventArgs> LoadDataTableDependencyAsset
        {
            add
            {
                m_LoadDataTableDependencyAssetEventHandler += value;
            }
            remove
            {
                m_LoadDataTableDependencyAssetEventHandler -= value;
            }
        }

        /// <summary>
        /// 数据表管理器轮询
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位</param>
        internal override void Update(float elapseSeconds, float realElapseSeconds)
        {

        }

        /// <summary>
        /// 关闭并清理数据表管理器
        /// </summary>
        internal override void Shutdown()
        {
            foreach(KeyValuePair<string, DataTableBase> dataTable in m_DataTables)
            {
                dataTable.Value.Shutdown();
            }

            m_DataTables.Clear();
        }

        /// <summary>
        /// 设置资源管理器
        /// </summary>
        /// <param name="resourceManager">资源管理器</param>
        public void SetResourceManager(IResourceManager resourceManager)
        {
            if(resourceManager == null)
            {
                throw new GameFrameworkException("Resource manager is invalid");
            }

            m_ResourceManager = resourceManager;
        }

        /// <summary>
        /// 设置数据表辅助器
        /// </summary>
        /// <param name="dataTableHelper">数据表辅助器</param>
        public void SetDataTableHelper(IDataTableHelper dataTableHelper)
        {
            if(dataTableHelper == null)
            {
                throw new GameFrameworkException("Data table helper is invalid");
            }

            m_DataTableHelper = dataTableHelper;
        }

        /// <summary>
        /// 加载数据表
        /// </summary>
        /// <param name="dataTableAssetName">数据表资源名称</param>
        public void LoadDataTable(string dataTableAssetName)
        {
            LoadDataTable(dataTableAssetName, null);
        }

        /// <summary>
        /// 加载数据表
        /// </summary>
        /// <param name="dataTableAssetName">数据表资源名称</param>
        /// <param name="userData">用户自定义数据</param>
        public void LoadDataTable(string dataTableAssetName, object userData)
        {
            if(m_ResourceManager == null)
            {
                throw new GameFrameworkException("You must set resource manager firest");
            }

            if(m_DataTableHelper == null)
            {
                throw new GameFrameworkException("You must set data table helper first");
            }

            m_ResourceManager.LoadAsset(dataTableAssetName, m_LoadAssetCallbacks, userData);
        }

        public bool HasDataTable<T>() where T : IDataRow
        {

        }

        private void LoadDataTableSuccessCallback(string dataTableAssetName, object dataTableAsset, float duration, object userData)
        {
            try
            {
                if (!m_DataTableHelper.LoadDataTable(dataTableAsset, userData))
                {
                    throw new GameFrameworkException(string.Format("Load data table failure in helper, asset name '{0}'", dataTableAssetName));
                }
            }
            catch(Exception e)
            {
                if(m_LoadDataTableFailureEventHandler != null)
                {
                    m_LoadDataTableFailureEventHandler(this, new LoadDataTableFailureEventArgs(dataTableAssetName, e.ToString(), userData));
                    return;
                }

                throw;
            }
            finally
            {
                m_DataTableHelper.ReleaseDataTableAsset(dataTableAsset);
            }

            if(m_LoadDataTableSuccessEventHandler != null)
            {
                m_LoadDataTableSuccessEventHandler(this, new LoadDataTableSuccessEventArgs(dataTableAssetName, duration, userData));
            }
        }

        private void LoadDataTableFailureCallback(string dataTableAssetName, LoadResourceStatus status, string errorMessage, object userData)
        {
            string appendErrorMessage = string.Format("Load data table failure, asset name '{0}', status '{1}', error message '{2}'", dataTableAssetName, status.ToString(), errorMessage);
            if(m_LoadDataTableFailureEventHandler != null)
            {
                m_LoadDataTableFailureEventHandler(this, new LoadDataTableFailureEventArgs(dataTableAssetName, appendErrorMessage, userData));
                return;
            }

            throw new GameFrameworkException(appendErrorMessage);
        }

        private void LoadDataTableUpdateCallback(string dataTableAssetName, float progress, object userData)
        {
            if(m_LoadDataTableUpdateEventHandler != null)
            {
                m_LoadDataTableUpdateEventHandler(this, new LoadDataTableUpdateEventArgs(dataTableAssetName, progress, userData));
            }
        }

        private void LoadDataTableDependencyAssetCallback(string dataTableAssetName, string dependencyAssetName, int loadedCount, int totalCount, object userData)
        {
            if(m_LoadDataTableDependencyAssetEventHandler != null)
            {
                m_LoadDataTableDependencyAssetEventHandler(this, new LoadDataTableDependencyAssetEventArgs(dataTableAssetName, dependencyAssetName, loadedCount, totalCount, userData));
            }
        }
    }
}
