using Shop.Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility.Application.Services.Dtos;
//using Utility.Domain.Entities;
using Utility.Domain.Repositories;

namespace Shop.Product.Domain.Repositories
{
    public interface IBaseRepository<Entity> : IRepository<Entity> where Entity:BaseEntity
    {
        void Delete(string id);

        void Delete(string[] ids);

        IList<Entity> Find(Entity entity);

        IList<Entity> FindByPage(Entity entity, int page = 1, int size = 10);

        ResultDto<Entity> FindResultDtoByPage(Entity entity, int page = 1, int size = 10);

        int Count(Entity entity);


    }
}
