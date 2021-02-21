using AutoMapper;
using Shop.Product.Application.Services.Manager.Dtos;
using Shop.Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Product.Application.Services.Manager.ProductAttributes.Dtos
{
    [AutoMap(typeof(ProductAttribueEntity))]
    public class ProductAttributeOutput: BasetOutput
    {
        /// <summary>
        /// 参数id
        /// </summary>
        public string AttributeId { get; set; }
        /// <summary>
        /// 商品 id
        /// </summary>
        public string ProductId { get; set; }

        public string Value { get; set; }
    }
}
