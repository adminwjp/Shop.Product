using AutoMapper;
using Shop.Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Product.Application.Services.Manager.CatalogAttributes.Dtos
{
    [AutoMap(typeof(CatalogAttribueEntity))]
    public class UpdateCatalogAttributeInput : BaseCatalogAttributeInput
    {
        public virtual string Id { get; set; }
    }
}
