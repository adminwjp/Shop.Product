using AutoMapper;
using Shop.Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Product.Application.Services.Manager.ProductAttributes.Dtos
{
    [AutoMap(typeof(ProductAttribueEntity))]
    public class UpdateProductAttributeInput : BaseProductAttributeInput
    {
        /// <summary>
        /// 主键
        /// </summary>
        public virtual string Id { get; set; }
    }
}
