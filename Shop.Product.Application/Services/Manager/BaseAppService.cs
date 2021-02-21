using Autofac.Annotation;
using Shop.Product.Domain.Entities;
using Shop.Product.Domain.Repositories;
using System;
using System.Collections.Generic;
using Utility.Application.Services;
using Utility.Application.Services.Dtos;
using Utility.Cache;
using Utility.ObjectMapping;
using Utility.Page;

namespace Shop.Product.Application.Services.Manager
{
    /// <summary>
    /// (增删改查)基础 服务
    /// </summary>
    [Component(typeof(BaseAppService<,,,,>), AutofacScope = AutofacScope.InstancePerLifetimeScope)]
    public class BaseAppService<Entity,CreateInput, UpdateInput, GetInput, GetOutput> : ApplicationService
        where Entity:BaseEntity,new()
        where CreateInput :class
        where UpdateInput : class
        where GetInput : class
        where GetOutput : class
    {
        private IBaseRepository<Entity> repository;

        public BaseAppService(IBaseRepository<Entity> repository, IObjectMapper objectMapper, ICacheContent cache)
        {
            this.repository = repository;
            this.ObjectMapper = objectMapper;
            this.Cache = cache;
        }


        /// <summary>
        /// 添加
        /// 1.如果放入缓存 也要 更新 该信息
        /// 2.不放人缓存 直接数据库操作 
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        public virtual int Insert(CreateInput create)
        {
            Entity entity = ObjectMapper.Map<Entity>(create);
            entity.Id = Guid.NewGuid().ToString("N");
            repository.Insert(entity);
            return 1;
        }

        /// <summary>
        /// 修改 
        /// 1.如果放入缓存 也要 更新 该信息
        /// 2.不放人缓存 直接数据库操作 
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        public virtual int Update(UpdateInput update)
        {
            Entity entity = ObjectMapper.Map<Entity>(update);
            repository.Update(entity);
            return 1;
        }

        /// <summary>
        /// 删除
        /// 1.如果放入缓存 也要 更新 该信息
        /// 2.不放人缓存 直接数据库操作 
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(string id)
        {
            repository.Delete(id);
        }

        /// <summary>
        /// 删除
        /// 1.如果放入缓存 也要 更新 该信息
        /// 2.不放人缓存 直接数据库操作 
        /// </summary>
        /// <param name="ids"></param>
        public virtual void Delete(string[] ids)
        {
            repository.Delete(ids);
        }

        /// <summary>
        /// 根据条件查询 
        /// 1.如果放入缓存 缓存查询 
        /// 2.不放人缓存 直接数据库操作 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual IList<GetOutput> Find(GetInput input)
        {
            Entity entity = ObjectMapper.Map<Entity>(input);
            var res = repository.Find(entity);
            var result = ObjectMapper.Map<IList<GetOutput>>(res);
            return result;
        }

        /// <summary>
        /// 根据条件查询 
        /// 1.如果放入缓存 缓存查询 
        /// 2.不放人缓存 直接数据库操作 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public virtual IList<GetOutput> FindByPage(GetInput input, int page = 1, int size = 10)
        {
            PageHelper.Set(ref page, ref size);
            Entity entity = ObjectMapper.Map<Entity>(input);
            var res = repository.FindByPage(entity, page, size);
            var result = ObjectMapper.Map<IList<GetOutput>>(res);
            return result;
        }

        /// <summary>
        /// 根据条件查询 
        /// 1.如果放入缓存 缓存查询 
        /// 2.不放人缓存 直接数据库操作 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public virtual ResultDto<GetOutput> FindResultDtoByPage(GetInput input, int page = 1, int size = 10)
        {
            PageHelper.Set(ref page, ref size);
            Entity entity = ObjectMapper.Map<Entity>(input);
            var res = repository.FindResultDtoByPage(entity, page, size);
            //var result = ObjectMapper.Map<ResultDto<IList<GetOutput>>>(res); //error
            var data = ObjectMapper.Map<List<GetOutput>>(res.Data);
            var result = new ResultDto<GetOutput>() { Data=data,Result=res.Result};
            return result;
        }

        /// <summary>
        /// 根据条件查询 
        /// 1.如果放入缓存 缓存查询 
        /// 2.不放人缓存 直接数据库操作 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual int Count(GetInput input)
        {
            Entity entity = ObjectMapper.Map<Entity>(input);
            var res = repository.Count(entity);
            return res;
        }

    }
}
