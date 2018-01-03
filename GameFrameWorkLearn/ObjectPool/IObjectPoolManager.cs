using System;

namespace GameFrameWork.ObjectPool
{
    public interface IObjectPoolManager
    {
        /// <summary>
        /// 获取对象池数量
        /// </summary>
        int Count { get; }

        /// <summary>
        /// 检查是否存在对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns>是否存在对象池</returns>
        bool HasObjectPool<T>() where T : ObjectBase;

        /// <summary>
        /// 检查是否存在对象池
        /// </summary>
        /// <param name="objectBase">对象类型</param>
        /// <returns>是否存在对象池</returns>
        bool HasObjectPool(Type objectType);

        /// <summary>
        /// 检查是否存在对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">对象池名称</param>
        /// <returns>是否存在对象池</returns>
        bool HasObjectPool<T>(string name) where T : ObjectBase;

        /// <summary>
        /// 检查是否存在对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="name">对象池名称</param>
        /// <returns>是否存在对象池</returns>
        bool HasObjectPool(Type objectType, string name);

        /// <summary>
        /// 获取对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns>要获取的对象池</returns>
        IObjectPool<T> GetObjectPool<T>() where T : ObjectBase;

        /// <summary>
        /// 获取对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <returns>要获取的对象池</returns>
        ObjectBase GetObjectPool(Type objectType);

        /// <summary>
        /// 获取对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">对象池名称</param>
        /// <returns>要获取的对象池</returns>
        IObjectPool<T> GetObjectPool<T>(string name) where T : ObjectBase;

        /// <summary>
        /// 获取所有对象池
        /// </summary>
        /// <returns>所有对象池</returns>
        ObjectBase[] GetAllObjectPools();

        /// <summary>
        /// 获取所有对象池
        /// </summary>
        /// <param name="sort">是否根据对象池的优先级排序</param>
        /// <returns>所有对象池</returns>
        ObjectBase[] GetAllObjectPools(bool sort);

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns>要创建的允许单次获取的对象池</returns>
        IObjectPool<T> CreateSingleSpawnObjectPool<T>() where T : ObjectBase;

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        ObjectBase CreateSingleSpawnObjectPool(Type objectType);

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">对象池名称</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        IObjectPool<T> CreateSingleSpawnObjectPool<T>(string name) where T : ObjectBase;

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="name">对象池名称</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        ObjectBase CreateSingleSpawnObjectPool(Type objectType, string name);
    }
}
