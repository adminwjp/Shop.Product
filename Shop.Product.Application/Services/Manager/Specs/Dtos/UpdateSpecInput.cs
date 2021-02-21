using AutoMapper;
using Shop.Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Product.Application.Services.Manager.Specs.Dtos
{

    /// <summary>
    ///修改 产品 规格 
    /// </summary>
    [AutoMap(typeof(SpecEntity))]
    public class UpdateSpecInput:BaseSpecInput
    {
        /// <summary>
        /// 主键
        /// </summary>
        public virtual string Id { get; set; }
    }
}
