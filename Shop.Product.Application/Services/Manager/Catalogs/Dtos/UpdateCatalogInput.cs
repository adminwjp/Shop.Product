using AutoMapper;
using Shop.Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Product.Application.Services.Manager.Catalogs.Dtos
{
    [AutoMap(typeof(CatalogEntity))]
    public class UpdateCatalogInput: CreateCatalogInput
    {
        public virtual string Id { get; set; }
    }
}
