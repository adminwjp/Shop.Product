using AutoMapper;
using Shop.Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Product.Application.Services.Manager.Products.Dtos
{
    /// <summary>
	/// 修改 产品 实体
	/// </summary>
    [AutoMap(typeof(ProductEntity))]
    public class UpdateProductInput:BaseProductInput
    {
        /// <summary>
        /// 主键
        /// </summary>
        public virtual string Id { get; set; }
        /// <summary>
        /// 更新账户
        /// </summary>
        public virtual string UpdateAccount { get; set; }
    }
}
