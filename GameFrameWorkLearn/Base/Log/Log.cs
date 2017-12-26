using System.Diagnostics;

namespace GameFrameWork
{
    /// <summary>
    /// 日志类
    /// </summary>
    public static class Log
    {
        private static ILogHelper s_LogHelper = null;

        /// <summary>
        /// 设置日志辅助器
        /// </summary>
        /// <param name="logHelper">要设置的日志辅助器</param>
        public static void SetLogHelper(ILogHelper logHelper)
        {
            s_LogHelper = logHelper;
        }

        /// <summary>
        /// 记录调试级别日志，进在带有DEBUG预编译选项时产生
        /// </summary>
        /// <param name="message">日志内容</param>
        [Conditional("DEBUG")]
        public static void Debug(object message)
        {
            if(s_LogHelper == null)
            {
                return;
            }
            s_LogHelper.Log(LogLevel.Debug, message);
        }
    }
}
