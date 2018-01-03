

namespace GameFrameWork.Resource
{
    /// <summary>
    /// 卸载场景回调函数集
    /// </summary>
    public sealed class UnloadSceneCallBacks
    {
        private readonly UnloadSceneFailureCallBack m_UnloadSceneFailureCallBack;
        private readonly UnloadSceneSuccessCallBack m_UnloadSceneSuccessCallBack;

        /// <summary>
        /// 初始化卸载场景回调函数集的新实例
        /// </summary>
        /// <param name="unloadSceneSuccessCallBack">卸载场景成功回调函数</param>
        public UnloadSceneCallBacks(UnloadSceneSuccessCallBack unloadSceneSuccessCallBack)
                : this(unloadSceneSuccessCallBack, null)
        {

        }

        /// <summary>
        /// 初始化卸载场景回调函数集的新实例
        /// </summary>
        /// <param name="unloadSceneSuccessCallBack">卸载场景成功回调函数</param>
        /// <param name="unloadSceneFailureCallBack">卸载场景失败回调函数</param>
        public UnloadSceneCallBacks(UnloadSceneSuccessCallBack unloadSceneSuccessCallBack, UnloadSceneFailureCallBack unloadSceneFailureCallBack)
        {
            if(unloadSceneSuccessCallBack == null)
            {
                throw new GameFrameworkException("Unload scene success callback is invalid");
            }

            m_UnloadSceneSuccessCallBack = unloadSceneSuccessCallBack;
            m_UnloadSceneFailureCallBack = unloadSceneFailureCallBack;
        }

        /// <summary>
        /// 获取卸载场景失败回调函数
        /// </summary>
        public UnloadSceneFailureCallBack UnloadSceneFailureCallBack
        {
            get { return m_UnloadSceneFailureCallBack; }
        }

        /// <summary>
        /// 获取卸载场景成功回调函数
        /// </summary>
        public UnloadSceneSuccessCallBack UnloadSceneSuccessCallBack
        {
            get { return m_UnloadSceneSuccessCallBack; }
        }
    }
}
