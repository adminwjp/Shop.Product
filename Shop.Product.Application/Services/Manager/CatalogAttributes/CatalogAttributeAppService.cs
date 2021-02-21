using Autofac.Annotation;
using Shop.Product.Application.Services.Manager.CatalogAttributes.Dtos;
using Shop.Product.Domain.Entities;
using Shop.Product.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Cache;
using Utility.ObjectMapping;

namespace Shop.Product.Application.Services.Manager.CatalogAttributes
{
    [Component(typeof(CatalogAttributeAppService), AutofacScope = AutofacScope.InstancePerLifetimeScope)]
    public class CatalogAttributeAppService : BaseAppService<CatalogAttribueEntity, CreateCatalogAttributeInput, UpdateCatalogAttributeInput, CatalogAttributeInput, CatalogAttributeOutput>
    {
        private ICatalogAttributeRepository repository;
        public CatalogAttributeAppService(ICatalogAttributeRepository repository, IObjectMapper objectMapper, ICacheContent cache)
            : base(repository, objectMapper, cache)
        {
            this.repository = repository;
        }
    }
}
