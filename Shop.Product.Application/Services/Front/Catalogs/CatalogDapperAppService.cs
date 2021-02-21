using Autofac.Annotation;
using Shop.Product.Application.Services.Front.Catalogs.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Logging;
using Utility.Domain.Uow;
using Shop.Product.Domain.Entities;
using System.Linq.Expressions;
using Utility.Extensions;
using Shop.Product.Infrastructure;
using Utility.Ef.Uow;

namespace Shop.Product.Application.Services.Front.Catalogs
{
    /// <summary>
    ///前端  的 菜单 信息
    /// </summary>
    [Component(typeof(ICatalogAppService), AutofacScope = AutofacScope.InstancePerLifetimeScope)]
    public class CatalogDapperAppService: ICatalogAppService
    {
        //[Autowired]
        protected readonly ILogger<CatalogDapperAppService> logger;
        //[Autowired]
        private readonly IDbConnection connection;
        //[Autowired]
        protected readonly IUnitWork unitWork;
        private readonly ProductDbContext dbContext;

        public CatalogDapperAppService(ILogger<CatalogDapperAppService> logger, ProductDbContext dbContext)
        {
            this.logger = logger;
            this.unitWork = new EfUnitWork(dbContext);
            this.connection = unitWork.Connection;
           
        }

        //[Autowired] 
        //private readonly ProductDbContext productDbContext;
        /**
         -- 查询 分类 、子分类 及 父分类 商品(数据量 大话 没必要),再过滤
       SELECT
		c.id,
		c.NAME name,
		c.pid,
		p.NAME product_name,
		p.id product_id 
	FROM
		t_catalog c
		LEFT JOIN (
		SELECT
			p.catalog_id,
			p.id,
			p.NAME,
			p.creation_time 
		FROM
			t_product p 
		WHERE
			catalog_id IN ( SELECT id FROM t_catalog WHERE pid IS NOT NULL OR pid != '0' ) 
		ORDER BY
			hit DESC,
			creation_time 
		) p ON c.id = p.catalog_id 
	ORDER BY
		c.pid,
		c.creation_time DESC,
	p.creation_time DESC 
         */
        /// <summary>
        /// 菜单 分类  
        /// 查询 分类 、子分类  及 父分类 前3 热销商品
        /// 一条  sql 查询 嵌套太多 重复 查询 sql 太多(效率低 sql 还复杂  不好维护);
        /// 查询 分类 、子分类  及 父分类 商品(数据量 大话 没必要),再过滤 ;
        /// 自定义  实现(存储过程 自定义 函数 实现 麻烦 数据库不同 语法也不同)
        /// 单表查询 再组合
        /// </summary>
        /// <returns></returns>
        public virtual IList<CatalogOutput> Catalogs()
        {
            string sql = $"select Id,Name,Code,Pid,Flag from {CatalogEntity.TableName} where flag={(int)CatalogFlag.Nav} or flag={(int)CatalogFlag.ChildrenNav} order by order1,creation_time";
            List<CatalogOutput> catalogs = FindCatalogs<CatalogOutput>(sql);
            if (catalogs == null)
            {
                return catalogs;
            }
            foreach (var item in catalogs)
            {
                if(item.Cids!=null)
                {
                    //"An exception was thrown while attempting to evaluate a LINQ query parameter expression. 
                    //To show additional information call EnableSensitiveDataLogging() when overriding DbContext.OnConfiguring
                    Expression<Func<ProductEntity, bool>> where=null;//=it=>it.CatalogID==item.Pids[0];
                    //for (int i = 1; i < item.Pids.Count; i++)
                    //{
                    //    where = where.Or(it => it.CatalogID == item.Pids[i]);
                    //}      
                    foreach (var id in item.Cids)
                    {
                        where = where.Or(it => it.CatalogID == id);
                    }
                    var productEntities = unitWork.Find(where).OrderByDescending(it => it.Hit)
                        .OrderByDescending(it=>it.CreationTime).Select(it => new ProductOutput { Name= it.Name, Id= it.Id }).Take(3).ToList();
                    if (productEntities != null && productEntities.Count > 0)
                    {
                        item.Products = item.Products ?? new List<ProductOutput>();
                        item.Products.AddRange(productEntities);
                    }
                }
            }
            return catalogs;
        }

        /// <summary>
        ///  导航 菜单 分类  
        /// </summary>
        /// <returns></returns>
        public virtual List<NavgationOutput> NavgationCatalogs()
        {
            //这样 查询绑定数据为 null
            List<NavgationOutput> catalogEntities = unitWork.Connection.Query<NavgationOutput>($"select Id,Name,Code from {CatalogEntity.TableName}  where flag={(int)CatalogFlag.Nav}   order by order1,creation_time").ToList();
            return catalogEntities;
        }

