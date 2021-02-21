using Autofac.Annotation;
using Shop.Product.Domain.Entities;
using Shop.Product.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Product.Infrastructure.Repositories
{
    [Component(typeof(ICatalogRepository), AutofacScope = AutofacScope.InstancePerLifetimeScope)]
    public class CatalogEfRepository : BaseEfRepository<CatalogEntity>, ICatalogRepository
    {
        public CatalogEfRepository(ProductDbContext dbContext) : base(dbContext)
        {

        }

        public IList<CatalogEntity> FindCatalog()
        {
            return base.Find((Expression<Func<CatalogEntity,bool>>)null).Select(it=>new CatalogEntity {Id=it.Id,Name=it.Name,Pid=it.Pid }).ToList();
        }
    }
}
