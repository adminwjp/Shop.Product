using AutoMapper;
using Shop.Product.Application.Services.Manager.Specs.Dtos;
using Shop.Product.Domain.Entities;
using System.Collections.Generic;

namespace Shop.Product.Application.Services.Manager.Products.Dtos
{
    /// <summary>
    ///查询 产品   返回 实体
    /// </summary>
    [AutoMap(typeof(ProductEntity))]
    public class ProductAndSpecDto:ProductDto
    {
        public IList<SpecOutput> Specs { get; set; }
    }
}
