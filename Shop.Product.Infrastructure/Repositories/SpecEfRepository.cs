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
	/// 产品 规格 仓库 基于 ef 实现 
	/// </summary>
	[Component(typeof(ISpecRepository), AutofacScope = AutofacScope.InstancePerLifetimeScope)]
	public class SpecEfRepository : BaseEfRepository<SpecEntity>, ISpecRepository
    {
        public SpecEfRepository(ProductDbContext dbContext) : base(dbContext)
        {

        }
		protected override Expression<Func<SpecEntity, bool>> GetWhere(SpecEntity entity)
		{
			Expression<Func<SpecEntity, bool>> where = null;
			if (!string.IsNullOrEmpty(entity.ProductID))
			{
				where = where.Or(it => it.ProductID == entity.ProductID);
			}
			if (!string.IsNullOrEmpty(entity.Size))
			{
				where = where.Or(it => it.Size.Contains(entity.Size));
			}
			if (!string.IsNullOrEmpty(entity.Color))
			{
				where = where.Or(it => it.Color.Contains(entity.Color));
			}
			return where;
		}

		public bool AddSocket(string id, int num)
		{
			base.Update(it => it.Id == id, it => new SpecEntity() { Stock = it.Stock + num });
			return true;
		}

		public bool RemoveSocket(string id, int num)
		{
			base.Update(it => it.Id == id, it => new SpecEntity() { Stock = it.Stock - num });
			return true;
		}
		public bool UpdatePrice(string id, decimal newPrice)
		{
			base.Update(it => it.Id == id, it => new SpecEntity() { Price = newPrice });
			return true;
		}
	}
}
