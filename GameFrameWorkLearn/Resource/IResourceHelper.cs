

namespace GameFrameWork.Resource
{
    /// <summary>
    /// 资源辅助器接口
    /// </summary>
    public interface IResourceHelper
    {
        /// <summary>
        /// 直接从指定文件路径读取数据流
        /// </summary>
        /// <param name="fileUri">文件路径</param>
        /// <param name="loadBytesCallBack">读取数据流回调函数</param>
        void LoadBytes(string fileUri, LoadBytesCallBack loadBytesCallBack);

        /// <summary>
        /// 卸载场景
        /// </summary>
        /// <param name="sceneAssetName">场景资源名称</param>
        /// <param name="unloadSceneCallBacks">卸载场景回调程序集</param>
        /// <param name="userData">用户自定义数据</param>
        void UnloadScene(string sceneAssetName, UnloadSceneCallBacks unloadSceneCallBacks, object userData);

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="objectToRelease">要释放的资源</param>
        void Release(object objectToRelease);
    }
}
