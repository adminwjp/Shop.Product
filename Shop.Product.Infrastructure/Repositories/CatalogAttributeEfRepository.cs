using Autofac.Annotation;
using Shop.Product.Domain.Entities;
using Shop.Product.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Product.Infrastructure.Repositories
{
    [Component(typeof(ICatalogAttributeRepository), AutofacScope = AutofacScope.InstancePerLifetimeScope)]
    public class CatalogAttributeEfRepository : BaseEfRepository<CatalogAttribueEntity>, ICatalogAttributeRepository
    {
        public CatalogAttributeEfRepository(ProductDbContext dbContext) : base(dbContext)
        {

        }

    }
}
