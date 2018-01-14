using System.Collections.Generic;

namespace GameFrameWork.Entity
{
    internal partial class EntityManager
    {
        /// <summary>
        /// 实体信息
        /// </summary>
        private sealed class EntityInfo
        {
            private static readonly IEntity[] EmptyArray = new IEntity[] { };

            private readonly IEntity m_Entity;
            private EntityStatus m_Status;
            private IEntity m_ParentEntity;
            private List<IEntity> m_ChildEntities;

            /// <summary>
            /// 初始化实体信息的新实例
            /// </summary>
            /// <param name="entity">实体</param>
            public EntityInfo(IEntity entity)
            {
                if(entity == null)
                {
                    throw new GameFrameworkException("Entity is invalid");
                }

                m_Entity = entity;
                m_Status = EntityStatus.WillInit;
                m_ParentEntity = null;
                m_ChildEntities = null;
            }

            /// <summary>
            /// 实体
            /// </summary>
            public IEntity Entity
            {
                get { return m_Entity; }
            }

            /// <summary>
            /// 获取或设置实例状态
            /// </summary>
            public EntityStatus Status
            {
                get { return m_Status; }
                set { m_Status = value; }
            }

            /// <summary>
            /// 获取或设置父实体
            /// </summary>
            public IEntity ParentEntity
            {
                get { return m_ParentEntity; }
                set { m_ParentEntity = value; }
            }

            /// <summary>
            /// 获取子实体
            /// </summary>
            /// <returns>子实体</returns>
            public IEntity[] GetChildEntities()
            {
                if(m_ChildEntities == null)
                {
                    return EmptyArray;
                }

                return m_ChildEntities.ToArray();
            }

            /// <summary>
            /// 增加子实体
            /// </summary>
            /// <param name="childEntity">子实体</param>
            public void AddChildEntity(IEntity childEntity)
            {
                if(m_ChildEntities == null)
                {
                    m_ChildEntities = new List<IEntity>();
                }

                if (m_ChildEntities.Contains(childEntity))
                {
                    throw new GameFrameworkException("Can not add child entity which is already exist.");
                }

                m_ChildEntities.Add(childEntity);
            }

            /// <summary>
            /// 移除子实体
            /// </summary>
            /// <param name="childEntity">子实体</param>
            public void RemoveChildEntity(IEntity childEntity)
            {
                if(m_ChildEntities == null || !m_ChildEntities.Remove(childEntity))
                {
                    throw new GameFrameworkException("Can not remove child entity which is not exist");
                }
            }
        }
    }
}
