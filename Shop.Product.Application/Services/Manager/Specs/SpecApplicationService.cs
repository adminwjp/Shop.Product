using Autofac.Annotation;
using Shop.Product.Application.Services.Manager.Specs.Dtos;
using Shop.Product.Domain.Entities;
using Shop.Product.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility.Application.Services;
using Utility.Cache;
using Utility.ObjectMapping;
using Utility.Page;

namespace Shop.Product.Application.Services.Manager.Specs
{
    /// <summary>
    /// 产品 规格 服务
    /// </summary>
    [Component(typeof(SpecApplicationService), AutofacScope = AutofacScope.InstancePerLifetimeScope)]
    public class SpecApplicationService : BaseAppService<SpecEntity,CreateSpecInput,UpdateSpecInput,SpecInput,SpecOutput>
    {
        private ISpecRepository repository;
        public SpecApplicationService(ISpecRepository repository, IObjectMapper objectMapper, ICacheContent cache)
            : base(repository, objectMapper, cache)
        {
            this.repository = repository;
        }
        

        /// <summary>
        /// 根据商品 id 查询商品规格 任何用户可以查询 展示 页面显示
        /// 1.放人缓存里面  缓存查询; 内存 还是 分布式 缓存 查询, 内存 查询所有 再次条件查询; 分布式缓存 需要什么查询什么 
        /// 2.不放人缓存 直接库里 查
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>

        public IList<SpecOutput> FindByPage(string productID, int page = 1, int size = 10)
        {
            var res = repository.FindByPage(it=>it.ProductID==productID&&!it.IsDeleted, page, size);
            var result = ObjectMapper.Map<IList<SpecOutput>>(res);
            return result;
        }
    }
}
