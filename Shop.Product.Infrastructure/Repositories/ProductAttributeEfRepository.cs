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
    [Component(typeof(IProductAttributeRepository), AutofacScope = AutofacScope.InstancePerLifetimeScope)]

    public class ProductAttributeEfRepository: BaseEfRepository<ProductAttribueEntity>, IProductAttributeRepository
    {
        public ProductAttributeEfRepository(ProductDbContext dbContext) : base(dbContext)
        {

        }
    }
}
