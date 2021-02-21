using Shop.Product.Domain.Entities;
using Shop.Product.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Utility.Application.Services.Dtos;
//using Utility.Domain.Entities;
using Utility.Ef.Repositories;
using Utility.Extensions;
using Z.EntityFramework.Plus;

namespace Shop.Product.Infrastructure.Repositories
{
    public class BaseEfRepository<Entity> : BaseEfRepository<ProductDbContext, Entity, string>, IBaseRepository <Entity>
        where Entity:BaseEntity,new()
    {
        public BaseEfRepository(ProductDbContext dbContext) : base(dbContext)
        {

        }
        public override void Update(Entity entity)
        {
            var old = FindSingle(it => it.Id == entity.Id);
            entity.CreationTime = old.CreationTime;
            entity.DeletionTime = old.DeletionTime;
            entity.IsDeleted = old.IsDeleted;
            base.Update(entity);
        }
        public void Delete(string id)
        {
            DbContext.Set<Entity>().Where(it => it.Id == id).Update(it => new Entity() { DeletionTime = DateTime.Now, IsDeleted = true });
            DbContext.SaveChanges();
        }
        public void Delete(string[] ids)
        {
            Expression<Func<Entity, bool>> where = null;
            foreach (var item in ids)
            {
                where = where.Or(it => it.Id == item);
            }

            DbContext.Set<Entity>().Where(where).Update(it => new Entity() { DeletionTime = DateTime.Now, IsDeleted = true });
            DbContext.SaveChanges();
        }
        public IList<Entity> Find(Entity entity)
        {
            var where = GetWhere(entity);
            //where = where.And(it => it.IsDeleted == false);//删除的数据 不查询
            return Find(where).ToList();
        }

        public IList<Entity> FindByPage(Entity entity, int page = 1, int size = 10)
        {
            var where = GetWhere(entity);
            //where = where.And(it => it.IsDeleted == false);//删除的数据 不查询
            return FindByPage(where,page,size).ToList();
        }
        public ResultDto<Entity> FindResultDtoByPage(Entity entity, int page = 1, int size = 10)
        {
            var where = GetWhere(entity);
            //where = where.And(it => it.IsDeleted == false);//删除的数据 不查询
            var datas= FindByPage(where, page, size).ToList();
            var count = Count(where);
            return new ResultDto<Entity>(datas, count, page, size);
        }

        public int Count(Entity entity)
        {
            var where = GetWhere(entity);
            //where = where.And(it => it.IsDeleted == false);//删除的数据 不查询
            return Count(where);
        }
    }
   
}
