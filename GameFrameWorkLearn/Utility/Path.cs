using System;
using System.Collections.Generic;

namespace GameFrameWork
{
    public static partial class Utility
    {
        /// <summary>
        /// 路径相关的实用函数
        /// </summary>
        public static class Path
        {
            /// <summary>
            /// 获取规范的路径
            /// </summary>
            /// <param name="path">需要规范的路径</param>
            /// <returns>规范后的路径</returns>
            public static string GetRegularPath(string path)
            {
                if(path == null)
                {
                    return null;
                }

                return path.Replace('\\', '/');
            }

            /// <summary>
            /// 获取连接后的路径
            /// </summary>
            /// <param name="path">路径片段</param>
            /// <returns>连接后的路径</returns>
            public static string GetCombinePath(params string[] path)
            {
                if(path == null || path.Length < 1)
                {
                    return null;
                }

                string combinePath = path[0];
                for(int i = 1; i<path.Length; i++)
                {
                    combinePath = System.IO.Path.Combine(combinePath, path[i]);
                }

                return GetRegularPath(combinePath);
            }

            /// <summary>
            /// 获取远程格式的路径（带有file://或http://前缀）
            /// </summary>
            /// <param name="path">原始路径</param>
            /// <returns>远程格式路径</returns>
            public static string GetRemotePath(params string[] path)
            {
                string combinePath = GetCombinePath(path);
                if(combinePath == null)
                {
                    return null;
                }

                return combinePath.Contains("://") ? combinePath : ("file:///" + combinePath).Replace("file:////", "file:///");
            }

            /// <summary>
            /// 获取带有后缀的资源名
            /// </summary>
            /// <param name="resourceName">原始资源名</param>
            /// <returns>带有后缀的资源名</returns>
            public static string GetResourceNameWithSuffix(string resourceName)
            {
                if(string.IsNullOrEmpty(resourceName))
                {
                    throw new GameFrameworkException("Resource name is invalid");
                }

                return string.Format("{0}.dat", resourceName);
            }

            public static string GetResourceNameWithCrc32AndSuffix(string resourceName, int hashCode)
            {
                if (string.IsNullOrEmpty(resourceName))
                {
                    throw new GameFrameworkException("Resource name is invalid");
                }

                return string.Format("{0}.{1:x8}.data", resourceName, hashCode);
            }
        }
    }
}
