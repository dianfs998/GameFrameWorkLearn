﻿using System;

namespace GameFrameWork.Resource
{
    /// <summary>
    /// 加载资源代理辅助器接口
    /// </summary>
    public interface ILoadResourceAgentHelper
    {
        /// <summary>
        /// 加载资源代理辅助器异步加载资源更新事件
        /// </summary>
        event EventHandler<LoadResourceAgentHelperUpdateEventArgs> LoadResourceAgentHelperUpdate;

        /// <summary>
        /// 加载资源代理辅助器异步读取资源文件完成事件
        /// </summary>
        event EventHandler<LoadResourceAgentHelperReadFileCompleteEventArgs> LoadResourceAgentHelperReadFileComplete;

        /// <summary>
        /// 加载资源代理辅助器异步读取资源二进制流完成事件
        /// </summary>
        event EventHandler<LoadResourceAgentHelperReadByteCompleteEventArgs> LoadResourceAgentHelperReadByteComplete;

        /// <summary>
        /// 加载资源代理辅助器异步将资源二进制流转换为加载对象完成事件
        /// </summary>
        event EventHandler<LoadResourceAgentHelperParseByteCompleteEventArgs> LoadResourceAgentHelperParseByteComplete;

        /// <summary>
        /// 加载资源代理辅助器异步加载资源完成事件
        /// </summary>
        event EventHandler<LoadResourceAgentHelperLoadCompleteEventArgs> LoadResourceAgentHelperLoadComplete;

        /// <summary>
        /// 加载资源代理辅助器错误事件
        /// </summary>
        event EventHandler<LoadResourceAgentHelperErrorEventArgs> LoadResourceAgentHelperError;

        /// <summary>
        /// 通过加载资源代理辅助器开始异步读取资源文件
        /// </summary>
        /// <param name="fullpath">要加载的资源完整路径名</param>
        void ReadFile(string fullpath);

        /// <summary>
        /// 通过加载资源代理辅助器开始异步读取资源二进制流
        /// </summary>
        /// <param name="fullpath">要加载的资源完整路径名</param>
        /// <param name="loadType">资源加载方式</param>
        void ReadBytes(string fullpath, int loadType);

        /// <summary>
        /// 通过加载资源代理辅助器开始将资源二进制流转换为加载对象
        /// </summary>
        /// <param name="bytes"></param>
        void ParseBytes(byte[] bytes);

        /// <summary>
        /// 通过加载资源代理辅助器开始异步加载资源
        /// </summary>
        /// <param name="resource">资源</param>
        /// <param name="resourceChildName">要加载的子文件名</param>
        /// <param name="isScene">要加载的资源是否是场景</param>
        void LoadAsset(object resource, string resourceChildName, bool isScene);

        /// <summary>
        /// 重置加载资源代理辅助器
        /// </summary>
        void Reset();
    }
}
