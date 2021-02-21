using Autofac.Annotation;
using Shop.Product.Application.Services.Manager.Catalogs.Dtos;
using Shop.Product.Application.Services.Manager.Dtos;
using Shop.Product.Domain.Entities;
using Shop.Product.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility.Cache;
using Utility.ObjectMapping;

namespace Shop.Product.Application.Services.Manager.Catalogs
{
    [Component(typeof(CatalogAppService), AutofacScope = AutofacScope.InstancePerLifetimeScope)]
    public class CatalogAppService:BaseAppService<CatalogEntity, CreateCatalogInput, UpdateCatalogInput,CatalogInput, CatalogOutput>
    {
        private ICatalogRepository repository;
        public CatalogAppService(ICatalogRepository repository, IObjectMapper objectMapper, ICacheContent cache)
            : base(repository, objectMapper, cache)
        {
            this.repository = repository;
        }

 

        public virtual List<CatalogDto> FindCatalog()
        {
            var datas = repository.FindCatalog();
            if (datas?.Count==0)
            {
                return null;
            }
            List<CatalogDto> catalogDtos = new List<CatalogDto>();
            Dictionary<string, CatalogDto> caches = new Dictionary<string, CatalogDto>();
            foreach (var item in datas)
            {
                CatalogDto temp = new CatalogDto() { Label = item.Name, Value = item.Id };
                CatalogDto catalog = null;
                if (item.Pid == null)
                {
                    if (caches.ContainsKey(item.Pid))
                    {
                        catalog = caches[item.Pid];
                        catalog.Label = item.Name;
                    }
                    else
                    {
                        catalogDtos.Add(temp);
                        caches[item.Pid] = temp;
                    }
                }
                else
                {
                    if (caches.ContainsKey(item.Pid))
                    {
                        catalog = caches[item.Pid];
                    }
                    else
                    {
                        catalog = new CatalogDto() { Value=item.Pid};
                        catalogDtos.Add(catalog);
                        caches[item.Pid] = catalog;
                    }
                    catalog.Children = catalog.Children ?? new List<CatalogDto>();
                    catalog.Children.Add(temp);
                }
            }
            return catalogDtos;
        }
    }
}
