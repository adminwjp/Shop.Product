using Autofac.Annotation;
using Shop.Product.Application.Services.Manager.ProductAttributes.Dtos;
using Shop.Product.Domain.Entities;
using Shop.Product.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Cache;
using Utility.ObjectMapping;

namespace Shop.Product.Application.Services.Manager.ProductAttributes
{
    [Component(typeof(ProductAttributeAppService), AutofacScope = AutofacScope.InstancePerLifetimeScope)]

    public class ProductAttributeAppService : BaseAppService<ProductAttribueEntity, CreateProductAttributeInput, UpdateProductAttributeInput, ProductAttributeInput, ProductAttributeOutput>
    {
        private IProductAttributeRepository repository;
        public ProductAttributeAppService(IProductAttributeRepository repository, IObjectMapper objectMapper, ICacheContent cache)
            : base(repository, objectMapper, cache)
        {
            this.repository = repository;
        }
    }
}
