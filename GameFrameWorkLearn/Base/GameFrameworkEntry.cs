using System;
using System.Collections.Generic;

namespace GameFrameWork
{
    /// <summary>
    /// 程序框架入口
    /// </summary>
    public static class GameFrameworkEntry
    {
        private const string GameFrameworkVersion = "3.0.9";

        /// <summary>
        /// 获取游戏框架版本号
        /// </summary>
        public static string Version
        {
            get { return GameFrameworkVersion; }
        }

        /// <summary>
        /// 所有游戏框架模块轮询
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位</param>
        public static void Update(float elapseSeconds, float realElapseSeconds)
        {
            //todo
        }

        /// <summary>
        /// 关闭并清理所有游戏框架模块
        /// </summary>
        public static void Shutdown()
        {
            //todo
        }

        /// <summary>
        /// 获取游戏框架模块
        /// </summary>
        /// <typeparam name="T">要获取的游戏框架模块类型</typeparam>
        /// <returns>要获取的游戏框架模块</returns>
        /// <remarks>如果要获取的游戏框架模块不存在，则自动创建该游戏框架模块</remarks>
        public static T GetModule<T>() where T : class
        {
            return null;
            //todo
        }
    }
}
