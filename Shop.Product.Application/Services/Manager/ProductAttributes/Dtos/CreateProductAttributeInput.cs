using AutoMapper;
using Shop.Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Product.Application.Services.Manager.ProductAttributes.Dtos
{
    [AutoMap(typeof(ProductAttribueEntity))]
    public class CreateProductAttributeInput : BaseProductAttributeInput
    {
    }
}
