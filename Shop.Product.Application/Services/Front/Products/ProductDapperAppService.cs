using Autofac.Annotation;
using Shop.Product.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shop.Product.Application.Services.Front.Products.Dtos;
using Shop.Product.Domain.Entities;
using Utility.Domain.Uow;
using Utility.Ef.Uow;
using Dapper;

namespace Shop.Product.Application.Services.Front.Products
{
    [Component(typeof(IProductAppService), AutofacScope = AutofacScope.InstancePerLifetimeScope)]
    public class ProductDapperAppService:IProductAppService
    {
        protected readonly ILogger<ProductDapperAppService> logger;
        private readonly ProductDbContext productDbContext;
        protected readonly IUnitWork unitWork;

        public ProductDapperAppService(ILogger<ProductDapperAppService> logger, ProductDbContext productDbContext)
        {
            this.logger = logger;
            this.productDbContext = productDbContext;
            this.unitWork = new EfUnitWork(productDbContext);
        }

        /// <summary>
        /// 获取 左侧 热门推荐商品
        /// </summary>
        /// <returns></returns>
        public virtual IList<LeftHotProductOutput> LeftHotProducts(int size=10)
        {
            //string sql = $"select Price ,now_Price NowPrice,Picture,Name from {ProductEntity.TableName} order by sell_count desc,hit desc,creation_time ";
            //List<LeftHotProductOutput> leftHotProductOutputs = unitWork.Connection.Query<LeftHotProductOutput>(sql).ToList();
            List<LeftHotProductOutput> leftHotProductOutputs = unitWork.Find<ProductEntity>().OrderByDescending(it=>it.Sales)
                .OrderByDescending(it => it.Hit).OrderByDescending(it => it.CreationTime).Select(it=>new LeftHotProductOutput() 
                {Id=it.Id,Price=it.Price,Picture=it.Picture,NowPrice=it.Price,Name=it.Name }).Take(size).ToList();
            return leftHotProductOutputs;
        }
        /// <summary>
        /// 获取  热门商品
        /// </summary>
        /// <returns></returns>
        public virtual IList<LeftHotProductOutput> HotProducts(int size = 10)
        {
            //string sql = $"select Price ,now_Price NowPrice,Picture,Name from {ProductEntity.TableName} order by sell_count desc,hit desc,creation_time ";
            //List<LeftHotProductOutput> leftHotProductOutputs = unitWork.Connection.Query<LeftHotProductOutput>(sql).ToList();
            List<LeftHotProductOutput> leftHotProductOutputs = unitWork.Find<ProductEntity>().OrderByDescending(it => it.Sales)
                .OrderByDescending(it => it.Hit).OrderByDescending(it => it.CreationTime).Select(it => new LeftHotProductOutput()
                { Id = it.Id, Price = it.Price, Picture = it.Picture, NowPrice = it.Price, Name = it.Name }).Take(size).ToList();
            return leftHotProductOutputs;
        }    
        /// <summary>
        /// 获取  最新商品
        /// </summary>
        /// <returns></returns>
        public virtual IList<LeftHotProductOutput> NewProducts(int size = 10)
        {
            //string sql = $"select Price ,now_Price NowPrice,Picture,Name from {ProductEntity.TableName} order by sell_count desc,hit desc,creation_time ";
            //List<LeftHotProductOutput> leftHotProductOutputs = unitWork.Connection.Query<LeftHotProductOutput>(sql).ToList();
            List<LeftHotProductOutput> leftHotProductOutputs = unitWork.Find<ProductEntity>(it=>it.IsNew=="y")
                .OrderByDescending(it => it.CreationTime).Select(it => new LeftHotProductOutput()
                { Id = it.Id, Price = it.Price, Picture = it.Picture, NowPrice = it.Price, Name = it.Name }).Take(size).ToList();
            return leftHotProductOutputs;
        }
        /// <summary>
        /// 获取  特价 商品
        /// </summary>
        /// <returns></returns>
        public virtual IList<LeftHotProductOutput> SpecialPriceProducts(int size = 10)
        {
            //string sql = $"select Price ,now_Price NowPrice,Picture,Name from {ProductEntity.TableName} order by sell_count desc,hit desc,creation_time ";
            //List<LeftHotProductOutput> leftHotProductOutputs = unitWork.Connection.Query<LeftHotProductOutput>(sql).ToList();
            List<LeftHotProductOutput> leftHotProductOutputs = unitWork.Find<ProductEntity>(it=>it.Sale=="y")
                .OrderByDescending(it => it.CreationTime).Select(it => new LeftHotProductOutput()
                { Id = it.Id, Price = it.Price, Picture = it.Picture, NowPrice = it.Price, Name = it.Name }).Take(size).ToList();
            return leftHotProductOutputs;
        }
        public void Products(string catalogId)
        {

        }

        public void Product(string productId)
        {

        }
    }
}
