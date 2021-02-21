using AutoMapper;
using Shop.Product.Domain.Entities;

namespace Shop.Product.Application.Services.Manager.Specs.Dtos
{
    /// <summary>
    ///添加 产品 规格 
    /// </summary>
   	[AutoMap(typeof(SpecEntity))]
    public class CreateSpecInput:BaseSpecInput
    {
    }
}
