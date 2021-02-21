using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Utility.Domain.Entities;

namespace Shop.Product.Domain.Entities
{
    /// <summary>
    /// 基类 实体
    /// </summary>
    public class BaseEntity:IEntity<string>,IHasCreationTime,IHasModificationTime,IHasDeletionTime,IDomainEvent
    {
        int? _requestedHashCode;
        /// <summary>
        /// 主键 Specified key was too long; max key length is 767 bytes
        /// </summary>
       	[Column("id")]
        [System.ComponentModel.DataAnnotations.StringLength(36)]
        public virtual string Id { get; set; }
        /// <summary>
        /// 创建 时间 datetime(6) mysql 不支持 ; datetime mysql 支持
        /// </summary>
        [System.ComponentModel.DataAnnotations.Schema.Column("creation_time"
#if MySql
            , TypeName = "datetime"
#endif
            )]
        public virtual DateTime CreationTime { get; set; }
        /// <summary>
        /// 修改 时间
        /// </summary>
        [System.ComponentModel.DataAnnotations.Schema.Column("last_modification_time"
#if MySql
            , TypeName = "datetime"
#endif
            )]
        public virtual DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        [System.ComponentModel.DataAnnotations.Schema.Column("deletion_time"
#if MySql
            , TypeName = "datetime"
#endif
            )]
        public virtual DateTime? DeletionTime { get; set; }
        /// <summary>
        /// 软删除 标识
        /// </summary>
        [Column("is_deleted")]
        public virtual bool IsDeleted { get; set; }

        private List<INotification> _domainEvents;
        /// <summary>
        /// 双向 订阅
        /// </summary>
        public virtual IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

        public virtual void Update(BaseEntity baseEntity)
        {
            this.Id = baseEntity.Id;
            this.CreationTime = baseEntity.CreationTime;
            this.LastModificationTime = baseEntity.LastModificationTime;
            this.DeletionTime = baseEntity.DeletionTime;
            this.IsDeleted = baseEntity.IsDeleted;
        }
        /// <summary>
        /// 添加 双向 订阅
        /// </summary>
        /// <param name="eventItem"></param>
        public virtual void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        /// <summary>
        /// 移除 双向 订阅
        /// </summary>
        /// <param name="eventItem"></param>
        public virtual void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        /// <summary>
        /// 清空 双向 订阅
        /// </summary>
        public virtual void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        public virtual bool IsTransient()
        {
            return this.Id == default(string);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is BaseEntity))
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            BaseEntity item = (BaseEntity)obj;

            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();

        }
        public static bool operator ==(BaseEntity left, BaseEntity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(BaseEntity left, BaseEntity right)
        {
            return !(left == right);
        }
    }
}