        /// <summary>
        /// 底部导航菜单
        /// </summary>
        /// <returns></returns>
        public virtual IList<BottomOutput> Bottom()
        {
            string sql = $"select Id,Name,Code,Pid,Flag from {CatalogEntity.TableName} where flag={(int)CatalogFlag.BottomNav}  order by order1,creation_time";
            List<BottomOutput> catalogs = FindCatalogs<BottomOutput>(sql);
            return catalogs;
        }
        /// <summary>
        /// 底部导航菜单 链接
        /// </summary>
        /// <returns></returns>
        public virtual IList<BottomNavgationOutput> BottomLink()
        {
            string sql = $"select Id,Name,Http,Target from {CatalogEntity.TableName} where flag={(int)CatalogFlag.BottomNavLink}  order by order1,creation_time";
            List<BottomNavgationOutput> bottoms = unitWork.Connection.Query<BottomNavgationOutput>(sql).ToList();
            return bottoms;
        }
        /// <summary>
        /// 整理 菜单 分类  
        /// </summary>
        /// <returns></returns>
        public virtual List<T> FindCatalogs<T>(string sql)where T:BottomOutput<T>,new()
        {
            //这样 查询绑定数据为 null
            List<CatalogEntity> catalogEntities = unitWork.Connection.Query<CatalogEntity>(sql).ToList();
            //List<CatalogEntity> catalogEntities = unitWork.Find<CatalogEntity>().OrderByDescending(it => it.Order1)
            //    .OrderByDescending(it => it.CreationTime).Select(it => new CatalogEntity() { Id = it.Id, Name = it.Name, Code = it.Code, Pid = it.Pid }).ToList();

            if (catalogEntities == null || catalogEntities.Count == 0)
            {
                logger.LogInformation(" find  catalog success,not have data ");
                return null;
            }
            List<T> catalogs = new List<T>();
            List<CatalogEntity> notFounds = new List<CatalogEntity>();
            foreach (var item in catalogEntities)
            {
                T catalogOutput = new T();
                Set(catalogOutput, item);
                if (item.Pid == null || item.Pid.Equals("0") || item.Pid.Equals(string.Empty)&&item.Flag== CatalogFlag.Nav)
                {
                    catalogs.Add(catalogOutput);
                }
                else
                {
                    T parent = catalogs.Find(it => it.Id.Equals(item.Pid));
                    if (parent == null)
                    {
                        logger.LogWarning(" find parent catalog fail,add notFounds list, {Pid} ", item.Pid);
                        notFounds.Add(item);
                    }
                    else
                    {
                        if(item.Flag== CatalogFlag.ChildrenNav)
                        {
                            SetParent(parent, catalogOutput, item);
                        }
                        else
                        {
                            logger.LogWarning(" find parent catalog success, {Pid} children {Id} not match ", item.Pid,item.Id);
                        }
                    }
                }
            }
            if (notFounds.Any())
            {
                foreach (var item in notFounds)
                {
                    T catalogOutput = new T();
                    Set(catalogOutput, item);
                    T parent = catalogs.Find(it => it.Id.Equals(item.Pid));
                    if (parent == null)
                    {
                        logger.LogError("notFounds list find parent catalog fail,{Pid} ", item.Pid);
                        //throw new Exception($"notFounds list find parent catalog fail,{item.Pid} ");
                    }
                    else
                    {
                        SetParent(parent,catalogOutput,item);
                    }
                }
            }
            return catalogs;
        }

        protected void SetParent<T>(T parent, T catalogOutput, CatalogEntity item) where T : BottomOutput<T>, new()
        {
            parent.Cids = parent.Cids ?? new List<string>();
            parent.Children = parent.Children ?? new List<T>();
            parent.Children.Add(catalogOutput);
            parent.Cids.Add(item.Id);
        }

        protected void Set<T>(T catalogOutput, CatalogEntity item) where T : BottomOutput<T>, new()
        {
           
            catalogOutput.Id = item.Id;
            catalogOutput.Name = item.Name;
            catalogOutput.Code = item.Code;
        }

        public virtual IList<CatalogOutput> DapperCatalogs()
        {
            string sql = @"";
            var data = connection.Query(sql);
            List<CatalogOutput> catalogs = new List<CatalogOutput>();
            foreach (var item in data)
            {
                CatalogOutput catalogOutput = new CatalogOutput();
                catalogOutput.Id = item.id;
                catalogOutput.Name = item.name;
                if (item.pid == null || item.pid == "0")
                {
                    catalogs.Add(catalogOutput);
                }
                else
                {
                    string pid = item.pid;
                    var parent = catalogs.Find(it => it.Id.Equals(pid));
                    if (parent == null)
                    {
                        logger.LogWarning("catalog id {CatalogId} not found", pid);
                    }
                    else
                    {
                        //parent.Children ??= new List<CatalogOutput>();
                        parent.Children = parent.Children ?? new List<CatalogOutput>();
                        parent.Children.Add(catalogOutput);
                        if (item.product_id != null)
                        {
                            catalogOutput.Products = catalogOutput.Products ?? new List<ProductOutput>();
                            ProductOutput productOutput = new ProductOutput();
                            catalogOutput.Products.Add(productOutput);
                            productOutput.Id = item.product_id;
                            productOutput.Name = item.product_name;
                        }
                    }
                }
            }
            return catalogs;
        }


    }
}
