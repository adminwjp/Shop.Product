using Autofac.Annotation;
using Shop.Product.Domain.Entities;
using Shop.Product.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Utility.Ef.Repositories;
using Utility.Extensions;
using Z.EntityFramework.Plus;

namespace Shop.Product.Infrastructure.Repositories
{
	/// <summary>
	/// 产品 仓库 基于 ef 实现 
	/// </summary>
	[Component(typeof(IProductRepository), AutofacScope = AutofacScope.InstancePerLifetimeScope)]
	public class ProductEfRepository : BaseEfRepository<ProductEntity>, IProductRepository
    {
        public ProductEfRepository(ProductDbContext dbContext ):base(dbContext)
        {

        }
        protected override Expression<Func<ProductEntity, bool>> GetWhere(ProductEntity entity)
        {
                Expression<Func<ProductEntity, bool>> where = null;
                if (!string.IsNullOrEmpty(entity.CatalogID))
                {
					where = where.Or(it => it.CatalogID == entity.CatalogID);
				}
				if (!string.IsNullOrEmpty(entity.Keywords))
				{
					where = where.Or(it => it.Keywords.Contains(entity.Keywords));
				}
				if (!string.IsNullOrEmpty(entity.CreateAccount))
				{
					where = where.Or(it => it.CreateAccount == entity.CreateAccount);
				}
				if (!string.IsNullOrEmpty(entity.Title))
				{
					where = where.Or(it => it.Title.Contains(entity.Title));
				}
				if (!string.IsNullOrEmpty(entity.UpdateAccount))
				{
					where = where.Or(it => it.UpdateAccount == entity.UpdateAccount);
				}
				if (!string.IsNullOrEmpty(entity.ActivityID))
				{
					where = where.Or(it => it.ActivityID == entity.ActivityID);
				}
				if (entity.Status!=0)
				{
					where = where.Or(it => it.Status == entity.Status);
				}
				if (!string.IsNullOrEmpty(entity.SearchKey))
				{
					where = where.Or(it => it.SearchKey.Contains(entity.SearchKey));
				}
				if (!string.IsNullOrEmpty(entity.Name))
				{
					where = where.Or(it => it.Name.Contains(entity.Name));
				}
				if (!string.IsNullOrEmpty(entity.GiftID))
				{
					where = where.Or(it => it.GiftID == entity.GiftID);
				}
                return where;
        }

		public bool AddSocket(string id,int num)
        {
			base.Update(it => it.Id == id,it=> new ProductEntity() { Stock=it.Stock+num});
			return true;
        }

		public bool RemoveSocket(string id, int num)
		{
			base.Update(it => it.Id == id, it => new ProductEntity() { Stock = it.Stock - num });
			return true;
		}
		public bool UpdatePrice(string id, decimal newPrice)
		{
			base.Update(it => it.Id == id, it => new ProductEntity() { Price= newPrice });
			return true;
		}
	}
}
