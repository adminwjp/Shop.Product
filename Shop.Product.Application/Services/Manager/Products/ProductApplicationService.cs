using Autofac.Annotation;
using Shop.Product.Application.Services.Manager.Products.Dtos;
using Shop.Product.Application.Services.Manager.Specs;
using Shop.Product.Domain.Entities;
using Shop.Product.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Utility.Application.Services;
using Utility.Cache;
using Utility.Ioc;
using Utility.ObjectMapping;
using Utility.Page;

namespace Shop.Product.Application.Services.Manager.Products
{
    /// <summary>
    /// 产品 服务 
    /// </summary>
    [Component(typeof(ProductApplicationService), AutofacScope = AutofacScope.InstancePerLifetimeScope)]
    public class ProductApplicationService: BaseAppService<ProductEntity,CreateProductInput,UpdateProductInput,ProductInput,ProductOutput>
    {
        private IProductRepository repository;
        public ProductApplicationService(IProductRepository repository,IObjectMapper objectMapper,IIocManager iocManager, ICacheContent cache) 
            :base(repository,objectMapper,cache)
        {
            this.repository = repository;
            this.ObjectMapper = objectMapper;
            this.IocManager = iocManager;
        }
        
       

        /// <summary>
        /// 根据分类 查询商品 任何用户可以查询 展示 页面显示
        /// 1.放人缓存里面  缓存查询; 内存 还是 分布式 缓存 查询, 内存 查询所有 再次条件查询; 分布式缓存 需要什么查询什么 
        /// 2.不放人缓存 直接库里 查
        /// </summary>
        /// <param name="catalogId"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>

        public  IList<ProductOutput> FindByPage(string catalogId,int page = 1, int size = 10)
        {
            var res = repository.FindByPage(it=>!it.IsDeleted&&it.CatalogID==catalogId, page, size);
            var result = ObjectMapper.Map<IList<ProductOutput>>(res);
            return result;
        }

        /// <summary>
        /// 根据分类 查询商品 任何用户可以查询 展示 页面显示
        /// 1.放人缓存里面  缓存查询; 内存 还是 分布式 缓存 查询, 内存 查询所有 再次条件查询; 分布式缓存 需要什么查询什么 
        /// 2.不放人缓存 直接库里 查
        /// </summary>
        /// <param name="catalogId"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>

        public IList<ProductAndSpecDto> FindToGetAllProductAndSpecDtoByPage(string catalogId, int page = 1, int size = 10)
        {
            var res = repository.FindByPage(it => !it.IsDeleted && it.CatalogID == catalogId, page, size);
            var result = ObjectMapper.Map<IList<ProductAndSpecDto>>(res);
            var spce = IocManager.Get<SpecApplicationService>();
            foreach (var item in result)
            {
                var specDtos = spce.FindByPage(item.Id, page, size);
                item.Specs = specDtos;
            }
            return result;
        }

        /// <summary>
        /// 添加库存
        /// 1.如果放入缓存 也要 更新 分类服务 的商品信息
        /// 2.不放人缓存 直接数据库操作 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool AddSocket(string id, int num)
        {
            repository.AddSocket(id, num);
            return true;
        }

        /// <summary>
        /// 移除库存 修改库存
        /// 1.如果放入缓存 也要 更新 分类服务 的商品信息
        /// 2.不放人缓存 直接数据库操作 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool RemoveSocket(string id, int num)
        {
            repository.RemoveSocket(id, num);
            return true;
        }

        /// <summary>
        /// 价格变动
        /// 1.如果放入缓存 也要 更新 分类服务 的商品信息
        /// 2.不放人缓存 直接数据库操作 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newPrice"></param>
        /// <returns></returns>
        public bool UpdatePrice(string id, decimal newPrice)
        {
            repository.UpdatePrice(id, newPrice);
            return true;
        }
    }
}
