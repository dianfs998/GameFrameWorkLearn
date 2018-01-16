using System;
using System.Collections.Generic;

namespace GameFrameWork.ObjectPool
{
    internal partial class ObjectPoolManager
    {
        /// <summary>
        /// 对象池
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private sealed class ObjectPool<T> : ObjectPoolBase, IObjectPool<T> where T : ObjectBase
        {
            private readonly LinkedList<Object<T>> m_Objects;
            private readonly bool m_AllowMultiSpawn;
            private float m_AutoReleaseInterval;
            private int m_Capacity;
            private float m_ExpireTime;
            private int m_Priority;
            private float m_AutoReleaseTime;

            /// <summary>
            /// 初始化对象池的新实例
            /// </summary>
            /// <param name="name">对象池名称</param>
            /// <param name="allowMultiSpawn">是否允许对象被多次获取</param>
            /// <param name="capacity">对象池的容量</param>
            /// <param name="expireTime">对象池对象过期秒数</param>
            /// <param name="priority">对象池的优先级</param>
            private ObjectPool(string name, bool allowMultiSpawn, int capacity, float expireTime, int priority)
                : base(name)
            {
                m_Objects = new LinkedList<Object<T>>();
                m_AllowMultiSpawn = allowMultiSpawn;
                m_AutoReleaseInterval = expireTime;
                Capacity = capacity;
                ExpireTime = expireTime;
            }

            /// <summary>
            /// 获取对象池的对象类型
            /// </summary>
            public override Type ObjectType
            {
                get { return typeof(T); }
            }

            /// <summary>
            /// 获取对象池中对象的数量
            /// </summary>
            public override int Count
            {
                get { return m_Objects.Count; }
            }

            /// <summary>
            /// 获取对象池中能被释放的对象数量
            /// </summary>
            public override int CanReleaseCount
            {
                get { return GetCanReleaseObjects().Count; }
            }

            /// <summary>
            /// 获取是否允许对象被多次获取
            /// </summary>
            public override bool AllowMultiSpawn
            {
                get { return m_AllowMultiSpawn; }
            }

            /// <summary>
            /// 获取或设置对象池自动释放可释放对象的间隔秒数
            /// </summary>
            public override float AutoReleaseInterval
            {
                get { return m_AutoReleaseInterval; }
                set { m_AutoReleaseInterval = value; }
            }

            /// <summary>
            /// 获取或设置对象池的容量
            /// </summary>
            public override int Capacity
            {
                get { return m_Capacity; }
                set
                {
                    if(value < 0)
                    {
                        throw new GameFrameworkException("Capacity is invalid");
                    }

                    if(m_Capacity == value)
                    {
                        return;
                    }

                    Log.Debug("Object pool '{0}' capacity changed from '{1}' to '{2}'", Utility.Text.GetFullName<T>(Name), m_Capacity.ToString(), value.ToString());
                    m_Capacity = value;
                    Release();
                }
            }

            /// <summary>
            /// 获取或设置对象池对象过期秒数
            /// </summary>
            public override float ExpireTime
            {
                get { return m_ExpireTime; }
                set
                {
                    if(value < 0f)
                    {
                        throw new GameFrameworkException("ExpireTime is invalid");
                    }

                    if(ExpireTime == value)
                    {
                        return;
                    }

                    Log.Debug("Object pool '{0}' expire time changed from '{1}' to '{2}'", Utility.Text.GetFullName<T>(Name), m_ExpireTime.ToString(), value.ToString());
                    m_ExpireTime = value;
                    Release();
                }
            }

            /// <summary>
            /// 获取或设置对象池的优先级
            /// </summary>
            public override int Priority
            {
                get { return m_Priority; }
                set { m_Priority = value; }
            }

            /// <summary>
            /// 创建对象
            /// </summary>
            /// <param name="obj">对象</param>
            /// <param name="spawned">对象是否被获取</param>
            public void Register(T obj, bool spawned)
            {
                if(obj == null)
                {
                    throw new GameFrameworkException("Object is invalid");
                }

                Log.Debug(spawned ? "Object pool '{0}' create and spawned '{1}'." : "Object pool '{0}' create '{1}'.", Utility.Text.GetFullName<T>(Name), obj.Name);
                m_Objects.AddLast(new Object<T>(obj, spawned));

                Release();
            }

            /// <summary>
            /// 检查对象
            /// </summary>
            /// <returns>要检查的对象是否存在</returns>
            public bool CanSpawn()
            {
                return CanSpawn(string.Empty);
            }

            /// <summary>
            /// 检查对象
            /// </summary>
            /// <param name="name">对象名称</param>
            /// <returns>要检查的对象是否存在</returns>
            public bool CanSpawn(string name)
            {
                foreach(Object<T> obj in m_Objects)
                {
                    if(obj.Name != name)
                    {
                        continue;
                    }

                    if(m_AllowMultiSpawn || !obj.IsInUse)
                    {
                        return true;
                    }
                }

                return false;
            }

            /// <summary>
            /// 获取对象
            /// </summary>
            /// <returns>要获取的对象</returns>
            public T Spawn()
            {
                return Spawn(string.Empty);
            }

            /// <summary>
            /// 获取对象
            /// </summary>
            /// <param name="name">对象名称</param>
            /// <returns>要获取的对象</returns>
            public T Spawn(string name)
            {
                foreach(Object<T> obj in m_Objects)
                {
                    if(obj.Name != name)
                    {
                        continue;
                    }

                    if(m_AllowMultiSpawn || !obj.IsInUse)
                    {
                        Log.Debug("Object pool '{0}' spawn '{1}'.", Utility.Text.GetFullName<T>(Name), obj.Peek().Name);
                        return obj.Spawn();
                    }
                }

                return null;
            }

            /// <summary>
            /// 回收对象
            /// </summary>
            /// <param name="obj">要回收的内部对象</param>
            public void Unspawn(T obj)
            {
                if(obj == null)
                {
                    throw new GameFrameworkException("Object is invalid");
                }

                Unspawn(obj.Target);
            }

            /// <summary>
            /// 回收对象
            /// </summary>
            /// <param name="target">要回收的对象</param>
            public void Unspawn(object target)
            {
                if(target == null)
                {
                    throw new GameFrameworkException("Target is invalid");
                }

                foreach(Object<T> obj in m_Objects)
                {
                    if(obj.Peek().Target == target)
                    {
                        Log.Debug("Object pool '{0}' unspawn '{1}'.", Utility.Text.GetFullName<T>(Name), obj.Peek.Name);
                        obj.Unspawn();
                        Release();
                        return;
                    }
                }

                throw new GameFrameworkException(string.Format("Can not find target in object pool '{0}'", Utility.Text.GetFullName<T>(Name)));
            }

            /// <summary>
            /// 设置对象是否被加锁
            /// </summary>
            /// <param name="obj">要设置被加锁的内部对象</param>
            /// <param name="locked">是否被加锁</param>
            public void SetLocked(T obj, bool locked)
            {
                if(obj == null)
                {
                    throw new GameFrameworkException("Object is invalid");
                }

                SetLocked(obj.Target, locked);
            }

            /// <summary>
            /// 设置对象是否被加锁
            /// </summary>
            /// <param name="target">要设置被加锁的对象</param>
            /// <param name="locked">是否被加锁</param>
            public void SetLocked(object target, bool locked)
            {
                if(target == null)
                {
                    throw new GameFrameworkException("Target is invalid");
                }

                foreach(Object<T> obj in m_Objects)
                {
                    if(obj.Peek().Target == target)
                    {
                        Log.Debug("Object pool '{0}' set locked '{1}' to '{2}'", Utility.Text.GetFullName<T>(Name), obj.Peek().Name, locked.ToString());
                        obj.Locked = locked;
                        return;
                    }
                }

                throw new GameFrameworkException(string.Format("Can not find target in object pool '{0}'", Utility.Text.GetFullName<T>(Name)));
            }

            private LinkedList<T> GetCanReleaseObjects()
            {
                LinkedList<T> canReleaseObjects = new LinkedList<T>();

                foreach(Object<T> obj in m_Objects)
                {
                    if(obj.IsInUse || obj.Locked)
                    {
                        continue;
                    }

                    canReleaseObjects.AddLast(obj.Peek());
                }

                return canReleaseObjects;
            }
        }
    }
}
